<%@ Page Title="Payslips" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="Payslips.aspx.cs" Inherits="Staff_System.Admin.Payslips" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h3 class="text-primary mb-4">
        <i class="fas fa-file-invoice-dollar me-2"></i> Generate Payslip
    </h3>

    <div class="card shadow-lg border-0">
        <div class="card-body">
            <div class="mb-3">
                <label for="ddlEmployee" class="form-label">Select Employee</label>
                <asp:DropDownList ID="ddlEmployee" runat="server" CssClass="form-control" AutoPostBack="True" OnSelectedIndexChanged="ddlEmployee_SelectedIndexChanged"></asp:DropDownList>
            </div>
            
            <div class="row">
                <div class="col-md-6">
                    <label for="txtTotalHours" class="form-label">Total Hours Worked</label>
                    <asp:TextBox ID="txtTotalHours" runat="server" CssClass="form-control" ReadOnly="True"></asp:TextBox>
                </div>
                <div class="col-md-6">
                    <label for="txtOvertimeHours" class="form-label">Overtime Hours</label>
                    <asp:TextBox ID="txtOvertimeHours" runat="server" CssClass="form-control" ReadOnly="True"></asp:TextBox>
                </div>
            </div>

            <div class="row mt-3">
                <div class="col-md-6">
                    <label for="txtBasicSalary" class="form-label">Basic Salary</label>
                    <asp:TextBox ID="txtBasicSalary" runat="server" CssClass="form-control" ReadOnly="True"></asp:TextBox>
                </div>
                <div class="col-md-6">
                    <label for="txtOvertimePay" class="form-label">Overtime Pay</label>
                    <asp:TextBox ID="txtOvertimePay" runat="server" CssClass="form-control" ReadOnly="True"></asp:TextBox>
                </div>
            </div>

            <div class="row mt-3">
                <div class="col-md-6">
                    <label for="txtTaxDeduction" class="form-label">Tax Deduction</label>
                    <asp:TextBox ID="txtTaxDeduction" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
                <div class="col-md-6">
                    <label for="txtOtherDeductions" class="form-label">Other Deductions</label>
                    <asp:TextBox ID="txtOtherDeductions" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
            </div>

            <div class="mt-3">
                <label for="txtTotalSalary" class="form-label">Total Salary</label>
                <asp:TextBox ID="txtTotalSalary" runat="server" CssClass="form-control" ReadOnly="True"></asp:TextBox>
            </div>

          
            <div class="mt-4 text-center">
                <asp:Button ID="btnSubmitPayslip" runat="server" Text="Submit Payslip" CssClass="btn btn-primary" OnClick="btnSubmitPayslip_Click" />
            </div>
        </div>
    </div>
</asp:Content>
