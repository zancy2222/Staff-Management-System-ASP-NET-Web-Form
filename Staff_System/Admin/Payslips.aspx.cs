using MySql.Data.MySqlClient;
using System;

namespace Staff_System.Admin
{
    public partial class Payslips : System.Web.UI.Page
    {
        string connStr = "server=localhost;user=root;database=awebform;port=3306;password=;";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadEmployees();
            }
        }

        private void LoadEmployees()
        {
            using (MySqlConnection conn = new MySqlConnection(connStr))
            {
                conn.Open();
                string query = "SELECT ID, Name FROM employees WHERE Status = 'Active' AND Position != 'Admin'";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                MySqlDataReader reader = cmd.ExecuteReader();

                ddlEmployee.DataSource = reader;
                ddlEmployee.DataTextField = "Name";
                ddlEmployee.DataValueField = "ID";
                ddlEmployee.DataBind();

                ddlEmployee.Items.Insert(0, new System.Web.UI.WebControls.ListItem("Select Employee", "0"));
            }
        }


        protected void ddlEmployee_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlEmployee.SelectedValue != "0")
            {
                CalculatePayslip(int.Parse(ddlEmployee.SelectedValue));
            }
        }

        private void CalculatePayslip(int employeeId)
        {
            const decimal basicSalary = 25000;
            const decimal perDaySalary = 1000;
            const decimal overtimeRate = 125;

            using (MySqlConnection conn = new MySqlConnection(connStr))
            {
                conn.Open();
                string query = @"SELECT SUM(TotalHours) AS TotalHours FROM attendance WHERE EmployeeID = @EmployeeID";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@EmployeeID", employeeId);

                object result = cmd.ExecuteScalar();
                decimal totalHours = result != DBNull.Value ? Convert.ToDecimal(result) : 0;
                decimal overtimeHours = totalHours > 8 ? totalHours - (int)(totalHours / 8) * 8 : 0;

                decimal totalDaysWorked = Math.Floor(totalHours / 8);
                decimal basicSalaryEarned = totalDaysWorked * perDaySalary;
                decimal overtimePay = overtimeHours * overtimeRate;

                // Display calculated values in UI
                txtTotalHours.Text = totalHours.ToString();
                txtOvertimeHours.Text = overtimeHours.ToString();
                txtBasicSalary.Text = basicSalaryEarned.ToString("0.00");
                txtOvertimePay.Text = overtimePay.ToString("0.00");

                // Calculate total salary
                decimal taxDeduction = string.IsNullOrEmpty(txtTaxDeduction.Text) ? 0 : Convert.ToDecimal(txtTaxDeduction.Text);
                decimal otherDeductions = string.IsNullOrEmpty(txtOtherDeductions.Text) ? 0 : Convert.ToDecimal(txtOtherDeductions.Text);
                decimal totalSalary = (basicSalaryEarned + overtimePay) - (taxDeduction + otherDeductions);

                txtTotalSalary.Text = totalSalary.ToString("0.00");
            }
        }

        protected void btnSubmitPayslip_Click(object sender, EventArgs e)
        {
            if (ddlEmployee.SelectedValue == "0")
            {
                Response.Write("<script>alert('Please select an employee.');</script>");
                return;
            }

            using (MySqlConnection conn = new MySqlConnection(connStr))
            {
                conn.Open();
                string query = @"INSERT INTO salary_records 
                        (EmployeeID, TotalHours, OvertimeHours, BasicSalary, OvertimePay, TaxDeduction, OtherDeductions, TotalSalary) 
                        VALUES 
                        (@EmployeeID, @TotalHours, @OvertimeHours, @BasicSalary, @OvertimePay, @TaxDeduction, @OtherDeductions, @TotalSalary)";
                MySqlCommand cmd = new MySqlCommand(query, conn);

                cmd.Parameters.AddWithValue("@EmployeeID", ddlEmployee.SelectedValue);
                cmd.Parameters.AddWithValue("@TotalHours", txtTotalHours.Text);
                cmd.Parameters.AddWithValue("@OvertimeHours", txtOvertimeHours.Text);
                cmd.Parameters.AddWithValue("@BasicSalary", txtBasicSalary.Text);
                cmd.Parameters.AddWithValue("@OvertimePay", txtOvertimePay.Text);
                cmd.Parameters.AddWithValue("@TaxDeduction", string.IsNullOrEmpty(txtTaxDeduction.Text) ? 0 : Convert.ToDecimal(txtTaxDeduction.Text));
                cmd.Parameters.AddWithValue("@OtherDeductions", string.IsNullOrEmpty(txtOtherDeductions.Text) ? 0 : Convert.ToDecimal(txtOtherDeductions.Text));
                cmd.Parameters.AddWithValue("@TotalSalary", txtTotalSalary.Text);

                cmd.ExecuteNonQuery();
                Response.Write("<script>alert('Payslip submitted successfully!');</script>");
            }
        }

    }
}
