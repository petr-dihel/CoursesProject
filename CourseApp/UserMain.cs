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
using System.Collections.ObjectModel;
using Database.Entities.Course;
using Database.Entities.User;
using Database.Entities.Invoice;
using Database.Entities.Teacher;

namespace CourseApp
{
    public partial class UserMain : Form
    {
        private CourseService courseService;

        private UserEntity loggedUser;

        private InvoiceService invoiceService;

        private TeacherService teacherService;

        public UserMain(UserEntity loggedUser)
        {
            InitializeComponent();
            this.loggedUser = loggedUser;
            this.invoiceService = new InvoiceService();
            this.teacherService = new TeacherService();

        }

        private void loadCoursesToGrid(Collection<CourseEntity> courses, DataGridView dataGridView)
        {
            dataGridView.Rows.Clear();
            foreach (CourseEntity entity in courses)
            {
                entity.teacher = this.courseService.GetCourseTeacher(entity.teacherId);
                dataGridView.Rows.Add(
                    entity.courseId,
                    entity.subject,
                    entity.date,
                    entity.teacher.name, 
                    entity.price,
                    entity.duration               
                );
            }
        }

        private void tabControl1_DrawItem(object sender, DrawItemEventArgs e)
        {
            TabPage page = tabControl1.TabPages[e.Index];
            Color color = Color.FromArgb(107, 144, 209);
            e.Graphics.FillRectangle(new SolidBrush(color), e.Bounds);
            e.Graphics.DrawRectangle(new Pen(color), e.Bounds);
    
            Rectangle paddedBounds = e.Bounds;
            
            int yOffset = (e.State == DrawItemState.Selected) ? -2 : 1;
            paddedBounds.Offset(1, yOffset);
            TextRenderer.DrawText(e.Graphics, page.Text, Font, paddedBounds, page.ForeColor);

        }

        private void Main_Load(object sender, EventArgs e)
        {
            this.courseService = new CourseService();
            Collection<CourseEntity> courses = this.courseService.getAll();
            this.loadCoursesToGrid(courses, dataGridView1);
            button3.Text += loggedUser.email;


        }

        private void tabPage1_Click(object sender, EventArgs e)
        {
            Collection<CourseEntity> courses = this.courseService.getAll();          
            loadCoursesToGrid(courses, dataGridView2);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Login.ActiveForm.Show();
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            string searchTerm = textBox1.Text;
            Collection<CourseEntity> courses;
            if (searchTerm == "")
            {
                courses = this.courseService.getAll();
            } else
            {
                courses = this.courseService.GetBysubject(searchTerm);
            }
            loadCoursesToGrid(courses, dataGridView1);       
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];
            string courseId = row.Cells[0].Value.ToString();
            string courseSubject = row.Cells[1].Value.ToString();
            if (!this.courseService.isSignedToCourse(courseId, this.loggedUser.userId.ToString()))
            {
                string message = "Chcete se opravdu přihlásit k tomutu kurzu " + courseSubject + " ?";
                const string caption = "Přihlášení ke kurzu";
                var result = MessageBox.Show(message, caption,
                                             MessageBoxButtons.YesNo,
                                             MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    this.courseService.InsertIntoUserCourse(this.loggedUser.userId.ToString(), courseId);
                }
            } else
            {
                string message = "K tomuto kurzu již přihlášený jste! " + courseSubject;
                const string caption = "Přihlášení ke kurzu";
                var result = MessageBox.Show(message, caption,
                                             MessageBoxButtons.OK,
                                             MessageBoxIcon.Question);
            }
        
        }

        private void tabPage2_Click(object sender, EventArgs e)
        {
            Collection<CourseEntity> courses = this.courseService.getUserCourse(this.loggedUser.userId);
            loadCoursesToGrid(courses, dataGridView2);   
        }

        private void loadInvoicesToGrid(Collection<InvoiceEntity> invoices)
        {
            dataGridView3.Rows.Clear();
            foreach (InvoiceEntity entity in invoices)
            {
                float price = this.invoiceService.getCoursePrice(entity.invoiceId);
                dataGridView3.Rows.Add(                   
                    (entity.paid ? "ANO" : "NE"),
                    entity.dateCreated,
                    entity.dueDate,
                    price
                );
            }
        }

        private void tabPage3_Click(object sender, EventArgs e)
        {
            Collection<InvoiceEntity> invoices = this.invoiceService.getUsersInvoices(this.loggedUser.userId);
        }

        private void loadTeaherToGrid(Collection<TeacherEntity> entities)
        {
            dataGridView4.Rows.Clear();
            foreach (TeacherEntity entity in entities)
            {
                dataGridView4.Rows.Add(
                    entity.name,
                    entity.surname,
                    entity.date_of_birth,
                    entity.telephone,
                    entity.email,
                    entity.averageRating
                );
            }
        }

        private void tabPage4_Click(object sender, EventArgs e)
        {
            Collection<TeacherEntity> teacherEntities = this.teacherService.getAll();
            this.loadTeaherToGrid(teacherEntities);
        }

        private void dataGridView4_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = this.dataGridView2.Rows[e.RowIndex];
            int teacherId = (int)row.Cells[0].Value;                   
            TeacherEntity teacher = this.teacherService.GetById(teacherId);
            Form ratingForm = new TeacherRating(teacher, loggedUser);
            ratingForm.ShowDialog();
        }

        private void UserMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void tabControl1_Click(object sender, EventArgs e)
        {
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch(tabControl1.SelectedIndex)
            {
                case 0:                
                    Collection<CourseEntity> courses = this.courseService.getAll();
                    loadCoursesToGrid(courses, dataGridView2);
                    break;
                case 1:
                    Collection<CourseEntity> courses2 = this.courseService.getUserCourse(this.loggedUser.userId);
                    loadCoursesToGrid(courses2, dataGridView2);
                    break;
                case 2:
                    Collection<InvoiceEntity> invoices = this.invoiceService.getUsersInvoices(this.loggedUser.userId);
                    loadInvoicesToGrid(invoices);
                    break;
                case 3:
                    Collection<TeacherEntity> teacherEntities = this.teacherService.getAll();
                    this.loadTeaherToGrid(teacherEntities);
                    break;

            };
        }

        private void dataGridView3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
