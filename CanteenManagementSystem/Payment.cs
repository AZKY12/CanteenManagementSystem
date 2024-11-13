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

namespace CanteenManagementSystem
{
    public partial class Payment : Form
    {
        public Payment()
        {
            InitializeComponent(); 
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            // Define the connection string
            string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=CMS_DB;Integrated Security=True";

            // Open a connection to the database
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();

                // Use a parameterized query to prevent SQL injection
                string query = "INSERT INTO paymentTable (PaymentId, CustomerName, Food1, Food2, Food3, PaymentMethod, Amount) VALUES (@PaymentId, @CustomerName, @Food1, @Food2, @Food3, @PaymentMethod, @Amount)";

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    // Add parameters with the values from text boxes
                    cmd.Parameters.AddWithValue("@PaymentId", int.Parse(textBox1.Text));
                    cmd.Parameters.AddWithValue("@CustomerName", textBox2.Text);
                    cmd.Parameters.AddWithValue("@Food1", textBox3.Text);
                    cmd.Parameters.AddWithValue("@Food2", textBox4.Text);
                    cmd.Parameters.AddWithValue("@Food3", textBox5.Text);
                    cmd.Parameters.AddWithValue("@PaymentMethod", textBox6.Text);
                    cmd.Parameters.AddWithValue("@Amount", decimal.Parse(textBox7.Text));

                    // Execute the command
                    cmd.ExecuteNonQuery();

                    // Inform the user of the successful operation
                    MessageBox.Show("Record Saved Successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            // Define the connection string
            string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=CMS_DB;Integrated Security=True";

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                string query = "SELECT * FROM paymentTable";

                using (SqlCommand cmd = new SqlCommand(query, con))
                using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                {
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dataGridView1.DataSource = dt;
                }
            }
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            textBox7.Text = "";
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            // Define the connection string
            string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=CMS_DB;Integrated Security=True";

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                string query = "UPDATE paymentTable SET CustomerName = @CustomerName, Food1 = @Food1, Food2 = @Food2, Food3 = @Food3, PaymentMethod = @PaymentMethod, Amount = @Amount WHERE PaymentId = @PaymentId";

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@PaymentId", int.Parse(textBox1.Text));
                    cmd.Parameters.AddWithValue("@CustomerName", textBox2.Text);
                    cmd.Parameters.AddWithValue("@Food1", textBox3.Text);
                    cmd.Parameters.AddWithValue("@Food2", textBox4.Text);
                    cmd.Parameters.AddWithValue("@Food3", textBox5.Text);
                    cmd.Parameters.AddWithValue("@PaymentMethod", textBox6.Text);
                    cmd.Parameters.AddWithValue("@Amount", decimal.Parse(textBox7.Text));

                    cmd.ExecuteNonQuery();
                }
            }

            MessageBox.Show("Record Updated Successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            // Define the connection string
            string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=CMS_DB;Integrated Security=True";

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                string query = "DELETE FROM paymentTable WHERE PaymentId = @PaymentId";

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@PaymentId", int.Parse(textBox1.Text));
                    cmd.ExecuteNonQuery();
                }
            }

            MessageBox.Show("Record Deleted Successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnDisplay_Click(object sender, EventArgs e)
        {
            // Define the connection string
            string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=CMS_DB;Integrated Security=True";

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                string query = "SELECT * FROM paymentTable";

                using (SqlCommand cmd = new SqlCommand(query, con))
                using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                {
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dataGridView1.DataSource = dt;
                }
            }
        }

        private void Payment_Load(object sender, EventArgs e)
        {
            MaximizeBox = false;
            ShowIcon = false;
        }
    }
}
