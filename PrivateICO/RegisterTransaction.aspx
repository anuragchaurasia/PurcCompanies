<%@ Page Title="" Language="C#" MasterPageFile="~/AdminMaster.Master" AutoEventWireup="true" CodeBehind="RegisterTransaction.aspx.cs" Inherits="PrivateICO.RegisterTransaction" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <script src="Scripts/jquery-1.9.0.min.js"></script>
    <link rel="stylesheet" href="../../plugins/iCheck/all.css" type="text/css" />
    <div>

        <div class="content-wrapper">
            <!-- Content Header (Page header) -->
            <section class="content-header">
                <h1>Edit User
                </h1>
                <ol class="breadcrumb">
                    <li><a href="#"><i class="fa fa-dashboard"></i>Dashboard</a></li>
                    <li><a href="#">User</a></li>
                    <li class="active">Transactions</li>
                </ol>
            </section>

            <!-- General Info -->
            <section class="content">

                <!-- SELECT2 EXAMPLE -->
                <div class="box box-default">
                    <div class="box-header with-border">
                        <h3 class="box-title">Investment Info</h3>

                        <div class="box-tools pull-right">
                            <button type="button" class="btn btn-box-tool" data-widget="collapse"><i class="fa fa-minus"></i></button>
                        </div>
                    </div>
                    <!-- /.box-header -->
                    <div class="box-body">
                        <div class="row">
                            <div class="col-md-6">
                                <div class="form-group">
                                    <label>Name*</label>
                                    <asp:TextBox runat="server" ReadOnly="true" ID="txtUsername" CssClass="form-control"></asp:TextBox>
                                </div>
                                <!-- /.form-group -->
                                <div class="form-group">
                                    <label>Email*</label>
                                    <asp:TextBox runat="server" ID="txtEmail" CssClass="form-control" ReadOnly="true"></asp:TextBox>
                                </div>
                                <!-- /.form-group -->
                            </div>
                            <!-- /.col -->
                            <div class="col-md-6">
                                <div class="form-group">
                                    <label>Transaction Currency*</label>
                                    <asp:DropDownList runat="server" CssClass="form-control" ID="drpCurrenyType">
                                        <asp:ListItem>BitCoin</asp:ListItem>
                                        <asp:ListItem>Ether</asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                                <!-- /.form-group -->
                                <div class="form-group">
                                    <label>Deposit Amount*</label>
                                    <asp:TextBox runat="server" ID="txtDepositCurrency" CssClass="form-control" type="number" min=".5" step="0.00000001" required placeholder="Enter Amount"></asp:TextBox>
                                    <label style="font-weight: 400; font-style: italic; font-size: 12px;">
                                        Min BTC : <b>.5</b> Min ETH : <b>5</b></label>
                                </div>
                                <!-- /.form-group -->
                            </div>
                            <!-- /.col -->
                            <div class="col-md-6">
                                <div class="form-group">
                                    <label>No Of Coins*</label>
                                    <asp:TextBox runat="server" ID="txtNoCoins"  Text="0" CssClass="form-control" placeholder="Coins user will get"></asp:TextBox>
                                </div>

                            </div>
                            <div class="col-md-6">
                                <label></label>
                                <div class="form-group">
                                    <asp:Button runat="server" ID="btnAddUserTransaction" Text="Add Transaction" OnClientClick="validateRange()" CssClass="btn btn-block btn-success" OnClick="btnAddUserTransaction_Click" />
                                </div>
                            </div>
                        </div>
                        <!-- /.row -->
                    </div>
                    <!-- /.box-body -->

                </div>
                <!-- /.box -->


            </section>
            <!-- /.content -->
            <!-- General Info -->

            <!-- /.content -->
        </div>

    </div>

    <script type="text/javascript">


        $(document).ready(function () {
            $('#ctl00_ContentPlaceHolder1_txtDepositCurrency').change(function () {

                var currentCurrency = $('#ctl00_ContentPlaceHolder1_drpCurrenyType').find(":selected").text();
                var depositAmount = $('#ctl00_ContentPlaceHolder1_txtDepositCurrency').val();
                var noOfQTM = $('#ctl00_ContentPlaceHolder1_txtNoCoins').val();

                if (currentCurrency == "Bitcoin") {
                    $('#ctl00_ContentPlaceHolder1_txtNoCoins').val((parseFloat(depositAmount) * 110000).toFixed(8));
                    $('#ctl00_ContentPlaceHolder1_txtDepositCurrency').attr('min','.5');
                }
                else
                    if (currentCurrency == "Ethereum") {
                        $('#ctl00_ContentPlaceHolder1_txtNoCoins').val((parseFloat(depositAmount) * 10000).toFixed(8));
                        $('#ctl00_ContentPlaceHolder1_txtDepositCurrency').attr('min', '5');
                    }
            });


            $('#ctl00_ContentPlaceHolder1_drpCurrenyType').change(function () {

                var currentCurrency = $('#ctl00_ContentPlaceHolder1_drpCurrenyType').find(":selected").text();
                var depositAmount = $('#ctl00_ContentPlaceHolder1_txtDepositCurrency').val();
                var noOfQTM = $('#ctl00_ContentPlaceHolder1_txtNoCoins').val();

                if (currentCurrency == "Bitcoin") {
                    $('#ctl00_ContentPlaceHolder1_txtNoCoins').val((parseFloat(depositAmount) * 110000).toFixed(8));
                    $('#ctl00_ContentPlaceHolder1_txtDepositCurrency').attr('min')
                }
                else
                    if (currentCurrency == "Ethereum") {
                        $('#ctl00_ContentPlaceHolder1_txtNoCoins').val((parseFloat(depositAmount) * 10000).toFixed(8));
                    }
            });

            $("ctl00_ContentPlaceHolder1_txtDepositCurrency").keydown(function (event) {
                if (event.shiftKey == true) {
                    event.preventDefault();
                }

                if ((event.keyCode >= 48 && event.keyCode <= 57) || 
                    (event.keyCode >= 96 && event.keyCode <= 105) || 
                    event.keyCode == 8 || event.keyCode == 9 || event.keyCode == 37 ||
                    event.keyCode == 39 || event.keyCode == 46 || event.keyCode == 190) {

                } else {
                    event.preventDefault();
                }

                if($(this).val().indexOf('.') !== -1 && event.keyCode == 190)
                    event.preventDefault(); 
                //if a decimal has been added, disable the "."-button

            });

        });


    </script>
</asp:Content>
