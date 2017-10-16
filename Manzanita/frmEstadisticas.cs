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
    public partial class frmEstadisticas : Form
    {
        public frmEstadisticas()
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

        private void pctClose_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void pctCancel_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void pctCancel_MouseEnter(object sender, EventArgs e)
        {
            pctCancel.BackColor = Color.LightCoral;
        }

        private void pctCancel_MouseLeave(object sender, EventArgs e)
        {
            pctCancel.BackColor = Color.White;
        }

        private void pctReset_Click(object sender, EventArgs e)
        {
            /*bool value = AlertBox.Question("¿Estás seguro que quieres reiniciar los contadores?", "red");
            if (value)
            {
                
            }*/
            GameData.cantLosApple = GameData.cantLosCereza = GameData.cantLosOrange = GameData.cantLosPera = GameData.cantLosAnana = GameData.cantLosBanana = GameData.cantLosStar = GameData.cantLosBAR50 = GameData.cantLosBAR100 = GameData.cantWinCereza = GameData.cantWinApple = GameData.cantNuevoTiro = GameData.cantWinOrange = GameData.cantWinPera = GameData.cantWinAnana = GameData.cantWinBanana = GameData.cantWinStar = GameData.cantWinBAR50 = GameData.cantWinBAR100 = GameData.cantWinGoldCoinsCereza = GameData.cantWinGoldCoinsApple = GameData.cantWinGoldCoinsOrange = GameData.cantWinGoldCoinsPera = GameData.cantWinGoldCoinsAnana = GameData.cantWinGoldCoinsBanana = GameData.cantWinGoldCoinsStar = GameData.cantWinGoldCoinsBAR50 = GameData.cantWinGoldCoinsBAR100 = GameData.cantWinSilverCoinsCereza = GameData.cantWinSilverCoinsApple = GameData.cantWinSilverCoinsOrange = GameData.cantWinSilverCoinsPera = GameData.cantWinSilverCoinsAnana = GameData.cantWinSilverCoinsBanana = GameData.cantWinSilverCoinsStar = GameData.cantWinSilverCoinsBAR50 = GameData.cantWinSilverCoinsBAR100 = 0;
            lblCaidasCereza.Text = "Caídas: " + (GameData.cantWinCereza + GameData.cantLosCereza).ToString();
            lblCaidasApple.Text = "Caídas: " + (GameData.cantWinApple + GameData.cantLosApple).ToString();
            lblCaidasOrange.Text = "Caídas: " + (GameData.cantWinOrange + GameData.cantLosOrange).ToString();
            lblCaidasPera.Text = "Caídas: " + (GameData.cantWinPera + GameData.cantLosPera).ToString();
            lblCaidasAnana.Text = "Caídas: " + (GameData.cantWinAnana + GameData.cantLosAnana).ToString();
            lblCaidasBanana.Text = "Caídas: " + (GameData.cantWinBanana + GameData.cantLosBanana).ToString();
            lblCaidasStar.Text = "Caídas: " + (GameData.cantWinStar + GameData.cantLosStar).ToString();
            lblCaidasBAR50.Text = "Caídas: " + (GameData.cantWinBAR50 + GameData.cantLosBAR50).ToString();
            lblCaidasBAR100.Text = "Caídas: " + (GameData.cantWinBAR100 + GameData.cantLosBAR100).ToString();
            lblCaidasNuevoTiro.Text = "Caídas: " + (GameData.cantNuevoTiro).ToString();
            lblPerdidasCereza.Text = "Caídas perdidas: " + GameData.cantLosCereza.ToString();
            lblPerdidasApple.Text = "Caídas perdidas: " + GameData.cantLosApple.ToString();
            lblPerdidasOrange.Text = "Caídas perdidas: " + GameData.cantLosOrange.ToString();
            lblPerdidasPera.Text = "Caídas perdidas: " + GameData.cantLosPera.ToString();
            lblPerdidasAnana.Text = "Caídas perdidas: " + GameData.cantLosAnana.ToString();
            lblPerdidasBanana.Text = "Caídas perdidas: " + GameData.cantLosBanana.ToString();
            lblPerdidasStar.Text = "Caídas perdidas: " + GameData.cantLosStar.ToString();
            lblPerdidasBAR50.Text = "Caídas perdidas: " + GameData.cantLosBAR50.ToString();
            lblPerdidasBAR100.Text = "Caídas perdidas: " + GameData.cantLosBAR100.ToString();
            lblGanadasCereza.Text = "Caídas ganadas: " + GameData.cantWinCereza.ToString();
            lblGanadasApple.Text = "Caídas ganadas: " + GameData.cantWinApple.ToString();
            lblGanadasOrange.Text = "Caídas ganadas: " + GameData.cantWinOrange.ToString();
            lblGanadasPera.Text = "Caídas ganadas: " + GameData.cantWinPera.ToString();
            lblGanadasAnana.Text = "Caídas ganadas: " + GameData.cantWinAnana.ToString();
            lblGanadasBanana.Text = "Caídas ganadas: " + GameData.cantWinBanana.ToString();
            lblGanadasStar.Text = "Caídas ganadas: " + GameData.cantWinStar.ToString();
            lblGanadasBAR50.Text = "Caídas ganadas: " + GameData.cantWinBAR50.ToString();
            lblGanadasBAR100.Text = "Caídas ganadas: " + GameData.cantWinBAR100.ToString();
            lblGoldCereza.Text = GameData.cantWinGoldCoinsCereza.ToString();
            lblGoldApple.Text = GameData.cantWinGoldCoinsApple.ToString();
            lblGoldOrange.Text = GameData.cantWinGoldCoinsOrange.ToString();
            lblGoldPera.Text = GameData.cantWinGoldCoinsPera.ToString();
            lblGoldAnana.Text = GameData.cantWinGoldCoinsAnana.ToString();
            lblGoldBanana.Text = GameData.cantWinGoldCoinsBanana.ToString();
            lblGoldStar.Text = GameData.cantWinGoldCoinsStar.ToString();
            lblGoldBAR50.Text = GameData.cantWinGoldCoinsBAR50.ToString();
            lblGoldBAR100.Text = GameData.cantWinGoldCoinsBAR100.ToString();
            lblSilverCereza.Text = GameData.cantWinSilverCoinsCereza.ToString();
            lblSilverApple.Text = GameData.cantWinSilverCoinsApple.ToString();
            lblSilverOrange.Text = GameData.cantWinSilverCoinsOrange.ToString();
            lblSilverPera.Text = GameData.cantWinSilverCoinsPera.ToString();
            lblSilverAnana.Text = GameData.cantWinSilverCoinsAnana.ToString();
            lblSilverBanana.Text = GameData.cantWinSilverCoinsBanana.ToString();
            lblSilverStar.Text = GameData.cantWinSilverCoinsStar.ToString();
            lblSilverBAR50.Text = GameData.cantWinSilverCoinsBAR50.ToString();
            lblSilverBAR100.Text = GameData.cantWinSilverCoinsBAR100.ToString();
        }

        private void pctReset_MouseEnter(object sender, EventArgs e)
        {
            pctReset.BackColor = Color.LightGreen;
        }

        private void pctReset_MouseLeave(object sender, EventArgs e)
        {
            pctReset.BackColor = Color.White;
        }

        private void frmEstadisticas_Load(object sender, EventArgs e)
        {
            this.Cursor = AdvancedCursors.Create(Path.Combine(Application.StartupPath, Lib.path + "cursor.ani"));
            lblCaidasCereza.Text = "Caídas: " + (GameData.cantWinCereza + GameData.cantLosCereza).ToString();
            lblCaidasApple.Text = "Caídas: " + (GameData.cantWinApple + GameData.cantLosApple).ToString();
            lblCaidasOrange.Text = "Caídas: " + (GameData.cantWinOrange + GameData.cantLosOrange).ToString();
            lblCaidasPera.Text = "Caídas: " + (GameData.cantWinPera + GameData.cantLosPera).ToString();
            lblCaidasAnana.Text = "Caídas: " + (GameData.cantWinAnana + GameData.cantLosAnana).ToString();
            lblCaidasBanana.Text = "Caídas: " + (GameData.cantWinBanana + GameData.cantLosBanana).ToString();
            lblCaidasStar.Text = "Caídas: " + (GameData.cantWinStar + GameData.cantLosStar).ToString();
            lblCaidasBAR50.Text = "Caídas: " + (GameData.cantWinBAR50 + GameData.cantLosBAR50).ToString();
            lblCaidasBAR100.Text = "Caídas: " + (GameData.cantWinBAR100 + GameData.cantLosBAR100).ToString();
            lblCaidasNuevoTiro.Text = "Caídas: " + (GameData.cantNuevoTiro).ToString();
            lblPerdidasCereza.Text = "Caídas perdidas: " + GameData.cantLosCereza.ToString();
            lblPerdidasApple.Text = "Caídas perdidas: " + GameData.cantLosApple.ToString();
            lblPerdidasOrange.Text = "Caídas perdidas: " + GameData.cantLosOrange.ToString();
            lblPerdidasPera.Text = "Caídas perdidas: " + GameData.cantLosPera.ToString();
            lblPerdidasAnana.Text = "Caídas perdidas: " + GameData.cantLosAnana.ToString();
            lblPerdidasBanana.Text = "Caídas perdidas: " + GameData.cantLosBanana.ToString();
            lblPerdidasStar.Text = "Caídas perdidas: " + GameData.cantLosStar.ToString();
            lblPerdidasBAR50.Text = "Caídas perdidas: " + GameData.cantLosBAR50.ToString();
            lblPerdidasBAR100.Text = "Caídas perdidas: " + GameData.cantLosBAR100.ToString();
            lblGanadasCereza.Text = "Caídas ganadas: " + GameData.cantWinCereza.ToString();
            lblGanadasApple.Text = "Caídas ganadas: " + GameData.cantWinApple.ToString();
            lblGanadasOrange.Text = "Caídas ganadas: " + GameData.cantWinOrange.ToString();
            lblGanadasPera.Text = "Caídas ganadas: " + GameData.cantWinPera.ToString();
            lblGanadasAnana.Text = "Caídas ganadas: " + GameData.cantWinAnana.ToString();
            lblGanadasBanana.Text = "Caídas ganadas: " + GameData.cantWinBanana.ToString();
            lblGanadasStar.Text = "Caídas ganadas: " + GameData.cantWinStar.ToString();
            lblGanadasBAR50.Text = "Caídas ganadas: " + GameData.cantWinBAR50.ToString();
            lblGanadasBAR100.Text = "Caídas ganadas: " + GameData.cantWinBAR100.ToString();
            lblGoldCereza.Text = GameData.cantWinGoldCoinsCereza.ToString();
            lblGoldApple.Text = GameData.cantWinGoldCoinsApple.ToString();
            lblGoldOrange.Text = GameData.cantWinGoldCoinsOrange.ToString();
            lblGoldPera.Text = GameData.cantWinGoldCoinsPera.ToString();
            lblGoldAnana.Text = GameData.cantWinGoldCoinsAnana.ToString();
            lblGoldBanana.Text = GameData.cantWinGoldCoinsBanana.ToString();
            lblGoldStar.Text = GameData.cantWinGoldCoinsStar.ToString();
            lblGoldBAR50.Text = GameData.cantWinGoldCoinsBAR50.ToString();
            lblGoldBAR100.Text = GameData.cantWinGoldCoinsBAR100.ToString();
            lblSilverCereza.Text = GameData.cantWinSilverCoinsCereza.ToString();
            lblSilverApple.Text = GameData.cantWinSilverCoinsApple.ToString();
            lblSilverOrange.Text = GameData.cantWinSilverCoinsOrange.ToString();
            lblSilverPera.Text = GameData.cantWinSilverCoinsPera.ToString();
            lblSilverAnana.Text = GameData.cantWinSilverCoinsAnana.ToString();
            lblSilverBanana.Text = GameData.cantWinSilverCoinsBanana.ToString();
            lblSilverStar.Text = GameData.cantWinSilverCoinsStar.ToString();
            lblSilverBAR50.Text = GameData.cantWinSilverCoinsBAR50.ToString();
            lblSilverBAR100.Text = GameData.cantWinSilverCoinsBAR100.ToString();
        }
    }
}
