<%@ Page Title="" Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true" CodeBehind="UploadAttendance.aspx.cs" Inherits="ESMEP_EdoStateMinistryOfEducationPortal_.Modules.School.UploadAttendance" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
        <link href="../../Content/assets/plugins/dropzone/dropzone.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

                   <div class="page-bar">
                        <div class="page-title-breadcrumb">
                            <div class=" pull-left">
                                <div class="page-title"> </div>
                            </div>
                            <ol class="breadcrumb page-breadcrumb pull-right">
                                <li><i class="fa fa-home"></i>&nbsp;<a class="parent-item" href="#">Home</a>&nbsp;<i class="fa fa-angle-right"></i>
                                </li>
                                <li><a class="parent-item" href="#">Reuslt</a>&nbsp;<i class="fa fa-angle-right"></i>
                                </li>
                                <li class="active">Upload</li>
                            </ol>
                        </div>
                    </div>

                    <div class="row">
                        <div class="col-md-12 col-sm-6">
                            <div class="card card-box">
                                <div class="card-head">
                                    <header>Upload Attendance</header>                                  
                                </div>
                                <div class="card-body " id="bar-parent">
                                    <div class="row">                                    
                                            <div class="col-md-12 col-sm-6">
                                                <asp:Label ID="ErrorMessage" runat="server" CssClass="" ForeColor="Red" ></asp:Label>
                                            </div>
                    <%--                     <div class="col-md-6 col-sm-6">--%>
                                        <div class=" col-md-4 col-sm-6">
	                                            <label>Select Exam</label>
                                                <asp:DropDownList runat="server" ID="ddlExam" CssClass="form-control"></asp:DropDownList>
                                            </div>
                                        
                                        <div class=" col-md-4 col-sm-6">
	                                            <label>Select Year</label>
                                                <asp:DropDownList runat="server" ID="ddlYear" CssClass="form-control" ></asp:DropDownList>
                                               </div>

                                        <div class="col-md-4 col-sm-6">
	                                            <label>Select Subject</label>
                                                <asp:DropDownList runat="server" ID="ddlSubject" CssClass="form-control"  ></asp:DropDownList>
                                             </div>
                                      </div>

                                              <div class="row" style="clear:both">
                                                     <label for="simpleFormPassword">  :</label>
                                              </div>
                                    <div class="row">
<%--                                                       <label for="simpleFormPassword">  Select Excel</label>                                                                                           <label for="simpleFormPassword">  :</label>--%>
                                         <div id="upload" class="form-group col-md-6 col-md-6">
                                                <input type="file" name="file" accept=".xls, .xlsx" runat="server" id="xlsxSchol" class=" dropzone-file-area" />
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
                    <header> Attendance For <asp:Label ID="lblSubject" Text="" runat="server" /></header>
            
                <div class="table-scrollable row">
                    <asp:GridView ID="gvResults" CssClass="table dt-responsive table-striped table-bordered table-hover table-checkable order-column valign-middle"
                        AutoGenerateColumns="false" runat="server">
                        <Columns>
                            <asp:BoundField  DataField="STUDENTID" HeaderText="#">
                            </asp:BoundField>
                            <asp:BoundField  DataField="SN" HeaderText="#">
                            </asp:BoundField>
                            <asp:BoundField  DataField="FULLNAME" HeaderText="NAME OF CANDIDATE">
                            </asp:BoundField>
                            <asp:BoundField  DataField="EXAM_NO" HeaderText="EXAM NUMBER">
                            </asp:BoundField>
                            <asp:BoundField  DataField="PRESENT" HeaderText="PRESENT/ABSENT">
                            </asp:BoundField>                    
                            <asp:BoundField  DataField="MARK" HeaderText="MARKS">
                            </asp:BoundField>              
                            <asp:BoundField  DataField="REMARKS" HeaderText="REMARKS">
                            </asp:BoundField>     
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
