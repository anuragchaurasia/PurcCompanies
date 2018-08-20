<%@ Page Title="" Language="C#" MasterPageFile="~/ComplianceMaster.Master" AutoEventWireup="true" CodeBehind="ListSubmittedMCProfiles.aspx.cs" Inherits="PrivateICO.ListSubmittedMCProfiles" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ListView ID="lstMCProfiles" runat="server" ItemPlaceholderID="groupPlaceHolder1" OnPagePropertiesChanging="lstMCProfiles_PagePropertiesChanging" OnItemCommand="lstMCProfiles_ItemCommand">
        <LayoutTemplate>
            <section class="content">
                <div class="row">
                    <div class="col-xs-12" style="width: 84%">
                        <div class="box" style="margin-left: 220px;">
                            <div class="box-header">
                                <h3 class="box-title">MC Sales Submitted Profiles</h3>
                               
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
                                            <th>Edit</th>
                                        </tr>
                                    </thead>
                                    <tbody>
                                        <asp:PlaceHolder runat="server" ID="groupPlaceHolder1"></asp:PlaceHolder>
                                    </tbody>
                                    <tfoot>
                                        <tr>
                                            <td colspan="7">
                                                <asp:DataPager ID="DataPager1" runat="server" PagedControlID="lstMCProfiles" PageSize="10">
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
                <td><%# Eval("DotNo") %></td>
                <td><%# Eval("MCNo") %></td>
                <td><%# Eval("NameOnCard") %></td>
                <td><%# Eval("AddressOnCard") %></td>
                <td><%# Eval("PhysicalAddress") %></td>
                <td><%# Eval("Email") %></td>
                <td>
                    <asp:LinkButton runat="server" ID="lnkEditDetails" CssClass="fa fa-fw fa-edit" CommandArgument='<%# Eval("MCID") %>' ToolTip="View Sale" CommandName="ViewSale"></asp:LinkButton>
                </td>
            </tr>
        </ItemTemplate>
    </asp:ListView>
</asp:Content>
