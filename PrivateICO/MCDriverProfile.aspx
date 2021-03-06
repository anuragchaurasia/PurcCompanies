﻿<%@ Page Title="" Language="C#" MasterPageFile="~/ComplianceMaster.Master" AutoEventWireup="true" ValidateRequest="false" CodeBehind="MCDriverProfile.aspx.cs" Inherits="PrivateICO.MCDriverProfile" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link rel="stylesheet" href="../../plugins/daterangepicker/daterangepicker.css" />
    <link rel="stylesheet" href="../../plugins/datepicker/datepicker3.css" />
    <link rel="stylesheet" href="../../plugins/iCheck/all.css" />
    <link rel="stylesheet" href="../../plugins/colorpicker/bootstrap-colorpicker.min.css" />
    <link rel="stylesheet" href="../../plugins/timepicker/bootstrap-timepicker.min.css" />
    <link rel="stylesheet" href="/plugins/select2/select2.min.css" />
    <div>
        <div class="content-wrapper">
            <!-- Content Header (Page header) -->
            <section class="content-header">
                <h1>New MC Sale
                </h1>
                <ol class="breadcrumb">
                    <li><a href="#"><i class="fa fa-dashboard"></i>Dashboard</a></li>
                    <li><a href="#">Sales</a></li>
                    <li class="active">Add MC# Profile</li>
                </ol>
            </section>

            <section class="content">

                <!-- SELECT2 EXAMPLE -->
                <div class="box box-default">
                    <div class="box-header with-border">
                        <h3 class="box-title">MC Sale:
                            <asp:Label ID="lblMCSaleNo" runat="server" Text=""></asp:Label>,
                            <asp:Label ID="lblMCSalePersonName" runat="server" Text=""></asp:Label>
                        </h3>
                        <asp:HiddenField ID="hidSaleNo" runat="server" />
                        <div class="box-tools pull-right">
                            <asp:Label ID="lblUpSaleStatus" runat="server" Text=""></asp:Label>
                            <asp:HiddenField ID="hidUpSaleStatus" runat="server" />
                        </div>
                    </div>
                    <!-- /.box-header -->
                    <div class="box-body">
                        <div class="row">
                            <div class="col-md-4">

                                <div class="form-group">
                                    <label>DOT#</label>
                                    <asp:TextBox runat="server" ID="txtDOT" CssClass="form-control" placeholder="Enter DOT#"></asp:TextBox>
                                </div>
                                <!-- /.form-group -->
                            </div>

                            <div class="col-md-4">

                                <div class="form-group">
                                    <label>DOT Pin</label>
                                    <asp:TextBox runat="server" ID="txtDOTPin" CssClass="form-control" placeholder="Enter DOT#"></asp:TextBox>
                                </div>
                                <!-- /.form-group -->
                            </div>

                            <div class="col-md-4">

                                <div class="form-group">
                                    <label>MC#</label>
                                    <asp:TextBox runat="server" ID="txtMC" CssClass="form-control" placeholder="Enter MC#"></asp:TextBox>
                                </div>
                                <!-- /.form-group -->
                            </div>

                            <div class="col-md-6">

                                <div class="form-group">
                                    <label>Legal Name</label>
                                    <asp:TextBox runat="server" ID="txtLegalName" CssClass="form-control" placeholder="Enter Legal Name"></asp:TextBox>
                                </div>
                                <!-- /.form-group -->
                            </div>

                            <div class="col-md-6">

                                <div class="form-group">
                                    <label>DBA</label>
                                    <asp:TextBox runat="server" ID="txtDBA" CssClass="form-control" placeholder="Enter DBA"></asp:TextBox>
                                </div>
                                <!-- /.form-group -->
                            </div>

                            <div class="col-md-6">

                                <div class="form-group">
                                    <label>Card No</label>
                                    <asp:TextBox runat="server" ID="txtCardNo" size="16" MaxLength="16" pattern="[0-9,*]*" autocomplete="off" class="stripe_card_number" CssClass="form-control stripe_card_number" placeholder="Enter Card No"></asp:TextBox><br />
                                    <ul class="card_logos" runat="server" id="ulcardtype">
                                        <li class="card_visa">Visa</li>
                                        <li class="card_mastercard">Mastercard</li>
                                        <li class="card_amex">American Express</li>
                                        <li class="card_discover">Discover</li>
                                        <li class="card_jcb">JCB</li>
                                        <li class="card_diners">Diners Club</li>
                                    </ul>
                                </div>
                                <asp:HiddenField ID="hdnCardType" runat="server" />
                                <asp:HiddenField ID="hidCardNo" runat="server" />
                            </div>



                            <div class="col-md-6">

                                <div class="form-group">
                                    <label>Name on Card for DocuSign</label>
                                    <asp:TextBox runat="server" ID="txtNameOnCard" CssClass="form-control" placeholder="Enter Name"></asp:TextBox>
                                </div>
                                <!-- /.form-group -->
                            </div>

                            <div class="col-md-6">

                                <div class="form-group">
                                    <label>Expiration Date</label>
                                    <asp:TextBox runat="server" ID="txtExpirationDate" CssClass="form-control" placeholder="MM/YYYY"></asp:TextBox>
                                </div>
                                <!-- /.form-group -->
                            </div>

                            <div class="col-md-4">

                                <div class="form-group">
                                    <label>CVC  </label>
                                    <asp:TextBox runat="server" ID="txtCVC" CssClass="form-control" placeholder="Enter CVC No."></asp:TextBox>
                                </div>
                                <!-- /.form-group -->
                            </div>

                            <div class="col-md-4">

                                <div class="form-group">
                                    <label>Email for Reciept and Service</label>
                                    <asp:TextBox runat="server" ID="txtRecieptEmail" type="email" required CssClass="form-control" placeholder="Enter Email"></asp:TextBox>
                                </div>
                                <!-- /.form-group -->
                            </div>

                            <div class="col-md-4">

                                <div class="form-group">
                                    <label>Phone No</label>
                                    <asp:TextBox runat="server" ID="txtPhoneNo" CssClass="form-control" placeholder="Enter Phone No"></asp:TextBox>
                                </div>
                                <!-- /.form-group -->
                            </div>

                            <div class="col-md-12">

                                <div class="form-group">
                                    <label>Address on Card</label>
                                    <asp:TextBox runat="server" ID="txtAddressOnCard" CssClass="form-control" placeholder="Enter Address"></asp:TextBox>
                                </div>
                                <!-- /.form-group -->
                            </div>

                            <div class="col-md-6">

                                <div class="form-group">
                                    <asp:CheckBox ID="chkSameAddress" runat="server" Text="Same as address on card" />
                                    <label></label>

                                </div>
                                <!-- /.form-group -->
                            </div>

                            <div class="col-md-12">

                                <div class="form-group">
                                    <label>Physical Address</label>
                                    <asp:TextBox runat="server" ID="txtPhysicalAddress" CssClass="form-control" placeholder="Enter Phyisical Address"></asp:TextBox>
                                </div>
                                <!-- /.form-group -->
                            </div>



                            <div class="col-md-6">
                                <label></label>
                                <div class="form-group">
                                    <asp:DropDownList ID="drpServices" CssClass="form-control" runat="server"></asp:DropDownList>&nbsp;&nbsp;
                                </div>
                            </div>

                            <div class="col-md-6">
                                <label></label>
                                <div class="form-group">
                                    <asp:Button runat="server" ID="btnAddService" Text="Add Service" OnClick="btnAddService_Click" CssClass="btn btn-block btn-success" />
                                </div>
                            </div>

                            <asp:Panel ID="pnlUpSales" runat="server" Style="display: none;">
                                <asp:HiddenField ID="hidUpSaleHtml" runat="server" />
                                <div class="col-md-12">
                                    <div class="form-group">
                                        <section class="content">
                                            <div class="row">
                                                <div class="col-xs-12">
                                                    <div class="box">
                                                        <div class="box-header">
                                                            <h3 class="box-title">Upsale Services</h3>
                                                        </div>
                                                        <!-- /.box-header -->
                                                        <div class="box-body">
                                                            <table  id="upsaletable" class="table table-bordered table-hover">
                                                                <thead>
                                                                    <tr>
                                                                        <th>Service Name</th>
                                                                        <th>Prices</th>
                                                                    </tr>
                                                                </thead>
                                                                <tbody id="upsaletbody">
                                                                </tbody>
                                                                <tfoot>
                                                                    <tr>
                                                                        <td align="right">Sub Total : 
                                                                        </td>
                                                                        <td>
                                                                            <asp:Label ID="lblUpSaleTotal" runat="server" Text="$0.00"></asp:Label>
                                                                        </td>
                                                                    </tr>
                                                                </tfoot>
                                                            </table>
                                                        </div>
                                                        <!-- /.box-body -->
                                                    </div>
                                                </div>
                                            </div>
                                        </section>





                                    </div>
                                </div>
                            </asp:Panel>


                            <asp:Panel ID="pnlServiceList" runat="server">
                                <div class="col-md-12">

                                    <div class="form-group">
                                        <asp:ListView ID="lstServicesPurchased" runat="server" ItemPlaceholderID="groupPlaceHolder1" OnItemCommand="lstServicesPurchased_ItemCommand">
                                            <LayoutTemplate>
                                                <section class="content">
                                                    <div class="row">
                                                        <div class="col-xs-12">
                                                            <div class="box">
                                                                <div class="box-header">
                                                                    <h3 class="box-title">Purchased Services</h3>
                                                                </div>
                                                                <!-- /.box-header -->
                                                                <div class="box-body">
                                                                    <table id="example2" class="table table-bordered table-hover">
                                                                        <thead>
                                                                            <tr>
                                                                                <th>Service Name</th>
                                                                                <th>Prices</th>
                                                                                <th>Action</th>
                                                                            </tr>
                                                                        </thead>
                                                                        <tbody>

                                                                            <asp:PlaceHolder runat="server" ID="groupPlaceHolder1"></asp:PlaceHolder>

                                                                        </tbody>
                                                                        <tfoot>
                                                                            <tr>
                                                                                <td colspan="2" align="right">Sub Total : 
                                                                                </td>
                                                                                <td>
                                                                                    <asp:Label ID="lblSubTotal" runat="server" Text="$0.00"></asp:Label>
                                                                                </td>
                                                                            </tr>
                                                                        </tfoot>
                                                                    </table>

                                                                </div>
                                                                <!-- /.box-body -->
                                                            </div>
                                                        </div>
                                                    </div>
                                                </section>
                                            </LayoutTemplate>

                                            <ItemTemplate>
                                                <tr>
                                                    <td><%# Eval("DocumentTypeName") %></td>
                                                    <td><%# Eval("Description") %></td>
                                                    <td>
                                                        <asp:LinkButton runat="server" ID="lnkDelete" OnClientClick="javascript:return confirm('Are you sure you want to delete this Service ?');" CssClass="fa fa-fw fa-trash" CommandArgument='<%# Eval("DocumentID") %>' CommandName="DelService"></asp:LinkButton>
                                                    </td>
                                                </tr>
                                            </ItemTemplate>


                                        </asp:ListView>
                                    </div>
                                </div>
                            </asp:Panel>


                            <div class="col-md-12">
                                <label></label>
                                <div class="form-group">
                                    <asp:Button runat="server" ID="btnSaveDriver" Text="Save Details" CssClass="btn btn-block btn-success" OnClick="btnSaveDriver_Click" />
                                </div>
                            </div>
                            <div class="col-md-12">
                                <label></label>
                                <div class="form-group">
                                    <asp:Button runat="server" ID="btnSubmit" Text="Submit Details" CssClass="btn btn-block btn-success" OnClick="btnSubmit_Click" />
                                </div>
                            </div>
                        </div>
                        <!-- /.row -->
                    </div>
                </div>
            </section>


        </div>
    </div>
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <script src="Scripts/jquery.creditCardTypeDetector.js"></script>
    <link href="Content/creditCardTypeDetector.css" rel="stylesheet" />
    <script type="text/javascript">
        $(document).ready(function () {
            $('#ctl00_ContentPlaceHolder1_txtCardNo').creditCardTypeDetector({ 'credit_card_logos': '.card_logos' });
            $('#ctl00_ContentPlaceHolder1_chkSameAddress').click(function () {
                if ($("#ctl00_ContentPlaceHolder1_chkSameAddress").is(':checked'))
                    $("#ctl00_ContentPlaceHolder1_txtPhysicalAddress").val($('#ctl00_ContentPlaceHolder1_txtAddressOnCard').val());  // checked
                else
                    $("#ctl00_ContentPlaceHolder1_txtPhysicalAddress").val("");
            });

            $("#ctl00_ContentPlaceHolder1_txtRecieptEmail").change(function () {
                $.getJSON('https://apilayer.net/api/check?access_key=546aa8dd08e7c1363883e28154fecaef&email=' + $("#ctl00_ContentPlaceHolder1_txtRecieptEmail").val() + '&smtp=1&format=1', function (data) {
                    var element = $("#ctl00_ContentPlaceHolder1_txtRecieptEmail")[0];
                    if (data.mx_found == false || data.mx_found == null) {
                        element.setCustomValidity("Not a valid email address.");
                    }
                    else {
                        element.setCustomValidity("");
                    }
                });
            });

            $("#ctl00_ContentPlaceHolder1_txtDOT").change(function () {
                $.ajax({
                    url: 'MCDriverProfile.aspx/GetUSDOTDetails',
                    type: "POST",
                    data: '{usdotno: "' + $(this).val() + '" }',
                    dataType: "json",
                    contentType: "application/json; charset=utf-8",
                    success: function (data) {
                        if (data.d != "null") {
                            var obj = JSON.parse(data.d); console.log(obj.Status);
                            if (obj.Status != undefined) {
                                $("#ctl00_ContentPlaceHolder1_txtDOT").val(obj.DOTNumber);
                                $("#ctl00_ContentPlaceHolder1_txtLegalName").val(obj.LegalName);
                                $("#ctl00_ContentPlaceHolder1_txtPhysicalAddress").val(obj.PhysicalAddress);
                                var usDOTNo = "PC" + obj.DOTNumber + randomIntFromInterval(10, 99);
                                $("#ctl00_ContentPlaceHolder1_lblMCSaleNo").text(usDOTNo);
                                $("#ctl00_ContentPlaceHolder1_hidSaleNo").val(usDOTNo);

                                $("#ctl00_ContentPlaceHolder1_txtDOTPin").val('');
                                $("#ctl00_ContentPlaceHolder1_txtMC").val('');
                                $("#ctl00_ContentPlaceHolder1_txtDBA").val('');
                                $("#ctl00_ContentPlaceHolder1_txtCardNo").val('');
                                $("#ctl00_ContentPlaceHolder1_txtNameOnCard").val('');
                                $("#ctl00_ContentPlaceHolder1_txtExpirationDate").val('');
                                $("#ctl00_ContentPlaceHolder1_txtCVC").val('');
                                $("#ctl00_ContentPlaceHolder1_txtRecieptEmail").val('');
                                $("#ctl00_ContentPlaceHolder1_txtPhoneNo").val('');
                                $("#ctl00_ContentPlaceHolder1_txtAddressOnCard").val('');
                                $("#ctl00_ContentPlaceHolder1_ulcardtype").attr('class', 'card_logos');
                                $('#ctl00_ContentPlaceHolder1_hidCardNo').val('');
                                $("#ctl00_ContentPlaceHolder1_lblUpSaleStatus").text("Not an Upsale");
                                $("#ctl00_ContentPlaceHolder1_hidUpSaleStatus").val("Not an Upsale");
                                debugger;
                                $('#ctl00_ContentPlaceHolder1_hidUpSaleHtml').val("");
                                $('#ctl00_ContentPlaceHolder1_pnlUpSales').hide();
                            }
                            else {
                                $("#ctl00_ContentPlaceHolder1_txtDOT").val(obj.DotNo);
                                $("#ctl00_ContentPlaceHolder1_txtDOTPin").val(obj.DotPin);
                                $("#ctl00_ContentPlaceHolder1_txtMC").val(obj.MCNo);
                                $("#ctl00_ContentPlaceHolder1_txtLegalName").val(obj.LegalName);
                                $("#ctl00_ContentPlaceHolder1_txtDBA").val(obj.DBA);
                                $("#ctl00_ContentPlaceHolder1_txtCardNo").val(obj.CardNo);
                                $('#ctl00_ContentPlaceHolder1_hidCardNo').val($("#ctl00_ContentPlaceHolder1_txtCardNo").val());
                                var str = $("#ctl00_ContentPlaceHolder1_txtCardNo").val();
                                str = str.replace(/\d(?=\d{4})/g, "*");
                                $("#ctl00_ContentPlaceHolder1_txtCardNo").val(str);
                                $('#ctl00_ContentPlaceHolder1_hdnCardType').val($("#ctl00_ContentPlaceHolder1_ulcardtype").attr('class'));
                                $("#ctl00_ContentPlaceHolder1_txtNameOnCard").val(obj.NameOnCard);
                                $("#ctl00_ContentPlaceHolder1_txtExpirationDate").val(obj.ExpirationDate);
                                $("#ctl00_ContentPlaceHolder1_txtCVC").val(obj.CVC);
                                $("#ctl00_ContentPlaceHolder1_txtRecieptEmail").val(obj.Email);
                                $("#ctl00_ContentPlaceHolder1_txtPhoneNo").val(obj.PhoneNo);
                                //$("#ctl00_ContentPlaceHolder1_txtAddressOnCard").val(obj.AddressOnCard);
                                $("#ctl00_ContentPlaceHolder1_txtPhysicalAddress").val(obj.PhysicalAddress);
                                $("#ctl00_ContentPlaceHolder1_ulcardtype").attr('class', obj.CardType);
                                //var usDOTNo = "PC" + obj.DotNo + randomIntFromInterval(10, 99);
                                $("#ctl00_ContentPlaceHolder1_lblMCSaleNo").text(obj.MCSaleNo);
                                $("#ctl00_ContentPlaceHolder1_hidSaleNo").val(obj.MCSaleNo);
                                $("#ctl00_ContentPlaceHolder1_lblUpSaleStatus").text("Upsale");
                                $("#ctl00_ContentPlaceHolder1_hidUpSaleStatus").val("Upsale");
                                $('#ctl00_ContentPlaceHolder1_pnlUpSales').show();
                                $("#upsaletbody").html('');
                                var totalprice = 0;
                                $.each(obj.serviceSaleData, function (a, b) { $("#upsaletbody").append('<td style="padding:8px;">' + b.ServiceName + '</td><td style="padding:8px;">' + b.ServicePrice + '</td>'); totalprice = parseFloat(totalprice) + parseFloat((b.ServicePrice).replace("$", "")) });
                                $('#ctl00_ContentPlaceHolder1_lblUpSaleTotal').text("$" + totalprice);
                                $('#ctl00_ContentPlaceHolder1_hidUpSaleHtml').val($("#upsaletable").html());
                            }
                        }
                        else {
                            $("#ctl00_ContentPlaceHolder1_txtDOTPin").val('');
                            $("#ctl00_ContentPlaceHolder1_txtMC").val('');
                            $("#ctl00_ContentPlaceHolder1_txtLegalName").val('');
                            $("#ctl00_ContentPlaceHolder1_txtDBA").val('');
                            $("#ctl00_ContentPlaceHolder1_txtCardNo").val('');
                            $("#ctl00_ContentPlaceHolder1_txtNameOnCard").val('');
                            $("#ctl00_ContentPlaceHolder1_txtExpirationDate").val('');
                            $("#ctl00_ContentPlaceHolder1_txtCVC").val('');
                            $("#ctl00_ContentPlaceHolder1_txtRecieptEmail").val('');
                            $("#ctl00_ContentPlaceHolder1_txtPhoneNo").val('');
                            $("#ctl00_ContentPlaceHolder1_txtAddressOnCard").val('');
                            $("#ctl00_ContentPlaceHolder1_txtPhysicalAddress").val('');
                            $("#ctl00_ContentPlaceHolder1_ulcardtype").attr('class', 'card_logos');
                            $('#ctl00_ContentPlaceHolder1_hidCardNo').val('');
                            var usDOTNo = "PC" + $("#ctl00_ContentPlaceHolder1_txtDOT").val() + randomIntFromInterval(10, 99);
                            $("#ctl00_ContentPlaceHolder1_lblMCSaleNo").text(usDOTNo);
                            $("#ctl00_ContentPlaceHolder1_hidSaleNo").val(usDOTNo);
                            $("#ctl00_ContentPlaceHolder1_lblUpSaleStatus").text("");
                            $("#ctl00_ContentPlaceHolder1_hidUpSaleStatus").val("");
                            $('#ctl00_ContentPlaceHolder1_pnlUpSales').hide();
                            debugger;
                            $('#ctl00_ContentPlaceHolder1_hidUpSaleHtml').val("");
                        }
                    }
                });
            });

            $("#ctl00_ContentPlaceHolder1_txtCardNo").click(function () {
                var str = $("#ctl00_ContentPlaceHolder1_txtCardNo").val();
                str = str.replace(/\d(?=\d{16})/g, "*");
                $("#ctl00_ContentPlaceHolder1_txtCardNo").val($('#ctl00_ContentPlaceHolder1_hidCardNo').val());
            });

            $("#ctl00_ContentPlaceHolder1_txtCardNo").change(function () {
                $('#ctl00_ContentPlaceHolder1_hidCardNo').val($("#ctl00_ContentPlaceHolder1_txtCardNo").val());
                var str = $("#ctl00_ContentPlaceHolder1_txtCardNo").val();
                str = str.replace(/\d(?=\d{4})/g, "*");
                $("#ctl00_ContentPlaceHolder1_txtCardNo").val(str);
                $('#ctl00_ContentPlaceHolder1_hdnCardType').val($("#ctl00_ContentPlaceHolder1_ulcardtype").attr('class'));
            });

            if ($("#ctl00_ContentPlaceHolder1_hidUpSaleStatus").val() != "") {
                $("#ctl00_ContentPlaceHolder1_lblUpSaleStatus").text($("#ctl00_ContentPlaceHolder1_hidUpSaleStatus").val());
            }

            if ($("#ctl00_ContentPlaceHolder1_hidUpSaleStatus").val() != "Upsale") {
                if ($("#ctl00_ContentPlaceHolder1_txtDOT").val() != "") {
                    $("#ctl00_ContentPlaceHolder1_lblMCSaleNo").text("PC" + $("#ctl00_ContentPlaceHolder1_txtDOT").val() + randomIntFromInterval(10, 99));
                }
            }
            else {
                $("#ctl00_ContentPlaceHolder1_lblMCSaleNo").text($("#ctl00_ContentPlaceHolder1_hidSaleNo").val());
            }

            var str = $("#ctl00_ContentPlaceHolder1_txtCardNo").val();
            str = str.replace(/\d(?=\d{4})/g, "*");
            $("#ctl00_ContentPlaceHolder1_txtCardNo").val(str);

            if ($('#ctl00_ContentPlaceHolder1_hdnCardType').val() != "") {
                $("#ctl00_ContentPlaceHolder1_ulcardtype").attr('class', $('#ctl00_ContentPlaceHolder1_hdnCardType').val());
            }

            if ($('#ctl00_ContentPlaceHolder1_hidUpSaleHtml').val() != "") {
                $('#ctl00_ContentPlaceHolder1_pnlUpSales').show();
                $("#upsaletable").html($('#ctl00_ContentPlaceHolder1_hidUpSaleHtml').val());
            }

        });

        function randomIntFromInterval(min, max) {
            return Math.floor(Math.random() * (max - min + 1) + min);
        }

        function autoscroll() {
            $('#ctl00_ContentPlaceHolder1_txtCardNo').creditCardTypeDetector({ 'credit_card_logos': '.card_logos' });
            $('#ctl00_ContentPlaceHolder1_chkSameAddress').click(function () {
                if ($("#ctl00_ContentPlaceHolder1_chkSameAddress").is(':checked'))
                    $("#ctl00_ContentPlaceHolder1_txtPhysicalAddress").val($('#ctl00_ContentPlaceHolder1_txtAddressOnCard').val());  // checked
                else
                    $("#ctl00_ContentPlaceHolder1_txtPhysicalAddress").val("");
            });

            $("#ctl00_ContentPlaceHolder1_txtRecieptEmail").change(function () {
                $.getJSON('https://apilayer.net/api/check?access_key=546aa8dd08e7c1363883e28154fecaef&email=' + $("#ctl00_ContentPlaceHolder1_txtRecieptEmail").val() + '&smtp=1&format=1', function (data) {
                    var element = $("#ctl00_ContentPlaceHolder1_txtRecieptEmail")[0];
                    if (data.mx_found == false || data.mx_found == null) {
                        element.setCustomValidity("Not a valid email address.");
                    }
                    else {
                        element.setCustomValidity("");
                    }
                });
            });

            $("#ctl00_ContentPlaceHolder1_txtDOT").change(function () {
                $.ajax({
                    url: 'MCDriverProfile.aspx/GetUSDOTDetails',
                    type: "POST",
                    data: '{usdotno: "' + $(this).val() + '" }',
                    dataType: "json",
                    contentType: "application/json; charset=utf-8",
                    success: function (data) {
                        if (data.d != "null") {
                            var obj = JSON.parse(data.d); console.log(obj.Status);
                            if (obj.Status != undefined) {
                                $("#ctl00_ContentPlaceHolder1_txtDOT").val(obj.DOTNumber);
                                $("#ctl00_ContentPlaceHolder1_txtLegalName").val(obj.LegalName);
                                $("#ctl00_ContentPlaceHolder1_txtPhysicalAddress").val(obj.PhysicalAddress);
                                var usDOTNo = "PC" + obj.DOTNumber + randomIntFromInterval(10, 99);
                                $("#ctl00_ContentPlaceHolder1_lblMCSaleNo").text(usDOTNo);
                                $("#ctl00_ContentPlaceHolder1_hidSaleNo").val(usDOTNo);

                                $("#ctl00_ContentPlaceHolder1_txtDOTPin").val('');
                                $("#ctl00_ContentPlaceHolder1_txtMC").val('');
                                $("#ctl00_ContentPlaceHolder1_txtDBA").val('');
                                $("#ctl00_ContentPlaceHolder1_txtCardNo").val('');
                                $("#ctl00_ContentPlaceHolder1_txtNameOnCard").val('');
                                $("#ctl00_ContentPlaceHolder1_txtExpirationDate").val('');
                                $("#ctl00_ContentPlaceHolder1_txtCVC").val('');
                                $("#ctl00_ContentPlaceHolder1_txtRecieptEmail").val('');
                                $("#ctl00_ContentPlaceHolder1_txtPhoneNo").val('');
                                $("#ctl00_ContentPlaceHolder1_txtAddressOnCard").val('');
                                $("#ctl00_ContentPlaceHolder1_ulcardtype").attr('class', 'card_logos');
                                $('#ctl00_ContentPlaceHolder1_hidCardNo').val('');
                                $("#ctl00_ContentPlaceHolder1_lblUpSaleStatus").text("Not an Upsale");
                                $("#ctl00_ContentPlaceHolder1_hidUpSaleStatus").val("Not an Upsale");
                                debugger;
                                $('#ctl00_ContentPlaceHolder1_hidUpSaleHtml').val("");
                                $('#ctl00_ContentPlaceHolder1_pnlUpSales').hide();
                            }
                            else {
                                $("#ctl00_ContentPlaceHolder1_txtDOT").val(obj.DotNo);
                                $("#ctl00_ContentPlaceHolder1_txtDOTPin").val(obj.DotPin);
                                $("#ctl00_ContentPlaceHolder1_txtMC").val(obj.MCNo);
                                $("#ctl00_ContentPlaceHolder1_txtLegalName").val(obj.LegalName);
                                $("#ctl00_ContentPlaceHolder1_txtDBA").val(obj.DBA);
                                $("#ctl00_ContentPlaceHolder1_txtCardNo").val(obj.CardNo);
                                $('#ctl00_ContentPlaceHolder1_hidCardNo').val($("#ctl00_ContentPlaceHolder1_txtCardNo").val());
                                var str = $("#ctl00_ContentPlaceHolder1_txtCardNo").val();
                                str = str.replace(/\d(?=\d{4})/g, "*");
                                $("#ctl00_ContentPlaceHolder1_txtCardNo").val(str);
                                $('#ctl00_ContentPlaceHolder1_hdnCardType').val($("#ctl00_ContentPlaceHolder1_ulcardtype").attr('class'));
                                $("#ctl00_ContentPlaceHolder1_txtNameOnCard").val(obj.NameOnCard);
                                $("#ctl00_ContentPlaceHolder1_txtExpirationDate").val(obj.ExpirationDate);
                                $("#ctl00_ContentPlaceHolder1_txtCVC").val(obj.CVC);
                                $("#ctl00_ContentPlaceHolder1_txtRecieptEmail").val(obj.Email);
                                $("#ctl00_ContentPlaceHolder1_txtPhoneNo").val(obj.PhoneNo);
                                //$("#ctl00_ContentPlaceHolder1_txtAddressOnCard").val(obj.AddressOnCard);
                                $("#ctl00_ContentPlaceHolder1_txtPhysicalAddress").val(obj.PhysicalAddress);
                                $("#ctl00_ContentPlaceHolder1_ulcardtype").attr('class', obj.CardType);
                                //var usDOTNo = "PC" + obj.DotNo + randomIntFromInterval(10, 99);
                                $("#ctl00_ContentPlaceHolder1_lblMCSaleNo").text(obj.MCSaleNo);
                                $("#ctl00_ContentPlaceHolder1_hidSaleNo").val(obj.MCSaleNo);
                                $("#ctl00_ContentPlaceHolder1_lblUpSaleStatus").text("Upsale");
                                $("#ctl00_ContentPlaceHolder1_hidUpSaleStatus").val("Upsale");
                                $('#ctl00_ContentPlaceHolder1_pnlUpSales').show();
                                $("#upsaletbody").html('');
                                var totalprice = 0;
                                $.each(obj.serviceSaleData, function (a, b) { $("#upsaletbody").append('<td style="padding:8px;">' + b.ServiceName + '</td><td style="padding:8px;">' + b.ServicePrice + '</td>'); totalprice = parseFloat(totalprice) + parseFloat((b.ServicePrice).replace("$", "")) });
                                $('#ctl00_ContentPlaceHolder1_lblUpSaleTotal').text("$" + totalprice);
                                $('#ctl00_ContentPlaceHolder1_hidUpSaleHtml').val($("#upsaletbody").html());
                            }
                        }
                        else {
                            $("#ctl00_ContentPlaceHolder1_txtDOTPin").val('');
                            $("#ctl00_ContentPlaceHolder1_txtMC").val('');
                            $("#ctl00_ContentPlaceHolder1_txtLegalName").val('');
                            $("#ctl00_ContentPlaceHolder1_txtDBA").val('');
                            $("#ctl00_ContentPlaceHolder1_txtCardNo").val('');
                            $("#ctl00_ContentPlaceHolder1_txtNameOnCard").val('');
                            $("#ctl00_ContentPlaceHolder1_txtExpirationDate").val('');
                            $("#ctl00_ContentPlaceHolder1_txtCVC").val('');
                            $("#ctl00_ContentPlaceHolder1_txtRecieptEmail").val('');
                            $("#ctl00_ContentPlaceHolder1_txtPhoneNo").val('');
                            $("#ctl00_ContentPlaceHolder1_txtAddressOnCard").val('');
                            $("#ctl00_ContentPlaceHolder1_txtPhysicalAddress").val('');
                            $("#ctl00_ContentPlaceHolder1_ulcardtype").attr('class', 'card_logos');
                            $('#ctl00_ContentPlaceHolder1_hidCardNo').val('');
                            var usDOTNo = "PC" + $("#ctl00_ContentPlaceHolder1_txtDOT").val() + randomIntFromInterval(10, 99);
                            $("#ctl00_ContentPlaceHolder1_lblMCSaleNo").text(usDOTNo);
                            $("#ctl00_ContentPlaceHolder1_hidSaleNo").val(usDOTNo);
                            $("#ctl00_ContentPlaceHolder1_lblUpSaleStatus").text("");
                            $("#ctl00_ContentPlaceHolder1_hidUpSaleStatus").val("");
                            $('#ctl00_ContentPlaceHolder1_pnlUpSales').hide();
                            debugger;
                            $('#ctl00_ContentPlaceHolder1_hidUpSaleHtml').val("");
                        }
                    }
                });
            });

            $("#ctl00_ContentPlaceHolder1_txtCardNo").click(function () {
                var str = $("#ctl00_ContentPlaceHolder1_txtCardNo").val();
                str = str.replace(/\d(?=\d{16})/g, "*");
                $("#ctl00_ContentPlaceHolder1_txtCardNo").val($('#ctl00_ContentPlaceHolder1_hidCardNo').val());
            });

            $("#ctl00_ContentPlaceHolder1_txtCardNo").change(function () {
                $('#ctl00_ContentPlaceHolder1_hidCardNo').val($("#ctl00_ContentPlaceHolder1_txtCardNo").val());
                var str = $("#ctl00_ContentPlaceHolder1_txtCardNo").val();
                str = str.replace(/\d(?=\d{4})/g, "*");
                $("#ctl00_ContentPlaceHolder1_txtCardNo").val(str);
                $('#ctl00_ContentPlaceHolder1_hdnCardType').val($("#ctl00_ContentPlaceHolder1_ulcardtype").attr('class'));
            });

            if ($("#ctl00_ContentPlaceHolder1_hidUpSaleStatus").val() != "") {
                $("#ctl00_ContentPlaceHolder1_lblUpSaleStatus").text($("#ctl00_ContentPlaceHolder1_hidUpSaleStatus").val());
            }

            if ($("#ctl00_ContentPlaceHolder1_hidUpSaleStatus").val() != "Upsale") {
                if ($("#ctl00_ContentPlaceHolder1_txtDOT").val() != "") {
                    $("#ctl00_ContentPlaceHolder1_lblMCSaleNo").text("PC" + $("#ctl00_ContentPlaceHolder1_txtDOT").val() + randomIntFromInterval(10, 99));
                }
            }
            else {
                $("#ctl00_ContentPlaceHolder1_lblMCSaleNo").text($("#ctl00_ContentPlaceHolder1_hidSaleNo").val());
            }

            var str = $("#ctl00_ContentPlaceHolder1_txtCardNo").val();
            str = str.replace(/\d(?=\d{4})/g, "*");
            $("#ctl00_ContentPlaceHolder1_txtCardNo").val(str);

            if ($('#ctl00_ContentPlaceHolder1_hdnCardType').val() != "") {
                $("#ctl00_ContentPlaceHolder1_ulcardtype").attr('class', $('#ctl00_ContentPlaceHolder1_hdnCardType').val());
            }

            if ($('#ctl00_ContentPlaceHolder1_hidUpSaleHtml').val() != "") {
                $('#ctl00_ContentPlaceHolder1_pnlUpSales').show();
                $("#upsaletable").html($('#ctl00_ContentPlaceHolder1_hidUpSaleHtml').val());
            }
        }

        Sys.WebForms.PageRequestManager.getInstance().add_endRequest(autoscroll);
    </script>
</asp:Content>
