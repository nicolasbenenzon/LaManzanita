using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Media;
using System.IO;

namespace Manzanita
{
    public partial class frmLoading : Form
    {
        bool alreadyLoaded = false;
        int skipStep = 0;

        public frmLoading()
        {
            InitializeComponent();
        }

        private void timerParpSkip_Tick(object sender, EventArgs e)
        {
            if (lblSkip.Visible == true) lblSkip.Visible = false;
            else lblSkip.Visible = true;
        }

        private void frmLoading_Load(object sender, EventArgs e)
        {
            pctNaranja.Top = pctManzana.Top = pctPera.Top = -400;
            this.Focus();
            this.Opacity = 0D;
            this.Cursor = AdvancedCursors.Create(Path.Combine(Application.StartupPath, Lib.path + "cursor.ani"));
        }

        private void timerAnimation_Tick(object sender, EventArgs e)
        {
            if (timerShading.Enabled == false)
            {
                if (pctPera.Top < 159) pctPera.Top += 15;
                else if (pctPera.Top >= 159 && pctManzana.Top < 95) pctManzana.Top += 15;
                else if (pctPera.Top >= 159 && pctManzana.Top >= 95 && pctNaranja.Top < 176) pctNaranja.Top += 15;
                else if (pctPera.Top >= 159 && pctManzana.Top >= 95 && pctNaranja.Top >= 176)
                {
                    pctText.Visible = true;
                    timerParpSkip.Enabled = true;
                    pctText.Top = 500;
                }
            }
        }

        private void frmLoading_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter && timerParpSkip.Enabled == true)
            {
                alreadyLoaded = true;
                timerShading.Enabled = true;
            }
            else
            {
                if (skipStep == 0)
                {
                    pctPera.Top = 159;
                    skipStep++;
                }
                else if (skipStep == 1)
                {
                    pctManzana.Top = 95;
                    skipStep++;
                }
                else if (skipStep == 2)
                {
                    pctNaranja.Top = 176;
                    skipStep++;
                }
                else if (skipStep == 3)
                {
                    pctText.Visible = true;
                    timerParpSkip.Enabled = true;
                    pctText.Top = 500;
                }
            }
        }

        private void frmLoading_Leave(object sender, EventArgs e)
        {
            this.Focus();
        }

        private void frmLoading_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void timerShading_Tick(object sender, EventArgs e)
        {
            if (alreadyLoaded == false)
            {
                if (this.Opacity < 1D) this.Opacity += 0.006;
                else
                {
                    timerShading.Enabled = false;
                    timerAnimation.Enabled = true;
                }
            }
            else if (this.Opacity > 0D) this.Opacity -= 0.006D;
            else
            {
                timerShading.Enabled = false;
                frmMainMenu FrmMain = new frmMainMenu();
                FrmMain.Show();
                FrmMain = null;
                this.Dispose();
            }
        }
    }
}
