<%@ Page Title="" Language="C#" MasterPageFile="~/ComplianceMaster.Master" AutoEventWireup="true" CodeBehind="ViewMCSale.aspx.cs" Inherits="PrivateICO.ViewMCSale" %>

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
                <h1>Add MC# Profile
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
                        <h3 class="box-title">MC Sale# : <asp:Label ID="lblMCSaleNo" runat="server" Text=""></asp:Label></h3>

                        <div class="box-tools pull-right">
                            <button type="button" class="btn btn-box-tool" data-widget="collapse"><i class="fa fa-minus"></i></button>
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
                                    <label>Name on Card</label>
                                    <asp:TextBox runat="server" ID="txtNameOnCard" ReadOnly="true" CssClass="form-control" placeholder="Enter Name"></asp:TextBox>
                                </div>
                                <!-- /.form-group -->
                            </div>

                            <div class="col-md-6">

                                <div class="form-group">
                                    <label>Card No</label>
                                    <asp:TextBox runat="server" ID="txtCardNo" ReadOnly="true" CssClass="form-control" placeholder="Enter Card No"></asp:TextBox>
                                </div>
                                <!-- /.form-group -->
                            </div>

                            <div class="col-md-6">

                                <div class="form-group">
                                    <label>Email for Reciept and Service</label>
                                    <asp:TextBox runat="server" ID="txtRecieptEmail" ReadOnly="true" CssClass="form-control" placeholder="Enter Email"></asp:TextBox>
                                </div>
                                <!-- /.form-group -->
                            </div>

                            <div class="col-md-12">

                                <div class="form-group">
                                    <label>Address on Card</label>
                                    <asp:TextBox runat="server" ID="txtAddressOnCard" ReadOnly="true" CssClass="form-control" placeholder="Enter Address"></asp:TextBox>
                                </div>
                                <!-- /.form-group -->
                            </div>

                            <div class="col-md-12">

                                <div class="form-group">
                                    <label>Physical Address</label>
                                    <asp:TextBox runat="server" ID="txtPhysicalAddress" ReadOnly="true" CssClass="form-control" placeholder="Enter Phyisical Address"></asp:TextBox>
                                </div>
                                <!-- /.form-group -->
                            </div>

                            <asp:Panel ID="pnlServiceList" runat="server">
                                <div class="col-md-12">

                                    <div class="form-group">
                                        <asp:ListView ID="lstServicesPurchased" runat="server" ItemPlaceholderID="groupPlaceHolder1">
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

                                                                            </tr>
                                                                        </thead>
                                                                        <tbody>

                                                                            <asp:PlaceHolder runat="server" ID="groupPlaceHolder1"></asp:PlaceHolder>

                                                                        </tbody>
                                                                        <tfoot>
                                                                            <tr>
                                                                                <td align="right">Sub Total : 
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

                                                </tr>
                                            </ItemTemplate>


                                        </asp:ListView>
                                    </div>
                                </div>
                            </asp:Panel>
                        </div>
                        <!-- /.row -->
                    </div>
                </div>
            </section>


        </div>
    </div>
    <script type="text/javascript">
        $(document).ready(function () {
            var str = $("#ctl00_ContentPlaceHolder1_txtCardNo").val();
            str = str.replace(/\d(?=\d{0})/g, "*");
            $("#ctl00_ContentPlaceHolder1_txtCardNo").val(str);
        });
    </script>
</asp:Content>
