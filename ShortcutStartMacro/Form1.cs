using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsInput;

namespace ShortcutStartMacro
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            RegisterHotKey(this.Handle, MYACTION_HOTKEY_ID, 0, _currentShortcutCode);
        }

        private int _currentShortcutCode = (int)Keys.F8;

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        private static extern short VkKeyScan(char ch);

        #region HotKey Registries
        // DLL libraries used to manage hotkeys
        [DllImport("user32.dll")]
        public static extern bool RegisterHotKey(IntPtr hWnd, int id, int fsModifiers, int vlc);
        [DllImport("user32.dll")]
        public static extern bool UnregisterHotKey(IntPtr hWnd, int id);

        const int MYACTION_HOTKEY_ID = 1;

        #endregion

        #region HotKey Modifiers
        public static int MOD_ALT = 0x1;
        public static int MOD_CONTROL = 0x2;
        public static int MOD_SHIFT = 0x4;
        public static int MOD_WIN = 0x8;
        public static int WM_HOTKEY = 0x312;
        #endregion

        #region Mouse registries
        //This is a replacement for Cursor.Position in WinForms
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        static extern bool SetCursorPos(int x, int y);

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern void mouse_event(int dwFlags, int dx, int dy, int cButtons, int dwExtraInfo);

        public const int MOUSEEVENTF_LEFTDOWN = 0x02;
        public const int MOUSEEVENTF_LEFTUP = 0x04;

        #endregion

        //This simulates a left mouse click
        public static void LeftMouseClick(int xpos, int ypos)
        {
            int currentX = Cursor.Position.X;
            int currentY = Cursor.Position.Y;

            SetCursorPos(xpos, ypos);
            mouse_event(MOUSEEVENTF_LEFTDOWN, xpos, ypos, 0, 0);
            mouse_event(MOUSEEVENTF_LEFTUP, xpos, ypos, 0, 0);
            SetCursorPos(currentX, currentY);
        }

        /// <summary>
        /// Called by hotkey.
        /// </summary>
        protected override void WndProc(ref Message m)
        {
            if (m.Msg == 0x0312 && m.WParam.ToInt32() == MYACTION_HOTKEY_ID)
            {
                StartCurrentMacro();
            }
            base.WndProc(ref m);
        }


        private void StartCurrentMacro()
        {
            foreach (UserControl1 control in panelTask.Controls)
            {
                if (control.Visible)
                {
                    Thread.Sleep(500);
                    switch (control.SelectedTaskAction)
                    {
                        case UserControl1.TaskAction.Click:
                            LeftMouseClick(control.SelectedPoint.X, control.SelectedPoint.Y);
                            break;
                        case UserControl1.TaskAction.Press:
                            SendKey(control.SelectedKey.KeyValue, control.SelectedKey.Modifiers);
                            break;
                        case UserControl1.TaskAction.Fill:
                            InputSimulator.SimulateTextEntry(control.SelectedText);
                            break;
                    }
                }
            }
        }


        public void SendKey(int keyValue, Keys modifiers)
        {
            VirtualKeyCode key;
            if (modifiers.Equals(Keys.None))
            {
                if (Enum.TryParse(VkKeyScan(((char)keyValue)).ToString(), out key))
                {
                    InputSimulator.SimulateKeyDown(key);
                    InputSimulator.SimulateKeyUp(key);
                }
            }
            else if (modifiers.Equals(Keys.Shift) && keyValue >= (int)Keys.A && keyValue <= (int)Keys.Z)
            {
                if (Enum.TryParse(VkKeyScan(((char)keyValue)).ToString(), out key))
                {
                    InputSimulator.SimulateModifiedKeyStroke(VirtualKeyCode.SHIFT, key);
                }
            }
            else if (modifiers.Equals(Keys.Control) && keyValue >= (int)Keys.A && keyValue <= (int)Keys.Z)
            {
                if (Enum.TryParse(VkKeyScan(((char)keyValue)).ToString(), out key))
                {
                    InputSimulator.SimulateModifiedKeyStroke(VirtualKeyCode.CONTROL, key);
                }
            }
            else if (modifiers.Equals(Keys.Alt) && keyValue >= (int)Keys.A && keyValue <= (int)Keys.Z)
            {
                if (Enum.TryParse(VkKeyScan(((char)keyValue)).ToString(), out key))
                {
                    //Alt is named MENU for legacy purposes.
                    InputSimulator.SimulateModifiedKeyStroke(VirtualKeyCode.MENU, key);
                }
            }

        }

        private void btnTest_Click(object sender, EventArgs e)
        {
            StartCurrentMacro();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            var task = new UserControl1();
            panelTask.Controls.Add(task);
        }

        private void textBoxShortcut_KeyDown(object sender, KeyEventArgs e)
        {
            textBoxShortcut.Text = MacroUtil.GetTextKeys(e);

            textBoxShortcut.Tag = e;

            btnApplyHotKey.Enabled = true;
            e.Handled = true;
            e.SuppressKeyPress = true;
        }

        private void btnApplyHotKey_Click(object sender, EventArgs e)
        {
            if (textBoxShortcut.Tag != null)
            {
                var keyEvent = (KeyEventArgs)textBoxShortcut.Tag;

                int modifiers = 0;
                
                if (keyEvent.Modifiers == Keys.Alt)
                    modifiers = modifiers | MOD_ALT;

                if (keyEvent.Modifiers == Keys.Control)
                    modifiers = modifiers | MOD_CONTROL;

                if (keyEvent.Modifiers == Keys.Shift)
                    modifiers = modifiers | MOD_SHIFT;


                UnregisterHotKey(this.Handle, MYACTION_HOTKEY_ID);
                RegisterHotKey(this.Handle, MYACTION_HOTKEY_ID, modifiers, keyEvent.KeyValue);
                _currentShortcutCode = keyEvent.KeyValue;
                btnApplyHotKey.Enabled = false;
            }
        }

        private void btnSaveMacro_Click(object sender, EventArgs e)
        {
            var saveDialog = new SaveFileDialog();
            saveDialog.Filter = "Ini Files (*.ini)|*.ini";
            DialogResult result = saveDialog.ShowDialog(this);
            if (result == DialogResult.OK)
            {
                var fileStream = saveDialog.OpenFile();
                var sw = new System.IO.StreamWriter(fileStream);
                sw.Flush();
                sw.Close();
                var ini = new IniFile(saveDialog.FileName);
                int index = 0;
                foreach (UserControl1 control in panelTask.Controls)
                {
                    if (control.Visible)
                    {
                        switch (control.SelectedTaskAction)
                        {
                            case UserControl1.TaskAction.Click:
                                ini.IniWriteValue("Properties", "click" + index, control.SelectedPoint.X + "," + control.SelectedPoint.Y);
                                break;
                            case UserControl1.TaskAction.Press:
                                ini.IniWriteValue("Properties", "press" + index, control.SelectedKey.KeyValue + "," + control.SelectedKey.Modifiers);
                                break;
                            case UserControl1.TaskAction.Fill:
                                ini.IniWriteValue("Properties", "fill" + index, control.SelectedText);
                                break;
                        }
                        index++;
                    }
                }
                MessageBox.Show("Macro saved!", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnLoadMacro_Click(object sender, EventArgs e)
        {
            try
            {
                var openFileDialog = new OpenFileDialog();
                openFileDialog.Filter = "Ini Files (*.ini)|*.ini";
                DialogResult result = openFileDialog.ShowDialog(this);
                if (result == DialogResult.OK)
                {
                    var ini = new IniFile(openFileDialog.FileName);
                    var macroValues = ini.GetKeysAndValues("Properties");
                    foreach (var macroValue in macroValues)
                    {
                        var task = new UserControl1();
                        panelTask.Controls.Add(task);

                        if (macroValue.Key.Contains("click"))
                        {
                            int cX = int.Parse(macroValue.Value.Split(',')[0]);
                            int cY = int.Parse(macroValue.Value.Split(',')[1]);
                            task.SelectedTaskAction = UserControl1.TaskAction.Click;
                            task.SelectedPoint = new Point(cX, cY);
                            task.radioClick.Checked = true;
                            task.textBoxTask.Text = "Mouse X (" + cX + ") - Mouse Y (" + cY + ")";
                        }
                        else if (macroValue.Key.Contains("press"))
                        {
                            //int keyCode = int.Parse(macroValue.Value.Split(',')[0]);
                            var theKey = (Keys)Enum.Parse(typeof(Keys), macroValue.Value.Split(',')[0]);
                            var theModifiers = (Keys)Enum.Parse(typeof(Keys), macroValue.Value.Split(',')[1]);
                            var keyEvent = new KeyEventArgs(theKey | theModifiers);

                            task.SelectedTaskAction = UserControl1.TaskAction.Press;
                            task.SelectedKey = keyEvent;
                            task.textBoxTask.Text = MacroUtil.GetTextKeys(keyEvent);
                            task.radioPress.Checked = true;
                        }
                        else if (macroValue.Key.Contains("fill"))
                        {
                            task.SelectedTaskAction = UserControl1.TaskAction.Fill;
                            task.SelectedText = macroValue.Value;
                            task.textBoxTask.Text = macroValue.Value;
                            task.radioFill.Checked = true;
                        }
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Error reading Macro file.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
