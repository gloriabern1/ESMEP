<%@ Page Title="" Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true" CodeBehind="ExamFeesSetup.aspx.cs" Inherits="ESMEP_EdoStateMinistryOfEducationPortal_.Modules.Configuration.ExamFeesSetup" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="page-bar">
        <div class="page-title-breadcrumb">
            <div class=" pull-left">
                <div class="page-title">Exams</div>
            </div>
            <ol class="breadcrumb page-breadcrumb pull-right">
                <li><i class="fa fa-home"></i>&nbsp;<a class="parent-item" href="#">Home</a>&nbsp;<i class="fa fa-angle-right"></i>
                </li>
                <li><a class="parent-item" href="#">exams</a>&nbsp;<i class="fa fa-angle-right"></i>
                </li>
                <li class="active">Exam Fee</li>
            </ol>
        </div>
    </div>
    
  <div class="row">
      <div class="col-md-12 col-sm-12">
		<div class="card-box">
			<div class="card-head">
				<header>Assign Fee For Exam Per Student</header>
			</div>
            <div class="card-body " id="bar-parent2">
                <div class="row">
            <div class="col-md-12 col-sm-6 center"> 
                        <asp:Label ID="ErrorMessage" runat="server" CssClass="" ForeColor="Red"></asp:Label>
	            </div>
	            <div class="col-md-6 col-sm-6"> 
                    <div class="form-group">
	                    <label>Select Exam</label>
	                    <asp:DropDownList runat="server" ID="ddlExam" CssClass="form-control"></asp:DropDownList>
	                </div>		
                </div>
             <div class="col-md-6 col-sm-6"> 
               <div class="form-group">
	                <label>Select Year</label>
	                <asp:DropDownList runat="server" ID="ddlYear" CssClass="form-control"></asp:DropDownList>
	            </div>		
            </div>
            <div class="col-md-6 col-sm-6"> 
                    <div class="form-group">
	                    <label>Enter Amount</label>
	                    <input type="number" runat="server" id="txtAmount" class="form-control" placeholder="1000" aria-valuemin="0" min="0">
	                </div>
                </div>
             <div class="col-md-6 col-sm-6"> 
                 </div>

            <div class="col-md-12">
              <div class="form-group pull-right" style="clear:both">
                  <asp:Button runat="server" ID="btnSumbit" CssClass="btn btn-info m-r-20" OnClick="btnSumbit_Click" Text="Submit" />
				</div>
			</div>
		</div>
	</div>
    </div>
     </div>
   </div>
     
</asp:Content>
