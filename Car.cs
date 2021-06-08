using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace BookACar
{
    public partial class Car : Form
    {
        SqlConnection Con;
        public Car()
        {
            Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Gabriela&Marco\Documents\CarRentaldb.mdf;Integrated Security=True;Connect Timeout=30");

            InitializeComponent();
        }
        private void populate()
        {
            Con.Open();
            string query = "select * from CarTbl";
            SqlDataAdapter da = new SqlDataAdapter(query, Con);
            SqlCommandBuilder builder = new SqlCommandBuilder(da);
            var ds = new DataSet();
            da.Fill(ds);
            CarsDGV.DataSource = ds.Tables[0];
            Con.Close();
        }
        private void UId_Click(object sender, EventArgs e)
        {
            if (RegNumTb.Text == " " || BrandTb.Text == " " || ModelTb.Text == " " || PriceTb.Text == " ")
            {
                MessageBox.Show("Missing information");
            }
            else
            {
                string query = "Insert into CarTbl values(" + RegNumTb.Text + ",'" + BrandTb.Text + "','" + ModelTb.Text + "','" + AvailableCb.SelectedItem.ToString() + "'," + PriceTb.Text + ")";

                try
                {
                    Con.Open();
                     using SqlCommand cmd = new SqlCommand(query, Con);
                    {
                        cmd.ExecuteNonQuery();
                    }
                    MessageBox.Show("Car Successfully Added");
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
            if (RegNumTb.Text == "")
            {
                MessageBox.Show("Missing information");
            }
            else
            {
                try
                {
                    Con.Open();
                    string query = "delete from CarTbl where RegNum=" + RegNumTb.Text + ";";
                    using SqlCommand cmd = new SqlCommand(query, Con);
                    {
                        cmd.ExecuteNonQuery();
                    }
                    MessageBox.Show("Car Deleted Successesfully");
                    Con.Close();
                    populate();
                }
                catch (Exception Myex)
                {
                    MessageBox.Show(Myex.Message);
                }
            }
        }

        private void AvailableCb_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (RegNumTb.Text == "" || BrandTb.Text == "" || ModelTb.Text == "" || PriceTb.Text == "")
            {
                MessageBox.Show("Missing information");
            }
            else
            {
                try
                {
                    Con.Open();
                    string query = "update CarTbl set Brand='" + BrandTb.Text + "', Model='" + ModelTb.Text + "', Available ='" + AvailableCb.SelectedItem.ToString() + "',Price=" + PriceTb.Text + " where RegNum=" + RegNumTb.Text + ";";
                    using SqlCommand cmd = new SqlCommand(query, Con);
                    {
                        cmd.ExecuteNonQuery();
                    }
                    MessageBox.Show("Car Successfully Updated");
                    Con.Close();
                    populate();

                }
                catch (Exception Myex)
                {
                    MessageBox.Show(Myex.Message);
                }
            }

        }

        private void CarsDGV_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            RegNumTb.Text = CarsDGV.SelectedRows[0].Cells[0].Value.ToString();
            BrandTb.Text = CarsDGV.SelectedRows[0].Cells[1].Value.ToString();
            ModelTb.Text = CarsDGV.SelectedRows[0].Cells[2].Value.ToString();
            AvailableCb.SelectedItem = CarsDGV.SelectedRows[0].Cells[3].Value.ToString();
            PriceTb.Text = CarsDGV.SelectedRows[0].Cells[4].Value.ToString();
        }
       
        private void Car_Load(object sender, EventArgs e)
        {
            populate();
            
        }

        private void label1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            MainForm main = new MainForm();
            main.Show();
        }

        private void Search_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Car_InputLanguageChanging(object sender, InputLanguageChangingEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            populate();
        }

        private void Search_SelectionChangeCommitted(object sender, EventArgs e)
        {
            string flag = "";
            if (Search.SelectedItem.ToString() == "Avaoilable")
            {
                flag = "Yes";
            }
            else
            {
                flag = "No";
            }
            Con.Open();
            string query = "select * from CarTbl where Available = '"+flag+"'";
            SqlDataAdapter da = new SqlDataAdapter(query, Con);
            SqlCommandBuilder builder = new SqlCommandBuilder(da);
            var ds = new DataSet();
            da.Fill(ds);
            CarsDGV.DataSource = ds.Tables[0];
            Con.Close();
        }

        private void AvailableCb_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }
    }
}