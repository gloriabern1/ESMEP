<%@ Page Title="" Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true" CodeBehind="UploadAttendance.aspx.cs" Inherits="ESMEP_EdoStateMinistryOfEducationPortal_.Modules.School.UploadAttendance" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

                   <div class="page-bar">
                        <div class="page-title-breadcrumb">
                            <div class=" pull-left">
                                <div class="page-title">School List</div>
                            </div>
                            <ol class="breadcrumb page-breadcrumb pull-right">
                                <li><i class="fa fa-home"></i>&nbsp;<a class="parent-item" href="#">Home</a>&nbsp;<i class="fa fa-angle-right"></i>
                                </li>
                                <li><a class="parent-item" href="#">Schools</a>&nbsp;<i class="fa fa-angle-right"></i>
                                </li>
                                <li class="active">School List</li>
                            </ol>
                        </div>
                    </div>
            
                           <div class="row">
          <div class="col-sm-12 col-md-12 col-xl-12">
                <div class="card-box">
                    <div class="card-head">
						<header>Inspectors</header>                        
					</div>

                   <div class="card-body ">
                    <div class="row">
                        <div class="col-md-12 col-sm-6 col-6 pull-right">
                            <div class="btn-group pull-right">
                                <a href="../school/addstudent" id="addRow" class="btn btn-info ">
                                    Add New <i class="fa fa-plus"></i>
                                </a>
                            </div>
                        </div>
                        <div>

                        </div>
                    </div>
                </div>
              </div>
            </div>
</asp:Content>
