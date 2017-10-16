using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace Manzanita
{
    public static class DragWindow
    {
        public static bool formDragged = false;
        static int mousePosDownX = 0;
        static int mousePosDownY = 0;

        public static void MouseDown(MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                formDragged = true;
                mousePosDownX = e.X;
                mousePosDownY = e.Y;
            }
        }

        public static void MouseUp(MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left) formDragged = false;
        }

        public static void MouseMove(MouseEventArgs e, Form f)
        {
            if (formDragged == true)
            {
                Point tmpPoint = new Point();
                tmpPoint.X = f.Location.X + (e.X - mousePosDownX);
                tmpPoint.Y = f.Location.Y + (e.Y - mousePosDownY);
                f.Location = tmpPoint;
            }
        }
    }
}
