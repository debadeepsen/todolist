using System;
using System.Drawing;
using System.Windows.Forms;
using ToDoList.DataObjects;

namespace ToDoList
{
    public partial class ItemDisplay : UserControl
    {
        public TaskItem TaskItem { get; set; }
        public event EventHandler Delete;
        public event EventHandler Edit;

        public ItemDisplay()
        {
            InitializeComponent();
        }

        public ItemDisplay(TaskItem taskItem)
        {
            InitializeComponent();
            TaskItem = taskItem;
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            int priorityIndex = (int)TaskItem.Priority;
            picPriorityLevel.BackColor = Constants.PRIORITY_COLORS[priorityIndex];
            toolTip1.SetToolTip(this, TaskItem.ToString());
            toolTip1.SetToolTip(lblTaskName, TaskItem.ToString());
            toolTip1.SetToolTip(picPriorityLevel, "Check this item off the list");

            lblTaskName.Text = TaskItem.Caption;
        }

        private void this_Click(object sender, EventArgs e)
        {
            if (Edit != null)
                Edit(this, EventArgs.Empty);
        }

        private void this_MouseEnter(object sender, EventArgs e)
        {
            BackColor = Color.LightGoldenrodYellow;
            lblTaskName.ForeColor = Color.Red;
            Cursor = Cursors.Hand;
        }

        private void this_MouseLeave(object sender, EventArgs e)
        {
            BackColor = Color.Snow;
            lblTaskName.ForeColor = Color.Black;
            Cursor = Cursors.Default;
        }

        private void picPriorityLevel_MouseEnter(object sender, EventArgs e)
        {
            picPriorityLevel.Image = Image.FromFile("checkmark.png");
        }

        private void picPriorityLevel_MouseLeave(object sender, EventArgs e)
        {
            picPriorityLevel.Image = null;
        }

        private void picPriorityLevel_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to check this item (" + TaskItem.Caption + ") off the list?", "Warning", MessageBoxButtons.YesNo) == DialogResult.No)
                return;

            if (Delete != null)
                Delete(this, EventArgs.Empty);
        }
    }
}
