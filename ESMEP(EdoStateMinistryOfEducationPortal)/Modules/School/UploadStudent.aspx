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
                                  
                                </div>

                                <div class="card-body " id="bar-parent">                                   
                                     <div class=" form-row form-row-seperated ">
                                         <label for="simpleFormPassword" class="col-md-3">Select Excel</label>   
                                            <input type="file" name="file" accept=".xls, .xlsx" runat="server" id="xlsxSchol" class="form-control-file dropzone-file-area form-control col-md-6" />
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
                 <asp:GridView ID="gvResult" CssClass="table table-bordered dt-responsive table-scrollable table-striped table-condensed table-hover table-responsive" AutoGenerateColumns="false" runat="server">
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
                    <asp:BoundField  DataField="Sex" HeaderText="Gender">
                    </asp:BoundField>
                    <asp:BoundField  DataField="GName" HeaderText="Guardian FullName">
                    </asp:BoundField> 
                    <asp:BoundField  DataField="GAddress" HeaderText="Guardian Address">
                    </asp:BoundField>       
                    <asp:BoundField  DataField="GPhone" HeaderText="Guardian Phone Number">
                    </asp:BoundField>                    
                    <asp:BoundField  DataField="GEmail" HeaderText="Guardian Email">
                    </asp:BoundField>     
                      <asp:BoundField  DataField="Relation" HeaderText="Relationship">
                    </asp:BoundField>     
                    </Columns>
            </asp:GridView>
           <asp:Button runat="server" ID="btnSave" Text="Save" CssClass="btn btn-warning pull-right" OnClick="btnSave_Click" />
       
            </div>
        </div>
    </div>
       </div> 
    <script src="../../Content/assets/plugins/datatables/jquery.dataTables.min.js"></script>
    <script type="text/javascript">  
    $(document).ready(function () {  
        $('#<%=gvResult.ClientID%>').DataTable({ "paging": false, "ordering": false, "searching": false });  
    });  
</script>  
</asp:Content>
