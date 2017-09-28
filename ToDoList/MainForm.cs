using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ToDoList.DataObjects;

namespace ToDoList
{
    public partial class MainForm : Form
    {
        List<TaskItem> currentListItems = new List<TaskItem>();
        int currentMaxID = 0;
        bool sort = false;

        public MainForm()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            Rectangle thisScreen = Screen.PrimaryScreen.Bounds;

            Left = thisScreen.Right - Width;
            Height = thisScreen.Height;

            //DummyAdd();

            LoadList();
        }

        private void DummyAdd()
        {
            currentListItems.Add(new TaskItem { ID = 1, Caption = "one", Priority = Priority.Low, Active = true });
            currentListItems.Add(new TaskItem { ID = 3, Caption = "two", Priority = Priority.High, Active = false });
            TaskItem.Serialize(currentListItems, Constants.LIST_XML_FILE);
        }

        private void ToggleButtonText()
        {
            btnSort.Text = !sort ? "Unsorted" : "Sorted";
        }

        private void LoadList()
        {
            flowLayoutPanel1.Controls.Clear();
            currentListItems = TaskItem.Deserialize(Constants.LIST_XML_FILE);

            if (!sort)
            {
                foreach (TaskItem taskItem in currentListItems)
                {
                    if (taskItem.ID > currentMaxID)
                        currentMaxID = taskItem.ID;

                    if (!taskItem.Active)
                        continue;

                    DisplayTaskItem(taskItem);
                }
            }
            else
            {
                List<TaskItem> sortedList = new List<TaskItem>();

                AddtoSortedList(sortedList, Priority.Urgent);
                AddtoSortedList(sortedList, Priority.High);
                AddtoSortedList(sortedList, Priority.Medium);
                AddtoSortedList(sortedList, Priority.Low);

                foreach(TaskItem taskItem in sortedList)
                {
                    if (taskItem.ID > currentMaxID)
                        currentMaxID = taskItem.ID;

                    DisplayTaskItem(taskItem);
                }
            }
        }

        private void DisplayTaskItem(TaskItem taskItem)
        {
            ItemDisplay display = new ItemDisplay(taskItem);
            display.Width = 195;
            display.Delete += Delete_Item;
            display.Edit += Edit_Item;
            flowLayoutPanel1.Controls.Add(display);
        }

        private void AddtoSortedList(List<TaskItem> sortedList, Priority priority)
        {
            foreach (TaskItem taskItem in currentListItems)
            {
                if (!taskItem.Active)
                    continue;

                if (taskItem.Priority == priority)
                    sortedList.Add(taskItem);
            }
        }

        private void Edit_Item(object sender, EventArgs e)
        {
            ItemDisplay display = sender as ItemDisplay;
            TaskItem taskItem = display.TaskItem;

            using (AddForm editForm = new AddForm(taskItem))
            {
                editForm.StartPosition = FormStartPosition.CenterScreen;
                if (editForm.ShowDialog() != DialogResult.OK)
                    return;

                foreach (TaskItem item in currentListItems)
                {
                    if (item.ID != taskItem.ID)
                        continue;

                    item.Caption = taskItem.Caption;
                    item.Priority = taskItem.Priority;
                    SaveAndReload();
                }
            }
        }

        private void Delete_Item(object sender, EventArgs e)
        {
            ItemDisplay display = sender as ItemDisplay;
            int ID = display.TaskItem.ID;

            foreach (var item in currentListItems)
            {
                if (item.ID == ID)
                    item.Active = false;
            }

            SaveAndReload();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            using (AddForm addForm = new AddForm(currentMaxID + 1))
            {
                addForm.StartPosition = FormStartPosition.CenterScreen;
                if (addForm.ShowDialog() != DialogResult.OK)
                    return;

                currentListItems.Add(addForm.Item);
                SaveAndReload();
            }
        }

        private void SaveAndReload()
        {
            try
            {
                TaskItem.Serialize(currentListItems, Constants.LIST_XML_FILE);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            LoadList();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnSort_Click(object sender, EventArgs e)
        {
            sort = !sort;
            ToggleButtonText();
            LoadList();
        }
    }
}
