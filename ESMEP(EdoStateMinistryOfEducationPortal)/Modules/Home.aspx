<%@ Page Title="" Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="ESMEP_EdoStateMinistryOfEducationPortal_.Modules.Home" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
           <div class="page-bar">
                        <div class="page-title-breadcrumb">
                            <div class=" pull-left">
                                <div class="page-title">Dashboard</div>
                            </div>
                            <ol class="breadcrumb page-breadcrumb pull-right">
                                <li><i class="fa fa-home"></i>&nbsp;<a class="parent-item" href="#">Home</a>&nbsp;<i class="fa fa-angle-right"></i>
                                </li>
                                <li class="active">Dashboard</li>
                            </ol>
                        </div>
                    </div>
                   <!-- start widget -->
					<div class="state-overview">
							<div class="row">
						        <div class="col-xl-3 col-md-6 col-12">
						          <div class="info-box bg-b-green">
						            <span class="info-box-icon push-bottom"><i class="material-icons">school</i></span>
						            <div class="info-box-content">
						              <span class="info-box-text">Total School</span>
						              <span class="info-box-number"><asp:Label runat="server" ID="lblSchool"></asp:Label></span>
						              <div class="progress">
						                <div class="progress-bar" style="width: 10%"></div>
						              </div>
						              <span class="progress-description">
						                    10% Increase in 28 Days
						                  </span>
						            </div>
						            <!-- /.info-box-content -->
						          </div>
						          <!-- /.info-box -->
						        </div>
						        <!-- /.col -->
						        <div class="col-xl-3 col-md-6 col-12">
						          <div class="info-box bg-b-yellow">
						            <span class="info-box-icon push-bottom"><i class="material-icons">person</i></span>
						            <div class="info-box-content">
						              <span class="info-box-text">Total Students</span>
						              <span class="info-box-number"><asp:Label runat="server" ID="lblStudent" Text="0"></asp:Label></span>
						              <div class="progress">
						                <div class="progress-bar" style="width: 8%"></div>
						              </div>
						              <span class="progress-description">
						                    8% Increase in 28 Days
						                  </span>
						            </div>
						            <!-- /.info-box-content -->
						          </div>
						          <!-- /.info-box -->
						        </div>
						        <!-- /.col -->
						        <div class="col-xl-3 col-md-6 col-12">
						          <div class="info-box bg-b-blue">
						            <span class="info-box-icon push-bottom"><i class="material-icons">group</i></span>
						            <div class="info-box-content">
						              <span class="info-box-text">Total Registration</span>
						              <span class="info-box-number"><asp:Label runat="server" ID="lblRegistered"></asp:Label></span>
						              <div class="progress">
						                <div class="progress-bar" style="width: 85%"></div>
						              </div>
						              <span class="progress-description">
						                    85% Increase in 28 Days
						                  </span>
						            </div>
						            <!-- /.info-box-content -->
						          </div>
						          <!-- /.info-box -->
						        </div>
						        <!-- /.col -->
						        <div class="col-xl-3 col-md-6 col-12">
						          <div class="info-box bg-b-pink">
						            <span class="info-box-icon push-bottom"><i class="material-icons">monetization_on</i></span>
						            <div class="info-box-content">
						              <span class="info-box-text">Fees Collection</span>
						              <span class="info-box-number"><asp:Label runat="server" ID="lblFees"></asp:Label></span><span>$</span>
						              <div class="progress">
						                <div class="progress-bar" style="width: 50%"></div>
						              </div>
						              <span class="progress-description">
						                    50% Increase in 28 Days
						                  </span>
						            </div>
						            <!-- /.info-box-content -->
						          </div>
						          <!-- /.info-box -->
						        </div>
						        <!-- /.col -->
						      </div>
						</div>
					<!-- end widget -->

    	<div class="row">
        <div class="col-lg-6 col-md-12 col-sm-12 col-12">
            <div class="card-box">
                <div class="card-head">
                    <header>No. School Registered for Exam</header>
                    <button id = "panel-button9" 
				    class = "mdl-button mdl-js-button mdl-button--icon pull-right" 
				    data-upgraded = ",MaterialButton">
				    <i class = "material-icons">more_vert</i>
				</button>
				<ul class = "mdl-menu mdl-menu--bottom-right mdl-js-menu mdl-js-ripple-effect"
				    data-mdl-for = "panel-button9">
				    <li class = "mdl-menu__item"><i class="material-icons">assistant_photo</i>Action</li>
				    <li class = "mdl-menu__item"><i class="material-icons">print</i>Another action</li>
				    <li class = "mdl-menu__item"><i class="material-icons">favorite</i>Something else here</li>
				</ul>
                </div>
                <div class="card-body ">
                <div class="table-responsive">
                    <table class="table table-striped custom-table table-hover">
                        <thead>
                            <tr>
                                <th>SN</th>
                                <th>Name</th>
                                <th>School</th>
                                <th>Action</th>
                            </tr>
                        </thead>
                        <tbody>
				<tr>
					<td>1</td>
					<td>FSLC</td>
					<td>Edo Community School</td>
					<td><a href="javascript:void(0)" class="" data-toggle="tooltip" title="Edit">
                        <i class="fa fa-check"></i></a> 
                        <a href="javascript:void(0)" class="text-inverse" title="Delete" data-toggle="tooltip">
                        <i class="fa fa-trash"></i></a>
                        </td>
				</tr>
                        </tbody>
                    </table>
                    </div>
                </div>
            </div>
	</div>
            <div class="col-lg-6 col-md-12 col-sm-12 col-12">
                                   <div class="card-box">
                                       <div class="card-head">
                                           <header>No. School In Local Govt</header>
                                           <button id = "panel-button8" 
				                           class = "mdl-button mdl-js-button mdl-button--icon pull-right" 
				                           data-upgraded = ",MaterialButton">
				                           <i class = "material-icons">more_vert</i>
				                        </button>
				                        <ul class = "mdl-menu mdl-menu--bottom-right mdl-js-menu mdl-js-ripple-effect"
				                           data-mdl-for = "panel-button8">
				                           <li class = "mdl-menu__item"><i class="material-icons">assistant_photo</i>Action</li>
				                           <li class = "mdl-menu__item"><i class="material-icons">print</i>Another action</li>
				                           <li class = "mdl-menu__item"><i class="material-icons">favorite</i>Something else here</li>
				                        </ul>
                                       </div>
                                       <div class="card-body ">
                                       <div class="table-responsive">
                                           <table class="table table-striped custom-table table-hover">
                                               <thead>
                                                   <tr>
                                                       <th>SN</th>
                                                       <th>Local Government</th>
                                                       <th>Count</th>
                                                       <th>Action</th>
                                                   </tr>
                                               </thead>
                                               <tbody>
									    <tr>
									      <td>1</td>
									      <td>Esan-North-East</td>
									      <td>2</td>
									      <td><a href="javascript:void(0)" class="" data-toggle="tooltip" title="Edit">
                                               	<i class="fa fa-check"></i></a> 
                                               	<a href="javascript:void(0)" class="text-inverse" title="Delete" data-toggle="tooltip">
                                               	<i class="fa fa-trash"></i></a>
                                              </td>
									    </tr>
                                               </tbody>
                                           </table>
                                           </div>
                                       </div>
                                   </div>
							</div>
		</div>				
</asp:Content>
