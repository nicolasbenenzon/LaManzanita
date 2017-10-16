namespace Manzanita
{
    partial class frmLoading
    {
        /// <summary>
        /// Variable del diseñador requerida.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén utilizando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben eliminar; false en caso contrario, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido del método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmLoading));
            this.timerParpSkip = new System.Windows.Forms.Timer(this.components);
            this.lblSkip = new System.Windows.Forms.Label();
            this.pctManzana = new System.Windows.Forms.PictureBox();
            this.pctNaranja = new System.Windows.Forms.PictureBox();
            this.pctPera = new System.Windows.Forms.PictureBox();
            this.pctText = new System.Windows.Forms.PictureBox();
            this.timerAnimation = new System.Windows.Forms.Timer(this.components);
            this.timerShading = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pctManzana)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctNaranja)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctPera)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctText)).BeginInit();
            this.SuspendLayout();
            // 
            // timerParpSkip
            // 
            this.timerParpSkip.Interval = 780;
            this.timerParpSkip.Tick += new System.EventHandler(this.timerParpSkip_Tick);
            // 
            // lblSkip
            // 
            this.lblSkip.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblSkip.Font = new System.Drawing.Font("Segoe Print", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSkip.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblSkip.Location = new System.Drawing.Point(12, 565);
            this.lblSkip.Name = "lblSkip";
            this.lblSkip.Size = new System.Drawing.Size(975, 64);
            this.lblSkip.TabIndex = 4;
            this.lblSkip.Text = "Pulse INTRO para continuar";
            this.lblSkip.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblSkip.Visible = false;
            // 
            // pctManzana
            // 
            this.pctManzana.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pctManzana.BackColor = System.Drawing.Color.LightPink;
            this.pctManzana.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pctManzana.BackgroundImage")));
            this.pctManzana.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pctManzana.Location = new System.Drawing.Point(332, 49);
            this.pctManzana.Margin = new System.Windows.Forms.Padding(0);
            this.pctManzana.Name = "pctManzana";
            this.pctManzana.Size = new System.Drawing.Size(321, 306);
            this.pctManzana.TabIndex = 0;
            this.pctManzana.TabStop = false;
            // 
            // pctNaranja
            // 
            this.pctNaranja.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pctNaranja.BackColor = System.Drawing.Color.LightPink;
            this.pctNaranja.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pctNaranja.BackgroundImage")));
            this.pctNaranja.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pctNaranja.Location = new System.Drawing.Point(658, 124);
            this.pctNaranja.Margin = new System.Windows.Forms.Padding(0);
            this.pctNaranja.Name = "pctNaranja";
            this.pctNaranja.Size = new System.Drawing.Size(249, 249);
            this.pctNaranja.TabIndex = 1;
            this.pctNaranja.TabStop = false;
            // 
            // pctPera
            // 
            this.pctPera.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pctPera.BackColor = System.Drawing.Color.LightPink;
            this.pctPera.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pctPera.BackgroundImage")));
            this.pctPera.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pctPera.Location = new System.Drawing.Point(91, 124);
            this.pctPera.Margin = new System.Windows.Forms.Padding(0);
            this.pctPera.Name = "pctPera";
            this.pctPera.Size = new System.Drawing.Size(241, 249);
            this.pctPera.TabIndex = 2;
            this.pctPera.TabStop = false;
            // 
            // pctText
            // 
            this.pctText.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pctText.BackColor = System.Drawing.Color.LightPink;
            this.pctText.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pctText.BackgroundImage")));
            this.pctText.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pctText.Location = new System.Drawing.Point(203, 500);
            this.pctText.Margin = new System.Windows.Forms.Padding(0);
            this.pctText.Name = "pctText";
            this.pctText.Size = new System.Drawing.Size(571, 97);
            this.pctText.TabIndex = 3;
            this.pctText.TabStop = false;
            this.pctText.Visible = false;
            // 
            // timerAnimation
            // 
            this.timerAnimation.Interval = 50;
            this.timerAnimation.Tick += new System.EventHandler(this.timerAnimation_Tick);
            // 
            // timerShading
            // 
            this.timerShading.Enabled = true;
            this.timerShading.Interval = 1;
            this.timerShading.Tick += new System.EventHandler(this.timerShading_Tick);
            // 
            // frmLoading
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightPink;
            this.ClientSize = new System.Drawing.Size(999, 659);
            this.Controls.Add(this.pctPera);
            this.Controls.Add(this.pctNaranja);
            this.Controls.Add(this.pctManzana);
            this.Controls.Add(this.pctText);
            this.Controls.Add(this.lblSkip);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmLoading";
            this.Opacity = 0D;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "La Manzanita";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmLoading_FormClosed);
            this.Load += new System.EventHandler(this.frmLoading_Load);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.frmLoading_KeyPress);
            this.Leave += new System.EventHandler(this.frmLoading_Leave);
            ((System.ComponentModel.ISupportInitialize)(this.pctManzana)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctNaranja)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctPera)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctText)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblSkip;
        private System.Windows.Forms.PictureBox pctManzana;
        private System.Windows.Forms.PictureBox pctNaranja;
        private System.Windows.Forms.PictureBox pctPera;
        private System.Windows.Forms.PictureBox pctText;
        private System.Windows.Forms.Timer timerAnimation;
        private System.Windows.Forms.Timer timerParpSkip;
        private System.Windows.Forms.Timer timerShading;
    }
}

