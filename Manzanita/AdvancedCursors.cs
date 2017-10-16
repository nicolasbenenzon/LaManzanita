using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Runtime.InteropServices;

namespace Manzanita
{
    public static class AdvancedCursors
    {
        [DllImport("User32.dll")]

        private static extern IntPtr LoadCursorFromFile(String str);

        public static Cursor Create(string filename)
        {
            IntPtr hCursor = LoadCursorFromFile(filename);
            if (!IntPtr.Zero.Equals(hCursor))
            {
                return new Cursor(hCursor);
            }
            else
            {
                throw new ApplicationException("No puede acceder al archivo " + filename);
            }
        }
    }
}
