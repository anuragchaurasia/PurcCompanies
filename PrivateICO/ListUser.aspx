<%@ Page Title="" Language="C#" MasterPageFile="~/AdminMaster.Master" AutoEventWireup="true" CodeBehind="ListUser.aspx.cs" Inherits="PrivateICO.ListUser" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <asp:ListView ID="lstUsers" runat="server" ItemPlaceholderID="groupPlaceHolder1" OnPagePropertiesChanging="lstUsers_PagePropertiesChanging" OnItemCommand="lstUsers_ItemCommand" >
        <LayoutTemplate>
            <section class="content">
                <div class="row">
                    <div class="col-xs-12" style="width: 84%">
                        <div class="box" style="margin-left: 220px;">
                            <div class="box-header">
                                <h3 class="box-title">Investors</h3>
                               <div class="pull-right">
                                    <asp:Button runat="server" ID="btnAddUser" Text="Add Investor" CssClass="btn btn-block btn-success" OnClick="btnAddUser_Click"  />
                               </div>
                            </div>
                            <!-- /.box-header -->
                            <div class="box-body">
                                
                                <table id="example2" class="table table-bordered table-hover">
                                    <thead>
                                        <tr>
                                            <th>First Name</th>
                                            <th>Last Name</th>
                                            <th>Email</th>
                                            <th>Phone No</th>
                                            <th>Coin Balance</th>
                                            <th>Referrer</th>
                                            <th>Creation Time</th>
                                            <th>Transactions</th>
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
                <td><%# Eval("FirstName") %></td>
                <td><%# Eval("LastName") %></td>
                <td><%# Eval("EmailAddress") %></td>
                <td><%# Eval("PhoneNo") %></td>
                <td><%# Eval("NoOfCoins") %></td>
                <td><%# Eval("ReferrerEmail") %></td>
                
                <td><%# Eval("CreationTime") %></td>
                <td>
                    <asp:LinkButton runat="server" ID="lnkTransaction" CssClass="fa fa-fw fa-edit" CommandArgument='<%# Eval("UserID") %>' ToolTip="Coin Transaction" CommandName="AddCoin"></asp:LinkButton>
                    
                </td>
            </tr>
        </ItemTemplate>


    </asp:ListView>
</asp:Content>
