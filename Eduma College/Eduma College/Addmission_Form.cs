using System;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace Eduma_College
{
    public partial class Addmission_Form : Form
    {
        public Addmission_Form()
        {
            InitializeComponent();
        }
        string pattern = "^([0-9a-zA-Z]([-\\.\\w]*[0-9a-zA-Z)*@([0-9a-zA-Z][-\\w]*[0-9a-zA-Z]\\.)+[a-zA-Z]{2,9})$";

        private void btnsubmit_Click(object sender, EventArgs e)
        {
            if(txtfullname.Text == "" || txtgurdianname.Text == "" || txtgender.Text == "" || txtdateofbirth.Text == "" || txtmobileno.Text == "" || txtemail.Text == "" || txtduration.Text == "" || txtyear.Text == "" || txtsemester.Text == "" || txtprogramming.Text == "" || txtreligion.Text == "" || txtcaste.Text =="" || txtaddress.Text =="")
                MessageBox.Show("Please Fill The Mandatory Feilds");
            else
            {
            SqlConnection con = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=D:\dot net prog\Eduma College\Eduma College\Eduma_Database.mdf;Integrated Security=True;User Instance=True");
            con.Open();
            SqlCommand com = new SqlCommand("INSERT INTO Addmission(Full_Name, Gurdian_Name, Gender, Date_of_Birth, Mobile_No, Email, [Duration(Year)], Year, Semester, Programming, Religion, Caste, Address)VALUES ('"+txtfullname.Text+"','"+txtgurdianname.Text+"','"+txtgender.Text+"','"+txtdateofbirth.Text+"','"+txtmobileno.Text+"','"+txtemail.Text+"','"+txtduration.Text+"','"+txtyear.Text+"','"+txtsemester.Text+"','"+txtprogramming.Text+"','"+txtreligion.Text+"','"+txtcaste.Text+"','"+txtaddress.Text+"')",con);
            com.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Submit Successfully");
            txtfullname.Clear();
            txtgurdianname.Clear();
            txtgender.ResetText();
            txtdateofbirth.ResetText();
            txtmobileno.Clear();
            txtemail.Clear();
            txtduration.ResetText();
            txtyear.ResetText();
            txtsemester.ResetText();
            txtprogramming.ResetText();
            txtreligion.ResetText();
            txtcaste.ResetText();
            txtaddress.ResetText();
            }
        }

        private void txtemail_TextChanged(object sender, EventArgs e)
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
    }
}
