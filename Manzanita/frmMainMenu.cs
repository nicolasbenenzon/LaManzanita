using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
//using System.Data.OleDb;

namespace Manzanita
{
    public partial class frmMainMenu : Form
    {
        public frmMainMenu()
        {
            InitializeComponent();
        }

        private void btnNuevaPartida_Click(object sender, EventArgs e)
        {
            bool value = AlertBox.Question("Al crear una nueva partida la partida guardada se borrará\n¿Estás seguro que deseas crear una nueva partida?", "red");
            if (value)
            {
                string game = AlertBox.Input("Ingresa el nombre de tu nueva partida");
                if (game != "" && game != null)
                {
                    if (game.Length > 3)
                    {
                        if (game.Length < 21)
                        {
                            AlertBox.Notify("Creando partida...", true, "blue");
                            //OleDbConnection cn = new OleDbConnection();
                            //cn.ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0; Data Source=LaManzanitaDB.accdb";
                            //cn.Open();
                            frmGame FrmGame = new frmGame();
                            FrmGame.lblNameAccount.Text = game;
                            FrmGame.Show();
                            FrmGame = null;
                            Lib.PlaySound("Billards.wav");
                            //OleDbCommand cmd = new OleDbCommand();
                            //cmd.CommandText = "UPDATE tblAcccount SET NameAccount='" + game + "', Money=10, GoldCoins=0, SilverCoins=0, cantNuevoTiro=0, cantWinCereza=0, cantWinApple=0, cantWinOrange=0, cantWinPera=0, cantWinAnana=0, cantWinBanana=0, cantWinStar=0, cantWinBAR50=0, cantWinBAR100=0, cantLosCereza=0, cantLosApple=0, cantLosOrange=0, cantLosPera=0, cantLosAnana=0, cantLosBanana=0, cantLosStar=0, cantLosBAR50=0, cantLosBAR100=0, cantWinGoldCoinsCereza=0, cantWinGoldCoinsApple=0, cantWinGoldCoinsOrange=0, cantWinGoldCoinsPera=0, cantWinGoldCoinsAnana=0, cantWinGoldCoinsBanana=0, cantWinGoldCoinsStar=0, cantWinGoldCoinsBAR50=0, cantWinGoldCoinsBAR100=0, cantWinSilverCoinsCereza=0, cantWinSilverCoinsApple=0, cantWinSilverCoinsOrange=0, cantWinSilverCoinsPera=0, cantWinSilverCoinsAnana=0, cantWinSilverCoinsBanana=0, cantWinSilverCoinsStar=0, cantWinSilverCoinsBAR50=0, cantWinSilverCoinsBAR100=0";
                            //cmd.ExecuteNonQuery();
                            //cmd = null;
                            this.Dispose();
                            AlertBox.Notify("¡Partida creada con éxito!", true);
                        }
                        else AlertBox.Notify("El nombre debe tener hasta 20 caracteres");
                    }
                    else AlertBox.Notify("El nombre debe tener al menos 4 caracteres");
                }
                else if (game != null) AlertBox.Notify("La partida debe tener un nombre");
            }
        }

