<%@ Page Title="" Language="C#" MasterPageFile="~/ComplianceMaster.Master" AutoEventWireup="true" CodeBehind="AddDriver.aspx.cs" Inherits="PrivateICO.AddDriver" %>

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
                <h1>Add User
                </h1>
                <ol class="breadcrumb">
                    <li><a href="#"><i class="fa fa-dashboard"></i>Dashboard</a></li>
                    <li><a href="#">Driver Interview</a></li>
                    <li class="active">Add Driver Profile</li>
                </ol>
            </section>

            <section class="content">

                <!-- SELECT2 EXAMPLE -->
                <div class="box box-default">
                    <div class="box-header with-border">
                        <h3 class="box-title">Driver Profile Interview Sheet</h3>

                        <div class="box-tools pull-right">
                            <button type="button" class="btn btn-box-tool" data-widget="collapse"><i class="fa fa-minus"></i></button>
                        </div>
                    </div>
                    <!-- /.box-header -->
                    <div class="box-body">
                        <div class="row">

                            <div class="col-md-6">

                                <div class="form-group">
                                    <label>DBA*</label>
                                    <asp:TextBox runat="server" ID="txtDriverDBA" CssClass="form-control" required placeholder="Enter DBA#"></asp:TextBox>
                                </div>
                                <!-- /.form-group -->
                            </div>

                            <div class="col-md-6">

                                <div class="form-group">
                                    <label>Date*</label>
                                    <asp:TextBox runat="server" ID="txtDate" CssClass="form-control" required placeholder="Enter Date"></asp:TextBox>
                                </div>
                                <!-- /.form-group -->
                            </div>

                            <div class="col-md-12">

                                <div class="form-group">
                                    <label>Legal Name*</label>
                                    <asp:TextBox runat="server" ID="txtDriverLegalName" CssClass="form-control" required placeholder="Enter Legal Name"></asp:TextBox>
                                </div>
                                <!-- /.form-group -->
                            </div>

                            <div class="col-md-4">
                                <div class="form-group">
                                    <label>USDOT#</label>
                                    <asp:TextBox runat="server" type="number" ID="txtDriverUSDOT" CssClass="form-control" required placeholder="Enter USDot"></asp:TextBox>
                                </div>

                            </div>

                            <div class="col-md-4">

                                <div class="form-group">
                                    <label>MC#*</label>
                                    <asp:TextBox runat="server" type="number" ID="txtMC" CssClass="form-control" required placeholder="Enter MC#"></asp:TextBox>
                                </div>
                                <!-- /.form-group -->
                            </div>

                            <div class="col-md-6">

                                <div class="form-group">
                                    <label>Phone No</label>
                                    <asp:TextBox runat="server" ID="txtDriverPhone" CssClass="form-control" required placeholder="Enter Phone No"></asp:TextBox>
                                </div>
                                <!-- /.form-group -->
                            </div>

                            <div class="col-md-12">

                                <div class="form-group">
                                    <label>Email Address</label>
                                    <asp:TextBox runat="server" ID="txtDriverEmailAddress" type="email" CssClass="form-control" required placeholder="Enter Email Address"></asp:TextBox>
                                </div>
                                <!-- /.form-group -->
                            </div>

                            <div class="col-md-12">

                                <div class="form-group">
                                    <label>Driver Name*</label>
                                    <asp:TextBox runat="server" ID="txtDriverName" CssClass="form-control" required placeholder="Enter Driver Name"></asp:TextBox>
                                </div>
                                <!-- /.form-group -->
                            </div>

                            <div class="col-md-12">

                                <div class="form-group">
                                    <label>Driver's Supervisor</label>
                                    <asp:TextBox runat="server" ID="txtSupervisor" CssClass="form-control" required placeholder="Enter Supervisor Name"></asp:TextBox>
                                </div>
                                <!-- /.form-group -->
                            </div>
                            <div class="col-md-4">

                                <div class="form-group">
                                    <label>Driver License #</label>
                                    <asp:TextBox runat="server" ID="txtDriverLicense" CssClass="form-control" required placeholder="Enter Driver License"></asp:TextBox>
                                </div>
                                <!-- /.form-group -->
                            </div>

                            <div class="col-md-4">

                                <div class="form-group">
                                    <label>Expiration Date #</label>
                                    <asp:TextBox runat="server" ID="txtExpirationDate" CssClass="form-control" required placeholder="Enter Expiration Date"></asp:TextBox>
                                </div>
                                <!-- /.form-group -->
                            </div>

                            <div class="col-md-4">

                                <div class="form-group">
                                    <label>Class</label>
                                    <asp:TextBox runat="server" ID="txtClass" CssClass="form-control" required placeholder="Enter Class"></asp:TextBox>
                                </div>
                                <!-- /.form-group -->
                            </div>

                            <div class="col-md-6">

                                <div class="form-group">
                                    <label>State Issued</label>
                                    <asp:DropDownList ID="DropDownListState" runat="server"  CssClass="form-control">
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
                                    <asp:TextBox runat="server" ID="txtDOB" CssClass="form-control" required placeholder="Enter Status Issued"></asp:TextBox>
                                </div>
                                <!-- /.form-group -->
                            </div>

                            <div class="col-md-4">

                                <div class="form-group">
                                    <label>SSN#</label>
                                    <asp:TextBox runat="server" ID="txtDriverSSN" CssClass="form-control" required placeholder="Enter SSN#"></asp:TextBox>
                                </div>
                                <!-- /.form-group -->
                            </div>

                            <div class="col-md-4">

                                <div class="form-group">
                                    <label>EIN#</label>
                                    <asp:TextBox runat="server" ID="txtDriverEIN" CssClass="form-control" required placeholder="Enter EIN#"></asp:TextBox>
                                </div>
                                <!-- /.form-group -->
                            </div>

                            <div class="col-md-12">

                                <div class="form-group">
                                    <label>Notes/Comments/Observations</label>
                                    <asp:TextBox runat="server" ID="txtNotesCommentsObservation" CssClass="form-control" required placeholder="Enter Comment/Notes/Observation"></asp:TextBox>
                                </div>
                                <!-- /.form-group -->
                            </div>



                            <div class="col-md-12">

                                <div class="form-group">
                                    <label>Services</label>
                                    <asp:CheckBoxList ID="chkServices" runat="server">
                                        <asp:ListItem>DQF</asp:ListItem>
                                        <asp:ListItem>MCS- 150 App Changes</asp:ListItem>
                                        <asp:ListItem>Drug and Alcohol</asp:ListItem>
                                        <asp:ListItem>OP1/MC# Form</asp:ListItem>
                                        <asp:ListItem>CA#</asp:ListItem>
                                        <asp:ListItem>TX DOT#</asp:ListItem>
                                        <asp:ListItem>State Filing</asp:ListItem>
                                        <asp:ListItem>MCP# CA</asp:ListItem>
                                        <asp:ListItem>IFTA/IRP</asp:ListItem>
                                        <asp:ListItem>SOS</asp:ListItem>
                                        <asp:ListItem>UCR</asp:ListItem>
                                        <asp:ListItem>BOC-3</asp:ListItem>
                                        <asp:ListItem>Other</asp:ListItem>
                                    </asp:CheckBoxList>
                                </div>
                                <!-- /.form-group -->
                            </div>

                            <div class="col-md-12">
                                <label></label>
                                <div class="form-group">
                                    <asp:Button runat="server" ID="btnSaveDriver" Text="Save Details" CssClass="btn btn-block btn-success" OnClick="btnSaveDriver_Click" />
                                </div>
                            </div>
                        </div>
                        <!-- /.row -->
                    </div>
                </div>
            </section>



        </div>
    </div>

</asp:Content>
