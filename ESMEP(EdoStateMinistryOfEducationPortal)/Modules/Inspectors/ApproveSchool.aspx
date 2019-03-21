<%@ Page Title="" Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true" CodeBehind="ApproveSchool.aspx.cs" Inherits="ESMEP_EdoStateMinistryOfEducationPortal_.Modules.Inspectors.ApproveSchool" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
     <div class="page-bar">
                        <div class="page-title-breadcrumb">
                            <div class=" pull-left">
                                <div class="page-title">Approve School</div>
                            </div>
                            <ol class="breadcrumb page-breadcrumb pull-right">
                                <li><i class="fa fa-home"></i>&nbsp;<a class="parent-item" href="#">Home</a>&nbsp;<i class="fa fa-angle-right"></i>
                                </li>
                                <li><a class="parent-item" href="#">Inspectors</a>&nbsp;<i class="fa fa-angle-right"></i>
                                </li>
                                <li class="active">Approve Schools </li>
                            </ol>
                        </div>
                    </div>
         <div class="row">
        <div class="col-sm-12 col-md-12 col-xl-12" id="PnlSchool" runat="server">
                <div class="card-box">
                    <div class="card-head">
                        <header>School</header>
				      
					</div>
                                 
                    <div class="card-body ">
                    <div class="row">
                         <asp:DropDownList runat="server" ID="ddlyear"  > </asp:DropDownList>
                        <asp:DropDownList runat="server" ID="ddlLgda"  > </asp:DropDownList>
                        <div class="col-md-6 col-sm-6 col-6">
                            <div class="btn-group">
                                <a href="../school/addstudent" id="addRow" class="btn btn-info">
                                    Add New <i class="fa fa-plus"></i>
                                </a>
                              
                            </div>
                           
                        </div>
                        <div class="col-md-6 col-sm-6 col-6">
<%--                                           <div class="btn-group pull-right">
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
                            </div>--%>
                        </div>
                    </div>
                    <div class="table-scrollable" >
                    <asp:GridView ID="tblGeneral" CssClass="table table-striped table-bordered table-hover table-checkable order-column valign-middle" OnRowCommand="tblGeneral_RowCommand"
                        AutoGenerateColumns="false" runat="server">
                        <Columns>
                            <asp:TemplateField Visible="false">
                                    <ItemTemplate>                  
                                        <asp:Label ID="lblExamId" runat="server"  Text='<%# Bind("ID") %>' Visible="false"/>
                                    </ItemTemplate>
                                <ItemStyle Width="0px" />
                            </asp:TemplateField>
                            <asp:BoundField  DataField="SN" HeaderText="#.">
                            </asp:BoundField>
                            <asp:BoundField  DataField="Name" HeaderText="Name">
                            </asp:BoundField>
                            <asp:BoundField  DataField="L.G.A" HeaderText="L.G.A">
                            </asp:BoundField>    
                            <asp:BoundField  DataField="Year" HeaderText="Year">
                            </asp:BoundField>                
                                         
                            <asp:TemplateField HeaderText="ACTION">
                                    <ItemTemplate>  
                                            <asp:Button ID="btnview" runat="server" CommandName="doView"  CommandArgument='<%# Bind("ID") %>' Text="VIEW" CssClass="btn btn-success btn-sm"/>                      
                                      <asp:Button ID="btnApprove" runat="server" CommandName="doApprove"  CommandArgument='<%# Bind("ID") %>' Text="Approve" CssClass="btn btn-primary btn-sm"/> 
                                    </ItemTemplate>
                             
                                    <ItemStyle Width="200px" />
                                </asp:TemplateField>
                            </Columns>
                    </asp:GridView>									
					</div>

                          
                    </div>
                    <asp:Label ID="lblSchoolId" runat="server" Visible="false"></asp:Label>
                </div>
            </div>

               <div class="col-sm-12 col-md-12 col-xl-12" id="panelStudent" runat="server" visible="false">
                <div class="card-box">
                    <div class="card-head">
                        <header>Students</header>
				      
					</div>
                                 
                    <div class="card-body ">
                    <div class="row">
                       
                        <div class="col-md-6 col-sm-6 col-6">
                            <div class="btn-group">
                                <a href="../school/addstudent" id="backSchool" class="btn btn-info">
                                    BACK TO LIST <i style="font-size:20px" class="fa fa-arrow-circle-o-left"></i>
                                </a>
                            </div>
                              <button id="btnApproveall" runat="server" type="submit" class="btn btn-danger"> Approve All</button>
                        </div>
                        <div class="col-md-6 col-sm-6 col-6">
<%--                                           <div class="btn-group pull-right">
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
                            </div>--%>
                        </div>
                    </div>
                                <div class="table-scrollable" >
                    <asp:GridView ID="GvStudent" CssClass="table table-striped table-bordered table-hover table-checkable order-column valign-middle" OnRowCommand="tblGeneral_RowCommand"
                        AutoGenerateColumns="false" runat="server">
                        <Columns>
                            <asp:TemplateField>
                                    <ItemTemplate>                  
                                        <asp:Label ID="lblExamId" runat="server"  Text='<%# Bind("ID") %>'/>
                                    </ItemTemplate>
                                <ItemStyle Width="0px" />
                            </asp:TemplateField>
                               <asp:TemplateField Visible="false">
                                    <ItemTemplate>                  
                                        <asp:Label ID="lblApprove" runat="server"  Text='<%# Bind("DOEAPPROVAL") %>' Visible="false"/>
                                    </ItemTemplate>
                                <ItemStyle Width="0px" />
                            </asp:TemplateField>
                             <asp:TemplateField HeaderText="Approval Status">
                            <ItemTemplate>
                                <asp:CheckBox ID="chkapprove" runat="server" />
                            </ItemTemplate>
                            <ItemStyle Width="200px" />
                        </asp:TemplateField>
                            <asp:BoundField  DataField="SN" HeaderText="#.">
                            </asp:BoundField>
                            <asp:BoundField  DataField="Name" HeaderText="Name">
                            </asp:BoundField>
                              <asp:BoundField  DataField="Batch" HeaderText="Approval Batch">
                            </asp:BoundField>
                              <asp:BoundField  DataField="Year" HeaderText="Year">
                            </asp:BoundField>
                      
                            </Columns>
                    </asp:GridView>				

                                    <button id="btnApproveselected" runat="server" type="submit" class="btn btn-danger" onserverclick="btnApproveselected_ServerClick"> Approve Selected </button>
					</div>

                    </div>
                   
                </div>
            </div>
    </div>

      <script type="text/javascript">  
    $(document).ready(function () {  
        $('#<%=tblGeneral.ClientID%>').DataTable();
         $('#<%=GvStudent.ClientID%>').DataTable();
    });  
</script>  
    <script src="../../Scripts/Pages/DataTableInitialization.js"></script>
</asp:Content>
