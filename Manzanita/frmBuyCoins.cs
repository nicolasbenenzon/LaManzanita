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
    public partial class frmBuyCoins : Form
    {
        public frmBuyCoins()
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

        private void pctBuyCoins_Click(object sender, EventArgs e)
        {
            if (FormMode.Mode == "buy")
            {
                if (Convert.ToInt32(updGoldCoins.Value) != 0 || Convert.ToInt32(updSilverCoins.Value) != 0)
                {
                    string totalMoney = lblTotalMoney.Text.Remove(0, 1);
                    if (GameData.money >= (Convert.ToInt32(totalMoney)))
                    {
                        GameData.money -= Convert.ToInt32(totalMoney);
                        GameData.goldCoins += Convert.ToInt32(updGoldCoins.Value);
                        GameData.silverCoins += Convert.ToInt32(updSilverCoins.Value);
                        lblMoney.Text = "$" + Convert.ToString(GameData.money);
                        lblGoldCoins.Text = Convert.ToString(GameData.goldCoins);
                        lblSilverCoins.Text = Convert.ToString(GameData.silverCoins);
                        this.Dispose();
                    }
                    else AlertBox.Notify("No tienes suficiente dinero");
                }
                else this.Dispose();
            }
            else
            {
                if (Convert.ToInt32(updGoldCoins.Value) != 0 || Convert.ToInt32(updSilverCoins.Value) != 0)
                {
                    string totalMoney = lblTotalMoney.Text.Remove(0, 2);
                    if (Convert.ToInt32(updSilverCoins.Value) <= (GameData.silverCoins))
                    {
                        if (Convert.ToInt32(updGoldCoins.Value) <= (GameData.goldCoins))
                        {
                            GameData.money += Convert.ToInt32(totalMoney);
                            GameData.goldCoins -= Convert.ToInt32(updGoldCoins.Value);
                            GameData.silverCoins -= Convert.ToInt32(updSilverCoins.Value);
                            lblMoney.Text = "$" + Convert.ToString(GameData.money);
                            lblGoldCoins.Text = Convert.ToString(GameData.goldCoins);
                            lblSilverCoins.Text = Convert.ToString(GameData.silverCoins);
                            this.Dispose();
                        }
                        else AlertBox.Notify("No tienes esa cantidad de fichas de oro");
                    }
                    else AlertBox.Notify("No tienes esa cantidad de fichas de plata");
                }
                else this.Dispose();
            }
        }

        private void pctBuyCoins_MouseEnter(object sender, EventArgs e)
        {
            pctBuyCoins.BackColor = Color.Gold;
        }

        private void pctBuyCoins_MouseLeave(object sender, EventArgs e)
        {
            pctBuyCoins.BackColor = Color.White;
        }

        private void updGoldCoins_ValueChanged(object sender, EventArgs e)
        {
            if (FormMode.Mode == "buy")
            {
                if (GameData.money >= ((Convert.ToInt32(updGoldCoins.Value) * GameData.COINS_GOLD) + (Convert.ToInt32(updSilverCoins.Value) * GameData.COINS_SILVER)))
                {
                    updGoldCoins.ForeColor = Color.Black;
                    lblMoneyGold.Text = "$" + (Convert.ToInt32(updGoldCoins.Value) * GameData.COINS_GOLD).ToString();
                    lblTotalMoney.Text = "$" + ((Convert.ToInt32(updGoldCoins.Value) * GameData.COINS_GOLD) + (Convert.ToInt32(updSilverCoins.Value) * GameData.COINS_SILVER)).ToString();
                    lblMoney.Text = "$" + (GameData.money - ((Convert.ToInt32(updGoldCoins.Value) * GameData.COINS_GOLD) + (Convert.ToInt32(updSilverCoins.Value) * GameData.COINS_SILVER))).ToString();
                }
                else
                {
                    updGoldCoins.Value--;
                    updGoldCoins.ForeColor = Color.Red;
                    AlertBox.Notify("No tienes dinero para comprar tantas fichas de oro");
                }
            }
            else
            {
                if (GameData.goldCoins >= Convert.ToInt32(updGoldCoins.Value))
                {
                    updGoldCoins.ForeColor = Color.Black;
                    lblMoneyGold.Text = "+$" + (Convert.ToInt32(updGoldCoins.Value) * GameData.COINS_SILVER).ToString();
                    lblTotalMoney.Text = "+$" + ((Convert.ToInt32(updGoldCoins.Value) * GameData.COINS_SILVER) + (Convert.ToInt32(updSilverCoins.Value))).ToString();
                    lblMoney.Text = "$" + (GameData.money + ((Convert.ToInt32(updGoldCoins.Value) * GameData.COINS_SILVER) + (Convert.ToInt32(updSilverCoins.Value)))).ToString();
                }
                else
                {
                    updGoldCoins.Value--;
                    updGoldCoins.ForeColor = Color.Red;
                    AlertBox.Notify("No tienes tantas fichas de oro para vender");
                }
            }
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            if (FormMode.Mode == "buy")
            {
                if (GameData.money >= ((Convert.ToInt32(updGoldCoins.Value) * GameData.COINS_GOLD) + (Convert.ToInt32(updSilverCoins.Value) * GameData.COINS_SILVER)))
                {
                    updSilverCoins.ForeColor = Color.Black;
                    lblMoneySilver.Text = "$" + (Convert.ToInt32(updSilverCoins.Value) * GameData.COINS_SILVER).ToString();
                    lblTotalMoney.Text = "$" + ((Convert.ToInt32(updGoldCoins.Value) * GameData.COINS_GOLD) + (Convert.ToInt32(updSilverCoins.Value) * GameData.COINS_SILVER)).ToString();
                    lblMoney.Text = "$" + (GameData.money - ((Convert.ToInt32(updGoldCoins.Value) * GameData.COINS_GOLD) + (Convert.ToInt32(updSilverCoins.Value) * GameData.COINS_SILVER))).ToString();
                }
                else
                {
                    updSilverCoins.Value--;
                    updSilverCoins.ForeColor = Color.Red;
                    AlertBox.Notify("No tienes dinero para comprar tantas fichas de plata");
                }
            }
            else
            {
                if (GameData.silverCoins >= Convert.ToInt32(updSilverCoins.Value))
                {
                    updSilverCoins.ForeColor = Color.Black;
                    lblMoneySilver.Text = "+$" + (Convert.ToInt32(updSilverCoins.Value)).ToString();
                    lblTotalMoney.Text = "+$" + ((Convert.ToInt32(updGoldCoins.Value) * GameData.COINS_SILVER) + (Convert.ToInt32(updSilverCoins.Value))).ToString();
                    lblMoney.Text = "$" + (GameData.money + ((Convert.ToInt32(updGoldCoins.Value) * GameData.COINS_SILVER) + (Convert.ToInt32(updSilverCoins.Value)))).ToString();
                }
                else
                {
                    updSilverCoins.Value--;
                    updSilverCoins.ForeColor = Color.Red;
                    AlertBox.Notify("No tienes tantas fichas de plata para vender");
                }
            }
        }

        private void frmBuyCoins_Load(object sender, EventArgs e)
        {
            lblMoney.Text = "$" + Convert.ToString(GameData.money);
            lblGoldCoins.Text = Convert.ToString(GameData.goldCoins);
            lblSilverCoins.Text = Convert.ToString(GameData.silverCoins);
            this.Cursor = AdvancedCursors.Create(Path.Combine(Application.StartupPath, Lib.path + "cursor.ani"));
            if (FormMode.Mode == "buy")
            {
                pctBuyCoins.BackgroundImage = Image.FromFile(Lib.path + "ComprarFichas.png");
                pctManzanita.BackgroundImage = Image.FromFile(Lib.path + "ComprarFichas.png");
            }
            else
            {
                pctBuyCoins.BackgroundImage = Image.FromFile(Lib.path + "VenderFichas.png");
                pctManzanita.BackgroundImage = Image.FromFile(Lib.path + "VenderFichas.png");
            }
        }
    }
}
