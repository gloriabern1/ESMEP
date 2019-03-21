<%@ Page Title="" Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true" CodeBehind="DownloadEntrySchedule.aspx.cs" Inherits="ESMEP_EdoStateMinistryOfEducationPortal_.Modules.School.DownloadEntrySchedule" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style> 
        .a {
              -ms-transform: rotate(20deg); /* IE 9 */
              -webkit-transform: rotate(20deg); /* Safari 3-8 */
              transform: rotate(270deg);
            }
</style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
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
    <asp:ScriptManager runat="server" ID="ScriptManager1" />

       <div class="row">
	    	<div class="col-sm-12">
			<div class="card-box">
				<div class="card-head">
					<header>Download Entry Schedule for Upload </header>
				</div>
				<div class="card-body" id="bar-parent2">
                    <div class="row">
                        <div class="col-md-12 col-sm-6">
                            <asp:Label ID="ErrorMessage" runat="server" CssClass="" ForeColor="Red" ></asp:Label>
                        </div>
                       <div class="form-group col-md-6 col-sm-6">
	                        <label>Select Exam</label>

                            <asp:DropDownList runat="server" ID="ddlExam" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="ddlExam_SelectedIndexChanged"></asp:DropDownList>
                           </div>
                     <div class="form-group col-md-6 col-sm-6">
	                        <label>Select Year</label>
                            <asp:DropDownList runat="server" ID="ddlYear" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="ddlYear_SelectedIndexChanged" ></asp:DropDownList>
                           </div>                       
                    </div>
                    <div class="row">
                        <asp:Label Text="" Visible="false" ID="lblExamName" runat="server" />
                    </div>
                     <div runat="server" id="divSec" visible="false">

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
                                        <asp:BoundField HeaderStyle-CssClass="a" DataField="sex" HeaderText="SEX">
                                        </asp:BoundField>                    
                                        <asp:BoundField  HeaderStyle-CssClass="a" DataField="Eng" HeaderText="ENG. STUDIES">
                                        </asp:BoundField>              
                                        <asp:BoundField HeaderStyle-CssClass="a" DataField="Maths" HeaderText="MATHS">
                                        </asp:BoundField>   
                                        <asp:BoundField HeaderStyle-CssClass="a" HeaderStyle-Height="80px" DataField="SciTech" HeaderText="BASIC SCIENCE & TECHNOLOGY">
                                        </asp:BoundField>
                                        <asp:BoundField HeaderStyle-CssClass="a" DataField="Rel" HeaderText="RELIGION & NATIONAL VALUES">
                                        </asp:BoundField>                    
                                        <asp:BoundField HeaderStyle-CssClass="a" HeaderStyle-Width="20px" DataField="Arts" HeaderText="CULTURAL & CREATIVE ARTS">
                                        </asp:BoundField>              
                                        <asp:BoundField HeaderStyle-CssClass="a"  DataField="Nig" HeaderText="NIGERIA LANGUAGE(EDO)">
                                        </asp:BoundField>     
                                        <asp:BoundField HeaderStyle-CssClass="a" DataField="Pre" HeaderText="PRE-VOCATIONAL">
                                        </asp:BoundField>
                                        <asp:BoundField HeaderStyle-CssClass="a" DataField="French" HeaderText="FRENCH LANGUAGE">
                                        </asp:BoundField>              
                                        <asp:BoundField HeaderStyle-CssClass="a" DataField="Bus" HeaderText="BUSINESS STUDIES">
                                        </asp:BoundField>              
                                        <asp:BoundField HeaderStyle-CssClass="a" DataField="Arabic" HeaderText="ARABIC">
                                        </asp:BoundField>   
                                        <asp:BoundField  DataField="Pratical" HeaderText="PRATICAL 5MRKS">
                                        </asp:BoundField>              
                                        <asp:BoundField  DataField="Num" HeaderText="NO OF SUBJECTS ENTERED FOR">
                                        </asp:BoundField>   
                                        <asp:BoundField  DataField="Sign" HeaderText="STUDENTS SIGNATURE">
                                        </asp:BoundField>              
                                        <asp:BoundField  DataField="Remarks" HeaderText="REMARKS">
                                        </asp:BoundField>   
                                    </Columns>
                                </asp:GridView>                    									
				            </div>

                            <div class="row">
                                <div style="clear:both" class="col-12">
                                    <div class="form-group" >
                                        <div class="">
                                            <asp:Button ID="btnSecEntry" CssClass="btn btn-default m-r-20" Text="Download Entry Schedule" runat="server" OnClick="btnSecEntry_Click" />
                                        </div>
                                    </div>
                                </div>
                              </div>
                        </div>
                 
                     <div runat="server" id="divPri" visible="false">
                  
                          <div class="table-scrollable row">
                            <asp:GridView ID="gvPrimary" CssClass="table table-striped table-bordered table-hover table-checkable order-column valign-middle"
                                AutoGenerateColumns="false" runat="server">
                                <Columns>
                                    <asp:BoundField  DataField="SN" HeaderText="#">
                                    </asp:BoundField>
                                    <asp:BoundField  DataField="Name" HeaderText="NAME OF CANDIDATE">
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Exam NO" HeaderText="EXAM NUMBER">
                                    </asp:BoundField>
                                    <asp:BoundField HeaderStyle-CssClass="a" DataField="sex" HeaderText="SEX">
                                    </asp:BoundField>                    
                                    <asp:BoundField HeaderStyle-CssClass="a" ItemStyle-Width="20px" HeaderStyle-Width="20px" DataField="Eng" HeaderText="ENG. STUDIES">
                                    </asp:BoundField>              
                                    <asp:BoundField HeaderStyle-CssClass="a" DataField="Maths" HeaderText="MATHS">
                                    </asp:BoundField>   
                                    <asp:BoundField HeaderStyle-CssClass="a" ItemStyle-Width="20px" HeaderStyle-Width="20px"  DataField="Gen" HeaderText="Gen. STUDIES">
                                    </asp:BoundField>
                                    <asp:BoundField HeaderStyle-CssClass="a"  DataField="C.R.S" HeaderText="C.R.S">
                                    </asp:BoundField>                    
                                    <asp:BoundField HeaderStyle-CssClass="a"  DataField="I.R.S" HeaderText="I.R.S">
                                    </asp:BoundField>            
                                    <asp:BoundField HeaderStyle-CssClass="a" ItemStyle-Width="20px" HeaderStyle-Width="20px" DataField="VOC" HeaderText="VOC. STUDIES">
                                    </asp:BoundField>      
                                    <asp:BoundField HeaderStyle-CssClass="a" HeaderStyle-Height="80px" HeaderStyle-Width="20px" DataField="Num" HeaderText="NO OF SUBJECTS ENTERED FOR">
                                    </asp:BoundField>   
                                    <asp:BoundField HeaderStyle-CssClass="a" HeaderStyle-Width="10px" DataField="Sign" HeaderText="STUDENTS SIGNATURE">
                                    </asp:BoundField>              
                                    <asp:BoundField HeaderStyle-CssClass="a" DataField="Remarks" HeaderText="REMARKS">
                                    </asp:BoundField>   
                                </Columns>
                            </asp:GridView>                    									
				        </div>
                    
                           <div class="row">
                                <div style="clear:both" class="col-12">
                                    <div class="form-group" >
                                        <div class="">
                                            <asp:Button ID="btnPriEntry" CssClass="btn btn-default m-r-20" Text="Download Entry Schedule" runat="server" OnClick="btnPriEntry_Click" />
                                        </div>
                                    </div>
                                </div>
                             </div>
                     </div>
                </div>
            </div>
        </div>
        </div>
</asp:Content>
