<%@ Page Title="" Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true" CodeBehind="AllInspectors.aspx.cs" Inherits="ESMEP_EdoStateMinistryOfEducationPortal_.Modules.Inspectors.LgaInspector"%>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
            <link href="../../Content/assets/plugins/datatables/plugins/bootstrap/dataTables.bootstrap4.min.css" rel="stylesheet" type="text/css"/>
    <link href="../../sweetalert2.min.css" rel="stylesheet" />
    <script src="../../sweetalert2.min.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
                       
    <asp:MultiView ID="Multiview1" runat="server">

        <asp:View runat="server" ID="View0">   
               <div class="page-bar">
        <div class="page-title-breadcrumb">
            <div class=" pull-left">
                <div class="page-title">All Inspector</div>
            </div>
            <ol class="breadcrumb page-breadcrumb pull-right">
                <li><i class="fa fa-home"></i>&nbsp;<a class="parent-item" href="#">Home</a>&nbsp;<i class="fa fa-angle-right"></i>
                </li>
                <li><a class="parent-item" href="#">Inspector</a>&nbsp;<i class="fa fa-angle-right"></i>
                </li>
                <li class="active">Inspector List</li>
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

                            <div class="table-scrollable">

                            <asp:GridView ID="gvInspector" CssClass="table table-striped table-bordered table-hover table-checkable order-column valign-middle" OnRowCommand="gvInspector_RowCommand" AutoGenerateColumns="false" runat="server">
                                <Columns>
                                    <asp:BoundField  DataField="Id" HeaderText="#.">
                                    </asp:BoundField>
                                         <asp:TemplateField Visible="false">
                                          <ItemTemplate>                  
                                             <asp:Label ID="name" runat="server"  Text='<%# Bind("Name") %>' Visible="false"/>
                                          </ItemTemplate>
                                        <ItemStyle Width="2px" />
                                    </asp:TemplateField>
                                    <asp:BoundField  DataField="Name" HeaderText="Chief Inspector">
                                    </asp:BoundField>
                                    <asp:BoundField  DataField="LocalGovtName" HeaderText="LocalGovernment">
                                    </asp:BoundField>    
                                    <asp:TemplateField HeaderText="ACTION">
                                            <ItemTemplate>  
                                                    <asp:Button ID="btnview" runat="server" CommandName="doView"  CommandArgument='<%# Bind("LgaId") %>' Text="VIEW" CssClass="btn btn-success btn-sm"/>                      
                                                    <asp:Button ID="btnAdd" runat="server" CommandName="create"  CommandArgument='<%# Bind("LgaId") %>' Text="Add An Inspector" CssClass="btn btn-success btn-sm"/>                 
                                                </ItemTemplate>
                                            <ItemStyle Width="20px" />
                                        </asp:TemplateField>
               <%--                     <asp:TemplateField HeaderText="ACTION">
                                            <ItemTemplate>  
                                                    <asp:Button ID="btnAdd" runat="server" CommandName="create"  CommandArgument='<%# Bind("LgaId") %>' Text="Add An Inspector" CssClass="btn btn-success btn-sm"/>                      
                                            </ItemTemplate>
                                            <ItemStyle Width="20px" />
                                        </asp:TemplateField>--%>
                                    </Columns>
                            </asp:GridView>									
					        </div>
                            </div>
                    </div>
                    </div>
         </div>
       </div>
        </asp:View>

        <asp:View runat="server" ID="View1">
               <div class="page-bar">
        <div class="page-title-breadcrumb">
            <div class=" pull-left">
                <div class="page-title">ADD Chief Inspector</div>
            </div>
            <ol class="breadcrumb page-breadcrumb pull-right">
                <li><i class="fa fa-home"></i>&nbsp;<a class="parent-item" href="#">Inspector</a>&nbsp;<i class="fa fa-angle-right"></i>
                </li>
                <li class="active">Add Inspector</li>
            </ol>
        </div>
    </div>

    <div class="row">
		<div class="col-sm-12">
			<div class="card-box">
				<div class="card-head">
					<header>Create Chief Inspector </header>
				</div>
				<div class="card-body" id="bar-parent2">
                    <div class="row">
                        <div class="col-md-12 col-sm-6">
                            <asp:Label ID="ErrorMessage" runat="server" CssClass="" ForeColor="Red"></asp:Label>
                        </div>
<%--                     <div class="col-md-6 col-sm-6">--%>
                       <div class="form-group col-md-6 col-sm-6">
	                        <label>Select Title</label>
                            <asp:DropDownList runat="server" ID="ddlTitle" CssClass="form-control" ></asp:DropDownList>
                           </div>
                       <div class="form-group col-md-6 col-sm-6">
	                        <label>First Name</label>
	                        <input type="text" class="form-control" runat="server" id="txtFname" placeholder="Enter First Name" required="">
	                    </div>
                       <div class="form-group col-md-6 col-sm-6">
	                        <label>Last Name</label>
	                        <input type="text" class="form-control" runat="server" id="txtLname" placeholder="Enter Last Name" required="required">
	                    </div>
                       <div class="form-group col-md-6 col-sm-6">
	                        <label>Other Name</label>
	                        <input type="text" class="form-control" runat="server" id="txtOname" placeholder="Enter Other Name">
	                    </div>

                     <div class="form-group col-md-6 col-sm-6">
                        <label for="username">Email address/Username</label>
                        <input type="email" class="form-control" runat="server" id="username" placeholder="Enter email address">
                    </div>

                    <div class="form-group col-md-6 col-sm-6">
                        <label for="password">Password</label>
                        <input type="password" class="form-control" runat="server" id="password" placeholder="Password">
                    </div>

                    <div class="form-group col-md-6 col-sm-6">
                        <label for="confirmPassword">Confirm Password</label>
                        <input type="password" class="form-control" runat="server" id="confirmPassword" placeholder="Confirm Password">
                    </div>

                        <div style="clear:both" class="col-12">
                            <div class="form-group" >
                                <div class="">
                                    <asp:Button ID="btnSubmit" CssClass="btn btn-info m-r-20" Text="Submit" runat="server" OnClick="btnSubmit_Click" />
                                    <asp:Button Text="Back " ID="btnBack" CssClass="btn btn-default" OnClick="btnBack_Click" runat="server" />
                                </div>
                            </div>
                        </div>
                 </div>
				</div>
               </div>           
             </div>
       </div>
            <asp:Label Text="" ID="lblLgaId" Visible="false" runat="server" />
        </asp:View>
    </asp:MultiView>

        <script src="../../Content/assets/plugins/datatables/jquery.dataTables.min.js" ></script>
 	<script src="../../Content/assets/plugins/datatables/plugins/bootstrap/dataTables.bootstrap4.min.js" ></script>
    <script src="../../Content/assets/js/pages/table/table_data.js" ></script>
    
    <script src="../../Scripts/Pages/DataTableInitialization.js"></script>
    <script src="../../Scripts/Pages/Inspector/Inspector.js"></script>  
        <script src="../../Scripts/Pages/sweetalert.js"></script>

    <script>
        function success() {
            swal(
                'Good job!',
                'Inspector Added Successfully',
                'success'
            )
        }

        function error() {
            swal(
                'Failed',
                'Inspector was not Added',
                'error'
            )
        }
    </script>
    
</asp:Content>
