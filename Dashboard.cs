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
    public partial class Dashboard : Form
    {
        SqlConnection Con;
        public Dashboard()
        {
            Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Gabriela&Marco\Documents\CarRentaldb.mdf;Integrated Security=True;Connect Timeout=30");

            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Dashboard_Load(object sender, EventArgs e)
        {
            string querycar = "select Count(*) from CarTbl";
            SqlDataAdapter sda = new SqlDataAdapter(querycar, Con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            CarLbl.Text = dt.Rows[0][0].ToString();

            string querycust = "select Count(*) from CustomerTbl";
            SqlDataAdapter sda1 = new SqlDataAdapter(querycust, Con);
            DataTable dt1 = new DataTable();
            sda1.Fill(dt1);
            CustLbl.Text = dt1.Rows[0][0].ToString();

            string queryuser = "select Count(*) from UserTbl";
            SqlDataAdapter sda2 = new SqlDataAdapter(queryuser, Con);
            DataTable dt2 = new DataTable();
            sda2.Fill(dt2);
            UserLbl.Text = dt2.Rows[0][0].ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            MainForm main = new MainForm();
            main.Show();
        }

        private void CarLbl_Click(object sender, EventArgs e)
        {

        }
    }
}
