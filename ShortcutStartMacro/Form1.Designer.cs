namespace ShortcutStartMacro
{
    partial class Form1
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnAdd = new System.Windows.Forms.Button();
            this.textBoxShortcut = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panelTask = new System.Windows.Forms.FlowLayoutPanel();
            this.btnTest = new System.Windows.Forms.Button();
            this.btnApplyHotKey = new System.Windows.Forms.Button();
            this.btnSaveMacro = new System.Windows.Forms.Button();
            this.btnLoadMacro = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(623, 29);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 34);
            this.btnAdd.TabIndex = 0;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // textBoxShortcut
            // 
            this.textBoxShortcut.Location = new System.Drawing.Point(76, 35);
            this.textBoxShortcut.Name = "textBoxShortcut";
            this.textBoxShortcut.Size = new System.Drawing.Size(250, 22);
            this.textBoxShortcut.TabIndex = 1;
            this.textBoxShortcut.Text = "F8";
            this.textBoxShortcut.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBoxShortcut_KeyDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 17);
            this.label1.TabIndex = 2;
            this.label1.Text = "HotKey";
            // 
            // panelTask
            // 
            this.panelTask.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelTask.AutoScroll = true;
            this.panelTask.Location = new System.Drawing.Point(12, 69);
            this.panelTask.Name = "panelTask";
            this.panelTask.Size = new System.Drawing.Size(1047, 497);
            this.panelTask.TabIndex = 3;
            // 
            // btnTest
            // 
            this.btnTest.Location = new System.Drawing.Point(704, 29);
            this.btnTest.Name = "btnTest";
            this.btnTest.Size = new System.Drawing.Size(92, 34);
            this.btnTest.TabIndex = 4;
            this.btnTest.Text = "Test";
            this.btnTest.UseVisualStyleBackColor = true;
            this.btnTest.Click += new System.EventHandler(this.btnTest_Click);
            // 
            // btnApplyHotKey
            // 
            this.btnApplyHotKey.Enabled = false;
            this.btnApplyHotKey.Location = new System.Drawing.Point(332, 32);
            this.btnApplyHotKey.Name = "btnApplyHotKey";
            this.btnApplyHotKey.Size = new System.Drawing.Size(75, 28);
            this.btnApplyHotKey.TabIndex = 5;
            this.btnApplyHotKey.Text = "Apply";
            this.btnApplyHotKey.UseVisualStyleBackColor = true;
            this.btnApplyHotKey.Click += new System.EventHandler(this.btnApplyHotKey_Click);
            // 
            // btnSaveMacro
            // 
            this.btnSaveMacro.Location = new System.Drawing.Point(891, 29);
            this.btnSaveMacro.Name = "btnSaveMacro";
            this.btnSaveMacro.Size = new System.Drawing.Size(75, 34);
            this.btnSaveMacro.TabIndex = 6;
            this.btnSaveMacro.Text = "Save";
            this.btnSaveMacro.UseVisualStyleBackColor = true;
            this.btnSaveMacro.Click += new System.EventHandler(this.btnSaveMacro_Click);
            // 
            // btnLoadMacro
            // 
            this.btnLoadMacro.Location = new System.Drawing.Point(972, 29);
            this.btnLoadMacro.Name = "btnLoadMacro";
            this.btnLoadMacro.Size = new System.Drawing.Size(75, 34);
            this.btnLoadMacro.TabIndex = 6;
            this.btnLoadMacro.Text = "Load";
            this.btnLoadMacro.UseVisualStyleBackColor = true;
            this.btnLoadMacro.Click += new System.EventHandler(this.btnLoadMacro_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1071, 580);
            this.Controls.Add(this.btnLoadMacro);
            this.Controls.Add(this.btnSaveMacro);
            this.Controls.Add(this.btnApplyHotKey);
            this.Controls.Add(this.btnTest);
            this.Controls.Add(this.panelTask);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxShortcut);
            this.Controls.Add(this.btnAdd);
            this.Name = "Form1";
            this.Text = "ShortcutStartMacro";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.TextBox textBoxShortcut;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.FlowLayoutPanel panelTask;
        private System.Windows.Forms.Button btnTest;
        private System.Windows.Forms.Button btnApplyHotKey;
        private System.Windows.Forms.Button btnSaveMacro;
        private System.Windows.Forms.Button btnLoadMacro;
    }
}

