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
    public partial class frmGame : Form
    {
        bool goldCoinDragged = false;
        bool silverCoinDragged = false;
        const string lightOn = Lib.path + "luzverdePrendida.png";
        const string lightOff = Lib.path + "luzverde.png";
        int numOfLaps = 0;
        string typeCoins;
        bool nuevoTiro = false;
        bool Winning = false;
        int countWinMoneyTimes = 0;
        int countWinTimes = 0;

        public frmGame()
        {
            InitializeComponent();
        }

        private void pctClose_Click(object sender, EventArgs e)
        {
            bool value = AlertBox.Question("¿Estás seguro que deseas salir del juego?\n¡NO TE OLVIDES DE GUARDAR ANTES!", "red");
            if (value) 
            {
                Application.Exit();
                //OleDbConnection cn = new OleDbConnection();
                //cn.Close();
                //cn = null;
            }
        }

        private void pctLoadMoney_Click(object sender, EventArgs e)
        {
            string passCode = AlertBox.Input("Ingresa la contraseña para cargar el dinero", "black", true);
            if (passCode == "contra123")
            {
                string cant = AlertBox.Input("Ingresa la cantidad de dinero que quieres cargar");
                GameData.money += Convert.ToInt32(cant);
                lblMoney.Text = "$" + GameData.money.ToString();
            }
            else if(passCode != null) AlertBox.Notify("Contraseña incorrecta");
        }

        public string FixTime(int minute, int second, int milisecond)
        {
            if (milisecond < 10 && second < 10 && minute < 10) return "0" + minute + ":0" + second + ":0" + milisecond;
            if (milisecond < 10 && second < 10) return minute + ":0" + second + ":0" + milisecond;
            if (milisecond < 10 && minute < 10) return "0" + minute + ":" + second + ":0" + milisecond;
            if (second < 10 && minute < 10) return "0" + minute + ":0" + second + ":" + milisecond;
            if (milisecond < 10) return minute + ":" + second + ":0" + milisecond;
            if (second < 10) return minute + ":0" + second + ":" + milisecond;
            if (minute < 10) return "0" + minute + ":" + second + ":" + milisecond;
            else return minute + ":" + second + ":" + milisecond;
        }

        private void pctEarnMoney_Click(object sender, EventArgs e)
        {
            if (countWinMoneyTimes < 3)
            {
                if (GameData.money >= 2)
                {
                    bool value = AlertBox.Question("Recibir un ejercicio para ganar dinero te costará $2\n¿Estás seguro que quieres arriesgarte? (Usos: " + countWinMoneyTimes + "/3)", "red");
                    if (value)
                    {
                        GameData.money -= 2;
                        lblMoney.Text = GameData.money.ToString();
                        Random rnd = new Random();
                        int rndExercise = rnd.Next(1, 40);
                        int num1 = 0, num2 = 0, num3 = 0, num4 = 0, num5 = 0, num6 = 0, num7 = 0, num8 = 0, result = 0;
                        string Res = "";
                        bool resValue = false;
                        countWinMoneyTimes++;
                        if (rndExercise == 1)
                        {
                            num1 = (rnd.Next(1, 50));
                            num2 = (rnd.Next(1, 50));
                            num3 = (rnd.Next(1, 4));
                            num4 = (rnd.Next(1, 50));
                            num5 = (rnd.Next(1, 50));
                            num6 = (rnd.Next(1, 4));
                            Res = AlertBox.Input("¿Cuánto es " + num1 + " + " + num2 + " * " + num3 + " + " + num4 + " - " + num5 + " * " + num6 + "?\nRecompensa: $8", "green");
                            result = num1 + num2 * num3 + num4 - num5 * num6;
                            if (Res == Convert.ToString(result))
                            {
                                GameData.money += 8;
                                lblMoney.Text = "$" + GameData.money.ToString();
                                AlertBox.Notify("¡Correcto!\nHas ganado $8", true);
                            }
                            else if(Res != null) AlertBox.Notify("¡Incorrecto!\nRespuesta: " + result);
                        }
                        else if (rndExercise == 2)
                        {
                            num1 = (rnd.Next(1, 50));
                            num2 = (rnd.Next(1, 50));
                            num3 = (rnd.Next(1, 50));
                            num4 = (rnd.Next(1, 4));
                            num5 = (rnd.Next(1, 50));
                            num6 = (rnd.Next(1, 50));
                            num7 = (rnd.Next(1, 50));
                            num8 = (rnd.Next(1, 50));
                            Res = AlertBox.Input("¿Cuánto es (" + num1 + " - " + num2 + " + " + num3 + " * " + num4 + " + " + num5 + " - " + num6 + " + " + num7 + " - " + num8 + ") * 2" + "?\nRecompensa: $10", "green");
                            result = (num1 - num2 + num3 * num4 + num5 - num6 + num7 - num8) * 2;
                            if (Res == Convert.ToString(result))
                            {
                                GameData.money += 10;
                                lblMoney.Text = "$" + GameData.money.ToString();
                                AlertBox.Notify("¡Correcto!\nHas ganado $10", true);
                            }
                            else if(Res != null) AlertBox.Notify("¡Incorrecto!\nRespuesta: " + result);
                        }
                        else if (rndExercise == 3)
                        {
                            Res = AlertBox.Input("¿Cómo se llama Messi?\nRecompensa: $4", "green");
                            if (Res == "Lionel" || Res == "lionel")
                            {
                                GameData.money += 4;
                                lblMoney.Text = "$" + GameData.money.ToString();
                                AlertBox.Notify("¡Correcto!\nHas ganado $4", true);
                            }
                            else if(Res != null) AlertBox.Notify("¡Incorrecto!");
                        }
                        else if (rndExercise == 4)
                        {
                            Res = AlertBox.Input("¿Cómo se llama Tévez?\nRecompensa: $4", "green");
                            if (Res == "Carlos" || Res == "carlos")
                            {
                                GameData.money += 4;
                                lblMoney.Text = "$" + GameData.money.ToString();
                                AlertBox.Notify("¡Correcto!\nHas ganado $4", true);
                            }
                            else if(Res != null) AlertBox.Notify("¡Incorrecto!");
                        }
                        else if (rndExercise == 5)
                        {
                            Res = AlertBox.Input("¿Cómo es el apodo de Agüero?\nRecompensa: $5", "green");
                            if (Res == "El Kun" || Res == "El kun" || Res == "Kun" || Res == "kun" || Res == "el kun" || Res == "el Kun")
                            {
                                GameData.money += 5;
                                lblMoney.Text = "$" + GameData.money.ToString();
                                AlertBox.Notify("¡Correcto!\nHas ganado $5", true);
                            }
                            else if(Res != null) AlertBox.Notify("¡Incorrecto!");
                        }
                        else if (rndExercise == 6)
                        {
                            Res = AlertBox.Input("¿Cómo se llama Tinelli?\nRecompensa: $4", "green");
                            if (Res == "marcelo" || Res == "Marcelo")
                            {
                                GameData.money += 4;
                                lblMoney.Text = "$" + GameData.money.ToString();
                                AlertBox.Notify("¡Correcto!\nHas ganado $4", true);
                            }
                            else if(Res != null) AlertBox.Notify("¡Incorrecto!");
                        }
                        else if (rndExercise == 7)
                        {
                            Res = AlertBox.Input("¿Qué programa conduce Guido Kazka?\nRecompensa: $6", "green");
                            if (Res == "a todo o nada" || Res == "A todo o nada" || Res == "A Todo o nada" || Res == "A Todo o Nada" || Res == "A Todo O Nada")
                            {
                                GameData.money += 6;
                                lblMoney.Text = "$" + GameData.money.ToString();
                                AlertBox.Notify("¡Correcto!\nHas ganado $6", true);
                            }
                            else if(Res != null) AlertBox.Notify("¡Incorrecto!");
                        }
                        else if (rndExercise == 8)
                        {
                            Res = AlertBox.Input("¿Qué programa conduce Clarivel Medina?\nRecompensa: $5", "green");
                            if (Res == "cuestión de peso" || Res == "Cuestión de peso" || Res == "Cuestión de Peso" || Res == "Cuestión De Peso" || Res == "cuestion de peso" || Res == "Cuestion de peso" || Res == "Cuestion de Peso" || Res == "Cuestion De Peso")
                            {
                                GameData.money += 5;
                                lblMoney.Text = "$" + GameData.money.ToString();
                                AlertBox.Notify("¡Correcto!\nHas ganado $5", true);
                            }
                            else if(Res != null) AlertBox.Notify("¡Incorrecto!");
                        }
                        else if (rndExercise == 9)
                        {
                            Res = AlertBox.Input("¿Cuál es la contra de Chevrolet?\nRecompensa: $5", "green");
                            if (Res == "ford" || Res == "Ford")
                            {
                                GameData.money += 5;
                                lblMoney.Text = "$" + GameData.money.ToString();
                                AlertBox.Notify("¡Correcto!\nHas ganado $5", true);
                            }
                            else if(Res != null) AlertBox.Notify("¡Incorrecto!");
                        }
                        else if (rndExercise == 10)
                        {
                            Res = AlertBox.Input("¿Cuál es el combo más barato de McDonald's?\nRecompensa: $5", "green");
                            if (Res == "Big Mac" || Res == "big mac" || Res == "big Mac" || Res == "Big mac" || Res == "Bigmac" || Res == "BigMac" || Res == "bigmac")
                            {
                                GameData.money += 5;
                                lblMoney.Text = "$" + GameData.money.ToString();
                                AlertBox.Notify("¡Correcto!\nHas ganado $5", true);
                            }
                            else if(Res != null) AlertBox.Notify("¡Incorrecto!");
                        }
                        else if (rndExercise == 11)
                        {
                            num1 = (rnd.Next(1, 50));
                            num2 = (rnd.Next(1, 50));
                            num3 = (rnd.Next(1, 50));
                            num4 = (rnd.Next(1, 4));
                            num5 = (rnd.Next(1, 50));
                            num6 = (rnd.Next(1, 50));
                            num7 = (rnd.Next(1, 50));
                            num8 = (rnd.Next(1, 50));
                            Res = AlertBox.Input("¿Cuánto es (" + num1 + " - " + num2 + " + " + num3 + " * " + num4 + " + " + num5 + " - " + num6 + " + " + num7 + " - " + num8 + ") * 2" + "?\nRecompensa: $10", "green");
                            result = (num1 - num2 + num3 * num4 + num5 - num6 + num7 - num8) * 2;
                            if (Res == Convert.ToString(result))
                            {
                                GameData.money += 10;
                                lblMoney.Text = "$" + GameData.money.ToString();
                                AlertBox.Notify("¡Correcto!\nHas ganado $10", true);
                            }
                            else if(Res != null) AlertBox.Notify("¡Incorrecto!\nRespuesta: " + result);
                        }
                        else if (rndExercise == 12)
                        {
                            num1 = (rnd.Next(1, 50));
                            num2 = (rnd.Next(1, 50));
                            num3 = (rnd.Next(1, 4));
                            num4 = (rnd.Next(1, 50));
                            num5 = (rnd.Next(1, 50));
                            num6 = (rnd.Next(1, 4));
                            Res = AlertBox.Input("¿Cuánto es " + num1 + " + " + num2 + " * " + num3 + " + " + num4 + " - " + num5 + " * " + num6 + "?\nRecompensa: $8", "green");
                            result = num1 + num2 * num3 + num4 - num5 * num6;
                            if (Res == Convert.ToString(result))
                            {
                                GameData.money += 8;
                                lblMoney.Text = "$" + GameData.money.ToString();
                                AlertBox.Notify("¡Correcto!\nHas ganado $8", true);
                            }
                            else if(Res != null) AlertBox.Notify("¡Incorrecto!\nRespuesta: " + result);
                        }
                        else if (rndExercise == 13)
                        {
                            num1 = (rnd.Next(1, 50));
                            num2 = (rnd.Next(1, 50));
                            num3 = (rnd.Next(1, 4));
                            num4 = (rnd.Next(1, 50));
                            num5 = (rnd.Next(1, 50));
                            num6 = (rnd.Next(1, 4));
                            Res = AlertBox.Input("¿Cuánto es " + num1 + " + " + num2 + " * " + num3 + " + " + num4 + " - " + num5 + " * " + num6 + "?\nRecompensa: $8", "green");
                            result = num1 + num2 * num3 + num4 - num5 * num6;
                            if (Res == Convert.ToString(result))
                            {
                                GameData.money += 8;
                                lblMoney.Text = "$" + GameData.money.ToString();
                                AlertBox.Notify("¡Correcto!\nHas ganado $8", true);
                            }
                            else if(Res != null) AlertBox.Notify("¡Incorrecto!\nRespuesta: " + result);
                        }
                        else if (rndExercise == 14)
                        {
                            num1 = (rnd.Next(1, 50));
                            num2 = (rnd.Next(1, 50));
                            num3 = (rnd.Next(1, 4));
                            num4 = (rnd.Next(1, 50));
                            num5 = (rnd.Next(1, 50));
                            num6 = (rnd.Next(1, 4));
                            Res = AlertBox.Input("¿Cuánto es " + num1 + " + " + num2 + " * " + num3 + " + " + num4 + " - " + num5 + " * " + num6 + "?\nRecompensa: $8", "green");
                            result = num1 + num2 * num3 + num4 - num5 * num6;
                            if (Res == Convert.ToString(result))
                            {
                                GameData.money += 8;
                                lblMoney.Text = "$" + GameData.money.ToString();
                                AlertBox.Notify("¡Correcto!\nHas ganado $8", true);
                            }
                            else if(Res != null) AlertBox.Notify("¡Incorrecto!\nRespuesta: " + result);
                        }
                        else if (rndExercise == 15)
                        {
                            Res = AlertBox.Input("¿Cómo se llama el novio de Barbie?\nRecompensa: $6", "green");
                            if (Res == "ken" || Res == "Ken")
                            {
                                GameData.money += 6;
                                lblMoney.Text = "$" + GameData.money.ToString();
                                AlertBox.Notify("¡Correcto!\nHas ganado $6", true);
                            }
                            else if(Res != null) AlertBox.Notify("¡Incorrecto!");
                        }
                        else if (rndExercise == 16)
                        {
                            Res = AlertBox.Input("¿Cómo se llama el perro de tintin?\nRecompensa: $6", "green");
                            if (Res == "milu" || Res == "Milu" || Res == "Milú" || Res == "milú")
                            {
                                GameData.money += 6;
                                lblMoney.Text = "$" + GameData.money.ToString();
                                AlertBox.Notify("¡Correcto!\nHas ganado $6", true);
                            }
                            else if(Res != null) AlertBox.Notify("¡Incorrecto!");
                        }
                        else if (rndExercise == 17)
                        {
                            Res = AlertBox.Input("¿En qué año se fundó Aéropostale?\nRecompensa: $7", "green");
                            if (Res == "1987")
                            {
                                GameData.money += 7;
                                lblMoney.Text = "$" + GameData.money.ToString();
                                AlertBox.Notify("¡Correcto!\nHas ganado $7", true);
                            }
                            else if(Res != null) AlertBox.Notify("¡Incorrecto!");
                        }
                        else if (rndExercise == 18)
                        {
                            Res = AlertBox.Input("¿En qué año se fundó Hollister?\nRecompensa: $7", "green");
                            if (Res == "1922")
                            {
                                GameData.money += 7;
                                lblMoney.Text = "$" + GameData.money.ToString();
                                AlertBox.Notify("¡Correcto!\nHas ganado $7", true);
                            }
                            else if(Res != null) AlertBox.Notify("¡Incorrecto!");
                        }
                        else if (rndExercise == 19)
                        {
                            Res = AlertBox.Input("¿En qué año se fundó Abercrombie & Fitch?\nRecompensa: $7", "green");
                            if (Res == "1892")
                            {
                                GameData.money += 7;
                                lblMoney.Text = "$" + GameData.money.ToString();
                                AlertBox.Notify("¡Correcto!\nHas ganado $7", true);
                            }
                            else if(Res != null) AlertBox.Notify("¡Incorrecto!");
                        }
                        else if (rndExercise == 20)
                        {
                            Res = AlertBox.Input("¿Cuál es la longitud máxima en metros de un cable UTP?\nRecompensa: $9", "green");
                            if (Res == "100")
                            {
                                GameData.money += 9;
                                lblMoney.Text = "$" + GameData.money.ToString();
                                AlertBox.Notify("¡Correcto!\nHas ganado $9", true);
                            }
                            else if(Res != null) AlertBox.Notify("¡Incorrecto!");
                        }
                        else if (rndExercise == 21)
                        {
                            Res = AlertBox.Input("¿Cuál es la longitud máxima en metros de un cable UTP?\nRecompensa: $9", "green");
                            if (Res == "100")
                            {
                                GameData.money += 9;
                                lblMoney.Text = "$" + GameData.money.ToString();
                                AlertBox.Notify("¡Correcto!\nHas ganado $9", true);
                            }
                            else if(Res != null) AlertBox.Notify("¡Incorrecto!");
                        }
                        else if (rndExercise == 22)
                        {
                            resValue = AlertBox.Question("¿A nico le gusta el helado de banana split?\nRecompensa: $4");
                            if (resValue) AlertBox.Notify("¡Incorrecto!");
                            else
                            {
                                GameData.money += 4;
                                lblMoney.Text = "$" + GameData.money.ToString();
                                AlertBox.Notify("¡Correcto!\nHas ganado $4", true);
                            }
                        }
                        else if (rndExercise == 23)
                        {
                            resValue = AlertBox.Question("¿A nico le gusta el helado de chocolate suizo?\nRecompensa: $4");
                            if (resValue)
                            {
                                GameData.money += 4;
                                lblMoney.Text = "$" + GameData.money.ToString();
                                AlertBox.Notify("¡Correcto!\nHas ganado $4", true);
                            }
                            else AlertBox.Notify("¡Incorrecto!");
                        }
                        else if (rndExercise == 24)
                        {
                            Res = AlertBox.Input("¿Cómo se dice 'contaminación' en inglés?\nRecompensa: $6", "green");
                            if (Res == "pollution" || Res == "Pollution")
                            {
                                GameData.money += 6;
                                lblMoney.Text = "$" + GameData.money.ToString();
                                AlertBox.Notify("¡Correcto!\nHas ganado $6", true);
                            }
                            else if(Res != null) AlertBox.Notify("¡Incorrecto!");
                        }
                        else if (rndExercise == 25)
                        {
                            Res = AlertBox.Input("¿Cómo se dice 'dispositivo' en inglés?\nRecompensa: $8", "green");
                            if (Res == "device" || Res == "Device")
                            {
                                GameData.money += 8;
                                lblMoney.Text = "$" + GameData.money.ToString();
                                AlertBox.Notify("¡Correcto!\nHas ganado $8", true);
                            }
                            else if(Res != null) AlertBox.Notify("¡Incorrecto!");
                        }
                        else if (rndExercise == 26)
                        {
                            Res = AlertBox.Input("¿Cómo se dice 'teclado' en inglés?\nRecompensa: $6", "green");
                            if (Res == "keyboard" || Res == "Keyboard")
                            {
                                GameData.money += 6;
                                lblMoney.Text = "$" + GameData.money.ToString();
                                AlertBox.Notify("¡Correcto!\nHas ganado $6", true);
                            }
                            else if(Res != null) AlertBox.Notify("¡Incorrecto!");
                        }
                        else if (rndExercise == 27)
                        {
                            num1 = (rnd.Next(1, 50));
                            num2 = (rnd.Next(1, 50));
                            num3 = (rnd.Next(1, 4));
                            num4 = (rnd.Next(1, 50));
                            Res = AlertBox.Input("¿Cuánto es " + num1 + " + " + num2 + " * " + num3 + " - " + num4 + "?\nRecompensa: $6", "green");
                            result = num1 + num2 * num3 - num4;
                            if (Res == Convert.ToString(result))
                            {
                                GameData.money += 6;
                                lblMoney.Text = "$" + GameData.money.ToString();
                                AlertBox.Notify("¡Correcto!\nHas ganado $6", true);
                            }
                            else if(Res != null) AlertBox.Notify("¡Incorrecto!\nRespuesta: " + result);
                        }
                        else if (rndExercise == 28)
                        {
                            num1 = (rnd.Next(1, 50));
                            num2 = (rnd.Next(1, 50));
                            num3 = (rnd.Next(1, 4));
                            num4 = (rnd.Next(1, 50));
                            Res = AlertBox.Input("¿Cuánto es " + num1 + " + " + num2 + " * " + num3 + " - " + num4 + "?\nRecompensa: $6", "green");
                            result = num1 + num2 * num3 - num4;
                            if (Res == Convert.ToString(result))
                            {
                                GameData.money += 6;
                                lblMoney.Text = "$" + GameData.money.ToString();
                                AlertBox.Notify("¡Correcto!\nHas ganado $6", true);
                            }
                            else if(Res != null) AlertBox.Notify("¡Incorrecto!\nRespuesta: " + result);
                        }
                        else if (rndExercise == 29)
                        {
                            resValue = AlertBox.Question("¿A nico le gusta el helado de sambayón?\nRecompensa: $4");
                            if (resValue) AlertBox.Notify("¡Incorrecto!");
                            else
                            {
                                
                                GameData.money += 4;
                                lblMoney.Text = "$" + GameData.money.ToString();
                                AlertBox.Notify("¡Correcto!\nHas ganado $4", true);
                            }
                        }
                        else if (rndExercise == 30)
                        {
                            Res = AlertBox.Input("¿En qué lenguaje de programación está desarrollado 'La manzanita'?\nRecompensa: $12", "green");
                            if (Res == "c#" || Res == "C#")
                            {
                                GameData.money += 12;
                                lblMoney.Text = "$" + GameData.money.ToString();
                                AlertBox.Notify("¡Correcto!\nHas ganado $12", true);
                            }
                            else if(Res != null) AlertBox.Notify("¡Incorrecto!");
                        }
                        else if (rndExercise == 31)
                        {
                            Res = AlertBox.Input("¿Cómo se llama Ponzio?\nRecompensa: $6", "green");
                            if (Res == "leonardo" || Res == "Leonardo")
                            {
                                GameData.money += 6;
                                lblMoney.Text = "$" + GameData.money.ToString();
                                AlertBox.Notify("¡Correcto!\nHas ganado $6", true);
                            }
                            else if(Res != null) AlertBox.Notify("¡Incorrecto!");
                        }
                        else if (rndExercise == 32)
                        {
                            Res = AlertBox.Input("¿Cómo es el apellido del jugador de River apodado 'El Enzo'?\nRecompensa: $5", "green");
                            if (Res == "francescoli" || Res == "Francescoli")
                            {
                                GameData.money += 5;
                                lblMoney.Text = "$" + GameData.money.ToString();
                                AlertBox.Notify("¡Correcto!\nHas ganado $5", true);
                            }
                            else if(Res != null) AlertBox.Notify("¡Incorrecto!");
                        }
                        else if (rndExercise == 33)
                        {
                            resValue = AlertBox.Question("¿La Bruna fue el máximo goleador de River?\nRecompensa: $5");
                            if (resValue)
                            {
                                GameData.money += 5;
                                lblMoney.Text = "$" + GameData.money.ToString();
                                AlertBox.Notify("¡Correcto!\nHas ganado $5", true);
                            }
                            else AlertBox.Notify("¡Incorrecto!");
                        }
                        else if (rndExercise == 34)
                        {
                            resValue = AlertBox.Question("¿El Beto Alonso fue el máximo goleador de River?\nRecompensa: $5");
                            if (resValue) AlertBox.Notify("¡Incorrecto!");
                            else
                            {
                                GameData.money += 5;
                                lblMoney.Text = "$" + GameData.money.ToString();
                                AlertBox.Notify("¡Correcto!\nHas ganado $5", true);
                            }
                        }
                        else if (rndExercise == 35)
                        {
                            Res = AlertBox.Input("¿Cuál es la longitud máxima en metros de un cable coaxil?\nRecompensa: $10", "green");
                            if (Res == "500")
                            {
                                GameData.money += 10;
                                lblMoney.Text = "$" + GameData.money.ToString();
                                AlertBox.Notify("¡Correcto!\nHas ganado $10", true);
                            }
                            else if (Res != null) AlertBox.Notify("¡Incorrecto!");
                        }
                        else if (rndExercise == 36)
                        {
                            Res = AlertBox.Input("¿Cuál es la longitud oficial en milimetros de una pelotita de ping pong?\nRecompensa: $10", "green");
                            if (Res == "38")
                            {
                                GameData.money += 10;
                                lblMoney.Text = "$" + GameData.money.ToString();
                                AlertBox.Notify("¡Correcto!\nHas ganado $10", true);
                            }
                            else if (Res != null) AlertBox.Notify("¡Incorrecto!");
                        }
                        else if (rndExercise == 37)
                        {
                            Res = AlertBox.Input("¿Cuál es la contra del Milan de italia?\nRecompensa: $7", "green");
                            if (Res == "Inter" || Res == "inter" || Res == "el inter" || Res == "El inter" || Res == "El Inter")
                            {
                                GameData.money += 7;
                                lblMoney.Text = "$" + GameData.money.ToString();
                                AlertBox.Notify("¡Correcto!\nHas ganado $7", true);
                            }
                            else if (Res != null) AlertBox.Notify("¡Incorrecto!");
                        }
                        else if (rndExercise == 38)
                        {
                            Res = AlertBox.Input("¿Quién es el fundador de Microsoft?\nRecompensa: $8", "green");
                            if (Res == "Bill Gates" || Res == "Bill gates" || Res == "bill gates" || Res == "bill Gates")
                            {
                                GameData.money += 8;
                                lblMoney.Text = "$" + GameData.money.ToString();
                                AlertBox.Notify("¡Correcto!\nHas ganado $8", true);
                            }
                            else if (Res != null) AlertBox.Notify("¡Incorrecto!");
                        }
                        else if (rndExercise == 39)
                        {
                            Res = AlertBox.Input("¿Quién es el fundador de Apple?\nRecompensa: $8", "green");
                            if (Res == "Steve Jobs" || Res == "Steve jobs" || Res == "steve jobs" || Res == "steve Jobs")
                            {
                                GameData.money += 8;
                                lblMoney.Text = "$" + GameData.money.ToString();
                                AlertBox.Notify("¡Correcto!\nHas ganado $8", true);
                            }
                            else if (Res != null) AlertBox.Notify("¡Incorrecto!");
                        }
                        else
                        {
                            resValue = AlertBox.Question("¿La Bruna fue el máximo goleador de River?\nRecompensa: $5");
                            if (resValue)
                            {
                                GameData.money += 5;
                                lblMoney.Text = "$" + GameData.money.ToString();
                                AlertBox.Notify("¡Correcto!\nHas ganado $5", true);
                            }
                            else AlertBox.Notify("¡Incorrecto!");
                        }
                        rnd = null;
                    }
                }
                else AlertBox.Notify("No tienes suficiente dinero");
            }
            else AlertBox.Notify("Se te acabaron tus 3 usos\nGira la ruleta para volver a obtenerlos");
        }

        private void pctBuyCoins_Click(object sender, EventArgs e)
        {
            frmBuyCoins FormBuyCoins = new frmBuyCoins();
            FormBuyCoins.lblMoney.Text = "$" + GameData.money.ToString();
            FormBuyCoins.lblGoldCoins.Text = GameData.goldCoins.ToString();
            FormBuyCoins.lblSilverCoins.Text = GameData.silverCoins.ToString();
            FormMode.Mode = "buy";
            if (FormMode.Mode == "buy") FormBuyCoins.pctBuyCoins.BackgroundImage = Image.FromFile(Lib.path + "ComprarFichas.png");
            else FormBuyCoins.pctBuyCoins.BackgroundImage = Image.FromFile(Lib.path + "VenderFichas.png");
            FormBuyCoins.Show();
            FormBuyCoins = null;
        }

        private void pctBuyCoins_MouseEnter(object sender, EventArgs e)
        {
            pctBuyCoins.BackColor = Color.Gold;
        }

        private void pctBuyCoins_MouseLeave(object sender, EventArgs e)
        {
            pctBuyCoins.BackColor = Color.White;
        }

        private void pctEarnMoney_MouseEnter(object sender, EventArgs e)
        {
            pctEarnMoney.BackColor = Color.LightGreen;
        }

        private void pctEarnMoney_MouseLeave(object sender, EventArgs e)
        {
            pctEarnMoney.BackColor = Color.White;
        }

        private void pctLoadMoney_MouseEnter(object sender, EventArgs e)
        {
            pctLoadMoney.BackColor = Color.Chartreuse;
        }

        private void pctLoadMoney_MouseLeave(object sender, EventArgs e)
        {
            pctLoadMoney.BackColor = Color.White;
        }

        private void frmGame_Load(object sender, EventArgs e)
        {
            this.Cursor = AdvancedCursors.Create(Path.Combine(Application.StartupPath, Lib.path + "cursor.ani"));
            GameData.money = 10;
            GameData.goldCoins = 0;
            GameData.silverCoins = 0;
            lblGoldCoins.Text = GameData.goldCoins.ToString();
            lblSilverCoins.Text = GameData.silverCoins.ToString();
            lblMoney.Text = "$" + GameData.money.ToString();
        }

        private void pictureBox71_Click(object sender, EventArgs e)
        {
            if (GameData.insertedGoldCoins > 0 || GameData.insertedSilverCoins > 0 || nuevoTiro == true)
            {
                pct15.BackColor = pct32.BackColor = Color.DodgerBlue;
                pct4.BackColor = Color.Gold;
                pct7.BackColor = Color.Goldenrod;
                pct1.BackColor = pct2.BackColor = pct3.BackColor = pct5.BackColor = pct6.BackColor = pct8.BackColor = pct9.BackColor = pct10.BackColor = pct11.BackColor = pct12.BackColor = pct13.BackColor = pct14.BackColor = pct16.BackColor = pct17.BackColor = pct18.BackColor = pct19.BackColor = pct20.BackColor = pct21.BackColor = pct22.BackColor = pct23.BackColor = pct24.BackColor = pct25.BackColor = pct26.BackColor = pct27.BackColor = pct28.BackColor = pct29.BackColor = pct30.BackColor = pct31.BackColor = pct33.BackColor = pct34.BackColor = pct35.BackColor = pct36.BackColor = Color.White;
                luz1.BackgroundImage = luz2.BackgroundImage = luz3.BackgroundImage = luz4.BackgroundImage = luz5.BackgroundImage = luz6.BackgroundImage = luz7.BackgroundImage = luz8.BackgroundImage = luz9.BackgroundImage = luz10.BackgroundImage = luz11.BackgroundImage = luz12.BackgroundImage = luz13.BackgroundImage = luz14.BackgroundImage = luz15.BackgroundImage = luz16.BackgroundImage = luz17.BackgroundImage = luz18.BackgroundImage = luz19.BackgroundImage = luz20.BackgroundImage = luz21.BackgroundImage = luz22.BackgroundImage = luz23.BackgroundImage = luz24.BackgroundImage = luz25.BackgroundImage = luz26.BackgroundImage = luz27.BackgroundImage = luz28.BackgroundImage = luz29.BackgroundImage = luz30.BackgroundImage = luz31.BackgroundImage = luz32.BackgroundImage = luz33.BackgroundImage = luz34.BackgroundImage = luz35.BackgroundImage = luz36.BackgroundImage = Image.FromFile(lightOff);
                if (!nuevoTiro && GameData.alreadyBetted == false)
                {
                    if (timerRoulette.Enabled == false)
                    {
                        frmBet FormBet = new frmBet();
                        FormBet.Show();
                        FormBet = null;
                        GameData.insertedCoinsBAR100 = GameData.insertedCoinsBAR50 = GameData.insertedCoinsStar = GameData.insertedCoinsApple = GameData.insertedCoinsCereza = GameData.insertedCoinsPera = GameData.insertedCoinsAnana = GameData.insertedCoinsBanana = GameData.insertedCoinsOrange = 0;
                    }
                    else AlertBox.Notify("La ruleta ya está andando");
                }
                else
                {
                    GameData.alreadyBetted = false;
                    nuevoTiro = false;
                    lblCoinsInsert.ForeColor = Color.Black;
                    lblCoinsInsert.Text = "Inserta la ficha aquí";
                    GameData.insertedGoldCoins = 0;
                    GameData.insertedSilverCoins = 0;
                    countWinMoneyTimes = 0;
                    GameData.lightTurn = 1;
                    GameData.finallyWinPos = 1;
                    numOfLaps = 0;
                    timerRoulette.Interval = 25;
                    Winning = false;
                    pctCancel.Visible = true;
                    if (timerRoulette.Enabled == false)
                    {
                        timerRoulette.Interval = 25;
                        timerRoulette.Enabled = true;
                        timerRoulette.Start();
                        Random rnd = new Random();
                        int rndPos = rnd.Next(1, 37);
                        if (GameData.typeCoin == 1)
                        {
                            if (rndPos == 1) GameData.finallyWinPos = 1;
                            else if (rndPos == 2) GameData.finallyWinPos = 2;
                            else if (rndPos == 3) GameData.finallyWinPos = 3;
                            else if (rndPos == 4)
                            {
                                rndPos = rnd.Next(1, 37);
                                if (rndPos == 4)
                                {
                                    rndPos = rnd.Next(1, 37);
                                    if (rndPos == 4) GameData.finallyWinPos = 4;
                                    else GameData.finallyWinPos = rnd.Next(5, 37);
                                }
                                else GameData.finallyWinPos = rnd.Next(10, 37);
                            }
                            else if (rndPos == 5) GameData.finallyWinPos = 5;
                            else if (rndPos == 6)
                            {
                                rndPos = rnd.Next(1, 37);
                                if (rndPos == 6) GameData.finallyWinPos = 6;
                                else GameData.finallyWinPos = rnd.Next(6, 20);
                            }
                            else if (rndPos == 7)
                            {
                                rndPos = rnd.Next(1, 37);
                                if (rndPos == 7)
                                {
                                    rndPos = rnd.Next(6, 8);
                                    if (rndPos == 7) GameData.finallyWinPos = 7;
                                    else GameData.finallyWinPos = rnd.Next(8, 37);
                                }
                                else GameData.finallyWinPos = rnd.Next(10, 37);
                            }
                            else if (rndPos == 8) GameData.finallyWinPos = 8;
                            else if (rndPos == 9) GameData.finallyWinPos = 9;
                            else if (rndPos == 10) GameData.finallyWinPos = 10;
                            else if (rndPos == 11) GameData.finallyWinPos = 11;
                            else if (rndPos == 12) GameData.finallyWinPos = 12;
                            else if (rndPos == 13) GameData.finallyWinPos = 13;
                            else if (rndPos == 14) GameData.finallyWinPos = 14;
                            else if (rndPos == 15) GameData.finallyWinPos = 15;
                            else if (rndPos == 16) GameData.finallyWinPos = 16;
                            else if (rndPos == 17) GameData.finallyWinPos = 17;
                            else if (rndPos == 18) GameData.finallyWinPos = 18;
                            else if (rndPos == 19) GameData.finallyWinPos = 19;
                            else if (rndPos == 20) GameData.finallyWinPos = 20;
                            else if (rndPos == 21) GameData.finallyWinPos = 21;
                            else if (rndPos == 22) GameData.finallyWinPos = 22;
                            else if (rndPos == 23)
                            {
                                rndPos = rnd.Next(1, 37);
                                if (rndPos == 23) GameData.finallyWinPos = 23;
                                else GameData.finallyWinPos = rnd.Next(23, 32);
                            }
                            else if (rndPos == 24) GameData.finallyWinPos = 24;
                            else if (rndPos == 25) GameData.finallyWinPos = 25;
                            else if (rndPos == 26) GameData.finallyWinPos = 26;
                            else if (rndPos == 27) GameData.finallyWinPos = 27;
                            else if (rndPos == 28) GameData.finallyWinPos = 28;
                            else if (rndPos == 29) GameData.finallyWinPos = 29;
                            else if (rndPos == 30) GameData.finallyWinPos = 30;
                            else if (rndPos == 31) GameData.finallyWinPos = 31;
                            else if (rndPos == 32) GameData.finallyWinPos = 32;
                            else if (rndPos == 33) GameData.finallyWinPos = 33;
                            else if (rndPos == 34) GameData.finallyWinPos = 34;
                            else if (rndPos == 35) GameData.finallyWinPos = 35;
                            else if (rndPos == 36) GameData.finallyWinPos = 36;
                        }
                        else if (GameData.typeCoin == 2)
                        {
                            if (rndPos == 1)
                            {
                                rndPos = rnd.Next(1, 3);
                                if (rndPos == 2) GameData.finallyWinPos = 1;
                                else GameData.finallyWinPos = rnd.Next(25, 37);
                            }
                            else if (rndPos == 2)
                            {
                                rndPos = rnd.Next(1, 3);
                                if (rndPos == 2) GameData.finallyWinPos = 2;
                                else GameData.finallyWinPos = rnd.Next(25, 37);
                            }
                            else if (rndPos == 3) GameData.finallyWinPos = 3;
                            else if (rndPos == 4)
                            {
                                rndPos = rnd.Next(1, 37);
                                if (rndPos == 4)
                                {
                                    rndPos = rnd.Next(1, 37);
                                    if (rndPos == 4)
                                    {
                                        rndPos = rnd.Next(1, 37);
                                        if (rndPos == 4) GameData.finallyWinPos = 4;
                                        else GameData.finallyWinPos = rnd.Next(6, 37);
                                    }
                                    else GameData.finallyWinPos = rnd.Next(5, 37);
                                }
                                else GameData.finallyWinPos = rnd.Next(10, 37);
                            }
                            else if (rndPos == 5) GameData.finallyWinPos = 5;
                            else if (rndPos == 6)
                            {
                                rndPos = rnd.Next(1, 37);
                                if (rndPos == 6)
                                {
                                    rndPos = rnd.Next(1, 5);
                                    if (rndPos == 2) GameData.finallyWinPos = 6;
                                    else GameData.finallyWinPos = rnd.Next(6, 20);
                                }
                                else GameData.finallyWinPos = rnd.Next(6, 20);
                            }
                            else if (rndPos == 7)
                            {
                                rndPos = rnd.Next(1, 37);
                                if (rndPos == 7)
                                {
                                    rndPos = rnd.Next(1, 37);
                                    if (rndPos == 7)
                                    {
                                        rndPos = rnd.Next(6, 8);
                                        if (rndPos == 7) GameData.finallyWinPos = 7;
                                        else GameData.finallyWinPos = rnd.Next(8, 37);
                                    }
                                    else GameData.finallyWinPos = rnd.Next(8, 37);
                                }
                                else GameData.finallyWinPos = rnd.Next(10, 37);
                            }
                            else if (rndPos == 8) GameData.finallyWinPos = 8;
                            else if (rndPos == 9)
                            {
                                rndPos = rnd.Next(1, 3);
                                if (rndPos == 2) GameData.finallyWinPos = 9;
                                else GameData.finallyWinPos = rnd.Next(25, 37);
                            }
                            else if (rndPos == 10)
                            {
                                rndPos = rnd.Next(1, 3);
                                if (rndPos == 2) GameData.finallyWinPos = 10;
                                else GameData.finallyWinPos = rnd.Next(25, 37);
                            }
                            else if (rndPos == 11) GameData.finallyWinPos = 11;
                            else if (rndPos == 12) GameData.finallyWinPos = 12;
                            else if (rndPos == 13)
                            {
                                rndPos = rnd.Next(1, 3);
                                if (rndPos == 2) GameData.finallyWinPos = 13;
                                else GameData.finallyWinPos = rnd.Next(25, 37);
                            }
                            else if (rndPos == 14) GameData.finallyWinPos = 14;
                            else if (rndPos == 15) GameData.finallyWinPos = 15;
                            else if (rndPos == 16)
                            {
                                rndPos = rnd.Next(1, 3);
                                if (rndPos == 2) GameData.finallyWinPos = 16;
                                else GameData.finallyWinPos = rnd.Next(25, 37);
                            }
                            else if (rndPos == 17) GameData.finallyWinPos = 17;
                            else if (rndPos == 18)
                            {
                                rndPos = rnd.Next(1, 3);
                                if (rndPos == 2) GameData.finallyWinPos = 18;
                                else GameData.finallyWinPos = rnd.Next(25, 37);
                            }
                            else if (rndPos == 19)
                            {
                                rndPos = rnd.Next(1, 3);
                                if (rndPos == 2) GameData.finallyWinPos = 19;
                                else GameData.finallyWinPos = rnd.Next(25, 37);
                            }
                            else if (rndPos == 20) GameData.finallyWinPos = 20;
                            else if (rndPos == 21) GameData.finallyWinPos = 21;
                            else if (rndPos == 22)
                            {
                                rndPos = rnd.Next(1, 3);
                                if (rndPos == 2) GameData.finallyWinPos = 22;
                                else GameData.finallyWinPos = rnd.Next(25, 37);
                            }
                            else if (rndPos == 23)
                            {
                                rndPos = rnd.Next(1, 37);
                                if (rndPos == 23)
                                {
                                    rndPos = rnd.Next(1, 5);
                                    if (rndPos == 2) GameData.finallyWinPos = 23;
                                    else GameData.finallyWinPos = rnd.Next(25, 37);
                                }
                                else GameData.finallyWinPos = rnd.Next(25, 37);
                            }
                            else if (rndPos == 24) GameData.finallyWinPos = 24;
                            else if (rndPos == 25)
                            {
                                rndPos = rnd.Next(1, 3);
                                if (rndPos == 2) GameData.finallyWinPos = 25;
                                else GameData.finallyWinPos = rnd.Next(25, 37);
                            }
                            else if (rndPos == 26) GameData.finallyWinPos = 26;
                            else if (rndPos == 27)
                            {
                                rndPos = rnd.Next(1, 3);
                                if (rndPos == 2) GameData.finallyWinPos = 27;
                                else GameData.finallyWinPos = rnd.Next(25, 37);
                            }
                            else if (rndPos == 28)
                            {
                                rndPos = rnd.Next(1, 3);
                                if (rndPos == 2) GameData.finallyWinPos = 28;
                                else GameData.finallyWinPos = rnd.Next(25, 37);
                            }
                            else if (rndPos == 29)
                            {
                                rndPos = rnd.Next(1, 3);
                                if (rndPos == 2) GameData.finallyWinPos = 29;
                                else GameData.finallyWinPos = rnd.Next(25, 37);
                            }
                            else if (rndPos == 30) GameData.finallyWinPos = 30;
                            else if (rndPos == 31)
                            {
                                rndPos = rnd.Next(1, 3);
                                if (rndPos == 2) GameData.finallyWinPos = 31;
                                else GameData.finallyWinPos = rnd.Next(25, 37);
                            }
                            else if (rndPos == 32) GameData.finallyWinPos = 32;
                            else if (rndPos == 33) GameData.finallyWinPos = 33;
                            else if (rndPos == 34)
                            {
                                rndPos = rnd.Next(1, 3);
                                if (rndPos == 2) GameData.finallyWinPos = 34;
                                else GameData.finallyWinPos = rnd.Next(25, 37);
                            }
                            else if (rndPos == 35) GameData.finallyWinPos = 35;
                            else if (rndPos == 36) GameData.finallyWinPos = 36;
                        }
                        rnd = null;
                        if (!(GameData.finallyWinPos >= 1 && GameData.finallyWinPos <= 37)) GameData.finallyWinPos = 4;
                    }
                }
            }
            else AlertBox.Notify("Primero debes insertar las fichas");
        }

        private void pictureBox71_MouseEnter(object sender, EventArgs e)
        {
            pctGirarRuleta.BackColor = Color.LightPink;
        }

        private void pictureBox71_MouseLeave(object sender, EventArgs e)
        {
            pctGirarRuleta.BackColor = Color.White;
        }

        private void timerParp_Tick(object sender, EventArgs e)
        {
            if (goldCoinDragged == true)
            {
                if (ovalTragamonedas.BorderColor == Color.Black)
                {
                    ovalTragamonedas.BorderColor = Color.Gold;
                    ovalTragamonedas.BorderWidth += 3;
                }
                else
                {
                    ovalTragamonedas.BorderColor = Color.Black;
                    ovalTragamonedas.BorderWidth -= 3;
                }
            }
            else if (silverCoinDragged == true)
            {
                if (ovalTragamonedas.BorderColor == Color.Black)
                {
                    ovalTragamonedas.BorderColor = Color.LightGray;
                    ovalTragamonedas.BorderWidth += 3;
                }
                else
                {
                    ovalTragamonedas.BorderColor = Color.Black;
                    ovalTragamonedas.BorderWidth -= 3;
                }
            }
        }

        private void pctTragamonedas_MouseEnter(object sender, EventArgs e)
        {
            if (goldCoinDragged == true)
            {
                ovalTragamonedas.BorderColor = Color.Gold;
                timerParp.Enabled = false;
            }
            else if (silverCoinDragged == true)
            {
                ovalTragamonedas.BorderColor = Color.LightGray;
                timerParp.Enabled = false;
            }
        }

        private void pctTragamonedas_MouseLeave(object sender, EventArgs e)
        {
            if (goldCoinDragged == true || silverCoinDragged == true)
            {
                ovalTragamonedas.BorderColor = Color.DarkGray;
                ovalTragamonedas.BorderWidth -= 3;
                timerParp.Enabled = true;
            }
        }

        private void pctTragamonedas_Click(object sender, EventArgs e)
        {
            if (goldCoinDragged == true || silverCoinDragged == true)
            {
                this.Cursor = AdvancedCursors.Create(Path.Combine(Application.StartupPath, Lib.path + "cursor.ani"));
                ovalTragamonedas.BorderColor = Color.Black;
                ovalTragamonedas.BorderWidth -= 3;
                timerParp.Enabled = false;
                if (goldCoinDragged == true)
                {
                    if (GameData.insertedSilverCoins == 0)
                    {
                        goldCoinDragged = false;
                        GameData.insertedGoldCoins++;
                        lblCoinsInsert.Text = GameData.insertedGoldCoins.ToString();
                        lblCoinsInsert.ForeColor = Color.DarkGoldenrod;
                        GameData.typeCoin = 1;
                    }
                    else
                    {
                        AlertBox.Notify("No puedes insertar diferentes tipos de fichas");
                        GameData.goldCoins++;
                        lblGoldCoins.Text = GameData.goldCoins.ToString();
                        goldCoinDragged = false;
                    }
                }
                else if (silverCoinDragged == true)
                {
                    if (GameData.insertedGoldCoins == 0)
                    {
                        silverCoinDragged = false;
                        GameData.insertedSilverCoins++;
                        lblCoinsInsert.Text = GameData.insertedSilverCoins.ToString();
                        lblCoinsInsert.ForeColor = Color.Gray;
                        GameData.typeCoin = 2;
                    }
                    else
                    {
                        AlertBox.Notify("No puedes insertar diferentes tipos de fichas");
                        GameData.silverCoins++;
                        lblSilverCoins.Text = GameData.silverCoins.ToString();
                        silverCoinDragged = false;
                    }
                }
            }
        }

        private void lblGoldCoins_Click(object sender, EventArgs e)
        {
            if (GameData.alreadyBetted == false)
            {
                if (GameData.goldCoins > 0 || goldCoinDragged == true)
                {
                    if (silverCoinDragged == true)
                    {
                        silverCoinDragged = false;
                        GameData.silverCoins++;
                        lblSilverCoins.Text = GameData.silverCoins.ToString();
                    }
                    else if (goldCoinDragged == false)
                    {
                        GameData.goldCoins--;
                        lblGoldCoins.Text = GameData.goldCoins.ToString();
                        goldCoinDragged = true;
                        timerParp.Enabled = true;
                        this.Cursor = AdvancedCursors.Create(Path.Combine(Application.StartupPath, Lib.path + "fichasoro.ico"));
                    }
                    else if (goldCoinDragged == true)
                    {
                        this.Cursor = AdvancedCursors.Create(Path.Combine(Application.StartupPath, Lib.path + "cursor.ani"));
                        timerParp.Enabled = false;
                        GameData.goldCoins++;
                        lblGoldCoins.Text = GameData.goldCoins.ToString();
                        goldCoinDragged = false;
                    }
                }
                else AlertBox.Notify("No tienes más fichas de oro");
            }
            else AlertBox.Notify("Ya apostaste, no puedes insertar más fichas\nPresiona el botón ¡Girar ruleta!");
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (GameData.alreadyBetted == false)
            {
                if (GameData.goldCoins > 0 || goldCoinDragged == true)
                {
                    if (silverCoinDragged == true)
                    {
                        silverCoinDragged = false;
                        GameData.silverCoins++;
                        lblSilverCoins.Text = GameData.silverCoins.ToString();
                    }
                    else if (goldCoinDragged == false)
                    {
                        GameData.goldCoins--;
                        lblGoldCoins.Text = GameData.goldCoins.ToString();
                        goldCoinDragged = true;
                        timerParp.Enabled = true;
                        this.Cursor = AdvancedCursors.Create(Path.Combine(Application.StartupPath, Lib.path + "fichasoro.ico"));
                    }
                    else if (goldCoinDragged == true)
                    {
                        this.Cursor = AdvancedCursors.Create(Path.Combine(Application.StartupPath, Lib.path + "cursor.ani"));
                        timerParp.Enabled = false;
                        GameData.goldCoins++;
                        lblGoldCoins.Text = GameData.goldCoins.ToString();
                        goldCoinDragged = false;
                    }
                }
                else AlertBox.Notify("No tienes más fichas de oro");
            }
            else AlertBox.Notify("Ya apostaste, no puedes insertar más fichas\nPresiona el botón ¡Girar ruleta!");
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            if (GameData.alreadyBetted == false)
            {
                if (GameData.silverCoins > 0 || silverCoinDragged == true)
                {
                    if (goldCoinDragged == true)
                    {
                        goldCoinDragged = false;
                        GameData.goldCoins++;
                        lblGoldCoins.Text = GameData.goldCoins.ToString();
                    }
                    else if (silverCoinDragged == false)
                    {
                        GameData.silverCoins--;
                        lblSilverCoins.Text = GameData.silverCoins.ToString();
                        silverCoinDragged = true;
                        timerParp.Enabled = true;
                        this.Cursor = AdvancedCursors.Create(Path.Combine(Application.StartupPath, Lib.path + "fichasplata.ico"));
                    }
                    else if (silverCoinDragged == true)
                    {
                        this.Cursor = AdvancedCursors.Create(Path.Combine(Application.StartupPath, Lib.path + "cursor.ani"));
                        timerParp.Enabled = false;
                        GameData.silverCoins++;
                        lblSilverCoins.Text = GameData.silverCoins.ToString();
                        silverCoinDragged = false;
                    }
                }
                else AlertBox.Notify("No tienes más fichas de plata");
            }
            else AlertBox.Notify("Ya apostaste, no puedes insertar más fichas\nPresiona el botón ¡Girar ruleta!");
        }

        private void lblSilverCoins_Click(object sender, EventArgs e)
        {
            if (GameData.alreadyBetted == false)
            {
                if (GameData.silverCoins > 0 || silverCoinDragged == true)
                {
                    if (goldCoinDragged == true)
                    {
                        goldCoinDragged = false;
                        GameData.goldCoins++;
                        lblGoldCoins.Text = GameData.goldCoins.ToString();
                    }
                    else if (silverCoinDragged == false)
                    {
                        GameData.silverCoins--;
                        lblSilverCoins.Text = GameData.silverCoins.ToString();
                        silverCoinDragged = true;
                        timerParp.Enabled = true;
                        this.Cursor = AdvancedCursors.Create(Path.Combine(Application.StartupPath, Lib.path + "fichasplata.ico"));
                    }
                    else if (silverCoinDragged == true)
                    {
                        this.Cursor = AdvancedCursors.Create(Path.Combine(Application.StartupPath, Lib.path + "cursor.ani"));
                        timerParp.Enabled = false;
                        GameData.silverCoins++;
                        lblSilverCoins.Text = GameData.silverCoins.ToString();
                        silverCoinDragged = false;
                    }
                }
                else AlertBox.Notify("No tienes más fichas de plata");
            }
            else AlertBox.Notify("Ya apostaste, no puedes insertar más fichas\nPresiona el botón ¡Girar ruleta!");
        }

        private void timerRoulette_Tick(object sender, EventArgs e)
        {
            Lib.PlaySound("roulette.wav");
            if (GameData.lightTurn == 1)
            {
                if (numOfLaps >= 7 && GameData.finallyWinPos == GameData.lightTurn-1)
                {
                    if (GameData.typeCoin == 1)
                    {
                        GameData.goldCoins += GameData.VALUE_ANANA * GameData.insertedCoinsAnana;
                        typeCoins = "oro";
                    }
                    else if (GameData.typeCoin == 2)
                    {
                        GameData.silverCoins += GameData.VALUE_ANANA * GameData.insertedCoinsAnana;
                        typeCoins = "plata";
                    }
                    if (GameData.VALUE_ANANA * GameData.insertedCoinsAnana > 0)
                    {
                        pct1.BackColor = Color.Lime;
                        AlertBox.Notify("¡Ganaste!\nRecompensa: " + GameData.VALUE_ANANA * GameData.insertedCoinsAnana + " fichas de " + typeCoins, true);
                        lblGoldCoins.Text = GameData.goldCoins.ToString();
                        lblSilverCoins.Text = GameData.silverCoins.ToString();
                        Winning = true;
                        pctCancel.Visible = false;
                        GameData.cantWinAnana++;
                        if (GameData.typeCoin == 1) GameData.cantWinGoldCoinsAnana += GameData.VALUE_ANANA * GameData.insertedCoinsAnana;
                        else if (GameData.typeCoin == 2) GameData.cantWinSilverCoinsAnana += GameData.VALUE_ANANA * GameData.insertedCoinsAnana;
                    }
                    else
                    {
                        GameData.cantLosAnana++;
                        pct1.BackColor = Color.Red;
                        pctCancel.Visible = false;
                        AlertBox.Notify("¡No ganas nada!");
                    }
                    timerRoulette.Enabled = false;
                }
                luz36.BackgroundImage = Image.FromFile(lightOff);
                luz1.BackgroundImage = Image.FromFile(lightOn);
                GameData.lightTurn++;
                if (numOfLaps < 4 && numOfLaps > 1) timerRoulette.Interval += 3;
                else if (numOfLaps >= 3) timerRoulette.Interval += 20;
            }
            else if (GameData.lightTurn == 2)
            {
                if (numOfLaps == 4 && GameData.finallyWinPos == GameData.lightTurn - 1)
                {
                    if (GameData.typeCoin == 1)
                    {
                        GameData.goldCoins += GameData.VALUE_ORANGE * GameData.insertedCoinsOrange;
                        typeCoins = "oro";
                    }
                    else if (GameData.typeCoin == 2)
                    {
                        GameData.silverCoins += GameData.VALUE_ORANGE * GameData.insertedCoinsOrange;
                        typeCoins = "plata";
                    }
                    if (GameData.VALUE_ORANGE * GameData.insertedCoinsOrange > 0)
                    {
                        pct2.BackColor = Color.Lime;
                        AlertBox.Notify("¡Ganaste!\nRecompensa: " + GameData.VALUE_ORANGE * GameData.insertedCoinsOrange + " fichas de " + typeCoins, true);
                        lblGoldCoins.Text = GameData.goldCoins.ToString();
                        lblSilverCoins.Text = GameData.silverCoins.ToString();
                        Winning = true;
                        pctCancel.Visible = false;
                        GameData.cantWinOrange++;
                        if (GameData.typeCoin == 1) GameData.cantWinGoldCoinsOrange += GameData.VALUE_ORANGE * GameData.insertedCoinsOrange;
                        else if (GameData.typeCoin == 2) GameData.cantWinSilverCoinsOrange += GameData.VALUE_ORANGE * GameData.insertedCoinsOrange;
                    }
                    else
                    {
                        GameData.cantLosOrange++;
                        pct2.BackColor = Color.Red;
                        pctCancel.Visible = false;
                        AlertBox.Notify("¡No ganas nada!");
                    }
                    timerRoulette.Enabled = false;
                }
                luz1.BackgroundImage = Image.FromFile(lightOff);
                luz2.BackgroundImage = Image.FromFile(lightOn);
                GameData.lightTurn++;
                if (numOfLaps < 4 && numOfLaps > 1) timerRoulette.Interval += 3;
                else if (numOfLaps >= 3) timerRoulette.Interval += 20;
            }
            else if (GameData.lightTurn == 3)
            {
                if (numOfLaps == 4 && GameData.finallyWinPos == GameData.lightTurn - 1)
                {
                    if (GameData.typeCoin == 1)
                    {
                        GameData.goldCoins += GameData.VALUE_CEREZA * GameData.insertedCoinsCereza;
                        typeCoins = "oro";
                    }
                    else if (GameData.typeCoin == 2)
                    {
                        GameData.silverCoins += GameData.VALUE_CEREZA * GameData.insertedCoinsCereza;
                        typeCoins = "plata";
                    }
                    if (GameData.VALUE_CEREZA * GameData.insertedCoinsCereza > 0)
                    {
                        pct3.BackColor = Color.Lime;
                        AlertBox.Notify("¡Ganaste!\nRecompensa: " + GameData.VALUE_CEREZA * GameData.insertedCoinsCereza + " fichas de " + typeCoins, true);
                        lblGoldCoins.Text = GameData.goldCoins.ToString();
                        lblSilverCoins.Text = GameData.silverCoins.ToString();
                        Winning = true;
                        pctCancel.Visible = false;
                        GameData.cantWinCereza++;
                        if (GameData.typeCoin == 1) GameData.cantWinGoldCoinsCereza += GameData.VALUE_CEREZA * GameData.insertedCoinsCereza;
                        else if (GameData.typeCoin == 2) GameData.cantWinSilverCoinsCereza += GameData.VALUE_CEREZA * GameData.insertedCoinsCereza;
                    }
                    else
                    {
                        GameData.cantLosCereza++;
                        pct3.BackColor = Color.Red;
                        pctCancel.Visible = false;
                        AlertBox.Notify("¡No ganas nada!");
                    }
                    timerRoulette.Enabled = false;
                }
                luz2.BackgroundImage = Image.FromFile(lightOff);
                luz3.BackgroundImage = Image.FromFile(lightOn);
                GameData.lightTurn++;
                if (numOfLaps < 4 && numOfLaps > 1) timerRoulette.Interval += 3;
                else if (numOfLaps >= 3) timerRoulette.Interval += 20;
            }
            else if (GameData.lightTurn == 4)
            {
                if (numOfLaps == 4 && GameData.finallyWinPos == GameData.lightTurn - 1)
                {
                    if (GameData.typeCoin == 1)
                    {
                        GameData.goldCoins += GameData.VALUE_BAR100 * GameData.insertedCoinsBAR100;
                        typeCoins = "oro";
                    }
                    else if (GameData.typeCoin == 2)
                    {
                        GameData.silverCoins += GameData.VALUE_BAR100 * GameData.insertedCoinsBAR100;
                        typeCoins = "plata";
                    }
                    if (GameData.VALUE_BAR100 * GameData.insertedCoinsBAR100 > 0)
                    {
                        pct4.BackColor = Color.Lime;
                        AlertBox.Notify("¡Ganaste!\nRecompensa: " + GameData.VALUE_BAR100 * GameData.insertedCoinsBAR100 + " fichas de " + typeCoins, true);
                        lblGoldCoins.Text = GameData.goldCoins.ToString();
                        lblSilverCoins.Text = GameData.silverCoins.ToString();
                        Winning = true;
                        pctCancel.Visible = false;
                        GameData.cantWinBAR100++;
                        if (GameData.typeCoin == 1) GameData.cantWinGoldCoinsBAR100 += GameData.VALUE_BAR100 * GameData.insertedCoinsBAR100;
                        else if (GameData.typeCoin == 2) GameData.cantWinSilverCoinsBAR100 += GameData.VALUE_BAR100 * GameData.insertedCoinsBAR100;
                    }
                    else
                    {
                        GameData.cantLosBAR100++;
                        pct4.BackColor = Color.Red;
                        pctCancel.Visible = false;
                        AlertBox.Notify("¡No ganas nada!");
                    }
                    timerRoulette.Enabled = false;
                }
                luz3.BackgroundImage = Image.FromFile(lightOff);
                luz4.BackgroundImage = Image.FromFile(lightOn);
                GameData.lightTurn++;
                if (numOfLaps < 4 && numOfLaps > 1) timerRoulette.Interval += 3;
                else if (numOfLaps >= 3) timerRoulette.Interval += 20;
            }
            else if (GameData.lightTurn == 5)
            {
                if (numOfLaps == 4 && GameData.finallyWinPos == GameData.lightTurn - 1)
                {
                    if (GameData.typeCoin == 1)
                    {
                        GameData.goldCoins += GameData.VALUE_APPLE * GameData.insertedCoinsApple;
                        typeCoins = "oro";
                    }
                    else if (GameData.typeCoin == 2)
                    {
                        GameData.silverCoins += GameData.VALUE_APPLE * GameData.insertedCoinsApple;
                        typeCoins = "plata";
                    }
                    if (GameData.VALUE_APPLE * GameData.insertedCoinsApple > 0)
                    {
                        pct5.BackColor = Color.Lime;
                        AlertBox.Notify("¡Ganaste!\nRecompensa: " + GameData.VALUE_APPLE * GameData.insertedCoinsApple + " fichas de " + typeCoins, true);
                        lblGoldCoins.Text = GameData.goldCoins.ToString();
                        lblSilverCoins.Text = GameData.silverCoins.ToString();
                        Winning = true;
                        pctCancel.Visible = false;
                        GameData.cantWinApple++;
                        if (GameData.typeCoin == 1) GameData.cantWinGoldCoinsApple += GameData.VALUE_APPLE * GameData.insertedCoinsApple;
                        else if (GameData.typeCoin == 2) GameData.cantWinSilverCoinsApple += GameData.VALUE_APPLE * GameData.insertedCoinsApple;
                    }
                    else
                    {
                        GameData.cantLosApple++;
                        pctCancel.Visible = false;
                        pct5.BackColor = Color.Red;
                        AlertBox.Notify("¡No ganas nada!");
                    }
                    timerRoulette.Enabled = false;
                }
                luz4.BackgroundImage = Image.FromFile(lightOff);
                luz5.BackgroundImage = Image.FromFile(lightOn);
                GameData.lightTurn++;
                if (numOfLaps < 4 && numOfLaps > 1) timerRoulette.Interval += 3;
                else if (numOfLaps >= 3) timerRoulette.Interval += 20;
            }
            else if (GameData.lightTurn == 6)
            {
                if (numOfLaps == 4 && GameData.finallyWinPos == GameData.lightTurn - 1)
                {
                    if (GameData.typeCoin == 1)
                    {
                        GameData.goldCoins += GameData.VALUE_STAR * GameData.insertedCoinsStar;
                        typeCoins = "oro";
                    }
                    else if (GameData.typeCoin == 2)
                    {
                        GameData.silverCoins += GameData.VALUE_STAR * GameData.insertedCoinsStar;
                        typeCoins = "plata";
                    }
                    if (GameData.VALUE_STAR * GameData.insertedCoinsStar > 0)
                    {
                        pct6.BackColor = Color.Lime;
                        AlertBox.Notify("¡Ganaste!\nRecompensa: " + GameData.VALUE_STAR * GameData.insertedCoinsStar + " fichas de " + typeCoins, true);
                        lblGoldCoins.Text = GameData.goldCoins.ToString();
                        lblSilverCoins.Text = GameData.silverCoins.ToString();
                        Winning = true;
                        pctCancel.Visible = false;
                        GameData.cantWinStar++;
                        if (GameData.typeCoin == 1) GameData.cantWinGoldCoinsStar += GameData.VALUE_STAR * GameData.insertedCoinsStar;
                        else if (GameData.typeCoin == 2) GameData.cantWinSilverCoinsStar += GameData.VALUE_STAR * GameData.insertedCoinsStar;
                    }
                    else
                    {
                        GameData.cantLosStar++;
                        pctCancel.Visible = false;
                        pct6.BackColor = Color.Red;
                        AlertBox.Notify("¡No ganas nada!");
                    }
                    timerRoulette.Enabled = false;
                }
                luz5.BackgroundImage = Image.FromFile(lightOff);
                luz6.BackgroundImage = Image.FromFile(lightOn);
                GameData.lightTurn++;
                if (numOfLaps < 4 && numOfLaps > 1) timerRoulette.Interval += 3;
                else if (numOfLaps >= 3) timerRoulette.Interval += 20;
            }
            else if (GameData.lightTurn == 7)
            {
                if (numOfLaps == 4 && GameData.finallyWinPos == GameData.lightTurn - 1)
                {
                    if (GameData.typeCoin == 1)
                    {
                        GameData.goldCoins += GameData.VALUE_BAR50 * GameData.insertedCoinsBAR50;
                        typeCoins = "oro";
                    }
                    else if (GameData.typeCoin == 2)
                    {
                        GameData.silverCoins += GameData.VALUE_BAR50 * GameData.insertedCoinsBAR50;
                        typeCoins = "plata";
                    }
                    if (GameData.VALUE_BAR50 * GameData.insertedCoinsBAR50 > 0)
                    {
                        pct7.BackColor = Color.Lime;
                        AlertBox.Notify("¡Ganaste!\nRecompensa: " + GameData.VALUE_BAR50 * GameData.insertedCoinsBAR50 + " fichas de " + typeCoins, true);
                        lblGoldCoins.Text = GameData.goldCoins.ToString();
                        lblSilverCoins.Text = GameData.silverCoins.ToString();
                        Winning = true;
                        pctCancel.Visible = false;
                        GameData.cantWinBAR50++;
                        if (GameData.typeCoin == 1) GameData.cantWinGoldCoinsBAR50 += GameData.VALUE_BAR50 * GameData.insertedCoinsBAR50;
                        else if (GameData.typeCoin == 2) GameData.cantWinSilverCoinsBAR50 += GameData.VALUE_BAR50 * GameData.insertedCoinsBAR50;
                    }
                    else
                    {
                        GameData.cantLosBAR50++;
                        pct7.BackColor = Color.Red;
                        pctCancel.Visible = false;
                        AlertBox.Notify("¡No ganas nada!");
                    }
                    timerRoulette.Enabled = false;
                }
                luz6.BackgroundImage = Image.FromFile(lightOff);
                luz7.BackgroundImage = Image.FromFile(lightOn);
                GameData.lightTurn++;
                if (numOfLaps < 4 && numOfLaps > 1) timerRoulette.Interval += 3;
                else if (numOfLaps >= 3) timerRoulette.Interval += 20;
            }
            else if (GameData.lightTurn == 8)
            {
                if (numOfLaps == 4 && GameData.finallyWinPos == GameData.lightTurn - 1)
                {
                    if (GameData.typeCoin == 1)
                    {
                        GameData.goldCoins += GameData.VALUE_CEREZA * GameData.insertedCoinsCereza;
                        typeCoins = "oro";
                    }
                    else if (GameData.typeCoin == 2)
                    {
                        GameData.silverCoins += GameData.VALUE_CEREZA * GameData.insertedCoinsCereza;
                        typeCoins = "plata";
                    }
                    if (GameData.VALUE_CEREZA * GameData.insertedCoinsCereza > 0)
                    {
                        pct8.BackColor = Color.Lime;
                        AlertBox.Notify("¡Ganaste!\nRecompensa: " + GameData.VALUE_CEREZA * GameData.insertedCoinsCereza + " fichas de " + typeCoins, true);
                        lblGoldCoins.Text = GameData.goldCoins.ToString();
                        lblSilverCoins.Text = GameData.silverCoins.ToString();
                        Winning = true;
                        pctCancel.Visible = false;
                        GameData.cantWinCereza++;
                        if (GameData.typeCoin == 1) GameData.cantWinGoldCoinsCereza += GameData.VALUE_CEREZA * GameData.insertedCoinsCereza;
                        else if (GameData.typeCoin == 2) GameData.cantWinSilverCoinsCereza += GameData.VALUE_CEREZA * GameData.insertedCoinsCereza;
                    }
                    else
                    {
                        GameData.cantLosCereza++;
                        pct8.BackColor = Color.Red;
                        pctCancel.Visible = false;
                        AlertBox.Notify("¡No ganas nada!");
                    }
                    timerRoulette.Enabled = false;
                }
                luz7.BackgroundImage = Image.FromFile(lightOff);
                luz8.BackgroundImage = Image.FromFile(lightOn);
                GameData.lightTurn++;
                if (numOfLaps < 4 && numOfLaps > 1) timerRoulette.Interval += 3;
                else if (numOfLaps >= 3) timerRoulette.Interval += 20;
            }
            else if (GameData.lightTurn == 9)
            {
                if (numOfLaps == 4 && GameData.finallyWinPos == GameData.lightTurn - 1)
                {
                    if (GameData.typeCoin == 1)
                    {
                        GameData.goldCoins += GameData.VALUE_ORANGE * GameData.insertedCoinsOrange;
                        typeCoins = "oro";
                    }
                    else if (GameData.typeCoin == 2)
                    {
                        GameData.silverCoins += GameData.VALUE_ORANGE * GameData.insertedCoinsOrange;
                        typeCoins = "plata";
                    }
                    if (GameData.VALUE_ORANGE * GameData.insertedCoinsOrange > 0)
                    {
                        pct9.BackColor = Color.Lime;
                        AlertBox.Notify("¡Ganaste!\nRecompensa: " + GameData.VALUE_ORANGE * GameData.insertedCoinsOrange + " fichas de " + typeCoins, true);
                        lblGoldCoins.Text = GameData.goldCoins.ToString();
                        lblSilverCoins.Text = GameData.silverCoins.ToString();
                        Winning = true;
                        pctCancel.Visible = false;
                        GameData.cantWinOrange++;
                        if (GameData.typeCoin == 1) GameData.cantWinGoldCoinsOrange += GameData.VALUE_ORANGE * GameData.insertedCoinsOrange;
                        else if (GameData.typeCoin == 2) GameData.cantWinSilverCoinsOrange += GameData.VALUE_ORANGE * GameData.insertedCoinsOrange;
                    }
                    else
                    {
                        GameData.cantLosOrange++;
                        pct9.BackColor = Color.Red;
                        AlertBox.Notify("¡No ganas nada!");
                        pctCancel.Visible = false;
                    }
                    timerRoulette.Enabled = false;
                }
                luz8.BackgroundImage = Image.FromFile(lightOff);
                luz9.BackgroundImage = Image.FromFile(lightOn);
                GameData.lightTurn++;
                if (numOfLaps < 4 && numOfLaps > 1) timerRoulette.Interval += 3;
                else if (numOfLaps >= 3) timerRoulette.Interval += 20;
            }
            else if (GameData.lightTurn == 10)
            {
                if (numOfLaps == 4 && GameData.finallyWinPos == GameData.lightTurn - 1)
                {
                    if (GameData.typeCoin == 1)
                    {
                        GameData.goldCoins += GameData.VALUE_ANANA * GameData.insertedCoinsAnana;
                        typeCoins = "oro";
                    }
                    else if (GameData.typeCoin == 2)
                    {
                        GameData.silverCoins += GameData.VALUE_ANANA * GameData.insertedCoinsAnana;
                        typeCoins = "plata";
                    }
                    if (GameData.VALUE_ANANA * GameData.insertedCoinsAnana > 0)
                    {
                        pct10.BackColor = Color.Lime;
                        AlertBox.Notify("¡Ganaste!\nRecompensa: " + GameData.VALUE_ANANA * GameData.insertedCoinsAnana + " fichas de " + typeCoins, true);
                        lblGoldCoins.Text = GameData.goldCoins.ToString();
                        lblSilverCoins.Text = GameData.silverCoins.ToString();
                        Winning = true;
                        pctCancel.Visible = false;
                        GameData.cantWinAnana++;
                        if (GameData.typeCoin == 1) GameData.cantWinGoldCoinsAnana += GameData.VALUE_ANANA * GameData.insertedCoinsAnana;
                        else if (GameData.typeCoin == 2) GameData.cantWinSilverCoinsAnana += GameData.VALUE_ANANA * GameData.insertedCoinsAnana;
                    }
                    else
                    {
                        GameData.cantLosAnana++;
                        pct10.BackColor = Color.Red;
                        pctCancel.Visible = false;
                        AlertBox.Notify("¡No ganas nada!");
                    }
                    timerRoulette.Enabled = false;
                }
                luz9.BackgroundImage = Image.FromFile(lightOff);
                luz10.BackgroundImage = Image.FromFile(lightOn);
                GameData.lightTurn++;
                if (numOfLaps < 4 && numOfLaps > 1) timerRoulette.Interval += 3;
                else if (numOfLaps >= 3) timerRoulette.Interval += 20;
            }
            else if (GameData.lightTurn == 11)
            {
                if (numOfLaps == 4 && GameData.finallyWinPos == GameData.lightTurn - 1)
                {
                    if (GameData.typeCoin == 1)
                    {
                        GameData.goldCoins += GameData.VALUE_APPLE * GameData.insertedCoinsApple;
                        typeCoins = "oro";
                    }
                    else if (GameData.typeCoin == 2)
                    {
                        GameData.silverCoins += GameData.VALUE_APPLE * GameData.insertedCoinsApple;
                        typeCoins = "plata";
                    }
                    if (GameData.VALUE_APPLE * GameData.insertedCoinsApple > 0)
                    {
                        pct11.BackColor = Color.Lime;
                        AlertBox.Notify("¡Ganaste!\nRecompensa: " + GameData.VALUE_APPLE * GameData.insertedCoinsApple + " fichas de " + typeCoins, true);
                        lblGoldCoins.Text = GameData.goldCoins.ToString();
                        lblSilverCoins.Text = GameData.silverCoins.ToString();
                        Winning = true;
                        pctCancel.Visible = false;
                        GameData.cantWinApple++;
                        if (GameData.typeCoin == 1) GameData.cantWinGoldCoinsApple += GameData.VALUE_APPLE * GameData.insertedCoinsApple;
                        else if (GameData.typeCoin == 2) GameData.cantWinSilverCoinsApple += GameData.VALUE_APPLE * GameData.insertedCoinsApple;
                    }
                    else
                    {
                        GameData.cantLosApple++;
                        pct11.BackColor = Color.Red;
                        pctCancel.Visible = false;
                        AlertBox.Notify("¡No ganas nada!");
                    }
                    timerRoulette.Enabled = false;
                }
                luz10.BackgroundImage = Image.FromFile(lightOff);
                luz11.BackgroundImage = Image.FromFile(lightOn);
                GameData.lightTurn++;
                if (numOfLaps < 4 && numOfLaps > 1) timerRoulette.Interval += 3;
                else if (numOfLaps >= 3) timerRoulette.Interval += 20;
            }
            else if (GameData.lightTurn == 12)
            {
                if (numOfLaps == 4 && GameData.finallyWinPos == GameData.lightTurn - 1)
                {
                    if (GameData.typeCoin == 1)
                    {
                        GameData.goldCoins += GameData.VALUE_CEREZA * GameData.insertedCoinsCereza;
                        typeCoins = "oro";
                    }
                    else if (GameData.typeCoin == 2)
                    {
                        GameData.silverCoins += GameData.VALUE_CEREZA * GameData.insertedCoinsCereza;
                        typeCoins = "plata";
                    }
                    if (GameData.VALUE_CEREZA * GameData.insertedCoinsCereza > 0)
                    {
                        pct12.BackColor = Color.Lime;
                        AlertBox.Notify("¡Ganaste!\nRecompensa: " + GameData.VALUE_CEREZA * GameData.insertedCoinsCereza + " fichas de " + typeCoins, true);
                        lblGoldCoins.Text = GameData.goldCoins.ToString();
                        lblSilverCoins.Text = GameData.silverCoins.ToString();
                        Winning = true;
                        pctCancel.Visible = false;
                        GameData.cantWinCereza++;
                        if (GameData.typeCoin == 1) GameData.cantWinGoldCoinsCereza += GameData.VALUE_CEREZA * GameData.insertedCoinsCereza;
                        else if (GameData.typeCoin == 2) GameData.cantWinSilverCoinsCereza += GameData.VALUE_CEREZA * GameData.insertedCoinsCereza;
                    }
                    else
                    {
                        GameData.cantLosCereza++;
                        pct12.BackColor = Color.Red;
                        pctCancel.Visible = false;
                        AlertBox.Notify("¡No ganas nada!");
                    }
                    timerRoulette.Enabled = false;
                }
                luz11.BackgroundImage = Image.FromFile(lightOff);
                luz12.BackgroundImage = Image.FromFile(lightOn);
                GameData.lightTurn++;
                if (numOfLaps < 4 && numOfLaps > 1) timerRoulette.Interval += 3;
                else if (numOfLaps >= 3) timerRoulette.Interval += 20;
            }
            else if (GameData.lightTurn == 13)
            {
                if (numOfLaps == 4 && GameData.finallyWinPos == GameData.lightTurn - 1)
                {
                    if (GameData.typeCoin == 1)
                    {
                        GameData.goldCoins += GameData.VALUE_BANANA * GameData.insertedCoinsBanana;
                        typeCoins = "oro";
                    }
                    else if (GameData.typeCoin == 2)
                    {
                        GameData.silverCoins += GameData.VALUE_BANANA * GameData.insertedCoinsBanana;
                        typeCoins = "plata";
                    }
                    if (GameData.VALUE_BANANA * GameData.insertedCoinsBanana > 0)
                    {
                        pct13.BackColor = Color.Lime;
                        AlertBox.Notify("¡Ganaste!\nRecompensa: " + GameData.VALUE_BANANA * GameData.insertedCoinsBanana + " fichas de " + typeCoins, true);
                        lblGoldCoins.Text = GameData.goldCoins.ToString();
                        lblSilverCoins.Text = GameData.silverCoins.ToString();
                        Winning = true;
                        pctCancel.Visible = false;
                        GameData.cantWinBanana++;
                        if (GameData.typeCoin == 1) GameData.cantWinGoldCoinsBanana += GameData.VALUE_BANANA * GameData.insertedCoinsBanana;
                        else if (GameData.typeCoin == 2) GameData.cantWinSilverCoinsBanana += GameData.VALUE_BANANA * GameData.insertedCoinsBanana;
                    }
                    else
                    {
                        GameData.cantLosBanana++;
                        pct13.BackColor = Color.Red;
                        pctCancel.Visible = false;
                        AlertBox.Notify("¡No ganas nada!");
                    }
                    timerRoulette.Enabled = false;
                }
                luz12.BackgroundImage = Image.FromFile(lightOff);
                luz13.BackgroundImage = Image.FromFile(lightOn);
                GameData.lightTurn++;
                if (numOfLaps < 4 && numOfLaps > 1) timerRoulette.Interval += 3;
                else if (numOfLaps >= 3) timerRoulette.Interval += 20;
            }
            else if (GameData.lightTurn == 14)
            {
                if (numOfLaps == 4 && GameData.finallyWinPos == GameData.lightTurn - 1)
                {
                    if (GameData.typeCoin == 1)
                    {
                        GameData.goldCoins += GameData.VALUE_APPLE * GameData.insertedCoinsApple;
                        typeCoins = "oro";
                    }
                    else if (GameData.typeCoin == 2)
                    {
                        GameData.silverCoins += GameData.VALUE_APPLE * GameData.insertedCoinsApple;
                        typeCoins = "plata";
                    }
                    if (GameData.VALUE_APPLE * GameData.insertedCoinsApple > 0)
                    {
                        pct14.BackColor = Color.Lime;
                        AlertBox.Notify("¡Ganaste!\nRecompensa: " + GameData.VALUE_APPLE * GameData.insertedCoinsApple + " fichas de " + typeCoins, true);
                        lblGoldCoins.Text = GameData.goldCoins.ToString();
                        lblSilverCoins.Text = GameData.silverCoins.ToString();
                        Winning = true;
                        pctCancel.Visible = false;
                        GameData.cantWinApple++;
                        if (GameData.typeCoin == 1) GameData.cantWinGoldCoinsApple += GameData.VALUE_APPLE * GameData.insertedCoinsApple;
                        else if (GameData.typeCoin == 2) GameData.cantWinSilverCoinsApple += GameData.VALUE_APPLE * GameData.insertedCoinsApple;
                    }
                    else
                    {
                        GameData.cantLosApple++;
                        pct14.BackColor = Color.Red;
                        pctCancel.Visible = false;
                        AlertBox.Notify("¡No ganas nada!");
                    }
                    timerRoulette.Enabled = false;
                }
                luz13.BackgroundImage = Image.FromFile(lightOff);
                luz14.BackgroundImage = Image.FromFile(lightOn);
                GameData.lightTurn++;
                if (numOfLaps < 4 && numOfLaps > 1) timerRoulette.Interval += 3;
                else if (numOfLaps >= 3) timerRoulette.Interval += 20;
            }
            else if (GameData.lightTurn == 15)
            {
                if (numOfLaps == 4 && GameData.finallyWinPos == GameData.lightTurn - 1)
                {
                    GameData.cantNuevoTiro++;
                    pct15.BackColor = Color.Lime;
                    nuevoTiro = true;
                    AlertBox.Notify("¡Nuevo tiro!\nPresiona el botón ¡Girar ruleta!", true);
                    timerRoulette.Enabled = false;
                    pctCancel.Visible = false;
                }
                luz14.BackgroundImage = Image.FromFile(lightOff);
                luz15.BackgroundImage = Image.FromFile(lightOn);
                GameData.lightTurn++;
                if (numOfLaps < 4 && numOfLaps > 1) timerRoulette.Interval += 3;
                else if (numOfLaps >= 3) timerRoulette.Interval += 20;
            }
            else if (GameData.lightTurn == 16)
            {
                if (numOfLaps == 4 && GameData.finallyWinPos == GameData.lightTurn - 1)
                {
                    if (GameData.typeCoin == 1)
                    {
                        GameData.goldCoins += GameData.VALUE_PERA * GameData.insertedCoinsPera;
                        typeCoins = "oro";
                    }
                    else if (GameData.typeCoin == 2)
                    {
                        GameData.silverCoins += GameData.VALUE_PERA * GameData.insertedCoinsPera;
                        typeCoins = "plata";
                    }
                    if (GameData.VALUE_PERA * GameData.insertedCoinsPera > 0)
                    {
                        pct16.BackColor = Color.Lime;
                        AlertBox.Notify("¡Ganaste!\nRecompensa: " + GameData.VALUE_PERA * GameData.insertedCoinsPera + " fichas de " + typeCoins, true);
                        lblGoldCoins.Text = GameData.goldCoins.ToString();
                        lblSilverCoins.Text = GameData.silverCoins.ToString();
                        Winning = true;
                        pctCancel.Visible = false;
                        GameData.cantWinPera++;
                        if (GameData.typeCoin == 1) GameData.cantWinGoldCoinsPera += GameData.VALUE_PERA * GameData.insertedCoinsPera;
                        else if (GameData.typeCoin == 2) GameData.cantWinSilverCoinsPera += GameData.VALUE_PERA * GameData.insertedCoinsPera;
                    }
                    else
                    {
                        GameData.cantLosPera++;
                        pct16.BackColor = Color.Red;
                        pctCancel.Visible = false;
                        AlertBox.Notify("¡No ganas nada!");
                    }
                    timerRoulette.Enabled = false;
                }
                luz15.BackgroundImage = Image.FromFile(lightOff);
                luz16.BackgroundImage = Image.FromFile(lightOn);
                GameData.lightTurn++;
                if (numOfLaps < 4 && numOfLaps > 1) timerRoulette.Interval += 3;
                else if (numOfLaps >= 3) timerRoulette.Interval += 20;
            }
            else if (GameData.lightTurn == 17)
            {
                if (numOfLaps == 4 && GameData.finallyWinPos == GameData.lightTurn - 1)
                {
                    if (GameData.typeCoin == 1)
                    {
                        GameData.goldCoins += GameData.VALUE_CEREZA * GameData.insertedCoinsCereza;
                        typeCoins = "oro";
                    }
                    else if (GameData.typeCoin == 2)
                    {
                        GameData.silverCoins += GameData.VALUE_CEREZA * GameData.insertedCoinsCereza;
                        typeCoins = "plata";
                    }
                    if (GameData.VALUE_CEREZA * GameData.insertedCoinsCereza > 0)
                    {
                        pct17.BackColor = Color.Lime;
                        AlertBox.Notify("¡Ganaste!\nRecompensa: " + GameData.VALUE_CEREZA * GameData.insertedCoinsCereza + " fichas de " + typeCoins, true);
                        lblGoldCoins.Text = GameData.goldCoins.ToString();
                        lblSilverCoins.Text = GameData.silverCoins.ToString();
                        Winning = true;
                        pctCancel.Visible = false;
                        GameData.cantWinCereza++;
                        if (GameData.typeCoin == 1) GameData.cantWinGoldCoinsCereza += GameData.VALUE_CEREZA * GameData.insertedCoinsCereza;
                        else if (GameData.typeCoin == 2) GameData.cantWinSilverCoinsCereza += GameData.VALUE_CEREZA * GameData.insertedCoinsCereza;
                    }
                    else
                    {
                        GameData.cantLosCereza++;
                        pct17.BackColor = Color.Red;
                        pctCancel.Visible = false;
                        AlertBox.Notify("¡No ganas nada!");
                    }
                    timerRoulette.Enabled = false;
                }
                luz16.BackgroundImage = Image.FromFile(lightOff);
                luz17.BackgroundImage = Image.FromFile(lightOn);
                GameData.lightTurn++;
                if (numOfLaps < 4 && numOfLaps > 1) timerRoulette.Interval += 3;
                else if (numOfLaps >= 3) timerRoulette.Interval += 20;
            }
            else if (GameData.lightTurn == 18)
            {
                if (numOfLaps == 4 && GameData.finallyWinPos == GameData.lightTurn - 1)
                {
                    if (GameData.typeCoin == 1)
                    {
                        GameData.goldCoins += GameData.VALUE_BANANA * GameData.insertedCoinsBanana;
                        typeCoins = "oro";
                    }
                    else if (GameData.typeCoin == 2)
                    {
                        GameData.silverCoins += GameData.VALUE_BANANA * GameData.insertedCoinsBanana;
                        typeCoins = "plata";
                    }
                    if (GameData.VALUE_BANANA * GameData.insertedCoinsBanana > 0)
                    {
                        pct18.BackColor = Color.Lime;
                        AlertBox.Notify("¡Ganaste!\nRecompensa: " + GameData.VALUE_BANANA * GameData.insertedCoinsBanana + " fichas de " + typeCoins, true);
                        lblGoldCoins.Text = GameData.goldCoins.ToString();
                        lblSilverCoins.Text = GameData.silverCoins.ToString();
                        Winning = true;
                        pctCancel.Visible = false;
                        GameData.cantWinBanana++;
                        if (GameData.typeCoin == 1) GameData.cantWinGoldCoinsBanana += GameData.VALUE_BANANA * GameData.insertedCoinsBanana;
                        else if (GameData.typeCoin == 2) GameData.cantWinSilverCoinsBanana += GameData.VALUE_BANANA * GameData.insertedCoinsBanana;
                    }
                    else
                    {
                        GameData.cantLosBanana++;
                        pct18.BackColor = Color.Red;
                        pctCancel.Visible = false;
                        AlertBox.Notify("¡No ganas nada!");
                    }
                    timerRoulette.Enabled = false;
                }
                luz17.BackgroundImage = Image.FromFile(lightOff);
                luz18.BackgroundImage = Image.FromFile(lightOn);
                GameData.lightTurn++;
                if (numOfLaps < 4 && numOfLaps > 1) timerRoulette.Interval += 3;
                else if (numOfLaps >= 3) timerRoulette.Interval += 20;
            }
            else if (GameData.lightTurn == 19)
            {
                if (numOfLaps == 4 && GameData.finallyWinPos == GameData.lightTurn - 1)
                {
                    if (GameData.typeCoin == 1)
                    {
                        GameData.goldCoins += GameData.VALUE_ANANA * GameData.insertedCoinsAnana;
                        typeCoins = "oro";
                    }
                    else if (GameData.typeCoin == 2)
                    {
                        GameData.silverCoins += GameData.VALUE_ANANA * GameData.insertedCoinsAnana;
                        typeCoins = "plata";
                    }
                    if (GameData.VALUE_ANANA * GameData.insertedCoinsAnana > 0)
                    {
                        pct19.BackColor = Color.Lime;
                        AlertBox.Notify("¡Ganaste!\nRecompensa: " + GameData.VALUE_ANANA * GameData.insertedCoinsAnana + " fichas de " + typeCoins, true);
                        lblGoldCoins.Text = GameData.goldCoins.ToString();
                        lblSilverCoins.Text = GameData.silverCoins.ToString();
                        Winning = true;
                        pctCancel.Visible = false;
                        GameData.cantWinAnana++;
                        if (GameData.typeCoin == 1) GameData.cantWinGoldCoinsAnana += GameData.VALUE_ANANA * GameData.insertedCoinsAnana;
                        else if (GameData.typeCoin == 2) GameData.cantWinSilverCoinsAnana += GameData.VALUE_ANANA * GameData.insertedCoinsAnana;
                    }
                    else
                    {
                        GameData.cantLosAnana++;
                        pct19.BackColor = Color.Red;
                        pctCancel.Visible = false;
                        AlertBox.Notify("¡No ganas nada!");
                    }
                    timerRoulette.Enabled = false;
                }
                luz18.BackgroundImage = Image.FromFile(lightOff);
                luz19.BackgroundImage = Image.FromFile(lightOn);
                GameData.lightTurn++;
                if (numOfLaps < 4 && numOfLaps > 1) timerRoulette.Interval += 3;
                else if (numOfLaps >= 3) timerRoulette.Interval += 20;
            }
            else if (GameData.lightTurn == 20)
            {
                if (numOfLaps == 4 && GameData.finallyWinPos == GameData.lightTurn - 1)
                {
                    if (GameData.typeCoin == 1)
                    {
                        GameData.goldCoins += GameData.VALUE_APPLE * GameData.insertedCoinsApple;
                        typeCoins = "oro";
                    }
                    else if (GameData.typeCoin == 2)
                    {
                        GameData.silverCoins += GameData.VALUE_APPLE * GameData.insertedCoinsApple;
                        typeCoins = "plata";
                    }
                    if (GameData.VALUE_APPLE * GameData.insertedCoinsApple > 0)
                    {
                        pct20.BackColor = Color.Lime;
                        AlertBox.Notify("¡Ganaste!\nRecompensa: " + GameData.VALUE_APPLE * GameData.insertedCoinsApple + " fichas de " + typeCoins, true);
                        lblGoldCoins.Text = GameData.goldCoins.ToString();
                        lblSilverCoins.Text = GameData.silverCoins.ToString();
                        Winning = true;
                        pctCancel.Visible = false;
                        GameData.cantWinApple++;
                        if (GameData.typeCoin == 1) GameData.cantWinGoldCoinsApple += GameData.VALUE_APPLE * GameData.insertedCoinsApple;
                        else if (GameData.typeCoin == 2) GameData.cantWinSilverCoinsApple += GameData.VALUE_APPLE * GameData.insertedCoinsApple;
                    }
                    else
                    {
                        GameData.cantLosApple++;
                        pct20.BackColor = Color.Red;
                        pctCancel.Visible = false;
                        AlertBox.Notify("¡No ganas nada!");
                    }
                    timerRoulette.Enabled = false;
                }
                luz19.BackgroundImage = Image.FromFile(lightOff);
                luz20.BackgroundImage = Image.FromFile(lightOn);
                GameData.lightTurn++;
                if (numOfLaps < 4 && numOfLaps > 1) timerRoulette.Interval += 3;
                else if (numOfLaps >= 3) timerRoulette.Interval += 20;
            }
            else if (GameData.lightTurn == 21)
            {
                if (numOfLaps == 4 && GameData.finallyWinPos == GameData.lightTurn - 1)
                {
                    if (GameData.typeCoin == 1)
                    {
                        GameData.goldCoins += GameData.VALUE_CEREZA * GameData.insertedCoinsCereza;
                        typeCoins = "oro";
                    }
                    else if (GameData.typeCoin == 2)
                    {
                        GameData.silverCoins += GameData.VALUE_CEREZA * GameData.insertedCoinsCereza;
                        typeCoins = "plata";
                    }
                    if (GameData.VALUE_CEREZA * GameData.insertedCoinsCereza > 0)
                    {
                        pct21.BackColor = Color.Lime;
                        AlertBox.Notify("¡Ganaste!\nRecompensa: " + GameData.VALUE_CEREZA * GameData.insertedCoinsCereza + " fichas de " + typeCoins, true);
                        lblGoldCoins.Text = GameData.goldCoins.ToString();
                        lblSilverCoins.Text = GameData.silverCoins.ToString();
                        Winning = true;
                        pctCancel.Visible = false;
                        GameData.cantWinCereza++;
                        if (GameData.typeCoin == 1) GameData.cantWinGoldCoinsCereza += GameData.VALUE_CEREZA * GameData.insertedCoinsCereza;
                        else if (GameData.typeCoin == 2) GameData.cantWinSilverCoinsCereza += GameData.VALUE_CEREZA * GameData.insertedCoinsCereza;
                    }
                    else
                    {
                        GameData.cantLosCereza++;
                        pct21.BackColor = Color.Red;
                        pctCancel.Visible = false;
                        AlertBox.Notify("¡No ganas nada!");
                    }
                    timerRoulette.Enabled = false;
                }
                luz20.BackgroundImage = Image.FromFile(lightOff);
                luz21.BackgroundImage = Image.FromFile(lightOn);
                GameData.lightTurn++;
                if (numOfLaps < 4 && numOfLaps > 1) timerRoulette.Interval += 3;
                else if (numOfLaps >= 3) timerRoulette.Interval += 20;
            }
            else if (GameData.lightTurn == 22)
            {
                if (numOfLaps == 4 && GameData.finallyWinPos == GameData.lightTurn - 1)
                {
                    if (GameData.typeCoin == 1)
                    {
                        GameData.goldCoins += GameData.VALUE_ORANGE * GameData.insertedCoinsOrange;
                        typeCoins = "oro";
                    }
                    else if (GameData.typeCoin == 2)
                    {
                        GameData.silverCoins += GameData.VALUE_ORANGE * GameData.insertedCoinsOrange;
                        typeCoins = "plata";
                    }
                    if (GameData.VALUE_ORANGE * GameData.insertedCoinsOrange > 0)
                    {
                        pct22.BackColor = Color.Lime;
                        AlertBox.Notify("¡Ganaste!\nRecompensa: " + GameData.VALUE_ORANGE * GameData.insertedCoinsOrange + " fichas de " + typeCoins, true);
                        lblGoldCoins.Text = GameData.goldCoins.ToString();
                        lblSilverCoins.Text = GameData.silverCoins.ToString();
                        Winning = true;
                        pctCancel.Visible = false;
                        GameData.cantWinOrange++;
                        if (GameData.typeCoin == 1) GameData.cantWinGoldCoinsOrange += GameData.VALUE_ORANGE * GameData.insertedCoinsOrange;
                        else if (GameData.typeCoin == 2) GameData.cantWinSilverCoinsOrange += GameData.VALUE_ORANGE * GameData.insertedCoinsOrange;
                    }
                    else
                    {
                        GameData.cantLosOrange++;
                        pct22.BackColor = Color.Red;
                        pctCancel.Visible = false;
                        AlertBox.Notify("¡No ganas nada!");
                    }
                    timerRoulette.Enabled = false;
                }
                luz21.BackgroundImage = Image.FromFile(lightOff);
                luz22.BackgroundImage = Image.FromFile(lightOn);
                GameData.lightTurn++;
                if (numOfLaps < 4 && numOfLaps > 1) timerRoulette.Interval += 3;
                else if (numOfLaps >= 3) timerRoulette.Interval += 20;
            }
            else if (GameData.lightTurn == 23)
            {
                if (numOfLaps == 4 && GameData.finallyWinPos == GameData.lightTurn - 1)
                {
                    if (GameData.typeCoin == 1)
                    {
                        GameData.goldCoins += GameData.VALUE_STAR * GameData.insertedCoinsStar;
                        typeCoins = "oro";
                    }
                    else if (GameData.typeCoin == 2)
                    {
                        GameData.silverCoins += GameData.VALUE_STAR * GameData.insertedCoinsStar;
                        typeCoins = "plata";
                    }
                    if (GameData.VALUE_STAR * GameData.insertedCoinsStar > 0)
                    {
                        pct23.BackColor = Color.Lime;
                        AlertBox.Notify("¡Ganaste!\nRecompensa: " + GameData.VALUE_STAR * GameData.insertedCoinsStar + " fichas de " + typeCoins, true);
                        lblGoldCoins.Text = GameData.goldCoins.ToString();
                        lblSilverCoins.Text = GameData.silverCoins.ToString();
                        Winning = true;
                        pctCancel.Visible = false;
                        GameData.cantWinStar++;
                        if (GameData.typeCoin == 1) GameData.cantWinGoldCoinsStar += GameData.VALUE_STAR * GameData.insertedCoinsStar;
                        else if (GameData.typeCoin == 2) GameData.cantWinSilverCoinsStar += GameData.VALUE_STAR * GameData.insertedCoinsStar;
                    }
                    else
                    {
                        GameData.cantLosStar++;
                        pct23.BackColor = Color.Red;
                        pctCancel.Visible = false;
                        AlertBox.Notify("¡No ganas nada!");
                    }
                    timerRoulette.Enabled = false;
                }
                luz22.BackgroundImage = Image.FromFile(lightOff);
                luz23.BackgroundImage = Image.FromFile(lightOn);
                GameData.lightTurn++;
                if (numOfLaps < 4 && numOfLaps > 1) timerRoulette.Interval += 3;
                else if (numOfLaps >= 3) timerRoulette.Interval += 20;
            }
            else if (GameData.lightTurn == 24)
            {
                if (numOfLaps == 4 && GameData.finallyWinPos == GameData.lightTurn - 1)
                {
                    if (GameData.typeCoin == 1)
                    {
                        GameData.goldCoins += GameData.VALUE_APPLE * GameData.insertedCoinsApple;
                        typeCoins = "oro";
                    }
                    else if (GameData.typeCoin == 2)
                    {
                        GameData.silverCoins += GameData.VALUE_APPLE * GameData.insertedCoinsApple;
                        typeCoins = "plata";
                    }
                    if (GameData.VALUE_APPLE * GameData.insertedCoinsApple > 0)
                    {
                        pct24.BackColor = Color.Lime;
                        AlertBox.Notify("¡Ganaste!\nRecompensa: " + GameData.VALUE_APPLE * GameData.insertedCoinsApple + " fichas de " + typeCoins, true);
                        lblGoldCoins.Text = GameData.goldCoins.ToString();
                        lblSilverCoins.Text = GameData.silverCoins.ToString();
                        Winning = true;
                        GameData.cantWinApple++;
                        pctCancel.Visible = false;
                        if (GameData.typeCoin == 1) GameData.cantWinGoldCoinsApple += GameData.VALUE_APPLE * GameData.insertedCoinsApple;
                        else if (GameData.typeCoin == 2) GameData.cantWinSilverCoinsApple += GameData.VALUE_APPLE * GameData.insertedCoinsApple;
                    }
                    else
                    {
                        GameData.cantLosApple++;
                        pct24.BackColor = Color.Red;
                        pctCancel.Visible = false;
                        AlertBox.Notify("¡No ganas nada!");
                    }
                    timerRoulette.Enabled = false;
                }
                luz23.BackgroundImage = Image.FromFile(lightOff);
                luz24.BackgroundImage = Image.FromFile(lightOn);
                GameData.lightTurn++;
                if (numOfLaps < 4 && numOfLaps > 1) timerRoulette.Interval += 3;
                else if (numOfLaps >= 3) timerRoulette.Interval += 20;
            }
            else if (GameData.lightTurn == 25)
            {
                if (numOfLaps == 4 && GameData.finallyWinPos == GameData.lightTurn - 1)
                {
                    if (GameData.typeCoin == 1)
                    {
                        GameData.goldCoins += GameData.VALUE_PERA * GameData.insertedCoinsPera;
                        typeCoins = "oro";
                    }
                    else if (GameData.typeCoin == 2)
                    {
                        GameData.silverCoins += GameData.VALUE_PERA * GameData.insertedCoinsPera;
                        typeCoins = "plata";
                    }
                    if (GameData.VALUE_PERA * GameData.insertedCoinsPera > 0)
                    {
                        pct25.BackColor = Color.Lime;
                        AlertBox.Notify("¡Ganaste!\nRecompensa: " + GameData.VALUE_PERA * GameData.insertedCoinsPera + " fichas de " + typeCoins, true);
                        lblGoldCoins.Text = GameData.goldCoins.ToString();
                        lblSilverCoins.Text = GameData.silverCoins.ToString();
                        Winning = true;
                        pctCancel.Visible = false;
                        GameData.cantWinPera++;
                        if (GameData.typeCoin == 1) GameData.cantWinGoldCoinsPera += GameData.VALUE_PERA * GameData.insertedCoinsPera;
                        else if (GameData.typeCoin == 2) GameData.cantWinSilverCoinsPera += GameData.VALUE_PERA * GameData.insertedCoinsPera;
                    }
                    else
                    {
                        GameData.cantLosPera++;
                        pct25.BackColor = Color.Red;
                        pctCancel.Visible = false;
                        AlertBox.Notify("¡No ganas nada!");
                    }
                    timerRoulette.Enabled = false;
                }
                luz24.BackgroundImage = Image.FromFile(lightOff);
                luz25.BackgroundImage = Image.FromFile(lightOn);
                GameData.lightTurn++;
                if (numOfLaps < 4 && numOfLaps > 1) timerRoulette.Interval += 3;
                else if (numOfLaps >= 3) timerRoulette.Interval += 20;
            }
            else if (GameData.lightTurn == 26)
            {
                if (numOfLaps == 4 && GameData.finallyWinPos == GameData.lightTurn - 1)
                {
                    if (GameData.typeCoin == 1)
                    {
                        GameData.goldCoins += GameData.VALUE_CEREZA * GameData.insertedCoinsCereza;
                        typeCoins = "oro";
                    }
                    else if (GameData.typeCoin == 2)
                    {
                        GameData.silverCoins += GameData.VALUE_CEREZA * GameData.insertedCoinsCereza;
                        typeCoins = "plata";
                    }
                    if (GameData.VALUE_CEREZA * GameData.insertedCoinsCereza > 0)
                    {
                        pct26.BackColor = Color.Lime;
                        AlertBox.Notify("¡Ganaste!\nRecompensa: " + GameData.VALUE_CEREZA * GameData.insertedCoinsCereza + " fichas de " + typeCoins, true);
                        lblGoldCoins.Text = GameData.goldCoins.ToString();
                        lblSilverCoins.Text = GameData.silverCoins.ToString();
                        Winning = true;
                        pctCancel.Visible = false;
                        GameData.cantWinCereza++;
                        if (GameData.typeCoin == 1) GameData.cantWinGoldCoinsCereza += GameData.VALUE_CEREZA * GameData.insertedCoinsCereza;
                        else if (GameData.typeCoin == 2) GameData.cantWinSilverCoinsCereza += GameData.VALUE_CEREZA * GameData.insertedCoinsCereza;
                    }
                    else
                    {
                        GameData.cantLosCereza++;
                        pct26.BackColor = Color.Red;
                        pctCancel.Visible = false;
                        AlertBox.Notify("¡No ganas nada!");
                    }
                    timerRoulette.Enabled = false;
                }
                luz25.BackgroundImage = Image.FromFile(lightOff);
                luz26.BackgroundImage = Image.FromFile(lightOn);
                GameData.lightTurn++;
                if (numOfLaps < 4 && numOfLaps > 1) timerRoulette.Interval += 3;
                else if (numOfLaps >= 3) timerRoulette.Interval += 20;
            }
            else if (GameData.lightTurn == 27)
            {
                if (numOfLaps == 4 && GameData.finallyWinPos == GameData.lightTurn - 1)
                {
                    if (GameData.typeCoin == 1)
                    {
                        GameData.goldCoins += GameData.VALUE_ORANGE * GameData.insertedCoinsOrange;
                        typeCoins = "oro";
                    }
                    else if (GameData.typeCoin == 2)
                    {
                        GameData.silverCoins += GameData.VALUE_ORANGE * GameData.insertedCoinsOrange;
                        typeCoins = "plata";
                    }
                    if (GameData.VALUE_ORANGE * GameData.insertedCoinsOrange > 0)
                    {
                        pct27.BackColor = Color.Lime;
                        AlertBox.Notify("¡Ganaste!\nRecompensa: " + GameData.VALUE_ORANGE * GameData.insertedCoinsOrange + " fichas de " + typeCoins, true);
                        lblGoldCoins.Text = GameData.goldCoins.ToString();
                        lblSilverCoins.Text = GameData.silverCoins.ToString();
                        Winning = true;
                        pctCancel.Visible = false;
                        GameData.cantWinOrange++;
                        if (GameData.typeCoin == 1) GameData.cantWinGoldCoinsOrange += GameData.VALUE_ORANGE * GameData.insertedCoinsOrange;
                        else if (GameData.typeCoin == 2) GameData.cantWinSilverCoinsOrange += GameData.VALUE_ORANGE * GameData.insertedCoinsOrange;
                    }
                    else
                    {
                        GameData.cantLosOrange++;
                        pctCancel.Visible = false;
                        pct27.BackColor = Color.Red;
                        AlertBox.Notify("¡No ganas nada!");
                    }
                    timerRoulette.Enabled = false;
                }
                luz26.BackgroundImage = Image.FromFile(lightOff);
                luz27.BackgroundImage = Image.FromFile(lightOn);
                GameData.lightTurn++;
                if (numOfLaps < 4 && numOfLaps > 1) timerRoulette.Interval += 3;
                else if (numOfLaps >= 3) timerRoulette.Interval += 20;
            }
            else if (GameData.lightTurn == 28)
            {
                if (numOfLaps == 4 && GameData.finallyWinPos == GameData.lightTurn - 1)
                {
                    if (GameData.typeCoin == 1)
                    {
                        GameData.goldCoins += GameData.VALUE_ANANA * GameData.insertedCoinsAnana;
                        typeCoins = "oro";
                    }
                    else if (GameData.typeCoin == 2)
                    {
                        GameData.silverCoins += GameData.VALUE_ANANA * GameData.insertedCoinsAnana;
                        typeCoins = "plata";
                    }
                    if (GameData.VALUE_ANANA * GameData.insertedCoinsAnana > 0)
                    {
                        pct28.BackColor = Color.Lime;
                        AlertBox.Notify("¡Ganaste!\nRecompensa: " + GameData.VALUE_ANANA * GameData.insertedCoinsAnana + " fichas de " + typeCoins, true);
                        lblGoldCoins.Text = GameData.goldCoins.ToString();
                        lblSilverCoins.Text = GameData.silverCoins.ToString();
                        Winning = true;
                        pctCancel.Visible = false;
                        GameData.cantWinAnana++;
                        if (GameData.typeCoin == 1) GameData.cantWinGoldCoinsAnana += GameData.VALUE_ANANA * GameData.insertedCoinsAnana;
                        else if (GameData.typeCoin == 2) GameData.cantWinSilverCoinsAnana += GameData.VALUE_ANANA * GameData.insertedCoinsAnana;
                    }
                    else
                    {
                        GameData.cantLosAnana++;
                        pctCancel.Visible = false;
                        pct28.BackColor = Color.Red;
                        AlertBox.Notify("¡No ganas nada!");
                    }
                    timerRoulette.Enabled = false;
                }
                luz27.BackgroundImage = Image.FromFile(lightOff);
                luz28.BackgroundImage = Image.FromFile(lightOn);
                GameData.lightTurn++;
                if (numOfLaps < 4 && numOfLaps > 1) timerRoulette.Interval += 3;
                else if (numOfLaps >= 3) timerRoulette.Interval += 20;
            }
            else if (GameData.lightTurn == 29)
            {
                if (numOfLaps == 4 && GameData.finallyWinPos == GameData.lightTurn - 1)
                {
                    if (GameData.typeCoin == 1)
                    {
                        GameData.goldCoins += GameData.VALUE_PERA * GameData.insertedCoinsPera;
                        typeCoins = "oro";
                    }
                    else if (GameData.typeCoin == 2)
                    {
                        GameData.silverCoins += GameData.VALUE_PERA * GameData.insertedCoinsPera;
                        typeCoins = "plata";
                    }
                    if (GameData.VALUE_ANANA * GameData.insertedCoinsAnana > 0)
                    {
                        pct29.BackColor = Color.Lime;
                        AlertBox.Notify("¡Ganaste!\nRecompensa: " + GameData.VALUE_PERA * GameData.insertedCoinsPera + " fichas de " + typeCoins, true);
                        lblGoldCoins.Text = GameData.goldCoins.ToString();
                        lblSilverCoins.Text = GameData.silverCoins.ToString();
                        Winning = true;
                        pctCancel.Visible = false;
                        GameData.cantWinPera++;
                        if (GameData.typeCoin == 1) GameData.cantWinGoldCoinsPera += GameData.VALUE_PERA * GameData.insertedCoinsPera;
                        else if (GameData.typeCoin == 2) GameData.cantWinSilverCoinsPera += GameData.VALUE_PERA * GameData.insertedCoinsPera;
                    }
                    else
                    {
                        GameData.cantLosPera++;
                        pct29.BackColor = Color.Red;
                        pctCancel.Visible = false;
                        AlertBox.Notify("¡No ganas nada!");
                    }
                    timerRoulette.Enabled = false;
                }
                luz28.BackgroundImage = Image.FromFile(lightOff);
                luz29.BackgroundImage = Image.FromFile(lightOn);
                GameData.lightTurn++;
                if (numOfLaps < 4 && numOfLaps > 1) timerRoulette.Interval += 3;
                else if (numOfLaps >= 3) timerRoulette.Interval += 20;
            }
            else if (GameData.lightTurn == 30)
            {
                if (numOfLaps == 4 && GameData.finallyWinPos == GameData.lightTurn - 1)
                {
                    if (GameData.typeCoin == 1)
                    {
                        GameData.goldCoins += GameData.VALUE_CEREZA * GameData.insertedCoinsCereza;
                        typeCoins = "oro";
                    }
                    else if (GameData.typeCoin == 2)
                    {
                        GameData.silverCoins += GameData.VALUE_CEREZA * GameData.insertedCoinsCereza;
                        typeCoins = "plata";
                    }
                    if (GameData.VALUE_CEREZA * GameData.insertedCoinsCereza > 0)
                    {
                        pct30.BackColor = Color.Lime;
                        AlertBox.Notify("¡Ganaste!\nRecompensa: " + GameData.VALUE_CEREZA * GameData.insertedCoinsCereza + " fichas de " + typeCoins, true);
                        lblGoldCoins.Text = GameData.goldCoins.ToString();
                        lblSilverCoins.Text = GameData.silverCoins.ToString();
                        Winning = true;
                        pctCancel.Visible = false;
                        GameData.cantWinCereza++;
                        if (GameData.typeCoin == 1) GameData.cantWinGoldCoinsCereza += GameData.VALUE_CEREZA * GameData.insertedCoinsCereza;
                        else if (GameData.typeCoin == 2) GameData.cantWinSilverCoinsCereza += GameData.VALUE_CEREZA * GameData.insertedCoinsCereza;
                    }
                    else
                    {
                        GameData.cantLosCereza++;
                        pct30.BackColor = Color.Red;
                        pctCancel.Visible = false;
                        AlertBox.Notify("¡No ganas nada!");
                    }
                    timerRoulette.Enabled = false;
                }
                luz29.BackgroundImage = Image.FromFile(lightOff);
                luz30.BackgroundImage = Image.FromFile(lightOn);
                GameData.lightTurn++;
                if (numOfLaps < 4 && numOfLaps > 1) timerRoulette.Interval += 3;
                else if (numOfLaps >= 3) timerRoulette.Interval += 20;
            }
            else if (GameData.lightTurn == 31)
            {
                if (numOfLaps == 4 && GameData.finallyWinPos == GameData.lightTurn - 1)
                {
                    if (GameData.typeCoin == 1)
                    {
                        GameData.goldCoins += GameData.VALUE_BANANA * GameData.insertedCoinsBanana;
                        typeCoins = "oro";
                    }
                    else if (GameData.typeCoin == 2)
                    {
                        GameData.silverCoins += GameData.VALUE_BANANA * GameData.insertedCoinsBanana;
                        typeCoins = "plata";
                    }
                    if (GameData.VALUE_BANANA * GameData.insertedCoinsBanana > 0)
                    {
                        pct31.BackColor = Color.Lime;
                        AlertBox.Notify("¡Ganaste!\nRecompensa: " + GameData.VALUE_BANANA * GameData.insertedCoinsBanana + " fichas de " + typeCoins, true);
                        lblGoldCoins.Text = GameData.goldCoins.ToString();
                        lblSilverCoins.Text = GameData.silverCoins.ToString();
                        Winning = true;
                        pctCancel.Visible = false;
                        GameData.cantWinBanana++;
                        if (GameData.typeCoin == 1) GameData.cantWinGoldCoinsBanana += GameData.VALUE_BANANA * GameData.insertedCoinsBanana;
                        else if (GameData.typeCoin == 2) GameData.cantWinSilverCoinsBanana += GameData.VALUE_BANANA * GameData.insertedCoinsBanana;
                    }
                    else
                    {
                        GameData.cantLosBanana++;
                        pct31.BackColor = Color.Red;
                        pctCancel.Visible = false;
                        AlertBox.Notify("¡No ganas nada!");
                    }
                    timerRoulette.Enabled = false;
                }
                luz30.BackgroundImage = Image.FromFile(lightOff);
                luz31.BackgroundImage = Image.FromFile(lightOn);
                GameData.lightTurn++;
                if (numOfLaps < 4 && numOfLaps > 1) timerRoulette.Interval += 3;
                else if (numOfLaps >= 3) timerRoulette.Interval += 20;
            }
            else if (GameData.lightTurn == 32)
            {
                if (numOfLaps == 4 && GameData.finallyWinPos == GameData.lightTurn - 1)
                {
                    GameData.cantNuevoTiro++;
                    pct32.BackColor = Color.Lime;
                    nuevoTiro = true;
                    AlertBox.Notify("¡Nuevo tiro!\nPresiona el botón ¡Girar ruleta!", true);
                    timerRoulette.Enabled = false;
                    pctCancel.Visible = false;
                }
                luz31.BackgroundImage = Image.FromFile(lightOff);
                luz32.BackgroundImage = Image.FromFile(lightOn);
                GameData.lightTurn++;
                if (numOfLaps < 4 && numOfLaps > 1) timerRoulette.Interval += 3;
                else if (numOfLaps >= 3) timerRoulette.Interval += 20;
            }
            else if (GameData.lightTurn == 33)
            {
                if (numOfLaps == 4 && GameData.finallyWinPos == GameData.lightTurn - 1)
                {
                    if (GameData.typeCoin == 1)
                    {
                        GameData.goldCoins += GameData.VALUE_APPLE * GameData.insertedCoinsApple;
                        typeCoins = "oro";
                    }
                    else if (GameData.typeCoin == 2)
                    {
                        GameData.silverCoins += GameData.VALUE_APPLE * GameData.insertedCoinsApple;
                        typeCoins = "plata";
                    }
                    if (GameData.VALUE_APPLE * GameData.insertedCoinsApple > 0)
                    {
                        pct33.BackColor = Color.Lime;
                        AlertBox.Notify("¡Ganaste!\nRecompensa: " + GameData.VALUE_APPLE * GameData.insertedCoinsApple + " fichas de " + typeCoins, true);
                        lblGoldCoins.Text = GameData.goldCoins.ToString();
                        lblSilverCoins.Text = GameData.silverCoins.ToString();
                        Winning = true;
                        pctCancel.Visible = false;
                        GameData.cantWinApple++;
                        if (GameData.typeCoin == 1) GameData.cantWinGoldCoinsApple += GameData.VALUE_APPLE * GameData.insertedCoinsApple;
                        else if (GameData.typeCoin == 2) GameData.cantWinSilverCoinsApple += GameData.VALUE_APPLE * GameData.insertedCoinsApple;
                    }
                    else
                    {
                        GameData.cantLosApple++;
                        pct33.BackColor = Color.Red;
                        AlertBox.Notify("¡No ganas nada!");
                        pctCancel.Visible = false;
                    }
                    timerRoulette.Enabled = false;
                }
                luz32.BackgroundImage = Image.FromFile(lightOff);
                luz33.BackgroundImage = Image.FromFile(lightOn);
                GameData.lightTurn++;
                if (numOfLaps < 4 && numOfLaps > 1) timerRoulette.Interval += 3;
                else if (numOfLaps >= 3) timerRoulette.Interval += 20;
            }
            else if (GameData.lightTurn == 34)
            {
                if (numOfLaps == 4 && GameData.finallyWinPos == GameData.lightTurn - 1)
                {
                    if (GameData.typeCoin == 1)
                    {
                        GameData.goldCoins += GameData.VALUE_PERA * GameData.insertedCoinsPera;
                        typeCoins = "oro";
                    }
                    else if (GameData.typeCoin == 2)
                    {
                        GameData.silverCoins += GameData.VALUE_PERA * GameData.insertedCoinsPera;
                        typeCoins = "plata";
                    }
                    if (GameData.VALUE_PERA * GameData.insertedCoinsPera > 0)
                    {
                        pct34.BackColor = Color.Lime;
                        AlertBox.Notify("¡Ganaste!\nRecompensa: " + GameData.VALUE_PERA * GameData.insertedCoinsPera + " fichas de " + typeCoins, true);
                        lblGoldCoins.Text = GameData.goldCoins.ToString();
                        lblSilverCoins.Text = GameData.silverCoins.ToString();
                        Winning = true;
                        GameData.cantWinPera++;
                        pctCancel.Visible = false;
                        if (GameData.typeCoin == 1) GameData.cantWinGoldCoinsPera += GameData.VALUE_PERA * GameData.insertedCoinsPera;
                        else if (GameData.typeCoin == 2) GameData.cantWinSilverCoinsPera += GameData.VALUE_PERA * GameData.insertedCoinsPera;
                    }
                    else
                    {
                        GameData.cantLosPera++;
                        pct34.BackColor = Color.Red;
                        AlertBox.Notify("¡No ganas nada!");
                        pctCancel.Visible = false;
                    }
                    timerRoulette.Enabled = false;
                }
                luz33.BackgroundImage = Image.FromFile(lightOff);
                luz34.BackgroundImage = Image.FromFile(lightOn);
                GameData.lightTurn++;
                if (numOfLaps < 4 && numOfLaps > 1) timerRoulette.Interval += 3;
                else if (numOfLaps >= 3) timerRoulette.Interval += 20;
            }
            else if (GameData.lightTurn == 35)
            {
                if (numOfLaps == 4 && GameData.finallyWinPos == GameData.lightTurn - 1)
                {
                    if (GameData.typeCoin == 1)
                    {
                        GameData.goldCoins += GameData.VALUE_CEREZA * GameData.insertedCoinsCereza;
                        typeCoins = "oro";
                    }
                    else if (GameData.typeCoin == 2)
                    {
                        GameData.silverCoins += GameData.VALUE_CEREZA * GameData.insertedCoinsCereza;
                        typeCoins = "plata";
                    }
                    if (GameData.VALUE_CEREZA * GameData.insertedCoinsCereza > 0)
                    {
                        pct35.BackColor = Color.Lime;
                        AlertBox.Notify("¡Ganaste!\nRecompensa: " + GameData.VALUE_CEREZA * GameData.insertedCoinsCereza + " fichas de " + typeCoins, true);
                        lblGoldCoins.Text = GameData.goldCoins.ToString();
                        lblSilverCoins.Text = GameData.silverCoins.ToString();
                        Winning = true;
                        pctCancel.Visible = false;
                        GameData.cantWinCereza++;
                        if (GameData.typeCoin == 1) GameData.cantWinGoldCoinsCereza += GameData.VALUE_CEREZA * GameData.insertedCoinsCereza;
                        else if (GameData.typeCoin == 2) GameData.cantWinSilverCoinsCereza += GameData.VALUE_CEREZA * GameData.insertedCoinsCereza;
                    }
                    else
                    {
                        GameData.cantLosCereza++;
                        pct35.BackColor = Color.Red;
                        AlertBox.Notify("¡No ganas nada!");
                        pctCancel.Visible = false;
                    }
                    timerRoulette.Enabled = false;
                }
                luz34.BackgroundImage = Image.FromFile(lightOff);
                luz35.BackgroundImage = Image.FromFile(lightOn);
                GameData.lightTurn++;
                if (numOfLaps < 4 && numOfLaps > 1) timerRoulette.Interval += 3;
                else if (numOfLaps >= 3) timerRoulette.Interval += 20;
            }
            else if (GameData.lightTurn == 36)
            {
                if (numOfLaps < 4 && numOfLaps > 1) timerRoulette.Interval += 3;
                if (numOfLaps == 4 && GameData.finallyWinPos == GameData.lightTurn - 1)
                {
                    if (GameData.typeCoin == 1)
                    {
                        GameData.goldCoins += GameData.VALUE_APPLE * GameData.insertedCoinsApple;
                        typeCoins = "oro";
                    }
                    else if (GameData.typeCoin == 2)
                    {
                        GameData.silverCoins += GameData.VALUE_APPLE * GameData.insertedCoinsApple;
                        typeCoins = "plata";
                    }
                    if (GameData.VALUE_APPLE * GameData.insertedCoinsApple > 0)
                    {
                        pct36.BackColor = Color.Lime;
                        AlertBox.Notify("¡Ganaste!\nRecompensa: " + GameData.VALUE_APPLE * GameData.insertedCoinsApple + " fichas de " + typeCoins, true);
                        lblGoldCoins.Text = GameData.goldCoins.ToString();
                        lblSilverCoins.Text = GameData.silverCoins.ToString();
                        Winning = true;
                        pctCancel.Visible = false;
                        GameData.cantWinApple++;
                        if (GameData.typeCoin == 1) GameData.cantWinGoldCoinsApple += GameData.VALUE_APPLE * GameData.insertedCoinsApple;
                        else if (GameData.typeCoin == 2) GameData.cantWinSilverCoinsApple += GameData.VALUE_APPLE * GameData.insertedCoinsApple;
                    }
                    else
                    {
                        GameData.cantLosApple++;
                        pct36.BackColor = Color.Red;
                        pctCancel.Visible = false;
                        AlertBox.Notify("¡No ganas nada!");
                    }
                    timerRoulette.Enabled = false;
                }
                luz35.BackgroundImage = Image.FromFile(lightOff);
                luz36.BackgroundImage = Image.FromFile(lightOn);
                GameData.lightTurn = 1;
                numOfLaps++;
                if (numOfLaps < 4 && numOfLaps > 1) timerRoulette.Interval += 3;
                else if (numOfLaps >= 3) timerRoulette.Interval += 20;
            }
        }

        private void timerUpdate_Tick(object sender, EventArgs e)
        {
            lblHour.Text = FixTime(DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second);
            lblGoldCoins.Text = GameData.goldCoins.ToString();
            lblSilverCoins.Text = GameData.silverCoins.ToString();
            lblMoney.Text = "$" + GameData.money.ToString();
            if ((GameData.insertedCoinsCereza + GameData.insertedCoinsApple + GameData.insertedCoinsOrange + GameData.insertedCoinsPera + GameData.insertedCoinsAnana + GameData.insertedCoinsBanana + GameData.insertedCoinsStar + GameData.insertedCoinsBAR50 + GameData.insertedCoinsBAR100) > 0)
            {
                lblBetNone.Visible = false;
                if (GameData.insertedCoinsCereza > 0)
                {
                    pctBetCereza.Visible = true;
                    lblinsertedCoinsCereza.Visible = true;
                    lblinsertedCoinsCereza.Text = GameData.insertedCoinsCereza + "  (" + GameData.VALUE_CEREZA * GameData.insertedCoinsCereza + ")";
                    if (GameData.insertedCoinsCereza >= 2) lblinsertedCoinsCereza.ForeColor = Color.ForestGreen;
                    else lblinsertedCoinsCereza.ForeColor = Color.Black;
                }
                else pctBetCereza.Visible = lblinsertedCoinsCereza.Visible = false;
                if (GameData.insertedCoinsApple > 0)
                {
                    pctBetApple.Visible = true;
                    lblinsertedCoinsApple.Visible = true;
                    lblinsertedCoinsApple.Text = GameData.insertedCoinsApple + "  (" + GameData.VALUE_APPLE * GameData.insertedCoinsApple + ")";
                    if (GameData.insertedCoinsApple >= 2) lblinsertedCoinsApple.ForeColor = Color.ForestGreen;
                    else lblinsertedCoinsApple.ForeColor = Color.Black;
                }
                else pctBetApple.Visible = lblinsertedCoinsApple.Visible = false;
                if (GameData.insertedCoinsOrange > 0)
                {
                    pctBetOrange.Visible = true;
                    lblinsertedCoinsOrange.Visible = true;
                    lblinsertedCoinsOrange.Text = GameData.insertedCoinsOrange + "  (" + GameData.VALUE_ORANGE * GameData.insertedCoinsOrange + ")";
                    if (GameData.insertedCoinsOrange >= 2) lblinsertedCoinsOrange.ForeColor = Color.ForestGreen;
                    else lblinsertedCoinsOrange.ForeColor = Color.Black;
                }
                else pctBetOrange.Visible = lblinsertedCoinsOrange.Visible = false;
                if (GameData.insertedCoinsPera > 0)
                {
                    pctBetPera.Visible = true;
                    lblinsertedCoinsPera.Visible = true;
                    lblinsertedCoinsPera.Text = GameData.insertedCoinsPera + "  (" + GameData.VALUE_PERA * GameData.insertedCoinsPera + ")";
                    if (GameData.insertedCoinsPera >= 2) lblinsertedCoinsPera.ForeColor = Color.ForestGreen;
                    else lblinsertedCoinsPera.ForeColor = Color.Black;
                }
                else pctBetPera.Visible = lblinsertedCoinsPera.Visible = false;
                if (GameData.insertedCoinsAnana > 0)
                {
                    pctBetAnana.Visible = true;
                    lblinsertedCoinsAnana.Visible = true;
                    lblinsertedCoinsAnana.Text = GameData.insertedCoinsAnana + "  (" + GameData.VALUE_ANANA * GameData.insertedCoinsAnana + ")";
                    if (GameData.insertedCoinsAnana >= 2) lblinsertedCoinsAnana.ForeColor = Color.ForestGreen;
                    else lblinsertedCoinsAnana.ForeColor = Color.Black;
                }
                else pctBetAnana.Visible = lblinsertedCoinsAnana.Visible = false;
                if (GameData.insertedCoinsBanana > 0)
                {
                    pctBetBanana.Visible = true;
                    lblinsertedCoinsBanana.Visible = true;
                    lblinsertedCoinsBanana.Text = GameData.insertedCoinsBanana + "  (" + GameData.VALUE_BANANA * GameData.insertedCoinsBanana + ")";
                    if (GameData.insertedCoinsBanana >= 2) lblinsertedCoinsBanana.ForeColor = Color.ForestGreen;
                    else lblinsertedCoinsBanana.ForeColor = Color.Black;
                }
                else pctBetBanana.Visible = lblinsertedCoinsBanana.Visible = false;
                if (GameData.insertedCoinsStar > 0)
                {
                    pctBetStar.Visible = true;
                    lblinsertedCoinsStar.Visible = true;
                    lblinsertedCoinsStar.Text = GameData.insertedCoinsStar + "  (" + GameData.VALUE_STAR * GameData.insertedCoinsStar + ")";
                    if (GameData.insertedCoinsStar >= 2) lblinsertedCoinsStar.ForeColor = Color.ForestGreen;
                    else lblinsertedCoinsStar.ForeColor = Color.Black;
                }
                else pctBetStar.Visible = lblinsertedCoinsStar.Visible = false;
                if (GameData.insertedCoinsBAR50 > 0)
                {
                    pctBetBAR50.Visible = true;
                    lblBetBAR50.Visible = true;
                    lblinsertedCoinsBAR50.Visible = true;
                    lblinsertedCoinsBAR50.Text = GameData.insertedCoinsBAR50 + "  (" + GameData.VALUE_BAR50 * GameData.insertedCoinsBAR50 + ")";
                    if (GameData.insertedCoinsBAR50 >= 2) lblinsertedCoinsBAR50.ForeColor = Color.ForestGreen;
                    else lblinsertedCoinsBAR50.ForeColor = Color.Black;
                }
                else pctBetBAR50.Visible = lblBetBAR50.Visible = lblinsertedCoinsBAR50.Visible = false;
                if (GameData.insertedCoinsBAR100 > 0)
                {
                    pctBetBAR100.Visible = true;
                    lblBetBAR100.Visible = true;
                    lblinsertedCoinsBAR100.Visible = true;
                    lblinsertedCoinsBAR100.Text = GameData.insertedCoinsBAR100 + "  (" + GameData.VALUE_BAR100 * GameData.insertedCoinsBAR100 + ")";
                    if (GameData.insertedCoinsBAR100 >= 2) lblinsertedCoinsBAR100.ForeColor = Color.ForestGreen;
                    else lblinsertedCoinsBAR100.ForeColor = Color.Black;

                }
                else pctBetBAR100.Visible = lblBetBAR100.Visible = lblinsertedCoinsBAR100.Visible = false;
            }
            else
            {
                lblBetNone.Visible = true;
                pctBetCereza.Visible = pctBetApple.Visible = pctBetOrange.Visible = pctBetPera.Visible = pctBetAnana.Visible = pctBetBanana.Visible = pctBetStar.Visible = pctBetBAR50.Visible = pctBetBAR100.Visible = lblBetBAR100.Visible = lblBetBAR50.Visible = false;
                lblinsertedCoinsCereza.Visible = lblinsertedCoinsApple.Visible = lblinsertedCoinsPera.Visible = lblinsertedCoinsOrange.Visible = lblinsertedCoinsAnana.Visible = lblinsertedCoinsBanana.Visible = lblinsertedCoinsStar.Visible = lblinsertedCoinsBAR50.Visible = lblinsertedCoinsBAR100.Visible = false;
            }
            if (Winning == true)
            {
                if (countWinTimes < 50)
                {
                    countWinTimes++;
                    if (pct1.BackColor == Color.White) pct1.BackColor = Color.Lime;
                    else pct1.BackColor = Color.White;
                    if (pct2.BackColor == Color.White) pct2.BackColor = Color.Lime;
                    else pct2.BackColor = Color.White;
                    if (pct3.BackColor == Color.White) pct3.BackColor = Color.Lime;
                    else pct3.BackColor = Color.White;
                    if (pct4.BackColor == Color.White) pct4.BackColor = Color.Lime;
                    else pct4.BackColor = Color.White;
                    if (pct5.BackColor == Color.White) pct5.BackColor = Color.Lime;
                    else pct5.BackColor = Color.White;
                    if (pct6.BackColor == Color.White) pct6.BackColor = Color.Lime;
                    else pct6.BackColor = Color.White;
                    if (pct7.BackColor == Color.White) pct7.BackColor = Color.Lime;
                    else pct7.BackColor = Color.White;
                    if (pct8.BackColor == Color.White) pct8.BackColor = Color.Lime;
                    else pct8.BackColor = Color.White;
                    if (pct9.BackColor == Color.White) pct9.BackColor = Color.Lime;
                    else pct9.BackColor = Color.White;
                    if (pct10.BackColor == Color.White) pct10.BackColor = Color.Lime;
                    else pct10.BackColor = Color.White;
                    if (pct11.BackColor == Color.White) pct11.BackColor = Color.Lime;
                    else pct11.BackColor = Color.White;
                    if (pct12.BackColor == Color.White) pct12.BackColor = Color.Lime;
                    else pct12.BackColor = Color.White;
                    if (pct13.BackColor == Color.White) pct13.BackColor = Color.Lime;
                    else pct13.BackColor = Color.White;
                    if (pct14.BackColor == Color.White) pct14.BackColor = Color.Lime;
                    else pct14.BackColor = Color.White;
                    if (pct15.BackColor == Color.White) pct15.BackColor = Color.Lime;
                    else pct15.BackColor = Color.White;
                    if (pct16.BackColor == Color.White) pct16.BackColor = Color.Lime;
                    else pct16.BackColor = Color.White;
                    if (pct17.BackColor == Color.White) pct17.BackColor = Color.Lime;
                    else pct17.BackColor = Color.White;
                    if (pct18.BackColor == Color.White) pct18.BackColor = Color.Lime;
                    else pct18.BackColor = Color.White;
                    if (pct19.BackColor == Color.White) pct19.BackColor = Color.Lime;
                    else pct19.BackColor = Color.White;
                    if (pct20.BackColor == Color.White) pct20.BackColor = Color.Lime;
                    else pct20.BackColor = Color.White;
                    if (pct21.BackColor == Color.White) pct21.BackColor = Color.Lime;
                    else pct21.BackColor = Color.White;
                    if (pct22.BackColor == Color.White) pct22.BackColor = Color.Lime;
                    else pct22.BackColor = Color.White;
                    if (pct23.BackColor == Color.White) pct23.BackColor = Color.Lime;
                    else pct23.BackColor = Color.White;
                    if (pct24.BackColor == Color.White) pct24.BackColor = Color.Lime;
                    else pct24.BackColor = Color.White;
                    if (pct25.BackColor == Color.White) pct25.BackColor = Color.Lime;
                    else pct25.BackColor = Color.White;
                    if (pct26.BackColor == Color.White) pct26.BackColor = Color.Lime;
                    else pct26.BackColor = Color.White;
                    if (pct27.BackColor == Color.White) pct27.BackColor = Color.Lime;
                    else pct27.BackColor = Color.White;
                    if (pct28.BackColor == Color.White) pct28.BackColor = Color.Lime;
                    else pct28.BackColor = Color.White;
                    if (pct29.BackColor == Color.White) pct29.BackColor = Color.Lime;
                    else pct29.BackColor = Color.White;
                    if (pct30.BackColor == Color.White) pct30.BackColor = Color.Lime;
                    else pct30.BackColor = Color.White;
                    if (pct31.BackColor == Color.White) pct31.BackColor = Color.Lime;
                    else pct31.BackColor = Color.White;
                    if (pct32.BackColor == Color.White) pct32.BackColor = Color.Lime;
                    else pct32.BackColor = Color.White;
                    if (pct33.BackColor == Color.White) pct33.BackColor = Color.Lime;
                    else pct33.BackColor = Color.White;
                    if (pct34.BackColor == Color.White) pct34.BackColor = Color.Lime;
                    else pct34.BackColor = Color.White;
                    if (pct35.BackColor == Color.White) pct35.BackColor = Color.Lime;
                    else pct35.BackColor = Color.White;
                    if (pct36.BackColor == Color.White) pct36.BackColor = Color.Lime;
                    else pct36.BackColor = Color.White;
                }
                else 
                {
                    pct4.BackColor = Color.Gold;
                    pct7.BackColor = Color.Goldenrod;
                    pct32.BackColor = pct15.BackColor = Color.DodgerBlue;
                    pct30.BackColor = Color.White;
                }
            }
        }

        private void pctSellCoins_Click(object sender, EventArgs e)
        {
            frmBuyCoins FormBuyCoins = new frmBuyCoins();
            FormBuyCoins.lblMoney.Text = "$" + GameData.money.ToString();
            FormBuyCoins.lblGoldCoins.Text = GameData.goldCoins.ToString();
            FormBuyCoins.lblSilverCoins.Text = GameData.silverCoins.ToString();
            FormMode.Mode = "sell";
            if (FormMode.Mode == "buy") FormBuyCoins.pctBuyCoins.BackgroundImage = Image.FromFile(Lib.path + "ComprarFichas.png");
            else FormBuyCoins.pctBuyCoins.BackgroundImage = Image.FromFile(Lib.path + "VenderFichas.png");
            FormBuyCoins.Show();
            FormBuyCoins = null;
        }

        private void pctSellCoins_MouseEnter(object sender, EventArgs e)
        {
            pctSellCoins.BackColor = Color.Gold;
        }

        private void pctSellCoins_MouseLeave(object sender, EventArgs e)
        {
            pctSellCoins.BackColor = Color.White;
        }

        private void pctHelp_Click(object sender, EventArgs e)
        {
            frmHelp FormHelp = new frmHelp();
            FormHelp.Show();
            FormHelp = null;
        }

        private void pctHelp_MouseEnter(object sender, EventArgs e)
        {
            pctHelp.BackColor = Color.LightBlue;
        }

        private void pctHelp_MouseLeave(object sender, EventArgs e)
        {
            pctHelp.BackColor = Color.White;
        }

        private void pctSave_Click(object sender, EventArgs e)
        {
            AlertBox.Notify("Guardando partida...", true, "blue");
            //OleDbCommand cmd = new OleDbCommand();
            //cmd.CommandText = "UPDATE tblAcccount SET NameAccount='" + GameData.nameAccount + "', Money=" + GameData.money + ", GoldCoins=" + GameData.goldCoins + ", SilverCoins=" + GameData.silverCoins + ", cantNuevoTiro=" + GameData.cantNuevoTiro + ", cantWinCereza=" + GameData.cantWinCereza + ", cantWinApple=" + GameData.cantWinApple + ", cantWinOrange=" + GameData.cantWinOrange + ", cantWinPera=" + GameData.cantWinPera + ", cantWinAnana=" + GameData.cantWinAnana + ", cantWinBanana=" + GameData.cantWinBanana + ", cantWinStar=" + GameData.cantWinStar + ", cantWinBAR50=" + GameData.cantWinBAR50 + ", cantWinBAR100=" + GameData.cantWinBAR100 + ", cantLosCereza=" + GameData.cantLosCereza + ", cantLosApple=" + GameData.cantLosApple + ", cantLosOrange=" + GameData.cantLosOrange + ", cantLosPera=" + GameData.cantLosPera + ", cantLosAnana=" + GameData.cantLosAnana + ", cantLosBanana=" + GameData.cantLosBanana + ", cantLosStar=" + GameData.cantLosStar + ", cantLosBAR50=" + GameData.cantLosBAR50 + ", cantLosBAR100=" + GameData.cantLosBAR100 + ", cantWinGoldCoinsCereza=" + GameData.cantWinGoldCoinsCereza + ", cantWinGoldCoinsApple=" + GameData.cantWinGoldCoinsApple + ", cantWinGoldCoinsOrange=" + GameData.cantWinGoldCoinsOrange + ", cantWinGoldCoinsPera=" + GameData.cantWinGoldCoinsPera + ", cantWinGoldCoinsAnana=" + GameData.cantWinGoldCoinsAnana + ", cantWinGoldCoinsBanana=" + GameData.cantWinGoldCoinsBanana + ", cantWinGoldCoinsStar=" + GameData.cantWinGoldCoinsStar + ", cantWinGoldCoinsBAR50=" + GameData.cantWinGoldCoinsBAR50 + ", cantWinGoldCoinsBAR100=" + GameData.cantWinGoldCoinsBAR100 + ", cantWinSilverCoinsCereza=" + GameData.cantWinSilverCoinsCereza + ", cantWinSilverCoinsApple=" + GameData.cantWinSilverCoinsApple + ", cantWinSilverCoinsOrange=" + GameData.cantWinSilverCoinsOrange + ", cantWinSilverCoinsPera=" + GameData.cantWinSilverCoinsPera + ", cantWinSilverCoinsAnana=" + GameData.cantWinSilverCoinsAnana + ", cantWinSilverCoinsBanana=" + GameData.cantWinSilverCoinsBanana + ", cantWinSilverCoinsStar=" + GameData.cantWinSilverCoinsStar + ", cantWinSilverCoinsBAR50=" + GameData.cantWinSilverCoinsBAR50 + ", cantWinSilverCoinsBAR100=" + GameData.cantWinSilverCoinsBAR100;
            //cmd.ExecuteNonQuery();
            //cmd = null;
            AlertBox.Notify("¡Partida guardada con éxito!", true);
        }

        private void pctSave_MouseEnter(object sender, EventArgs e)
        {
            pctSave.BackColor = Color.PaleTurquoise;
        }

        private void pctSave_MouseLeave(object sender, EventArgs e)
        {
            pctSave.BackColor = Color.White;
        }

        private void pctEstadisticas_Click(object sender, EventArgs e)
        {
            frmEstadisticas FormEstadisticas = new frmEstadisticas();
            FormEstadisticas.Show();
            FormEstadisticas = null;
        }

        private void pctEstadisticas_MouseEnter(object sender, EventArgs e)
        {
            pctEstadisticas.BackColor = Color.LightSalmon;
        }

        private void pctEstadisticas_MouseLeave(object sender, EventArgs e)
        {
            pctEstadisticas.BackColor = Color.White;
        }

        private void pctCancel_Click(object sender, EventArgs e)
        {
            pctCancel.Visible = false;
            AlertBox.Notify("Tiro cancelado");
            timerRoulette.Stop();
        }

        private void pctCancel_MouseEnter(object sender, EventArgs e)
        {
            pctCancel.BackColor = Color.LightCoral;
        }

        private void pctCancel_MouseLeave(object sender, EventArgs e)
        {
            pctCancel.BackColor = Color.White;
        }
    } 
}
