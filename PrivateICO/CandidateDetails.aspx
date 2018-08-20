<%@ Page Title="" Language="C#" MasterPageFile="~/AdminMaster.Master" AutoEventWireup="true" CodeBehind="CandidateDetails.aspx.cs" Inherits="PrivateICO.CandidateDetails" %>

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
                <h1>Candidate Details
                </h1>
                <ol class="breadcrumb">
                    <li><a href="#"><i class="fa fa-dashboard"></i>Dashboard</a></li>
                    <li><a href="#">Hiring Management</a></li>
                    <li class="active">Candidate Details</li>
                </ol>
            </section>
            <section class="content">

                <!-- SELECT2 EXAMPLE -->
                <div class="box box-default">
                    <div class="box-header with-border">
                        <h3 class="box-title">User Info</h3>

                        <div class="box-tools pull-right">
                            <button type="button" class="btn btn-box-tool" data-widget="collapse"><i class="fa fa-minus"></i></button>
                        </div>
                    </div>
                    <!-- /.box-header -->
                    <div class="box-body">
                        <div class="row">
                            <div class="col-md-6">
                                <div class="form-group">
                                    <label>Last Name*</label>
                                    <asp:Label runat="server" ID="txtLastName" CssClass="form-control"></asp:Label>
                                </div>
                            </div>

                            <div class="col-md-6">
                                <div class="form-group">
                                    <label>First Name*</label>
                                    <asp:Label runat="server" ID="txtFirstName" CssClass="form-control"></asp:Label>
                                </div>
                            </div>

                            <div class="col-md-6">
                                <div class="form-group">
                                    <label>Middle Name</label>
                                    <asp:Label runat="server" ID="txtMiddleName" CssClass="form-control"></asp:Label>
                                </div>
                            </div>

                            <div class="col-md-12">
                                <div class="form-group">
                                    <label>Street Address*</label>
                                    <asp:Label runat="server" ID="txtStreetAddress" CssClass="form-control"></asp:Label>
                                </div>
                            </div>

                            <div class="col-md-6">
                                <div class="form-group">
                                    <label>Apartment/Unit# </label>
                                    <asp:Label runat="server" ID="txtApartmentUnitNo" CssClass="form-control" placeholder="Apartment Unit"></asp:Label>
                                </div>
                            </div>

                            <div class="col-md-6">
                                <div class="form-group">
                                    <label>City* </label>
                                    <asp:Label runat="server" ID="txtCity" CssClass="form-control" required placeholder="City"></asp:Label>
                                </div>
                            </div>

                            <div class="col-md-6">
                                <div class="form-group">
                                    <label>State* </label>
                                    <asp:Label runat="server" ID="txtState" CssClass="form-control" required placeholder="State"></asp:Label>
                                </div>
                            </div>

                            <div class="col-md-6">
                                <div class="form-group">
                                    <label>Zip Code* </label>
                                    <asp:Label runat="server" ID="txtZipCode" CssClass="form-control" required placeholder="Zip Code"></asp:Label>
                                </div>
                            </div>

                            <div class="col-md-6">
                                <div class="form-group">
                                    <label>Phone*</label>
                                    <asp:Label runat="server" ID="txtPhone" CssClass="form-control" required placeholder="Phone No."></asp:Label>
                                </div>
                            </div>

                            <div class="col-md-6">
                                <div class="form-group">
                                    <label>Email*</label>
                                    <asp:Label runat="server" ID="txtEmail" CssClass="form-control" required placeholder="Email"></asp:Label>
                                </div>
                            </div>

                            <div class="col-md-6">
                                <div class="form-group">
                                    <label>Date Available*</label>
                                    <asp:Label runat="server" ID="txtDateAvailable" CssClass="form-control" required placeholder="Availability Date"></asp:Label>
                                </div>
                            </div>

                            <div class="col-md-6">
                                <div class="form-group">
                                    <label>Social Security No*</label>
                                    <asp:Label runat="server" ID="txtSSN" CssClass="form-control" required placeholder="Social Security#"></asp:Label>
                                </div>
                            </div>

                            <div class="col-md-6">
                                <div class="form-group">
                                    <label>Desired Income*</label>
                                    <asp:Label runat="server" ID="txtDesiredIncome" CssClass="form-control" required placeholder="In USD"></asp:Label>
                                </div>
                            </div>

                            <div class="col-md-6">
                                <div class="form-group">
                                    <label>Position Applied For*</label>
                                    <asp:Label runat="server" ID="txtPositionAppliedFor" CssClass="form-control" required placeholder="Position"></asp:Label>
                                </div>
                            </div>

                            <div class="col-md-6">
                                <div class="form-group">
                                    <label>Are you the citizen of United States ?</label>
                                    <asp:Label runat="server" ID="lblCitizenUS" CssClass="form-control" ></asp:Label>
                                </div>
                            </div>

                            <div class="col-md-6">
                                <div class="form-group">
                                    <label>Are you authorized to work in United States ?</label>
                                    <asp:Label runat="server" ID="lblAuthorizedForWork" CssClass="form-control" ></asp:Label>
                                </div>
                            </div>

                            <div class="col-md-6">
                                <div class="form-group">
                                    <label>Have you worked for this company ?</label>
                                    <asp:Label runat="server" ID="lblHaveYourWorked" CssClass="form-control" ></asp:Label>
                                </div>
                            </div>

                            <div class="col-md-6">
                                <div class="form-group">
                                    <label>If Yes, When?</label>
                                    <asp:Label runat="server" ID="txtWorkedForCompany" CssClass="form-control" placeholder="When you have worked ?"></asp:Label>
                                </div>
                            </div>

                            <div class="col-md-6">
                                <div class="form-group">
                                    <label>Have you ever been convicted of a felony ?</label>
                                    <asp:Label runat="server" ID="lblHaveConvictedForFelony" CssClass="form-control" ></asp:Label>
                                </div>
                            </div>

                            <div class="col-md-12">
                                <div class="form-group">
                                    <label>If yes,explain</label>
                                    <asp:Label runat="server" ID="txtExplainFelony" CssClass="form-control" placeholder="Explain Felony"></asp:Label>
                                </div>
                            </div>

                            <div class="col-md-12">
                                <div class="form-group">
                                    <label>Resume</label>
                                    <asp:LinkButton runat="server" ID="lblDownloadResume" OnClick="lblDownloadResume_Click" CssClass="form-control">Download Resume</asp:LinkButton>
                                </div>
                            </div>
                        </div>
                        <!-- /.row -->
                    </div>
                    <!-- /.box-body -->

                </div>
                <!-- /.box -->


            </section>

            <section class="content">

                <!-- SELECT2 EXAMPLE -->
                <div class="box box-default">
                    <div class="box-header with-border">
                        <h3 class="box-title">Education</h3>

                        <div class="box-tools pull-right">
                            <button type="button" class="btn btn-box-tool" data-widget="collapse"><i class="fa fa-minus"></i></button>
                        </div>
                    </div>
                    <!-- /.box-header -->
                    <div class="box-body">
                        <div class="row">
                            <div class="col-md-6">
                                <div class="form-group">
                                    <label>Highschool</label>
                                    <asp:Label runat="server" ID="txtHighSchool" CssClass="form-control" placeholder="HighSchool"></asp:Label>
                                </div>
                            </div>
                            <div class="col-md-6">
                                <div class="form-group">
                                    <label>Address</label>
                                    <asp:Label runat="server" ID="txtHighSchoolAddress" CssClass="form-control" placeholder="HighSchool Address"></asp:Label>
                                </div>
                            </div>

                            <div class="col-md-6">
                                <div class="form-group">
                                    <label>From</label>
                                    <asp:Label runat="server" ID="txtFrom1" CssClass="form-control" placeholder="From (Which Year)"></asp:Label>
                                </div>
                            </div>
                            <div class="col-md-6">
                                <div class="form-group">
                                    <label>To</label>
                                    <asp:Label runat="server" ID="txtTo1" CssClass="form-control" placeholder="To (Which Year)"></asp:Label>
                                </div>
                            </div>

                            <div class="col-md-6">
                                <div class="form-group">
                                    <label>Did you graduated ?</label>
                                   <asp:Label runat="server" ID="lblGraduated1" CssClass="form-control" ></asp:Label>
                                </div>
                            </div>

                            <div class="col-md-6">
                                <div class="form-group">
                                    <label>Diploma</label>
                                    <asp:Label runat="server" ID="txtDiploma1" CssClass="form-control" placeholder="Diploma Details"></asp:Label>
                                </div>
                            </div>
                            <div class="col-md-6">
                                <div class="form-group">
                                    <label>College</label>
                                    <asp:Label runat="server" ID="txtCollege1" CssClass="form-control" placeholder="College Details"></asp:Label>
                                </div>
                            </div>
                            <div class="col-md-12">
                                <div class="form-group">
                                    <label>Address</label>
                                    <asp:Label runat="server" ID="txtCollegeAddress1" CssClass="form-control" placeholder="College Address"></asp:Label>
                                </div>
                            </div>



                            <div class="col-md-6">
                                <div class="form-group">
                                    <label>From</label>
                                    <asp:Label runat="server" ID="txtFrom2" CssClass="form-control" placeholder="From (Which Year)"></asp:Label>
                                </div>
                            </div>
                            <div class="col-md-6">
                                <div class="form-group">
                                    <label>To</label>
                                    <asp:Label runat="server" ID="txtTo2" CssClass="form-control" placeholder="To (Which Year)"></asp:Label>
                                </div>
                            </div>

                            <div class="col-md-6">
                                <div class="form-group">
                                    <label>Did you graduated ?</label>
                                    <asp:Label runat="server" ID="lblGraduated2" CssClass="form-control" ></asp:Label>
                                </div>
                            </div>
                            <div class="col-md-6">
                                <div class="form-group">
                                    <label>Deegre</label>
                                    <asp:Label runat="server" ID="txtDeegre" CssClass="form-control" placeholder="Deegre Details"></asp:Label>
                                </div>
                            </div>
                            <div class="col-md-6">
                                <div class="form-group">
                                    <label>Other</label>
                                    <asp:Label runat="server" ID="txtOther" CssClass="form-control" placeholder="Other Details"></asp:Label>
                                </div>
                            </div>

                            <div class="col-md-12">
                                <div class="form-group">
                                    <label>Address</label>
                                    <asp:Label runat="server" ID="txtDeegreAddress" CssClass="form-control" placeholder="College Address"></asp:Label>
                                </div>
                            </div>

                            <div class="col-md-6">
                                <div class="form-group">
                                    <label>From</label>
                                    <asp:Label runat="server" ID="txtFrom3" CssClass="form-control" placeholder="From (Which Year)"></asp:Label>
                                </div>
                            </div>
                            <div class="col-md-6">
                                <div class="form-group">
                                    <label>To</label>
                                    <asp:Label runat="server" ID="txtTo3" CssClass="form-control" placeholder="To (Which Year)"></asp:Label>
                                </div>
                            </div>

                            <div class="col-md-6">
                                <div class="form-group">
                                    <label>Did you graduated ?</label>
                                   <asp:Label runat="server" ID="lblGraduated3" CssClass="form-control" ></asp:Label>
                                </div>
                            </div>
                            <div class="col-md-6">
                                <div class="form-group">
                                    <label>Deegre</label>
                                    <asp:Label runat="server" ID="txtDeegre2" CssClass="form-control" placeholder="Deegre Details"></asp:Label>
                                </div>
                            </div>
                        </div>
                        <!-- /.row -->
                    </div>
                    <!-- /.box-body -->

                </div>
                <!-- /.box -->


            </section>

            <section class="content">

                <!-- SELECT2 EXAMPLE -->
                <div class="box box-default">
                    <div class="box-header with-border">
                        <h3 class="box-title">References</h3>

                        <div class="box-tools pull-right">
                            <button type="button" class="btn btn-box-tool" data-widget="collapse"><i class="fa fa-minus"></i></button>
                        </div>
                    </div>
                    <!-- /.box-header -->
                    <div class="box-body">
                        <div class="row">
                          <div class="col-md-12">
                            <div class="form-group">
                                <h3>Reference 1</h3>

                            </div>
                        </div>
                        <div class="col-md-6">
                            <div class="form-group">
                                <label>Full Name</label>
                                <asp:Label runat="server" ID="txtFullReferenceName" CssClass="form-control"  placeholder="Full Name"></asp:Label>
                            </div>
                        </div>

                        <div class="col-md-6">
                            <div class="form-group">
                                <label>Relationship</label>
                                <asp:Label runat="server" ID="txtRelationship" CssClass="form-control"  placeholder="Relationship with reference"></asp:Label>
                            </div>
                        </div>

                        <div class="col-md-6">
                            <div class="form-group">
                                <label>Company</label>
                                <asp:Label runat="server" ID="txtReferenceCompanyName" CssClass="form-control"  placeholder="Company Name"></asp:Label>
                            </div>
                        </div>
                        <div class="col-md-6">
                            <div class="form-group">
                                <label>Phone</label>
                                <asp:Label runat="server" ID="txtReferencePhoneNo" CssClass="form-control"  placeholder="Phone No"></asp:Label>
                            </div>
                        </div>
                        <div class="col-md-12">
                            <div class="form-group">
                                <label>Address</label>
                                <asp:Label runat="server" ID="txtReferenceAddress" CssClass="form-control"  placeholder="Address"></asp:Label>
                            </div>
                        </div>

                        <div class="col-md-12">
                            <div class="form-group">
                                <h3>Reference 2</h3>

                            </div>
                        </div>

                        <div class="col-md-6">
                            <div class="form-group">
                                <label>Full Name</label>
                                <asp:Label runat="server" ID="txtFullReferenceName2" CssClass="form-control"  placeholder="Full Name"></asp:Label>
                            </div>
                        </div>

                        <div class="col-md-6">
                            <div class="form-group">
                                <label>Relationship</label>
                                <asp:Label runat="server" ID="txtRelationship2" CssClass="form-control"  placeholder="Relationship with reference"></asp:Label>
                            </div>
                        </div>

                        <div class="col-md-6">
                            <div class="form-group">
                                <label>Company</label>
                                <asp:Label runat="server" ID="txtReferenceCompanyName2" CssClass="form-control"  placeholder="Company Name"></asp:Label>
                            </div>
                        </div>
                        <div class="col-md-6">
                            <div class="form-group">
                                <label>Phone</label>
                                <asp:Label runat="server" ID="txtReferencePhoneNo2" CssClass="form-control"  placeholder="Phone No"></asp:Label>
                            </div>
                        </div>
                        <div class="col-md-12">
                            <div class="form-group">
                                <label>Address</label>
                                <asp:Label runat="server" ID="txtReferenceAddress2" CssClass="form-control"  placeholder="Address"></asp:Label>
                            </div>
                        </div>
                        <div class="col-md-12">
                            <div class="form-group">
                                <h3>Reference 3</h3>

                            </div>
                        </div>
                        <div class="col-md-6">
                            <div class="form-group">
                                <label>Full Name</label>
                                <asp:Label runat="server" ID="txtFullReferenceName3" CssClass="form-control"  placeholder="Full Name"></asp:Label>
                            </div>
                        </div>

                        <div class="col-md-6">
                            <div class="form-group">
                                <label>Relationship</label>
                                <asp:Label runat="server" ID="txtRelationship3" CssClass="form-control"  placeholder="Relationship with reference"></asp:Label>
                            </div>
                        </div>

                        <div class="col-md-6">
                            <div class="form-group">
                                <label>Company</label>
                                <asp:Label runat="server" ID="txtReferenceCompanyName3" CssClass="form-control"  placeholder="Company Name"></asp:Label>
                            </div>
                        </div>
                        <div class="col-md-6">
                            <div class="form-group">
                                <label>Phone</label>
                                <asp:Label runat="server" ID="txtReferencePhoneNo3" CssClass="form-control"  placeholder="Phone No"></asp:Label>
                            </div>
                        </div>
                        <div class="col-md-12">
                            <div class="form-group">
                                <label>Address</label>
                                <asp:Label runat="server" ID="txtReferenceAddress3" CssClass="form-control"  placeholder="Address"></asp:Label>
                            </div>
                        </div>
                        </div>
                        <!-- /.row -->
                    </div>
                    <!-- /.box-body -->

                </div>
                <!-- /.box -->


            </section>

            <section class="content">

                <!-- SELECT2 EXAMPLE -->
                <div class="box box-default">
                    <div class="box-header with-border">
                        <h3 class="box-title">Employment</h3>

                        <div class="box-tools pull-right">
                            <button type="button" class="btn btn-box-tool" data-widget="collapse"><i class="fa fa-minus"></i></button>
                        </div>
                    </div>
                    <!-- /.box-header -->
                    <div class="box-body">
                        <div class="row">
                              
                    <div class="col-md-12">
                        <div class="form-group">
                            <h3>Previous Company Detail 1</h3>

                        </div>
                    </div>
                    <div class="col-md-6">
                        <div class="form-group">
                            <label>Company Name</label>
                            <asp:Label runat="server" ID="txtCompanyName1" CssClass="form-control"  placeholder="Company Name"></asp:Label>
                        </div>
                    </div>
                    <div class="col-md-6">
                        <div class="form-group">
                            <label>Phone</label>
                            <asp:Label runat="server" ID="txtCompanyPhone1" CssClass="form-control"  placeholder="Company Phone No"></asp:Label>
                        </div>
                    </div>

                    <div class="col-md-12">
                        <div class="form-group">
                            <label>Address</label>
                            <asp:Label runat="server" ID="txtCompanyAddress1" CssClass="form-control"  placeholder="Company Address"></asp:Label>
                        </div>
                    </div>

                    <div class="col-md-12">
                        <div class="form-group">
                            <label>Supervisor</label>
                            <asp:Label runat="server" ID="txtCompanySupervisor1" CssClass="form-control"  placeholder="Company Supervisor Name"></asp:Label>
                        </div>
                    </div>

                    <div class="col-md-6">
                        <div class="form-group">
                            <label>Job Title</label>
                            <asp:Label runat="server" ID="txtJobTitle" CssClass="form-control"  placeholder="Relationship with reference"></asp:Label>
                        </div>
                    </div>

                    <div class="col-md-6">
                        <div class="form-group">
                            <label>Starting Salary</label>
                            <asp:Label runat="server" ID="txtStartingSalary" CssClass="form-control"  placeholder="Starting Salary in USD"></asp:Label>
                        </div>
                    </div>

                    <div class="col-md-6">
                        <div class="form-group">
                            <label>Ending Salary</label>
                            <asp:Label runat="server" ID="txtEndingSalary" CssClass="form-control"  placeholder="Ending Salary in USD"></asp:Label>
                        </div>
                    </div>

                    <div class="col-md-6">
                        <div class="form-group">
                            <label>Responsibilities</label>
                            <asp:Label runat="server" ID="txtResponsibility" CssClass="form-control"  placeholder="Responsibilities"></asp:Label>
                        </div>
                    </div>

                    <div class="col-md-6">
                        <div class="form-group">
                            <label>From</label>
                            <asp:Label runat="server" ID="txtCompanyFrom1" CssClass="form-control"  placeholder="From (Which Year)"></asp:Label>
                        </div>
                    </div>
                    <div class="col-md-6">
                        <div class="form-group">
                            <label>To</label>
                            <asp:Label runat="server" ID="txtCompanyTo1" CssClass="form-control"  placeholder="To (Which Year)"></asp:Label>
                        </div>
                    </div>

                    <div class="col-md-6">
                        <div class="form-group">
                            <label>Reason For Leaving</label>
                            <asp:Label runat="server" ID="txtReasonForLeaving1" CssClass="form-control"  placeholder="Reason for leaving this organization"></asp:Label>
                        </div>
                    </div>

                    <div class="col-md-6">
                        <div class="form-group">
                            <label>May we contact your previous supervisor for a reference?</label>
                            <asp:Label runat="server" ID="lblContactSV1" CssClass="form-control"></asp:Label>
                        </div>
                    </div>

                    <div class="col-md-12">
                    </div>
                    <div class="col-md-12">
                        <div class="form-group">
                            <h3>Previous Company Detail 2</h3>

                        </div>
                    </div>
                    <div class="col-md-6">
                        <div class="form-group">
                            <label>Company Name</label>
                            <asp:Label runat="server" ID="txtCompanyName2" CssClass="form-control"  placeholder="Company Name"></asp:Label>
                        </div>
                    </div>
                    <div class="col-md-6">
                        <div class="form-group">
                            <label>Phone</label>
                            <asp:Label runat="server" ID="txtCompanyPhone2" CssClass="form-control"  placeholder="Company Phone No"></asp:Label>
                        </div>
                    </div>

                    <div class="col-md-12">
                        <div class="form-group">
                            <label>Address</label>
                            <asp:Label runat="server" ID="txtCompanyAddress2" CssClass="form-control"  placeholder="Company Address"></asp:Label>
                        </div>
                    </div>

                    <div class="col-md-12">
                        <div class="form-group">
                            <label>Supervisor</label>
                            <asp:Label runat="server" ID="txtCompanySupervisor2" CssClass="form-control"  placeholder="Company Supervisor Name"></asp:Label>
                        </div>
                    </div>

                    <div class="col-md-6">
                        <div class="form-group">
                            <label>Job Title</label>
                            <asp:Label runat="server" ID="txtJobTitle2" CssClass="form-control"  placeholder="Relationship with reference"></asp:Label>
                        </div>
                    </div>

                    <div class="col-md-6">
                        <div class="form-group">
                            <label>Starting Salary</label>
                            <asp:Label runat="server" ID="txtStartingSalary2" CssClass="form-control"  placeholder="Starting Salary in USD"></asp:Label>
                        </div>
                    </div>

                    <div class="col-md-6">
                        <div class="form-group">
                            <label>Ending Salary</label>
                            <asp:Label runat="server" ID="txtEndingSalary2" CssClass="form-control"  placeholder="Ending Salary in USD"></asp:Label>
                        </div>
                    </div>

                    <div class="col-md-6">
                        <div class="form-group">
                            <label>Responsibilities</label>
                            <asp:Label runat="server" ID="txtResponsibility2" CssClass="form-control"  placeholder="Responsibilities"></asp:Label>
                        </div>
                    </div>

                    <div class="col-md-6">
                        <div class="form-group">
                            <label>From</label>
                            <asp:Label runat="server" ID="txtCompanyFrom2" CssClass="form-control"  placeholder="From (Which Year)"></asp:Label>
                        </div>
                    </div>
                    <div class="col-md-6">
                        <div class="form-group">
                            <label>To</label>
                            <asp:Label runat="server" ID="txtCompanyTo2" CssClass="form-control"  placeholder="To (Which Year)"></asp:Label>
                        </div>
                    </div>

                    <div class="col-md-6">
                        <div class="form-group">
                            <label>Reason For Leaving</label>
                            <asp:Label runat="server" ID="txtReasonForLeaving2" CssClass="form-control"  placeholder="Reason for leaving this organization"></asp:Label>
                        </div>
                    </div>

                    <div class="col-md-6">
                        <div class="form-group">
                            <label>May we contact your previous supervisor for a reference?</label>
                          <asp:Label runat="server" ID="lblContactSV2" CssClass="form-control"></asp:Label>
                        </div>
                    </div>

                    <div class="col-md-12">
                    </div>
                    <div class="col-md-12">
                        <div class="form-group">
                            <h3>Previous Company Detail 3</h3>

                        </div>
                    </div>
                    <div class="col-md-6">
                        <div class="form-group">
                            <label>Company Name</label>
                            <asp:Label runat="server" ID="txtCompanyName3" CssClass="form-control"  placeholder="Company Name"></asp:Label>
                        </div>
                    </div>
                    <div class="col-md-6">
                        <div class="form-group">
                            <label>Phone</label>
                            <asp:Label runat="server" ID="txtCompanyPhone3" CssClass="form-control"  placeholder="Company Phone No"></asp:Label>
                        </div>
                    </div>

                    <div class="col-md-12">
                        <div class="form-group">
                            <label>Address</label>
                            <asp:Label runat="server" ID="txtCompanyAddress3" CssClass="form-control"  placeholder="Company Address"></asp:Label>
                        </div>
                    </div>

                    <div class="col-md-12">
                        <div class="form-group">
                            <label>Supervisor</label>
                            <asp:Label runat="server" ID="txtSupervisor3" CssClass="form-control"  placeholder="Company Supervisor Name"></asp:Label>
                        </div>
                    </div>

                    <div class="col-md-6">
                        <div class="form-group">
                            <label>Job Title</label>
                            <asp:Label runat="server" ID="txtJobTitle3" CssClass="form-control"  placeholder="Relationship with reference"></asp:Label>
                        </div>
                    </div>

                    <div class="col-md-6">
                        <div class="form-group">
                            <label>Starting Salary</label>
                            <asp:Label runat="server" ID="txtStartingSalary3" CssClass="form-control"  placeholder="Starting Salary in USD"></asp:Label>
                        </div>
                    </div>

                    <div class="col-md-6">
                        <div class="form-group">
                            <label>Ending Salary</label>
                            <asp:Label runat="server" ID="txtEndingSalary3" CssClass="form-control"  placeholder="Ending Salary in USD"></asp:Label>
                        </div>
                    </div>

                    <div class="col-md-6">
                        <div class="form-group">
                            <label>Responsibilities</label>
                            <asp:Label runat="server" ID="txtResponsibilities3" CssClass="form-control"  placeholder="Responsibilities"></asp:Label>
                        </div>
                    </div>

                    <div class="col-md-6">
                        <div class="form-group">
                            <label>From</label>
                            <asp:Label runat="server" ID="txtCompanyFrom3" CssClass="form-control"  placeholder="From (Which Year)"></asp:Label>
                        </div>
                    </div>
                    <div class="col-md-6">
                        <div class="form-group">
                            <label>To</label>
                            <asp:Label runat="server" ID="txtCompanyTo3" CssClass="form-control"  placeholder="To (Which Year)"></asp:Label>
                        </div>
                    </div>

                    <div class="col-md-6">
                        <div class="form-group">
                            <label>Reason For Leaving</label>
                            <asp:Label runat="server" ID="txtReasonForLeaving3" CssClass="form-control"  placeholder="Reason for leaving this organization"></asp:Label>
                        </div>
                    </div>

                    <div class="col-md-6">
                        <div class="form-group">
                            <label>May we contact your previous supervisor for a reference?</label>
                           <asp:Label runat="server" ID="lblContactSV3" CssClass="form-control"></asp:Label>
                        </div>
                    </div>
                        </div>
                        <!-- /.row -->
                    </div>
                    <!-- /.box-body -->

                </div>
                <!-- /.box -->


            </section>

            <section class="content">

                <!-- SELECT2 EXAMPLE -->
                <div class="box box-default">
                    <div class="box-header with-border">
                        <h3 class="box-title">Military Services</h3>

                        <div class="box-tools pull-right">
                            <button type="button" class="btn btn-box-tool" data-widget="collapse"><i class="fa fa-minus"></i></button>
                        </div>
                    </div>
                    <!-- /.box-header -->
                    <div class="box-body">
                        <div class="row">
                            
                        <div class="col-md-6">
                            <div class="form-group">
                                <label>Branch</label>
                                <asp:Label runat="server" ID="txtBranch" CssClass="form-control"  placeholder="Branch"></asp:Label>
                            </div>
                        </div>

                        <div class="col-md-6">
                            <div class="form-group">
                                <label>From</label>
                                <asp:Label runat="server" ID="txtMilitaryFrom" CssClass="form-control"  placeholder="From (Which Year)"></asp:Label>
                            </div>
                        </div>
                        <div class="col-md-6">
                            <div class="form-group">
                                <label>To</label>
                                <asp:Label runat="server" ID="txtMilitaryTo" CssClass="form-control"  placeholder="To (Which Year)"></asp:Label>
                            </div>
                        </div>

                        <div class="col-md-6">
                            <div class="form-group">
                                <label>Rank at Discharge</label>
                                <asp:Label runat="server" ID="txtRankAtDischarge" CssClass="form-control"  placeholder="Rank of Discharge"></asp:Label>
                            </div>
                        </div>
                        <div class="col-md-6">
                            <div class="form-group">
                                <label>Type of Discharge</label>
                                <asp:Label runat="server" ID="txtTypeOfDischarge" CssClass="form-control"  placeholder="Type of Discharge"></asp:Label>
                            </div>
                        </div>
                        <div class="col-md-12">
                            <div class="form-group">
                                <label>If other than honorable, explain</label>
                                <asp:Label runat="server" ID="txtMilitaryExplain" CssClass="form-control"  placeholder="Explanation"></asp:Label>
                            </div>
                        </div>
                        </div>
                        <!-- /.row -->
                    </div>
                    <!-- /.box-body -->

                </div>
                <!-- /.box -->


            </section>
        </div>

    </div>

</asp:Content>
