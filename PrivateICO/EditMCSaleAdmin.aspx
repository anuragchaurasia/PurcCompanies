<%@ Page Title="" Language="C#" MasterPageFile="~/AdminMaster.Master" AutoEventWireup="true" CodeBehind="EditMCSaleAdmin.aspx.cs" Inherits="PrivateICO.EditMCSaleAdmin" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <div class="content-wrapper">
            <!-- Content Header (Page header) -->
            <section class="content-header">
                <h1>Edit MC# Profile
                </h1>
                <ol class="breadcrumb">
                    <li><a href="#"><i class="fa fa-dashboard"></i>Dashboard</a></li>
                    <li><a href="#">Sales</a></li>
                    <li class="active">Edit MC# Profile</li>
                </ol>
            </section>

            <section class="content" id="example2">

                <!-- SELECT2 EXAMPLE -->
                <div class="box box-default">
                    <div class="box-header with-border">
                        <h3 class="box-title">MC Sale# :
                            <asp:Label ID="lblMCSaleNo" runat="server" Text=""></asp:Label></h3>
                        <h3 class="box-title">Sales Person Name :
                            <asp:Label ID="lblSalesPersonName" runat="server" Text=""></asp:Label></h3>
                        <div class="pull-right">
                            <asp:LinkButton runat="server" ID="btnPrint" Text="Print" CssClass="btn btn-block btn-success" />
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
                                    <asp:HiddenField ID="hidCardNo" runat="server" />
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
                                    <label>CVC </label>
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
                                                                    <table class="table table-bordered table-hover">
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
                                                        <asp:LinkButton runat="server" ID="lnkDelete" CssClass="fa fa-fw fa-trash" OnClientClick="javascript:return confirm('Are you sure you want to delete this Service ?');" CommandArgument='<%# Eval("DocumentID") %>' CommandName="DelService"></asp:LinkButton>
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
                                    <asp:Button runat="server" ID="btnEditProfile" Text="Update Details" CssClass="btn btn-block btn-success" OnClick="btnEditProfile_Click" />
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
            $('#ctl00_ContentPlaceHolder1_btnPrint').click(function () {
                //alert("Print feature is not available at the moment.");
                printData();
                return false;
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
            });
            var str = $("#ctl00_ContentPlaceHolder1_txtCardNo").val();
            str = str.replace(/\d(?=\d{4})/g, "*");
            $("#ctl00_ContentPlaceHolder1_txtCardNo").val(str);

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
        });

        function printData() {
            var divToPrint = $("#example2");
            divToPrint.find('#ctl00_ContentPlaceHolder1_txtCardNo').attr('value', divToPrint.find('#ctl00_ContentPlaceHolder1_txtCardNo').val().replace(/\d(?=\d{4})/g, "*"));
            newWin = window.open("");
            
            //newWin.document.write('<html><head><link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/admin-lte/2.4.3/css/AdminLTE.css" media="print" /><link href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css" rel="stylesheet" media="print" type="text/css"></head><body>' + divToPrint.outerHTML + '</body></html>');
            newWin.document.write(divToPrint.html());
            newWin.print();
            newWin.close();
        }

        function autoscroll() {
            $('#ctl00_ContentPlaceHolder1_txtCardNo').creditCardTypeDetector({ 'credit_card_logos': '.card_logos' });
            $('#ctl00_ContentPlaceHolder1_chkSameAddress').click(function () {
                if ($("#ctl00_ContentPlaceHolder1_chkSameAddress").is(':checked'))
                    $("#ctl00_ContentPlaceHolder1_txtPhysicalAddress").val($('#ctl00_ContentPlaceHolder1_txtAddressOnCard').val());  // checked
                else
                    $("#ctl00_ContentPlaceHolder1_txtPhysicalAddress").val("");
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
            });
            var str = $("#ctl00_ContentPlaceHolder1_txtCardNo").val();
            str = str.replace(/\d(?=\d{4})/g, "*");
            $("#ctl00_ContentPlaceHolder1_txtCardNo").val(str);

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
        }

        Sys.WebForms.PageRequestManager.getInstance().add_endRequest(autoscroll);
        Sys.WebForms.PageRequestManager.getInstance().add_endRequest(printData);
    </script>
</asp:Content>
