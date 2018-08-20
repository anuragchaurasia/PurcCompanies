<%@ Page Title="" Language="C#" MasterPageFile="~/AdminMaster.Master" AutoEventWireup="true" CodeBehind="UploadLeads.aspx.cs" Inherits="PrivateICO.UploadLeads" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <style type="text/css">
        .fileul {
            list-style-type: none;
            margin: 0;
            padding: 0;
            overflow: hidden;
        }

        .fileli {
            float: left;
        }
    </style>
    <div>
        <div class="content-wrapper">
            <asp:ListView ID="lstUsers" runat="server" ItemPlaceholderID="groupPlaceHolder1" OnPagePropertiesChanging="lstUsers_PagePropertiesChanging" DataKeyNames="UserID" OnItemCommand="lstUsers_ItemCommand">
                <LayoutTemplate>
                    <section class="content">
                        <div class="row">
                            <div class="col-xs-12">
                                <div class="box">
                                    <div class="box-header">
                                        <h3 class="box-title">Sales Persons</h3>
                                        <div class="pull-right">
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
                                                        <asp:DataPager ID="DataPager1" runat="server" PagedControlID="lstUsers" PageSize="50">
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
                            <ul class="fileul">
                                <li class="fileli">
                                    <asp:FileUpload runat="server" ID="flUpload" accept=".doc,.docx,.pdf,.xls,.xlsx" onchange="UploadFile(this)" /></li>

                                <li class="fileli">&nbsp;&nbsp;&nbsp;&nbsp;
                            <asp:LinkButton runat="server" ID="lnkUpload" Style="display: none;" CommandArgument='<%# Eval("UserID") %>' CommandName="Upl">Upload</asp:LinkButton>
                                </li>

                            </ul>
                        </td>
                    </tr>
                </ItemTemplate>
            </asp:ListView>
        </div>
    </div>
    <script src="Scripts/jquery-1.9.0.js"></script>
    <script type="text/javascript">
        function UploadFile(fileUpload) {
            if (fileUpload.value != '') {
                $(fileUpload).parent().next().find('a').show();
            }
        }
    </script>

</asp:Content>
