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
    public partial class frmAlertYesNo : Form
    {
        public frmAlertYesNo()
        {
            InitializeComponent();
        }

        private void pctManzanita_Click(object sender, EventArgs e)
        {
            DragWindow.formDragged = false;
        }

        private void pctManzanita_MouseDown(object sender, MouseEventArgs e)
        {
            DragWindow.MouseDown(e);
        }

        private void pctManzanita_MouseMove(object sender, MouseEventArgs e)
        {
            DragWindow.MouseMove(e, this);
        }

        private void pctManzanita_MouseUp(object sender, MouseEventArgs e)
        {
            DragWindow.MouseUp(e);
        }

        private void frmAlertYesNo_Leave(object sender, EventArgs e)
        {
            this.Activate();
        }

        private void pctClose_Click(object sender, EventArgs e)
        {
            AlertBox.mVal = false;
            this.Dispose();
        }

        private void pctNo_Click(object sender, EventArgs e)
        {
            AlertBox.mVal = false;
            this.Dispose();
        }

        private void pctYes_Click(object sender, EventArgs e)
        {
            AlertBox.mVal = true;
            this.Dispose();
        }

        private void pctYes_MouseEnter(object sender, EventArgs e)
        {
            pctYes.BackColor = Color.LightGreen;
        }

        private void pctYes_MouseLeave(object sender, EventArgs e)
        {
            pctYes.BackColor = Color.White;
        }

        private void pctNo_MouseEnter(object sender, EventArgs e)
        {
            pctNo.BackColor = Color.LightCoral;
        }

        private void pctNo_MouseLeave(object sender, EventArgs e)
        {
            pctNo.BackColor = Color.White;
        }

        private void frmAlertYesNo_Load(object sender, EventArgs e)
        {
            this.Cursor = AdvancedCursors.Create(Path.Combine(Application.StartupPath, Lib.path + "cursor.ani"));
        }
    }
}
