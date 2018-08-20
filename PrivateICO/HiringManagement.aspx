<%@ Page Title="" Language="C#" MasterPageFile="~/AdminMaster.Master" AutoEventWireup="true" CodeBehind="HiringManagement.aspx.cs" Inherits="PrivateICO.HiringManagement" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <asp:ListView ID="lstCandidates" runat="server" ItemPlaceholderID="groupPlaceHolder1" OnPagePropertiesChanging="lstCandidates_PagePropertiesChanging" OnItemCommand="lstCandidates_ItemCommand">
        <LayoutTemplate>
            <section class="content">
                <div class="row">
                    <div class="col-xs-12" style="width: 84%">
                        <div class="box" style="margin-left: 220px;">
                            <div class="box-header">
                                <h3 class="box-title">Candidates</h3>
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
                                            <th>City</th>
                                            <th>State</th>
                                            <th>Date Available</th>
                                            <th>Position Applied For</th>
                                            <th>Actions</th>
                                        </tr>
                                    </thead>
                                    <tbody>
                                        <asp:PlaceHolder runat="server" ID="groupPlaceHolder1"></asp:PlaceHolder>
                                    </tbody>
                                    <tfoot>
                                        <tr>
                                            <td colspan="6">
                                                <asp:DataPager ID="DataPager1" runat="server" PagedControlID="lstCandidates" PageSize="10">
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
                <td><%# Eval("Email") %></td>
                <td><%# Eval("Phone") %></td>
                <td><%# Eval("City") %></td>
                <td><%# Eval("State") %></td>
                <td><%# Eval("DateAvailable") %></td>
                <td><%# Eval("PositionAppliedFor") %></td>
                <td>
                    <asp:LinkButton runat="server" ID="lnkViewDetails" CssClass="fa fa-fw fa-eye" CommandArgument='<%# Eval("CanadidateID") %>' ToolTip="View Complete Details" CommandName="ViewDetails"></asp:LinkButton>
                </td>
            </tr>
        </ItemTemplate>


    </asp:ListView>

</asp:Content>
