<%@ Page Title="" Language="C#" MasterPageFile="~/ComplianceMaster.Master" AutoEventWireup="true" CodeBehind="EditTempDOTSale.aspx.cs" Inherits="PrivateICO.EditTempDOTSale" %>

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
    <div>
        <div class="content-wrapper">
            <!-- Content Header (Page header) -->
            <section class="content-header">
                <h1>Edit Sale
                </h1>
                <ol class="breadcrumb">
                    <li><a href="#"><i class="fa fa-dashboard"></i>Dashboard</a></li>
                    <li><a href="#">Driver Interview</a></li>
                    <li class="active">Edit USDOT Sale</li>
                </ol>
            </section>

            <section class="content">

                <!-- SELECT2 EXAMPLE -->
                <div class="box box-default">
                    <div class="box-header with-border">
                        <h3 class="box-title">PC Sale# :
                            <asp:Label ID="lblPCSaleNo" runat="server" Text=""></asp:Label>,
                            <asp:Label ID="lblPCSalePersonName" runat="server" Text=""></asp:Label></h3>

                        <div class="box-tools pull-right">
                            <button type="button" class="btn btn-box-tool" data-widget="collapse"><i class="fa fa-minus"></i></button>
                        </div>
                    </div>
                    <!-- /.box-header -->
                    <div class="box-body">
                        <div class="row">
                            <div class="col-md-6">

                                <div class="form-group">
                                    <label>Card No</label>
                                    <asp:TextBox runat="server" ID="txtCardNo" size="16" MaxLength="16" pattern="[0-9,*]*" autocomplete="off" class="stripe_card_number" CssClass="form-control stripe_card_number" placeholder="Enter Card No"></asp:TextBox><br />

                                    <ul class="card_logos" runat="server" id="ulcardtype">
                                        <li class="card_visa">Visa</li>
                                        <li class="card_mastercard">Mastercard</li>
                                        <li class="card_amex">American Express</li>
                                        <li class="card_discover">Discover</li>
                                        <li class="card_jcb">JCB</li>
                                        <li class="card_diners">Diners Club</li>
                                    </ul>
                                </div>
                                <asp:HiddenField ID="hdnCardType" runat="server" />
                                <asp:HiddenField ID="hidCardNo" runat="server" />
                                <asp:HiddenField ID="hidSSNNo" runat="server" />
                            </div>


                            <div class="col-md-6">

                                <div class="form-group">
                                    <label>Expiration</label>
                                    <asp:TextBox runat="server" ID="txtExpiration" CssClass="form-control" placeholder="Enter Expiration"></asp:TextBox>
                                </div>
                                <!-- /.form-group -->
                            </div>

                            <div class="col-md-6">

                                <div class="form-group">
                                    <label>CVC</label>
                                    <asp:TextBox runat="server" ID="txtCVC" CssClass="form-control" placeholder="Enter CVC"></asp:TextBox>
                                </div>
                                <!-- /.form-group -->
                            </div>
                        </div>
                        <!-- /.row -->
                    </div>
                </div>
            </section>

            <section class="content">

                <!-- SELECT2 EXAMPLE -->
                <div class="box box-default">
                    <div class="box-header with-border">
                        <h3 class="box-title">Company Snapshot</h3>

                        <div class="box-tools pull-right">
                            <button type="button" class="btn btn-box-tool" data-widget="collapse"><i class="fa fa-minus"></i></button>
                        </div>
                    </div>
                    <!-- /.box-header -->
                    <div class="box-body">
                        <div class="row">
                            <div class="col-md-4">
                                <div class="form-group">
                                    <label>USDOT#</label>
                                    <asp:TextBox runat="server" type="number" ID="txtUSDOT" CssClass="form-control" placeholder="Enter USDot"></asp:TextBox>
                                </div>

                            </div>

                            <div class="col-md-4">

                                <div class="form-group">
                                    <label>MC No</label>
                                    <asp:TextBox runat="server" type="number" ID="txtCA" CssClass="form-control" placeholder="Enter MC No"></asp:TextBox>
                                </div>
                                <!-- /.form-group -->
                            </div>

                            <div class="col-md-4">

                                <div class="form-group">
                                    <label>Name on Card for DocuSign</label>
                                    <asp:TextBox runat="server" ID="txtNameOnCard" CssClass="form-control" placeholder="Enter Name on Card"></asp:TextBox>
                                </div>
                                <!-- /.form-group -->
                            </div>

                            <div class="col-md-4">
                                <div class="form-group">
                                    <label>USDOT Pin No</label>
                                    <asp:TextBox runat="server" ID="txtUSDOTPin" CssClass="form-control" placeholder="Enter USDot Pin No"></asp:TextBox>
                                </div>

                            </div>

                            <div class="col-md-4">

                                <div class="form-group">
                                    <label>Name</label>
                                    <asp:TextBox runat="server" ID="txtName" CssClass="form-control" placeholder="Enter Name"></asp:TextBox>
                                </div>
                                <!-- /.form-group -->
                            </div>

                            <div class="col-md-4">

                                <div class="form-group">
                                    <label>Admin/DBA</label>
                                    <asp:TextBox runat="server" ID="txtDBA" CssClass="form-control" placeholder="Enter DBA#"></asp:TextBox>
                                </div>
                                <!-- /.form-group -->
                            </div>

                            <div class="col-md-6">

                                <div class="form-group">
                                    <label>Legal Name</label>
                                    <asp:TextBox runat="server" ID="txtLegalName" CssClass="form-control" placeholder="Enter Legal Name"></asp:TextBox>
                                </div>
                                <!-- /.form-group -->
                            </div>

                            <div class="col-md-12">

                                <div class="form-group">
                                    <label>Company Type </label>
                                    <asp:DropDownList ID="chkCompanyType" runat="server" CssClass="form-control">
                                        <asp:ListItem>LLC Limited Liability</asp:ListItem>
                                        <asp:ListItem>Sole Proprietor</asp:ListItem>
                                        <asp:ListItem>Corporation </asp:ListItem>
                                        <asp:ListItem>Partnership </asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                                <!-- /.form-group -->
                            </div>

                            <div class="col-md-12">

                                <div class="form-group">
                                    <label>Physical Address</label>
                                    <asp:TextBox runat="server" ID="txtMailingAddress" TextMode="MultiLine" CssClass="form-control" placeholder="Enter Mailing Address"></asp:TextBox>
                                </div>
                                <!-- /.form-group -->
                            </div>

                            <div class="col-md-12">

                                <div class="form-group">
                                    <asp:CheckBox ID="chkSameAddress" runat="server" CssClass="form-control" Text="Same as mailing address" />
                                    <label></label>

                                </div>
                                <!-- /.form-group -->
                            </div>
                            <div class="col-md-12">

                                <div class="form-group">
                                    <label>Billing Address</label>
                                    <asp:TextBox runat="server" ID="txtBillingAddress" TextMode="MultiLine" CssClass="form-control" placeholder="Enter Billing Address"></asp:TextBox>
                                </div>
                                <!-- /.form-group -->
                            </div>

                            <div class="col-md-12">

                                <div class="form-group">
                                    <label>Email Address</label>
                                    <asp:TextBox runat="server" type="email" ID="txtEmailAddress" CssClass="form-control" placeholder="Enter Email Address"></asp:TextBox>
                                </div>
                                <!-- /.form-group -->
                            </div>

                            <div class="col-md-6">

                                <div class="form-group">
                                    <label>Date/Time</label>
                                    <asp:TextBox runat="server" ID="txtDateTime" CssClass="form-control" placeholder="Enter DateTime"></asp:TextBox>
                                </div>
                                <!-- /.form-group -->
                            </div>

                            <div class="col-md-4">

                                <div class="form-group">
                                    <label>Phone #(<asp:Label ID="lblAdditionalPhoneNo" runat="server" Text=""></asp:Label>)</label>
                                    <asp:TextBox runat="server" ID="txtAdditionalPhoneNo" CssClass="form-control" placeholder="Enter Additional Driver Phone#"></asp:TextBox>
                                </div>
                                <!-- /.form-group -->
                            </div>

                            <div class="col-md-4">

                                <div class="form-group">
                                    <label>Additional Phone Type </label>
                                    <asp:DropDownList ID="drpPhoneType" runat="server" CssClass="form-control">
                                        <asp:ListItem>Cell</asp:ListItem>
                                        <asp:ListItem>Landline</asp:ListItem>
                                        <asp:ListItem>Office</asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                                <!-- /.form-group -->
                            </div>

                             <div class="col-md-4">

                                <div class="form-group">
                                    <label>Additional Phone # </label>
                                    <asp:TextBox runat="server" ID="txtOtherPhoneNo" CssClass="form-control" placeholder="Enter Additional Driver Phone#"></asp:TextBox>
                                </div>
                                <!-- /.form-group -->
                            </div>

                            <div class="col-md-12">

                                <div class="form-group">
                                    <label>Compliance Supervisor</label>
                                    <asp:DropDownList ID="drpComplianceSupervisor" runat="server" CssClass="form-control"></asp:DropDownList>
                                </div>
                                <!-- /.form-group -->
                            </div>



                        </div>
                        <!-- /.row -->
                    </div>
                </div>
            </section>

            <section class="content" id="driverSection">

                <!-- SELECT2 EXAMPLE -->
                <div class="box box-default">
                    <div class="box-header with-border">
                        <h3 class="box-title">Vehicle Info</h3>

                        <div class="box-tools pull-right">
                            <button type="button" class="btn btn-box-tool" data-widget="collapse"><i class="fa fa-minus"></i></button>
                        </div>
                    </div>
                    <!-- /.box-header -->
                    <div class="box-body">
                        <div class="row">
                            <div class="col-md-6">
                                <div class="form-group">
                                    <label>Year</label>
                                    <asp:TextBox runat="server" ID="txtYear" CssClass="form-control" placeholder="Enter Year"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-md-6">
                                <div class="form-group">
                                    <label>Make</label>
                                    <asp:TextBox runat="server" ID="txtMake" CssClass="form-control" placeholder="Enter Make"></asp:TextBox>
                                </div>
                                <!-- /.form-group -->
                            </div>

                            <div class="col-md-6">

                                <div class="form-group">
                                    <label>Model</label>
                                    <asp:TextBox runat="server" ID="txtModel" CssClass="form-control" placeholder="Enter Model"></asp:TextBox>
                                </div>
                                <!-- /.form-group -->
                            </div>

                            <div class="col-md-6">

                                <div class="form-group">
                                    <label>GVW#</label>
                                    <asp:TextBox runat="server" ID="txtGVW" CssClass="form-control" placeholder="Enter GVW"></asp:TextBox>
                                </div>
                                <!-- /.form-group -->
                            </div>
                            <div class="col-md-4">

                                <div class="form-group">
                                    <label>Cargo Carried</label><br />
                                    <asp:CheckBox runat="server" ID="chkGeneralFreight" Text="General Freight" /><br />
                                    <asp:CheckBox runat="server" ID="chkHouseholdGoods" Text="Household Goods" /><br />
                                    <asp:CheckBox runat="server" ID="chkMetalsheetscoilsrolls" Text="Metal: sheets, coils, rolls" /><br />
                                    <asp:CheckBox runat="server" ID="chkMotorVehicles" Text="Motor Vehicles" /><br />
                                    <asp:CheckBox runat="server" ID="chkDriveTowaway" Text="Drive/Tow away" /><br />
                                    <asp:CheckBox runat="server" ID="chkLogsPolesBeamsLumber" Text="Logs, Poles, Beams, Lumber" /><br />
                                    <asp:CheckBox runat="server" ID="chkBuildingMaterials" Text="Building Materials" /><br />
                                    <asp:CheckBox runat="server" ID="chkMobileHomes" Text="Mobile Homes" /><br />
                                    <asp:CheckBox runat="server" ID="chkMachineryLargeObjects" Text="Machinery, Large Objects" /><br />
                                    <asp:CheckBox runat="server" ID="chkFreshProduce" Text="Fresh Produce" /><br />
                                </div>
                                <!-- /.form-group -->
                            </div>
                            <div class="col-md-4">

                                <div class="form-group">
                                    <label></label>
                                    <br />
                                    <asp:CheckBox runat="server" ID="chkLiquidsGases" Text="Liquids/Gases" /><br />
                                    <asp:CheckBox runat="server" ID="chkIntermodalCont" Text="Intermodal Cont." /><br />
                                    <asp:CheckBox runat="server" ID="chkPassengers" Text="Passengers" /><br />
                                    <asp:CheckBox runat="server" ID="chkOilfieldEquipment" Text="Oilfield Equipment" /><br />
                                    <asp:CheckBox runat="server" ID="chkLivestock" Text="Livestock" /><br />
                                    <asp:CheckBox runat="server" ID="chkGrainFeedHay" Text="Grain, Feed, Hay" /><br />
                                    <asp:CheckBox runat="server" ID="chkCoalCoke" Text="Coal/Coke" /><br />
                                    <asp:CheckBox runat="server" ID="chkMeat" Text="Meat" /><br />
                                    <asp:CheckBox runat="server" ID="chkGarbageRefuse" Text="Garbage/Refuse" /><br />
                                    <asp:CheckBox runat="server" ID="chkUSMail" Text="US Mail" /><br />
                                </div>
                                <!-- /.form-group -->
                            </div>
                            <div class="col-md-4">

                                <div class="form-group">
                                    <label></label>
                                    <br />
                                    <asp:CheckBox runat="server" ID="chkChemicals" Text="Chemicals" /><br />
                                    <asp:CheckBox runat="server" ID="chkCommoditiesDryBulk" Text="Commodities Dry Bulk" /><br />
                                    <asp:CheckBox runat="server" ID="chkRefrigeratedFood" Text="Refrigerated Food" /><br />
                                    <asp:CheckBox runat="server" ID="chkBeverages" Text="Beverages" /><br />
                                    <asp:CheckBox runat="server" ID="chkPaperProducts" Text="Paper Products" /><br />
                                    <asp:CheckBox runat="server" ID="chkUtilities" Text="Utilities" /><br />
                                    <asp:CheckBox runat="server" ID="chkAgriculturalFarmSupplies" Text="Agricultural/Farm Supplies" /><br />
                                    <asp:CheckBox runat="server" ID="chkConstruction" Text="Construction" /><br />
                                    <asp:CheckBox runat="server" ID="chkWaterWell" Text="Water Well" /><br />
                                </div>
                                <!-- /.form-group -->
                            </div>

                        </div>
                        <!-- /.row -->
                    </div>
                </div>
            </section>

            <section class="content">

                <!-- SELECT2 EXAMPLE -->
                <div class="box box-default">
                    <div class="box-header with-border">
                        <h3 class="box-title">Information Sheet</h3>

                        <div class="box-tools pull-right">
                            <button type="button" class="btn btn-box-tool" data-widget="collapse"><i class="fa fa-minus"></i></button>
                        </div>
                    </div>
                    <!-- /.box-header -->
                    <div class="box-body">
                        <div class="row">



                            <div class="col-md-6">

                                <div class="form-group">
                                    <label>Date</label>
                                    <asp:TextBox runat="server" ID="txtDate" CssClass="form-control" placeholder="Enter Date"></asp:TextBox>
                                </div>
                                <!-- /.form-group -->
                            </div>

                            <div class="col-md-12">

                                <div class="form-group">
                                    <label>Legal Name</label>
                                    <asp:TextBox runat="server" ID="txtDriverLegalName" CssClass="form-control" placeholder="Enter Legal Name"></asp:TextBox>
                                </div>
                                <!-- /.form-group -->
                            </div>

                            <div class="col-md-4">
                                <div class="form-group">
                                    <label>USDOT#</label>
                                    <asp:TextBox runat="server" type="number" ID="txtDriverUSDOT" CssClass="form-control" placeholder="Enter USDot"></asp:TextBox>
                                </div>

                            </div>

                            <div class="col-md-6">

                                <div class="form-group">
                                    <label>Phone No (Driver or Company responsible)</label>
                                    <asp:TextBox runat="server" ID="txtDriverPhone" CssClass="form-control" placeholder="Enter Phone No"></asp:TextBox>
                                </div>
                                <!-- /.form-group -->
                            </div>

                            <div class="col-md-12">

                                <div class="form-group">
                                    <label>Email Address (Driver or Company responsible)</label>
                                    <asp:TextBox runat="server" ID="txtDriverEmailAddress" type="email" CssClass="form-control" placeholder="Enter Email Address"></asp:TextBox>
                                </div>
                                <!-- /.form-group -->
                            </div>

                            <div class="col-md-12">

                                <div class="form-group">
                                    <label>Driver Name</label>
                                    <asp:TextBox runat="server" ID="txtDriverName" CssClass="form-control" placeholder="Enter Driver Name"></asp:TextBox>
                                </div>
                                <!-- /.form-group -->
                            </div>

                            <div class="col-md-12">

                                <div class="form-group">
                                    <label>Driver's Supervisor is the owner of the company</label>
                                    <asp:TextBox runat="server" ID="txtSupervisor" CssClass="form-control" placeholder="Enter Supervisor Name"></asp:TextBox>
                                </div>
                                <!-- /.form-group -->
                            </div>
                            <div class="col-md-4">

                                <div class="form-group">
                                    <label>Driver License #</label>
                                    <asp:TextBox runat="server" ID="txtDriverLicense" CssClass="form-control" placeholder="Enter Driver License"></asp:TextBox>
                                </div>
                                <!-- /.form-group -->
                            </div>

                            <div class="col-md-4">

                                <div class="form-group">
                                    <label>Expiration Date #</label>
                                    <asp:TextBox runat="server" ID="txtExpirationDate" CssClass="form-control" placeholder="Enter Expiration Date"></asp:TextBox>
                                </div>
                                <!-- /.form-group -->
                            </div>

                            <div class="col-md-4">

                                <div class="form-group">
                                    <label>Class</label>
                                    <asp:TextBox runat="server" ID="txtClass" CssClass="form-control" placeholder="Enter Class"></asp:TextBox>
                                </div>
                                <!-- /.form-group -->
                            </div>

                            <div class="col-md-6">

                                <div class="form-group">
                                    <label>State Issued</label>
                                    <asp:DropDownList ID="DropDownListState" runat="server" CssClass="form-control">
                                        <asp:ListItem Value="AL">Alabama</asp:ListItem>
                                        <asp:ListItem Value="AK">Alaska</asp:ListItem>
                                        <asp:ListItem Value="AZ">Arizona</asp:ListItem>
                                        <asp:ListItem Value="AR">Arkansas</asp:ListItem>
                                        <asp:ListItem Value="CA">California</asp:ListItem>
                                        <asp:ListItem Value="CO">Colorado</asp:ListItem>
                                        <asp:ListItem Value="CT">Connecticut</asp:ListItem>
                                        <asp:ListItem Value="DC">District of Columbia</asp:ListItem>
                                        <asp:ListItem Value="DE">Delaware</asp:ListItem>
                                        <asp:ListItem Value="FL">Florida</asp:ListItem>
                                        <asp:ListItem Value="GA">Georgia</asp:ListItem>
                                        <asp:ListItem Value="HI">Hawaii</asp:ListItem>
                                        <asp:ListItem Value="ID">Idaho</asp:ListItem>
                                        <asp:ListItem Value="IL">Illinois</asp:ListItem>
                                        <asp:ListItem Value="IN">Indiana</asp:ListItem>
                                        <asp:ListItem Value="IA">Iowa</asp:ListItem>
                                        <asp:ListItem Value="KS">Kansas</asp:ListItem>
                                        <asp:ListItem Value="KY">Kentucky</asp:ListItem>
                                        <asp:ListItem Value="LA">Louisiana</asp:ListItem>
                                        <asp:ListItem Value="ME">Maine</asp:ListItem>
                                        <asp:ListItem Value="MD">Maryland</asp:ListItem>
                                        <asp:ListItem Value="MA">Massachusetts</asp:ListItem>
                                        <asp:ListItem Value="MI">Michigan</asp:ListItem>
                                        <asp:ListItem Value="MN">Minnesota</asp:ListItem>
                                        <asp:ListItem Value="MS">Mississippi</asp:ListItem>
                                        <asp:ListItem Value="MO">Missouri</asp:ListItem>
                                        <asp:ListItem Value="MT">Montana</asp:ListItem>
                                        <asp:ListItem Value="NE">Nebraska</asp:ListItem>
                                        <asp:ListItem Value="NV">Nevada</asp:ListItem>
                                        <asp:ListItem Value="NH">New Hampshire</asp:ListItem>
                                        <asp:ListItem Value="NJ">New Jersey</asp:ListItem>
                                        <asp:ListItem Value="NM">New Mexico</asp:ListItem>
                                        <asp:ListItem Value="NY">New York</asp:ListItem>
                                        <asp:ListItem Value="NC">North Carolina</asp:ListItem>
                                        <asp:ListItem Value="ND">North Dakota</asp:ListItem>
                                        <asp:ListItem Value="OH">Ohio</asp:ListItem>
                                        <asp:ListItem Value="OK">Oklahoma</asp:ListItem>
                                        <asp:ListItem Value="OR">Oregon</asp:ListItem>
                                        <asp:ListItem Value="PA">Pennsylvania</asp:ListItem>
                                        <asp:ListItem Value="RI">Rhode Island</asp:ListItem>
                                        <asp:ListItem Value="SC">South Carolina</asp:ListItem>
                                        <asp:ListItem Value="SD">South Dakota</asp:ListItem>
                                        <asp:ListItem Value="TN">Tennessee</asp:ListItem>
                                        <asp:ListItem Value="TX">Texas</asp:ListItem>
                                        <asp:ListItem Value="UT">Utah</asp:ListItem>
                                        <asp:ListItem Value="VT">Vermont</asp:ListItem>
                                        <asp:ListItem Value="VA">Virginia</asp:ListItem>
                                        <asp:ListItem Value="WA">Washington</asp:ListItem>
                                        <asp:ListItem Value="WV">West Virginia</asp:ListItem>
                                        <asp:ListItem Value="WI">Wisconsin</asp:ListItem>
                                        <asp:ListItem Value="WY">Wyoming</asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                                <!-- /.form-group -->
                            </div>

                            <div class="col-md-6">

                                <div class="form-group">
                                    <label>DOB</label>
                                    <asp:TextBox runat="server" ID="txtDOB" CssClass="form-control" placeholder="Enter Status Issued"></asp:TextBox>
                                </div>
                                <!-- /.form-group -->
                            </div>

                            <div class="col-md-6">

                                <div class="form-group">
                                    <label></label>
                                    <asp:DropDownList runat="server" ID="drpCDL" CssClass="form-control">
                                        <asp:ListItem>CDL</asp:ListItem>
                                        <asp:ListItem>Non-CDL</asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                                <!-- /.form-group -->
                            </div>

                            <div class="col-md-6">

                                <div class="form-group">
                                    <label>SSN#</label>
                                    <asp:TextBox runat="server" ID="txtDriverSSN" CssClass="form-control" placeholder="Enter SSN#"></asp:TextBox>
                                </div>
                                <!-- /.form-group -->
                            </div>

                            <div class="col-md-6">

                                <div class="form-group">
                                    <label>EIN# ( Admin) </label>
                                    <asp:TextBox runat="server" ID="txtDriverEIN" CssClass="form-control" placeholder="Enter EIN#"></asp:TextBox>
                                </div>
                                <!-- /.form-group -->
                            </div>

                            <div class="col-md-6">

                                <div class="form-group">
                                    <label>VIN# ( Admin) </label>
                                    <asp:TextBox runat="server" ID="txtDriverVIN" CssClass="form-control" placeholder="Enter VIN#"></asp:TextBox>
                                </div>
                                <!-- /.form-group -->
                            </div>

                            <div class="col-md-12">

                                <div class="form-group">
                                    <label>Notes/Comments/Observations</label>
                                    <asp:TextBox runat="server" ID="txtNotesCommentsObservation" MaxLength="100" CssClass="form-control" placeholder="Enter Comment/Notes/Observation"></asp:TextBox>
                                </div>
                                <!-- /.form-group -->
                            </div>

                            <div class="col-md-4">
                                <label></label>
                                <div class="form-group">
                                </div>
                                <!-- /.form-group -->
                            </div>



                            <div class="col-md-4">
                                <label></label>
                                <div class="form-group">
                                </div>
                            </div>

                            <div class="col-md-4">
                                <label></label>
                                <div class="form-group">
                                    <asp:Button runat="server" ID="btnUpdateDriver" Text="Update Driver and Vehicle Details" CssClass="btn btn-block btn-success" OnClick="btnUpdateDriver_Click" />
                                    <asp:HiddenField ID="hidCurrentDriverInterviewID" runat="server" />
                                </div>
                            </div>

                            <div class="col-md-12">
                                <div class="form-group">
                                    <asp:ListView ID="lstDrivers" runat="server" ItemPlaceholderID="groupPlaceHolder1" OnItemCommand="lstDrivers_ItemCommand">
                                        <LayoutTemplate>
                                            <section class="content">
                                                <div class="row">
                                                    <div class="col-xs-12">
                                                        <div class="box">
                                                            <div class="box-header">
                                                                <h3 class="box-title">Drivers</h3>
                                                            </div>
                                                            <!-- /.box-header -->
                                                            <div class="box-body">
                                                                <table id="example2" class="table table-bordered table-hover">
                                                                    <thead>
                                                                        <tr>
                                                                            <th>Date</th>
                                                                            <th>Legal Name</th>
                                                                            <th>USDOT No.</th>
                                                                            <th>Email Address</th>
                                                                            <th>Driver Name</th>
                                                                            <th>DOB</th>
                                                                            <th>Action</th>
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
                                            <tr runat="server" id="tempSaleArea">
                                                <td><%# Eval("Date") %></td>
                                                <td><%# Eval("LegalName") %></td>
                                                <td><%# Eval("USDOT") %></td>
                                                <td><%# Eval("Email") %></td>
                                                <td><%# Eval("DriverName") %></td>
                                                <td><%# Eval("DOB") %></td>
                                                <td>
                                                    <asp:LinkButton runat="server" ID="lnkEditDriver" CssClass="fa fa-fw fa-edit" CommandArgument='<%# Eval("DriverInterviewID") %>' CommandName="EditDriver"></asp:LinkButton>
                                                    <asp:LinkButton runat="server" ID="lnkDeleteDriver" CssClass="fa fa-fw fa-trash" CommandArgument='<%# Eval("DriverInterviewID") %>' CommandName="DeleteDriver"></asp:LinkButton>
                                                </td>
                                            </tr>
                                        </ItemTemplate>
                                    </asp:ListView>
                                </div>
                                <!-- /.form-group -->
                            </div>

                            <div class="col-md-6">
                                <label></label>
                                <div class="form-group">
                                    <asp:DropDownList ID="drpServices" CssClass="form-control" runat="server"></asp:DropDownList>&nbsp;&nbsp;
                                </div>
                            </div>

                            <div class="col-md-6">
                                <label></label>
                                <div class="form-group">
                                    <asp:Button runat="server" ID="btnAddService" Text="Add Service" OnClick="btnAddService_Click" CssClass="btn btn-block btn-success" />
                                </div>
                            </div>

                            <asp:Panel ID="pnlServiceList" runat="server">
                                <div class="col-md-12" id="purchasedServiceSection">

                                    <div class="form-group">
                                        <asp:ListView ID="lstServicesPurchased" runat="server" ItemPlaceholderID="groupPlaceHolder1" OnItemCommand="lstServicesPurchased_ItemCommand">
                                            <LayoutTemplate>
                                                <section class="content">
                                                    <div class="row">
                                                        <div class="col-xs-12">
                                                            <div class="box">
                                                                <div class="box-header">
                                                                    <h3 class="box-title">Purchased Services</h3>
                                                                </div>
                                                                <!-- /.box-header -->
                                                                <div class="box-body">
                                                                    <table id="example2" class="table table-bordered table-hover">
                                                                        <thead>
                                                                            <tr>
                                                                                <th>Service Name</th>
                                                                                <th>Price</th>
                                                                                <th>Action</th>
                                                                            </tr>
                                                                        </thead>
                                                                        <tbody>

                                                                            <asp:PlaceHolder runat="server" ID="groupPlaceHolder1"></asp:PlaceHolder>

                                                                        </tbody>
                                                                        <tfoot>
                                                                            <tr>
                                                                                <td colspan="2" align="right">Sub Total : 
                                                                                </td>
                                                                                <td>
                                                                                    <asp:Label ID="lblSubTotal" runat="server" Text="$0.00"></asp:Label>
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
                                                    <td><%# Eval("DocumentTypeName") %></td>
                                                    <td><%# Eval("Description") %></td>
                                                    <td>
                                                        <asp:LinkButton runat="server" ID="lnkDelete" OnClientClick="javascript:return confirm('Are you sure you want to delete this Service ?');" CssClass="fa fa-fw fa-trash" CommandArgument='<%# Eval("DocumentID") %>' CommandName="DelService"></asp:LinkButton>
                                                    </td>
                                                </tr>
                                            </ItemTemplate>


                                        </asp:ListView>
                                    </div>
                                </div>
                            </asp:Panel>

                            <div class="col-md-4">
                                <label></label>
                                <div class="form-group">
                                    <asp:Button ID="lnkAddDrivers" runat="server" OnClick="lnkAddDrivers_Click" Visible="false" Text="Add More Drivers" CssClass="btn btn-block btn-success"></asp:Button>
                                </div>
                                <!-- /.form-group -->
                            </div>



                            <div class="col-md-4">
                                <label></label>
                                <div class="form-group">
                                    <asp:Button runat="server" ID="btnEditDriverProfileInterview" Text="Save Details" CssClass="btn btn-block btn-success" OnClick="btnEditDriverProfileInterview_Click" />
                                </div>
                            </div>

                            <div class="col-md-4">
                                <label></label>
                                <div class="form-group">
                                    <asp:Button runat="server" ID="btnSubmitDetails" Text="Submit Details" CssClass="btn btn-block btn-success" OnClick="btnSubmitDetails_Click" />
                                </div>
                            </div>

                        </div>
                        <!-- /.row -->
                    </div>
                </div>
            </section>

        </div>
    </div>
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <script src="Scripts/jquery.creditCardTypeDetector.js"></script>
    <link href="Content/creditCardTypeDetector.css" rel="stylesheet" />
    <script type="text/javascript">
        $(document).ready(function () {
            $('#ctl00_ContentPlaceHolder1_txtCardNo').creditCardTypeDetector({ 'credit_card_logos': '.card_logos' });
            $('#ctl00_ContentPlaceHolder1_chkSameAddress').click(function () {
                if ($("#ctl00_ContentPlaceHolder1_chkSameAddress").is(':checked'))
                    $("#ctl00_ContentPlaceHolder1_txtBillingAddress").val($('#ctl00_ContentPlaceHolder1_txtMailingAddress').val());  // checked
                else
                    $("#ctl00_ContentPlaceHolder1_txtBillingAddress").val("");
            });
            $("#ctl00_ContentPlaceHolder1_txtCardNo").click(function () {
                var str = $("#ctl00_ContentPlaceHolder1_txtCardNo").val();
                str = str.replace(/\d(?=\d{16})/g, "*");
                $("#ctl00_ContentPlaceHolder1_txtCardNo").val($('#ctl00_ContentPlaceHolder1_hidCardNo').val());
            });
            $("#ctl00_ContentPlaceHolder1_txtDriverSSN").click(function () {
                var str = $("#ctl00_ContentPlaceHolder1_txtDriverSSN").val();
                str = str.replace(/\d(?=\d{16})/g, "*");
                $("#ctl00_ContentPlaceHolder1_txtDriverSSN").val($('#ctl00_ContentPlaceHolder1_hidSSNNo').val());
            });
            $("#ctl00_ContentPlaceHolder1_txtCardNo").change(function () {
                $('#ctl00_ContentPlaceHolder1_hidCardNo').val($("#ctl00_ContentPlaceHolder1_txtCardNo").val());
                var str = $("#ctl00_ContentPlaceHolder1_txtCardNo").val();
                str = str.replace(/\d(?=\d{4})/g, "*");
                $("#ctl00_ContentPlaceHolder1_txtCardNo").val(str);
            });
            $("#ctl00_ContentPlaceHolder1_txtDriverSSN").change(function () {
                $('#ctl00_ContentPlaceHolder1_hidSSNNo').val($("#ctl00_ContentPlaceHolder1_txtDriverSSN").val());
                var str = $("#ctl00_ContentPlaceHolder1_txtDriverSSN").val();
                str = str.replace(/\d(?=\d{4})/g, "*");
                $("#ctl00_ContentPlaceHolder1_txtDriverSSN").val(str);
            });
            var str = $("#ctl00_ContentPlaceHolder1_txtCardNo").val();
            str = str.replace(/\d(?=\d{4})/g, "*");
            $("#ctl00_ContentPlaceHolder1_txtCardNo").val(str);
            var str1 = $("#ctl00_ContentPlaceHolder1_txtDriverSSN").val();
            str1 = str1.replace(/\d(?=\d{4})/g, "*");
            $("#ctl00_ContentPlaceHolder1_txtDriverSSN").val(str1);

            $("#ctl00_ContentPlaceHolder1_txtEmailAddress").change(function () {
                $.getJSON('https://apilayer.net/api/check?access_key=546aa8dd08e7c1363883e28154fecaef&email=' + $("#ctl00_ContentPlaceHolder1_txtEmailAddress").val() + '&smtp=1&format=1', function (data) {

                    var element = $("#ctl00_ContentPlaceHolder1_txtEmailAddress")[0];
                    if (data.mx_found == false || data.mx_found == null) {
                        element.setCustomValidity("Not a valid email address.");
                    }
                    else {
                        element.setCustomValidity("");
                    }

                });
            });

            $("#ctl00_ContentPlaceHolder1_txtDriverEmailAddress").change(function () {
                $.getJSON('https://apilayer.net/api/check?access_key=546aa8dd08e7c1363883e28154fecaef&email=' + $("#ctl00_ContentPlaceHolder1_txtDriverEmailAddress").val() + '&smtp=1&format=1', function (data) {
                    var element = $("#ctl00_ContentPlaceHolder1_txtDriverEmailAddress")[0];
                    if (data.mx_found == false || data.mx_found == null) {
                        element.setCustomValidity("Not a valid email address.");
                    }
                    else {
                        element.setCustomValidity("");
                    }
                });
            });

        });

        function autoscroll() {
            $('html, body').animate({
                scrollTop: $("#driverSection").offset().top
            }, 2000);
            $("#ctl00_ContentPlaceHolder1_txtDate").datepicker();
        }

        function servicescroll() {
            $('html, body').animate({
                scrollTop: $("#purchasedServiceSection").offset().top
            }, 1000);
        }

        function cardFunctions() {
            $('#ctl00_ContentPlaceHolder1_txtCardNo').creditCardTypeDetector({ 'credit_card_logos': '.card_logos' });
            $('#ctl00_ContentPlaceHolder1_chkSameAddress').click(function () {
                if ($("#ctl00_ContentPlaceHolder1_chkSameAddress").is(':checked'))
                    $("#ctl00_ContentPlaceHolder1_txtBillingAddress").val($('#ctl00_ContentPlaceHolder1_txtMailingAddress').val());  // checked
                else
                    $("#ctl00_ContentPlaceHolder1_txtBillingAddress").val("");
            });
            $("#ctl00_ContentPlaceHolder1_txtCardNo").click(function () {
                var str = $("#ctl00_ContentPlaceHolder1_txtCardNo").val();
                str = str.replace(/\d(?=\d{16})/g, "*");
                $("#ctl00_ContentPlaceHolder1_txtCardNo").val($('#ctl00_ContentPlaceHolder1_hidCardNo').val());
            });
            $("#ctl00_ContentPlaceHolder1_txtDriverSSN").click(function () {
                var str = $("#ctl00_ContentPlaceHolder1_txtDriverSSN").val();
                str = str.replace(/\d(?=\d{16})/g, "*");
                $("#ctl00_ContentPlaceHolder1_txtDriverSSN").val($('#ctl00_ContentPlaceHolder1_hidSSNNo').val());
            });
            $("#ctl00_ContentPlaceHolder1_txtCardNo").change(function () {
                $('#ctl00_ContentPlaceHolder1_hidCardNo').val($("#ctl00_ContentPlaceHolder1_txtCardNo").val());
                var str = $("#ctl00_ContentPlaceHolder1_txtCardNo").val();
                str = str.replace(/\d(?=\d{4})/g, "*");
                $("#ctl00_ContentPlaceHolder1_txtCardNo").val(str);
            });
            $("#ctl00_ContentPlaceHolder1_txtDriverSSN").change(function () {
                $('#ctl00_ContentPlaceHolder1_hidSSNNo').val($("#ctl00_ContentPlaceHolder1_txtDriverSSN").val());
                var str = $("#ctl00_ContentPlaceHolder1_txtDriverSSN").val();
                str = str.replace(/\d(?=\d{4})/g, "*");
                $("#ctl00_ContentPlaceHolder1_txtDriverSSN").val(str);
            });
            var str = $("#ctl00_ContentPlaceHolder1_txtCardNo").val();
            str = str.replace(/\d(?=\d{4})/g, "*");
            $("#ctl00_ContentPlaceHolder1_txtCardNo").val(str);
            var str1 = $("#ctl00_ContentPlaceHolder1_txtDriverSSN").val();
            str1 = str1.replace(/\d(?=\d{4})/g, "*");
            $("#ctl00_ContentPlaceHolder1_txtDriverSSN").val(str1);

            $("#ctl00_ContentPlaceHolder1_txtEmailAddress").change(function () {
                $.getJSON('https://apilayer.net/api/check?access_key=546aa8dd08e7c1363883e28154fecaef&email=' + $("#ctl00_ContentPlaceHolder1_txtEmailAddress").val() + '&smtp=1&format=1', function (data) {

                    var element = $("#ctl00_ContentPlaceHolder1_txtEmailAddress")[0];
                    if (data.mx_found == false || data.mx_found == null) {
                        element.setCustomValidity("Not a valid email address.");
                    }
                    else {
                        element.setCustomValidity("");
                    }

                });
            });

            $("#ctl00_ContentPlaceHolder1_txtDriverEmailAddress").change(function () {
                $.getJSON('https://apilayer.net/api/check?access_key=546aa8dd08e7c1363883e28154fecaef&email=' + $("#ctl00_ContentPlaceHolder1_txtDriverEmailAddress").val() + '&smtp=1&format=1', function (data) {
                    var element = $("#ctl00_ContentPlaceHolder1_txtDriverEmailAddress")[0];
                    if (data.mx_found == false || data.mx_found == null) {
                        element.setCustomValidity("Not a valid email address.");
                    }
                    else {
                        element.setCustomValidity("");
                    }
                });
            });
        }

        Sys.WebForms.PageRequestManager.getInstance().add_endRequest(autoscroll);
        Sys.WebForms.PageRequestManager.getInstance().add_endRequest(cardFunctions);
        Sys.WebForms.PageRequestManager.getInstance().add_endRequest(servicescroll);
    </script>
</asp:Content>
