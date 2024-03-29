﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true" CodeBehind="AllSchool.aspx.cs" Inherits="ESMEP_EdoStateMinistryOfEducationPortal_.Modules.School.AllSchool1" %>
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
										<header>Schools</header>
				                        <button id = "sdntmenu" 
				                           class = "mdl-button mdl-js-button mdl-button--icon pull-right" 
				                           data-upgraded = ",MaterialButton">
				                           <i class = "material-icons">more_vert</i>
				                        </button>
				                        <ul class = "mdl-menu mdl-menu--bottom-right mdl-js-menu mdl-js-ripple-effect"
				                           data-mdl-for = "sdntmenu">
				                           <li class = "mdl-menu__item"><i class="material-icons">assistant_photo</i>Action</li>
				                           <li class = "mdl-menu__item"><i class="material-icons">print</i>Another action</li>
				                           <li class = "mdl-menu__item"><i class="material-icons">favorite</i>Something else here</li>
				                        </ul>
									</div>
                                 
                                 <div class="card-body ">
                                 	<div class="row">
                                       <div class="col-md-6 col-sm-6 col-6 pull-right">
                                           <div class="btn-group">
                                               <a href="../registration/addSchool" id="addRow" class="btn btn-info">
                                                   Add New <i class="fa fa-plus"></i>
                                               </a>
                                           </div>
                                       </div>
                                   <div class="table-scrollable">
                                    <asp:GridView ID="gvSchool" CssClass="table table-striped table-bordered table-hover table-checkable order-column valign-middle" OnRowCommand="gvSchool_RowCommand"
                                        AutoGenerateColumns="false" runat="server">
                                        <Columns>
                                            <asp:TemplateField Visible="false">
                                                    <ItemTemplate>                  
                                                        <asp:Label ID="lblExamId" runat="server"  Text='<%# Bind("ID") %>' Visible="false"/>
                                                    </ItemTemplate>
                                                <ItemStyle Width="0px" />
                                            </asp:TemplateField>
                                            <asp:BoundField  DataField="SN" HeaderText="#">
                                            </asp:BoundField>
                                            <asp:BoundField  DataField="Name" HeaderText="NAME OF SCHOOL">
                                            </asp:BoundField>
                                            <asp:BoundField  DataField="Email" HeaderText="EMAIL ADDRESS">
                                            </asp:BoundField>
                                            <asp:BoundField  DataField="Address" HeaderText="ADDRESS">
                                            </asp:BoundField>                    
                                            <asp:BoundField  DataField="LocalGovt" HeaderText="LOCAL GOVERNMENT">
                                            </asp:BoundField>              
                                            <asp:BoundField  DataField="Inspector" HeaderText="INSPECTOR">
                                            </asp:BoundField>                
                                            <asp:TemplateField HeaderText="ACTION">
                                                    <ItemTemplate>  
                                                            <asp:Button ID="btnview" runat="server" CommandName="doView"  CommandArgument='<%# Bind("ID") %>' Text="VIEW" CssClass="btn btn-success btn-sm"/>                      
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
        <!-- data tables -->
   
            <script type="text/javascript">  
    $(document).ready(function () {  
        $('#<%=gvSchool.ClientID%>').DataTable();  
    });  
</script>  
<%-- Page Script --%>
    <script src="../../Scripts/Pages/AllSchool.js"></script>
</asp:Content>
