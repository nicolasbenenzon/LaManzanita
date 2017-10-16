using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Manzanita
{
    public class AlertBox
    {
        public static string sVal;
        public static bool mVal;

        public static void Notify(string text, bool color = false, string b_Color = "")
        {
            frmAlert FormAlert = new frmAlert();
            FormAlert.Show();
            FormAlert.Opacity = 0D;
            FormAlert.lblInvalidUser.Text = text;
            FormAlert.fadeComplete = false;
            if (color == false) FormAlert.BackColor = Color.LightCoral;
            else if (color == true) FormAlert.BackColor = Color.LightGreen;
            if (b_Color == "blue") FormAlert.BackColor = Color.LightBlue;
            FormAlert = null;
        }

        public static bool Question(string question, string color = "black")
        {
            frmAlertYesNo FrmAlertYesNo = new frmAlertYesNo();
            FrmAlertYesNo.lblQuestion.Text = question;
            if (color == "red") FrmAlertYesNo.lblQuestion.ForeColor = Color.Red;
            else if (color == "green") FrmAlertYesNo.lblQuestion.ForeColor = Color.Green;
            else if (color == "blue") FrmAlertYesNo.lblQuestion.ForeColor = Color.Blue;
            else FrmAlertYesNo.lblQuestion.ForeColor = Color.Black;
            FrmAlertYesNo.ShowDialog();
            FrmAlertYesNo = null;
            return (mVal);
        }

        public static string Input(string text, string color = "black", bool passChar = false)
        {
            frmAlertInput FrmAlertInput = new frmAlertInput();
            FrmAlertInput.lblText.Text = text;
            if (color == "red") FrmAlertInput.lblText.ForeColor = Color.Red;
            else if (color == "green") FrmAlertInput.lblText.ForeColor = Color.Green;
            else if (color == "blue") FrmAlertInput.lblText.ForeColor = Color.Blue;
            else FrmAlertInput.lblText.ForeColor = Color.Black;
            if (passChar) FrmAlertInput.txtText.PasswordChar = '•';
            else FrmAlertInput.txtText.PasswordChar = '\0';
            FrmAlertInput.ShowDialog();
            FrmAlertInput = null;
            return (sVal);
        }
    }
}
