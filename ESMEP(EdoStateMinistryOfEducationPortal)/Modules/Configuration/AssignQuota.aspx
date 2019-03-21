<%@ Page Title="" Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true" CodeBehind="AssignQuota.aspx.cs" Inherits="ESMEP_EdoStateMinistryOfEducationPortal_.Modules.Configuration.AssignQuota" %>
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
                <li><a class="parent-item" href="#">quota</a>&nbsp;<i class="fa fa-angle-right"></i>
                </li>
                <li class="active">Assign Quota</li>
            </ol>
        </div>
    </div>
    
  <div class="row">
      <div class="col-md-12 col-sm-12">
		<div class="card-box">
			<div class="card-head">
				<header>Assign Quota To School</header>
			</div>
            <div class="card-body " id="bar-parent2">
                <div class="row">
            <div class="col-md-12 col-sm-6 center"> 
                        <asp:Label ID="ErrorMessage" runat="server" CssClass="" ForeColor="Red"></asp:Label>
	            </div>
	            <div class="col-md-6 col-sm-6"> 
                    <div class="form-group">
	                    <label>Select Local Government</label>
	                    <asp:DropDownList runat="server" ID="ddlLocalGovt" AutoPostBack="true" OnSelectedIndexChanged="ddlLocalGovt_SelectedIndexChanged" CssClass="form-control"></asp:DropDownList>
	                </div>		
                </div>	    

             <div class="col-md-6 col-sm-6"> 
               <div class="form-group">
	                <label>Select Year</label>
	                <asp:DropDownList runat="server" ID="ddlYear" CssClass="form-control"></asp:DropDownList>
	            </div>		
            </div>
        <div class="col-md-6 col-sm-6"> 
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
                    <asp:BoundField  DataField="Inspector" HeaderText="INSPECTOR">
                    </asp:BoundField>                    
                    <asp:TemplateField Visible="false">
                            <ItemTemplate>                  
                                <asp:Label ID="txtAssignQuota" runat="server" CssClass="form-control"  Text=""/>
                            </ItemTemplate>
                        <ItemStyle Width="0px" />
                    </asp:TemplateField>   
                    
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
                                     <div class="col-md-6 col-sm-6"> 
                    <div class="form-group">
	                    <label>Select School</label>
	                    <asp:DropDownList runat="server" ID="ddlSchool" CssClass="form-control"></asp:DropDownList>
	                </div>		
                </div>

            <div class="col-md-6 col-sm-6"> 
                    <div class="form-group">
	                    <label>Number of Student(Quota)</label>
	                    <input type="number" runat="server" id="txtQuota" class="form-control" placeholder="000" aria-valuemin="0" min="0">
	                </div>
                </div>

             <div class="col-md-6 col-sm-6"> 
                 </div>

            <div class="col-md-12">
              <div class="form-group pull-right" style="clear:both">
                  <asp:Button runat="server" ID="btnSumbit" CssClass="btn btn-info m-r-20" OnClick="btnSubmit_Click" Text="Submit" />
<%--                 <button type="submit" runat="server" class="btn btn-info m-r-20" onclick="btnSubmit_Click">Submit</button>--%>
				</div>
			</div>
		</div>
	</div>
   </div>
  </div>
 </div>     
</asp:Content>
