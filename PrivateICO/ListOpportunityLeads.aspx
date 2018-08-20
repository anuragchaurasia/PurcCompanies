<%@ Page Title="" Language="C#" MasterPageFile="~/ComplianceMaster.Master" AutoEventWireup="true" CodeBehind="ListOpportunityLeads.aspx.cs" Inherits="PrivateICO.ListOpportunityLeads" %>
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
                                            <label>Search By DOT# </label>
                                            <asp:TextBox ID="txtDOTNo" runat="server" placeholder="Enter DOT Number" CssClass="form-control"></asp:TextBox>
                                        </div>
                                    </div>
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
    <asp:ListView ID="lstOfLeads" runat="server" ItemPlaceholderID="groupPlaceHolder1" OnItemCommand="lstOfLeads_ItemCommand" OnPagePropertiesChanging="lstOfLeads_PagePropertiesChanging"  >
        <LayoutTemplate>
            <section class="content">
                <div class="row">
                    <div class="col-xs-12" style="width: 84%">
                        <div class="box" style="margin-left: 220px;">
                            <div class="box-header">
                                <h3 class="box-title">Opportunity Leads</h3>
                               <div class="pull-right">
                                    <asp:Button runat="server" ID="btnAddOpportunity" Text="Add Opportunity Lead" CssClass="btn btn-block btn-success" OnClick="btnAddOpportunity_Click"  />
                               </div>
                            </div>
                            <!-- /.box-header -->
                            <div class="box-body">
                                
                                <table id="example2" class="table table-bordered table-hover">
                                    <thead>
                                        <tr>
                                            <th>DOT#</th>
                                            <th>Business Name</th>
                                           <%-- <th>Compliance Agent</th>--%>
                                            <th>Contact Name</th>
                                            <th>Contact Phone No</th>
                                            <th>Email</th>
                                            <th>Service Discussed</th>
                                           <%-- <th>TimeLine</th>--%>
                                            <th>Actions</th>
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

                            </div>
                            <!-- /.box-body -->
                        </div>
                    </div>
                </div>
            </section>
        </LayoutTemplate>

        <ItemTemplate>
            <tr>
                <td><%# Eval("DOTNo") %></td>
                <td><%# Eval("BusinessName") %></td>
                <%--<td><%# Eval("ComplianceAgent") %></td>--%>
                <td><%# Eval("ContactName") %></td>
                <td><%# Eval("PhoneNoForContact") %></td>
                <td><%# Eval("Email") %></td>
                <td><%# Eval("ServiceDiscussed") %></td>
               <%-- <td><%# Eval("TimeLine") %></td>--%>
               <td>
                    <asp:LinkButton runat="server" ID="lnkEditOpportunity" CssClass="fa fa-fw fa-edit" CommandArgument='<%# Eval("LeadID") %>' ToolTip="Edit Lead" CommandName="EditLead"></asp:LinkButton>
                    &nbsp;<asp:LinkButton runat="server" ID="lnkDeleteLead" CssClass="fa fa-fw fa-trash" OnClientClick="javascript:return confirm('Are you sure you want to delete this Lead ?');" CommandArgument='<%# Eval("LeadID") %>' ToolTip="Delete Lead" CommandName="DeleteLead"></asp:LinkButton>
                </td>
            </tr>
        </ItemTemplate>


    </asp:ListView>
</asp:Content>
