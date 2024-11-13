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
    public partial class Customer : Form
    {
        public Customer()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
        }

        private void label4_Click(object sender, EventArgs e)
        {

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
                string query = "INSERT INTO customerTable (CustomerId, CustomerName, ContactNumber, Email) VALUES (@CustomerId, @CustomerName, @ContactNumber, @Email)";

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    // Add parameters with the values from text boxes
                    cmd.Parameters.AddWithValue("@CustomerId", int.Parse(textBox1.Text));
                    cmd.Parameters.AddWithValue("@CustomerName", textBox2.Text);
                    cmd.Parameters.AddWithValue("@ContactNumber", textBox3.Text);
                    cmd.Parameters.AddWithValue("@Email", textBox4.Text);

                    // Execute the command
                    cmd.ExecuteNonQuery();

                    // Inform the user of the successful operation
                    MessageBox.Show("Record Saved Successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }

        }

        private void btnAdd_Click_1(object sender, EventArgs e)
        {
            // Define the connection string
            string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=CMS_DB;Integrated Security=True";

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                string query = "SELECT * FROM customerTable";

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
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            // Define the connection string
            string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=CMS_DB;Integrated Security=True";

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                string query = "UPDATE customerTable SET CustomerName = @CustomerName, ContactNumber = @ContactNumber, Email = @Email WHERE CustomerId = @CustomerId";

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@CustomerId", int.Parse(textBox1.Text));
                    cmd.Parameters.AddWithValue("@CustomerName", textBox2.Text);
                    cmd.Parameters.AddWithValue("@ContactNumber", textBox3.Text);
                    cmd.Parameters.AddWithValue("@Email", textBox4.Text);

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
                string query = "DELETE FROM customerTable WHERE CustomerId = @CustomerId";

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@CustomerId", int.Parse(textBox1.Text));
                    cmd.ExecuteNonQuery();
                }
            }

            MessageBox.Show("Record Deleted Successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }


        private void btnDisplay_Click_1(object sender, EventArgs e)
        {
            // Define the connection string
            string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=CMS_DB;Integrated Security=True";

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                string query = "SELECT * FROM customerTable";

                using (SqlCommand cmd = new SqlCommand(query, con))
                using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                {
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dataGridView1.DataSource = dt;
                }
            }
        }

        private void Customer_Load(object sender, EventArgs e)
        {
            MaximizeBox = false;
            ShowIcon = false;
        }
    }
}
