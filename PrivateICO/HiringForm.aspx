<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="HiringForm.aspx.cs" Inherits="PrivateICO.HiringForm" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta charset="utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <!-- Tell the browser to be responsive to screen width -->
    <meta content="width=device-width, initial-scale=1, maximum-scale=1, user-scalable=no" name="viewport" />
    <!-- Bootstrap 3.3.6 -->
    <link rel="stylesheet" href="bootstrap/css/bootstrap.min.css" />
    <link href="Content/steps.css" rel="stylesheet" />
    <script src="Scripts/jquery-1.10.2.js"></script>
    <script src="Scripts/bootstrap.min.js"></script>
    <script src="Scripts/steps.js"></script>
    <title>Purcell Compliances Hiring Form</title>
    <!-- Font Awesome -->
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.5.0/css/font-awesome.min.css" />
    <!-- Ionicons -->
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/ionicons/2.0.1/css/ionicons.min.css" />
    <!-- Theme style -->
    <link rel="stylesheet" href="dist/css/AdminLTE.min.css" />
    <!-- AdminLTE Skins. Choose a skin from the css/skins
       folder instead of downloading all of them to reduce the load. -->
    <link rel="stylesheet" href="dist/css/skins/_all-skins.min.css" />
    <style>
        label {
    display: inline-block;
    max-width: 100%;
    margin-bottom: 5px;
    font-weight: 700;
    color:black;
}
    </style>
