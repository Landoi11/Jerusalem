using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Jerusalem
{
    public partial class Jerusalem : Form
    {
        SqlConnection con = new SqlConnection("Data Source =LANDOI\\SQLEXPRESS; Initial Catalog=Jerusalem1;Integrated Security=True");
        public Jerusalem()
        {
            InitializeComponent();
        }
        void data()
        {
            SqlCommand cmd = new SqlCommand("Select * from Student", con);
            SqlDataAdapter sd = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sd.Fill(dt);
            studinfo.DataSource = dt;
        }
        void data1()
        {
            SqlCommand cmd = new SqlCommand("Select * from Student", con);
            SqlDataAdapter sd = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sd.Fill(dt);
            studpercrs.DataSource = dt;
        }
        void enrolled()
        {
            SqlCommand cmd = new SqlCommand("Select * from Enrolled", con);
            SqlDataAdapter sd = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sd.Fill(dt);
            enrolleds.DataSource = dt;
        }
        void drop()
        {
            SqlCommand cmd = new SqlCommand("Select * from Dropped", con);
            SqlDataAdapter sd = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sd.Fill(dt);
            dropped.DataSource = dt;
        }
        void subject()
        {
            SqlCommand cmd = new SqlCommand("Select * from Subjects", con);
            SqlDataAdapter sd = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sd.Fill(dt);
            subjects.DataSource = dt;
        }

        private void btnen_Click(object sender, EventArgs e)
        {
            con.Open();

            SqlCommand cmd = new SqlCommand("insert into Student_info1 values ('" + txtid.Text + "','" + txtname.Text + "','" + cboyr.Text + "','" + cbosec.Text + "','" + cbopi.Text + "')", con);

            cmd.ExecuteNonQuery();
            con.Close();
            enrolled();
            data();
            txtname.Text = "";
            cboyr.Text = "";
            cbopi.Text = "";
            cbosec.Text = "";
            txtid.Text = "";
        }

        private void Jerusalem_Load(object sender, EventArgs e)
        {
            data();
            enrolled();
            drop();
        }

        private void studpercrs_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                //gets a collection that contains all the rows
                DataGridViewRow row = this.studpercrs.Rows[e.RowIndex];
                //populate the textbox from specific value of the coordinates of column and row.
                txtidi.Text = row.Cells[0].Value.ToString();
            }
        }

        private void btnis_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("Select * from Student where Program = 'BSIS'", con);
            SqlDataAdapter sd = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sd.Fill(dt);
            studpercrs.DataSource = dt;
        }

        private void btnit_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("Select * from Student where Program = 'BSIT'", con);
            SqlDataAdapter sd = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sd.Fill(dt);
            studpercrs.DataSource = dt;
        }

        private void btncs_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("Select * from Student where Program = 'BSCS'", con);
            SqlDataAdapter sd = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sd.Fill(dt);
            studpercrs.DataSource = dt;
        }

        private void btnemc_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("Select * from Student where Program = 'BSEMC'", con);
            SqlDataAdapter sd = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sd.Fill(dt);
            studpercrs.DataSource = dt;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            data1();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("delete student_info1 where Student_ID='" + txtidi.Text + "'", con);
            cmd.ExecuteNonQuery();
            MessageBox.Show("Student Dropped!!!");
            con.Close();
            drop();
            data();
            data1();
            enrolled();
        }

        private void enrolleds_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                //gets a collection that contains all the rows
                DataGridViewRow row = this.enrolleds.Rows[e.RowIndex];
                //populate the textbox from specific value of the coordinates of column and row.
                txtsn.Text = row.Cells[0].Value.ToString();
            }
            else
            {
                txtsn.Text = "";
            }
        }

        private void txtsn_TextChanged(object sender, EventArgs e)
        {
            con.Open();

            SqlCommand cm = new SqlCommand("Select * from Student where Student_ID='" + txtsn.Text + "'", con);
            SqlDataReader reader = cm.ExecuteReader();
            while (reader.Read())
            {
                txtnm.Text = reader["Student_Name"].ToString();
                txtpro.Text = reader["PROGRAM"].ToString();
                txtyl.Text = reader["Year_level"].ToString();
            }
            
            
            con.Close();
            subject();
        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }
    }
}
