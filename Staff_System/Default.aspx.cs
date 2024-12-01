using MySql.Data.MySqlClient;
using System;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Staff_System
{
    public partial class Default : System.Web.UI.Page
    {
        string connStr = "server=localhost;user=root;database=awebform;port=3306;password=;";

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            string email = txtEmail.Text;
            string password = txtPassword.Text; // Plain password entered by the user

            using (MySqlConnection conn = new MySqlConnection(connStr))
            {
                conn.Open();
                string query = "SELECT ID, Position, Password FROM employees WHERE Email = @Email";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Email", email);

                MySqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    // Retrieve the hashed password stored in the database
                    string storedHashedPassword = reader["Password"].ToString();
                    string position = reader["Position"].ToString();
                    string id = reader["ID"].ToString();

                    // Hash the entered password and compare it with the stored password
                    string hashedPassword = HashPassword(password);

                    if (hashedPassword == storedHashedPassword)
                    {
                        // Store user details in Session
                        Session["UserID"] = id; // Store the ID
                        Session["Email"] = email; // Store the Email

                        // Redirect based on Position
                        if (position == "Admin")
                        {
                            Response.Redirect("~/Admin/Employee.aspx");
                        }
                        else if (position == "Staff")
                        {
                            Response.Redirect("~/StaffFolder/Profile.aspx");
                        }
                        else
                        {
                            lblError.Text = "Invalid position.";
                            lblError.Visible = true;
                        }
                    }
                    else
                    {
                        lblError.Text = "Invalid email or password.";
                        lblError.Visible = true;
                    }
                }
                else
                {
                    lblError.Text = "Invalid email or password.";
                    lblError.Visible = true;
                }
            }
        }


        // Method to hash the password (SHA256)
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
    }
}
