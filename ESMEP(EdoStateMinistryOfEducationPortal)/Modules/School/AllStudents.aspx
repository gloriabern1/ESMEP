﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true" CodeBehind="AllStudents.aspx.cs" Inherits="ESMEP_EdoStateMinistryOfEducationPortal_.Modules.School.AllSchool" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
        <link href="../../Content/assets/plugins/datatables/plugins/bootstrap/dataTables.bootstrap4.min.css" rel="stylesheet" type="text/css"/>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

         <div class="page-bar">
                        <div class="page-title-breadcrumb">
                            <div class=" pull-left">
                                <div class="page-title">All Students List</div>
                            </div>
                            <ol class="breadcrumb page-breadcrumb pull-right">
                                <li>
                                    <i class="fa fa-home"></i>&nbsp;<a class="parent-item" href="index.html">Home</a>&nbsp;<i class="fa fa-angle-right"></i>
                                </li>
                                <li>
                                    <a class="parent-item" href="#">Students</a>&nbsp;<i class="fa fa-angle-right"></i>
                                </li>
                                <li class="active">All Students List</li>
                            </ol>
                        </div>
                    </div>
                  

<div class="row">
    <div class="col-md-12">
        <div class="tabbable-line">
            <ul class="nav customtab nav-tabs" role="tablist">
	            <li class="nav-item"><a href="#tab1" class="nav-link active"  data-toggle="tab" >List View</a></li>
<%--	            <li class="nav-item"><a href="#tab2" class="nav-link" data-toggle="tab">Grid View</a></li>--%>
	        </ul>
            <div class="tab-content">
                <div class="tab-pane active fontawesome-demo" id="tab1">
                    <div class="row">
					    <div class="col-md-12">
					        <div class="card card-box">
					            <div class="card-head">
					                <header>All Students List</header>
					                <div class="tools">
					                    <a class="fa fa-repeat btn-color box-refresh" href="javascript:;"></a>
						                <a class="t-collapse btn-color fa fa-chevron-down" href="javascript:;"></a>
						                <a class="t-close btn-color fa fa-times" href="javascript:;"></a>
					                </div>
					            </div>
					            <div class="card-body ">
					                <div class="row">
					                    <div class="col-md-6 col-sm-6 col-6 pull-left">
					                        <div class="btn-group">
					                            <a href="AddStudent" id="addRow" class="btn btn-info">
					                                Add New <i class="fa fa-plus"></i>
					                            </a>
					                        </div>
					                    </div>
