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
    public partial class RemoveStudent : Form
    {
        public RemoveStudent()
        {
            InitializeComponent();
        }

        private void btndelete_Click(object sender, EventArgs e)
        {
           if(MessageBox.Show("This will DELETE your DATA", "Warning", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
           {
               SqlConnection con = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=D:\dot net prog\Eduma College\Eduma College\Eduma_Database.mdf;Integrated Security=True;User Instance=True");
               con.Open();
               SqlCommand com = new SqlCommand("DELETE from Addmission WHERE Mobile_no='"+txtmobileno.Text+"'",con);
               SqlDataAdapter da = new SqlDataAdapter(com);
               DataSet ds = new DataSet();
               da.Fill(ds);

               MessageBox.Show("Deletion Successfull", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
           }
        }

        private void RemoveStudent_Load(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=D:\dot net prog\Eduma College\Eduma College\Eduma_Database.mdf;Integrated Security=True;User Instance=True");
            con.Open();
            SqlCommand com = new SqlCommand("SELECT * from Addmission",con);
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
        }
    }
}
