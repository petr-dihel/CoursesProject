using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Database.Services;
using Database.Entities.User;
using Database.Entities.Administrator;
using Database.Entities.Teacher;

namespace CourseApp
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
            comboBox1.SelectedIndex = 0;
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            switch(comboBox1.SelectedIndex)
            {
                case 0:
                    UserService userService = new UserService();
                    UserEntity loggedUser = userService.TryLogin(textBox1.Text, textBox2.Text);
                    if (loggedUser != null)
                    {
                        UserMain MainForm = new UserMain(loggedUser);
                        MainForm.Show();
                        this.Hide();
                    }
                    else
                    {
                        label4.Text = "Wrong email or password";
                        label4.Visible = true;
                    }
                    break;
                case 2:
                    TeacherService teacherService = new TeacherService();
                    TeacherEntity loggerTeacher = teacherService.TryLogIn(textBox1.Text, textBox2.Text);
                    if (loggerTeacher != null)
                    {
                        TeacherMain MainForm = new TeacherMain(loggerTeacher);
                        MainForm.Show();
                        this.Hide(); 
                    } else
                    {
                        label4.Text = "Wrong email or password";
                        label4.Visible = true;
                    }
                    break;
                case 1:
                    AdministratorService administratorService = new AdministratorService();
                    AdministratorEntity loggedAdmin = administratorService.tryLogIn(textBox1.Text, textBox2.Text);
                    if (loggedAdmin != null)
                    {
                        AdministratorMain MainForm = new AdministratorMain(loggedAdmin);
                        MainForm.Show();
                        this.Hide();
                    }
                    else
                    {
                        label4.Text = "Wrong email or password";
                        label4.Visible = true;
                    }
                    break;
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void Login_Load(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
