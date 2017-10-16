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
    public partial class frmHelp : Form
    {
        int step = 0;

        public frmHelp()
        {
            InitializeComponent();
        }

        private void pctClose_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void pctCancel_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void pctAccept_Click(object sender, EventArgs e)
        {
            if (step < 5) step++;
            else step = 1;
            lblSteps.Text = step + "/5";
            if (step == 1)
            {
                lblTitle.Text = "INTRODUCCIÓN";
                lblText.Text = "Bienvenido, " + GameData.nameAccount + "\nGracias por jugar a La manzanita, esperemos que el juego sea de su agrado. Ahora procederemos a brindarle toda la información necesaria para que pueda jugar al juego sin ninguna duda ni problema.\nEl objetivo del juego es como el de una ruleta, apostar y ganar. El dinero sirve para comprar fichas de oro o de plata (ya explicaremos posteriormente sus diferencias), con ellas podrás apostar en la ruleta para así poder ganar más fichas. Para continuar con cada concepto detallado del juego presiona el botón 'siguiente' o para salir del tutorial presiona el botón 'cancelar'.";
            }
            else if (step == 2)
            {
                lblTitle.Text = "EL DINERO";
                lblText.Text = "El dinero sirve para comprar fichas como lo mencionamos anteriormente, puedes ganar dinero presionando el botón 'ganar dinero' el cual te dará preguntas, cuentas matemáticas o lo que sea para que puedas ganar dinero. Cada pregunta o problema tiene su recompensa por contestarla correctamente, puedes acceder a este botón 3 veces por girada de ruleta, cuando gires la ruleta podrás usarlo sólamente 3 veces hasta que vuelvas a girar, el costo de usar este botón es de $2.";
            }
            else if (step == 3)
            {
                lblTitle.Text = "LAS FICHAS";
                lblText.Text = "Como ya vimos, tenemos 2 tipos de fichas, las de plata que son más baratas pero tendrás menos probabilidades de sacarte las frutas o casilleros más altos en la ruleta pero con menos probabilidades no decimos imposible, y también tenemos las de oro que aumentarán tus probabilidades de sacarte casilleros más altos en la ruleta. Si apuestas fichas de oro, ganarás fichas de oro y si apuestas fichas de plata, ganarás de plata. Las fichas si necesitas dinero puedes venderlas, pero ten en cuenta que las venderás a la mitad de precio, las fichas de oro valen $4 c/u y las de plata $2 c/u.";
            }
            else if (step == 4)
            {
                lblTitle.Text = "LA APUESTA";
                lblText.Text = "Cuando ya estés listo para girar la ruleta presionas el botón 'Probar suerte', si no has apostado aún te saldrá el panel de apuestas en el cuál te dará a escoger a qué casillero apostar y cuántas fichas apostar a qué casillero. Puedes apostar más de 1 ficha a un casillero y su recompensa se multiplicará por la cantidad de fichas que hayas puesto, si yo apuesto 4 fichas a la pera y su recompensa normal es de 10 entonces su recompensa pasará a ser de 40 por el hecho de haber apostado 4 fichas a la misma fruta. También en el panel podrás obvservar las probabilidades que tiene cada casillero de salir en ese turno, hay 4 colores que te lo indicarán.";
            }
            else if (step == 5)
            {
                lblTitle.Text = "¿CÓMO EMPEZAR A APOSTAR?";
                lblText.Text = "Es fácil, si ya has comprado fichas, presiona en las fichas que quieres apostar y se te cambiará el cursor por la ficha seleccionada, luego llevala hasta el tragamonedas y has clic sobre él para poner la ficha, una vez puesta no hay vuelta atrás, ya está apostada. Recuerda que puedes poner más de una ficha para apostar a varios casilleros o varios a un casillero.";
            }
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

        private void frmHelp_Load(object sender, EventArgs e)
        {
            this.Cursor = AdvancedCursors.Create(Path.Combine(Application.StartupPath, Lib.path + "cursor.ani"));
            step = 1;
            lblSteps.Text = "1/5";
            lblTitle.Text = "INTRODUCCIÓN";
            lblText.Text = "Bienvenido, " + GameData.nameAccount + "\nGracias por jugar a La manzanita, esperemos que el juego sea de su agrado. Ahora procederemos a brindarle toda la información necesaria para que pueda jugar al juego sin ninguna duda ni problema.\nEl objetivo del juego es como el de una ruleta, apostar y ganar. El dinero sirve para comprar fichas de oro o de plata (ya explicaremos posteriormente sus diferencias), con ellas podrás apostar en la ruleta para así poder ganar más fichas. Para continuar con cada concepto detallado del juego presiona el botón 'siguiente' o para salir del tutorial presiona el botón 'cancelar'.";
        }
    }
}
