using MySql.Data.MySqlClient;
using System;

namespace Staff_System.StaffFolder
{
    public partial class Attendance : System.Web.UI.Page
    {
        string connStr = "server=localhost;user=root;database=awebform;port=3306;password=;";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadEmployeeInfo();
                CheckAttendanceStatus();
                LoadAttendanceRecords();
            }
        }

        private void LoadEmployeeInfo()
        {
            // Fetch the logged-in user's ID and name from the session
            if (Session["UserID"] != null)
            {
                int employeeId = Convert.ToInt32(Session["UserID"]);

                using (MySqlConnection conn = new MySqlConnection(connStr))
                {
                    conn.Open();
                    string query = "SELECT Name FROM employees WHERE ID = @EmployeeID";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@EmployeeID", employeeId);

                    MySqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        lblEmployee.Text = "Welcome, " + reader["Name"].ToString();
                    }
                }
            }
        }

        private void CheckAttendanceStatus()
        {
            int employeeId = Convert.ToInt32(Session["UserID"]);
            string today = DateTime.Now.ToString("yyyy-MM-dd");

            using (MySqlConnection conn = new MySqlConnection(connStr))
            {
                conn.Open();
                string query = "SELECT ID, TimeIn, TimeOut, TotalHours FROM attendance WHERE EmployeeID = @EmployeeID AND Date = @Today";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@EmployeeID", employeeId);
                cmd.Parameters.AddWithValue("@Today", today);

                MySqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    if (reader["TimeIn"] != DBNull.Value && reader["TimeOut"] == DBNull.Value)
                    {
                        btnTimeIn.Enabled = false; // Disable Time In button
                        btnTimeOut.Enabled = true; // Enable Time Out button
                        lblTotalHours.Text = "You have already checked in. Time out to log hours.";
                    }
                    else if (reader["TimeIn"] != DBNull.Value && reader["TimeOut"] != DBNull.Value)
                    {
                        lblTotalHours.Text = "Total Hours Worked: " + reader["TotalHours"].ToString() + " hours.";
                        btnTimeIn.Enabled = false;
                        btnTimeOut.Enabled = false;
                    }
                }
                else
                {
                    btnTimeIn.Enabled = true;
                    btnTimeOut.Enabled = false;
                }
            }
        }

        protected void btnTimeIn_Click(object sender, EventArgs e)
        {
            int employeeId = Convert.ToInt32(Session["UserID"]);
            string today = DateTime.Now.ToString("yyyy-MM-dd");
            DateTime timeIn = DateTime.Now;

            using (MySqlConnection conn = new MySqlConnection(connStr))
            {
                conn.Open();
                string query = "INSERT INTO attendance (EmployeeID, TimeIn, Date) VALUES (@EmployeeID, @TimeIn, @Date)";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@EmployeeID", employeeId);
                cmd.Parameters.AddWithValue("@TimeIn", timeIn);
                cmd.Parameters.AddWithValue("@Date", today);
                cmd.ExecuteNonQuery();
            }

            lblMessage.CssClass = "text-success";
            lblMessage.Text = "You have successfully checked in!";
            lblMessage.Visible = true;

            // Reload attendance status
            CheckAttendanceStatus();
        }

        protected void btnTimeOut_Click(object sender, EventArgs e)
        {
            int employeeId = Convert.ToInt32(Session["UserID"]);
            string today = DateTime.Now.ToString("yyyy-MM-dd");
            DateTime timeOut = DateTime.Now;

            using (MySqlConnection conn = new MySqlConnection(connStr))
            {
                conn.Open();
                string query = "UPDATE attendance SET TimeOut = @TimeOut, TotalHours = TIMESTAMPDIFF(HOUR, TimeIn, @TimeOut) WHERE EmployeeID = @EmployeeID AND Date = @Date";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@TimeOut", timeOut);
                cmd.Parameters.AddWithValue("@EmployeeID", employeeId);
                cmd.Parameters.AddWithValue("@Date", today);
                cmd.ExecuteNonQuery();
            }

            lblMessage.CssClass = "text-success";
            lblMessage.Text = "You have successfully checked out!";
            lblMessage.Visible = true;

            // Reload attendance status
            CheckAttendanceStatus();
        }

        private void LoadAttendanceRecords()
        {
            int employeeId = Convert.ToInt32(Session["UserID"]);

            using (MySqlConnection conn = new MySqlConnection(connStr))
            {
                conn.Open();
                string query = "SELECT e.Name AS EmployeeName, a.TimeIn, a.TimeOut, a.TotalHours, a.Date FROM attendance a JOIN employees e ON a.EmployeeID = e.ID WHERE a.EmployeeID = @EmployeeID ORDER BY a.Date DESC";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@EmployeeID", employeeId);

                MySqlDataReader reader = cmd.ExecuteReader();
                gvAttendanceRecords.DataSource = reader;
                gvAttendanceRecords.DataBind();
            }
        }
    }
}
