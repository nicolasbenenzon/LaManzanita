using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;


namespace Manzanita
{
    public partial class frmAlert : Form
    {
        public bool fadeComplete = false;

        public frmAlert()
        {
            InitializeComponent();
        }

        private void frmAlert_Load(object sender, EventArgs e)
        {
            this.Opacity = 0D;
            timerOpening.Enabled = true;
            timerWaitingFade.Enabled = false;
            fadeComplete = false;
            this.Cursor = AdvancedCursors.Create(Path.Combine(Application.StartupPath, Lib.path + "cursor.ani"));
        }

        private void timerOpening_Tick(object sender, EventArgs e)
        {
            if (this.Opacity < 100D) this.Opacity += 0.1D;
            if (timerWaitingFade.Enabled == false && fadeComplete == true)
            {
                if (this.Opacity > 0D) this.Opacity -= 0.2D;
                else
                {
                    timerOpening.Enabled = false;
                    this.Dispose();
                }
            }
            else timerWaitingFade.Enabled = true;
        }

        private void timerWaitingFade_Tick(object sender, EventArgs e)
        {
            timerWaitingFade.Enabled = false;
            fadeComplete = true;
        }

        private void lblInvalidUser_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void rectangleShape1_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void rectangleShape1_MouseDown(object sender, MouseEventArgs e)
        {
            DragWindow.MouseDown(e);
        }

        private void rectangleShape1_MouseMove(object sender, MouseEventArgs e)
        {
            DragWindow.MouseMove(e, this);
        }

        private void rectangleShape1_MouseUp(object sender, MouseEventArgs e)
        {
            DragWindow.MouseUp(e);
        }

        private void lblInvalidUser_MouseDown(object sender, MouseEventArgs e)
        {
            DragWindow.MouseDown(e);
        }

        private void lblInvalidUser_MouseMove(object sender, MouseEventArgs e)
        {
            DragWindow.MouseMove(e, this);
        }

        private void lblInvalidUser_MouseUp(object sender, MouseEventArgs e)
        {
            DragWindow.MouseUp(e);
        }

        private void frmAlert_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void frmAlert_MouseDown(object sender, MouseEventArgs e)
        {
            DragWindow.MouseDown(e);
        }

        private void frmAlert_MouseMove(object sender, MouseEventArgs e)
        {
            DragWindow.MouseMove(e, this);
        }

        private void frmAlert_MouseUp(object sender, MouseEventArgs e)
        {
            DragWindow.MouseUp(e);
        }
    }
}
