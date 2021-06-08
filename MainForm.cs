using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace BookACar
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Car car = new Car();
            car.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            Customer customer = new Customer();
            customer.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Rental rent = new Rental();
            rent.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Return ret = new Return();
            ret.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            Users user = new Users();
            user.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            this.Hide();
            Dashboard board = new Dashboard();
            board.Show();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }
    }
}
