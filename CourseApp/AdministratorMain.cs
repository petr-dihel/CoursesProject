using CourseApp.AdministratorForms;
using Database.Entities.Administrator;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CourseApp
{
    public partial class AdministratorMain : Form
    {
        private AdministratorEntity LoggedAdmin;

        public AdministratorMain(AdministratorEntity loggedAdmin)
        {
            InitializeComponent();
            this.LoggedAdmin = loggedAdmin;
        }

        private void učiteToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void certifikátToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {
            CertificateForm certificateForm = new CertificateForm();
            certificateForm.MdiParent = this;
            certificateForm.Show();
        }

        private void certifikátToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            CertificateForm certificateForm = new CertificateForm();
            certificateForm.MdiParent = this;
            certificateForm.Show();
        }

        private void kurzToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CourseForm courseForm = new CourseForm();
            courseForm.MdiParent = this;
            courseForm.Show();
        }

        private void učiteleToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            TeacherForm teacherForm = new TeacherForm();
            teacherForm.MdiParent = this;
            teacherForm.Show();
        }

        private void nastavitDlužníkyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UserDebt form = new UserDebt();
            form.MdiParent = this;
            form.Show();
        }

        private void přidatToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void AdministratorMain_Load(object sender, EventArgs e)
        {

        }

        private void AdministratorMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
