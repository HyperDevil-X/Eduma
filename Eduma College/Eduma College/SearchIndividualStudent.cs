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
    public partial class SearchIndividualStudent : Form
    {
        public SearchIndividualStudent()
        {
            InitializeComponent();
        }

        private void btnshowdetail_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=D:\dot net prog\Eduma College\Eduma College\Eduma_Database.mdf;Integrated Security=True;User Instance=True");
            con.Open();
            SqlCommand com = new SqlCommand("SELECT * FROM Addmission  where Mobile_No  ='"+textBox1.Text+"'",con);
            com.ExecuteNonQuery();
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataSet ds = new DataSet();
            da.Fill(ds);
            if (ds.Tables[0].Rows.Count != 0)
            {
                lblfullname.Text = ds.Tables[0].Rows[0][0].ToString();
                lblgurdianname.Text = ds.Tables[0].Rows[0][1].ToString();
                lblgender.Text = ds.Tables[0].Rows[0][2].ToString();
                lbldob.Text = ds.Tables[0].Rows[0][3].ToString();
                lblmobileno.Text = ds.Tables[0].Rows[0][4].ToString();
                lblemail.Text = ds.Tables[0].Rows[0][5].ToString();
                lblduration.Text = ds.Tables[0].Rows[0][6].ToString();
                lblyear.Text = ds.Tables[0].Rows[0][7].ToString();
                lblsem.Text = ds.Tables[0].Rows[0][8].ToString();
                lblprog.Text = ds.Tables[0].Rows[0][9].ToString();
                lblreligion.Text = ds.Tables[0].Rows[0][10].ToString();
                lblcaste.Text = ds.Tables[0].Rows[0][11].ToString();
                lbladdress.Text = ds.Tables[0].Rows[0][12].ToString();
            }
            else
            {
                MessageBox.Show("No Record Found","No Match");
                lblfullname.Text = "__________________";
                lblgurdianname.Text = "__________________";
                lblgender.Text = "__________________";
                lbldob.Text = "__________________";
                lblmobileno.Text = "__________________";
                lblemail.Text = "__________________";
                lblduration.Text = "__________________";
                lblyear.Text = "__________________";
                lblsem.Text = "__________________";
                lblprog.Text = "__________________";
                lblreligion.Text = "__________________";
                lblcaste.Text = "__________________";
                lbladdress.Text = "__________________";


                textBox1.Text = "";
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            lblfullname.Text = "__________________";
            lblgurdianname.Text = "__________________";
            lblgender.Text = "__________________";
            lbldob.Text = "__________________";
            lblmobileno.Text = "__________________";
            lblemail.Text = "__________________";
            lblduration.Text = "__________________";
            lblyear.Text = "__________________";
            lblsem.Text = "__________________";
            lblprog.Text = "__________________";
            lblreligion.Text = "__________________";
            lblcaste.Text = "__________________";
            lbladdress.Text = "__________________";


            textBox1.Text = "";

        }
    }
}
