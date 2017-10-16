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
    public partial class frmStatic : Form
    {
        public frmStatic()
        {
            InitializeComponent();
        }

        private void frmStatic_Load(object sender, EventArgs e)
        {
            Resolution.adjustResolution(this);
            this.Cursor = AdvancedCursors.Create(Path.Combine(Application.StartupPath, Lib.path + "cursor.ani"));
            Lib.PlaySound("Billards.wav");
        }

        private void timerOpen_Tick(object sender, EventArgs e)
        {
            frmLoading FrmLoading = new frmLoading();
            FrmLoading.Show();
            FrmLoading = null;
            timerOpen.Enabled = false;
        }
    }
}
