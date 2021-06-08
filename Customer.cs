using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace BookACar
{
    public partial class Customer : Form
    {
        public Customer()
        {
            InitializeComponent();
        }
        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Gabriela&Marco\Documents\CarRentaldb.mdf;Integrated Security=True;Connect Timeout=30");
        private void populate()
        {
            Con.Open();
            string query = "select * from CustomerTbl";
            SqlDataAdapter da = new SqlDataAdapter(query, Con);
            SqlCommandBuilder builder = new SqlCommandBuilder(da);
            var ds = new DataSet();
            da.Fill(ds);
            CustomersDGV.DataSource = ds.Tables[0];
            Con.Close();
        }
        private void label1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            MainForm main = new MainForm();
            main.Show();
        }

        private void UId_Click(object sender, EventArgs e)
        {
            if (IdTb.Text == "" || NameTb.Text == "" || AddressTb.Text == "" || PhoneTb.Text == "")
            {
                MessageBox.Show("Missing information");
            }
            else
            {
                try
                {
                    Con.Open();
                    string query = "Insert into CustomerTbl values(" + IdTb.Text + ",'" + NameTb.Text + "', '" + AddressTb.Text + "'," + PhoneTb.Text + ")";
                    using SqlCommand cmd = new SqlCommand(query, Con); 
                    {
                        cmd.ExecuteNonQuery();
                    }
                    MessageBox.Show("Customer Successfully Added");
                    Con.Close();
                    populate();

                }
                catch (Exception Myex)
                {
                    MessageBox.Show(Myex.Message);
                }
            }
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
                    string query = "delete from CustomerTbl where CustId=" + IdTb.Text + ";";
                    SqlCommand cmd = new SqlCommand(query, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Customer Deleted Successesfully");
                    Con.Close();
                    populate();
                }
                catch (Exception Myex)
                {
                    MessageBox.Show(Myex.Message);
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (IdTb.Text == "" || NameTb.Text == "" || AddressTb.Text == "" || PhoneTb.Text == "")
            {
                MessageBox.Show("Missing information");
            }
            else
            {
                try
                {
                    Con.Open();
                    string query = "update CustomerTbl set CustName='" + NameTb.Text + "',CustAdd='" + AddressTb.Text + "', Phone ='" + PhoneTb.Text + "' where CustId=" + IdTb.Text + ";";
                    using SqlCommand cmd = new SqlCommand(query, Con);
                    {
                        cmd.ExecuteNonQuery();
                    }
                    MessageBox.Show("Customer  Successfully Updated");
                    Con.Close();
                    populate();

                }
                catch (Exception Myex)
                {
                    MessageBox.Show(Myex.Message);
                }
            }
        }

        private void Customer_Load(object sender, EventArgs e)
        {
            populate();
        }

        private void CustomersDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            IdTb.Text = CustomersDGV.SelectedRows[0].Cells[0].Value.ToString();
            NameTb.Text = CustomersDGV.SelectedRows[0].Cells[1].Value.ToString();
            AddressTb.Text = CustomersDGV.SelectedRows[0].Cells[2].Value.ToString();
            PhoneTb.Text = CustomersDGV.SelectedRows[0].Cells[3].Value.ToString();
        }
    }
}
