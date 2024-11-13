using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;


namespace CanteenManagementSystem
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Food fd = new Food();
            fd.TopLevel = false;
            this.Controls.Add(fd);
            fd.Dock = DockStyle.Bottom;
            fd.Show();
        }

        private void Main_Load(object sender, EventArgs e)
        {
            MaximizeBox = false;
            MinimizeBox = false;
            ShowIcon = false;

            // Define the connection string
            string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=CMS_DB;Integrated Security=True";

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();

                // Get food count
                string queryFood = "SELECT COUNT(*) FROM foodTable";
                using (SqlCommand cmdFood = new SqlCommand(queryFood, con))
                {
                    int foodCount = (int)cmdFood.ExecuteScalar();
                    label5.Text = "" + foodCount;
                }

                // Get customer count
                string queryCustomer = "SELECT COUNT(*) FROM customerTable";
                using (SqlCommand cmdCustomer = new SqlCommand(queryCustomer, con))
                {
                    int customerCount = (int)cmdCustomer.ExecuteScalar();
                    label6.Text = "" + customerCount;
                }

                // Get order count
                string queryOrder = "SELECT COUNT(*) FROM orderTable";
                using (SqlCommand cmdOrder = new SqlCommand(queryOrder, con))
                {
                    int orderCount = (int)cmdOrder.ExecuteScalar();
                    label7.Text = "" + orderCount;
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Customer cs = new Customer();
            cs.TopLevel = false;
            this.Controls.Add(cs);
            cs.Dock = DockStyle.Bottom;
            cs.Show();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Order odr = new Order();
            odr.TopLevel = false;
            this.Controls.Add(odr);
            odr.Dock = DockStyle.Bottom;
            odr.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Payment pym = new Payment();
            pym.TopLevel = false;
            this.Controls.Add(pym);
            pym.Dock = DockStyle.Bottom;
            pym.Show();
        }
    }
}
