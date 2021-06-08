using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace BookACar
{
    public partial class Rental : Form
    {
        SqlConnection Con;

        public Rental()
        {
            Con  = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Gabriela&Marco\Documents\CarRentaldb.mdf;Integrated Security=True;Connect Timeout=30");

            InitializeComponent();
        }
        private void fillcombo()
        {
            Con.Open();
            string query = "select RegNum from CarTbl where Available='"+"Yes"+"'";
            SqlCommand cmd = new SqlCommand(query, Con);
            SqlDataReader rdr;
            rdr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Columns.Add("RegNum", typeof(string));
            dt.Load(rdr);
            CarRegCb.ValueMember = "RegNum";
            CarRegCb.DataSource = dt;
            Con.Close();
        }
        private void fillCustomer()
        {
            Con.Open();
            string query = "select CustId from CustomerTbl";
            SqlCommand cmd = new SqlCommand(query, Con);
            SqlDataReader rdr;
            rdr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Columns.Add("CustId", typeof(int));
            dt.Load(rdr);
            CustCb.ValueMember = "CustId";
            CustCb.DataSource = dt;
            Con.Close();
        }
        private void fetchCustName()
        {
            Con.Open();
            string query = "select * from CustomerTbl where CustId="+CustCb.SelectedValue.ToString()+"";
            SqlCommand cmd = new SqlCommand(query, Con);
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            foreach(DataRow dr in dt.Rows)
            {
                CustNameTb.Text = dr["CustName"].ToString();
            }
            Con.Close();
        }
        private void populate()
        {
            Con.Open();
            string query = "select * from RentalTbl";
            SqlDataAdapter da = new SqlDataAdapter(query, Con);
            SqlCommandBuilder builder = new SqlCommandBuilder(da);
            var ds = new DataSet();
            da.Fill(ds);
            RentDGV.DataSource = ds.Tables[0];
            Con.Close();
        }
        private void label1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void UpdateonRent()
        {
            Con.Open();
            string query = "update CarTbl set Available ='" + "No" + "' where RegNum = '" + CarRegCb.SelectedValue.ToString() + "';";
            using SqlCommand cmd = new SqlCommand(query, Con);
            {
                cmd.ExecuteNonQuery();
            }
           // MessageBox.Show("User Successfully Updated");
            Con.Close();
        }
        private void UpdateonRentDelete()
        {
            Con.Open();
            string query = "update CarTbl set Available ='" + "Yes" + "' where RegNum = '" + CarRegCb.SelectedValue.ToString() + "';";
            using SqlCommand cmd = new SqlCommand(query, Con);
            {
                cmd.ExecuteNonQuery();
            }
            // MessageBox.Show("User Successfully Updated");
            Con.Close();
        }
        private void Rental_Load(object sender, EventArgs e)
        {
            fillcombo();
            fillCustomer();
            populate();
        }
                           
        private void IdTb_TextChanged(object sender, EventArgs e)
        {

        }

        private void CarRegCb_SelectionChangeCommitted(object sender, EventArgs e)
        {

        }

        private void CustCb_SelectionChangeCommitted(object sender, EventArgs e)
        {
            fetchCustName();
        }

        private void UId_Click(object sender, EventArgs e)
        {
            if (IdTb.Text == "" || CustNameTb.Text == "" || FeesTb.Text == "")
            {
                MessageBox.Show("Missing information");
            }
            else
            {
                try
                {
                    Con.Open();
                    string query = "Insert into RentalTbl values(" + IdTb.Text + ",'" + CarRegCb.SelectedValue.ToString() + "', '" + CustNameTb.Text + "','" + DateTime.Parse(RentDate.Text) + "','" + DateTime.Parse(ReturnDate.Text) + "','" + FeesTb.Text +"')";
                    using SqlCommand cmd = new SqlCommand(query, Con);
                    {
                        cmd.ExecuteNonQuery();
                    }
                    MessageBox.Show("Car Successfully Rented");
                    Con.Close();
                    UpdateonRent();
                    populate();

                }
                catch (Exception Myex)
                {
                    MessageBox.Show(Myex.Message);
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            MainForm main = new MainForm();
            main.Show();
        }

        private void CarRegCb_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (IdTb.Text == "")
            {
                MessageBox.Show("Missing information");
            }
            else
            {
                try
                {
                    Con.Open();
                    string query = "delete from RentalTbl where RentId=" + IdTb.Text + ";";
                    SqlCommand cmd = new SqlCommand(query, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Rental Deleted Successesfully");
                    Con.Close();
                    populate();
                    UpdateonRentDelete();
                }
                catch (Exception Myex)
                {
                    MessageBox.Show(Myex.Message);
                }
            }
        }

        private void RentDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            IdTb.Text = RentDGV.SelectedRows[0].Cells[0].Value.ToString();
            CarRegCb.SelectedValue = RentDGV.SelectedRows[0].Cells[1].Value.ToString();
            //CustNameTb.Text = RentDGV.SelectedRows[0].Cells[3].Value.ToString();
            FeesTb.Text = RentDGV.SelectedRows[0].Cells[5].Value.ToString();
        }

        private void Rental_Load_1(object sender, EventArgs e)
        {
            fillcombo();
            fillCustomer();
            populate();
        }

        private void CarRegCb_SelectionChangeCommitted_1(object sender, EventArgs e)
        {

        }

        private void CustCb_SelectionChangeCommitted_1(object sender, EventArgs e)
        {
            fetchCustName();
        }

        private void FeesTb_TextChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (IdTb.Text == "")
            {
                MessageBox.Show("Missing information");
            }
            else
            {
                try
                {
                    Con.Open();
                    string query = "update RentalTbl set IdTb.Text='" + IdTb.Text + "', CarRegCb.SelectedValue.ToString()'" + CustNameTb.Text + "', FeesTb.Text ='" + FeesTb.Text + "' where CustId=" + IdTb.Text + ";";
                    using SqlCommand cmd = new SqlCommand(query, Con);
                    {
                        cmd.ExecuteNonQuery();
                    }
                    MessageBox.Show("Rent Successfully Updated");
                    Con.Close();
                    populate();
                    UpdateonRent();
                }
                catch (Exception Myex)
                {
                    MessageBox.Show(Myex.Message);
                }
            }
        }
    }
    
}
