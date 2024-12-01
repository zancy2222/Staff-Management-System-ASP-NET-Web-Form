<%@ Page Title="Attendance" Language="C#" MasterPageFile="~/StaffFolder/Staff.Master" AutoEventWireup="true" CodeBehind="Attendance.aspx.cs" Inherits="Staff_System.StaffFolder.Attendance" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h3 class="text-primary mb-4">
        <i class="fas fa-calendar-check me-2"></i> Attendance
    </h3>
    
    <!-- Time In / Time Out Section -->
    <div class="card shadow-lg border-0">
        <div class="card-header bg-primary text-white">
            <h5 class="mb-0">
                <i class="fas fa-clock me-2"></i> Time In / Time Out
            </h5>
        </div>
        <div class="card-body">
            <asp:Label ID="lblMessage" runat="server" CssClass="text-success d-none"></asp:Label>

            <div class="mb-3">
                <asp:Label ID="lblEmployee" runat="server" CssClass="form-label"></asp:Label>
                <asp:Button ID="btnTimeIn" runat="server" Text="Time In" CssClass="btn btn-success" OnClick="btnTimeIn_Click" />
                <asp:Button ID="btnTimeOut" runat="server" Text="Time Out" CssClass="btn btn-danger" OnClick="btnTimeOut_Click" />
            </div>

            <div class="mb-3">
                <label for="lblTotalHours" class="form-label">Total Hours Worked</label>
                <asp:Label ID="lblTotalHours" runat="server" CssClass="form-control"></asp:Label>
            </div>
        </div>
    </div>

    <!-- Attendance History Table -->
    <div class="card shadow-lg border-0 mt-4">
        <div class="card-header bg-primary text-white">
            <h5 class="mb-0">
                <i class="fas fa-history me-2"></i> Attendance Records
            </h5>
        </div>
        <div class="card-body">
            <asp:GridView ID="gvAttendanceRecords" runat="server" CssClass="table table-bordered" AutoGenerateColumns="False">
                <Columns>
                    <asp:BoundField DataField="EmployeeName" HeaderText="Employee Name" SortExpression="EmployeeName" />
                    <asp:BoundField DataField="TimeIn" HeaderText="Time In" SortExpression="TimeIn" />
                    <asp:BoundField DataField="TimeOut" HeaderText="Time Out" SortExpression="TimeOut" />
                    <asp:BoundField DataField="TotalHours" HeaderText="Total Hours" SortExpression="TotalHours" />
                    <asp:BoundField DataField="Date" HeaderText="Date" SortExpression="Date" />
                </Columns>
            </asp:GridView>
        </div>
    </div>

</asp:Content>
