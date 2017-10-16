namespace Manzanita
{
    partial class frmAlertInput
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAlertInput));
            this.pctManzanita = new System.Windows.Forms.PictureBox();
            this.rectangleShape1 = new Microsoft.VisualBasic.PowerPacks.RectangleShape();
            this.shapeContainer1 = new Microsoft.VisualBasic.PowerPacks.ShapeContainer();
            this.pctClose = new System.Windows.Forms.PictureBox();
            this.txtText = new System.Windows.Forms.TextBox();
            this.lblText = new System.Windows.Forms.Label();
            this.pctCancel = new System.Windows.Forms.PictureBox();
            this.pctAccept = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pctManzanita)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctClose)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctCancel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctAccept)).BeginInit();
            this.SuspendLayout();
            // 
            // pctManzanita
            // 
            this.pctManzanita.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pctManzanita.BackColor = System.Drawing.Color.White;
            this.pctManzanita.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pctManzanita.BackgroundImage")));
            this.pctManzanita.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.pctManzanita.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pctManzanita.Location = new System.Drawing.Point(0, 0);
            this.pctManzanita.Name = "pctManzanita";
            this.pctManzanita.Size = new System.Drawing.Size(429, 37);
            this.pctManzanita.TabIndex = 56;
            this.pctManzanita.TabStop = false;
            this.pctManzanita.Click += new System.EventHandler(this.pctManzanita_Click);
            this.pctManzanita.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pctManzanita_MouseDown);
            this.pctManzanita.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pctManzanita_MouseMove);
            this.pctManzanita.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pctManzanita_MouseUp);
            // 
            // rectangleShape1
            // 
            this.rectangleShape1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.rectangleShape1.BackColor = System.Drawing.Color.PaleGreen;
            this.rectangleShape1.Location = new System.Drawing.Point(0, 9);
            this.rectangleShape1.Name = "rectangleShape1";
            this.rectangleShape1.Size = new System.Drawing.Size(428, 175);
            // 
            // shapeContainer1
            // 
            this.shapeContainer1.Location = new System.Drawing.Point(0, 0);
            this.shapeContainer1.Margin = new System.Windows.Forms.Padding(0);
            this.shapeContainer1.Name = "shapeContainer1";
            this.shapeContainer1.Shapes.AddRange(new Microsoft.VisualBasic.PowerPacks.Shape[] {
            this.rectangleShape1});
            this.shapeContainer1.Size = new System.Drawing.Size(429, 185);
            this.shapeContainer1.TabIndex = 57;
            this.shapeContainer1.TabStop = false;
            // 
            // pctClose
            // 
            this.pctClose.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pctClose.BackColor = System.Drawing.Color.White;
            this.pctClose.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pctClose.BackgroundImage")));
            this.pctClose.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pctClose.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.pctClose.Location = new System.Drawing.Point(395, 12);
            this.pctClose.Name = "pctClose";
            this.pctClose.Size = new System.Drawing.Size(22, 16);
            this.pctClose.TabIndex = 58;
            this.pctClose.TabStop = false;
            this.pctClose.Click += new System.EventHandler(this.pctClose_Click);
            // 
            // txtText
            // 
            this.txtText.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtText.Font = new System.Drawing.Font("Cooper Black", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtText.Location = new System.Drawing.Point(52, 87);
            this.txtText.MaxLength = 20;
            this.txtText.Name = "txtText";
            this.txtText.Size = new System.Drawing.Size(325, 26);
            this.txtText.TabIndex = 59;
            this.txtText.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtText.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtText_KeyPress);
            // 
            // lblText
            // 
            this.lblText.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblText.Location = new System.Drawing.Point(12, 50);
            this.lblText.Name = "lblText";
            this.lblText.Size = new System.Drawing.Size(405, 35);
            this.lblText.TabIndex = 60;
            this.lblText.Text = "Ingresa el título que quieres que tenga la partida";
            this.lblText.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblText.UseMnemonic = false;
            // 
            // pctCancel
            // 
            this.pctCancel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pctCancel.BackColor = System.Drawing.Color.White;
            this.pctCancel.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pctCancel.BackgroundImage")));
            this.pctCancel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pctCancel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pctCancel.Location = new System.Drawing.Point(233, 127);
            this.pctCancel.Name = "pctCancel";
            this.pctCancel.Size = new System.Drawing.Size(106, 47);
            this.pctCancel.TabIndex = 62;
            this.pctCancel.TabStop = false;
            this.pctCancel.Click += new System.EventHandler(this.pctCancel_Click);
            this.pctCancel.MouseEnter += new System.EventHandler(this.pctCancel_MouseEnter);
            this.pctCancel.MouseLeave += new System.EventHandler(this.pctCancel_MouseLeave);
            // 
            // pctAccept
            // 
            this.pctAccept.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pctAccept.BackColor = System.Drawing.Color.White;
            this.pctAccept.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pctAccept.BackgroundImage")));
            this.pctAccept.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pctAccept.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pctAccept.Location = new System.Drawing.Point(89, 127);
            this.pctAccept.Name = "pctAccept";
            this.pctAccept.Size = new System.Drawing.Size(106, 47);
            this.pctAccept.TabIndex = 61;
            this.pctAccept.TabStop = false;
            this.pctAccept.Click += new System.EventHandler(this.pctAccept_Click);
            this.pctAccept.MouseEnter += new System.EventHandler(this.pctAccept_MouseEnter);
            this.pctAccept.MouseLeave += new System.EventHandler(this.pctAccept_MouseLeave);
            // 
            // frmAlertInput
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.PowderBlue;
            this.ClientSize = new System.Drawing.Size(429, 185);
            this.Controls.Add(this.pctCancel);
            this.Controls.Add(this.pctAccept);
            this.Controls.Add(this.lblText);
            this.Controls.Add(this.txtText);
            this.Controls.Add(this.pctClose);
            this.Controls.Add(this.pctManzanita);
            this.Controls.Add(this.shapeContainer1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmAlertInput";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmAlertInput";
            this.Load += new System.EventHandler(this.frmAlertInput_Load);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.frmAlertInput_KeyPress);
            this.Leave += new System.EventHandler(this.frmAlertInput_Leave);
            ((System.ComponentModel.ISupportInitialize)(this.pctManzanita)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctClose)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctCancel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctAccept)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pctManzanita;
        private Microsoft.VisualBasic.PowerPacks.RectangleShape rectangleShape1;
        private Microsoft.VisualBasic.PowerPacks.ShapeContainer shapeContainer1;
        private System.Windows.Forms.PictureBox pctClose;
        public System.Windows.Forms.Label lblText;
        private System.Windows.Forms.PictureBox pctCancel;
        private System.Windows.Forms.PictureBox pctAccept;
        public System.Windows.Forms.TextBox txtText;
    }
}