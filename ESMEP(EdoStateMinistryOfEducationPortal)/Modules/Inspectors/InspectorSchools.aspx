<%@ Page Title="" Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true" CodeBehind="InspectorSchools.aspx.cs" Inherits="ESMEP_EdoStateMinistryOfEducationPortal_.Modules.Inspectors.InspectorSchools" %>
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
                           <div class="col-md-12 col-sm-6">
                        <div class="card card-box">
                            <div class="card-head">
                                <header>All School</header>
                                <div class="tools">
                                    <a class="fa fa-repeat btn-color box-refresh" href="javascript:;"></a>
	                                <a class="t-collapse btn-color fa fa-chevron-down" href="javascript:;"></a>
	                                <a class="t-close btn-color fa fa-times" href="javascript:;"></a>
                                </div>
                            </div>
                            <div class="card-body" id="line-parent">
  								<div class="panel-group accordion" id="accordion3">
                                        <div class="panel panel-default">
                                            <div class="panel-heading panel-heading-gray">
                                                <h4 class="panel-title">
                                                    <a class="accordion-toggle accordion-toggle-styled" data-toggle="collapse" data-parent="#accordion3" href="#collapse_3_1"> Primary School </a>
                                                </h4>
                                            </div>
                                            <div id="collapse_3_1" class="panel-collapse in">
                                                <div class="panel-body" style="height:400px; overflow-y:auto;">
                                                    <div class="table-scrollable">
                                                        <asp:GridView ID="gvPrimary" CssClass="table table-striped table-bordered table-hover table-checkable order-column valign-middle" OnRowCommand="gvPrimary_RowCommand"
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
                                                                <asp:BoundField  DataField="Principal" HeaderText="NAME OF PRINCIPAL">
                                                                </asp:BoundField>       
                                                                <asp:BoundField  DataField="Student" HeaderText="# OF STUDENTS">
                                                                </asp:BoundField> 
                                                                      <asp:TemplateField HeaderText="Type OF School">
                                                                        <ItemTemplate>                  
                                                                            <asp:Label ID="type" runat="server"  Text='<%# Bind("Type") %>'/>
                                                                        </ItemTemplate>
                                                                    <ItemStyle />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="ACTION">
                                                                        <ItemTemplate>  
                                                                                <asp:Button ID="btnview" runat="server" CommandName="doView"  CommandArgument='<%# Bind("ID") %>' Text="View Submission" CssClass="btn btn-success btn-sm"/>                      
                                                                        </ItemTemplate>
                                                                        <ItemStyle Width="20px" />
                                                                    </asp:TemplateField>
                                                                </Columns>
                                                        </asp:GridView>                                                    								
					            				    </div>
                                            </div>
                                        </div>
                                        <div class="panel panel-default">
                                            <div class="panel-heading panel-heading-gray">
                                                <h4 class="panel-title">
                                                    <a class="accordion-toggle accordion-toggle-styled collapsed" data-toggle="collapse" data-parent="#accordion3" href="#collapse_3_2">Secondary School </a>
                                                </h4>
                                            </div>
                                            <div id="collapse_3_2" class="panel-collapse collapse">
                                                <div class="panel-body" style="height:400px; overflow-y:auto;">
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
                                                                <asp:BoundField  DataField="Principal" HeaderText="NAME OF PRINCIPAL">
                                                                </asp:BoundField>                                                                   
                                                                <asp:BoundField  DataField="Student" HeaderText="# OF STUDENTS">
                                                                </asp:BoundField>     
                                                                  <asp:TemplateField HeaderText="Type of School">
                                                                    <ItemTemplate>                  
                                                                            <asp:Label ID="type" runat="server"  Text='<%# Bind("Type") %>'/>
                                                                        </ItemTemplate>
                                                                    <ItemStyle />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="ACTION">
                                                                        <ItemTemplate>  
                                                                                <asp:Button ID="btnview" runat="server" CommandName="doView"  CommandArgument='<%# Bind("ID") %>' Text="View Submission" CssClass="btn btn-success btn-sm"/>                      
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
                        </div>
                    </div>
                    </div>
                       </div>         
    <!-- data tables -->
    <script src="../../Content/assets/plugins/datatables/jquery.dataTables.min.js" ></script>
 	<script src="../../Content/assets/plugins/datatables/plugins/bootstrap/dataTables.bootstrap4.min.js" ></script>
    <script src="../../Content/assets/js/pages/table/table_data.js" ></script>
<%-- Page Script --%>
    <script src="../../Scripts/Pages/AllSchool.js"></script>

</asp:Content>
