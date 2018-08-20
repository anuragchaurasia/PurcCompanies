<%@ Page Title="" Language="C#" MasterPageFile="~/ComplianceMaster.Master" AutoEventWireup="true" CodeBehind="LeadsEntry.aspx.cs" Inherits="PrivateICO.LeadsEntry" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <div class="content-wrapper">
            <!-- Content Header (Page header) -->
            <section class="content-header">
                <h1>Add Lead
                </h1>
                <ol class="breadcrumb">
                    <li><a href="#"><i class="fa fa-dashboard"></i>Dashboard</a></li>
                    <li><a href="#">Sales Leads</a></li>
                    <li class="active">Add Lead</li>
                </ol>
            </section>

            <!-- General Info -->
            <section class="content">

                <!-- SELECT2 EXAMPLE -->
                <div class="box box-default">
                    <div class="box-header with-border">
                        <h3 class="box-title">Lead Info</h3>
                        <div class="box-tools pull-right">
                            <button type="button" class="btn btn-box-tool" data-widget="collapse"><i class="fa fa-minus"></i></button>
                        </div>
                    </div>
                    <!-- /.box-header -->
                    <div class="box-body">
                        <div class="row">

                            <div class="col-md-6">
                                <div class="form-group">
                                    <label>DOT#*</label>
                                    <asp:TextBox runat="server" ID="txtDoT" CssClass="form-control" required placeholder="Enter DOT#"></asp:TextBox>
                                </div>
                            </div>

                            <div class="col-md-6">
                                <div class="form-group">
                                    <label>Business Name*</label>
                                    <asp:TextBox runat="server" ID="txtBusinessName" CssClass="form-control" required placeholder="Enter Business Name"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-md-6">
                                <div class="form-group">
                                    <label>Compliance Agent*</label>
                                    <asp:TextBox runat="server" ID="txtComplianceAgent" CssClass="form-control" required placeholder="Enter Compliance Agent Name"></asp:TextBox>
                                </div>
                                <!-- /.form-group -->
                            </div>

                            <div class="col-md-6">
                                <div class="form-group">
                                    <label>Contact Name</label>
                                    <asp:TextBox runat="server" required ID="txtContactName" CssClass="form-control" placeholder="Enter Contact Name"></asp:TextBox>
                                </div>
                            </div>

                            <div class="col-md-6">
                                <div class="form-group">
                                    <label>Best Phone No for Contact</label>
                                    <asp:TextBox runat="server" required ID="txtBestPhone" CssClass="form-control" placeholder="Enter Best Phone No for Contact"></asp:TextBox>
                                </div>
                            </div>

                            <div class="col-md-6">
                                <div class="form-group">
                                    <label>Choose Email List</label>
                                    <asp:DropDownList ID="drpEmailList" multiple  runat="server" CssClass="form-control"></asp:DropDownList>
                                </div>
                            </div>

                            <div class="col-md-6">
                                <div class="form-group">
                                    <label>Email</label>
                                    <asp:TextBox runat="server" required ID="txtEmail" type="email" CssClass="form-control" placeholder="Enter Email"></asp:TextBox>
                                </div>
                            </div>


                            <div class="col-md-6">
                                <div class="form-group">
                                    <label>TimeLine</label>
                                    <asp:TextBox runat="server" required ID="txtTimeLine" CssClass="form-control" placeholder="Enter Timeline"></asp:TextBox>
                                </div>
                            </div>

                            <div class="col-md-6">
                                <div class="form-group">
                                    <label>Opportunity Discussed</label>
                                    <asp:TextBox runat="server" required ID="txtServiceDiscussed" CssClass="form-control" placeholder="Enter Service Discussed"></asp:TextBox>
                                </div>
                            </div>

                            <div class="col-md-6">
                                <div class="form-group">
                                    <label>Notes</label>
                                    <asp:TextBox runat="server" required ID="txtNotes" CssClass="form-control" placeholder="Enter Notes"></asp:TextBox>
                                </div>
                            </div>

                            <div class="col-md-6">
                                <label></label>
                                <div class="form-group">
                                    <asp:Button runat="server" ID="btnAddLead" OnClientClick="javascript:getAllSelectedIDs();" Text="Add Lead" OnClick="btnAddLead_Click" CssClass="btn btn-block btn-success" />
                                    <asp:HiddenField ID="hdnEmailID" runat="server"  />
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </section>
        </div>
    </div>
    <link href="Content/jquery-ui.css" rel="stylesheet" />
    <script src="plugins/jQueryUI/jquery-ui.min.js"></script>
    <%--<script src="Scripts/jquery-ui.js"></script>--%>
    <script src="Scripts/min/inputmask/inputmask.min.js"></script>
    <script src="Scripts/min/inputmask/inputmask.extensions.min.js"></script>
    <script src="Scripts/min/jquery.inputmask.bundle.min.js"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            $("#ctl00_ContentPlaceHolder1_txtTimeLine").datepicker();
            //$("#ctl00_ContentPlaceHolder1_drpEmailList").prettyDropdown({
                
            //});
        });

        function getAllSelectedIDs()
        {
            var option_all = $('#ctl00_ContentPlaceHolder1_drpEmailList').find(":selected").map(function () {
                return $(this).val();
            }).get().join(',');
            $("#ctl00_ContentPlaceHolder1_hdnEmailID").val(option_all);
            return false;
        }
    </script>
</asp:Content>
