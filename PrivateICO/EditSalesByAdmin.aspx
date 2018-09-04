<%@ Page Title="" Language="C#" MasterPageFile="~/AdminMaster.Master" AutoEventWireup="true" CodeBehind="EditSalesByAdmin.aspx.cs" Inherits="PrivateICO.EditSalesByAdmin" %>

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
                <h1>Edit Sales Person
                </h1>
                <ol class="breadcrumb">
                    <li><a href="#"><i class="fa fa-dashboard"></i>Dashboard</a></li>
                    <li><a href="#">Sales Person</a></li>
                    <li class="active">Edit Sales Person</li>
                </ol>
            </section>

            <!-- General Info -->
            <section class="content">

                <!-- SELECT2 EXAMPLE -->
                <div class="box box-default">
                    <div class="box-header with-border">
                        <h3 class="box-title">Edit User Info</h3>

                        <div class="pull-right">
                            <asp:LinkButton runat="server" ID="btnChangePass" Text="Change Password" OnClick="btnChangePass_Click" CssClass="btn btn-block btn-success" />
                        </div>
                    </div>
                    <!-- /.box-header -->
                    <div class="box-body">
                        <div class="row">
                            <div class="col-md-6">
                                <div class="form-group">
                                    <label>Name*</label>
                                    <asp:TextBox runat="server" ID="txtFirstName" CssClass="form-control" required placeholder="Enter First Name"></asp:TextBox>
                                </div>

                            </div>

                            <div class="col-md-6">

                                <div class="form-group">
                                    <label>Email*</label>
                                    <asp:TextBox runat="server" ID="txtEmail" CssClass="form-control" required placeholder="Enter Email"></asp:TextBox>
                                </div>
                                <!-- /.form-group -->
                            </div>

                            <div class="col-md-6">
                                <div class="form-group">
                                    <label>1099 Contractor</label>
                                    <div>
                                        <asp:CheckBox runat="server" ID="ChkIsContractor" Text=" Is Contractor ?"></asp:CheckBox>
                                    </div>
                                </div>
                            </div>

                            <div class="col-md-6">
                                <div class="form-group">
                                    <label>User Type</label>
                                    <div>
                                        <asp:DropDownList runat="server" ID="ddlUserType" CssClass="form-control">
                                            <asp:ListItem>Sales</asp:ListItem>
                                            <asp:ListItem>Admin</asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                </div>
                            </div>

                            <div class="col-md-6">
                                <div class="form-group">
                                    <label>Active</label>
                                    <div>
                                        <asp:CheckBox runat="server" ID="chkIsActive" Text=" Is Active ?"></asp:CheckBox>
                                    </div>
                                </div>
                            </div>
                            <div class="col-md-6">
                                <div class="form-group">
                                    <label>Extension No.</label>
                                    <asp:TextBox runat="server" title="Extension No for Ring Central" ID="txtExtensionNo" CssClass="form-control" placeholder="Ring Central Extension No"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-md-6">
                                <label></label>
                                <div class="form-group">
                                    <asp:Button runat="server" ID="btnEditUser" Text="Edit User" OnClick="btnEditUser_Click" CssClass="btn btn-block btn-success" />
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
            $('#ctl00_ContentPlaceHolder1_ddlUserType').change(function () {
            });
        });
    </script>
</asp:Content>
