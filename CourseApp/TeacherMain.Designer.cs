namespace CourseApp
{
    partial class TeacherMain
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
            this.courseEntityBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.courseEntityBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // courseEntityBindingSource
            // 
            this.courseEntityBindingSource.DataSource = typeof(Database.Entities.Course.CourseEntity);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(323, 172);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(151, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Logged in successfully";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // TeacherMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1036, 454);
            this.Controls.Add(this.label1);
            this.Name = "TeacherMain";
            this.Text = "TeacherMain";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.TeacherMain_FormClosed);
            this.Load += new System.EventHandler(this.TeacherMain_Load);
            ((System.ComponentModel.ISupportInitialize)(this.courseEntityBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.BindingSource courseEntityBindingSource;
        private System.Windows.Forms.Label label1;
    }
}