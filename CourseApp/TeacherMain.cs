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

namespace CourseApp
{
    public partial class TeacherMain : Form
    {
        private TeacherEntity teacherEntity;

        private CourseService courseService;

        public TeacherMain(TeacherEntity teacherEntity)
        {
            InitializeComponent();
            this.teacherEntity = teacherEntity;
            this.courseService = new CourseService();
        }

        private void TeacherMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void TeacherMain_Load(object sender, EventArgs e)
        {    
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
