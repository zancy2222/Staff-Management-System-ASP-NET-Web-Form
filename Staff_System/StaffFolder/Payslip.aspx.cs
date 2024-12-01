using MySql.Data.MySqlClient;
using Staff_System.Admin;
using System;
using System.Data;
using System.Web.UI;

namespace Staff_System.StaffFolder
{
    public partial class Payslip : Page
    {
        string connStr = "server=localhost;user=root;database=awebform;port=3306;password=;";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadPayslips();
            }
        }

        private void LoadPayslips()
        {
            // Ensure the user is logged in and has an ID stored in the session
            if (Session["UserID"] == null)
            {
                Response.Redirect("../Default.aspx");
                return;
            }

            int userId = int.Parse(Session["UserID"].ToString());

            using (MySqlConnection conn = new MySqlConnection(connStr))
            {
                conn.Open();
                string query = @"
                    SELECT SalaryDate, TotalHours, OvertimeHours, BasicSalary, 
                           OvertimePay, TaxDeduction, OtherDeductions, TotalSalary
                    FROM salary_records
                    WHERE EmployeeID = @EmployeeID
                    ORDER BY SalaryDate DESC";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@EmployeeID", userId);

                using (MySqlDataAdapter adapter = new MySqlDataAdapter(cmd))
                {
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    gvPayslips.DataSource = dt;
                    gvPayslips.DataBind();
                }
            }
        }
    }
}