</head>
<body class="hold-transition skin-blue sidebar-mini"   style="background-color: #dfe2e6;">
    <div class="container">

        <div class="stepwizard col-md-offset-3">
            <div class="stepwizard-row setup-panel">
                <div class="stepwizard-step">
                    <a href="#step-1" type="button" class="btn btn-primary btn-circle">1</a>
                    <p>Applicant Info</p>
                </div>
                <div class="stepwizard-step">
                    <a href="#step-2" type="button" class="btn btn-default btn-circle" disabled="disabled">2</a>
                    <p>Education</p>
                </div>
                <div class="stepwizard-step">
                    <a href="#step-3" type="button" class="btn btn-default btn-circle" disabled="disabled">3</a>
                    <p>Reference</p>
                </div>

                <div class="stepwizard-step">
                    <a href="#step-4" type="button" class="btn btn-default btn-circle" disabled="disabled">4</a>
                    <p>Employment</p>
                </div>

                <div class="stepwizard-step">
                    <a href="#step-5" type="button" class="btn btn-default btn-circle" disabled="disabled">5</a>
                    <p>Military Service</p>
                </div>

                <div class="stepwizard-step">
                    <a href="#step-6" type="button" class="btn btn-default btn-circle" disabled="disabled">6</a>
                    <p>Signature</p>
                </div>
            </div>
        </div>
        <form id="form1" runat="server">

            <div class="row setup-content" id="step-1">
                <div class="col-xs-6 col-md-offset-3">
                    <h3>Applicant Information</h3>

                    <div class="col-md-12">
                        <div class="form-group">
                            <label>Upload your resume*<p style="color:red;background-color:black;">&nbsp;(Uploading Resume is mandatory)</p></label>
                            <asp:FileUpload runat="server" ID="flResume" CssClass="form-control" />
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="flResume" ForeColor="Red" ErrorMessage="Please select a .pdf or .doc file" ValidationExpression="^([a-zA-Z].*|[1-9].*)\.(((p|P)(d|D)(f|F))|((d|D)(o|O)(c|C))|((d|D)(o|O)(c|C)(x|X)))$"></asp:RegularExpressionValidator>
                        </div>
                    </div>


                    <div class="col-md-6">
                        <div class="form-group">
                            <label>Last Name*</label>
                            <asp:TextBox runat="server" ID="txtLastName" CssClass="form-control" required placeholder="Last Name"></asp:TextBox>
                        </div>
                    </div>

                    <div class="col-md-6">
                        <div class="form-group">
                            <label>First Name*</label>
                            <asp:TextBox runat="server" ID="txtFirstName" CssClass="form-control" required placeholder="First Name"></asp:TextBox>
                        </div>
                    </div>

                    <div class="col-md-6">
                        <div class="form-group">
                            <label>Middle Name</label>
                            <asp:TextBox runat="server" ID="txtMiddleName" CssClass="form-control" placeholder="Middle Name"></asp:TextBox>
                        </div>
                    </div>

                    <div class="col-md-12">
                        <div class="form-group">
                            <label>Street Address*</label>
                            <asp:TextBox runat="server" ID="txtStreetAddress" CssClass="form-control" required placeholder="Street Address"></asp:TextBox>
                        </div>
                    </div>

                    <div class="col-md-6">
                        <div class="form-group">
                            <label>Apartment/Unit# </label>
                            <asp:TextBox runat="server" ID="txtApartmentUnitNo" CssClass="form-control" placeholder="Apartment Unit"></asp:TextBox>
                        </div>
                    </div>

                    <div class="col-md-6">
                        <div class="form-group">
                            <label>City* </label>
                            <asp:TextBox runat="server" ID="txtCity" CssClass="form-control" required placeholder="City"></asp:TextBox>
                        </div>
                    </div>

                    <div class="col-md-6">
                        <div class="form-group">
                            <label>State* </label>
                            <asp:TextBox runat="server" ID="txtState" CssClass="form-control" required placeholder="State"></asp:TextBox>
                        </div>
                    </div>

                    <div class="col-md-6">
                        <div class="form-group">
                            <label>Zip Code* </label>
                            <asp:TextBox runat="server" ID="txtZipCode" CssClass="form-control" required placeholder="Zip Code"></asp:TextBox>
                        </div>
                    </div>

                    <div class="col-md-6">
                        <div class="form-group">
                            <label>Phone*</label>
                            <asp:TextBox runat="server" ID="txtPhone" CssClass="form-control" required placeholder="Phone No."></asp:TextBox>
                        </div>
                    </div>

                    <div class="col-md-6">
                        <div class="form-group">
                            <label>Email*</label>
                            <asp:TextBox runat="server" ID="txtEmail" CssClass="form-control" required placeholder="Email"></asp:TextBox>
                        </div>
                    </div>

                    <div class="col-md-6">
                        <div class="form-group">
                            <label>Date Available*</label>
                            <asp:TextBox runat="server" ID="txtDateAvailable" CssClass="form-control" required placeholder="Availability Date"></asp:TextBox>
                        </div>
                    </div>

                    <div class="col-md-6">
                        <div class="form-group">
                            <label>Social Security No*</label>
                            <asp:TextBox runat="server" ID="txtSSN" CssClass="form-control" placeholder="Social Security#"></asp:TextBox>
                        </div>
                    </div>

                    <div class="col-md-6">
                        <div class="form-group">
                            <label>Desired Income*</label>
                            <asp:TextBox runat="server" ID="txtDesiredIncome" CssClass="form-control" required placeholder="In USD"></asp:TextBox>
                        </div>
                    </div>

                    <div class="col-md-6">
                        <div class="form-group">
                            <label>Position Applied For*</label>
                            <asp:DropDownList runat="server" ID="ddlPositions" CssClass="form-control">
                                <asp:ListItem>Sales</asp:ListItem>
                                <asp:ListItem>Admin</asp:ListItem>
                                <asp:ListItem>Compliance Supervisor/Sales</asp:ListItem>
                                <asp:ListItem>Administration</asp:ListItem>
                                <asp:ListItem>Receptionist</asp:ListItem>
                                <asp:ListItem>Sales Manager</asp:ListItem>
                                <asp:ListItem>Clerical Administration</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                    </div>

                    <div class="col-md-6">
                        <div class="form-group">
                            <label>Are you the citizen of United States ?</label>
                            <asp:RadioButtonList ID="radioUSCitizen" runat="server">
                                <asp:ListItem Text="Yes" Value="1"></asp:ListItem>
                                <asp:ListItem Text="No" Value="0"></asp:ListItem>
                            </asp:RadioButtonList>
                        </div>
                    </div>

                    <div class="col-md-6">
                        <div class="form-group">
                            <label>Are you authorized to work in United States ?</label>
                            <asp:RadioButtonList ID="radioAuthorizedForWork" runat="server">
                                <asp:ListItem Text="Yes" Value="1"></asp:ListItem>
                                <asp:ListItem Text="No" Value="0"></asp:ListItem>
                            </asp:RadioButtonList>
                        </div>
                    </div>

                    <div class="col-md-6">
                        <div class="form-group">
                            <label>Have you worked for this company ?</label>
                            <asp:RadioButtonList ID="radioWorkedForThisCompany" runat="server">
                                <asp:ListItem Text="Yes" Value="1"></asp:ListItem>
                                <asp:ListItem Text="No" Value="0"></asp:ListItem>
                            </asp:RadioButtonList>
                        </div>
                    </div>

                    <div class="col-md-6">
                        <div class="form-group">
                            <label>If Yes, When?</label>
                            <asp:TextBox runat="server" ID="txtWorkedForCompany" CssClass="form-control" placeholder="When you have worked ?"></asp:TextBox>
                        </div>
                    </div>

                    <div class="col-md-6">
                        <div class="form-group">
                            <label>Have you ever been convicted of a felony ?</label>
                            <asp:RadioButtonList ID="radioFelony" runat="server">
                                <asp:ListItem Text="Yes" Value="1"></asp:ListItem>
                                <asp:ListItem Text="No" Value="0"></asp:ListItem>
                            </asp:RadioButtonList>
                        </div>
                    </div>

                    <div class="col-md-12">
                        <div class="form-group">
                            <label>If yes,explain</label>
                            <asp:TextBox runat="server" ID="txtExplainFelony" CssClass="form-control" placeholder="Explain Felony"></asp:TextBox>
                        </div>
                        <button class="btn btn-primary nextBtn btn-lg pull-right" type="button">Next</button>
                    </div>

                </div>
            </div>
            <div class="row setup-content" id="step-2">
                <div class="col-xs-6 col-md-offset-3">
                    <div class="col-md-12">
                        <h3>Education</h3>
                        <div class="col-md-6">
                            <div class="form-group">
                                <label>Highschool</label>
                                <asp:TextBox runat="server" ID="txtHighSchool" CssClass="form-control" placeholder="HighSchool"></asp:TextBox>
                            </div>
                        </div>
                        <div class="col-md-6">
                            <div class="form-group">
                                <label>Address</label>
                                <asp:TextBox runat="server" ID="txtHighSchoolAddress" CssClass="form-control" placeholder="HighSchool Address"></asp:TextBox>
                            </div>
                        </div>

                        <div class="col-md-6">
                            <div class="form-group">
                                <label>From</label>
                                <asp:TextBox runat="server" ID="txtFrom1" CssClass="form-control" placeholder="From (Which Year)"></asp:TextBox>
                            </div>
                        </div>
                        <div class="col-md-6">
                            <div class="form-group">
                                <label>To</label>
                                <asp:TextBox runat="server" ID="txtTo1" CssClass="form-control" placeholder="To (Which Year)"></asp:TextBox>
                            </div>
                        </div>

                        <div class="col-md-6">
                            <div class="form-group">
                                <label>Did you graduated ?</label>
                                <asp:RadioButtonList ID="radioGraduated1" runat="server">
                                    <asp:ListItem Text="Yes" Value="1"></asp:ListItem>
                                    <asp:ListItem Text="No" Value="0"></asp:ListItem>
                                </asp:RadioButtonList>
                            </div>
                        </div>

                        <div class="col-md-6">
                            <div class="form-group">
                                <label>Diploma</label>
                                <asp:TextBox runat="server" ID="txtDiploma1" CssClass="form-control" placeholder="Diploma Details"></asp:TextBox>
                            </div>
                        </div>
                        <div class="col-md-6">
                            <div class="form-group">
                                <label>College</label>
                                <asp:TextBox runat="server" ID="txtCollege1" CssClass="form-control" placeholder="College Details"></asp:TextBox>
                            </div>
                        </div>
                        <div class="col-md-12">
                            <div class="form-group">
                                <label>Address</label>
                                <asp:TextBox runat="server" ID="txtCollegeAddress1" CssClass="form-control" placeholder="College Address"></asp:TextBox>
                            </div>
                        </div>



                        <div class="col-md-6">
                            <div class="form-group">
                                <label>From</label>
                                <asp:TextBox runat="server" ID="txtFrom2" CssClass="form-control" placeholder="From (Which Year)"></asp:TextBox>
                            </div>
                        </div>
                        <div class="col-md-6">
                            <div class="form-group">
                                <label>To</label>
                                <asp:TextBox runat="server" ID="txtTo2" CssClass="form-control" placeholder="To (Which Year)"></asp:TextBox>
                            </div>
                        </div>

                        <div class="col-md-6">
                            <div class="form-group">
                                <label>Did you graduated ?</label>
                                <asp:RadioButtonList ID="radioGraduated2" runat="server">
                                    <asp:ListItem Text="Yes" Value="1"></asp:ListItem>
                                    <asp:ListItem Text="No" Value="0"></asp:ListItem>
                                </asp:RadioButtonList>
                            </div>
                        </div>
                        <div class="col-md-6">
                            <div class="form-group">
                                <label>Deegre</label>
                                <asp:TextBox runat="server" ID="txtDeegre" CssClass="form-control" placeholder="Deegre Details"></asp:TextBox>
                            </div>
                        </div>
                        <div class="col-md-6">
                            <div class="form-group">
                                <label>Other</label>
                                <asp:TextBox runat="server" ID="txtOther" CssClass="form-control" placeholder="Other Details"></asp:TextBox>
                            </div>
                        </div>

                        <div class="col-md-12">
                            <div class="form-group">
                                <label>Address</label>
                                <asp:TextBox runat="server" ID="txtDeegreAddress" CssClass="form-control" placeholder="College Address"></asp:TextBox>
                            </div>
                        </div>

                        <div class="col-md-6">
                            <div class="form-group">
                                <label>From</label>
                                <asp:TextBox runat="server" ID="txtFrom3" CssClass="form-control" placeholder="From (Which Year)"></asp:TextBox>
                            </div>
                        </div>
                        <div class="col-md-6">
                            <div class="form-group">
                                <label>To</label>
                                <asp:TextBox runat="server" ID="txtTo3" CssClass="form-control" placeholder="To (Which Year)"></asp:TextBox>
                            </div>
                        </div>

                        <div class="col-md-6">
                            <div class="form-group">
                                <label>Did you graduated ?</label>
                                <asp:RadioButtonList ID="radioGraduated3" runat="server">
                                    <asp:ListItem Text="Yes" Value="1"></asp:ListItem>
                                    <asp:ListItem Text="No" Value="0"></asp:ListItem>
                                </asp:RadioButtonList>
                            </div>
                        </div>
                        <div class="col-md-6">
                            <div class="form-group">
                                <label>Deegre</label>
                                <asp:TextBox runat="server" ID="txtDeegre2" CssClass="form-control" placeholder="Deegre Details"></asp:TextBox>
                            </div>
                        </div>

                        <button class="btn btn-primary nextBtn btn-lg pull-right" type="button">Next</button>
                    </div>
                </div>
            </div>
            <div class="row setup-content" id="step-3">
                <div class="col-xs-6 col-md-offset-3">
                    <div class="col-md-12">
                        <h3>References</h3>

                        <div class="col-md-12">
                            <div class="form-group">
                                <h3>Reference 1</h3>

                            </div>
                        </div>
                        <div class="col-md-6">
                            <div class="form-group">
                                <label>Full Name</label>
                                <asp:TextBox runat="server" ID="txtFullReferenceName" CssClass="form-control" placeholder="Full Name"></asp:TextBox>
                            </div>
                        </div>

                        <div class="col-md-6">
                            <div class="form-group">
                                <label>Relationship</label>
                                <asp:TextBox runat="server" ID="txtRelationship" CssClass="form-control" placeholder="Relationship with reference"></asp:TextBox>
                            </div>
                        </div>

                        <div class="col-md-6">
                            <div class="form-group">
                                <label>Company</label>
                                <asp:TextBox runat="server" ID="txtReferenceCompanyName" CssClass="form-control" placeholder="Company Name"></asp:TextBox>
                            </div>
                        </div>
                        <div class="col-md-6">
                            <div class="form-group">
                                <label>Phone</label>
                                <asp:TextBox runat="server" ID="txtReferencePhoneNo" CssClass="form-control" placeholder="Phone No"></asp:TextBox>
                            </div>
                        </div>
                        <div class="col-md-12">
                            <div class="form-group">
                                <label>Address</label>
                                <asp:TextBox runat="server" ID="txtReferenceAddress" CssClass="form-control" placeholder="Address"></asp:TextBox>
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
                                <asp:TextBox runat="server" ID="txtFullReferenceName2" CssClass="form-control" placeholder="Full Name"></asp:TextBox>
                            </div>
                        </div>

                        <div class="col-md-6">
                            <div class="form-group">
                                <label>Relationship</label>
                                <asp:TextBox runat="server" ID="txtRelationship2" CssClass="form-control" placeholder="Relationship with reference"></asp:TextBox>
                            </div>
                        </div>

                        <div class="col-md-6">
                            <div class="form-group">
                                <label>Company</label>
                                <asp:TextBox runat="server" ID="txtReferenceCompanyName2" CssClass="form-control" placeholder="Company Name"></asp:TextBox>
                            </div>
                        </div>
                        <div class="col-md-6">
                            <div class="form-group">
                                <label>Phone</label>
                                <asp:TextBox runat="server" ID="txtReferencePhoneNo2" CssClass="form-control" placeholder="Phone No"></asp:TextBox>
                            </div>
                        </div>
                        <div class="col-md-12">
                            <div class="form-group">
                                <label>Address</label>
                                <asp:TextBox runat="server" ID="txtReferenceAddress2" CssClass="form-control" placeholder="Address"></asp:TextBox>
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
                                <asp:TextBox runat="server" ID="txtFullReferenceName3" CssClass="form-control" placeholder="Full Name"></asp:TextBox>
                            </div>
                        </div>

                        <div class="col-md-6">
                            <div class="form-group">
                                <label>Relationship</label>
                                <asp:TextBox runat="server" ID="txtRelationship3" CssClass="form-control" placeholder="Relationship with reference"></asp:TextBox>
                            </div>
                        </div>

                        <div class="col-md-6">
                            <div class="form-group">
                                <label>Company</label>
                                <asp:TextBox runat="server" ID="txtReferenceCompanyName3" CssClass="form-control" placeholder="Company Name"></asp:TextBox>
                            </div>
                        </div>
                        <div class="col-md-6">
                            <div class="form-group">
                                <label>Phone</label>
                                <asp:TextBox runat="server" ID="txtReferencePhoneNo3" CssClass="form-control" placeholder="Phone No"></asp:TextBox>
                            </div>
                        </div>
                        <div class="col-md-12">
                            <div class="form-group">
                                <label>Address</label>
                                <asp:TextBox runat="server" ID="txtReferenceAddress3" CssClass="form-control" placeholder="Address"></asp:TextBox>
                            </div>
                        </div>

                        <button class="btn btn-primary nextBtn btn-lg pull-right" type="button">Next</button>
                    </div>
                </div>
            </div>
            <div class="row setup-content" id="step-4">
                <div class="col-xs-6 col-md-offset-3">
                    <div class="col-md-12">
                        <h3>Two Years Employment</h3>
                    </div>
                    <div class="col-md-12">
                        <div class="form-group">
                            <h3>Previous Company Detail 1</h3>

                        </div>
                    </div>
                    <div class="col-md-6">
                        <div class="form-group">
                            <label>Company Name</label>
                            <asp:TextBox runat="server" ID="txtCompanyName1" CssClass="form-control" placeholder="Company Name"></asp:TextBox>
                        </div>
                    </div>
                    <div class="col-md-6">
                        <div class="form-group">
                            <label>Phone</label>
                            <asp:TextBox runat="server" ID="txtCompanyPhone1" CssClass="form-control" placeholder="Company Phone No"></asp:TextBox>
                        </div>
                    </div>

                    <div class="col-md-12">
                        <div class="form-group">
                            <label>Address</label>
                            <asp:TextBox runat="server" ID="txtCompanyAddress1" CssClass="form-control" placeholder="Company Address"></asp:TextBox>
                        </div>
                    </div>

                    <div class="col-md-12">
                        <div class="form-group">
                            <label>Supervisor</label>
                            <asp:TextBox runat="server" ID="txtCompanySupervisor1" CssClass="form-control" placeholder="Company Supervisor Name"></asp:TextBox>
                        </div>
                    </div>

                    <div class="col-md-6">
                        <div class="form-group">
                            <label>Job Title</label>
                            <asp:TextBox runat="server" ID="txtJobTitle" CssClass="form-control" placeholder="Relationship with reference"></asp:TextBox>
                        </div>
                    </div>

                    <div class="col-md-6">
                        <div class="form-group">
                            <label>Starting Salary</label>
                            <asp:TextBox runat="server" ID="txtStartingSalary" CssClass="form-control" placeholder="Starting Salary in USD"></asp:TextBox>
                        </div>
                    </div>

                    <div class="col-md-6">
                        <div class="form-group">
                            <label>Ending Salary</label>
                            <asp:TextBox runat="server" ID="txtEndingSalary" CssClass="form-control" placeholder="Ending Salary in USD"></asp:TextBox>
                        </div>
                    </div>

                    <div class="col-md-6">
                        <div class="form-group">
                            <label>Responsibilities</label>
                            <asp:TextBox runat="server" ID="txtResponsibility" CssClass="form-control" placeholder="Responsibilities"></asp:TextBox>
                        </div>
                    </div>

                    <div class="col-md-6">
                        <div class="form-group">
                            <label>From</label>
                            <asp:TextBox runat="server" ID="txtCompanyFrom1" CssClass="form-control" placeholder="From (Which Year)"></asp:TextBox>
                        </div>
                    </div>
                    <div class="col-md-6">
                        <div class="form-group">
                            <label>To</label>
                            <asp:TextBox runat="server" ID="txtCompanyTo1" CssClass="form-control" placeholder="To (Which Year)"></asp:TextBox>
                        </div>
                    </div>

                    <div class="col-md-6">
                        <div class="form-group">
                            <label>Reason For Leaving</label>
                            <asp:TextBox runat="server" ID="txtReasonForLeaving1" CssClass="form-control" placeholder="Reason for leaving this organization"></asp:TextBox>
                        </div>
                    </div>

                    <div class="col-md-6">
                        <div class="form-group">
                            <label>May we contact your previous supervisor for a reference?</label>
                            <asp:RadioButtonList ID="radioContactToCompany1" runat="server">
                                <asp:ListItem Text="Yes" Value="1"></asp:ListItem>
                                <asp:ListItem Text="No" Value="0"></asp:ListItem>
                            </asp:RadioButtonList>
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
                            <asp:TextBox runat="server" ID="txtCompanyName2" CssClass="form-control" placeholder="Company Name"></asp:TextBox>
                        </div>
                    </div>
                    <div class="col-md-6">
                        <div class="form-group">
                            <label>Phone</label>
                            <asp:TextBox runat="server" ID="txtCompanyPhone2" CssClass="form-control" placeholder="Company Phone No"></asp:TextBox>
                        </div>
                    </div>

                    <div class="col-md-12">
                        <div class="form-group">
                            <label>Address</label>
                            <asp:TextBox runat="server" ID="txtCompanyAddress2" CssClass="form-control" placeholder="Company Address"></asp:TextBox>
                        </div>
                    </div>

                    <div class="col-md-12">
                        <div class="form-group">
                            <label>Supervisor</label>
                            <asp:TextBox runat="server" ID="txtCompanySupervisor2" CssClass="form-control" placeholder="Company Supervisor Name"></asp:TextBox>
                        </div>
                    </div>

                    <div class="col-md-6">
                        <div class="form-group">
                            <label>Job Title</label>
                            <asp:TextBox runat="server" ID="txtJobTitle2" CssClass="form-control" placeholder="Relationship with reference"></asp:TextBox>
                        </div>
                    </div>

                    <div class="col-md-6">
                        <div class="form-group">
                            <label>Starting Salary</label>
                            <asp:TextBox runat="server" ID="txtStartingSalary2" CssClass="form-control" placeholder="Starting Salary in USD"></asp:TextBox>
                        </div>
                    </div>

                    <div class="col-md-6">
                        <div class="form-group">
                            <label>Ending Salary</label>
                            <asp:TextBox runat="server" ID="txtEndingSalary2" CssClass="form-control" placeholder="Ending Salary in USD"></asp:TextBox>
                        </div>
                    </div>

                    <div class="col-md-6">
                        <div class="form-group">
                            <label>Responsibilities</label>
                            <asp:TextBox runat="server" ID="txtResponsibility2" CssClass="form-control" placeholder="Responsibilities"></asp:TextBox>
                        </div>
                    </div>

                    <div class="col-md-6">
                        <div class="form-group">
                            <label>From</label>
                            <asp:TextBox runat="server" ID="txtCompanyFrom2" CssClass="form-control" placeholder="From (Which Year)"></asp:TextBox>
                        </div>
                    </div>
                    <div class="col-md-6">
                        <div class="form-group">
                            <label>To</label>
                            <asp:TextBox runat="server" ID="txtCompanyTo2" CssClass="form-control" placeholder="To (Which Year)"></asp:TextBox>
                        </div>
                    </div>

                    <div class="col-md-6">
                        <div class="form-group">
                            <label>Reason For Leaving</label>
                            <asp:TextBox runat="server" ID="txtReasonForLeaving2" CssClass="form-control" placeholder="Reason for leaving this organization"></asp:TextBox>
                        </div>
                    </div>

                    <div class="col-md-6">
                        <div class="form-group">
                            <label>May we contact your previous supervisor for a reference?</label>
                            <asp:RadioButtonList ID="radioContactToCompany2" runat="server">
                                <asp:ListItem Text="Yes" Value="1"></asp:ListItem>
                                <asp:ListItem Text="No" Value="0"></asp:ListItem>
                            </asp:RadioButtonList>
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
                            <asp:TextBox runat="server" ID="txtCompanyName3" CssClass="form-control" placeholder="Company Name"></asp:TextBox>
                        </div>
                    </div>
                    <div class="col-md-6">
                        <div class="form-group">
                            <label>Phone</label>
                            <asp:TextBox runat="server" ID="txtCompanyPhone3" CssClass="form-control" placeholder="Company Phone No"></asp:TextBox>
                        </div>
                    </div>

                    <div class="col-md-12">
                        <div class="form-group">
                            <label>Address</label>
                            <asp:TextBox runat="server" ID="txtCompanyAddress3" CssClass="form-control" placeholder="Company Address"></asp:TextBox>
                        </div>
                    </div>

                    <div class="col-md-12">
                        <div class="form-group">
                            <label>Supervisor</label>
                            <asp:TextBox runat="server" ID="txtSupervisor3" CssClass="form-control" placeholder="Company Supervisor Name"></asp:TextBox>
                        </div>
                    </div>

                    <div class="col-md-6">
                        <div class="form-group">
                            <label>Job Title</label>
                            <asp:TextBox runat="server" ID="txtJobTitle3" CssClass="form-control" placeholder="Relationship with reference"></asp:TextBox>
                        </div>
                    </div>

                    <div class="col-md-6">
                        <div class="form-group">
                            <label>Starting Salary</label>
                            <asp:TextBox runat="server" ID="txtStartingSalary3" CssClass="form-control" placeholder="Starting Salary in USD"></asp:TextBox>
                        </div>
                    </div>

                    <div class="col-md-6">
                        <div class="form-group">
                            <label>Ending Salary</label>
                            <asp:TextBox runat="server" ID="txtEndingSalary3" CssClass="form-control" placeholder="Ending Salary in USD"></asp:TextBox>
                        </div>
                    </div>

                    <div class="col-md-6">
                        <div class="form-group">
                            <label>Responsibilities</label>
                            <asp:TextBox runat="server" ID="txtResponsibilities3" CssClass="form-control" placeholder="Responsibilities"></asp:TextBox>
                        </div>
                    </div>

                    <div class="col-md-6">
                        <div class="form-group">
                            <label>From</label>
                            <asp:TextBox runat="server" ID="txtCompanyFrom3" CssClass="form-control" placeholder="From (Which Year)"></asp:TextBox>
                        </div>
                    </div>
                    <div class="col-md-6">
                        <div class="form-group">
                            <label>To</label>
                            <asp:TextBox runat="server" ID="txtCompanyTo3" CssClass="form-control" placeholder="To (Which Year)"></asp:TextBox>
                        </div>
                    </div>

                    <div class="col-md-6">
                        <div class="form-group">
                            <label>Reason For Leaving</label>
                            <asp:TextBox runat="server" ID="txtReasonForLeaving3" CssClass="form-control" placeholder="Reason for leaving this organization"></asp:TextBox>
                        </div>
                    </div>

                    <div class="col-md-6">
                        <div class="form-group">
                            <label>May we contact your previous supervisor for a reference?</label>
                            <asp:RadioButtonList ID="radioContactToCompany3" runat="server">
                                <asp:ListItem Text="Yes" Value="1"></asp:ListItem>
                                <asp:ListItem Text="No" Value="0"></asp:ListItem>
                            </asp:RadioButtonList>
                        </div>
                    </div>

                    <button class="btn btn-primary nextBtn btn-lg pull-right" type="button">Next</button>

                </div>
            </div>

            <div class="row setup-content" id="step-5">
                <div class="col-xs-6 col-md-offset-3">
                    <div class="col-md-12">
                        <h3>Military Service</h3>
                        <div class="col-md-6">
                            <div class="form-group">
                                <label>Branch</label>
                                <asp:TextBox runat="server" ID="txtBranch" CssClass="form-control" placeholder="Branch"></asp:TextBox>
                            </div>
                        </div>

                        <div class="col-md-6">
                            <div class="form-group">
                                <label>From</label>
                                <asp:TextBox runat="server" ID="txtMilitaryFrom" CssClass="form-control" placeholder="From (Which Year)"></asp:TextBox>
                            </div>
                        </div>
                        <div class="col-md-6">
                            <div class="form-group">
                                <label>To</label>
                                <asp:TextBox runat="server" ID="txtMilitaryTo" CssClass="form-control" placeholder="To (Which Year)"></asp:TextBox>
                            </div>
                        </div>

                        <div class="col-md-6">
                            <div class="form-group">
                                <label>Rank at Discharge</label>
                                <asp:TextBox runat="server" ID="txtRankAtDischarge" CssClass="form-control" placeholder="Rank of Discharge"></asp:TextBox>
                            </div>
                        </div>
                        <div class="col-md-6">
                            <div class="form-group">
                                <label>Type of Discharge</label>
                                <asp:TextBox runat="server" ID="txtTypeOfDischarge" CssClass="form-control" placeholder="Type of Discharge"></asp:TextBox>
                            </div>
                        </div>
                        <div class="col-md-12">
                            <div class="form-group">
                                <label>If other than honorable, explain</label>
                                <asp:TextBox runat="server" ID="txtMilitaryExplain" CssClass="form-control" placeholder="Explanation"></asp:TextBox>
                            </div>
                        </div>

                        <button class="btn btn-primary nextBtn btn-lg pull-right" type="button">Next</button>
                    </div>
                </div>
            </div>

            <div class="row setup-content" id="step-6">
                <div class="col-xs-6 col-md-offset-3">
                    <div class="col-md-12">
                        <h3>Disclaimer and Signature</h3>
                        <div class="col-md-12">
                            <div class="form-group">
                                <label>
                                    I certify that my answers are true and complete to the best of my knowledge. 
