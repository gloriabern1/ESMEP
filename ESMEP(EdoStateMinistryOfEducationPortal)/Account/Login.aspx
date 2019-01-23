<%@ Page Title="Log in" Language="C#"  AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="ESMEP_EdoStateMinistryOfEducationPortal_.Account.Login" Async="true" %>

<!DOCTYPE html>
<html>

<!-- Mirrored from radixtouch.in/templates/admin/smart/source/light/login.html by HTTrack Website Copier/3.x [XR&CO'2014], Wed, 24 Oct 2018 14:03:55 GMT -->
<head>
    <meta charset="utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta content="width=device-width, initial-scale=1" name="viewport" />
    <meta name="description" content="Responsive Admin Template" />
    <meta name="author" content="RedstarHospital" />
    <title>Login</title>
    <!-- google font -->
    <link href="http://fonts.googleapis.com/css?family=Open+Sans:400,300,600,700&amp;subset=all" rel="stylesheet" type="text/css" />
	<!-- icons -->
    <link href="../fonts/font-awesome/css/font-awesome.min.css" rel="stylesheet" type="text/css"/>
	<link rel="stylesheet" href="../Content/assets/plugins/iconic/css/material-design-iconic-font.min.css">
    <!-- bootstrap -->
	<link href="../Content/assets/plugins/bootstrap/css/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <!-- style -->
    <link rel="stylesheet" href="../Content/assets/css/pages/extra_pages.css">
	<!-- favicon -->
    <link rel="shortcut icon" href="http://radixtouch.in/templates/admin/smart/source/assets/img/favicon.ico" /> 
</head>
<body>
      <div class="limiter">
		<div class="container-login100 page-background">
			<div class="wrap-login100">
				<form class="login100-form validate-form" runat="server">
                    <div class="p-b-20">
                        <h5>Edo State Examination Registration portal</h5>
                    </div>
					<span class="login100-form-logo p-t-10">
						<img alt="" src="../Content/img/edostateSubeb.jpg">
					</span>
					<span class="login100-form-title p-b-34 p-t-27">
						Log in
					</span>
                    <span><asp:Label runat="server" ForeColor="Red" ID="ErrorMessage"></asp:Label></span>
					<div class="wrap-input100 validate-input" data-validate = "Enter username">
						<input class="input100" type="text" runat="server" id="txtEmail" name="username" placeholder="Username">
						<span class="focus-input100" data-placeholder=""></span>
					</div>
					<div class="wrap-input100 validate-input" data-validate="Enter password">
						<input class="input100" type="password" runat="server" id="txtPassword" name="pass" placeholder="Password">
						<span class="focus-input100" data-placeholder=""></span>
					</div>
					<div class="contact100-form-checkbox">
						<input class="input-checkbox100" runat="server" id="chkRememberMe" type="checkbox" name="remember-me">
						<label class="label-checkbox100" for="RememberMe">
							Remember me
						</label>
					</div>
					<div class="container-login100-form-btn">
                        <asp:Button ID="btnLogIn" CssClass="login100-form-btn" Text="Login" runat="server" OnClick="LogIn" />
					</div>
					<div class="text-center p-t-30">
						<a class="txt1" href="forgot_password.html">Forgot Password?</a>
					</div>
                   <p>
                    <asp:HyperLink runat="server" ID="RegisterHyperLink" ViewStateMode="Disabled">Register as a new user</asp:HyperLink>
                </p>
				</form>
			</div>
		</div>
	</div>

    <!-- start js include path -->
    <script src="../Content/assets/plugins/jquery/jquery.min.js" ></script>
    <!-- bootstrap -->
    <script src="../Content/assets/plugins/bootstrap/js/bootstrap.min.js" ></script>
    <script src="../Content/assets/js/pages/extra-pages/pages.js" ></script>
    <!-- end js include path -->
</body>

</html>