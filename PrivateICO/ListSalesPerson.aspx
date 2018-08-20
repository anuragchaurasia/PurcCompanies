<%@ Page Title="" Language="C#" MasterPageFile="~/AdminMaster.Master" AutoEventWireup="true" CodeBehind="ListSalesPerson.aspx.cs" Inherits="PrivateICO.ListSalesPerson" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ListView ID="lstUsers" runat="server" ItemPlaceholderID="groupPlaceHolder1" OnPagePropertiesChanging="lstUsers_PagePropertiesChanging" OnItemCommand="lstUsers_ItemCommand">
        <LayoutTemplate>
            <section class="content">
                <div class="row">
                    <div class="col-xs-12" style="width: 84%">
                        <div class="box" style="margin-left: 220px;">
                            <div class="box-header">
                                <h3 class="box-title">Sales Persons</h3>
                                <div class="pull-right">
                                    <asp:Button runat="server" ID="btnAddUser" Text="Add Sales Person/Admin" CssClass="btn btn-block btn-success" OnClick="btnAddUser_Click" />
                                </div>
                            </div>
                            <!-- /.box-header -->
                            <div class="box-body">

                                <table id="example2" class="table table-bordered table-hover">
                                    <thead>

                                        <tr>
                                            <th>Name</th>
                                            <th>Email</th>
                                            <th>Is Contractor ?</th>
                                            <th>Is Active ?</th>
                                            <th>User Type</th>
                                            <th>Creation Time</th>
                                            <th>Profile Action</th>
                                        </tr>
                                    </thead>
                                    <tbody>
                                        <asp:PlaceHolder runat="server" ID="groupPlaceHolder1"></asp:PlaceHolder>
                                    </tbody>
                                    <tfoot>
                                        <tr>
                                            <td colspan="6">
                                                <asp:DataPager ID="DataPager1" runat="server" PagedControlID="lstUsers" PageSize="10">
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
                <td><%# Eval("Name") %></td>
                <td><%# Eval("Email") %></td>
                <td><%# Eval("IsContractor") %></td>
                <td><%# Eval("IsActive") %></td>
                <td><%# Eval("UserType") %></td>
                <td><%# Eval("CreationTime") %></td>
                <td>
                    <asp:LinkButton runat="server" ID="lnkEditDetails" CssClass="fa fa-fw fa-edit" CommandArgument='<%# Eval("UserID") %>' ToolTip="Edit User" CommandName="EditUser"></asp:LinkButton>
                    &nbsp;<asp:LinkButton runat="server" ID="lnkViewSales" CssClass="fa fa-fw fa-dollar" CommandArgument='<%# Eval("UserID") %>' ToolTip="View Sales" CommandName="ViewSale"></asp:LinkButton>
                    &nbsp;<asp:LinkButton runat="server" ID="lnkViewLeads" CssClass="fa fa-fw fa-users" CommandArgument='<%# Eval("UserID") %>' ToolTip="View Lead Status" CommandName="ViewLeads"></asp:LinkButton>
                    &nbsp;<asp:LinkButton runat="server" ID="lnkOpportunityLeads" CssClass="fa fa-fw fa-user-plus" CommandArgument='<%# Eval("UserID") %>' ToolTip="View Opportunity Lead" CommandName="ViewOpportunityLeads"></asp:LinkButton>
                    &nbsp;<asp:LinkButton runat="server" ID="lnkDeleteSalesUser" CssClass="fa fa-fw fa-trash" OnClientClick="javascript:return confirm('Are you sure you want to delete this Sales Person ?');" CommandArgument='<%# Eval("UserID") %>' ToolTip="Delete Sales User" CommandName="DeleteSale"></asp:LinkButton>
                </td>
            </tr>
        </ItemTemplate>
    </asp:ListView>
</asp:Content>
