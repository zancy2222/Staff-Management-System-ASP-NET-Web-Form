<%@ Page Title="TicketRequest" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="TicketRequest.aspx.cs" Inherits="Staff_System.Admin.TicketRequest" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h3 class="text-primary mb-4">
        <i class="fas fa-ticket-alt me-2"></i> Ticket Request
    </h3>
    <div class="card shadow-lg border-0">
        <div class="card-header bg-primary text-white">
            <h5 class="mb-0">
                <i class="fas fa-list me-2"></i> Employee Leave Requests
            </h5>
        </div>
        <div class="card-body">
            <asp:GridView ID="gvLeaveRequests" runat="server" CssClass="table table-bordered" AutoGenerateColumns="False" OnRowCommand="gvLeaveRequests_RowCommand">
                <Columns>
                    <asp:BoundField DataField="Name" HeaderText="Employee Name" SortExpression="Name" />
                    <asp:BoundField DataField="LeaveType" HeaderText="Leave Type" SortExpression="LeaveType" />
                    <asp:BoundField DataField="StartDate" HeaderText="Start Date" SortExpression="StartDate" />
                    <asp:BoundField DataField="EndDate" HeaderText="End Date" SortExpression="EndDate" />
                    <asp:BoundField DataField="Reason" HeaderText="Reason" SortExpression="Reason" />
                    <asp:TemplateField HeaderText="Action">
                        <ItemTemplate>
                            <asp:Button ID="btnApprove" runat="server" CommandName="Approve" CommandArgument='<%# Eval("ID") %>' Text="Approve" CssClass="btn btn-success btn-sm" />
                            <asp:Button ID="btnDecline" runat="server" CommandName="Decline" CommandArgument='<%# Eval("ID") %>' Text="Decline" CssClass="btn btn-danger btn-sm" />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>
    </div>
</asp:Content>
