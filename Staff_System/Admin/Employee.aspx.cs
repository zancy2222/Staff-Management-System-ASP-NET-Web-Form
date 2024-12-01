using System;
using System.Data;
using MySql.Data.MySqlClient;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Security.Cryptography;
using System.Text;

namespace Staff_System.Admin
{
    public partial class Employee : System.Web.UI.Page
    {
        string connStr = "server=localhost;user=root;database=awebform;port=3306;password=;";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindEmployeeData();
            }
        }
        private void BindEmployeeData()
        {
            using (MySqlConnection conn = new MySqlConnection(connStr))
            {
                conn.Open();
                string query = "SELECT ID, Name, Contact, Email, Status, Position FROM employees";  // Include 'Position'
                MySqlDataAdapter da = new MySqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                GridView1.DataSource = dt;
                GridView1.DataBind();
            }
        }


        protected void btnAddEmployee_Click(object sender, EventArgs e)
        {
            string name = txtNameModal.Text;
            string contact = txtContactModal.Text;
            string email = txtEmailModal.Text;
            string password = txtPasswordModal.Text;
            string status = ddlStatusModal.SelectedValue;
            string position = ddlPositionModal.SelectedValue;

            // Hash the password using SHA256
            string hashedPassword = HashPassword(password);

            using (MySqlConnection conn = new MySqlConnection(connStr))
            {
                conn.Open();
                string query = "INSERT INTO employees (Name, Contact, Email, Password, Status, Position) VALUES (@Name, @Contact, @Email, @Password, @Status, @Position)";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Name", name);
                cmd.Parameters.AddWithValue("@Contact", contact);
                cmd.Parameters.AddWithValue("@Email", email);
                cmd.Parameters.AddWithValue("@Password", hashedPassword);
                cmd.Parameters.AddWithValue("@Status", status);
                cmd.Parameters.AddWithValue("@Position", position);

                cmd.ExecuteNonQuery();
            }

            // Rebind the data to GridView after inserting
            BindEmployeeData();
        }


        // Method to hash the password
        private string HashPassword(string password)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] hashBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                StringBuilder sb = new StringBuilder();
                foreach (byte b in hashBytes)
                {
                    sb.Append(b.ToString("X2"));
                }
                return sb.ToString(); // Returns the hashed password
            }
        }

        // Handle the RowDeleting event to delete the employee
        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int employeeID = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Value);
            DeleteEmployee(employeeID);

            // Rebind the data to the GridView after deletion
            BindEmployeeData();
        }

        private void DeleteEmployee(int employeeID)
        {
            using (MySqlConnection conn = new MySqlConnection(connStr))
            {
                conn.Open();
                string query = "DELETE FROM employees WHERE ID = @ID";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@ID", employeeID);
                cmd.ExecuteNonQuery();
            }
        }
    }
}
