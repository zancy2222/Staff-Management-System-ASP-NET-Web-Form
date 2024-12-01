<%@ Page Title="Leave Request" Language="C#" MasterPageFile="~/StaffFolder/Staff.Master" AutoEventWireup="true" CodeBehind="LeaveRequest.aspx.cs" Inherits="Staff_System.StaffFolder.LeaveRequest" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h3 class="text-primary mb-4">
        <i class="fas fa-calendar-alt me-2"></i> Leave Request
    </h3>
    <div class="card shadow-lg border-0">
        <div class="card-header bg-primary text-white">
            <h5 class="mb-0">
                <i class="fas fa-paper-plane me-2"></i> Submit Your Leave Request
            </h5>
        </div>
        <div class="card-body">
            <asp:Label ID="lblMessage" runat="server" CssClass="text-success d-none"></asp:Label>
            <div class="mb-3">
                <label for="ddlLeaveType" class="form-label"><i class="fas fa-list me-2"></i> Leave Type</label>
                <asp:DropDownList ID="ddlLeaveType" runat="server" CssClass="form-select">
                    <asp:ListItem Text="Select Leave Type" Value="" />
                    <asp:ListItem Text="Sick Leave" Value="Sick Leave" />
                    <asp:ListItem Text="Vacation Leave" Value="Vacation Leave" />
                    <asp:ListItem Text="Emergency Leave" Value="Emergency Leave" />
                </asp:DropDownList>
            </div>
            <div class="row mb-3">
                <div class="col-md-6">
                    <label for="txtStartDate" class="form-label"><i class="fas fa-calendar-day me-2"></i> Start Date</label>
                    <asp:TextBox ID="txtStartDate" runat="server" CssClass="form-control" Type="date"></asp:TextBox>
                </div>
                <div class="col-md-6">
                    <label for="txtEndDate" class="form-label"><i class="fas fa-calendar-day me-2"></i> End Date</label>
                    <asp:TextBox ID="txtEndDate" runat="server" CssClass="form-control" Type="date"></asp:TextBox>
                </div>
            </div>
            <div class="mb-3">
                <label for="txtReason" class="form-label"><i class="fas fa-edit me-2"></i> Reason</label>
                <asp:TextBox ID="txtReason" runat="server" CssClass="form-control" TextMode="MultiLine" Rows="4"></asp:TextBox>
            </div>
            <asp:Button ID="btnSubmit" runat="server" Text="Submit Request" CssClass="btn btn-primary" OnClick="btnSubmit_Click" />
            
            <!-- Display leave request status -->
            <div class="mt-4">
                <h5>Your Leave Request Status:</h5>
                <asp:Label ID="lblStatus" runat="server" CssClass="text-info"></asp:Label>
            </div>
        </div>
    </div>
</asp:Content>
