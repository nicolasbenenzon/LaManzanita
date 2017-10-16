namespace Manzanita
{
    partial class frmAlert
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAlert));
            this.lblInvalidUser = new System.Windows.Forms.Label();
            this.shapeContainer1 = new Microsoft.VisualBasic.PowerPacks.ShapeContainer();
            this.rectangleShape1 = new Microsoft.VisualBasic.PowerPacks.RectangleShape();
            this.timerOpening = new System.Windows.Forms.Timer(this.components);
            this.timerWaitingFade = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // lblInvalidUser
            // 
            resources.ApplyResources(this.lblInvalidUser, "lblInvalidUser");
            this.lblInvalidUser.Name = "lblInvalidUser";
            this.lblInvalidUser.Click += new System.EventHandler(this.lblInvalidUser_Click);
            this.lblInvalidUser.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lblInvalidUser_MouseDown);
            this.lblInvalidUser.MouseMove += new System.Windows.Forms.MouseEventHandler(this.lblInvalidUser_MouseMove);
            this.lblInvalidUser.MouseUp += new System.Windows.Forms.MouseEventHandler(this.lblInvalidUser_MouseUp);
            // 
            // shapeContainer1
            // 
            resources.ApplyResources(this.shapeContainer1, "shapeContainer1");
            this.shapeContainer1.Name = "shapeContainer1";
            this.shapeContainer1.Shapes.AddRange(new Microsoft.VisualBasic.PowerPacks.Shape[] {
            this.rectangleShape1});
            this.shapeContainer1.TabStop = false;
            // 
            // rectangleShape1
            // 
            resources.ApplyResources(this.rectangleShape1, "rectangleShape1");
            this.rectangleShape1.Name = "rectangleShape1";
            this.rectangleShape1.Click += new System.EventHandler(this.rectangleShape1_Click);
            this.rectangleShape1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.rectangleShape1_MouseDown);
            this.rectangleShape1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.rectangleShape1_MouseMove);
            this.rectangleShape1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.rectangleShape1_MouseUp);
            // 
            // timerOpening
            // 
            this.timerOpening.Interval = 50;
            this.timerOpening.Tick += new System.EventHandler(this.timerOpening_Tick);
            // 
            // timerWaitingFade
            // 
            this.timerWaitingFade.Interval = 2000;
            this.timerWaitingFade.Tick += new System.EventHandler(this.timerWaitingFade_Tick);
            // 
            // frmAlert
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightCoral;
            this.Controls.Add(this.lblInvalidUser);
            this.Controls.Add(this.shapeContainer1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmAlert";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.TopMost = true;
            this.Load += new System.EventHandler(this.frmAlert_Load);
            this.Click += new System.EventHandler(this.frmAlert_Click);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.frmAlert_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.frmAlert_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.frmAlert_MouseUp);
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.VisualBasic.PowerPacks.ShapeContainer shapeContainer1;
        private Microsoft.VisualBasic.PowerPacks.RectangleShape rectangleShape1;
        private System.Windows.Forms.Timer timerOpening;
        public System.Windows.Forms.Timer timerWaitingFade;
        public System.Windows.Forms.Label lblInvalidUser;
    }
}