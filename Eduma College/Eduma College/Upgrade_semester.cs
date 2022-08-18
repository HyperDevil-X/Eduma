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
    public partial class Upgrade_semester : Form
    {
        public Upgrade_semester()
        {
            InitializeComponent();
        }

        private void btnupgrade_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Semester update waring !", "Confirm", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
            {
                SqlConnection con = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=D:\dot net prog\Eduma College\Eduma College\Eduma_Database.mdf;Integrated Security=True;User Instance=True");
                con.Open();
                SqlCommand com = new SqlCommand("UPDATE Addmission SET  Semester = '" + comboboxto.Text + "' WHERE (Semester='" + comboboxfrom.Text + "')", con);
                com.ExecuteNonQuery();
                SqlDataAdapter da = new SqlDataAdapter(com);
                DataSet ds = new DataSet();
                da.Fill(ds);
                MessageBox.Show("Upgrade Successfully", "Success");
                comboboxfrom.ResetText();
                comboboxto.ResetText();
            }
            else
            {
                MessageBox.Show("Upgrade Cancelled","Cancel");
            }
        }
    }
}
