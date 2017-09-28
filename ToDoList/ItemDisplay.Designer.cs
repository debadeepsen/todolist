namespace ToDoList
{
    partial class ItemDisplay
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.picPriorityLevel = new System.Windows.Forms.PictureBox();
            this.lblTaskName = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.picPriorityLevel)).BeginInit();
            this.SuspendLayout();
            // 
            // picPriorityLevel
            // 
            this.picPriorityLevel.BackColor = System.Drawing.Color.DarkRed;
            this.picPriorityLevel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picPriorityLevel.Location = new System.Drawing.Point(11, 12);
            this.picPriorityLevel.Name = "picPriorityLevel";
            this.picPriorityLevel.Size = new System.Drawing.Size(24, 24);
            this.picPriorityLevel.TabIndex = 0;
            this.picPriorityLevel.TabStop = false;
            this.picPriorityLevel.Click += new System.EventHandler(this.picPriorityLevel_Click);
            this.picPriorityLevel.MouseEnter += new System.EventHandler(this.picPriorityLevel_MouseEnter);
            this.picPriorityLevel.MouseLeave += new System.EventHandler(this.picPriorityLevel_MouseLeave);
            // 
            // lblTaskName
            // 
            this.lblTaskName.AutoEllipsis = true;
            this.lblTaskName.BackColor = System.Drawing.Color.Transparent;
            this.lblTaskName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTaskName.Location = new System.Drawing.Point(45, 13);
            this.lblTaskName.Name = "lblTaskName";
            this.lblTaskName.Size = new System.Drawing.Size(351, 23);
            this.lblTaskName.TabIndex = 1;
            this.lblTaskName.Text = "label1";
            this.lblTaskName.Click += new System.EventHandler(this.this_Click);
            this.lblTaskName.MouseEnter += new System.EventHandler(this.this_MouseEnter);
            this.lblTaskName.MouseLeave += new System.EventHandler(this.this_MouseLeave);
            // 
            // ItemDisplay
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Snow;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.lblTaskName);
            this.Controls.Add(this.picPriorityLevel);
            this.Name = "ItemDisplay";
            this.Size = new System.Drawing.Size(424, 48);
            this.Click += new System.EventHandler(this.this_Click);
            this.MouseEnter += new System.EventHandler(this.this_MouseEnter);
            this.MouseLeave += new System.EventHandler(this.this_MouseLeave);
            ((System.ComponentModel.ISupportInitialize)(this.picPriorityLevel)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox picPriorityLevel;
        private System.Windows.Forms.Label lblTaskName;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}
