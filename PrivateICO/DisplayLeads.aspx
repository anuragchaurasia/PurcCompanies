<%@ Page Title="" Language="C#" MasterPageFile="~/AdminMaster.Master" AutoEventWireup="true" CodeBehind="DisplayLeads.aspx.cs" Inherits="PrivateICO.DisplayLeads" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

     <asp:ListView ID="lstOfLeads" runat="server" ItemPlaceholderID="groupPlaceHolder1" OnPagePropertiesChanging="lstOfLeads_PagePropertiesChanging"  >
        <LayoutTemplate>
            <section class="content">
                <div class="row">
                    <div class="col-xs-12" style="width: 84%">
                        <div class="box" style="margin-left: 220px;">
                            <div class="box-header">
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
                                            <th>DOT#</th>
                                            <th>Business Name</th>
                                           <%-- <th>Compliance Agent</th>--%>
                                            <th>Contact Name</th>
                                            <th>Contact Phone No</th>
                                            <th>Email</th>
                                            <th>Service Discussed</th>
                                            <th>TimeLine</th>
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
                <td><%# Eval("TimeLine") %></td>
               
            </tr>
        </ItemTemplate>


    </asp:ListView>

</asp:Content>
