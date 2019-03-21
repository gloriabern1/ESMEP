<%@ Page Title="" Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true" CodeBehind="AllQuota.aspx.cs" Inherits="ESMEP_EdoStateMinistryOfEducationPortal_.Modules.Configuration.AllQuota" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
         <div class="page-bar">
                        <div class="page-title-breadcrumb">
                            <div class=" pull-left">
                                <div class="page-title">QUOTA</div>
                            </div>
                            <ol class="breadcrumb page-breadcrumb pull-right">
                                <li><i class="fa fa-home"></i>&nbsp;<a class="parent-item" href="#">Home</a>&nbsp;<i class="fa fa-angle-right"></i>
                                </li>
                                <li><a class="parent-item" href="#">Quota</a>&nbsp;<i class="fa fa-angle-right"></i>
                                </li>
                                <li class="active">All Quota</li>
                            </ol>
                        </div>
                    </div>
                    <div class="row">
                    	<div class="col-sm-12 col-md-12 col-xl-12">
                             <div class="card-box">
                                 <div class="card-head">
										<header>All Assigned Quota</header>
<%--				                        <button id = "sdntmenu" 
				                           class = "mdl-button mdl-js-button mdl-button--icon pull-right" 
				                           data-upgraded = ",MaterialButton">
				                           <i class = "material-icons">more_vert</i>
				                        </button>
				                        <ul class = "mdl-menu mdl-menu--bottom-right mdl-js-menu mdl-js-ripple-effect"
				                           data-mdl-for = "sdntmenu">
				                           <li class = "mdl-menu__item"><i class="material-icons">assistant_photo</i>Action</li>
				                           <li class = "mdl-menu__item"><i class="material-icons">print</i>Another action</li>
				                           <li class = "mdl-menu__item"><i class="material-icons">favorite</i>Something else here</li>
				                        </ul>--%>
									</div>
                                 
                                 <div class="card-body ">
                                 	<div class="row">
                                       <div class="col-md-6 col-sm-6 col-6 pull-right">
                                           <div class="btn-group">
                                               <a href="../AssignQuota" id="addRow" class="btn btn-info">
                                                   Add New <i class="fa fa-plus"></i>
                                               </a>
                                           </div>
                                       </div>
                                   <div class="table-scrollable">
                                    <asp:GridView ID="gvAllQuota" CssClass="table table-striped table-bordered table-hover table-checkable order-column valign-middle" OnRowCommand="gvAllQuota_RowCommand"
                                        AutoGenerateColumns="false" runat="server">
                                        <Columns>
                                            <asp:BoundField  DataField="ID" Visible="false" HeaderText="#">
                                            </asp:BoundField>
                                            <asp:BoundField  DataField="SN" HeaderText="#">
                                            </asp:BoundField>
                                            <asp:BoundField  DataField="Name" HeaderText="NAME OF SCHOOL">
                                            </asp:BoundField>
                                            <asp:BoundField  DataField="Assigned" HeaderText="QUOTA ASSIGNED">
                                            </asp:BoundField>
                                            <asp:BoundField  DataField="Used" HeaderText="QUOTA USED">
                                            </asp:BoundField>                    
                                            <asp:BoundField  DataField="Remainning" HeaderText="QUOTA REMAINNING">
                                            </asp:BoundField>              
                                            <asp:BoundField  DataField="Year" HeaderText="YEAR">
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
        $('#<%=gvAllQuota.ClientID%>').DataTable();  
    });  
</script>  
</asp:Content>
