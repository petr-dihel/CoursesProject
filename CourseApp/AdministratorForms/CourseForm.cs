using Database.Entities.Course;
using Database.Entities.Teacher;
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
    public partial class CourseForm : Form
    {
        public CourseForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CourseEntity courseEntity = new CourseEntity();
            courseEntity.date = dateTimePicker1.Value.ToString();
            courseEntity.duration = Int32.Parse(textBox1.Text);
            courseEntity.subject = textBox2.Text;
            courseEntity.minRequiredPoints = Int32.Parse(textBox3.Text);
            courseEntity.price = float.Parse(textBox4.Text);
            courseEntity.teacherId = Int32.Parse(comboBox1.SelectedValue.ToString());
            CourseService courseService = new CourseService();
            courseService.Insert(courseEntity);
            label7.Text = "Kurz přidán";
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void CourseForm_Load(object sender, EventArgs e)
        {
            TeacherService teacherService = new TeacherService();
            Collection<TeacherEntity> teachers = teacherService.getAll();
            SortedDictionary<string, int> teacherDictionary = new SortedDictionary<string, int>();
            foreach (TeacherEntity item in teachers)
            {
                teacherDictionary.Add(item.name + ' ' + item.surname, item.teacherId);
            }
            comboBox1.DataSource = new BindingSource(teacherDictionary, null);
            comboBox1.DisplayMember = "Key";
            comboBox1.ValueMember = "Value";
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }
    }
}
