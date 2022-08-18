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
    public partial class Fees : Form
    {
        public Fees()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void txtmobileno_TextChanged(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=D:\dot net prog\Eduma College\Eduma College\Eduma_Database.mdf;Integrated Security=True;User Instance=True");
            con.Open();
            SqlCommand com = new SqlCommand("SELECT Full_Name, Gurdian_Name, [Duration(Year)]FROM Addmission where Mobile_No = '" + txtmobileno.Text + "' ", con);
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataSet ds = new DataSet();
            da.Fill(ds);
            if (ds.Tables[0].Rows.Count != 0)
            {
                fullnamelabel.Text = ds.Tables[0].Rows[0][0].ToString();
                gurdiannamelabel.Text = ds.Tables[0].Rows[0][1].ToString();
                durationlabel.Text = ds.Tables[0].Rows[0][2].ToString();
            }
            else
            {
                fullnamelabel.Text = "__________________";
                gurdiannamelabel.Text = "__________________";
                durationlabel.Text = "__________________";
            }


        }

        private void btnsubmit_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=D:\dot net prog\Eduma College\Eduma College\Eduma_Database.mdf;Integrated Security=True;User Instance=True");
            con.Open();
            SqlCommand com = new SqlCommand("SELECT * FROM Fees where Mobile_no='" + txtmobileno.Text + "'", con);
            com.ExecuteNonQuery();
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataSet ds = new DataSet();
            da.Fill(ds);
            if (ds.Tables[0].Rows.Count == 0)
            {
                SqlConnection con1 = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=D:\dot net prog\Eduma College\Eduma College\Eduma_Database.mdf;Integrated Security=True;User Instance=True");
                con1.Open();
                SqlCommand com1 = new SqlCommand("INSERT INTO Fees (Mobile_no, Full_Name, Gurdian_Name, Duration, Fees) VALUES ('" + txtmobileno.Text + "','" + fullnamelabel.Text + "','" + gurdiannamelabel.Text + "','" + durationlabel.Text + "','" + txtfees.Text + "')", con1);
                com.ExecuteNonQuery();
                SqlDataAdapter da1 = new SqlDataAdapter(com1);
                DataSet ds1 = new DataSet();
                da1.Fill(ds1);
                if (MessageBox.Show("Fees Submission Successfull.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Asterisk) == DialogResult.OK)
                {
                    txtmobileno.Clear();
                    fullnamelabel.Text = "__________________";
                    gurdiannamelabel.Text = "__________________";
                    durationlabel.Text = "__________________";
                    txtfees.Clear();
                }
            }
                else
                {
                    MessageBox.Show("Fees is already Submitted");
                    txtmobileno.Clear();
                    fullnamelabel.Text = "__________________";
                    gurdiannamelabel.Text = "__________________";
                    durationlabel.Text = "__________________";
                    txtfees.Clear();
                }
            }
        }
    }
