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
    public partial class frmAlertInput : Form
    {
        public frmAlertInput()
        {
            InitializeComponent();
        }

        private void pctClose_Click(object sender, EventArgs e)
        {
            AlertBox.sVal = null;
            this.Dispose();
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

        private void pctAccept_Click(object sender, EventArgs e)
        {
            Accept();
        }

        private void pctCancel_Click(object sender, EventArgs e)
        {
            Cancel();
        }

        private void Accept()
        {
            AlertBox.sVal = txtText.Text;
            this.Dispose();
        }

        private void Cancel()
        {
            AlertBox.sVal = null;
            this.Dispose();
        }

        private void EnableKeysToControl(KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter) Accept();
            else if (e.KeyChar == (char)Keys.Escape) Cancel();
        }

        private void frmAlertInput_KeyPress(object sender, KeyPressEventArgs e)
        {
            EnableKeysToControl(e);
        }

        private void frmAlertInput_Leave(object sender, EventArgs e)
        {
            this.Activate();
        }

        private void txtText_KeyPress(object sender, KeyPressEventArgs e)
        {
            EnableKeysToControl(e);
        }

        private void pctAccept_MouseEnter(object sender, EventArgs e)
        {
            pctAccept.BackColor = Color.LightGreen;
        }

        private void pctAccept_MouseLeave(object sender, EventArgs e)
        {
            pctAccept.BackColor = Color.White;
        }

        private void pctCancel_MouseEnter(object sender, EventArgs e)
        {
            pctCancel.BackColor = Color.LightCoral;
        }

        private void pctCancel_MouseLeave(object sender, EventArgs e)
        {
            pctCancel.BackColor = Color.White;
        }

        private void frmAlertInput_Load(object sender, EventArgs e)
        {
            this.Cursor = AdvancedCursors.Create(Path.Combine(Application.StartupPath, Lib.path + "cursor.ani"));
        }
    }
}
