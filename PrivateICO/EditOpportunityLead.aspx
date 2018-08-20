<%@ Page Title="" Language="C#" MasterPageFile="~/ComplianceMaster.Master" AutoEventWireup="true" CodeBehind="EditOpportunityLead.aspx.cs" Inherits="PrivateICO.EditOpportunityLead" %>

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
                                    <asp:Button runat="server" ID="btnEditLead" Text="Edit Lead" OnClick="btnEditLead_Click" CssClass="btn btn-block btn-success" />
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </section>

            <!-- General Info -->
            <section class="content">

                <!-- SELECT2 EXAMPLE -->
                <div class="box box-default">
                    <div class="box-header with-border">
                        <h3 class="box-title">Lead Notes</h3>
                        <div class="box-tools pull-right">
                            <button type="button" class="btn btn-box-tool" data-widget="collapse"><i class="fa fa-minus"></i></button>
                        </div>
                    </div>
                    <!-- /.box-header -->
                    <div class="box-body">
                        <div class="row">

                            <div class="col-md-12">
                                <div class="form-group">
                                    <asp:ListView ID="lstOfLeads" runat="server" ItemPlaceholderID="groupPlaceHolder1"  OnPagePropertiesChanging="lstOfLeads_PagePropertiesChanging">
                                        <LayoutTemplate>



                                            <table id="example2" class="table table-bordered table-hover">
                                                <thead>
                                                    <tr>
                                                        <th>Note</th>
                                                        <th>Timeline</th>
                                                        <th>Creation Time</th>
                                                    </tr>
                                                </thead>
                                                <tbody>
                                                    <asp:PlaceHolder runat="server" ID="groupPlaceHolder1"></asp:PlaceHolder>
                                                </tbody>
                                                <tfoot>
                                                    <tr>
                                                        <td colspan="6">
                                                            <asp:DataPager ID="DataPager1" runat="server" PagedControlID="lstOfLeads" PageSize="10">
                                                                <Fields>
                                                                    <asp:NextPreviousPagerField ButtonType="Link" ShowFirstPageButton="false" ShowPreviousPageButton="true"
                                                                        ShowNextPageButton="false" />
                                                                    <asp:NumericPagerField ButtonType="Link" />
                                                                    <asp:NextPreviousPagerField ButtonType="Link" ShowNextPageButton="true" ShowLastPageButton="false" ShowPreviousPageButton="false" />
                                                                </Fields>
                                                            </asp:DataPager>
                                                        </td>
                                                    </tr>
                                                </tfoot>
                                            </table>



                                        </LayoutTemplate>

                                        <ItemTemplate>
                                            <tr>
                                                <td><%# Eval("Note") %></td>
                                                <td><%# Eval("Timeline") %></td>
                                                <td><%# Eval("NoteLeftAt") %></td>
                                            </tr>
                                        </ItemTemplate>
                                    </asp:ListView>
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
        });
    </script>
</asp:Content>
