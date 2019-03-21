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
    <div class="col-md-12">
        <div class="tabbable-line">
            <ul class="nav customtab nav-tabs" role="tablist">
	            <li class="nav-item"><a href="#tab1" class="nav-link active"  data-toggle="tab" >Primary School List</a></li>
	            <li class="nav-item"><a href="#tab2" class="nav-link" data-toggle="tab">Secondary School List</a></li>
	        </ul>
            <div class="tab-content">
                  <div class="tab-pane active fontawesome-demo" id="tab1">
                      <div class="row">
                           <div class="col-md-12 col-sm-6">
                        <div class="card card-box">
                            <div class="card-head">
                                <header>Schools</header>
                                <div class="tools">
                                    <a class="fa fa-repeat btn-color box-refresh" href="javascript:;"></a>
	                                <a class="t-collapse btn-color fa fa-chevron-down" href="javascript:;"></a>
	                                <a class="t-close btn-color fa fa-times" href="javascript:;"></a>
                                </div>
                            </div>
                            <div class="card-body" id="line-parent">
                                    <asp:MultiView ID="Multiview0" runat="server">
                                        <asp:View runat="server" ID="View0">

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
                             
                                            </asp:View>
                            
                                            <asp:View runat="server" ID="View1">
                                                  <div class="row">
                                                      <div class="col-md-12">
  								                      <div class="panel tab-border card-box">
                                                <header class="panel-heading panel-heading-gray custom-tab ">
                                                    <ul class="nav nav-tabs">
                                                        <li class="nav-item"><a href="#attendance" data-toggle="tab" class="active">Attendance List</a>
                                                        </li>
                                                        <li class="nav-item"><a href="#entry" data-toggle="tab">Entry Schedule</a>
                                                        </li>
                                                    </ul>
                                                </header>
                                                    <div class="panel-body">
                                                        <div class="tab-content">
                                                            <div class="tab-pane active" id="attendance">   
                                                            <%--      <div class="card-body" id="bar-parent2">--%>
                                                                    <div class="row">
                                                                            <div class="col-md-12 col-sm-6">
                                                                                <asp:Label ID="ErrorMessage" runat="server" CssClass="" ForeColor="Red" ></asp:Label>
                                                                            </div>
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
                        <%--                                                 </div>                                  --%>
                                                                <div class="table-scrollable row">
                                                            <asp:GridView ID="gvAttendance" CssClass="table table-striped table-bordered table-hover table-checkable order-column valign-middle"
                                                                AutoGenerateColumns="false" runat="server">
                                                                <Columns>              
                                                                    <asp:TemplateField HeaderText="ID" Visible="false">
                                                                    <ItemTemplate>                  
                                                                        <asp:Label ID="lblID" runat="server"  Text='<%# Bind("ID") %>' Visible="false"/>
                                                                    </ItemTemplate>
                                                                <ItemStyle />
                                                            </asp:TemplateField>
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
                                                                        <asp:TemplateField HeaderText="Approved">
                                                                        <ItemTemplate>                  
                                                                            <asp:Label ID="lblStatus" runat="server"  Text='<%# Bind("Status") %>'/>
                                                                        </ItemTemplate>
                                                                    <ItemStyle />
                                                                </asp:TemplateField> 
                                                                </Columns>
                                                            </asp:GridView>                    									
				                                        </div>

                                                            <div class="row" id="divBtn" runat="server" visible="false">
                                                                <div style="clear:both" class="col-12">
                                                                    <div class="form-group" >
                                                                        <div class="">
                                                                            <asp:Button ID="btnAttendApprove" CssClass="btn btn-default m-r-20" Text="Approve" runat="server" OnClick="btnAttendApprove_Click" />
                                                                                <asp:Button ID="btnAttendReject" CssClass="btn btn-default m-r-20" Text="Reject" runat="server" OnClick="btnAttendReject_Click" />
                                                                        </div>
                                                                    </div>
                                                                </div>
                                                                </div>              
                                                            </div>

                                                        <div class="tab-pane" id="entry">
                                                                  <div class="row">
                                                                    <div class="col-md-12 col-sm-6">
                                                                        <asp:Label ID="Label2" runat="server" CssClass="" ForeColor="Red" ></asp:Label>
                                                                    </div>
                                                                    <div class="form-group col-md-6 col-sm-6">
	                                                                    <label>Select Exam</label>

                                                                        <asp:DropDownList runat="server" ID="ddlExam2" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="ddlExam_SelectedIndexChanged"></asp:DropDownList>
                                                                        </div>
                                                                    <div class="form-group col-md-6 col-sm-6">
	                                                                    <label>Select Year</label>
                                                                        <asp:DropDownList runat="server" ID="ddlYear2" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="ddlYear_SelectedIndexChanged" ></asp:DropDownList>
                                                                        </div>                       
                                                                </div>

                                                            <div class="table-scrollable row">
                                                                <asp:GridView ID="GridView2" CssClass="table table-striped table-bordered table-hover table-checkable order-column valign-middle"
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
                                                                            <asp:TemplateField HeaderText="Approved">
                                                                    <ItemTemplate>                  
                                                                        <asp:Label ID="lblStatus" runat="server"  Text='<%# Bind("STATUS") %>'/>
                                                                    </ItemTemplate>
                                                                <ItemStyle />
                                                            </asp:TemplateField> 
                                                                    </Columns>
                                                                </asp:GridView>                    									
				                                            </div>
                    
                                                                <div class="row" id="divBtnEntry" runat="server" visible="false">
                                                                    <div style="clear:both" class="col-12">
                                                                        <div class="form-group" >
                                                                            <div class="">
                                                                                <asp:Button ID="btnPriEntryAprove" CssClass="btn btn-default m-r-20" Text="Approve Entry Schedule"      runat="server" OnClick="btnPriEntryAprove_Click" />
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
                                            </asp:View>
                                            </asp:MultiView>
                            </div>
                        </div>
                      </div>
                    </div>                       
                </div>
                 <div class="tab-pane fontawesome-demo" id="tab2">
                     <div class="row">
                       <div class="col-md-12 col-sm-6">
                        <div class="card card-box">
                            <div class="card-head">
                                <header>Schools</header>
                                <div class="tools">
                                    <a class="fa fa-repeat btn-color box-refresh" href="javascript:;"></a>
	                                <a class="t-collapse btn-color fa fa-chevron-down" href="javascript:;"></a>
	                                <a class="t-close btn-color fa fa-times" href="javascript:;"></a>
                                </div>
                            </div>
                            <div class="card-body" id="line-parent1">
  		                      
                            <asp:MultiView ID="Multiview1" ActiveViewIndex="0" runat="server">
                                <asp:View runat="server" ID="View2">
                                    <div class="table-scrollable row">
                                      <div class="col-md-12">
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
                                  </asp:View>
                                    
                                   <asp:View runat="server" ID="View3">
                                      <div class="row">
                                        <div class="col-md-12 col-sm-6">
                                         <div class="card-body" id="line-parent2">
  								                  <div class="panel tab-border card-box">
                                                    <header class="panel-heading panel-heading-gray custom-tab ">
                                                        <ul class="nav nav-tabs">
                                                            <li class="nav-item"><a href="#attendanceSec" data-toggle="tab" class="active">Primary</a>
                                                            </li>
                                                            <li class="nav-item"><a href="#entryPri" data-toggle="tab">Secondary</a>
                                                            </li>
                                                        </ul>
                                                    </header>
                                             <div class="panel-body">
                                                 <div class="tab-content">
                                                   <div class="tab-pane active" id="attendanceSec">   
                                                     <div class="panel-body" style="height:400px; overflow-y:auto;">                                                  
                                                           <div class="row">
                                                                <div class="col-md-12 col-sm-6">
                                                                    <asp:Label ID="Label1" runat="server" CssClass="" ForeColor="Red" ></asp:Label>
                                                                </div>
                                                               <div class="form-group col-md-4 col-sm-6">
	                                                                <label>Select Exam</label>

                                                                    <asp:DropDownList runat="server" ID="ddlExam1" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="ddlExam1_SelectedIndexChanged"></asp:DropDownList>
                                                                   </div>
                                                             <div class="form-group col-md-4 col-sm-6">
	                                                                <label>Select Year</label>
                                                                    <asp:DropDownList runat="server" ID="ddlYear1" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="ddlYear1_SelectedIndexChanged" ></asp:DropDownList>
                                                                   </div>
                                                                 <div class="form-group col-md-4 col-sm-6">
	                                                                <label>Select Subject</label>
                                                                    <asp:DropDownList runat="server" ID="ddlSubject1" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="ddlSubject1_SelectedIndexChanged" ></asp:DropDownList>
                                                                 </div>
                                                            </div>      

                                                      <div class="table-scrollable row">
                                                          <div class="col-md-12">
                                                        <asp:GridView ID="gvAttendance1" CssClass="table table-striped table-bordered table-hover table-checkable order-column valign-middle"
                                                            AutoGenerateColumns="false" runat="server">
                                                            <Columns>
                                                                <asp:TemplateField HeaderText="ID" Visible="false">
                                                                            <ItemTemplate>                  
                                                                                <asp:Label ID="lblID" runat="server"  Text='<%# Bind("ID") %>' Visible="false"/>
                                                                            </ItemTemplate>
                                                                        <ItemStyle />
                                                                    </asp:TemplateField>
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
                                                                <asp:TemplateField HeaderText="Approved">
                                                                            <ItemTemplate>                  
                                                                                <asp:Label ID="lblStatus" runat="server"  Text='<%# Bind("STATUS") %>'/>
                                                                            </ItemTemplate>
                                                                        <ItemStyle />
                                                                    </asp:TemplateField>     
                                                            </Columns>
                                                        </asp:GridView>                    									
				                                         </div>
                                                      </div>

                                                <div class="row" id="divBtn1" runat="server" visible="false">
                                                    <div style="clear:both" class="col-12">
                                                        <div class="form-group" >
                                                            <div class="">
                                                                <asp:Button ID="btnSecAttendApprove" CssClass="btn btn-default m-r-20" Text="Approve" runat="server" OnClick="btnSecAttendApprove_Click"/>
                                                                    <asp:Button ID="btnSecAttendReject" CssClass="btn btn-default m-r-20" Text="Reject" runat="server" OnClick="btnSecAttendReject_Click"/>
                                                            </div>
                                                        </div>
                                                    </div>
                                                    </div>              
                                        </div>
                                        </div>
                                        <div class="tab-pane" id="entryPri">
                                        <div class="panel-body" style="height:400px; overflow-y:auto;">                  
                                                      
                                    <div class="table-scrollable row">
                                          <div class="row">
                                            <div class="col-md-12 col-sm-6">
                                                <asp:Label ID="Label3" runat="server" CssClass="" ForeColor="Red" ></asp:Label>
                                            </div>
                                            <div class="form-group col-md-6 col-sm-6">
	                                            <label>Select Exam</label>

                                                <asp:DropDownList runat="server" ID="ddlExam3" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="ddlExam_SelectedIndexChanged"></asp:DropDownList>
                                                </div>
                                            <div class="form-group col-md-6 col-sm-6">
	                                            <label>Select Year</label>
                                                <asp:DropDownList runat="server" ID="ddlYear3" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="ddlYear_SelectedIndexChanged" ></asp:DropDownList>
                                                </div>                       
                                        </div>

                                        <div class="col-md-12">
                                        <asp:GridView ID="GridView4" CssClass="table table-striped table-bordered table-hover table-checkable order-column valign-middle"
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
                                                  <asp:TemplateField HeaderText="Approved">
                                                        <ItemTemplate>                  
                                                            <asp:Label ID="lblStatus" runat="server"  Text='<%# Bind("STATUS") %>'/>
                                                        </ItemTemplate>
                                                    <ItemStyle />
                                                </asp:TemplateField>
                                            </Columns>
                                        </asp:GridView>                    									
				                    </div>
                                </div>
                                    <div class="row">
                                        <div style="clear:both" class="col-12">
                                            <div class="form-group" >
                                                <div class="">
                                                    <asp:Button ID="btnSecEntryApprove" CssClass="btn btn-default m-r-20" Text="Approved" runat="server" OnClick="btnSecEntryApprove_Click" />
                                                    <asp:Button ID="btnSecEntryReject" CssClass="btn btn-default m-r-20" Text="Reject" runat="server" OnClick="btnSecEntryReject_Click" />
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
                   
                   
                   
                    
                    </div>
                                      </div>
                                    </asp:View>
                                   </asp:MultiView>                       
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
                <script type="text/javascript">  
    $(document).ready(function () {  
        $('#<%=gvSchool.ClientID%>').DataTable();  
    });  
</script>
 <script type="text/javascript">  
    $(document).ready(function () {  
        $('#<%=gvAttendance1.ClientID%>').DataTable();  
    });  
</script>  
 <script type="text/javascript">  
    $(document).ready(function () {  
        $('#<%=gvAttendance.ClientID%>').DataTable();  
    });  
</script>            <script type="text/javascript">  
    $(document).ready(function () {  
        $('#<%=gvPrimary.ClientID%>').DataTable();  
    });  
</script>
   <script type="text/javascript">  
    $(document).ready(function () {  
        $('#<%=gvSchool.ClientID%>').DataTable();  
    });  
</script>

</asp:Content>
