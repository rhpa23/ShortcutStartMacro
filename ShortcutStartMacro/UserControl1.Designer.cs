namespace ShortcutStartMacro
{
    partial class UserControl1
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.radioFill = new System.Windows.Forms.RadioButton();
            this.radioPress = new System.Windows.Forms.RadioButton();
            this.radioClick = new System.Windows.Forms.RadioButton();
            this.textBoxTask = new System.Windows.Forms.TextBox();
            this.btnApply = new System.Windows.Forms.Button();
            this.btnRemove = new System.Windows.Forms.Button();
            this.panelEdit = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.panelEdit.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.radioFill);
            this.panel1.Controls.Add(this.radioPress);
            this.panel1.Controls.Add(this.radioClick);
            this.panel1.Location = new System.Drawing.Point(6, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(223, 32);
            this.panel1.TabIndex = 0;
            // 
            // radioFill
            // 
            this.radioFill.AutoSize = true;
            this.radioFill.Location = new System.Drawing.Point(158, 7);
            this.radioFill.Name = "radioFill";
            this.radioFill.Size = new System.Drawing.Size(46, 21);
            this.radioFill.TabIndex = 2;
            this.radioFill.TabStop = true;
            this.radioFill.Text = "Fill";
            this.radioFill.UseVisualStyleBackColor = true;
            this.radioFill.CheckedChanged += new System.EventHandler(this.radioFill_CheckedChanged);
            // 
            // radioPress
            // 
            this.radioPress.AutoSize = true;
            this.radioPress.Location = new System.Drawing.Point(77, 7);
            this.radioPress.Name = "radioPress";
            this.radioPress.Size = new System.Drawing.Size(65, 21);
            this.radioPress.TabIndex = 1;
            this.radioPress.TabStop = true;
            this.radioPress.Text = "Press";
            this.radioPress.UseVisualStyleBackColor = true;
            this.radioPress.CheckedChanged += new System.EventHandler(this.radioPress_CheckedChanged);
            // 
            // radioClick
            // 
            this.radioClick.AutoSize = true;
            this.radioClick.Location = new System.Drawing.Point(3, 7);
            this.radioClick.Name = "radioClick";
            this.radioClick.Size = new System.Drawing.Size(58, 21);
            this.radioClick.TabIndex = 0;
            this.radioClick.TabStop = true;
            this.radioClick.Text = "Click";
            this.radioClick.UseVisualStyleBackColor = true;
            this.radioClick.CheckedChanged += new System.EventHandler(this.radioClick_CheckedChanged);
            // 
            // textBoxTask
            // 
            this.textBoxTask.Location = new System.Drawing.Point(235, 8);
            this.textBoxTask.Name = "textBoxTask";
            this.textBoxTask.Size = new System.Drawing.Size(604, 22);
            this.textBoxTask.TabIndex = 1;
            // 
            // btnApply
            // 
            this.btnApply.Location = new System.Drawing.Point(845, 5);
            this.btnApply.Name = "btnApply";
            this.btnApply.Size = new System.Drawing.Size(75, 29);
            this.btnApply.TabIndex = 2;
            this.btnApply.Text = "Apply";
            this.btnApply.UseVisualStyleBackColor = true;
            this.btnApply.Click += new System.EventHandler(this.btnApply_Click);
            // 
            // btnRemove
            // 
            this.btnRemove.Location = new System.Drawing.Point(932, 10);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(75, 29);
            this.btnRemove.TabIndex = 3;
            this.btnRemove.Text = "Remove";
            this.btnRemove.UseVisualStyleBackColor = true;
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // panelEdit
            // 
            this.panelEdit.Controls.Add(this.btnApply);
            this.panelEdit.Controls.Add(this.textBoxTask);
            this.panelEdit.Controls.Add(this.panel1);
            this.panelEdit.Location = new System.Drawing.Point(3, 5);
            this.panelEdit.Name = "panelEdit";
            this.panelEdit.Size = new System.Drawing.Size(923, 37);
            this.panelEdit.TabIndex = 4;
            // 
            // UserControl1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panelEdit);
            this.Controls.Add(this.btnRemove);
            this.Name = "UserControl1";
            this.Size = new System.Drawing.Size(1012, 49);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panelEdit.ResumeLayout(false);
            this.panelEdit.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnRemove;
        private System.Windows.Forms.Panel panelEdit;
        public System.Windows.Forms.RadioButton radioFill;
        public System.Windows.Forms.RadioButton radioPress;
        public System.Windows.Forms.RadioButton radioClick;
        public System.Windows.Forms.TextBox textBoxTask;
        public System.Windows.Forms.Button btnApply;
    }
}
