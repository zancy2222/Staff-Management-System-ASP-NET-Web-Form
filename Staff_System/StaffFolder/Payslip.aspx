<%@ Page Title="Payslip" Language="C#" MasterPageFile="~/StaffFolder/Staff.Master" AutoEventWireup="true" CodeBehind="Payslip.aspx.cs" Inherits="Staff_System.StaffFolder.Payslip" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h3 class="text-primary mb-4">
        <i class="fas fa-file-invoice-dollar me-2"></i> My Payslips
    </h3>

    <div class="card shadow-lg border-0">
        <div class="card-body">
            <asp:GridView ID="gvPayslips" runat="server" CssClass="table table-bordered table-hover" AutoGenerateColumns="False">
                <Columns>
                    <asp:BoundField DataField="SalaryDate" HeaderText="Salary Date" DataFormatString="{0:yyyy-MM-dd}" />
                    <asp:BoundField DataField="TotalHours" HeaderText="Total Hours Worked" />
                    <asp:BoundField DataField="OvertimeHours" HeaderText="Overtime Hours" />
                    <asp:BoundField DataField="BasicSalary" HeaderText="Basic Salary" DataFormatString="{0:C}" />
                    <asp:BoundField DataField="OvertimePay" HeaderText="Overtime Pay" DataFormatString="{0:C}" />
                    <asp:BoundField DataField="TaxDeduction" HeaderText="Tax Deduction" DataFormatString="{0:C}" />
                    <asp:BoundField DataField="OtherDeductions" HeaderText="Other Deductions" DataFormatString="{0:C}" />
                    <asp:BoundField DataField="TotalSalary" HeaderText="Net Salary" DataFormatString="{0:C}" />
                </Columns>
            </asp:GridView>
        </div>
    </div>
</asp:Content>