If this application leads to employment, I understand that false or misleading information in my application or interview may result in my release.
                                </label>

                            </div>
                        </div>

                        <div class="col-md-6">
                            <div class="form-group">
                                <label>Your Name*</label>
                                <asp:TextBox runat="server" ID="txtSignatureName" CssClass="form-control" required placeholder="Signature Name"></asp:TextBox>
                            </div>
                        </div>
                        <div class="col-md-6">
                            <div class="form-group">
                                <label>Date</label>
                                <asp:TextBox runat="server" ID="txtTodayDate" CssClass="form-control" ReadOnly="true"></asp:TextBox>
                            </div>
                        </div>


                        <asp:Button ID="btnAddHiring" CssClass="btn btn-primary nextBtn btn-lg pull-right" OnClick="btnAddHiring_Click" runat="server" Text="Submit" />
                    </div>
                </div>
            </div>
        </form>
    </div>
    <link href="Content/jquery-ui.css" rel="stylesheet" />
    <script src="Scripts/jquery-ui.js"></script>
    <script src="Scripts/min/inputmask/inputmask.min.js"></script>
    <script src="Scripts/min/inputmask/inputmask.extensions.min.js"></script>
    <script src="Scripts/min/jquery.inputmask.bundle.min.js"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            $("#txtDateAvailable").datepicker({ minDate: 0 });
            $('#txtFirstName').change(function () {
                addSignature();
            });
            $('#txtLastName').change(function () {
                addSignature();
            });
            $('#txtMiddleName').change(function () {
                addSignature();
            });
            function addSignature() {
                var firstName = $('#txtFirstName').val();
                var lastName = $('#txtLastName').val();
                var middleName = $('#txtMiddleName').val();
                $('#txtSignatureName').val(firstName + " " + middleName + " " + lastName);
            }

        });
    </script>
</body>
</html>
