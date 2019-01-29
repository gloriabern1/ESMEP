<%@ Page Title="" Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true" CodeBehind="AddStudent.aspx.cs" Inherits="ESMEP_EdoStateMinistryOfEducationPortal_.Modules.School.AddStudent" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
        <link href="../../Content/assets/plugins/dropzone/dropzone.css" rel="stylesheet" media="screen">
        <link rel="stylesheet" href="../../Content/assets/plugins/material-datetimepicker/bootstrap-material-datetimepicker.css" />

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="page-bar">
        <div class="page-title-breadcrumb">
            <div class=" pull-left">
                <div class="page-title">ADD NEW Student</div>
            </div>
            <ol class="breadcrumb page-breadcrumb pull-right">
                <li><i class="fa fa-home"></i>&nbsp;<a class="parent-item" href="#">School</a>&nbsp;<i class="fa fa-angle-right"></i>
                </li>
                <li class="active">Add Student</li>
            </ol>
        </div>
    </div>

    <div class="row">
		<div class="col-sm-12">
			<div class="card-box">
				<div class="card-head">
					<header>Create Student Profile</header>
				</div>
				<div class="card-body row">
                    <asp:Label ID="ErrorMessage" runat="server" CssClass="" ForeColor="Red"></asp:Label>
					
                    <div class="col-lg-4 p-t-20"> 
						<div class = "mdl-textfield mdl-js-textfield">
						    <input class = "mdl-textfield__input" type = "text" runat="server" id = "txtFirstName">
						    <label class = "mdl-textfield__label" for = "txtname">First Name</label>
					</div>
					</div>

                     <div class="col-lg-4 p-t-20"> 
						<div class = "mdl-textfield mdl-js-textfield">
						    <input class = "mdl-textfield__input" type = "text" runat="server" id = "txtLastName">
						    <label class = "mdl-textfield__label" for = "txtname">Last Name</label>
					</div>
					</div>

                     <div class="col-lg-4 p-t-20"> 
						<div class = "mdl-textfield mdl-js-textfield">
						    <input class = "mdl-textfield__input" type = "text" runat="server" id = "txtMidName">
						    <label class = "mdl-textfield__label" for = "txtname">Other Names</label>
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
                        <asp:DropDownList runat="server" ID="ddlState" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="ddlState_SelectedIndexChanged" ></asp:DropDownList>
<%--							<label for="sample2" class="mdl-textfield__label">Local Government</label>--%>
						</div>
					</div>

                    <div class="col-lg-4 p-t-20"> 
					<div class="mdl-textfield mdl-js-textfield getmdl-select getmdl-select__fix-height select-width">
                        <asp:DropDownList runat="server" ID="ddlLGA" CssClass="form-control" ></asp:DropDownList>
<%--							<label for="sample2" class="mdl-textfield__label">Local Government</label>--%>
						</div>
					</div>

                     <div class="col-lg-4 p-t-20"> 
                        <label class = "" >Birth Date</label>
						<div class = "txt-full-width">
     					    <input type="date" id="txtdate" runat="server" class="datepicker form-control">
<%--						    <input class = "mdl-textfield__input" type = "text" id = "dateOfBirth" runat="server">--%>
						</div>
					</div>     
                    <div class="col-lg-4 p-t-20"> 
                      <label class = "" >Select Gender</label>
                        <asp:DropDownList runat="server" ID="ddlSex" CssClass="form-control" ></asp:DropDownList>
                   </div>   							                          											
				</div>
			</div>
		</div>
        </div>

    <div class="row">
	<div class="col-sm-12">
		<div class="card-box">
			<div class="card-head">
				<header>Guardian Details</header>
			</div>
			<div class="card-body row">

                    <div class="col-lg-6 p-t-20"> 
						<div class = "mdl-textfield mdl-js-textfield txt-full-width">
						    <input class = "mdl-textfield__input" type = "text" runat="server" id = "txtFullname">
						    <label class = "mdl-textfield__label" for = "txtname">Full Name</label>
					</div>
					</div>
                
					<div class="col-lg-6 p-t-20">
						<div class = "mdl-textfield mdl-js-textfield txt-full-width">
						    <input class = "mdl-textfield__input" type = "text" runat="server" id = "txtGAddress">
						    <label class = "mdl-textfield__label" for = "txtAddress">
						    Address</label>
						</div>
					</div>

                     <div class="col-lg-4 p-t-20"> 
						<div class = "mdl-textfield mdl-js-textfield">
						    <input class = "mdl-textfield__input" type = "text" runat="server" pattern = "-?[0-9]*(\.[0-9]+)?" id = "txtGMobile">
						    <label class = "mdl-textfield__label" for = "txtname">Phone Number</label>
      						<span class = "mdl-textfield__error">Number required!</span>

					</div>
					</div>

                     <div class="col-lg-4 p-t-20"> 
						<div class = "mdl-textfield mdl-js-textfield">
						    <input class = "mdl-textfield__input" type = "text" runat="server" id = "txtGEmail">
						    <label class = "mdl-textfield__label" for = "txtname">Email</label>
					</div>
					</div>

                                
                    <div class="col-lg-4 p-t-20"> 
					<div class="mdl-textfield mdl-js-textfield getmdl-select getmdl-select__fix-height select-width">
                        <asp:DropDownList runat="server" ID="ddlRelation" CssClass="form-control" ></asp:DropDownList>
							<label for="ddlRelation" class="mdl-textfield__label"></label>
						</div>
					</div>
			</div>
            	
		</div>
	</div>
</div>
				
   <div class="row">
	<div class="col-sm-12">
		<div class="card-box">
			<div class="card-head">
				<header>Student Passport</header>
			</div>
			<div class="card-body row">
                <div class="col-lg-12 p-t-20">
					<label class="control-label col-md-3">Upload Photo
                        </label>
                        <div class="col-md-4">
                            <div id="id_dropzone" class="dropzone">
<%--                                <asp:FileUpload ID="id_dropzone" runat="server" CssClass="" />--%>
<%--                                <input type="file" class="dropzone" id="iddropzone" runat="server" hidden />--%>
                            </div>
                        </div>
                </div>
            </div>
            </div>
        <center>
            <div class="card-body row">
                <asp:Button runat="server" CssClass="mdl-button mdl-js-button mdl-button--raised mdl-js-ripple-effect m-b-10 m-r-20 btn-pink" Text="Save" ID="btnSave" OnClick="btnSave_Click" />
<%--			<button type="submit" class="" runat="server" onclick="">Submit</button>--%>
<%--			<button type="button" class="mdl-button mdl-js-button mdl-button--raised mdl-js-ripple-effect m-b-10 btn-default">Cancel</button>--%>
		</div>
        </center>

        </div>
    </div>


       <!-- dropzone -->
    <script src="../../Content/assets/plugins/dropzone/dropzone.js" ></script>
    <script src="../../Content/assets/plugins/dropzone/dropzone-call.js" ></script>
      <!-- material -->
    <script src='<%=Page.ResolveUrl("~/Content/assets/js/pages/material-select/getmdl-select.js") %>' ></script>
    <script  src='<%=Page.ResolveUrl("~/Content/assets/plugins/material-datetimepicker/moment-with-locales.min.js") %>'></script>
	<script  src='<%=Page.ResolveUrl("~/Content/assets/plugins/material-datetimepicker/bootstrap-material-datetimepicker.js") %>'></script>
	<script  src='<%=Page.ResolveUrl("~/Content/assets/plugins/material-datetimepicker/datetimepicker.js") %>'></script>
</asp:Content>
