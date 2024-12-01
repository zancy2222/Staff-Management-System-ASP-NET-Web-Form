using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System;
using MySql.Data.MySqlClient;

namespace Staff_System.Admin
{
    public partial class UpdateEmployee : System.Web.UI.Page
    {
        string connStr = "server=localhost;user=root;database=awebform;port=3306;password=;";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                int employeeId = Convert.ToInt32(Request.QueryString["id"]);
                LoadEmployeeData(employeeId);
            }
        }

        // Load employee data based on ID
        private void LoadEmployeeData(int employeeId)
        {
            using (MySqlConnection conn = new MySqlConnection(connStr))
            {
                conn.Open();
                string query = "SELECT * FROM employees WHERE ID = @ID";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@ID", employeeId);
                MySqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    txtName.Text = reader["Name"].ToString();
                    txtContact.Text = reader["Contact"].ToString();
                    txtEmail.Text = reader["Email"].ToString();
                    txtPassword.Text = reader["Password"].ToString();
                    ddlStatus.SelectedValue = reader["Status"].ToString();
                }
            }
        }

        // Update employee data
        protected void btnUpdateEmployee_Click(object sender, EventArgs e)
        {
            int employeeId = Convert.ToInt32(Request.QueryString["id"]);
            string name = txtName.Text;
            string contact = txtContact.Text;
            string email = txtEmail.Text;
            string password = txtPassword.Text;
            string status = ddlStatus.SelectedValue;

            using (MySqlConnection conn = new MySqlConnection(connStr))
            {
                conn.Open();
                string query = "UPDATE employees SET Name = @Name, Contact = @Contact, Email = @Email, Password = @Password, Status = @Status WHERE ID = @ID";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Name", name);
                cmd.Parameters.AddWithValue("@Contact", contact);
                cmd.Parameters.AddWithValue("@Email", email);
                cmd.Parameters.AddWithValue("@Password", password);
                cmd.Parameters.AddWithValue("@Status", status);
                cmd.Parameters.AddWithValue("@ID", employeeId);

                cmd.ExecuteNonQuery();
            }

            Response.Redirect("Employee.aspx");
        }
    }
}
