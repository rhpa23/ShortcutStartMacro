using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ShortcutStartMacro
{
    public class MacroUtil
    {
        public static string GetTextKeys(KeyEventArgs e)
        {
            var keys = new List<string>();

            if (e.Control == true)
            {
                keys.Add("CTRL");
            }

            if (e.Alt == true)
            {
                keys.Add("ALT");
            }

            if (e.Shift == true)
            {
                keys.Add("SHIFT");
            }

            switch (e.KeyCode)
            {
                case Keys.ControlKey:
                case Keys.Alt:
                case Keys.ShiftKey:
                case Keys.Menu:
                    break;
                default:
                    keys.Add(e.KeyCode.ToString()
                        .Replace("Oem", string.Empty)
                        );
                    break;
            }

            e.Handled = true;

            return string.Join(" + ", keys);
        }
    }
}
