<%@ Page Title="" Language="C#" MasterPageFile="~/AdminMaster.Master" AutoEventWireup="true" CodeBehind="DocumentUpload.aspx.cs" Inherits="PrivateICO.DocumentUpload" %>

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
            <asp:ListView ID="lstDocuments" runat="server" OnDataBinding="lstDocuments_DataBinding" OnItemDataBound="lstDocuments_ItemDataBound" ItemPlaceholderID="groupPlaceHolder1" OnItemCommand="lstDocuments_ItemCommand" OnPagePropertiesChanging="lstDocuments_PagePropertiesChanging">
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
                                                    <th>Upload Doc</th>
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
                        <td><asp:Label runat="server" ID="txtDocTypeName" Text='<%# Eval("DocumentTypeName") %>'></asp:Label>
                            <asp:LinkButton runat="server" ID="lnkDocTypeName" Text='<%# Eval("DocumentTypeName") %>' Visible="false"></asp:LinkButton>
                            <asp:HiddenField runat="server" ID="hidDocID" Value='<%# Eval("DocumentTypeID") %>' />
                        </td>
                        <td>
                            <ul class="fileul">
                                <li class="fileli">
                                    <asp:FileUpload runat="server" ID="flUpload" accept=".doc,.docx,.pdf" onchange="UploadFile(this)" /></li>
                                
                                <li class="fileli">&nbsp;&nbsp;&nbsp;&nbsp; <asp:LinkButton runat="server" ID="lnkUpload" style="display:none;" CommandArgument='<%# Eval("DocumentTypeID") %>' CommandName="Upl" >Upload</asp:LinkButton>
                                </li>
                                
                            </ul>
                        </td>
                    </tr>
                </ItemTemplate>


            </asp:ListView>
        </div>
    </div>
    <script type="text/javascript">
        function UploadFile(fileUpload) {
            if (fileUpload.value != '') {
                $(fileUpload).parent().next().find('a').show();
            }
        }
    </script>
</asp:Content>
