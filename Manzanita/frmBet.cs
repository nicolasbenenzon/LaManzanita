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
    public partial class frmBet : Form
    {
        string probabilidad = "";

        public frmBet()
        {
            InitializeComponent();
        }

        private void pctClose_Click(object sender, EventArgs e)
        {
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

        private void frmBet_Load(object sender, EventArgs e)
        {
            this.Cursor = AdvancedCursors.Create(Path.Combine(Application.StartupPath, Lib.path + "cursor.ani"));
            if (GameData.typeCoin == 1)
            {
                lblBetCoins.ForeColor = Color.Gold;
                pctCoins.BackgroundImage = Image.FromFile(Lib.path + "fichasoro.png");
                lblBetCoins.Text = GameData.insertedGoldCoins.ToString();
                prBAR100.BackColor = Color.Orange;
                prBAR50.BackColor = Color.Orange;
                prStar.BackColor = Color.Orange;
                prOrange.BackColor = Color.Lime;
                prApple.BackColor = Color.Lime;
                prCereza.BackColor = Color.Lime;
                prAnana.BackColor = Color.Lime;
                prBanana.BackColor = Color.Lime;
                prPera.BackColor = Color.Lime;
                lblBetCereza.ForeColor = lblBetApple.ForeColor = lblBetOrange.ForeColor = lblBetPera.ForeColor = lblBetAnana.ForeColor = lblBetBanana.ForeColor = lblBetStar.ForeColor = lblBetBAR50.ForeColor = lblBetBAR100.ForeColor = Color.Gold;
                GameData.insertedRealCoins = GameData.insertedGoldCoins;
                lblWhatsBet.ForeColor = Color.Goldenrod;
                lblWhatsBet.Text = "(Apostando fichas de oro, ganarás fichas de oro)";
            }
            else if (GameData.typeCoin == 2)
            {
                lblBetCoins.ForeColor = Color.LightGray;
                pctCoins.BackgroundImage = Image.FromFile(Lib.path + "fichasplata.png");
                lblBetCoins.Text = GameData.insertedSilverCoins.ToString();
                prBAR100.BackColor = Color.Red;
                prBAR50.BackColor = Color.Orange;
                prStar.BackColor = Color.Orange;
                prOrange.BackColor = Color.LightGreen;
                prApple.BackColor = Color.Lime;
                prCereza.BackColor = Color.Lime;
                prAnana.BackColor = Color.LightGreen;
                prBanana.BackColor = Color.LightGreen;
                prPera.BackColor = Color.LightGreen;
                lblBetCereza.ForeColor = lblBetApple.ForeColor = lblBetOrange.ForeColor = lblBetPera.ForeColor = lblBetAnana.ForeColor = lblBetBanana.ForeColor = lblBetStar.ForeColor = lblBetBAR50.ForeColor = lblBetBAR100.ForeColor = Color.LightGray;
                GameData.insertedRealCoins = GameData.insertedSilverCoins;
                lblWhatsBet.ForeColor = Color.LightGray;
                lblWhatsBet.Text = "(Apostando fichas de plata, ganarás fichas de plata)";
            }
        }

        private void pctCereza_Click(object sender, EventArgs e)
        {
            if (GameData.insertedRealCoins >= 1)
            {
                GameData.insertedRealCoins--;
                lblBetCoins.Text = GameData.insertedRealCoins.ToString();
                GameData.insertedCoinsCereza++;
                lblBetCereza.Text = (GameData.insertedCoinsCereza).ToString();
                lblRewardCereza.Text = Convert.ToString(GameData.VALUE_CEREZA * GameData.insertedCoinsCereza);
                if (GameData.insertedCoinsCereza >= 2) lblRewardCereza.ForeColor = Color.GreenYellow;
                else lblRewardCereza.ForeColor = Color.Black;
            }
            else AlertBox.Notify("No te quedan más fichas para apostar");
        }

        private void lblBAR100_Click(object sender, EventArgs e)
        {
            if (GameData.insertedRealCoins >= 1)
            {
                GameData.insertedRealCoins--;
                lblBetCoins.Text = GameData.insertedRealCoins.ToString();
                GameData.insertedCoinsBAR100++;
                lblBetBAR100.Text = (GameData.insertedCoinsBAR100).ToString();
                lblRewardBAR100.Text = Convert.ToString(GameData.VALUE_BAR100 * GameData.insertedCoinsBAR100);
                if (GameData.insertedCoinsBAR100 >= 2) lblRewardBAR100.ForeColor = Color.GreenYellow;
                else lblRewardBAR100.ForeColor = Color.Black;
            }
            else AlertBox.Notify("No te quedan más fichas para apostar");
        }

        private void lblBAR50_Click(object sender, EventArgs e)
        {
            if (GameData.insertedRealCoins >= 1)
            {
                GameData.insertedRealCoins--;
                lblBetCoins.Text = GameData.insertedRealCoins.ToString();
                GameData.insertedCoinsBAR50++;
                lblBetBAR50.Text = (GameData.insertedCoinsBAR50).ToString();
                lblRewardBAR50.Text = Convert.ToString(GameData.VALUE_BAR50 * GameData.insertedCoinsBAR50);
                if (GameData.insertedCoinsBAR50 >= 2) lblRewardBAR50.ForeColor = Color.GreenYellow;
                else lblRewardBAR50.ForeColor = Color.Black;
            }
            else AlertBox.Notify("No te quedan más fichas para apostar");
        }

        private void pctBAR50_Click(object sender, EventArgs e)
        {
            if (GameData.insertedRealCoins >= 1)
            {
                GameData.insertedRealCoins--;
                lblBetCoins.Text = GameData.insertedRealCoins.ToString();
                GameData.insertedCoinsBAR50++;
                lblBetBAR50.Text = (GameData.insertedCoinsBAR50).ToString();
                lblRewardBAR50.Text = Convert.ToString(GameData.VALUE_BAR50 * GameData.insertedCoinsBAR50);
                if (GameData.insertedCoinsBAR50 >= 2) lblRewardBAR50.ForeColor = Color.GreenYellow;
                else lblRewardBAR50.ForeColor = Color.Black;
            }
            else AlertBox.Notify("No te quedan más fichas para apostar");
        }

        private void pctStar_Click(object sender, EventArgs e)
        {
            if (GameData.insertedRealCoins >= 1)
            {
                GameData.insertedRealCoins--;
                lblBetCoins.Text = GameData.insertedRealCoins.ToString();
                GameData.insertedCoinsStar++;
                lblBetStar.Text = (GameData.insertedCoinsStar).ToString();
                lblRewardStar.Text = Convert.ToString(GameData.VALUE_STAR * GameData.insertedCoinsStar);
                if (GameData.insertedCoinsStar >= 2) lblRewardStar.ForeColor = Color.GreenYellow;
                else lblRewardStar.ForeColor = Color.Black;
            }
            else AlertBox.Notify("No te quedan más fichas para apostar");
        }

        private void pctBanana_Click(object sender, EventArgs e)
        {
            if (GameData.insertedRealCoins >= 1)
            {
                GameData.insertedRealCoins--;
                lblBetCoins.Text = GameData.insertedRealCoins.ToString();
                GameData.insertedCoinsBanana++;
                lblBetBanana.Text = (GameData.insertedCoinsBanana).ToString();
                lblRewardBanana.Text = Convert.ToString(GameData.VALUE_BANANA * GameData.insertedCoinsBanana);
                if (GameData.insertedCoinsBanana >= 2) lblRewardBanana.ForeColor = Color.GreenYellow;
                else lblRewardBanana.ForeColor = Color.Black;
            }
            else AlertBox.Notify("No te quedan más fichas para apostar");
        }

        private void pctAnana_Click(object sender, EventArgs e)
        {
            if (GameData.insertedRealCoins >= 1)
            {
                GameData.insertedRealCoins--;
                lblBetCoins.Text = GameData.insertedRealCoins.ToString();
                GameData.insertedCoinsAnana++;
                lblBetAnana.Text = (GameData.insertedCoinsAnana).ToString();
                lblRewardAnana.Text = Convert.ToString(GameData.VALUE_ANANA * GameData.insertedCoinsAnana);
                if (GameData.insertedCoinsAnana >= 2) lblRewardAnana.ForeColor = Color.GreenYellow;
                else lblRewardAnana.ForeColor = Color.Black;
            }
            else AlertBox.Notify("No te quedan más fichas para apostar");
        }

        private void pctPera_Click(object sender, EventArgs e)
        {
            if (GameData.insertedRealCoins >= 1)
            {
                GameData.insertedRealCoins--;
                lblBetCoins.Text = GameData.insertedRealCoins.ToString();
                GameData.insertedCoinsPera++;
                lblBetPera.Text = (GameData.insertedCoinsPera).ToString();
                lblRewardPera.Text = Convert.ToString(GameData.VALUE_PERA * GameData.insertedCoinsPera);
                if (GameData.insertedCoinsPera >= 2) lblRewardPera.ForeColor = Color.GreenYellow;
                else lblRewardPera.ForeColor = Color.Black;
            }
            else AlertBox.Notify("No te quedan más fichas para apostar");
        }

        private void pctOrange_Click(object sender, EventArgs e)
        {
            if (GameData.insertedRealCoins >= 1)
            {
                GameData.insertedRealCoins--;
                lblBetCoins.Text = GameData.insertedRealCoins.ToString();
                GameData.insertedCoinsOrange++;
                lblBetOrange.Text = (GameData.insertedCoinsOrange).ToString();
                lblRewardOrange.Text = Convert.ToString(GameData.VALUE_ORANGE * GameData.insertedCoinsOrange);
                if (GameData.insertedCoinsOrange >= 2) lblRewardOrange.ForeColor = Color.GreenYellow;
                else lblRewardOrange.ForeColor = Color.Black;
            }
            else AlertBox.Notify("No te quedan más fichas para apostar");
        }

        private void pctApple_Click(object sender, EventArgs e)
        {
            if (GameData.insertedRealCoins >= 1)
            {
                GameData.insertedRealCoins--;
                lblBetCoins.Text = GameData.insertedRealCoins.ToString();
                GameData.insertedCoinsApple++;
                lblBetApple.Text = (GameData.insertedCoinsApple).ToString();
                lblRewardApple.Text = Convert.ToString(GameData.VALUE_APPLE * GameData.insertedCoinsApple);
                if (GameData.insertedCoinsApple >= 2) lblRewardApple.ForeColor = Color.GreenYellow;
                else lblRewardApple.ForeColor = Color.Black;
            }
            else AlertBox.Notify("No te quedan más fichas para apostar");
        }

        private void pctBAR100_Click(object sender, EventArgs e)
        {
            if (GameData.insertedRealCoins >= 1)
            {
                GameData.insertedRealCoins--;
                lblBetCoins.Text = GameData.insertedRealCoins.ToString();
                GameData.insertedCoinsBAR100++;
                lblBetBAR100.Text = (GameData.insertedCoinsBAR100).ToString();
                lblRewardBAR100.Text = Convert.ToString(GameData.VALUE_BAR100 * GameData.insertedCoinsBAR100);
                if (GameData.insertedCoinsBAR100 >= 2) lblRewardBAR100.ForeColor = Color.GreenYellow;
                else lblRewardBAR100.ForeColor = Color.Black;
            }
            else AlertBox.Notify("No te quedan más fichas para apostar");
        }

        private void pctCancel_Click(object sender, EventArgs e)
        {
            GameData.insertedCoinsBAR100 = GameData.insertedCoinsBAR50 = GameData.insertedCoinsStar = GameData.insertedCoinsBanana = GameData.insertedCoinsAnana = GameData.insertedCoinsPera = GameData.insertedCoinsOrange = GameData.insertedCoinsApple = GameData.insertedCoinsCereza = 0;
            this.Dispose();
        }

        private void pctReset_Click(object sender, EventArgs e)
        {
            GameData.insertedCoinsBAR100 = GameData.insertedCoinsBAR50 = GameData.insertedCoinsStar = GameData.insertedCoinsApple = GameData.insertedCoinsCereza = GameData.insertedCoinsPera = GameData.insertedCoinsAnana = GameData.insertedCoinsBanana = GameData.insertedCoinsOrange = 0;
            lblBetCereza.Text = lblBetApple.Text = lblBetOrange.Text = lblBetBanana.Text = lblBetAnana.Text = lblBetStar.Text = lblBetBAR50.Text = lblBetBAR100.Text = lblBetPera.Text = "";
            lblRewardCereza.ForeColor = lblRewardApple.ForeColor = lblRewardPera.ForeColor = lblRewardOrange.ForeColor = lblRewardAnana.ForeColor = lblRewardBanana.ForeColor = lblRewardStar.ForeColor = lblRewardBAR50.ForeColor = lblRewardBAR100.ForeColor = Color.Black;
            if (GameData.typeCoin == 1)
            {
                lblBetCoins.Text = GameData.insertedGoldCoins.ToString();
                GameData.insertedRealCoins = GameData.insertedGoldCoins;
            }
            else if (GameData.typeCoin == 2)
            {
                lblBetCoins.Text = GameData.insertedSilverCoins.ToString();
                GameData.insertedRealCoins = GameData.insertedSilverCoins;
            }
        }

        private void pctReset_MouseEnter(object sender, EventArgs e)
        {
            pctReset.BackColor = Color.LightGreen;
        }

        private void pctReset_MouseLeave(object sender, EventArgs e)
        {
            pctReset.BackColor = Color.White;
        }

        private void pctCancel_MouseEnter(object sender, EventArgs e)
        {
            pctCancel.BackColor = Color.LightCoral;
        }

        private void pctCancel_MouseLeave(object sender, EventArgs e)
        {
            pctCancel.BackColor = Color.White;
            toolTip.Hide(pctCancel);
        }

        private void pctGirarRuleta_Click(object sender, EventArgs e)
        {
            if (GameData.insertedRealCoins == 0)
            {
                GameData.alreadyBetted = true;
                AlertBox.Notify("Ya hiciste tu apuesta\nPresiona el botón ¡Girar ruleta!", true);
                this.Dispose();
            }
            else AlertBox.Notify("Aún faltan fichas por apostar");
        }

        private void pctGirarRuleta_MouseEnter(object sender, EventArgs e)
        {
            pctApostar.BackColor = Color.PaleTurquoise;
        }

        private void pctGirarRuleta_MouseLeave(object sender, EventArgs e)
        {
            pctApostar.BackColor = Color.White;
        }

        private void pctBAR100_MouseEnter(object sender, EventArgs e)
        {
            pctBAR100.BackColor = Color.PaleTurquoise;
            if (GameData.typeCoin == 1) probabilidad = "Difícil";
            else probabilidad = "Casi imposible";
            toolTip.ToolTipTitle = "BAR 100";
            toolTip.SetToolTip(pctBAR100, "Probabilidades: " + probabilidad + "\nRecompensa por 1 ficha: 100\nRecompensa por tu apuesta: " + GameData.VALUE_BAR100 * GameData.insertedCoinsBAR100);
        }

        private void pctBAR100_MouseLeave(object sender, EventArgs e)
        {
            pctBAR100.BackColor = Color.Gold;
            toolTip.Hide(pctBAR100);
        }

        private void pctBAR50_MouseEnter(object sender, EventArgs e)
        {
            pctBAR50.BackColor = Color.PaleTurquoise;
            toolTip.ToolTipTitle = "BAR 50";
            toolTip.SetToolTip(pctBAR50, "Probabilidades: Difícil\nRecompensa por 1 ficha: 50\nRecompensa por tu apuesta: " + GameData.VALUE_BAR50 * GameData.insertedCoinsBAR50);
        }

        private void pctBAR50_MouseLeave(object sender, EventArgs e)
        {
            pctBAR50.BackColor = Color.Goldenrod;
            toolTip.Hide(pctBAR50);
        }

        private void pctStar_MouseEnter(object sender, EventArgs e)
        {
            pctStar.BackColor = Color.PaleTurquoise;
            toolTip.ToolTipTitle = "Estrella";
            toolTip.SetToolTip(pctStar, "Probabilidades: Difícil\nRecompensa por 1 ficha: 30\nRecompensa por tu apuesta: " + GameData.VALUE_STAR * GameData.insertedCoinsStar);
        }

        private void pctStar_MouseLeave(object sender, EventArgs e)
        {
            pctStar.BackColor = Color.White;
            toolTip.Hide(pctStar);
        }

        private void pctBanana_MouseEnter(object sender, EventArgs e)
        {
            pctBanana.BackColor = Color.PaleTurquoise;
            if (GameData.typeCoin == 1) probabilidad = "Muy probable";
            else probabilidad = "Probable";
            toolTip.ToolTipTitle = "Banana";
            toolTip.SetToolTip(pctBanana, "Probabilidades: " + probabilidad + "\nRecompensa por 1 ficha: 20\nRecompensa por tu apuesta: " + GameData.VALUE_BANANA * GameData.insertedCoinsBanana);
        }

        private void pctBanana_MouseLeave(object sender, EventArgs e)
        {
            pctBanana.BackColor = Color.White;
            toolTip.Hide(pctBanana);
        }

        private void pctAnana_MouseEnter(object sender, EventArgs e)
        {
            pctAnana.BackColor = Color.PaleTurquoise;
            if (GameData.typeCoin == 1) probabilidad = "Muy probable";
            else probabilidad = "Probable";
            toolTip.ToolTipTitle = "Anana";
            toolTip.SetToolTip(pctAnana, "Probabilidades: " + probabilidad + "\nRecompensa por 1 ficha: 15\nRecompensa por tu apuesta: " + GameData.VALUE_ANANA * GameData.insertedCoinsAnana);
        }

        private void pctAnana_MouseLeave(object sender, EventArgs e)
        {
            pctAnana.BackColor = Color.White;
            toolTip.Hide(pctAnana);
        }

        private void pctPera_MouseEnter(object sender, EventArgs e)
        {
            pctPera.BackColor = Color.PaleTurquoise;
            if (GameData.typeCoin == 1) probabilidad = "Muy probable";
            else probabilidad = "Probable";
            toolTip.ToolTipTitle = "Pera";
            toolTip.SetToolTip(pctPera, "Probabilidades: " + probabilidad + "\nRecompensa por 1 ficha: 10\nRecompensa por tu apuesta: " + GameData.VALUE_PERA * GameData.insertedCoinsPera);
        }

        private void pctPera_MouseLeave(object sender, EventArgs e)
        {
            pctPera.BackColor = Color.White;
            toolTip.Hide(pctPera);
        }

        private void pctOrange_MouseEnter(object sender, EventArgs e)
        {
            pctOrange.BackColor = Color.PaleTurquoise;
            if (GameData.typeCoin == 1) probabilidad = "Muy probable";
            else probabilidad = "Probable";
            toolTip.ToolTipTitle = "Naranja";
            toolTip.SetToolTip(pctOrange, "Probabilidades: " + probabilidad + "\nRecompensa por 1 ficha: 10\nRecompensa por tu apuesta: " + GameData.VALUE_ORANGE * GameData.insertedCoinsOrange);
        }

        private void pctOrange_MouseLeave(object sender, EventArgs e)
        {
            pctOrange.BackColor = Color.White;
            toolTip.Hide(pctOrange);
        }

        private void pctApple_MouseEnter(object sender, EventArgs e)
        {
            pctApple.BackColor = Color.PaleTurquoise;
            toolTip.ToolTipTitle = "Manzana";
            toolTip.SetToolTip(pctApple, "Probabilidades: Muy probable\nRecompensa por 1 ficha: 5\nRecompensa por tu apuesta: " + GameData.VALUE_APPLE * GameData.insertedCoinsApple);
        }

        private void pctApple_MouseLeave(object sender, EventArgs e)
        {
            pctApple.BackColor = Color.White;
            toolTip.Hide(pctApple);
        }

        private void pctCereza_MouseEnter(object sender, EventArgs e)
        {
            pctCereza.BackColor = Color.PaleTurquoise;
            toolTip.ToolTipTitle = "Cereza";
            toolTip.SetToolTip(pctCereza, "Probabilidades: Muy probable\nRecompensa por 1 ficha: 2\nRecompensa por tu apuesta: " + GameData.VALUE_CEREZA * GameData.insertedCoinsCereza);
        }

        private void pctCereza_MouseLeave(object sender, EventArgs e)
        {
            pctCereza.BackColor = Color.White;
            toolTip.Hide(pctCereza);
        }
    }
}
