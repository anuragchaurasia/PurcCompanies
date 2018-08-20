<%@ Page Title="" Language="C#" MasterPageFile="~/ComplianceMaster.Master" AutoEventWireup="true" CodeBehind="DailySalesDisplay.aspx.cs" Inherits="PrivateICO.DailySalesDisplay" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link rel="stylesheet" href="../../plugins/daterangepicker/daterangepicker.css" />
    <!-- bootstrap datepicker -->
    <link rel="stylesheet" href="../../plugins/datepicker/datepicker3.css" />
    <!-- iCheck for checkboxes and radio inputs -->
    <link rel="stylesheet" href="../../plugins/iCheck/all.css" />
    <!-- Bootstrap Color Picker -->
    <link rel="stylesheet" href="../../plugins/colorpicker/bootstrap-colorpicker.min.css" />
    <!-- Bootstrap time Picker -->
    <link rel="stylesheet" href="../../plugins/timepicker/bootstrap-timepicker.min.css" />
    <!-- Select2 -->
    <link rel="stylesheet" href="/plugins/select2/select2.min.css" />
    <script src="Scripts/jquery-1.10.2.js"></script>
    <div>
        <div class="content-wrapper">
            <asp:ListView ID="lstSales" runat="server" ItemPlaceholderID="groupPlaceHolder1" OnItemCommand="lstSales_ItemCommand" OnItemDataBound="lstSales_ItemDataBound">
                <LayoutTemplate>
                    <section class="content">
                        <div class="row">

                            <div class="col-xs-12">
                                <div class="box">
                                    <div class="box-header">
                                        <h3 class="box-title">Sales</h3>
                                        <div class="pull-right">
                                            <asp:LinkButton runat="server" ID="btnPrint" Text="Print" CssClass="btn btn-block btn-success"  />
                                        </div>
                                    </div>
                                    <!-- /.box-header -->
                                    <div class="box-body">

                                        <table id="example2" class="table table-bordered table-hover">
                                            <thead>
                                                <tr>
                                                    <th>Sales Entry Time</th>
                                                    <th>Day Sale</th>
                                                    <th>Refunds</th>
                                                    <th>Net Sales</th>
                                                    <th>Monthly Sales</th>
                                                    <th>$ Commision</th>
                                                    <th>% Commision</th>
                                                    <th>Cash Bonus</th>
                                                </tr>
                                            </thead>
                                            <tbody>
                                                <asp:PlaceHolder runat="server" ID="groupPlaceHolder1"></asp:PlaceHolder>
                                            </tbody>
                                            <tfoot>
                                                <tr>
                                                    <td>Draw Taken in Month:
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="lblDrawTakenInMonth" runat="server" Text=""></asp:Label>
                                                    </td>

                                                    <td>Totals:
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="lblTotals" runat="server" Text=""></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="lblDollarCommision" runat="server" Text=""></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="lblPercentCommision" runat="server" Text=""></asp:Label>
                                                    </td>
                                                    <td></td>
                                                    <td>
                                                        <asp:Label ID="lblTotalCashBonus" runat="server" Text=""></asp:Label></td>
                                                    <td></td>
                                                </tr>
                                                <tr>
                                                    <td>Daily Bonus For Month</td>
                                                    <td>
                                                        <asp:Label ID="lblDailyBonusForMonth" runat="server" Text=""></asp:Label></td>
                                                    <td></td>
                                                    <td>Monthly Office Rent</td>
                                                    <td>
                                                        <asp:Label ID="lblMonthlyOfficeRent" runat="server" Text=""></asp:Label></td>
                                                    <td>Pay</td>
                                                    <td>
                                                        <asp:Label ID="lblPayName" runat="server" Text=""></asp:Label></td>
                                                    <td></td>
                                                    <td></td>
                                                </tr>
                                                <tr>
                                                    <td colspan="4"></td>
                                                    <td>QBs Total Pay</td>
                                                    <td>
                                                        <asp:Label ID="lblQBtotalPayout" runat="server" Text=""></asp:Label>
                                                    </td>
                                                    <td>Actual Payout</td>
                                                    <td>
                                                        <asp:Label ID="lblActualPayOut" runat="server" Text=""></asp:Label>
                                                    </td>
                                                </tr>
                                            </tfoot>
                                        </table>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </section>
                </LayoutTemplate>

                <ItemTemplate>
                    <tr>
                        <td><%# Eval("EntryDate") %></td>
                        <td><%# Eval("DailySaleAmount") %></td>
                        <td><%# Eval("Refunds") %></td>
                        <td><%# Eval("NetSales") %></td>
                        <td><%# Eval("MonthlySales") %></td>
                        <td><%# Eval("CommisionInUSD") %></td>
                        <td><%# Eval("CommisionPercentage") %></td>
                        <td><%# Eval("CashBonus") %></td>
                        <%-- <td>
                            <asp:LinkButton runat="server" ID="lnkEdit" CssClass="fa fa-fw fa-edit" CommandArgument='<%# Eval("SaleID") %>' ToolTip="Edit Sale" CommandName="EditSale"></asp:LinkButton>
                        </td>--%>
                    </tr>
                </ItemTemplate>


            </asp:ListView>
        </div>
    </div>
   <%-- <script src="Scripts/jquery.min.js"></script>--%>
    <script type="text/javascript">
        $(document).ready(function () {
            $('#ctl00_ContentPlaceHolder1_lstSales_btnPrint').click(function () {
                printData();
                return false;
            });
        });

        function printData() {
            var divToPrint = document.getElementById("example2");
            newWin = window.open("");
            newWin.document.write(divToPrint.outerHTML);
            newWin.print();
            newWin.close();
        }
    </script>
</asp:Content>
