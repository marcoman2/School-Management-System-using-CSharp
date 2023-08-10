using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SchoolMangementSystem
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            dashboardForm1.Visible = false;
            addStudentForm1.Visible = false;
            addTeachersForm1.Visible = true;
            addTeachersForm1.Update();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            DialogResult check = MessageBox.Show("Are you sure you want to logout?", "Confirmation Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if(check == DialogResult.Yes)
            {
                LoginForm lForm = new LoginForm();
                lForm.Show();
                this.Hide();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DashboardForm dForm = new DashboardForm();
            dForm.displayEnrolledStudentToday();
            dForm.displayTotalGS();
            dForm.displayTotalTT();
            dForm.displayTotalES();

            dashboardForm1.Visible = true;
            dashboardForm1.Update();
            addStudentForm1.Visible = false;
            addTeachersForm1.Visible = false;
        }

        private void AddStudent_btn_Click(object sender, EventArgs e)
        {
            dashboardForm1.Visible = false;
            addStudentForm1.Visible = true;
            addStudentForm1.Update();
            addTeachersForm1.Visible = false;
        }
    }
}
