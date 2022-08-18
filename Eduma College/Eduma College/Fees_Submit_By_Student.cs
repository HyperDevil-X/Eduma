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
    public partial class Fees_Submit_By_Student : Form
    {
        public Fees_Submit_By_Student()
        {
            InitializeComponent();
        }

        private void Fees_Submit_By_Student_Load(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=D:\dot net prog\Eduma College\Eduma College\Eduma_Database.mdf;Integrated Security=True;User Instance=True");
            con.Open();
            SqlCommand com = new SqlCommand("select Addmission.Full_Name as Full_Name, Addmission.Gurdian_Name as Gurdian_Name, Addmission.Gender as Gender, Addmission.Date_of_Birth as Date_of_Birth, Addmission.Mobile_No as Mobile_No, Addmission.Email as Email, Addmission.[Duration(Year)] as [Duration(Year)], Addmission.Year as Year, Addmission.Semester as Semester,Addmission.Programming as Programming, Addmission.Religion as Religion, Addmission.Caste as Caste, Addmission.Address as Address,fees.Fees as Fees from addmission inner join Fees on Addmission.Mobile_no=fees.Mobile_no", con);
            com.ExecuteNonQuery();
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
        }
    }
}
