<%@ Page Title="" Language="C#" MasterPageFile="~/CustomerMaster.Master" AutoEventWireup="true" CodeBehind="DownloadDocs.aspx.cs" Inherits="PrivateICO.DownloadDocs" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>


    <asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <div>
            <div class="content-wrapper">
                <asp:ListView ID="lstDocuments" runat="server"  ItemPlaceholderID="groupPlaceHolder1" OnItemCommand="lstDocuments_ItemCommand" OnPagePropertiesChanging="lstDocuments_PagePropertiesChanging">
                    <LayoutTemplate>
                        <section class="content">
                            <div class="row">
                                <div class="col-xs-12">
                                    <div class="box">
                                        <div class="box-header">
                                            <h3 class="box-title">Documents</h3>
                                        </div>
                                        <!-- /.box-header -->
                                        <div class="box-body">
                                            <table id="example2" class="table table-bordered table-hover">
                                                <thead>
                                                    <tr>
                                                        <th>Name</th>
                                                        <th>Download Doc</th>
                                                    </tr>
                                                </thead>
                                                <tbody>

                                                    <asp:PlaceHolder runat="server" ID="groupPlaceHolder1"></asp:PlaceHolder>

                                                </tbody>

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
                            <td>
                                <asp:Label runat="server" ID="txtDocTypeName" Text='<%# Eval("DocumentName") %>'></asp:Label>
                            </td>
                            <td>
                                <asp:LinkButton runat="server" ID="lnkDownload" CommandName="DownloadDoc" CommandArgument='<%# Eval("DocumentPath") %>'>Download</asp:LinkButton>
                            </td>
                        </tr>
                    </ItemTemplate>


                </asp:ListView>
            </div>
        </div>
    </asp:Content>


