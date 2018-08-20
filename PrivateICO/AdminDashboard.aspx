<%@ Page Title="" Language="C#" MasterPageFile="~/AdminMaster.Master" AutoEventWireup="true" CodeBehind="AdminDashboard.aspx.cs" Inherits="PrivateICO.AdminDashboard" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <style>
        .lblData {
        font-size:xx-large;
        }
    </style>
    <div class="content-wrapper" style="min-height: 1819px;">
        <!-- Content Header (Page header) -->
        <section class="content-header">
            <h1 id="pageTitle">Dashboard</h1>
            <!-- You can dynamically generate breadcrumbs here -->
        </section>
        <section class="content">
            <div class="row" runat="server" id="dashboard">
                <div class="col-lg-4 col-xs-6">
                    <!-- small box -->
                    <div class="small-box bg-gray">
                        <div class="inner">
                            <h3>Target Achieved</h3>
                            <p>
                                <asp:Label ID="lblTargetAchieved" runat="server" Text="0.00" CssClass="lblData" ></asp:Label></p>
                            <br />
                            <br />
                            <p>&nbsp;</p>
                        </div>
                        <div class="icon">
                            <i class="fa fa-dollar"></i>
                        </div>
                    </div>
                </div>
            </div>
        </section>
    </div>
</asp:Content>
