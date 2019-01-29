<%@ Page Title="" Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true" CodeBehind="UploadStudent.aspx.cs" Inherits="ESMEP_EdoStateMinistryOfEducationPortal_.Modules.School.UploadStudent" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
         <div class="page-bar">
                        <div class="page-title-breadcrumb">
                            <div class=" pull-left">
                                <div class="page-title">Upload New Students</div>
                            </div>
                            <ol class="breadcrumb page-breadcrumb pull-right">
                                <li>
                                    <i class="fa fa-home"></i>&nbsp;<a class="parent-item" href="#">Student</a>&nbsp;<i class="fa fa-angle-right"></i>
                                </li>
                                <li class="active">Add Students in Bulk</li>
                            </ol>
                        </div>
                    </div>

                <div class="row">
                        <div class="col-md-12 col-sm-6">
                            <div class="card card-box">
                                <div class="card-head">
                                    <header>Upload Student</header>
                                     <%--<button id = "panel-button" 
				                           class = "mdl-button mdl-js-button mdl-button--icon pull-right" 
				                           data-upgraded = ",MaterialButton">
				                           <i class = "material-icons">more_vert</i>
				                        </button>
				                        <ul class = "mdl-menu mdl-menu--bottom-right mdl-js-menu mdl-js-ripple-effect"
				                           data-mdl-for = "panel-button">
				                           <li class = "mdl-menu__item"><i class="material-icons">assistant_photo</i>Action</li>
				                           <li class = "mdl-menu__item"><i class="material-icons">print</i>Another action</li>
				                           <li class = "mdl-menu__item"><i class="material-icons">favorite</i>Something else here</li>
				                        </ul>--%>
                                </div>

                                <div class="card-body " id="bar-parent">                                   
                                        <div class="form-group col-md-6">
                                            <label for="simpleFormPassword">Select Excel</label>
                                            <input type="file" name="file" accept=".xls, .xlsx" runat="server" id="xlsxSchol" class="form-control-file" />
                                        </div>
                                    <asp:Button ID="btnUpload" CssClass="btn btn-primary" Text="Upload" runat="server" OnClick="btnUpload_Click" />
                                </div>
                            </div>
                        </div>
                    </div>

      <div class="row" runat="server" id="excelDiv" visible="false">
        <div class="col-md-12 col-sm-6">
            <div class="card card-box">
                <div class="card-head">
                    <header>Upload School</header>
                 <asp:GridView ID="gvResult" CssClass="table table-bordered table-scrollable table-striped table-condensed table-hover table-responsive" AutoGenerateColumns="false" runat="server">
                  <Columns>
                    <asp:BoundField  DataField="ID" HeaderText="SN">
                    </asp:BoundField>
                    <asp:BoundField  DataField="Firstname" HeaderText="First Name">
                    </asp:BoundField>       
                    <asp:BoundField  DataField="Lastname" HeaderText="Last Name">
                    </asp:BoundField>   
                    <asp:BoundField  DataField="Othername" HeaderText="Other Names">
                    </asp:BoundField>           
                    <asp:BoundField  DataField="Address" HeaderText="Address">
                    </asp:BoundField>
                    <asp:BoundField  DataField="Origin" HeaderText="State Of Origin">
                    </asp:BoundField>
                    <asp:BoundField  DataField="LGA" HeaderText="Local Government">
                    </asp:BoundField>
                    <asp:BoundField  DataField="DOB" HeaderText="Date of Birth">
                    </asp:BoundField>                   
                    <asp:BoundField  DataField="MobileNo" HeaderText="Phone Number">
                    </asp:BoundField>
                    <asp:BoundField  DataField="Type" HeaderText="Type">
                    </asp:BoundField> 
                    <asp:BoundField  DataField="Category" HeaderText="Category">
                    </asp:BoundField>       
                    <asp:BoundField  DataField="DateOfInCorporation" HeaderText="Date Of Incorporation">
                    </asp:BoundField>                    
                    <asp:BoundField  DataField="PrincipalName" HeaderText="Principal's Name">
                    </asp:BoundField>     
               
                    </Columns>
            </asp:GridView>
           <asp:Button runat="server" ID="btnSave" Text="Save" CssClass="btn btn-warning pull-right" OnClick="btnSave_Click" />
       
            </div>
        </div>
    </div>
       </div> 
</asp:Content>
