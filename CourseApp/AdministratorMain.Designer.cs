namespace CourseApp
{
    partial class AdministratorMain
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
            this.přidatToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.certifikátToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.kurzToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.učiteleToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.uživateléToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nastavitDlužníkyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // přidatToolStripMenuItem
            // 
            this.přidatToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.certifikátToolStripMenuItem1,
            this.kurzToolStripMenuItem,
            this.učiteleToolStripMenuItem1});
            this.přidatToolStripMenuItem.Name = "přidatToolStripMenuItem";
            this.přidatToolStripMenuItem.Size = new System.Drawing.Size(60, 24);
            this.přidatToolStripMenuItem.Text = "Přidat";
            this.přidatToolStripMenuItem.Click += new System.EventHandler(this.přidatToolStripMenuItem_Click);
            // 
            // certifikátToolStripMenuItem1
            // 
            this.certifikátToolStripMenuItem1.Name = "certifikátToolStripMenuItem1";
            this.certifikátToolStripMenuItem1.Size = new System.Drawing.Size(216, 26);
            this.certifikátToolStripMenuItem1.Text = "Certifikát";
            this.certifikátToolStripMenuItem1.Click += new System.EventHandler(this.certifikátToolStripMenuItem1_Click);
            // 
            // kurzToolStripMenuItem
            // 
            this.kurzToolStripMenuItem.Name = "kurzToolStripMenuItem";
            this.kurzToolStripMenuItem.Size = new System.Drawing.Size(216, 26);
            this.kurzToolStripMenuItem.Text = "Kurz";
            this.kurzToolStripMenuItem.Click += new System.EventHandler(this.kurzToolStripMenuItem_Click);
            // 
            // učiteleToolStripMenuItem1
            // 
            this.učiteleToolStripMenuItem1.Name = "učiteleToolStripMenuItem1";
            this.učiteleToolStripMenuItem1.Size = new System.Drawing.Size(216, 26);
            this.učiteleToolStripMenuItem1.Text = "Učitele";
            this.učiteleToolStripMenuItem1.Click += new System.EventHandler(this.učiteleToolStripMenuItem1_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.přidatToolStripMenuItem,
            this.uživateléToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(8, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(1087, 28);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // uživateléToolStripMenuItem
            // 
            this.uživateléToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.nastavitDlužníkyToolStripMenuItem});
            this.uživateléToolStripMenuItem.Name = "uživateléToolStripMenuItem";
            this.uživateléToolStripMenuItem.Size = new System.Drawing.Size(82, 24);
            this.uživateléToolStripMenuItem.Text = "Uživatelé";
            // 
            // nastavitDlužníkyToolStripMenuItem
            // 
            this.nastavitDlužníkyToolStripMenuItem.Name = "nastavitDlužníkyToolStripMenuItem";
            this.nastavitDlužníkyToolStripMenuItem.Size = new System.Drawing.Size(196, 26);
            this.nastavitDlužníkyToolStripMenuItem.Text = "Nastavit dlužníky";
            this.nastavitDlužníkyToolStripMenuItem.Click += new System.EventHandler(this.nastavitDlužníkyToolStripMenuItem_Click);
            // 
            // AdministratorMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1087, 487);
            this.Controls.Add(this.menuStrip1);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "AdministratorMain";
            this.Text = "AdministratorMain";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.AdministratorMain_FormClosed);
            this.Load += new System.EventHandler(this.AdministratorMain_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStripMenuItem přidatToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem certifikátToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem kurzToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem učiteleToolStripMenuItem1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem uživateléToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem nastavitDlužníkyToolStripMenuItem;
    }
}