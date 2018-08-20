<%@ Page Title="" Language="C#" MasterPageFile="~/ComplianceMaster.Master" AutoEventWireup="true" CodeBehind="InvestorDashboard.aspx.cs" Inherits="PrivateICO.InvestorDashboard" %>

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
            <div class="row">
                <!-- ./col -->



                <div class="col-lg-4 col-xs-6">
                    <!-- small box -->
                    <div class="small-box bg-gray">
                        <div class="inner">
                            <h3>Bitcoin</h3>
                            <p>
                                <asp:Label ID="lblBTCVal" runat="server" Text="0.00" CssClass="lblData" ></asp:Label></p>
                            <br />
                            <br />
                            <p>&nbsp;</p>
                        </div>
                        <div class="icon">
                            <i class="fa fa-dollar"></i>
                        </div>
                    </div>
                </div>

                <div class="col-lg-4 col-xs-6">
                    <!-- small box -->
                    <div class="small-box bg-purple">
                        <div class="inner">
                            <h3>Ether</h3>
                            <p>
                                <asp:Label ID="lblETHVal" runat="server" Text="0.00"  CssClass="lblData"></asp:Label></p>
                            <br />
                            <br />
                            <p>&nbsp;</p>
                        </div>
                        <div class="icon">
                            <i class="fa fa-dollar"></i>
                        </div>
                    </div>
                </div>
                <div class="col-lg-4 col-xs-6">
                    <!-- small box -->
                    <div class="small-box bg-red">
                        <div class="inner">
                            <h3>QTM</h3>
                            <p>
                                <asp:Label ID="lblQTMVal" runat="server" Text="0.00"  CssClass="lblData"></asp:Label></p>
                            <br />
                            <br />
                            <p>&nbsp;</p>

                           
                        </div>
                        <div class="icon">
                            <i class="fa fa-dollar"></i>
                        </div>
                    </div>
                </div>

                <div class="col-lg-4 col-xs-6">
                    <!-- small box -->
                    <div class="small-box bg-yellow">
                        <div class="inner">
                            <h3>Referral</h3>
                            <p>
                                <asp:Label ID="lblReferrals" runat="server" Text="0"  CssClass="lblData"></asp:Label></p>
                            <br />
                            <br />
                            <p>&nbsp;</p>
                        </div>
                        <div class="icon">
                            <i class="fa fa-dollar"></i>
                        </div>
                    </div>
                </div>

                <div class="col-lg-4 col-xs-6">
                    <!-- small box -->
                    <div class="small-box bg-green">
                        <div class="inner">
                            <h3>Max <br />Supply</h3>
                            <p>
                                <asp:Label ID="Label1" runat="server" Text="300 Million"  CssClass="lblData"></asp:Label></p>

                            <p>&nbsp;</p>
                        </div>
                        <div class="icon">
                            <i class="fa fa-dollar"></i>
                        </div>
                    </div>
                </div>

                <div class="col-lg-4 col-xs-6">
                    <!-- small box -->
                    <div class="small-box bg-aqua">
                        <div class="inner">
                            <h3>Referral<br /> Reward</h3>
                            <p>
                                <asp:Label ID="lblReferralEarning" runat="server" Text="0.00"  CssClass="lblData"></asp:Label></p>

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
