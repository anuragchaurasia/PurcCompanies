<%@ Page Title="" Language="C#" MasterPageFile="~/AdminMaster.Master" AutoEventWireup="true" CodeBehind="Documents.aspx.cs" Inherits="PrivateICO.Documents" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>

        <div class="content-wrapper">
            <!-- Content Header (Page header) -->
            <section class="content-header">
                <h1>Add Documents
                </h1>
                <ol class="breadcrumb">
                    <li><a href="#"><i class="fa fa-dashboard"></i>Dashboard</a></li>
                    <li><a href="#">Documents</a></li>
                    <li class="active">Add Documents</li>
                </ol>
            </section>

            <!-- General Info -->
            <section class="content">

                <!-- SELECT2 EXAMPLE -->
                <div class="box box-default">
                    <div class="box-header with-border">
                        <h3 class="box-title">Add Document</h3>

                        <div class="box-tools pull-right">
                            <button type="button" class="btn btn-box-tool" data-widget="collapse"><i class="fa fa-minus"></i></button>
                        </div>
                    </div>
                    <!-- /.box-header -->
                    <div class="box-body">
                        <div class="row">
                            <div class="col-md-6">
                                <div class="form-group">
                                    <label>Document Name*</label>
                                    <asp:TextBox runat="server" ID="txtDocName" CssClass="form-control" placeholder="Enter Document Name"></asp:TextBox>
                                </div>

                            </div>
                            <!-- /.col -->
                            <div class="col-md-6">
                                <div class="form-group">
                                    <label>Description*</label>
                                    <asp:TextBox runat="server" ID="txtDescription" CssClass="form-control" placeholder="Enter Description"></asp:TextBox>
                                </div>

                            </div>
                             
                            <div class="col-md-6 pull-right" >
                                <label></label>
                                <div class="form-group">
                                    <asp:Button runat="server" ID="btnSaveDocument" Text="Save Document" CssClass="btn btn-block btn-success" OnClick="btnSaveDocument_Click" />
                                </div>
                            </div>
                        </div>
                        <!-- /.row -->
                    </div>
                    <!-- /.box-body -->

                </div>
                <!-- /.box -->


            </section>
            <asp:ListView ID="lstDocuments" runat="server" ItemPlaceholderID="groupPlaceHolder1" OnItemCommand="lstDocuments_ItemCommand" OnPagePropertiesChanging="lstDocuments_PagePropertiesChanging" >
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
                                            <th>Document ID</th>
                                            <th>Name</th>
                                            <th>Description</th>
                                            
                                        </tr>
                                    </thead>
                                    <tbody>
                                        
                                            <asp:PlaceHolder runat="server" ID="groupPlaceHolder1"></asp:PlaceHolder>
                                        
                                    </tbody>
                                   <%-- <tfoot>
                                        <tr>
                                            <td colspan="3">
                                                <asp:DataPager ID="DataPager1" runat="server" PagedControlID="lstDocuments" PageSize="100">
                                                    <Fields>
                                                        <asp:NextPreviousPagerField ButtonType="Link" ShowFirstPageButton="false" ShowPreviousPageButton="true"
                                                            ShowNextPageButton="false" />
                                                        <asp:NumericPagerField ButtonType="Link" />
                                                        <asp:NextPreviousPagerField ButtonType="Link" ShowNextPageButton="true" ShowLastPageButton="false" ShowPreviousPageButton="false" />
                                                    </Fields>
                                                </asp:DataPager>
                                            </td>
                                        </tr>
                                    </tfoot>--%>
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
            <td><%# Eval("DocumentTypeID") %></td>
            <td><%# Eval("DocumentTypeName") %></td>
            <td><%# Eval("Description") %></td>
            <td>
                <asp:LinkButton runat="server" ID="lnkEdit" CssClass="fa fa-fw fa-edit" CommandArgument='<%# Eval("DocumentID") %>' CommandName="Modify"></asp:LinkButton>&nbsp;<asp:LinkButton runat="server" ID="lnkDocs" CssClass="fa fa-fw fa-files-o" CommandArgument='<%# Eval("DocumentID") %>' OnClientClick="if (!confirm('Are you sure you want delete?')) return false;" CommandName="Del"></asp:LinkButton>
            </td>
                </tr>
        </ItemTemplate>


    </asp:ListView>
        </div>

    </div>

</asp:Content>
