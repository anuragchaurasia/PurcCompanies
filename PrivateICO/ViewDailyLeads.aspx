<%@ Page Title="" Language="C#" MasterPageFile="~/ComplianceMaster.Master" AutoEventWireup="true" CodeBehind="ViewDailyLeads.aspx.cs" Inherits="PrivateICO.ViewDailyLeads" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <asp:ListView ID="lstUsers" runat="server" ItemPlaceholderID="groupPlaceHolder1"   OnItemCommand="lstUsers_ItemCommand" >
        <LayoutTemplate>
            <section class="content">
                <div class="row">
                    <div class="col-xs-12" style="width: 84%">
                        <div class="box" style="margin-left: 220px;">
                            <div class="box-header">
                                <h3 class="box-title">Daily Leads</h3>
                               <div class="pull-right">
                                   
                               </div>
                            </div>
                            <!-- /.box-header -->
                            <div class="box-body">
                                
                                <table id="example2" class="table table-bordered table-hover">
                                    <thead>
                                        <tr>
                                            <th>Document Name</th>
                                            <th>Lead Date</th>
                                            <th>Download Leads</th>
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
                <td><%# Eval("DocumentName") %></td>
                <td><%# Eval("UploadDate") %></td>
                <td>
                    <asp:LinkButton runat="server" ID="lnkDownload" CssClass="fa fa-fw fa-file" CommandArgument='<%# Eval("DocumentPath") %>' ToolTip="Download Leads" CommandName="DownloadLeads"></asp:LinkButton>
                    
                </td>
            </tr>
        </ItemTemplate>


    </asp:ListView>
</asp:Content>
