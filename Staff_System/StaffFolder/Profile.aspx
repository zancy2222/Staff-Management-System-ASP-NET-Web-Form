<%@ Page Title="Staff Profile" Language="C#" MasterPageFile="~/StaffFolder/Staff.Master" AutoEventWireup="true" CodeBehind="Profile.aspx.cs" Inherits="Staff_System.StaffFolder.Profile" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h3 class="text-primary mb-4">
        <i class="fas fa-user-circle me-2"></i> My Profile
    </h3>
    <div class="card shadow-lg border-0">
        <div class="card-header bg-primary text-white">
            <h5 class="mb-0">
                <i class="fas fa-id-badge me-2"></i> Profile Details
            </h5>
        </div>
        <div class="card-body">
            <div class="row mb-3">
                <div class="col-md-6">
                    <p>
                        <i class="fas fa-user text-primary me-2"></i>
                        <strong>Name:</strong> <asp:Label ID="lblName" runat="server" CssClass="text-secondary"></asp:Label>
                    </p>
                </div>
                <div class="col-md-6">
                    <p>
                        <i class="fas fa-envelope text-primary me-2"></i>
                        <strong>Email:</strong> <asp:Label ID="lblEmail" runat="server" CssClass="text-secondary"></asp:Label>
                    </p>
                </div>
            </div>
            <div class="row mb-3">
                <div class="col-md-6">
                    <p>
                        <i class="fas fa-phone-alt text-primary me-2"></i>
                        <strong>Contact:</strong> <asp:Label ID="lblContact" runat="server" CssClass="text-secondary"></asp:Label>
                    </p>
                </div>
                <div class="col-md-6">
                    <p>
                        <i class="fas fa-user-check text-primary me-2"></i>
                        <strong>Status:</strong> <asp:Label ID="lblStatus" runat="server" CssClass="text-secondary"></asp:Label>
                    </p>
                </div>
            </div>
            <div class="row">
                <div class="col-md-6">
                    <p>
                        <i class="fas fa-briefcase text-primary me-2"></i>
                        <strong>Position:</strong> <asp:Label ID="lblPosition" runat="server" CssClass="text-secondary"></asp:Label>
                    </p>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
