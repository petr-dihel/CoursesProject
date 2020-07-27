using Database.Entities.Course;
using Database.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CourseApp.AdministratorForms
{
    public partial class CertificateForm : Form
    {
        public CertificateForm()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void CertificateForm_Load(object sender, EventArgs e)
        {
            CourseService courseService = new CourseService();
            Collection<CourseEntity> courses = courseService.getAll();
            SortedDictionary<string, int> teacherDictionary = new SortedDictionary<string, int>();
            foreach (CourseEntity item in courses)
            {
                teacherDictionary.Add(item.courseId + ' ' + item.subject, item.courseId);
            }
            comboBox1.DataSource = new BindingSource(teacherDictionary, null);
            comboBox1.DisplayMember = "Key";
            comboBox1.ValueMember = "Value";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CertificateService certificateService = new CertificateService();
            int courseId = Int32.Parse(comboBox1.SelectedValue.ToString());
            DateTime expirationDate = dateTimePicker1.Value.Date;
            certificateService.InsertCertificates(courseId, expirationDate);
            label3.Text = "Úspěšně přidáno";
        }
    }
}
