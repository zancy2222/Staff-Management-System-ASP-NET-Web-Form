using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Web.UI;

namespace Staff_System.Admin
{
    public partial class AttendanceRecords : Page
    {
        string connStr = "server=localhost;user=root;database=awebform;port=3306;password=;";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadEmployees();  // Load employee names into the dropdown
            }
        }

        // Load employee names into the dropdown, excluding Admins
        private void LoadEmployees()
        {
            using (MySqlConnection conn = new MySqlConnection(connStr))
            {
                conn.Open();
                string query = "SELECT ID, Name FROM employees WHERE Status = 'Active' AND Position = 'Staff' ORDER BY Name";
                MySqlCommand cmd = new MySqlCommand(query, conn);

                using (MySqlDataAdapter adapter = new MySqlDataAdapter(cmd))
                {
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    ddlEmployee.DataSource = dt;
                    ddlEmployee.DataTextField = "Name";
                    ddlEmployee.DataValueField = "ID";
                    ddlEmployee.DataBind();
                }
            }
        }

        // Load attendance records for the selected employee
        private void LoadAttendanceRecords(int employeeId)
        {
            using (MySqlConnection conn = new MySqlConnection(connStr))
            {
                conn.Open();
                string query = @"
                    SELECT a.Date, a.TimeIn, a.TimeOut, a.TotalHours
                    FROM attendance a
                    WHERE a.EmployeeID = @EmployeeID
                    ORDER BY a.Date DESC";

                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@EmployeeID", employeeId);

                using (MySqlDataAdapter adapter = new MySqlDataAdapter(cmd))
                {
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    gvAttendance.DataSource = dt;
                    gvAttendance.DataBind();

                    // Sum the total hours worked
                    decimal totalHours = 0;
                    foreach (DataRow row in dt.Rows)
                    {
                        totalHours += Convert.ToDecimal(row["TotalHours"]);
                    }
                    lblTotalHours.Text = totalHours.ToString("0.00");
                }
            }
        }

        // Event handler for employee selection change
        protected void ddlEmployee_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(ddlEmployee.SelectedValue))
            {
                int employeeId = Convert.ToInt32(ddlEmployee.SelectedValue);
                LoadAttendanceRecords(employeeId);
            }
            else
            {
                gvAttendance.DataSource = null;
                gvAttendance.DataBind();
                lblTotalHours.Text = "0.00";
            }
        }
    }
}
