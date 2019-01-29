<%@ Page Title="" Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true" CodeBehind="AddSchool.aspx.cs" Inherits="ESMEP_EdoStateMinistryOfEducationPortal_.Modules.Registration.AddSchool" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
           <!-- Date Time item CSS -->
    <link rel="stylesheet" href="../../Content/assets/plugins/material-datetimepicker/bootstrap-material-datetimepicker.css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <div class="page-bar">
                        <div class="page-title-breadcrumb">
                            <div class=" pull-left">
                                <div class="page-title">New School</div>
                            </div>
                            <ol class="breadcrumb page-breadcrumb pull-right">
                                <li>
                                    <i class="fa fa-home"></i>&nbsp;<a class="parent-item" href='<%=Page.ResolveUrl("~/Modules/School/AllSchool")%>'>School</a>&nbsp;<i class="fa fa-angle-right"></i>
                                </li>
                                <li class="active">Add New School</li>
                            </ol>
                        </div>
                    </div>

    <div class="row">
	<div class="col-sm-12">
		<div class="card-box">
			<div class="card-head">
				<header>Register School</header>
			</div>
			<div class="card-body row">
                <asp:Label ID="ErrorMessage" runat="server" CssClass="" ForeColor="Red"></asp:Label>
				<div class="col-lg-4 p-t-20"> 
					<div class = "mdl-textfield mdl-js-textfield">
						<input class = "mdl-textfield__input" type = "text" runat="server" id = "txtname">
						<label class = "mdl-textfield__label" for = "txtname">Name Of School</label>
				</div>
				</div>
				<div class="col-lg-4 p-t-20">
					<div class = "mdl-textfield mdl-js-textfield">
						<input class = "mdl-textfield__input" type = "text" runat="server" id = "txtAddress">
						<label class = "mdl-textfield__label" for = "txtAddress">
						Address</label>
					</div>
				</div>

                    <div class="col-lg-4 p-t-20"> 
					<div class="mdl-textfield mdl-js-textfield getmdl-select getmdl-select__fix-height select-width">
                        <asp:DropDownList runat="server" ID="ddlLGA" CssClass="form-control" ></asp:DropDownList>
<%--									            <input class="mdl-textfield__input" type="text" id="sample2" value="India" readonly tabIndex="-1">--%>
						<%--<label for="sample2" class="pull-right margin-0">
							<i class="mdl-icon-toggle__label material-icons">keyboard_arrow_down</i>
						</label>--%>
						<label for="sample2" class="mdl-textfield__label"></label>
						<%--<ul data-mdl-for="sample2" class="mdl-menu mdl-menu--bottom-left mdl-js-menu">
							<li class="mdl-menu__item" data-val="DE">Shrilanka</li>
							<li class="mdl-menu__item" data-val="BY">India</li>
							<li class="mdl-menu__item" data-val="RU">Germany</li>
						</ul>--%>
					</div>
				</div>
							           
				<div class="col-lg-4 p-t-20">
					<div class = "mdl-textfield mdl-js-textfield">
					<input class = "mdl-textfield__input" type = "text" runat="server"  id = "txtEmail" >
					<label class = "mdl-textfield__label" for = "txtemail">
					Email Address </label>
				</div>
				</div>
                <div class="col-lg-4 p-t-20">
					<div class = "mdl-textfield mdl-js-textfield mdl-textfield--floating-label txt-width">
						<input class = "mdl-textfield__input" type = "text" runat="server" 
						pattern = "-?[0-9]*(\.[0-9]+)?" id = "txtMobileNo">
						<label class = "mdl-textfield__label" for = "txtMobileNo">
						Mobile Number</label>
						<span class = "mdl-textfield__error">Number required!</span>
					</div>
				</div>
                             
				<div class="col-lg-4 p-t-20"> 
					<div class = "mdl-textfield mdl-js-textfield mdl-textfield--floating-label txt-width">
						<input class = "mdl-textfield__input" type = "text" id = "txtPrincipal" runat="server">
						<label class = "mdl-textfield__label" for = "text4">Name Of Principal</label>
					</div>
				</div>

                <div class="col-lg-4 p-t-20"> 
                  <label class = "" >Select Title</label>
					<div class="mdl-textfield mdl-js-textfield getmdl-select getmdl-select__fix-height select-width">
                        <asp:DropDownList runat="server" ID="ddlTitle" CssClass="form-control" ></asp:DropDownList>
					</div>
				</div>

                <div class="col-lg-4 p-t-20">
                   <label class = "" >Date Of Incorporation</label>
				    <div class = "mdl-textfield mdl-js-textfield mdl-textfield--floating-label txt-full-width">
					    <input type="date" id="txtdate" runat="server" class="datepicker form-control">

                    </div>
				</div>                               

                <div class="col-lg-4 p-t-20"> 
                  <label class = "" >Select Category</label>
					<div class="mdl-textfield mdl-js-textfield getmdl-select getmdl-select__fix-height select-width">
                        <asp:DropDownList runat="server" ID="ddlSchoolCat" CssClass="form-control" ></asp:DropDownList>
					</div>
				</div>
							            							       
            <div class="col-lg-2 p-t-20">
	            <div class="radio p-0">
	                <input type="radio" name="type" id="radPublic" runat="server" value="1" checked>
	                <label for="radPublic">
	                    Public
	                </label>
	            </div>
             </div>
		<div class="col-lg-2 p-t-20">
	            <div class="radio p-0">
	                <input type="radio" name="type" id="radPrivate" runat="server" value="2">
	                <label for="radPrivate">
	                    Private
	                </label>
	            </div>
             </div>

				<div class="col-lg-12 p-t-20"> 
					<label class="mdl-checkbox mdl-js-checkbox mdl-js-ripple-effect" for="checkbox-1">
						<input type="checkbox" id="checkbox-1" class="mdl-checkbox__input" checked>
						<span class="mdl-checkbox__label">Are you sure?</span>
					</label>
				</div>

				<div class="col-lg-8 p-t-20">
				</div>
									
				<div class="col-lg-12 p-t-20"> 
                    <asp:Button runat="server" CssClass="mdl-button mdl-js-button mdl-button--raised mdl-js-ripple-effect mdl-button--accent" ID="btnSubmit" Text="Submit" OnClick="btnSubmit_Click" />
				</div>
			</div>
		</div>
	</div>
    </div>
                                
      <!-- material -->
    <script src='<%=Page.ResolveUrl("~/Content/assets/js/pages/material-select/getmdl-select.js") %>' ></script>
    <script  src='<%=Page.ResolveUrl("~/Content/assets/plugins/material-datetimepicker/moment-with-locales.min.js") %>'></script>
	<script  src='<%=Page.ResolveUrl("~/Content/assets/plugins/material-datetimepicker/bootstrap-material-datetimepicker.js") %>'></script>
	<script  src='<%=Page.ResolveUrl("~/Content/assets/plugins/material-datetimepicker/datetimepicker.js") %>'></script>
</asp:Content>
