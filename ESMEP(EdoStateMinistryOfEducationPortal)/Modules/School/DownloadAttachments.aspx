<%@ Page Title="" Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true" CodeBehind="DownloadAttachments.aspx.cs" Inherits="ESMEP_EdoStateMinistryOfEducationPortal_.Modules.School.DownloadAttachments" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:ScriptManager runat="server" ID="ScriptManager1"></asp:ScriptManager>
      <div class="page-bar">
                <div class="page-title-breadcrumb">
                    <div class=" pull-left">
                        <div class="page-title">Document Download</div>
                    </div>
                    <ol class="breadcrumb page-breadcrumb pull-right">
                        <li>
                            <i class="fa fa-home"></i>&nbsp;<a class="parent-item" href="#">School</a>&nbsp;<i class="fa fa-angle-right"></i>
                        </li>
                        <li class="active">Download Document</li>
                    </ol>
                </div>
            </div>

       <div class="row">
		<div class="col-sm-12">
			<div class="card-box">
				<div class="card-head">
					<header>Download Document for Upload </header>
				</div>
				<div class="card-body" id="bar-parent2">
                    <div class="row">
                        <div class="col-md-12 col-sm-6">
                            <asp:Label ID="ErrorMessage" runat="server" CssClass="" ForeColor="Red" ></asp:Label>
                        </div>
<%--                     <div class="col-md-6 col-sm-6">--%>
                       <div class="form-group col-md-4 col-sm-6">
	                        <label>Select Exam</label>

                            <asp:DropDownList runat="server" ID="ddlExam" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="ddlExam_SelectedIndexChanged"></asp:DropDownList>
                           </div>
                     <div class="form-group col-md-4 col-sm-6">
	                        <label>Select Year</label>
                            <asp:DropDownList runat="server" ID="ddlYear" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="ddlYear_SelectedIndexChanged" ></asp:DropDownList>
                           </div>
                         <div class="form-group col-md-4 col-sm-6">
	                        <label>Select Subject</label>
                            <asp:DropDownList runat="server" ID="ddlSubject" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="ddlSubject_SelectedIndexChanged" ></asp:DropDownList>
                         </div>
                    </div>
                    <div class="row">
                        <asp:Label Text="" Visible="false" ID="lblExamName" runat="server" />
                    </div>

                <div class="table-scrollable row">
                    <asp:GridView ID="gvSchool" CssClass="table table-striped table-bordered table-hover table-checkable order-column valign-middle"
                        AutoGenerateColumns="false" runat="server">
                        <Columns>
                            <asp:BoundField  DataField="SN" HeaderText="#">
                            </asp:BoundField>
                            <asp:BoundField  DataField="Name" HeaderText="NAME OF CANDIDATE">
                            </asp:BoundField>
                            <asp:BoundField  DataField="Exam_NO" HeaderText="EXAM NUMBER">
                            </asp:BoundField>
                            <asp:BoundField  DataField="Present" HeaderText="PRESENT/ABSENT">
                            </asp:BoundField>                    
                            <asp:BoundField  DataField="Mark" HeaderText="MARKS">
                            </asp:BoundField>              
                            <asp:BoundField  DataField="Remarks" HeaderText="REMARKS">
                            </asp:BoundField>     
                        </Columns>
                    </asp:GridView>                    									
				</div>

                    <div class="row" id="divBtn" runat="server" visible="false">
                        <div style="clear:both" class="col-12">
                            <div class="form-group" >
                                <div class="">
                                    <asp:Button ID="btnAttendenceList" CssClass="btn btn-default m-r-20" Text="Download Attendence Sheet" runat="server" OnClick="btnAttendenceList_Click" />
                     <%--               <asp:Button Text="Download Continuous Assessment Mark Sheet " ID="btnContAssessment" CssClass="btn btn-success m-r-20" OnClick="btnContAssessment_Click" runat="server" />
                                    <asp:Button ID="btnEntry" CssClass="btn btn-warning " Text="Download Entry Schedule" runat="server" OnClick="btnEntry_Click" />--%>
                                </div>
                            </div>
                        </div>
                     </div>
                </div>
            </div>
        </div>
        </div>
    
    <script>
        function CallLoadTableFunction(e) {
            e.preventDefault();

            $.ajax({
                type: "POST",
                url: "DownloadAttachments.aspx/LoadGridView",
                data: '{Exam: "' + $("#<%=ddlExam.ClientID%>").val() + '" Session: "' + $("#<%=ddlYear.ClientID%>").val() + '" Subject: "' + $("#<%=ddlSubject.ClientID%>").val() + '" }',
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (response) {
                  if (response.d) {
                  }
                  else {

                  }
                },
                failure: function (response) {
                  $('#<%=ErrorMessage.ClientID%>').val("Error in calling Ajax:" + response.d);
                }
            })
        }
    
        //function Postback() {
        //    const exam =
        //}
    </script>
</asp:Content>
