<%@ Page Title="Register" Language="C#"  AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="ESMEP_EdoStateMinistryOfEducationPortal_.Account.Register" %>

<!DOCTYPE html>
<html>

<!-- Mirrored from radixtouch.in/templates/admin/smart/source/light/login.html by HTTrack Website Copier/3.x [XR&CO'2014], Wed, 24 Oct 2018 14:03:55 GMT -->
<head>
    <meta charset="utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta content="width=device-width, initial-scale=1" name="viewport" />
    <meta name="description" content="Responsive Admin Template" />
    <meta name="author" content="RedstarHospital" />
    <title></title>
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
    <p class="text-danger">
        <asp:Literal runat="server" ID="ErrorMessage" />
    </p> 
      <div class="limiter">
		<div class="container-login100 page-background">
			<div class="wrap-login100">
				<form class="login100-form validate-form" runat="server">
				<%--	<span class="login100-form-logo">
						<img alt="" src="../assets/img/logo-2.png">
					</span>--%>
					<span class="login100-form-title p-b-34 p-t-27">
						Registration
					</span>
					<div class="row">
					<div class="col-lg-6 p-t-20">
					<div class="wrap-input100 validate-input" data-validate = "Enter username">
						<input class="input100" runat="server" type="text" id="txtUsername" name="username" placeholder="Username">
						<span class="focus-input100" data-placeholder="&#xf207;"></span>
					</div>
					</div>
					<div class="col-lg-6 p-t-20">
					<div class="wrap-input100 validate-input" data-validate = "Enter email">
						<input class="input100" runat="server" type="email" id="txtEmail" name="email" placeholder="Email">
						<span class="focus-input100" data-placeholder="&#xf207;"></span>
					</div>
					</div>
					<div class="col-lg-6 p-t-20">
					<div class="wrap-input100 validate-input" data-validate="Enter password">
						<input class="input100" type="password" id="txtPass" runat="server" name="pass" placeholder="Password">
						<span class="focus-input100" data-placeholder="&#xf191;"></span>
					</div>
					</div>
					<div class="col-lg-6 p-t-20">
					<div class="wrap-input100 validate-input" data-validate="Enter password again">
						<input class="input100" type="password" id="txtConfirmPass" name="pass2" placeholder="Confirm password">
						<span class="focus-input100" data-placeholder="&#xf191;"></span>
					</div>
					</div>
					</div>
					<div class="contact100-form-checkbox">
						<input class="input-checkbox100" id="remamberMe" type="checkbox" name="remember-me">
						<label class="label-checkbox100" for="ckb1">
							Remember me
						</label>
					</div>
					<div class="container-login100-form-btn">
                        <asp:Button runat="server" OnClick="CreateUser_Click" Text="Register" CssClass="login100-form-btn" />
					</div>
					<div class="text-center p-t-30">
						<a class="txt1" href="login.html">
							You already have a membership?
						</a>
					</div>
				</form>
			</div>
		</div>
	</div>
  

            <div class="col-md-offset-2 col-md-10">
            </div>
      
    
    <!-- start js include path -->
    <script src="../Content/assets/plugins/jquery/jquery.min.js" ></script>
    <!-- bootstrap -->
    <script src="../Content/assets/plugins/bootstrap/js/bootstrap.min.js" ></script>
    <script src="../Content/assets/js/pages/extra-pages/pages.js" ></script>
    <!-- end js include path -->
</body>

</html>