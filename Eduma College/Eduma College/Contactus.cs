using System;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Eduma_College
{
    public partial class Contactus : Form
    {
        public Contactus()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=D:\dot net prog\Eduma College\Eduma College\Eduma_Database.mdf;Integrated Security=True;User Instance=True");
            con.Open();
            SqlCommand com = new SqlCommand("INSERT INTO Contactus(Name, [Mobile No], [E-mail])VALUES ('"+txtname.Text+"','"+txtmobile.Text+"','"+txtemail.Text+"')",con);
            com.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Submitted Successfully");
            txtname.Clear();
            txtmobile.Clear();
            txtemail.Clear();

        }
    }
}
