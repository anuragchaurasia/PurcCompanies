﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ForgetPassword.aspx.cs" Inherits="PrivateICO.ForgetPassword" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta charset="utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <!-- Tell the browser to be responsive to screen width -->
    <meta content="width=device-width, initial-scale=1, maximum-scale=1, user-scalable=no" name="viewport" />
    <!-- Bootstrap 3.3.6 -->
    <link rel="stylesheet" href="bootstrap/css/bootstrap.min.css" />
    <title>Purcell Compliances Sales Management</title>
    <!-- Font Awesome -->
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.5.0/css/font-awesome.min.css" />
    <!-- Ionicons -->
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/ionicons/2.0.1/css/ionicons.min.css" />
    <!-- Theme style -->
    <link rel="stylesheet" href="dist/css/AdminLTE.min.css" />
    <!-- AdminLTE Skins. Choose a skin from the css/skins
       folder instead of downloading all of them to reduce the load. -->
    <link rel="stylesheet" href="dist/css/skins/_all-skins.min.css" />
</head>
<body class="hold-transition skin-blue sidebar-mini" style="background-image:url(img/backg.png);background-repeat: no-repeat;background-position: 0 0;background-size: cover;  ">
    <div>
        <form id="form1" runat="server">
            <div class="content-wrapper" style="margin-left:0px; ">
                <section class="content">
                    <div class="row">
                        <div class="col-lg-6 col-lg-offset-3" style="margin-top: 409px;">
                            <div class="box box-info">
                                
                               <%-- <div class="box-header with-border">
                                    
                                    <h3 class="box-title" style="vertical-align:central;margin-left:150px;font-size:xx-large;"><img src="img/logo-main.png"  style="max-width:70%;" /></h3>
                                </div>--%>
                                <!-- /.box-header -->

                                <div class="box-body">
                                    <div class="form-group">
                                        <label for="inputEmail3" class="col-sm-2 control-label">Enter Your Email</label>

                                        <div class="col-sm-10 form-group">
                                            <asp:TextBox runat="server" ID="txtUsername" CssClass="form-control" placeholder="Email Address" required></asp:TextBox>
                                        </div>
                                    </div>
                                </div>
                                <!-- /.box-body -->
                                <div class="box-footer">
                                    <asp:LinkButton ID="LinkButton1" runat="server" PostBackUrl="~/Default.aspx">Sign In</asp:LinkButton>
                                    <asp:Button runat="server" ID="btnSignIn" CssClass="btn btn-info pull-right" Text="Recover Password" OnClick="btnSignIn_Click" />
                                </div>
                                <!-- /.box-footer -->
                            </div>
                        </div>
                    </div>
                </section>
            </div>
        </form>
    </div>
</body>
</html>