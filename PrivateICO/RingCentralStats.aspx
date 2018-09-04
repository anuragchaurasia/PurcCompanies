<%@ Page Title="" Language="C#" MasterPageFile="~/AdminMaster.Master" Async="true"  AutoEventWireup="true" CodeBehind="RingCentralStats.aspx.cs" Inherits="PrivateICO.RingCentralStats" %>
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
                <h1>Ring Central Details
                </h1>
                <ol class="breadcrumb">
                    <li><a href="#"><i class="fa fa-dashboard"></i>Dashboard</a></li>
                    <li><a href="#">Ring Central</a></li>
                    <li class="active">User Stats</li>
                </ol>
            </section>

            <!-- General Info -->
            <section class="content">

                <!-- SELECT2 EXAMPLE -->
                <div class="box box-default">
                    <!-- /.box-header -->
                    <div class="box-body">
                        <div class="row">

                            <div class="col-md-6">
                                <div class="form-group">
                                    <label><b>Total Contacts</b></label>
                                    
                                </div>

                            </div>

                            <div class="col-md-6">

                                <div class="form-group">
                                    <label>
                                        <asp:Label ID="lblTotalContacts" runat="server" Text=""></asp:Label></label>
                                </div>
                            </div>

                            <div class="col-md-6">
                                <div class="form-group">
                                    <label><b>User Status</b></label>
                                    
                                </div>

                            </div>

                            <div class="col-md-6">

                                <div class="form-group">
                                    <label>
                                        <asp:Label ID="lblUserStatus" runat="server" Text=""></asp:Label></label>
                                </div>
                            </div>

                            <div class="col-md-6">
                                <div class="form-group">
                                    <label><b>Total Calls</b></label>
                                    
                                </div>

                            </div>

                            <div class="col-md-6">

                                <div class="form-group">
                                    <label>
                                        <asp:Label ID="lblTotalCalls" runat="server" Text=""></asp:Label></label>
                                </div>
                            </div>

                            <div class="col-md-6">
                                <div class="form-group">
                                    <label><b>Total Time </b></label>
                                    
                                </div>

                            </div>

                            <div class="col-md-6">

                                <div class="form-group">
                                    <label>
                                        <asp:Label ID="lblTotalTime" runat="server" Text=""></asp:Label></label>
                                </div>
                            </div>

                             <div class="col-md-6">
                                <div class="form-group">
                                    <label><b>No Of Inbound Calls </b></label>
                                    
                                </div>

                            </div>

                            <div class="col-md-6">

                                <div class="form-group">
                                    <label>
                                        <asp:Label ID="lblInBoundCalls" runat="server" Text=""></asp:Label></label>
                                </div>
                            </div>

                            <div class="col-md-6">
                                <div class="form-group">
                                    <label><b>No Of VoiceMails</b></label>
                                    
                                </div>

                            </div>

                            <div class="col-md-6">

                                <div class="form-group">
                                    <label>
                                        <asp:Label ID="lblVoiceMails" runat="server" Text=""></asp:Label></label>
                                </div>
                            </div>

                            <div class="col-md-6">
                                <div class="form-group">
                                    <label><b>Calls Average</b></label>
                                    
                                </div>

                            </div>

                            <div class="col-md-6">

                                <div class="form-group">
                                    <label>
                                        <asp:Label ID="lblCallAverage" runat="server" Text=""></asp:Label></label>
                                </div>
                            </div>

                            
                            <div class="col-md-6">
                                <div class="form-group">
                                    <label><b>Total Closed Sales</b></label>
                                    
                                </div>

                            </div>

                            <div class="col-md-6">

                                <div class="form-group">
                                    <label>
                                        <asp:Label ID="lblClosedSales" runat="server" Text=""></asp:Label></label>
                                </div>
                            </div>
                           
                            <div class="col-md-6">
                                <div class="form-group">
                                    <label><b>Total Do Not Call Sales</b></label>
                                    
                                </div>

                            </div>

                            <div class="col-md-6">

                                <div class="form-group">
                                    <label>
                                        <asp:Label ID="lblDoNotCall" runat="server" Text=""></asp:Label></label>
                                </div>
                            </div>

                             <div class="col-md-6">
                                <div class="form-group">
                                    <label><b>Total Closing Statements</b></label>
                                    
                                </div>

                            </div>

                            <div class="col-md-6">

                                <div class="form-group">
                                    <label>
                                        <asp:Label ID="lblClosingStatement" runat="server" Text=""></asp:Label></label>
                                </div>
                            </div>

                             <div class="col-md-6">
                                <div class="form-group">
                                    <label><b>Total Follow-Up Sales</b></label>
                                    
                                </div>

                            </div>

                            <div class="col-md-6">

                                <div class="form-group">
                                    <label>
                                        <asp:Label ID="lblFollowUps" runat="server" Text=""></asp:Label></label>
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
</asp:Content>
