using System;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text.RegularExpressions;
using System.Text;
using System.Windows.Forms;

namespace Eduma_College
{
    public partial class AddTeacher : Form
    {
        public AddTeacher()
        {
            InitializeComponent();
        }
        string pattern = "^([0-9a-zA-Z]([-\\.\\w]*[0-9a-zA-Z)*@([0-9a-zA-Z][-\\w]*[0-9a-zA-Z]\\.)+[a-zA-Z]{2,9})$";
        private void btnsubmit_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=D:\dot net prog\Eduma College\Eduma College\Eduma_Database.mdf;Integrated Security=True;User Instance=True");
            con.Open();
            SqlCommand com = new SqlCommand("INSERT INTO addteacher (Full_Name, Gender, Date_of_Birth, Mobile_No, Email, Year, Semester, Programming, [Duration(Year)], Address) VALUES ('"+txtfullname.Text+"','"+txtgender.Text+"','"+txtdateofbirth.Text+"','"+txtmobileno.Text+"','"+txtemail.Text+"','"+txtyear.Text+"','"+txtsem.Text+"','"+txtprog.Text+"','"+txtduration.Text+"','"+txtaddress.Text+"')",con);
            com.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Submitted Successfully");
            txtfullname.Clear();
            txtdateofbirth.ResetText();
            txtmobileno.Clear();
            txtemail.Clear();
            txtyear.ResetText();
            txtsem.ResetText();
            txtprog.ResetText();
            txtduration.ResetText();
            txtaddress.ResetText();
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
