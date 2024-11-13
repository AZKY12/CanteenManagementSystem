using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace CanteenManagementSystem
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            MaximizeBox = false;
            MinimizeBox = false;
            ShowIcon = false;
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
                string query = "SELECT Username, Password FROM [Table] WHERE Username = @Username AND Password = @Password";

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    // Add parameters for Username and Password
                    cmd.Parameters.AddWithValue("@Username", txtUsername.Text);
                    cmd.Parameters.AddWithValue("@Password", txtPassword.Text);

                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        da.Fill(dt);

                        if (dt.Rows.Count > 0)
                        {
                            Main mn = new Main();
                            mn.Show();
                            this.Hide();
                        }
                        else
                        {
                            MessageBox.Show("Invalid username or password");
                        }
                    }
                }
            }
        }
    }
}
