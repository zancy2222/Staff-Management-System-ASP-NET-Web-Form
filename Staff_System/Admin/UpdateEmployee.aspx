<%@ Page Title="Update Employee" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="UpdateEmployee.aspx.cs" Inherits="Staff_System.Admin.UpdateEmployee" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h3 class="mb-4 text-center text-primary">Update Employee</h3>

    <div class="card shadow-sm">
        <div class="card-body">
            <!-- Employee Form for Update -->
            <div class="mb-3">
                <label for="txtName" class="form-label">Name</label>
                <asp:TextBox ID="txtName" runat="server" CssClass="form-control" />
            </div>
            <div class="mb-3">
                <label for="txtContact" class="form-label">Contact</label>
                <asp:TextBox ID="txtContact" runat="server" CssClass="form-control" />
            </div>
            <div class="mb-3">
                <label for="txtEmail" class="form-label">Email</label>
                <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control" />
            </div>
            <div class="mb-3">
                <label for="txtPassword" class="form-label">Password</label>
                <asp:TextBox ID="txtPassword" runat="server" CssClass="form-control" TextMode="Password" />
            </div>
            <div class="mb-3">
                <label for="ddlStatus" class="form-label">Status</label>
                <asp:DropDownList ID="ddlStatus" runat="server" CssClass="form-select">
                    <asp:ListItem Text="Active" Value="Active"></asp:ListItem>
                    <asp:ListItem Text="Inactive" Value="Inactive"></asp:ListItem>
                </asp:DropDownList>
            </div>

            <asp:Button ID="btnUpdateEmployee" runat="server" CssClass="btn btn-primary" Text="Update" OnClick="btnUpdateEmployee_Click" />
        </div>
    </div>
</asp:Content>
