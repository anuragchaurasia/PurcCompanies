<%@ Page Title="" Language="C#" MasterPageFile="~/ComplianceMaster.Master" AutoEventWireup="true" CodeBehind="ListLeads.aspx.cs" Inherits="PrivateICO.ListLeads" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <div class="content-wrapper">
            <section class="content-header">
                <section class="content">
                    <div class="box box-default">
                        <div class="box-header with-border">
                            <h3 class="box-title">Filters</h3>

                            <div class="box-tools pull-right">
                                <button type="button" class="btn btn-box-tool" data-widget="collapse"><i class="fa fa-minus"></i></button>
                            </div>
                        </div>
                        <div class="box-header with-border">
                        </div>
                        <!-- /.box-header -->
                        <div class="box-body">
                            <div class="row">
                                <asp:Panel ID="Panel1" runat="server">
                                    <div class="col-md-6">
                                        <div class="form-group">
                                            <label>Sort By Time </label>
                                            <asp:DropDownList runat="server" ID="ddlSortByTime" CssClass="form-control">
                                                <asp:ListItem>Newest First</asp:ListItem>
                                                <asp:ListItem>Oldest First</asp:ListItem>
                                            </asp:DropDownList>
                                        </div>

                                    </div>
                                    <!-- /.col -->
                                    <div class="col-md-6">
                                        <div class="form-group">
                                            <label>Sort By Operating Status </label>
                                            <asp:DropDownList runat="server" ID="ddlSortByOperatingStatus" CssClass="form-control">
                                                <asp:ListItem>Please Select</asp:ListItem>
                                                <asp:ListItem>Not Authorized</asp:ListItem>
                                                <asp:ListItem>Active</asp:ListItem>
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                    <div class="col-md-6">
                                        <div class="form-group">
                                            <label>Sort By Sale Status*</label>
                                            <asp:DropDownList runat="server" ID="ddlSortByClosedStatus" CssClass="form-control">
                                                <asp:ListItem>Please Select</asp:ListItem>
                                                <asp:ListItem Value="Closed">Closed</asp:ListItem>
                                                <asp:ListItem Value="Follow up">Follow up</asp:ListItem>
                                                <asp:ListItem Value="Left Voicemail">Left Voicemail</asp:ListItem>
                                                <asp:ListItem Value="No Answer">No Answer</asp:ListItem>
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                    <div class="col-md-6">
                                        <div class="form-group">
                                            <label>Sort By Timezone*</label>
                                            <asp:DropDownList runat="server" ID="ddlTimeZone" CssClass="form-control">
                                                <asp:ListItem>Please Select</asp:ListItem>
                                                <asp:ListItem Value="AST">AST</asp:ListItem>
                                                <asp:ListItem Value="EST">EST</asp:ListItem>
                                                <asp:ListItem Value="CST">CST</asp:ListItem>
                                                <asp:ListItem Value="MST">MST</asp:ListItem>
                                                <asp:ListItem Value="PST">PST</asp:ListItem>
                                                <asp:ListItem Value="AST">AST</asp:ListItem>
                                                <asp:ListItem Value="HST">HST</asp:ListItem>
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                    <div class="col-md-6">
                                        <div class="form-group">
                                            <label>Sort By DOTNO*</label>
                                            <asp:DropDownList runat="server" ID="drpDOTNo" CssClass="form-control">
                                                <asp:ListItem>Please Select</asp:ListItem>
                                                <asp:ListItem>Asc DOT#</asp:ListItem>
                                                <asp:ListItem>Desc DOT#</asp:ListItem>
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                    <div class="col-md-6">
                                        <div class="form-group">
                                            <label>Select Date</label>
                                            <asp:TextBox ID="txtDate" runat="server" placeholder="Choose Date" CssClass="form-control"></asp:TextBox>

                                        </div>
                                    </div>
                                    <div class="col-md-6">
                                        <label></label>
                                        <div class="form-group">
                                            <asp:Button runat="server" ID="btnSort" Text="Filter Leads" CssClass="btn btn-block btn-success" OnClick="btnSort_Click" />
                                        </div>
                                    </div>
                                    <div class="col-md-12">
                                        <div class="form-group">

                                            <hr />
                                        </div>

                                    </div>

                                    <div class="col-md-6">
                                        <div class="form-group">
                                            <label>Search By DOT# </label>
                                            <asp:TextBox ID="txtDOTNo" runat="server" placeholder="Enter DOT Number" CssClass="form-control"></asp:TextBox>

                                        </div>

                                    </div>
                                    <!-- /.col -->

                                    <div class="col-md-6">
                                        <label>&nbsp;</label>
                                        <div class="form-group">
                                            <asp:Button runat="server" ID="btnSearchByDOTNo" Text="Search By DOT#" CssClass="btn btn-block btn-success" OnClick="btnSearchByDOTNo_Click" />
                                        </div>
                                    </div>
                                </asp:Panel>
                            </div>
                        </div>
                    </div>
                </section>
            </section>
        </div>
    </div>
    <asp:ListView ID="lstOfLeads" runat="server" ItemPlaceholderID="groupPlaceHolder1" OnPagePropertiesChanging="lstOfLeads_PagePropertiesChanging" OnItemDataBound="lstOfLeads_ItemDataBound">
        <LayoutTemplate>
            <section class="content">
                <div>
                    <div class="content-wrapper">
                        <section class="content-header">
                            <section class="content">
                                <div class="box box-default">
                                    <div class="box-header with-border">
                                        <h3 class="box-title">Opportunity Leads</h3>
                                        <%--<div class="pull-right">
                                            <asp:Button runat="server" ID="btnAddUser" Text="Add Investor" CssClass="btn btn-block btn-success" OnClick="btnAddUser_Click" />
                                        </div>--%>
                                    </div>
                                    <div class="box-body">

                                        <table id="example2" class="table table-bordered table-hover">
                                            <thead class="thead-dark">
                                                <tr>
                                                    <th></th>
                                                    <th colspan="1">New Leads</th>
                                                    <th colspan="1">
                                                        <asp:Label ID="lblNewLeads" runat="server" Text="0"></asp:Label></th>
                                                    <th colspan="1">Follow up</th>
                                                    <th colspan="1">
                                                        <asp:Label ID="lblNotASale" runat="server" Text="0"></asp:Label></th>
                                                    <th colspan="1">Sale leads</th>
                                                    <th colspan="1">
                                                        <asp:Label ID="lblSaleLeads" runat="server" Text="0"></asp:Label></th>
                                                    <th colspan="1">Total leads</th>
                                                    <th colspan="1">
                                                        <asp:Label ID="lblTotalLeads" runat="server" Text="0"></asp:Label></th>
                                                    <th></th>
                                                    <th></th>
                                                </tr>
                                                <tr>
                                                     <th><asp:LinkButton runat="server" ID="delLead" OnClick="delLead_Click">Delete</asp:LinkButton></th>
                                                    <th>DOT#</th>
                                                    <th>Legal Name</th>
                                                    <th>Physical Address</th>
                                                    <%--<th>Zip Code</th>
                                                    <th>Mailing Address</th>--%>
                                                    <th>Phone No</th>
                                                    <th>TimeZone</th>
                                                    <th>Operating Status</th>
                                                    <th>Interstate</th>
                                                    <th>Auth For Hire</th>
                                                    <th>Power Units</th>
                                                    <th>Drivers</th>
                                                    <th>Date Filed</th>
                                                    <th>Uploaded On</th>
                                                    <th>Status</th>

                                                </tr>
                                            </thead>
                                            <tbody>
                                                <asp:PlaceHolder runat="server" ID="groupPlaceHolder1"></asp:PlaceHolder>
                                            </tbody>
                                            <tfoot>
                                                <tr>
                                                    <td colspan="10">
                                                        <asp:DataPager ID="DataPager1" runat="server" PagedControlID="lstOfLeads" PageSize="100">
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
                            </section>
                        </section>

                    </div>
                </div>
            </section>
        </LayoutTemplate>

        <ItemTemplate>
            <tr id="row" runat="server">
                <td><asp:CheckBox ID="chkDelete" runat="server" /></td>
               <td><%# Eval("DOTNumber") %></td>
                <td><%# Eval("LegalName") %></td>
                <td><%# Eval("PhysicalAddress") %></td>
                <%--<td><%# Eval("ZipCode") %></td>
                <td><%# Eval("MailingAddress") %></td>--%>
                <td>
                    <pre><%# Eval("PhoneNo") %></pre>
                </td>
                <td><%# Eval("TimeZone") %></td>
                <td><%# Eval("OperatingStatus") %></td>
                <td><%# Eval("Interstate") %></td>
                <td><%# Eval("AuthForHire") %></td>
                <td><%# Eval("PowerUnits") %></td>
                <td><%# Eval("Drivers") %></td>
                <td><%# Eval("DateFiled") %></td>
                <td><%# Eval("SavedOn") %></td>
                <td>
                    <asp:DropDownList ID="drpStatusList" CssClass="form-control" runat="server" OnSelectedIndexChanged="drpStatusList_SelectedIndexChanged">
                        <asp:ListItem>New Leads</asp:ListItem>
                        <asp:ListItem>Closed</asp:ListItem>
                        <asp:ListItem>Follow up</asp:ListItem>
                        <asp:ListItem>Left Voicemail</asp:ListItem>
                        <asp:ListItem>No Answer</asp:ListItem>
                        <asp:ListItem>Do Not Call</asp:ListItem>
                    </asp:DropDownList>
                    <asp:HiddenField ID="HiddenStatus" runat="server" Value='<%# Eval("Status") %>' />
                    <asp:HiddenField ID="HiddenID" runat="server" Value='<%# Eval("DailyLeadID") %>' />

                </td>

            </tr>
        </ItemTemplate>


    </asp:ListView>
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <asp:HiddenField ID="hdnScrollElementID" runat="server" Value="" />
    <script type="text/javascript">
        $(document).ready(function () {
            var currentDrop;
            $("select[id^='ctl00_ContentPlaceHolder1_lstOfLeads_ctr']").change(function () {
                currentDrop = $(this).attr("id");
                $.ajax({
                    url: 'ListLeads.aspx/UpdateStatus',
                    type: "POST",
                    data: '{leadid: "' + $(this).attr('class') + '", status: "' + $(this).find(":selected").text() + '", id: "' + currentDrop + '" }',
                    dataType: "json",
                    contentType: "application/json; charset=utf-8",
                    success: function (data) {
                        var dropdowntext = $("#" + data.d).find(":selected").text();
                        if (dropdowntext == "Follow up") {
                            var dropcssclass = $("#" + data.d).attr('class');
                            $("#" + data.d).parent().parent().css('background-color', '#BBDAFF');
                            window.open("LeadsEntry.aspx?LeadID=" + dropcssclass,'_blank');
                        }
                        else
                            if (dropdowntext == "Left Voicemail") {
                                $("#" + data.d).parent().parent().css('background-color', '#EFCDF8');
                            }
                            else
                                if (dropdowntext == "Closed") {
                                    var dropcssclass = $("#" + data.d).attr('class');
                                    $("#" + data.d).parent().parent().css('background-color', '#A4F0B7');
                                    window.open("DriverProfile.aspx?LeadID=" + dropcssclass, '_blank');
                                }
                                else
                                    if (dropdowntext == "No Answer") {
                                        $("#" + data.d).parent().parent().css('background-color', '#FFFF99');
                                    }
                                    else
                                        if (dropdowntext == "Do Not Call") {
                                            $("#" + data.d).parent().parent().css('background-color', '#FFA8A8');
                                        }
                    }
                });
                //$('#ctl00_ContentPlaceHolder1_hdnScrollElementID').val(this.id);
            });
            //autoscroll();
        });

        function autoscroll() {
            var scrollDivID = '#' + $('#ctl00_ContentPlaceHolder1_hdnScrollElementID').val();
            $('html, body').animate({
                scrollTop: $(scrollDivID).offset().top
            }, 2000);
            $("#ctl00_ContentPlaceHolder1_txtDate").datepicker();
        }

        Sys.WebForms.PageRequestManager.getInstance().add_endRequest(autoscroll);
    </script>
</asp:Content>
