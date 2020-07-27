using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Database.Entities.Teacher;
using Database.Entities.User;
using Database.Entities.Rating;
using Database.Services;

namespace CourseApp
{
    public partial class TeacherRating : Form
    {

        private TeacherEntity teacher;

        private UserEntity user;

        private RatingService ratingService;

        public TeacherRating(TeacherEntity teacher, UserEntity user)
        {
            InitializeComponent();
            this.teacher = teacher;
            this.user = user;
            this.ratingService = new RatingService();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            RatingEntity rating = new RatingEntity();
            rating.userId = user.userId;
            rating.teacherId = teacher.teacherId;
            rating.points = (int)numericUpDown1.Value;
            this.ratingService.Insert(rating);
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void TeacherRating_Load(object sender, EventArgs e)
        {

        }
    }
}
