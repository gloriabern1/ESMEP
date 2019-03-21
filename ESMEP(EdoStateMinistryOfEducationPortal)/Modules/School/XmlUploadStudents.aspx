<%@ Page Title="" Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true" CodeBehind="XmlUploadStudents.aspx.cs" Inherits="ESMEP_EdoStateMinistryOfEducationPortal_.Modules.School.XmlUploadStudents" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<div class="page-bar">
        <div class="page-title-breadcrumb">
            <div class=" pull-left">
                <div class="page-title">Upload Students</div>
            </div>
            <ol class="breadcrumb page-breadcrumb pull-right">
                <li><i class="fa fa-home"></i>&nbsp;<a class="parent-item" href="#">Home</a>&nbsp;<i class="fa fa-angle-right"></i>
                </li>
                <li><a class="parent-item" href="#">Students</a>&nbsp;<i class="fa fa-angle-right"></i>
                </li>
                <li class="active">Upload Student</li>
            </ol>
        </div>
    </div>
<div class="row">
  <div class="col-md-12 col-sm-6">
    <div class="card card-box">
        <div class="card-head">
            <header>Upload Student From XML</header>                                  
        </div>
        <div class="card-body " id="bar-parent">
            <div class="row">                                    
                    <div class="col-md-12 col-sm-6">
                        <asp:Label ID="ErrorMessage" runat="server" CssClass="" ForeColor="Red" ></asp:Label>
                    </div>
    
<%--                    <div class=" col-md-4 col-sm-6">
	                        <label>Select Year</label>
                            <asp:DropDownList runat="server" ID="ddlYear" CssClass="form-control" ></asp:DropDownList>
                            </div>--%>
                            <div id="upload" class="form-group col-md-6 col-md-6">
                            <input type="file" name="file" accept=".xml" runat="server" id="xlsxSchol" class=" dropzone-file-area" />
                            </div>
                        </div>                       
                <div style="clear:both" class="col-12">
                <div class="form-group" >
                <asp:Button ID="btnUpload" CssClass="btn btn-primary pull-right" Text="Upload" runat="server" OnClick="btnUpload_Click" />
            </div>
            </div>
                </div>
        </div>
    </div>
</div>
          <div class="row" runat="server" id="excelDiv" visible="false">

          <div class="col-md-12 col-sm-6">
            <div class="card card-box">
                <div class="card-head">
                    <header> Attendance For <asp:Label ID="lblSubject" runat="server" /></header>
            <asp:Label ID="lblFileName" Visible="false" runat="server" />
                <div class="table-scrollable row">
                    <asp:GridView ID="gvResults" CssClass="table dt-responsive table-striped table-bordered table-hover table-checkable order-column valign-middle"
                      AutoGenerateColumns="false" runat="server">
                      <Columns>
                     <asp:BoundField  DataField="ID" Visible="false" HeaderText="">
                      </asp:BoundField> 
                      <asp:BoundField  DataField="SN" HeaderText="#">
                      </asp:BoundField> 
                        <asp:BoundField  DataField="REG_NUM" HeaderText="Reg Number">
                       </asp:BoundField>
                          <asp:BoundField  DataField="FULLNAME" HeaderText="FULLNAME">
                      </asp:BoundField> 
                        <asp:BoundField  DataField="DATE_OF_BIRTH" HeaderText="DATE OF BIRTH">
                       </asp:BoundField>
                          <asp:BoundField  DataField="GENDER" HeaderText="GENDER">
                      </asp:BoundField> 
                        <asp:BoundField  DataField="EXAM_YEAR" HeaderText="EXAM YEAR">
                       </asp:BoundField>
                          <asp:BoundField  DataField="ADDRESS" HeaderText="ADDRESS">
                      </asp:BoundField> 
                      <asp:BoundField DataField="PICTURES" HeaderText="Image" HtmlEncode="false" />
                      </Columns>
                    </asp:GridView>                    									
				</div>
              
                <div style="clear:both" class="col-12">
                   <div class="form-group" >
                     <asp:Button runat="server" ID="btnSave" Text="Save" CssClass="btn btn-warning pull-right" OnClick="btnSave_Click" />       
                    </div>
                </div>
               </div>
        </div>
    </div>
        </div>

       <script src="../../Content/assets/plugins/dropzone/dropzone.js"></script>
    <script src="../../Content/assets/plugins/datatables/jquery.dataTables.min.js"></script>
    <script>
        $(document).ready(function () {  
            $('#MainContent_xlsxSchol').dropzone();
        });
    </script>
    <script type="text/javascript">  
    $(document).ready(function () {  
        $('#<%=gvResults.ClientID%>').DataTable();  
    });  
</script>  
</asp:Content>
