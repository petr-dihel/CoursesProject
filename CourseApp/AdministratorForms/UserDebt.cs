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
    public partial class UserDebt : Form
    {
        public UserDebt()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            UserService userService = new UserService();
            userService.SetDebts();
            label1.Text = "Dlužníci nastaveni";
        }
    }
}
