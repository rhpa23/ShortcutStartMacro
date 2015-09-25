using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ShortcutStartMacro
{
    public partial class UserControl1 : UserControl
    {
        #region Properties

        public enum TaskAction { Click, Press, Fill };

        public TaskAction SelectedTaskAction { get; set; }

        public KeyEventArgs SelectedKey { get; set; }

        public Point SelectedPoint { get; set; }

        public string SelectedText { get; set; }
        
        #endregion

        public UserControl1()
        {
            InitializeComponent();
        }

        private void radioClick_CheckedChanged(object sender, EventArgs e)
        {
            if (radioClick.Checked)
            {
                textBoxTask.Text = "Point cursor to target and press Space to set click position..";
                btnApply.Focus();
            }
            
        }

        private void radioPress_CheckedChanged(object sender, EventArgs e)
        {
            if (radioPress.Checked)
            {
                textBoxTask.Focus();
                textBoxTask.KeyDown += textBoxTask_KeyDown;
            }
            else
            {
                textBoxTask.KeyDown -= textBoxTask_KeyDown;
            }
        }

        private void radioFill_CheckedChanged(object sender, EventArgs e)
        {
            if (radioFill.Checked)
            {
                textBoxTask.Focus();
            }
        }

        void textBoxTask_KeyDown(object sender, KeyEventArgs e)
        {
            if (radioPress.Checked)
            {
                textBoxTask.Text = "Press key: " + MacroUtil.GetTextKeys(e);
                this.SelectedKey = e;

                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }


        private void btnApply_Click(object sender, EventArgs e)
        {
            if (radioClick.Checked)
            {
                int currentX = Cursor.Position.X;
                int currentY = Cursor.Position.Y;
                textBoxTask.Text = "Mouse X (" + currentX + ") - Mouse Y (" + currentY + ")";
                this.SelectedTaskAction = TaskAction.Click;
                this.SelectedPoint = new Point(currentX, currentY);
            }
            else if (radioFill.Checked)
            {
                this.SelectedTaskAction = TaskAction.Fill;
                SelectedText = textBoxTask.Text;
            }
            else if (radioPress.Checked)
            {
                this.SelectedTaskAction = TaskAction.Press;
            }
            this.panelEdit.Enabled = false;
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            this.Visible = false;
        }

        

        

    }
}
