<%@ Page Title="" Language="C#" MasterPageFile="~/AdminMaster.Master" AutoEventWireup="true" CodeBehind="ListUSDOTSaleAdmin.aspx.cs" Inherits="PrivateICO.ListUSDOTSaleAdmin" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ListView ID="lstUSDOTProfiles" runat="server" ItemPlaceholderID="groupPlaceHolder1" OnPagePropertiesChanging="lstUSDOTProfiles_PagePropertiesChanging" OnItemCommand="lstUSDOTProfiles_ItemCommand">
        <LayoutTemplate>
            <section class="content">
                <div class="row">
                    <div class="col-xs-12" style="width: 84%">
                        <div class="box" style="margin-left: 220px;">
                            <div class="box-header">
                                <h3 class="box-title">USDOT Sale Submitted Profiles</h3>
                                <div class="pull-right">
                                    <%--<asp:Button runat="server" ID="btnAddUSDOTSale" Text="Add USDOT Sale Profile" CssClass="btn btn-block btn-success" OnClick="btnAddMCSale_Click" />--%>
                                </div>
                            </div>
                            <!-- /.box-header -->
                            <div class="box-body">
                                <table id="example2" class="table table-bordered table-hover">
                                    <thead>

                                        <tr>
                                            <th>USDOT#</th>
                                            <th>MC#</th>
                                            <th>Name on Card</th>
                                            <th>Address on Card</th>
                                            <th>Physical Address</th>
                                            <th>Email</th>
                                            <th>Submitted By</th>
                                            <th>Submitted At</th>
                                            <th>Edit</th>
                                        </tr>
                                    </thead>
                                    <tbody>
                                        <asp:PlaceHolder runat="server" ID="groupPlaceHolder1"></asp:PlaceHolder>
                                    </tbody>
                                    <tfoot>
                                        <tr>
                                            <td colspan="9">
                                                <asp:DataPager ID="DataPager1" runat="server" PagedControlID="lstUSDOTProfiles" PageSize="10">
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
                <td><%# Eval("USDot") %></td>
                <td><%# Eval("CA") %></td>
                <td><%# Eval("NameOnCard") %></td>
                <td><%# Eval("BillingAddress") %></td>
                <td><%# Eval("PhysicalAddress") %></td>
                <td><%# Eval("Email") %></td>
                <td><%# Eval("SubmittedBy") %></td>
                <td><%# Eval("DateTime") %></td>
                <td>
                    <asp:LinkButton runat="server" ID="lnkEditDetails" CssClass="fa fa-fw fa-edit" CommandArgument='<%# Eval("OrderFormID") %>' ToolTip="Edit Sale" CommandName="EditSale"></asp:LinkButton>
                &nbsp;<asp:LinkButton runat="server" ID="lnkDeleteSale" CssClass="fa fa-fw fa-trash" OnClientClick="javascript:return confirm('Are you sure you want to delete this Sale ?');" CommandArgument='<%# Eval("OrderFormID") %>' ToolTip="Delete Sale" CommandName="DeleteSale"></asp:LinkButton>
                </td>
            </tr>
        </ItemTemplate>
    </asp:ListView>
</asp:Content>

