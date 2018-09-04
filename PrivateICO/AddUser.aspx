<%@ Page Title="" Language="C#" MasterPageFile="~/AdminMaster.Master" AutoEventWireup="true" CodeBehind="AddUser.aspx.cs" Inherits="PrivateICO.AddUser" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <%--  <!-- daterange picker -->
    <link rel="stylesheet" href="../../plugins/daterangepicker/daterangepicker.css">
    <!-- bootstrap datepicker -->
    <link rel="stylesheet" href="../../plugins/datepicker/datepicker3.css">
    <!-- iCheck for checkboxes and radio inputs -->
    <link rel="stylesheet" href="../../plugins/iCheck/all.css">
    <!-- Bootstrap Color Picker -->
    <link rel="stylesheet" href="../../plugins/colorpicker/bootstrap-colorpicker.min.css">
    <!-- Bootstrap time Picker -->
    <link rel="stylesheet" href="../../plugins/timepicker/bootstrap-timepicker.min.css">
    <!-- Select2 -->
    <link rel="stylesheet" href="/plugins/select2/select2.min.css">--%>

     <!-- daterange picker -->
    <link rel="stylesheet" href="../../web/plugins/daterangepicker/daterangepicker.css">
    <!-- bootstrap datepicker -->
    <link rel="stylesheet" href="../../web/plugins/datepicker/datepicker3.css">
    <!-- iCheck for checkboxes and radio inputs -->
    <link rel="stylesheet" href="../../web/plugins/iCheck/all.css">
    <!-- Bootstrap Color Picker -->
    <link rel="stylesheet" href="../../web/plugins/colorpicker/bootstrap-colorpicker.min.css">
    <!-- Bootstrap time Picker -->
    <link rel="stylesheet" href="../../web/plugins/timepicker/bootstrap-timepicker.min.css">
    <!-- Select2 -->
    <link rel="stylesheet" href="/web/plugins/select2/select2.min.css">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>

        <div class="content-wrapper">
            <!-- Content Header (Page header) -->
            <section class="content-header">
                <h1>Add Customers
                </h1>
                <ol class="breadcrumb">
                    <li><a href="#"><i class="fa fa-dashboard"></i>Dashboard</a></li>
                    <li><a href="#">Customers</a></li>
                    <li class="active">Add Customers</li>
                </ol>
            </section>

            <!-- General Info -->
            <section class="content">

                <!-- SELECT2 EXAMPLE -->
                <div class="box box-default">
                    <div class="box-header with-border">
                        <h3 class="box-title">General Info</h3>

                        <div class="box-tools pull-right">
                            <button type="button" class="btn btn-box-tool" data-widget="collapse"><i class="fa fa-minus"></i></button>
                        </div>
                    </div>
                    <!-- /.box-header -->
                    <div class="box-body">
                        <div class="row">
                            <div class="col-md-6">
                                <div class="form-group">
                                    <label>Username*</label>
                                    <asp:TextBox runat="server" ID="txtUsername" CssClass="form-control" placeholder="Enter Username"></asp:TextBox>
                                </div>
                                <!-- /.form-group -->
                                <div class="form-group">
                                    <label>Email*</label>
                                    <asp:TextBox runat="server" ID="txtEmail" CssClass="form-control" placeholder="Enter Email"></asp:TextBox>
                                </div>
                                <!-- /.form-group -->
                            </div>
                            <!-- /.col -->
                            <div class="col-md-6">
                                <div class="form-group">
                                    <label>Name*</label>
                                    <asp:TextBox runat="server" ID="txtName" CssClass="form-control" placeholder="Enter Name"></asp:TextBox>
                                </div>
                                <!-- /.form-group -->
                                <div class="form-group">
                                    <label>Phone No.*</label>
                                    <asp:TextBox runat="server" ID="txtPhoneNo" CssClass="form-control" placeholder="Enter Phone No"></asp:TextBox>
                                </div>
                                <!-- /.form-group -->
                            </div>

                            <div class="col-md-6">
                                <div class="form-group">
                                    <label>USDot</label>
                                    <asp:TextBox runat="server" ID="txtUsDot" CssClass="form-control" placeholder="Enter Name"></asp:TextBox>
                                </div>
                                
                            </div>
                            <!-- /.col -->
                            <div class="col-md-6" style="display:none;">
                                <div class="form-group">
                                    <label>Password*</label>
                                    <asp:TextBox runat="server" ID="txtPassword" CssClass="form-control" TextMode="Password"  placeholder="Enter Password"></asp:TextBox>
                                </div>

                            </div>

                            <div class="col-md-6" style="display:none;">
                                <div class="form-group">
                                    <label>Confirm Password*</label>
                                    <asp:TextBox runat="server" ID="txtConfirmPassword" CssClass="form-control" TextMode="Password"  placeholder="Enter Password Again"></asp:TextBox>
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
            <section class="content">

                <!-- SELECT2 EXAMPLE -->
                <div class="box box-default">
                    <div class="box-header with-border">
                        <h3 class="box-title">Address Detail</h3>

                        <div class="box-tools pull-right">
                            <button type="button" class="btn btn-box-tool" data-widget="collapse"><i class="fa fa-minus"></i></button>
                        </div>
                    </div>
                    <!-- /.box-header -->
                    <div class="box-body">
                        <div class="row">
                            <div class="col-md-12">

                                <!-- /.form-group -->
                                <div class="form-group">
                                    <label>Address*</label>
                                    <asp:TextBox runat="server" ID="txtAddress" CssClass="form-control" TextMode="MultiLine" placeholder="Enter Address"></asp:TextBox>
                                </div>
                                <!-- /.form-group -->
                            </div>

                            <div class="col-md-6">
                                <!-- /.form-group -->
                                <div class="form-group">
                                    <label>Country</label>
                                    <asp:DropDownList CssClass="form-control select2" runat="Server" ID="ddlCountry" Style="width: 100%;">
                                        <asp:ListItem Selected="True">United States of America</asp:ListItem>
                                        <asp:ListItem>Canada</asp:ListItem>
                                    </asp:DropDownList>

                                </div>
                            </div>
                            <div class="col-md-6">
                                <!-- /.form-group -->
                                <div class="form-group">
                                    <label>States</label>
                                    <asp:DropDownList CssClass="form-control select2" runat="Server" ID="ddlStates" Style="width: 100%;">
                                        <asp:ListItem Selected="True">Alabama</asp:ListItem>
                                        <asp:ListItem>Alaska</asp:ListItem>
                                        <asp:ListItem>California</asp:ListItem>
                                        <asp:ListItem>Delaware</asp:ListItem>
                                        <asp:ListItem>Idaho</asp:ListItem>
                                        <asp:ListItem>North Carolina</asp:ListItem>
                                        <asp:ListItem>Texas</asp:ListItem>
                                        <asp:ListItem>Washington</asp:ListItem>
                                    </asp:DropDownList>

                                </div>
                            </div>
                            <div class="col-md-6">

                                <!-- /.form-group -->
                                <div class="form-group">
                                    <label>Zip Code</label>
                                    <asp:TextBox runat="server" ID="txtZipCode" CssClass="form-control" placeholder="Enter Zipcode"></asp:TextBox>
                                </div>

                                <!-- /.form-group -->
                            </div>
                            <div class="col-md-6">
                                <label></label>
                                <div class="form-group">
                                    <asp:Button runat="server" ID="btnSaveCustomer" Text="Save Customers" CssClass="btn btn-block btn-success" OnClick="btnSaveCustomer_Click" />
                                </div>
                            </div>
                        </div>
                        <!-- /.row -->
                    </div>
                    <!-- /.box-body -->

                </div>
                <!-- /.box -->


                <!-- /.row -->

            </section>
            <!-- /.content -->
        </div>

    </div>

  


</asp:Content>
