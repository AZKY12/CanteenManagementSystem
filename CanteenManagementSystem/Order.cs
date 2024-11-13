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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Data.SqlClient;


namespace CanteenManagementSystem
{
    public partial class Order : Form
    {
        public Order()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
        }

        private void Order_Load(object sender, EventArgs e)
        {
            MaximizeBox = false;
            ShowIcon = false;
        }

        private void dateTimePicker1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Back)
            {
                dateTimePicker1.CustomFormat = "";
            }
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
                string query = "INSERT INTO orderTable (OrderId, CustomerName, Food1, Food2, Food3, OrderDate) VALUES (@OrderId, @CustomerName, @Food1, @Food2, @Food3, @OrderDate)";

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    // Add parameters with the values from text boxes
                    cmd.Parameters.AddWithValue("@OrderId", int.Parse(textBox1.Text));
                    cmd.Parameters.AddWithValue("@CustomerName", textBox2.Text);
                    cmd.Parameters.AddWithValue("@Food1", textBox3.Text);
                    cmd.Parameters.AddWithValue("@Food2", textBox4.Text);
                    cmd.Parameters.AddWithValue("@Food3", textBox6.Text);
                    cmd.Parameters.AddWithValue("@OrderDate", DateTime.Parse(dateTimePicker1.Text));

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
                string query = "SELECT * FROM orderTable";

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
            textBox6.Text = "";
            dateTimePicker1.Text = "";
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            // Define the connection string
            string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=CMS_DB;Integrated Security=True";

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                string query = "UPDATE orderTable SET CustomerName = @CustomerName, Food1 = @Food1, Food2 = @Food2, Food3 = @Food3, OrderDate = @OrderDate WHERE OrderId = @OrderId";

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@OrderId", int.Parse(textBox1.Text));
                    cmd.Parameters.AddWithValue("@CustomerName", textBox2.Text);
                    cmd.Parameters.AddWithValue("@Food1", textBox3.Text);
                    cmd.Parameters.AddWithValue("@Food2", textBox4.Text);
                    cmd.Parameters.AddWithValue("@Food3", textBox6.Text);
                    cmd.Parameters.AddWithValue("@OrderDate", DateTime.Parse(dateTimePicker1.Text));

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
                string query = "DELETE FROM orderTable WHERE OrderId = @OrderId";

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@OrderId", int.Parse(textBox1.Text));
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
                string query = "SELECT * FROM orderTable";

                using (SqlCommand cmd = new SqlCommand(query, con))
                using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                {
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dataGridView1.DataSource = dt;
                }
            }
        }

    }
}
