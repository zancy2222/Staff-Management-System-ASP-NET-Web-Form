<%@ Page Title="Attendance Records" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="AttendanceRecords.aspx.cs" Inherits="Staff_System.Admin.AttendanceRecords" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h3 class="text-primary mb-4">
        <i class="fas fa-history me-2"></i> Attendance Records
    </h3>

    <!-- Employee Dropdown -->
    <div class="mb-3">
        <label for="ddlEmployee" class="form-label">Select Employee</label>
        <asp:DropDownList ID="ddlEmployee" runat="server" class="form-control" OnSelectedIndexChanged="ddlEmployee_SelectedIndexChanged" AutoPostBack="true">
            <asp:ListItem Text="Select Employee" Value="" />
        </asp:DropDownList>
    </div>

    <!-- Attendance Records Table -->
    <div class="card shadow-lg border-0">
        <div class="card-body">
            <asp:GridView ID="gvAttendance" runat="server" CssClass="table table-bordered table-hover" AutoGenerateColumns="False">
                <Columns>
                    <asp:BoundField DataField="Date" HeaderText="Date" DataFormatString="{0:yyyy-MM-dd}" />
                    <asp:BoundField DataField="TimeIn" HeaderText="Time In" DataFormatString="{0:hh:mm tt}" />
                    <asp:BoundField DataField="TimeOut" HeaderText="Time Out" DataFormatString="{0:hh:mm tt}" />
                    <asp:BoundField DataField="TotalHours" HeaderText="Total Hours Worked" />
                </Columns>
            </asp:GridView>

            <!-- Total Hours Summary -->
            <div class="mt-3">
                <strong>Total Hours Worked: </strong>
                <asp:Label ID="lblTotalHours" runat="server" Text="0.00"></asp:Label>
            </div>
        </div>
    </div>
</asp:Content>
