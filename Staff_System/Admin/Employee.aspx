<%@ Page Title="Employee" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="Employee.aspx.cs" Inherits="Staff_System.Admin.Employee" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h3 class="mb-4 text-center text-primary">Employee Management</h3>

    <!-- Add Employee Button -->
    <div class="d-flex justify-content-end mb-3">
        <button type="button" class="btn btn-success" data-bs-toggle="modal" data-bs-target="#employeeModal">Add Employee</button>
    </div>

    <!-- Employee Table -->
    <div class="card shadow-sm">
        <div class="card-body">
            <asp:GridView ID="GridView1" runat="server" CssClass="table table-striped" AutoGenerateColumns="False"
                DataKeyNames="ID" OnRowDeleting="GridView1_RowDeleting">
                <Columns>
                    <asp:BoundField DataField="Name" HeaderText="Name" SortExpression="Name" />
                    <asp:BoundField DataField="Contact" HeaderText="Contact" SortExpression="Contact" />
                    <asp:BoundField DataField="Email" HeaderText="Email" SortExpression="Email" />
                    <asp:BoundField DataField="Status" HeaderText="Status" SortExpression="Status" />
                    <asp:BoundField DataField="Position" HeaderText="Position" SortExpression="Position" />
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:LinkButton ID="lnkDelete" runat="server" CommandName="Delete" 
                                CommandArgument='<%# Eval("ID") %>' Text="Delete" CssClass="btn btn-danger btn-sm" 
                                OnClientClick="return confirm('Are you sure you want to delete this employee?');" />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>
    </div>

    <!-- Modal for Add Employee -->
    <div class="modal fade" id="employeeModal" tabindex="-1" aria-labelledby="employeeModalLabel" aria-hidden="true">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title" id="employeeModalLabel">Add Employee</h5>
                    <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
                </div>
                <div class="modal-body">
                    <!-- Add Employee Form -->
                    <div class="mb-3">
                        <label for="txtNameModal" class="form-label">Name</label>
                        <asp:TextBox ID="txtNameModal" runat="server" CssClass="form-control" />
                    </div>
                    <div class="mb-3">
                        <label for="txtContactModal" class="form-label">Contact</label>
                        <asp:TextBox ID="txtContactModal" runat="server" CssClass="form-control" />
                    </div>
                    <div class="mb-3">
                        <label for="txtEmailModal" class="form-label">Email</label>
                        <asp:TextBox ID="txtEmailModal" runat="server" CssClass="form-control" />
                    </div>
                    <div class="mb-3">
                        <label for="txtPasswordModal" class="form-label">Password</label>
                        <asp:TextBox ID="txtPasswordModal" runat="server" CssClass="form-control" TextMode="Password" />
                    </div>
                    <div class="mb-3">
                        <label for="ddlStatusModal" class="form-label">Status</label>
                        <asp:DropDownList ID="ddlStatusModal" runat="server" CssClass="form-select">
                            <asp:ListItem Text="Active" Value="Active"></asp:ListItem>
                            <asp:ListItem Text="Inactive" Value="Inactive"></asp:ListItem>
                        </asp:DropDownList>
                    </div>
                    <div class="mb-3">
                        <label for="ddlPositionModal" class="form-label">Position</label>
                        <asp:DropDownList ID="ddlPositionModal" runat="server" CssClass="form-select">
                            <asp:ListItem Text="Staff" Value="Staff"></asp:ListItem>
                            <asp:ListItem Text="Admin" Value="Admin"></asp:ListItem>
                        </asp:DropDownList>
                    </div>
                </div>
                <div class="modal-footer">
                    <asp:Button ID="btnSaveEmployee" runat="server" CssClass="btn btn-primary" Text="Save" OnClick="btnAddEmployee_Click" />
                    <button type="button" class="btn btn-secondary" data-bs-dismiss="modal">Close</button>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
