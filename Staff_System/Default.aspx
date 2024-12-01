<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Staff_System.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container d-flex justify-content-center align-items-center" style="height: 100vh;">
        <div class="card shadow-lg" style="max-width: 300px; width: 100%;">
            <div class="card-header text-center">
                <h3 class="mb-0 text-primary">Login</h3>
            </div>
            <div class="card-body">
                <asp:Label ID="lblError" runat="server" CssClass="text-danger" Visible="false" Text="Invalid email or password"></asp:Label>
                
                <!-- Email Input Field -->
                <div class="mb-3">
                    <label for="txtEmail" class="form-label">Email</label>
                    <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control form-control-lg" placeholder="Enter your email" />
                </div>

                <!-- Password Input Field -->
                <div class="mb-3">
                    <label for="txtPassword" class="form-label">Password</label>
                    <asp:TextBox ID="txtPassword" runat="server" CssClass="form-control form-control-lg" TextMode="Password" placeholder="Enter your password" />
                </div>

                <!-- Login Button -->
                <div class="mb-3">
                    <asp:Button ID="btnLogin" runat="server" CssClass="btn btn-primary w-100 btn-lg" Text="Login" OnClick="btnLogin_Click" />
                </div>
            </div>
        </div>
    </div>
</asp:Content>
