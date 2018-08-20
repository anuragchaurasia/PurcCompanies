<%@ Page Title="" Language="C#" MasterPageFile="~/AdminMaster.Master" AutoEventWireup="true" CodeBehind="EditMasterSales.aspx.cs" Inherits="PrivateICO.EditMasterSales" %>
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
                                    <label>Choose Date*</label>
                                    <asp:TextBox runat="server" ReadOnly="true" ID="txtDate" CssClass="form-control" required placeholder="Choose Date"></asp:TextBox>
                                </div>
                            </div>

                            <div class="col-md-6">
                                <div class="form-group">
                                    <label>Day Sales Amount*</label>
                                    <asp:TextBox runat="server" Text="0" ID="txtDaySales" data-inputmask="'alias': 'numeric', 'groupSeparator': ',', 'autoGroup': true, 'digits': 2, 'digitsOptional': false, 'prefix': '$ ', 'placeholder': '0'" CssClass="form-control" required placeholder="Enter Day Sales"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-md-6">
                                <div class="form-group">
                                    <label>Refunds*</label>
                                    <asp:TextBox runat="server" ID="txtRefunds" CssClass="form-control" Text="0" required placeholder="Enter Refunds"></asp:TextBox>
                                </div>
                                <!-- /.form-group -->
                            </div>

                            <div class="col-md-6">
                                <div class="form-group">
                                    <label>Net Sales</label>
                                    <asp:TextBox runat="server" ID="txtNetSales" ReadOnly="true" Text="0" CssClass="form-control" placeholder="Enter Net Sales"></asp:TextBox>
                                </div>
                            </div>

                            <div class="col-md-6">
                                <div class="form-group">
                                    <label>Monthly Sales</label>
                                    <asp:TextBox runat="server" required ID="txtMonthlySales" Text="0" CssClass="form-control" placeholder="0.00" ReadOnly="true"></asp:TextBox>
                                </div>
                            </div>

                            <div class="col-md-6">
                                <div class="form-group">
                                    <label>Commision</label>
                                    <asp:TextBox runat="server" required ID="txtCommision" Text="0" ReadOnly="true" CssClass="form-control" placeholder="Commision in USD"></asp:TextBox>
                                </div>
                            </div>


                            <div class="col-md-6">
                                <div class="form-group">
                                    <label>Cash Bonus</label>
                                    <asp:TextBox runat="server" required ID="txtBonus" Text="0" CssClass="form-control" placeholder="Enter Bonus"></asp:TextBox>
                                </div>
                            </div>

                            <div class="col-md-6">
                                <div class="form-group">
                                    <label>Monthly Draws Taken</label>
                                    <asp:TextBox runat="server" required ID="txtMonthlyDrawsTaken" Text="0" CssClass="form-control" placeholder="Enter Monthly Draws Taken"></asp:TextBox>
                                </div>
                            </div>

                            <div class="col-md-6">
                                <div class="form-group">
                                    <label>QBTotalPay</label>
                                    <asp:TextBox runat="server" required ID="txtQBTotalPay" Text="0" CssClass="form-control" ReadOnly="true" placeholder="Enter QB Total Pay"></asp:TextBox>
                                </div>
                            </div>

                            <div class="col-md-6">
                                <div class="form-group">
                                    <label>Total Cash Bonus</label>
                                    <asp:TextBox runat="server" required ID="txtTotalCashBonus" Text="0" ReadOnly="true" CssClass="form-control" placeholder="Total Cash Bonus"></asp:TextBox>
                                </div>
                            </div>

                            <div class="col-md-6">
                                <div class="form-group">
                                    <label>Monthly Office Rent</label>
                                    <asp:TextBox runat="server" required ID="txtMonthlyOfficeRent"  Text="0" CssClass="form-control" placeholder="50 USD"></asp:TextBox>
                                </div>
                            </div>

                            <div class="col-md-6">
                                <div class="form-group">
                                    <label>Actual Payout Total </label>
                                    <asp:TextBox runat="server" required ID="txtActualPayout" Text="0" CssClass="form-control" placeholder="Enter Actual Payout Total"></asp:TextBox>
                                </div>
                            </div>

                            <div class="col-md-6">
                                <div class="form-group">
                                    <label>Daily Bonus for Month </label>
                                    <asp:TextBox runat="server" required ID="txtDailyBonusForMonth" Text="0" CssClass="form-control" placeholder="Enter Daily Bonus For Month"></asp:TextBox>
                                </div>
                            </div>

                            <div class="col-md-6">
                                <label></label>
                                <div class="form-group">
                                    <asp:Button runat="server" ID="btnEditSales" Text="Edit Sales" OnClick="btnEditSales_Click" CssClass="btn btn-block btn-success" />
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </section>
        </div>
    </div>
   <%-- <script src="Scripts/jquery.min.js"></script>--%>
    <link href="Content/jquery-ui.css" rel="stylesheet" />
    <script src="Scripts/jquery-ui.js"></script>
    <script src="Scripts/min/inputmask/inputmask.min.js"></script>
    <script src="Scripts/min/inputmask/inputmask.extensions.min.js"></script>
    <script src="Scripts/min/jquery.inputmask.bundle.min.js"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            $("#ctl00_ContentPlaceHolder1_txtDate").datepicker();
            $("#ctl00_ContentPlaceHolder1_txtRefunds").inputmask();
            var monthlySale = $('#ctl00_ContentPlaceHolder1_txtMonthlySales').val();
            var totalBonus = $('#ctl00_ContentPlaceHolder1_txtTotalCashBonus').val();
            $('#ctl00_ContentPlaceHolder1_txtDaySales').change(function () {
                var daySaleAmount = $('#ctl00_ContentPlaceHolder1_txtDaySales').val();
                var refunds = $('#ctl00_ContentPlaceHolder1_txtRefunds').val();

                if (isNaN(daySaleAmount) || daySaleAmount == "") {
                    daySaleAmount = "0.00";
                }
                if (isNaN(refunds) || refunds == "") {
                    refunds = "0.00";
                }
                var netsale = parseFloat(daySaleAmount) - parseFloat(refunds);
                $('#ctl00_ContentPlaceHolder1_txtMonthlySales').val(parseFloat(monthlySale) + parseFloat(netsale));
                var currentMonthlySale = parseFloat($('#ctl00_ContentPlaceHolder1_txtMonthlySales').val());
                if (currentMonthlySale > 0 && currentMonthlySale <= 4000) {
                    $('#ctl00_ContentPlaceHolder1_txtCommision').val(currentMonthlySale * 20 / 100);
                }
                else if (currentMonthlySale > 4001 && currentMonthlySale <= 7000) {
                    $('#ctl00_ContentPlaceHolder1_txtCommision').val(currentMonthlySale * 25 / 100);
                }
                else if (currentMonthlySale > 7001 && currentMonthlySale <= 9500) {
                    $('#ctl00_ContentPlaceHolder1_txtCommision').val(currentMonthlySale * 28 / 100);
                }
                else if (currentMonthlySale > 9501) {
                    $('#ctl00_ContentPlaceHolder1_txtCommision').val(currentMonthlySale * 30 / 100);
                }

                $('#ctl00_ContentPlaceHolder1_txtNetSales').val(netsale);
                calculateQBPay();
            });
            $('#ctl00_ContentPlaceHolder1_txtRefunds').change(function () {
                var daySaleAmount = $('#ctl00_ContentPlaceHolder1_txtDaySales').val();
                var refunds = $('#ctl00_ContentPlaceHolder1_txtRefunds').val();
                if (isNaN(daySaleAmount) || daySaleAmount == "") {
                    daySaleAmount = "0.00";
                }
                if (isNaN(refunds) || refunds == "") {
                    refunds = "0.00";
                }
                var netsale = parseFloat(daySaleAmount) - parseFloat(refunds);
                $('#ctl00_ContentPlaceHolder1_txtMonthlySales').val(parseFloat(monthlySale) + parseFloat(netsale));
                var currentMonthlySale = parseFloat($('#ctl00_ContentPlaceHolder1_txtMonthlySales').val());
                if (currentMonthlySale > 0 && currentMonthlySale <= 4000) {
                    $('#ctl00_ContentPlaceHolder1_txtCommision').val(currentMonthlySale * 20 / 100);
                }
                else if (currentMonthlySale > 4001 && currentMonthlySale <= 7000) {
                    $('#ctl00_ContentPlaceHolder1_txtCommision').val(currentMonthlySale * 25 / 100);
                }
                else if (currentMonthlySale > 7001 && currentMonthlySale <= 9500) {
                    $('#ctl00_ContentPlaceHolder1_txtCommision').val(currentMonthlySale * 28 / 100);
                }
                else if (currentMonthlySale > 9501) {
                    $('#ctl00_ContentPlaceHolder1_txtCommision').val(currentMonthlySale * 30 / 100);
                }
                $('#ctl00_ContentPlaceHolder1_txtNetSales').val(netsale);
                calculateQBPay();
            });
            $('#ctl00_ContentPlaceHolder1_txtBonus').change(function () {
                var dayBonus = parseFloat($('#ctl00_ContentPlaceHolder1_txtBonus').val());
                $('#ctl00_ContentPlaceHolder1_txtTotalCashBonus').val(parseFloat(totalBonus) + dayBonus);
                calculateQBPay();
            });

            $('#ctl00_ContentPlaceHolder1_txtCommision').change(function () {
                calculateQBPay();
            });
            $('#ctl00_ContentPlaceHolder1_txtTotalCashBonus').change(function () {
                calculateQBPay();
            });
            $('#ctl00_ContentPlaceHolder1_txtDailyBonusForMonth').change(function () {
                calculateQBPay();
            });
            $('#ctl00_ContentPlaceHolder1_txtDailyBonusForMonth').change(function () {
                calculateQBPay();
            });
            $('#ctl00_ContentPlaceHolder1_txtMonthlyOfficeRent').change(function () {
                calculateQBPay();
            });

            function calculateQBPay() {
                var totalCommision = $('#ctl00_ContentPlaceHolder1_txtCommision').val();
                var cashBonus = $('#ctl00_ContentPlaceHolder1_txtTotalCashBonus').val();
                var dailyBonusForMonth = $('#ctl00_ContentPlaceHolder1_txtDailyBonusForMonth').val();
                var monthyRental = $('#ctl00_ContentPlaceHolder1_txtMonthlyOfficeRent').val();
                var drawTakenMonthly = $('#ctl00_ContentPlaceHolder1_txtMonthlyDrawsTaken').val();

                var totalQBPay = parseFloat(totalCommision) + parseFloat(cashBonus) + parseFloat(dailyBonusForMonth) - parseFloat(monthyRental) - parseFloat(drawTakenMonthly);
                var totalActualPay = parseFloat(totalCommision) + parseFloat(dailyBonusForMonth) - parseFloat(monthyRental) - parseFloat(drawTakenMonthly);
                $('#ctl00_ContentPlaceHolder1_txtQBTotalPay').val(totalQBPay);
                $('#ctl00_ContentPlaceHolder1_txtActualPayout').val(totalActualPay);
            }

        });
    </script>

</asp:Content>
