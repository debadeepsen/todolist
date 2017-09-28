using System;
using System.Windows.Forms;
using ToDoList.DataObjects;

namespace ToDoList
{
    public partial class AddForm : Form
    {
        private TaskItem item = new TaskItem();
        public TaskItem Item { get { return item; } }

        public AddForm()
        {
            InitializeComponent();
            LoadFields();
        }

        public AddForm(int newID)
        {
            InitializeComponent();
            LoadFields();
            item.ID = newID;
        }

        public AddForm(TaskItem itemToEdit)
        {
            // edit mode
            InitializeComponent();
            item = itemToEdit;
            LoadFields();
            txtItemText.Text = itemToEdit.Caption;
            txtDescription.Text = itemToEdit.Description;
            cmbPriorities.SelectedIndex = (int)itemToEdit.Priority;
            Text = "Edit the following Task Item";
            btnSubmit.Text = "Modify";
        }

        private void LoadFields()
        {
            txtItemText.Select();
            txtItemText.Select(0, 0);

            foreach (var priority in Enum.GetNames(typeof(Priority)))
                cmbPriorities.Items.Add(priority);

            cmbPriorities.SelectedIndex = 0;
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            item.Caption = txtItemText.Text.Trim();
            item.Description = txtDescription.Text.Trim();
            item.Priority = (Priority)cmbPriorities.SelectedIndex;
            item.Active = true;
            DialogResult = DialogResult.OK;
            Close();
        }

        private void btnHiddenCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
