<%@ Page Title="" Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true" CodeBehind="AboutSchool.aspx.cs" Inherits="ESMEP_EdoStateMinistryOfEducationPortal_.Modules.School.ViewDetails" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
             <div class="page-bar">
                        <div class="page-title-breadcrumb">
                            <div class=" pull-left">
                                <div class="page-title">Course Details</div>
                            </div>
                            <ol class="breadcrumb page-breadcrumb pull-right">
                                <li><i class="fa fa-home"></i>&nbsp;<a class="parent-item" href="../Home">Home</a>&nbsp;<i class="fa fa-angle-right"></i>
                                </li>
                                <li><a class="parent-item" href="#">School</a>&nbsp;<i class="fa fa-angle-right"></i>
                                </li>
                                <li class="active">School Details</li>
                            </ol>
                        </div>s
                    </div>
                    <div class="row">
                        <div class="col-md-12">
                            <!-- BEGIN PROFILE SIDEBAR -->
                            <div class="profile-sidebar">
                                <div class="card card-topline-aqua">
                                    <div class="card-body no-padding height-9">
                                        <div class="row">
                                            <div class="course-picture">
                                                <img src='<%=Page.ResolveUrl("~/Content/img/EdoStateLogo.jpg") %>' class="img-responsive" alt=""> 

                                            </div>
                                        </div>
                                        <div class="profile-usertitle">
                                            <div class="profile-usertitle-name">School Logo </div>
                                        </div>
                                        <!-- END SIDEBAR USER TITLE -->
                                    </div>
                                </div>
                                <div class="card">
                                    <div class="card-head card-topline-aqua">
                                        <header>About School</header>
                                    </div>
                                    <div class="card-body no-padding height-9">
                                        <div class="profile-desc">
                                            Established since <asp:Label ID="lblDate1" runat="server" />
                                        </div>
                                        <ul class="list-group list-group-unbordered">
                                            <li class="list-group-item">
                                                <b>Email</b>
                                                <div class="profile-desc-item pull-right"><asp:Label runat="server" ID="lblEmail"></asp:Label></div>
                                            </li>
                                             <li class="list-group-item">
                                                <b>Principal's Name</b>
                                                <div class="profile-desc-item pull-right"><asp:Label runat="server" ID="lblPrincipal"></asp:Label></div>
                                            </li>
                                            <li class="list-group-item">
                                                <b>Local Government </b>
                                                <div class="profile-desc-item pull-right"><asp:Label runat="server" ID="lblLga"></asp:Label></div>
                                            </li>

                                            <li class="list-group-item">
                                                <b>Date Of Incorporation</b>
                                                <div class="profile-desc-item pull-right"><asp:Label runat="server" ID="lblDate"></asp:Label></div>
                                            </li>
                                        </ul>
                                        <div class="row list-separated profile-stat">
                                            <div class="col-md-4 col-sm-4 col-6">
                                                <div class="uppercase profile-stat-title"> <asp:Label runat="server" ID="lblClasses"></asp:Label></div>
                                                <div class="uppercase profile-stat-text"> Classes  </div>
                                            </div>
                                            <div class="col-md-4 col-sm-4 col-6">
                                                <div class="uppercase profile-stat-title"><asp:Label runat="server" ID="lblStudent"></asp:Label></div>
                                                <div class="uppercase profile-stat-text"> Students </div>
                                            </div>
                                            <div class="col-md-4 col-sm-4 col-6">
                                                <div class="uppercase profile-stat-title"> 61 </div>
                                                <div class="uppercase profile-stat-text"> Batches </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <!-- END BEGIN PROFILE SIDEBAR -->
                            <!-- BEGIN PROFILE CONTENT -->
                            <div class="profile-content">
                                <div class="row">
                                     <div class="card">
                                         <div class="card-topline-aqua">
                                             <header></header>
                                         </div>
											<div class="white-box">
					                            <!-- Nav tabs -->
					                            <!-- Tab panes -->
					                            <div class="tab-content">
					                                <div class="tab-pane active fontawesome-demo">
															<div id="biography" >
								                                    <p>Foundered on <asp:Label ID="lblDate2" runat="server" /></p>
							                                    <br>
							                                    <h4 class="font-bold">Subjects </h4>
							                                    <hr>
							                                    <ul>
							                                        <li>English</li>
							                                        <li>Mathematics</li>
							                                        <li>Computer Science</li>
							                                        <li>Biology</li>
							                                        <li>Chemistry</li>
							                                        <li>Physics</li>
							                                        <li>Etc.</li>
							                                    </ul>
							                                </div>
													</div>
					                            </div>
					                        </div>
                                         </div>
                                     </div>
                                </div>
                                <!-- END PROFILE CONTENT -->
                            </div>
                        </div>
           
</asp:Content>
