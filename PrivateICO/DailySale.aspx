<%@ Page Title="" Language="C#" MasterPageFile="~/ComplianceMaster.Master" AutoEventWireup="true" CodeBehind="DailySale.aspx.cs" Inherits="PrivateICO.DailySale" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link rel="stylesheet" href="../../plugins/daterangepicker/daterangepicker.css" />
    <!-- bootstrap datepicker -->
    <link rel="stylesheet" href="../../plugins/datepicker/datepicker3.css" />
    <!-- iCheck for checkboxes and radio inputs -->
    <link rel="stylesheet" href="../../plugins/iCheck/all.css" />
    <!-- Bootstrap Color Picker -->
    <link rel="stylesheet" href="../../plugins/colorpicker/bootstrap-colorpicker.min.css" />
    <!-- Bootstrap time Picker -->
    <link rel="stylesheet" href="../../plugins/timepicker/bootstrap-timepicker.min.css" />
    <!-- Select2 -->
    <link rel="stylesheet" href="/plugins/select2/select2.min.css" />
    <div>
        <div class="content-wrapper">
            <!-- Content Header (Page header) -->
            <section class="content-header">
                <h1>Add User
                </h1>
                <ol class="breadcrumb">
                    <li><a href="#"><i class="fa fa-dashboard"></i>Dashboard</a></li>
                    <li><a href="#">Sale Details</a></li>
                    <li class="active">Add Sale</li>
                </ol>
            </section>

            <!-- General Info -->
            <section class="content">

                <!-- SELECT2 EXAMPLE -->
                <div class="box box-default">
                    <div class="box-header with-border">
                        <h3 class="box-title">Sale Info</h3>
                        <div class="box-tools pull-right">
                            <button type="button" class="btn btn-box-tool" data-widget="collapse"><i class="fa fa-minus"></i></button>
                        </div>
                    </div>
                    <!-- /.box-header -->
                    <div class="box-body">
                        <div class="row">
                            <div class="col-md-6">
                                <div class="form-group">
                                    <label>Day	Sales*</label>
                                    <asp:TextBox runat="server" ID="txtDaySales" CssClass="form-control" required placeholder="Enter Day Sales"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-md-6">
                                <div class="form-group">
                                    <label>Refunds*</label>
                                    <asp:TextBox runat="server" ID="txtRefunds" CssClass="form-control" required placeholder="Enter Refunds"></asp:TextBox>
                                </div>
                                <!-- /.form-group -->
                            </div>

                            <div class="col-md-6">
                                <div class="form-group">
                                    <label>Net Sales</label>
                                    <asp:TextBox runat="server"  ID="txtNetSales"  required  CssClass="form-control" placeholder="Enter Net Sales"></asp:TextBox>
                                </div>
                            </div>

                            <div class="col-md-6">
                                <div class="form-group">
                                    <label>Monthly Sales</label>
                                    <asp:TextBox runat="server" required  ID="txtMonthlySales" CssClass="form-control" placeholder="Enter Monthly Sales"></asp:TextBox>
                                </div>
                            </div>

                             <div class="col-md-6">
                                <div class="form-group">
                                    <label>Tier 1</label>
                                    <asp:TextBox runat="server" required  ID="txtTier1" CssClass="form-control" placeholder="Enter Tier1"></asp:TextBox>
                                </div>
                            </div>

                            <div class="col-md-6">
                                <div class="form-group">
                                    <label>Tier 2</label>
                                    <asp:TextBox runat="server" required  ID="txtTier2" CssClass="form-control" placeholder="Enter Tier2"></asp:TextBox>
                                </div>
                            </div>
                            
                            <div class="col-md-6">
                                <div class="form-group">
                                    <label>Tier 3</label>
                                    <asp:TextBox runat="server" required  ID="txtTier3" CssClass="form-control" placeholder="Enter Tier3"></asp:TextBox>
                                </div>
                            </div>

                            <div class="col-md-6">
                                <div class="form-group">
                                    <label>Tier 4</label>
                                    <asp:TextBox runat="server" required  ID="txtTier4" CssClass="form-control" placeholder="Enter Tier4"></asp:TextBox>
                                </div>
                            </div>

                            <div class="col-md-6">
                                <div class="form-group">
                                    <label>Bonus</label>
                                    <asp:TextBox runat="server" required  ID="txtBonus" CssClass="form-control" placeholder="Enter Bonus"></asp:TextBox>
                                </div>
                            </div>

                            <div class="col-md-6">
                                <div class="form-group">
                                    <label>Monthly Draws Taken</label>
                                    <asp:TextBox runat="server" required  ID="txtMonthlyDrawsTaken" CssClass="form-control" placeholder="Enter Monthly Draws Taken"></asp:TextBox>
                                </div>
                            </div>

                             <div class="col-md-6">
                                <div class="form-group">
                                    <label>QBTotalPay</label>
                                    <asp:TextBox runat="server" required  ID="txtQBTotalPay" CssClass="form-control" placeholder="Enter QB Total Pay"></asp:TextBox>
                                </div>
                            </div>

                            <div class="col-md-6">
                                <div class="form-group">
                                    <label>Cash Bonus</label>
                                    <asp:TextBox runat="server" required  ID="txtCashBonus" CssClass="form-control" placeholder="Enter Cash Bonus"></asp:TextBox>
                                </div>
                            </div>

                            <div class="col-md-6">
                                <div class="form-group">
                                    <label>Monthly Office Rent</label>
                                    <asp:TextBox runat="server" required  ID="txtMonthlyOfficeRent" CssClass="form-control" placeholder="Enter Monthly Office Rent"></asp:TextBox>
                                </div>
                            </div>

                            <div class="col-md-6">
                                <div class="form-group">
                                    <label>Actual Payout Total </label>
                                    <asp:TextBox runat="server" required  ID="txtActualPayout" CssClass="form-control" placeholder="Enter Actual Payout Total"></asp:TextBox>
                                </div>
                            </div>

                            <div class="col-md-6">
                                <label></label>
                                <div class="form-group">
                                    <asp:Button runat="server" ID="btnAddSales" Text="Add Sales" OnClick="btnAddSales_Click" CssClass="btn btn-block btn-success" />
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </section>
        </div>
    </div>
</asp:Content>
