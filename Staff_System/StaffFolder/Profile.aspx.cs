using MySql.Data.MySqlClient;
using Org.BouncyCastle.Asn1.Cmp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;


namespace Staff_System.StaffFolder
{
    public partial class Profile : System.Web.UI.Page
    {
        string connStr = "server=localhost;user=root;database=awebform;port=3306;password=;";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadProfileDetails();
            }
        }

        private void LoadProfileDetails()
        {
            string userId = Session["UserID"]?.ToString(); // Retrieve the User ID from the session

            if (!string.IsNullOrEmpty(userId))
            {
                using (MySqlConnection conn = new MySqlConnection(connStr))
                {
                    conn.Open();
                    string query = "SELECT Name, Contact, Email, Status, Position FROM employees WHERE ID = @UserID";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@UserID", userId);

                    MySqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        lblName.Text = reader["Name"].ToString();
                        lblEmail.Text = reader["Email"].ToString();
                        lblContact.Text = reader["Contact"].ToString();
                        lblStatus.Text = reader["Status"].ToString();
                        lblPosition.Text = reader["Position"].ToString();
                    }
                }
            }
            else
            {
                Response.Redirect("~/Default.aspx"); // Redirect to login if session is null
            }
        }

    }
}
