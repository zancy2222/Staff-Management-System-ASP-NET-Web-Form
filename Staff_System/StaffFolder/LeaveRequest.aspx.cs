using MySql.Data.MySqlClient;
using System;
using System.Web;

namespace Staff_System.StaffFolder
{
    public partial class LeaveRequest : System.Web.UI.Page
    {
        string connStr = "server=localhost;user=root;database=awebform;port=3306;password=;";

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            string leaveType = ddlLeaveType.SelectedValue;
            string startDate = txtStartDate.Text;
            string endDate = txtEndDate.Text;
            string reason = txtReason.Text;

            // Fetch the logged-in user's ID from the session
            int employeeId;
            if (Session["UserID"] != null && int.TryParse(Session["UserID"].ToString(), out employeeId))
            {
                if (string.IsNullOrWhiteSpace(leaveType) || string.IsNullOrWhiteSpace(startDate) ||
                    string.IsNullOrWhiteSpace(endDate) || string.IsNullOrWhiteSpace(reason))
                {
                    lblMessage.CssClass = "text-danger";
                    lblMessage.Text = "All fields are required.";
                    lblMessage.Visible = true;
                    return;
                }

                // Check if the employee already has a pending request
                using (MySqlConnection conn = new MySqlConnection(connStr))
                {
                    conn.Open();
                    string checkQuery = "SELECT COUNT(*) FROM leave_requests WHERE EmployeeID = @EmployeeID AND Status = 'Pending'";
                    MySqlCommand checkCmd = new MySqlCommand(checkQuery, conn);
                    checkCmd.Parameters.AddWithValue("@EmployeeID", employeeId);
                    int pendingRequestCount = Convert.ToInt32(checkCmd.ExecuteScalar());

                    if (pendingRequestCount > 0)
                    {
                        lblMessage.CssClass = "text-warning";
                        lblMessage.Text = "You already have a pending leave request.";
                        lblMessage.Visible = true;
                        return;
                    }

                    // Save the leave request with default 'Pending' status
                    string query = "INSERT INTO leave_requests (EmployeeID, LeaveType, StartDate, EndDate, Reason, Status) " +
                                   "VALUES (@EmployeeID, @LeaveType, @StartDate, @EndDate, @Reason, 'Pending')";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@EmployeeID", employeeId);
                    cmd.Parameters.AddWithValue("@LeaveType", leaveType);
                    cmd.Parameters.AddWithValue("@StartDate", startDate);
                    cmd.Parameters.AddWithValue("@EndDate", endDate);
                    cmd.Parameters.AddWithValue("@Reason", reason);

                    int result = cmd.ExecuteNonQuery();
                    if (result > 0)
                    {
                        lblMessage.CssClass = "text-success";
                        lblMessage.Text = "Leave request submitted successfully. Status: Pending.";
                    }
                    else
                    {
                        lblMessage.CssClass = "text-danger";
                        lblMessage.Text = "An error occurred while submitting your request.";
                    }
                    lblMessage.Visible = true;
                }
            }
            else
            {
                // Redirect to login page if the session is missing
                Response.Redirect("~/Default.aspx");
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Ensure session is valid
                if (Session["UserID"] == null)
                {
                    Response.Redirect("~/Default.aspx");
                }
                else
                {
                    // Display the status of the existing leave request
                    int employeeId = Convert.ToInt32(Session["UserID"]);
                    using (MySqlConnection conn = new MySqlConnection(connStr))
                    {
                        conn.Open();
                        string query = "SELECT Status FROM leave_requests WHERE EmployeeID = @EmployeeID ORDER BY ID DESC LIMIT 1";
                        MySqlCommand cmd = new MySqlCommand(query, conn);
                        cmd.Parameters.AddWithValue("@EmployeeID", employeeId);
                        var status = cmd.ExecuteScalar();

                        if (status != null)
                        {
                            lblStatus.Text = "Your last leave request status: " + status.ToString();
                        }
                        else
                        {
                            lblStatus.Text = "You have not submitted any leave requests yet.";
                        }
                    }
                }
            }
        }
    }
}
