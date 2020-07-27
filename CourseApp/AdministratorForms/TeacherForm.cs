using Database.Entities.Address;
using Database.Entities.Teacher;
using Database.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CourseApp.AdministratorForms
{
    public partial class TeacherForm : Form
    {
        public TeacherForm()
        {
            InitializeComponent();
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            TeacherEntity teacherEntity = new TeacherEntity();
            TeacherService teacherService = new TeacherService();

            teacherEntity.name = textBox1.Text;
            teacherEntity.surname = textBox2.Text;
            teacherEntity.email = textBox3.Text;
            teacherEntity.password = textBox4.Text;
            teacherEntity.telephone = textBox5.Text;
            teacherEntity.date_of_birth = dateTimePicker1.Value.Date;

            teacherService.Insert(teacherEntity);

            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";

            label6.Text = "Teacher added";
        }
    }
}