        private void btnCargarPartida_Click(object sender, EventArgs e)
        {
            /*OleDbConnection cn = new OleDbConnection();
            cn.ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0; Data Source=LaManzanitaDB.accdb";
            cn.Open();
            OleDbCommand cmd = new OleDbCommand("SELECT * FROM tblAccount", cn);
            OleDbDataAdapter da = new OleDbDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds, "data");
            if (ds.Tables["data"].Rows.Count != 0)
            {
                AlertBox.Notify("Cargando partida...", true, "blue");
                GameData.nameAccount = ds.Tables["data"].Rows[0].ItemArray[0].ToString();
                GameData.money = Convert.ToInt32(ds.Tables["data"].Rows[0].ItemArray[1].ToString());
                GameData.goldCoins = Convert.ToInt32(ds.Tables["data"].Rows[0].ItemArray[2].ToString());
                GameData.silverCoins = Convert.ToInt32(ds.Tables["data"].Rows[0].ItemArray[3].ToString());
                GameData.cantNuevoTiro = Convert.ToInt32(ds.Tables["data"].Rows[0].ItemArray[4].ToString());
                GameData.cantWinCereza = Convert.ToInt32(ds.Tables["data"].Rows[0].ItemArray[5].ToString());
                GameData.cantWinApple = Convert.ToInt32(ds.Tables["data"].Rows[0].ItemArray[6].ToString());
                GameData.cantWinOrange = Convert.ToInt32(ds.Tables["data"].Rows[0].ItemArray[7].ToString());
                GameData.cantWinPera = Convert.ToInt32(ds.Tables["data"].Rows[0].ItemArray[8].ToString());
                GameData.cantWinAnana = Convert.ToInt32(ds.Tables["data"].Rows[0].ItemArray[9].ToString());
                GameData.cantWinBanana = Convert.ToInt32(ds.Tables["data"].Rows[0].ItemArray[10].ToString());
                GameData.cantWinStar = Convert.ToInt32(ds.Tables["data"].Rows[0].ItemArray[11].ToString());
                GameData.cantWinBAR50 = Convert.ToInt32(ds.Tables["data"].Rows[0].ItemArray[12].ToString());
                GameData.cantWinBAR100 = Convert.ToInt32(ds.Tables["data"].Rows[0].ItemArray[13].ToString());
                GameData.cantLosCereza = Convert.ToInt32(ds.Tables["data"].Rows[0].ItemArray[14].ToString());
                GameData.cantLosApple = Convert.ToInt32(ds.Tables["data"].Rows[0].ItemArray[15].ToString());
                GameData.cantLosOrange = Convert.ToInt32(ds.Tables["data"].Rows[0].ItemArray[16].ToString());
                GameData.cantLosPera = Convert.ToInt32(ds.Tables["data"].Rows[0].ItemArray[17].ToString());
                GameData.cantLosAnana = Convert.ToInt32(ds.Tables["data"].Rows[0].ItemArray[18].ToString());
                GameData.cantLosBanana = Convert.ToInt32(ds.Tables["data"].Rows[0].ItemArray[19].ToString());
                GameData.cantLosStar = Convert.ToInt32(ds.Tables["data"].Rows[0].ItemArray[20].ToString());
                GameData.cantLosBAR50 = Convert.ToInt32(ds.Tables["data"].Rows[0].ItemArray[21].ToString());
                GameData.cantLosBAR100 = Convert.ToInt32(ds.Tables["data"].Rows[0].ItemArray[22].ToString());
                GameData.cantWinGoldCoinsCereza = Convert.ToInt32(ds.Tables["data"].Rows[0].ItemArray[23].ToString());
                GameData.cantWinGoldCoinsApple = Convert.ToInt32(ds.Tables["data"].Rows[0].ItemArray[24].ToString());
                GameData.cantWinGoldCoinsOrange = Convert.ToInt32(ds.Tables["data"].Rows[0].ItemArray[25].ToString());
                GameData.cantWinGoldCoinsPera = Convert.ToInt32(ds.Tables["data"].Rows[0].ItemArray[26].ToString());
                GameData.cantWinGoldCoinsAnana = Convert.ToInt32(ds.Tables["data"].Rows[0].ItemArray[27].ToString());
                GameData.cantWinGoldCoinsBanana = Convert.ToInt32(ds.Tables["data"].Rows[0].ItemArray[28].ToString());
                GameData.cantWinGoldCoinsStar = Convert.ToInt32(ds.Tables["data"].Rows[0].ItemArray[29].ToString());
                GameData.cantWinGoldCoinsBAR50 = Convert.ToInt32(ds.Tables["data"].Rows[0].ItemArray[30].ToString());
                GameData.cantWinGoldCoinsBAR100 = Convert.ToInt32(ds.Tables["data"].Rows[0].ItemArray[31].ToString());
                GameData.cantWinSilverCoinsCereza = Convert.ToInt32(ds.Tables["data"].Rows[0].ItemArray[32].ToString());
                GameData.cantWinSilverCoinsApple = Convert.ToInt32(ds.Tables["data"].Rows[0].ItemArray[33].ToString());
                GameData.cantWinSilverCoinsOrange = Convert.ToInt32(ds.Tables["data"].Rows[0].ItemArray[34].ToString());
                GameData.cantWinSilverCoinsPera = Convert.ToInt32(ds.Tables["data"].Rows[0].ItemArray[35].ToString());
                GameData.cantWinSilverCoinsAnana = Convert.ToInt32(ds.Tables["data"].Rows[0].ItemArray[36].ToString());
                GameData.cantWinSilverCoinsBanana = Convert.ToInt32(ds.Tables["data"].Rows[0].ItemArray[37].ToString());
                GameData.cantWinSilverCoinsStar = Convert.ToInt32(ds.Tables["data"].Rows[0].ItemArray[38].ToString());
                GameData.cantWinSilverCoinsBAR50 = Convert.ToInt32(ds.Tables["data"].Rows[0].ItemArray[39].ToString());
                GameData.cantWinSilverCoinsBAR100 = Convert.ToInt32(ds.Tables["data"].Rows[0].ItemArray[40].ToString());
                AlertBox.Notify("¡Partida cargada con éxito!", true);
            }
            else AlertBox.Notify("No tienes una partida guardada\n¡Empieza una nueva!");
            ds = null;
            da = null;
            cmd = null;
            //cn = null;*/
        }

        private void btnConfig_Click(object sender, EventArgs e)
        {
            AlertBox.Notify("No hay nada que configurar");
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            bool value = AlertBox.Question("¿Estás seguro que deseas salir del juego?");
            if (value) Application.Exit();
        }

        private void btnNuevaPartida_MouseEnter(object sender, EventArgs e)
        {
            btnNuevaPartida.BackColor = Color.Green;
        }

        private void btnNuevaPartida_MouseLeave(object sender, EventArgs e)
        {
            btnNuevaPartida.BackColor = Color.HotPink;
        }

        private void btnCargarPartida_MouseEnter(object sender, EventArgs e)
        {
            btnCargarPartida.BackColor = Color.Blue;
        }

        private void btnCargarPartida_MouseLeave(object sender, EventArgs e)
        {
            btnCargarPartida.BackColor = Color.HotPink;
        }

        private void btnConfig_MouseEnter(object sender, EventArgs e)
        {
            btnConfig.BackColor = Color.Orange;
        }

        private void btnConfig_MouseLeave(object sender, EventArgs e)
        {
            btnConfig.BackColor = Color.HotPink;
        }

        private void btnExit_MouseEnter(object sender, EventArgs e)
        {
            btnExit.BackColor = Color.Red;
        }

        private void btnExit_MouseLeave(object sender, EventArgs e)
        {
            btnExit.BackColor = Color.HotPink;
        }

        private void frmMainMenu_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void frmMainMenu_Load(object sender, EventArgs e)
        {
            this.Cursor = AdvancedCursors.Create(Path.Combine(Application.StartupPath, Lib.path + "cursor.ani"));
        }
    }
}