<%--					                    <div class="col-md-6 col-sm-6 col-6">
					                        <div class="btn-group pull-right">
					                            <a class="btn deepPink-bgcolor  btn-outline dropdown-toggle" data-toggle="dropdown">Tools
					                                <i class="fa fa-angle-down"></i>
					                            </a>
					                            <ul class="dropdown-menu pull-right">
					                                <li>
					                                    <a href="javascript:;">
					                                        <i class="fa fa-print"></i> Print </a>
					                                </li>
					                                <li>
					                                    <a href="javascript:;">
					                                        <i class="fa fa-file-pdf-o"></i> Save as PDF </a>
					                                </li>
					                                <li>
					                                    <a href="javascript:;">
					                                        <i class="fa fa-file-excel-o"></i> Export to Excel </a>
					                                </li>
					                            </ul>
					                        </div>
					                    </div>--%>
					                </div>
					                <div class="table-scrollable">
					                    <asp:GridView ID="gvStudents" CssClass="table table-striped table-bordered table-hover table-checkable order-column valign-middle"
                                            AutoGenerateColumns="false" runat="server">

                                            <Columns> 
                                                <asp:TemplateField Visible="false">
                                                        <ItemTemplate>                  
                                                            <asp:Label ID="lblStudentId" runat="server"  Text='<%# Bind("ID") %>' Visible="false"/>
                                                        </ItemTemplate>
                                                    <ItemStyle Width="2px" />
                                                </asp:TemplateField>
                                                <asp:BoundField  DataField="SN" HeaderText="#.">
                                                </asp:BoundField>
                                                <asp:BoundField  DataField="Name" HeaderText="Student Name">
                                                </asp:BoundField>
                                                <asp:BoundField  DataField="Sex" HeaderText="Gender">
                                                </asp:BoundField>
                                                <asp:BoundField  DataField="Date" HeaderText="Date Of Registration">
                                                </asp:BoundField>       
                                                <asp:BoundField  DataField="School" HeaderText="School">
                                                </asp:BoundField>  
                                                <asp:BoundField  DataField="Status" HeaderText="Status">
                                                </asp:BoundField>                                                                                                       
                                                <asp:TemplateField HeaderText="Select">
                                                        <ItemTemplate>  

                                                        </ItemTemplate>
                                                        <ItemStyle Width="20px" />
                                                    </asp:TemplateField>
                                                </Columns>
                                        </asp:GridView>

					                </div>
					            </div>
					        </div>
					    </div>
					</div>
                </div>
                <div class="tab-pane" id="tab2">
                    <div class="row">
					    <div class="col-md-4">
				            <div class="card card-box">
				                <div class="card-body no-padding ">
				                    <div class="doctor-profile">
				                            <img src="../assets/img/std/std10.jpg" class="doctor-pic" alt=""> 
					                    <div class="profile-usertitle">
					                        <div class="doctor-name">Pooja Patel </div>
					                        <div class="name-center"> Science </div>
					                    </div>
				                            <p>A-103, shyam gokul flats, Mahatma Road <br />Mumbai</p> 
				                            <div><p><i class="fa fa-phone"></i><a href="tel:(123)456-7890">  (123)456-7890</a></p> </div>
					                    <div class="profile-userbuttons">
					                        <a href="professor_profile.html" class="btn btn-circle deepPink-bgcolor btn-sm">Read More</a>
					                    </div>
				                    </div>
				                </div>
				            </div>
					    </div>
					    <div class="col-md-4">
				            <div class="card card-box">
				                <div class="card-body no-padding ">
				                    <div class="doctor-profile">
				                            <img src="../assets/img/std/std1.jpg" class="doctor-pic" alt=""> 
					                    <div class="profile-usertitle">
					                        <div class="doctor-name">Rajesh </div>
					                        <div class="name-center"> Mathematics </div>
					                    </div>
				                            <p>45, Krishna Tower, Near Bus Stop, Satellite, <br />Mumbai</p> 
				                            <div><p><i class="fa fa-phone"></i><a href="tel:(123)456-7890">  (123)456-7890</a></p> </div>
					                    <div class="profile-userbuttons">
					                            <a href="professor_profile.html" class="btn btn-circle deepPink-bgcolor btn-sm">Read More</a>
					                    </div>
				                    </div>
				                </div>
				            </div>
					    </div>
					    <div class="col-md-4">
				            <div class="card card-box">
				                <div class="card-body no-padding ">
				                    <div class="doctor-profile">
				                            <img src="../assets/img/std/std2.jpg" class="doctor-pic" alt=""> 
					                    <div class="profile-usertitle">
					                        <div class="doctor-name">Sarah Smith </div>
					                        <div class="name-center"> Commerce </div>
					                    </div>
				                            <p>456, Estern evenue, Courtage area, <br />New York</p> 
				                            <div><p><i class="fa fa-phone"></i><a href="tel:(123)456-7890">  (123)456-7890</a></p> </div>
					                    <div class="profile-userbuttons">
					                            <a href="professor_profile.html" class="btn btn-circle deepPink-bgcolor btn-sm">Read More</a>
					                    </div>
				                    </div>
				                </div>
				            </div>
					    </div>
                    </div>                    
                </div>
            </div>
        </div>
    </div>
</div>

  <script type="text/javascript">  
    $(document).ready(function () {  
        $('#<%=gvStudents.ClientID%>').DataTable();  
    });  
</script>  
<%-- Page Script --%>
<%--    <script src="../../Scripts/Pages/AllStudent.js"></script>--%>
</asp:Content>
