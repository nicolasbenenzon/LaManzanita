namespace Manzanita
{
    partial class frmAlertYesNo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAlertYesNo));
            this.shapeContainer1 = new Microsoft.VisualBasic.PowerPacks.ShapeContainer();
            this.rectangleShape1 = new Microsoft.VisualBasic.PowerPacks.RectangleShape();
            this.pctManzanita = new System.Windows.Forms.PictureBox();
            this.pctClose = new System.Windows.Forms.PictureBox();
            this.pctNo = new System.Windows.Forms.PictureBox();
            this.pctYes = new System.Windows.Forms.PictureBox();
            this.lblQuestion = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pctManzanita)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctClose)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctNo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctYes)).BeginInit();
            this.SuspendLayout();
            // 
            // shapeContainer1
            // 
            this.shapeContainer1.Location = new System.Drawing.Point(0, 0);
            this.shapeContainer1.Margin = new System.Windows.Forms.Padding(0);
            this.shapeContainer1.Name = "shapeContainer1";
            this.shapeContainer1.Shapes.AddRange(new Microsoft.VisualBasic.PowerPacks.Shape[] {
            this.rectangleShape1});
            this.shapeContainer1.Size = new System.Drawing.Size(418, 187);
            this.shapeContainer1.TabIndex = 0;
            this.shapeContainer1.TabStop = false;
            // 
            // rectangleShape1
            // 
            this.rectangleShape1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.rectangleShape1.BackColor = System.Drawing.Color.Transparent;
            this.rectangleShape1.Location = new System.Drawing.Point(0, 11);
            this.rectangleShape1.Name = "rectangleShape1";
            this.rectangleShape1.Size = new System.Drawing.Size(417, 175);
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
            this.pctManzanita.Size = new System.Drawing.Size(418, 37);
            this.pctManzanita.TabIndex = 1;
            this.pctManzanita.TabStop = false;
            this.pctManzanita.Click += new System.EventHandler(this.pctManzanita_Click);
            this.pctManzanita.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pctManzanita_MouseDown);
            this.pctManzanita.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pctManzanita_MouseMove);
            this.pctManzanita.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pctManzanita_MouseUp);
            // 
            // pctClose
            // 
            this.pctClose.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pctClose.BackColor = System.Drawing.Color.White;
            this.pctClose.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pctClose.BackgroundImage")));
            this.pctClose.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pctClose.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.pctClose.Location = new System.Drawing.Point(384, 12);
            this.pctClose.Name = "pctClose";
            this.pctClose.Size = new System.Drawing.Size(22, 16);
            this.pctClose.TabIndex = 52;
            this.pctClose.TabStop = false;
            this.pctClose.Click += new System.EventHandler(this.pctClose_Click);
            // 
            // pctNo
            // 
            this.pctNo.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pctNo.BackColor = System.Drawing.Color.White;
            this.pctNo.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pctNo.BackgroundImage")));
            this.pctNo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pctNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pctNo.Location = new System.Drawing.Point(226, 121);
            this.pctNo.Name = "pctNo";
            this.pctNo.Size = new System.Drawing.Size(106, 47);
            this.pctNo.TabIndex = 57;
            this.pctNo.TabStop = false;
            this.pctNo.Click += new System.EventHandler(this.pctNo_Click);
            this.pctNo.MouseEnter += new System.EventHandler(this.pctNo_MouseEnter);
            this.pctNo.MouseLeave += new System.EventHandler(this.pctNo_MouseLeave);
            // 
            // pctYes
            // 
            this.pctYes.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pctYes.BackColor = System.Drawing.Color.White;
            this.pctYes.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pctYes.BackgroundImage")));
            this.pctYes.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pctYes.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pctYes.Location = new System.Drawing.Point(83, 121);
            this.pctYes.Name = "pctYes";
            this.pctYes.Size = new System.Drawing.Size(106, 47);
            this.pctYes.TabIndex = 56;
            this.pctYes.TabStop = false;
            this.pctYes.Click += new System.EventHandler(this.pctYes_Click);
            this.pctYes.MouseEnter += new System.EventHandler(this.pctYes_MouseEnter);
            this.pctYes.MouseLeave += new System.EventHandler(this.pctYes_MouseLeave);
            // 
            // lblQuestion
            // 
            this.lblQuestion.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblQuestion.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblQuestion.Location = new System.Drawing.Point(12, 61);
            this.lblQuestion.Name = "lblQuestion";
            this.lblQuestion.Size = new System.Drawing.Size(394, 35);
            this.lblQuestion.TabIndex = 55;
            this.lblQuestion.Text = "¿Estás seguro que deseas salir del juego?";
            this.lblQuestion.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // frmAlertYesNo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.PowderBlue;
            this.ClientSize = new System.Drawing.Size(418, 187);
            this.Controls.Add(this.pctNo);
            this.Controls.Add(this.pctYes);
            this.Controls.Add(this.lblQuestion);
            this.Controls.Add(this.pctClose);
            this.Controls.Add(this.pctManzanita);
            this.Controls.Add(this.shapeContainer1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmAlertYesNo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.frmAlertYesNo_Load);
            this.Leave += new System.EventHandler(this.frmAlertYesNo_Leave);
            ((System.ComponentModel.ISupportInitialize)(this.pctManzanita)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctClose)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctNo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctYes)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.VisualBasic.PowerPacks.ShapeContainer shapeContainer1;
        private Microsoft.VisualBasic.PowerPacks.RectangleShape rectangleShape1;
        private System.Windows.Forms.PictureBox pctManzanita;
        private System.Windows.Forms.PictureBox pctClose;
        private System.Windows.Forms.PictureBox pctNo;
        private System.Windows.Forms.PictureBox pctYes;
        public System.Windows.Forms.Label lblQuestion;
    }
}