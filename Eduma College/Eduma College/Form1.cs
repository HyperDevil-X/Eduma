using System.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Diagnostics;

namespace Eduma_College
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            timer1.Start();
        }
        string pattern = "^([0-9a-zA-Z]([-\\.\\w]*[0-9a-zA-Z)*@([0-9a-zA-Z][-\\w]*[0-9a-zA-Z]\\.)+[a-zA-Z]{2,9})$";

        private void exitSystemToolStripMenuItem_Click(object sender, EventArgs e)
        {
             
            Application.Exit();
        }

        private void btnenroll_Click(object sender, EventArgs e)
        {
            if (txtemail.Text == "" || txtusername.Text == "" || txtpassword.Text == "" || txtconfirmpassword.Text == "")

                MessageBox.Show("Please Fill The Mandotory Fields");

            else if (txtpassword.Text != txtconfirmpassword.Text)
                MessageBox.Show("Password Not Match");
            else
            {
                SqlConnection con = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=D:\dot net prog\Eduma College\Eduma College\Eduma_Database.mdf;Integrated Security=True;User Instance=True");
                con.Open();
                SqlCommand com = new SqlCommand("INSERT INTO Enroll(E_mail, Username, Password, Confirmpassword)VALUES ('" + txtemail.Text + "','" + txtusername.Text + "','" + txtpassword.Text + "','" + txtconfirmpassword.Text + "')", con);
                com.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Enroll Successfully");
                panel1.Visible = false;
                menuStrip2.Visible = true;
                pictureBox2.Visible = true;
                pictureBox3.Visible = true;
                fbpic.Visible = true;
                linkLabel1.Visible = true;
                instapic.Visible = true;
                linkLabel2.Visible = true;
                googlepic.Visible = true;
                linkLabel3.Visible = true;
            } 
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            menuStrip2.Visible = false;
            pictureBox2.Visible = false;
            pictureBox3.Visible = false;
            fbpic.Visible = false;
            linkLabel1.Visible = false;
            instapic.Visible = false;
            linkLabel2.Visible = false;
            googlepic.Visible = false;
            linkLabel3.Visible = false;
        }

       

        private void txtemail_Leave(object sender, EventArgs e)
        {
            if (Regex.IsMatch(txtemail.Text, pattern) == false)
            {
                txtemail.Focus();
                errorProvider1.SetError(this.txtemail, "Invalid Email");
            }
            else
            {
                errorProvider1.Clear();
            }
        }

        private void timer1_Tick_1(object sender, EventArgs e)
        {
            movetext.Location = new Point(movetext.Location.X + 20, movetext.Location.Y);
            if (movetext.Location.X > this.Width)
            {
                movetext.Location = new Point(0 - movetext.Width, movetext.Location.Y);
            }

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("https://www.facebook.com/");
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("https://www.instagram.com/");
        }

        private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("https://www.google.com/?gws_rd=ssl");
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            Addmission_Form af = new Addmission_Form();
            af.Show();
        }

        private void upgradeSemesterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Upgrade_semester us = new Upgrade_semester();
            us.Show();
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            Fees f = new Fees();
            f.Show();
        }

        private void toolStripMenuItem5_Click(object sender, EventArgs e)
        {
            Fees_Submit_By_Student fsbs = new Fees_Submit_By_Student();
            fsbs.Show();
        }

        private void toolStripMenuItem6_Click(object sender, EventArgs e)
        {
            SearchIndividualStudent sis = new SearchIndividualStudent();
            sis.Show();
        }

        private void addTeacherInformationsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddTeacher at = new AddTeacher();
            at.Show();
        }

        private void searchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SearchTeacher st = new SearchTeacher();
            st.Show();
        }

        private void abouToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RemoveStudent rs = new RemoveStudent();
            rs.Show();

        }

        private void contactUsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Contactus cu = new Contactus();
            cu.Show();
        }

        private void aboutUsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Aboutus au = new Aboutus();
            au.Show();
        }
    }
}
