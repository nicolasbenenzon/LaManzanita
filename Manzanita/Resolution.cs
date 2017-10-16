using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace Manzanita
{
    public static class Resolution
    {
        public static void adjustResolution(Form form)
        {
            string width = Screen.PrimaryScreen.Bounds.Size.Width.ToString();
            string height = Screen.PrimaryScreen.Bounds.Size.Height.ToString();
            string size = width + "x" + height;
            switch (size)
            {
                case "800x600":
                    {
                        changeResolution(form, 110F, 110F);
                        break;
                    }
                case "1024x600":
                    {
                        changeResolution(form, 96F, 110F);
                        break;
                    }
                default:
                    {
                        changeResolution(form, 96F, 96F);
                        break;
                    }
            }
        }

        private static void changeResolution(Form form, float width, float height)
        {
            form.AutoScaleDimensions = new SizeF(width, height);
            form.PerformAutoScale();
        }
    }
}
