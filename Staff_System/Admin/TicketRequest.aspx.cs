using MySql.Data.MySqlClient;
using System;
using System.Web.UI.WebControls;

namespace Staff_System.Admin
{
    public partial class TicketRequest : System.Web.UI.Page
    {
        string connStr = "server=localhost;user=root;database=awebform;port=3306;password=;";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadLeaveRequests();
            }
        }

        private void LoadLeaveRequests()
        {
            using (MySqlConnection conn = new MySqlConnection(connStr))
            {
                conn.Open();
                string query = @"
                    SELECT lr.ID, e.Name, lr.LeaveType, lr.StartDate, lr.EndDate, lr.Reason, lr.Status
                    FROM leave_requests lr
                    INNER JOIN employees e ON lr.EmployeeID = e.ID
                    WHERE lr.Status = 'Pending'";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                MySqlDataReader reader = cmd.ExecuteReader();
                gvLeaveRequests.DataSource = reader;
                gvLeaveRequests.DataBind();
            }
        }

        protected void gvLeaveRequests_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int leaveRequestId = Convert.ToInt32(e.CommandArgument);
            string status = e.CommandName == "Approve" ? "Approved" : "Declined";

            using (MySqlConnection conn = new MySqlConnection(connStr))
            {
                conn.Open();
                string query = "UPDATE leave_requests SET Status = @Status WHERE ID = @LeaveRequestID";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Status", status);
                cmd.Parameters.AddWithValue("@LeaveRequestID", leaveRequestId);
                cmd.ExecuteNonQuery();
            }

            // Reload the requests after approval or decline
            LoadLeaveRequests();
        }
    }
}
