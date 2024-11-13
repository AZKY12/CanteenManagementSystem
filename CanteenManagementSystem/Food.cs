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
using MongoDB.Driver.Core.Configuration;


namespace CanteenManagementSystem
{
    public partial class Food : Form
    {
        public Food()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Define the connection string
            string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=CMS_DB;Integrated Security=True";

            // Open a connection to the database
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();

                // Use a parameterized query to prevent SQL injection
                string query = "INSERT INTO foodTable (FoodId, FoodName, Price, Quantity, Status) VALUES (@FoodId, @FoodName, @Price, @Quantity, @Status)";

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    // Add parameters with the values from text boxes
                    cmd.Parameters.AddWithValue("@FoodId", int.Parse(textBox1.Text));
                    cmd.Parameters.AddWithValue("@FoodName", textBox2.Text);
                    cmd.Parameters.AddWithValue("@Price", decimal.Parse(textBox3.Text));
                    cmd.Parameters.AddWithValue("@Quantity", int.Parse(textBox4.Text));
                    cmd.Parameters.AddWithValue("@Status", textBox5.Text);

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
                string query = "SELECT * FROM foodTable";

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
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            // Define the connection string
            string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=CMS_DB;Integrated Security=True";


            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                string query = "UPDATE foodTable SET foodname = @foodname, price = @price, quantity = @quantity, status = @status WHERE foodid = @foodid";

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@foodid", int.Parse(textBox1.Text));
                    cmd.Parameters.AddWithValue("@foodname", textBox2.Text);
                    cmd.Parameters.AddWithValue("@price", textBox3.Text);
                    cmd.Parameters.AddWithValue("@quantity", textBox4.Text);
                    cmd.Parameters.AddWithValue("@status", textBox5.Text);

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
                string query = "DELETE FROM foodTable WHERE foodid = @foodid";

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@foodid", int.Parse(textBox1.Text));
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
                string query = "SELECT * FROM foodTable";

                using (SqlCommand cmd = new SqlCommand(query, con))
                using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                {
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dataGridView1.DataSource = dt;
                }
            }

        }

        private void Food_Load(object sender, EventArgs e)
        {
            MaximizeBox = false;
            ShowIcon = false;
        }
    }
}
