<%@ Page Title="" Language="C#" MasterPageFile="~/AdminMaster.Master" AutoEventWireup="true" CodeBehind="AdminDailyLeadStatus.aspx.cs" Inherits="PrivateICO.AdminDailyLeadStatus" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <div class="content-wrapper">
            <section class="content-header">
                <section class="content">
                    <div class="box box-default">
                        <div class="box-header with-border">
                            <h3 class="box-title">Filters</h3>

                            <div class="box-tools pull-right">
                                <button type="button" class="btn btn-box-tool" data-widget="collapse"><i class="fa fa-minus"></i></button>
                            </div>
                        </div>
                        <div class="box-header with-border">
                        </div>
                        <!-- /.box-header -->
                        <div class="box-body">
                            <div class="row">
                                <asp:Panel ID="Panel1" runat="server">
                                    <div class="col-md-6">
                                        <div class="form-group">
                                            <label>Sort By Time </label>
                                            <asp:DropDownList runat="server" ID="ddlSortByTime" CssClass="form-control">
                                                <asp:ListItem>Newest First</asp:ListItem>
                                                <asp:ListItem>Oldest First</asp:ListItem>
                                            </asp:DropDownList>
                                        </div>

                                    </div>
                                    <!-- /.col -->
                                    <div class="col-md-6">
                                        <div class="form-group">
                                            <label>Sort By Operating Status </label>
                                            <asp:DropDownList runat="server" ID="ddlSortByOperatingStatus" CssClass="form-control">
                                                <asp:ListItem>Please Select</asp:ListItem>
                                                <asp:ListItem>Not Authorized</asp:ListItem>
                                                <asp:ListItem>Active</asp:ListItem>
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                    <div class="col-md-6">
                                        <div class="form-group">
                                            <label>Sort By Closed Status</label>
                                            <asp:DropDownList runat="server" ID="ddlSortByClosedStatus" CssClass="form-control">
                                                <asp:ListItem>Please Select</asp:ListItem>
                                                <asp:ListItem Value="Closed">Closed</asp:ListItem>
                                                <asp:ListItem Value="Follow up">Follow up</asp:ListItem>
                                                <asp:ListItem Value="Left Voicemail">Left Voicemail</asp:ListItem>
                                                <asp:ListItem Value="No Answer">No Answer</asp:ListItem>
                                                <asp:ListItem Value="Do Not Call">Do Not Call</asp:ListItem>
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                     <div class="col-md-6">
                                        <div class="form-group">
                                            <label>Sort By Timezone</label>
                                            <asp:DropDownList runat="server" ID="ddlTimeZone" CssClass="form-control">
                                                <asp:ListItem>Please Select</asp:ListItem>
                                                <asp:ListItem Value="AST">AST</asp:ListItem>
                                                <asp:ListItem Value="EST">EST</asp:ListItem>
                                                <asp:ListItem Value="CST">CST</asp:ListItem>
                                                <asp:ListItem Value="MST">MST</asp:ListItem>
                                                <asp:ListItem Value="PST">PST</asp:ListItem>
                                                <asp:ListItem Value="AST">AST</asp:ListItem>
                                                <asp:ListItem Value="HST">HST</asp:ListItem>
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                    <div class="col-md-6">
                                        <div class="form-group">
                                            <label>Sort By DOTNO</label>
                                            <asp:DropDownList runat="server" ID="drpDOTNo" CssClass="form-control">
                                                <asp:ListItem>Please Select</asp:ListItem>
                                                <asp:ListItem>Asc DOT#</asp:ListItem>
                                                <asp:ListItem>Desc DOT#</asp:ListItem>
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                    <div class="col-md-6">
                                        <div class="form-group">
                                            <label>Select Date</label>
                                            <asp:TextBox ID="txtDate" runat="server" placeholder="Choose Date" CssClass="form-control"></asp:TextBox>

                                        </div>
                                    </div>
                                    <div class="col-md-6">
                                        <label></label>
                                        <div class="form-group">
                                            <asp:Button runat="server" ID="btnSort" Text="Sort Leads" CssClass="btn btn-block btn-success" OnClick="btnSort_Click" />
                                        </div>
                                    </div>

                                     <div class="col-md-12">
                                        <div class="form-group">
                                           
                                           <hr />
                                        </div>

                                    </div>

                                      <div class="col-md-6">
                                        <div class="form-group">
                                            <label>Search By DOT# </label>
                                            <asp:TextBox ID="txtDOTNo" runat="server" placeholder="Enter DOT Number" CssClass="form-control"></asp:TextBox>

                                        </div>

                                    </div>
                                    <!-- /.col -->

                                    <div class="col-md-6">
                                        <label>&nbsp;</label>
                                        <div class="form-group">
                                            <asp:Button runat="server" ID="btnSearchByDOTNo" Text="Search By DOT#" CssClass="btn btn-block btn-success" OnClick="btnSearchByDOTNo_Click" />
                                        </div>
                                    </div>
                                </asp:Panel>
                            </div>
                        </div>
                    </div>
                </section>
            </section>
        </div>
    </div>
    
    <asp:ListView ID="lstOfLeads" runat="server" ItemPlaceholderID="groupPlaceHolder1" OnPagePropertiesChanging="lstOfLeads_PagePropertiesChanging" OnItemDataBound="lstOfLeads_ItemDataBound">
        <LayoutTemplate>
            <section class="content">
                <div>
                    <div class="content-wrapper">
                        <section class="content-header">
                            <section class="content">
                                <div class="box box-default">
                                    <div class="box-header with-border">
                                        <h3 class="box-title">Leads</h3>
                                        <%--<div class="pull-right">
                                    <asp:Button runat="server" ID="btnAddUser" Text="Add Investor" CssClass="btn btn-block btn-success" OnClick="btnAddUser_Click"  />
                                        </div>--%>
                                    </div>
                                    <!-- /.box-header -->
                                    <div class="box-body">

                                        <table id="example2" class="table table-bordered table-hover">
                                            <thead>

                                                <tr>
                                                    <th colspan="1">New Leads</th>
                                                    <th colspan="2">
                                                        <asp:Label ID="lblNewLeads" runat="server" Text="0"></asp:Label></th>
                                                    <th colspan="2">Follow up</th>
                                                    <th colspan="2">
                                                        <asp:Label ID="lblNotASale" runat="server" Text="0"></asp:Label></th>
                                                    <th colspan="2">Sale leads</th>
                                                    <th colspan="2">
                                                        <asp:Label ID="lblSaleLeads" runat="server" Text="0"></asp:Label></th>
                                                    <th colspan="1">Total leads</th>
                                                    <th colspan="1">
                                                        <asp:Label ID="lblTotalLeads" runat="server" Text="0"></asp:Label></th>

                                                </tr>

                                                <tr>
                                                    <th><asp:LinkButton runat="server" ID="delLead" OnClick="delLead_Click">Delete</asp:LinkButton></th>
                                                    <th>DOT#</th>
                                                    <th>Legal Name</th>
                                                    <th>Physical Address</th>
                                                    <th>Zip Code</th>
                                                    <%--<th>Mailing Address</th>--%>
                                                    <th>Phone No</th>
                                                    <th>TimeZone</th>
                                                    <th>Operating Status</th>
                                                    <th>Interstate</th>
                                                    <th>Auth For Hire</th>
                                                    <th>Power Units</th>
                                                    <th>Drivers</th>
                                                    <th>Date Filed</th>
                                                    <th>Status</th>
                                                </tr>
                                            </thead>
                                            <tbody>
                                                <asp:PlaceHolder runat="server" ID="groupPlaceHolder1"></asp:PlaceHolder>
                                            </tbody>
                                            <tfoot>
                                                <tr>
                                                    <td colspan="6">
                                                        <asp:DataPager ID="DataPager1" runat="server" PagedControlID="lstOfLeads" PageSize="100">
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

                                    </div>
                                    <!-- /.box-body -->
                                </div>
                            </section>
                        </section>
                    </div>
                </div>
            </section>
        </LayoutTemplate>

        <ItemTemplate>
            <tr runat="server" id="row">
                <td>
                    <asp:CheckBox ID="chkDelete" runat="server" /></td>
                <td><%# Eval("DOTNumber") %></td>
                <td><%# Eval("LegalName") %></td>
                <td><%# Eval("PhysicalAddress") %></td>
                <td><%# Eval("ZipCode") %></td>
                <%--<td><%# Eval("MailingAddress") %></td>--%>
                <td><pre><%# Eval("PhoneNo") %></pre></td>
                <td><%# Eval("TimeZone") %></td>
                <td><%# Eval("OperatingStatus") %></td>
                <td><%# Eval("Interstate") %></td>
                <td><%# Eval("AuthForHire") %></td>
                <td><%# Eval("PowerUnits") %></td>
                <td><%# Eval("Drivers") %></td>
                <td><%# Eval("DateFiled") %></td>
                <td><%# Eval("Status") %>
                    <asp:HiddenField ID="HiddenStatus" runat="server" Value='<%# Eval("Status") %>' />
                    <asp:HiddenField ID="hdnDailyLeadID" runat="server" Value='<%# Eval("DailyLeadID") %>' />
                </td>
            </tr>
        </ItemTemplate>


    </asp:ListView>
    <link href="Content/jquery-ui.css" rel="stylesheet" />
    <script src="plugins/jQueryUI/jquery-ui.min.js"></script>
    <%--<script src="Scripts/jquery-ui.js"></script>--%>
    <script src="Scripts/min/inputmask/inputmask.min.js"></script>
    <script src="Scripts/min/inputmask/inputmask.extensions.min.js"></script>
    <script src="Scripts/min/jquery.inputmask.bundle.min.js"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            $("#ctl00_ContentPlaceHolder1_txtDate").datepicker();
        });

        function autoscroll() {
            $("#ctl00_ContentPlaceHolder1_txtDate").datepicker();
        }

        Sys.WebForms.PageRequestManager.getInstance().add_endRequest(autoscroll);
    </script>
</asp:Content>
