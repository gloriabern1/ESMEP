<%@ Page Title="" Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true" CodeBehind="RegisterStudent.aspx.cs" Inherits="ESMEP_EdoStateMinistryOfEducationPortal_.Modules.School.RegisterStudent" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

     <div class="page-bar">
        <div class="page-title-breadcrumb">
            <div class=" pull-left">
                <div class="page-title">Register Student</div>
            </div>
            <ol class="breadcrumb page-breadcrumb pull-right">
                <li>
                    <i class="fa fa-home"></i>&nbsp;<a class="parent-item" href="#">School</a>&nbsp;<i class="fa fa-angle-right"></i>
                </li>
                <li class="active">RegisterStudent</li>
            </ol>
        </div>
    </div>

    <div class="row">
        <div class="col-md-12 col-sm-12">
            <div class="card card-box">
                <div class="card-head">
                    <header>Examination Registration</header>                   
                </div>
                    
    <asp:MultiView runat="server" ID="mutilView1">
        
        <asp:View ID="View0" runat="server">
            <asp:Label runat="server" ID="lblSchoolId" Visible="false"></asp:Label> <asp:Label runat="server" ID="lblStudent" Visible="false"></asp:Label><asp:Label runat="server" ID="lblStudentR" Visible="false"></asp:Label>
              <div class="card-body row" id="bar-parent2">              
              <div class="table-scrollable ">
                <asp:GridView ID="gvExam" CssClass="table table-striped table-bordered table-hover table-checkable order-column valign-middle"
                AutoGenerateColumns="false" runat="server">

                <Columns>
                    <asp:TemplateField>
                          <ItemTemplate>                  
                             <asp:Label ID="lblExamId" runat="server"  Text='<%# Bind("ID") %>' Visible="false"/>
                          </ItemTemplate>
                        <ItemStyle Width="0px" />
                    </asp:TemplateField>
                   <asp:BoundField  DataField="SN" HeaderText="SN">
                    </asp:BoundField>
                    <asp:BoundField  DataField="EXAM" HeaderText="Examination">
                    </asp:BoundField>
                    <asp:BoundField  DataField="EXAMCODE" HeaderText="Exam Code">
                    </asp:BoundField>                    
                    <asp:BoundField  DataField="FEE" HeaderText="Fees">
                    </asp:BoundField>                
                    <asp:TemplateField HeaderText="Select">
                          <ItemTemplate>  
                              <asp:CheckBox ID="chkExam" runat="server" CssClass="checkbox-inline" />
                          </ItemTemplate>
                         <ItemStyle Width="20px" />
                      </asp:TemplateField>
                                        <asp:TemplateField>
                          <ItemTemplate>                  
                             <asp:Label ID="lblExamCode" runat="server"  Text='<%# Bind("EXAMCODE") %>' Visible="false"/>
                          </ItemTemplate>
                        <ItemStyle Width="0px" />
                    </asp:TemplateField>
                    </Columns>
            </asp:GridView>
                     </div>
            <div class="col-md-12 col-sm-6">
                  <asp:Button runat="server" ID="btnNext" Text="Next" CssClass="btn btn-warning col-md-2 pull-right" OnClick="btnNext_Click" />
             </div>
          </div>
        </asp:View>
 
                   <asp:View ID="View1" runat="server">
                        <div class="card-body " id="bar-parent9">
                     <div class="table-scrollable">
                <asp:GridView ID="gvStudents" CssClass="table table-striped table-bordered table-hover table-checkable order-column valign-middle"
                AutoGenerateColumns="false" runat="server">

                <Columns> 
                   <asp:TemplateField>
                          <ItemTemplate>                  
                             <asp:Label ID="lblStudentId" runat="server"  Text='<%# Bind("ID") %>' Visible="false"/>
                          </ItemTemplate>
                       <ItemStyle Width="2px" />
                    </asp:TemplateField>
                   <asp:BoundField  DataField="SN" HeaderText="SN">
                    </asp:BoundField>
                    <asp:BoundField  DataField="Name" HeaderText="Student Name">
                    </asp:BoundField>
                    <asp:BoundField  DataField="Sex" HeaderText="Gender">
                    </asp:BoundField>  
                    <asp:TemplateField HeaderText="Select">
                          <ItemTemplate>  
                              <asp:CheckBox ID="chkStudent" runat="server" CssClass="checkbox-inline" />
                          </ItemTemplate>
                         <ItemStyle Width="20px" />
                      </asp:TemplateField>
                    </Columns>
            </asp:GridView>
                     </div>
                     <div class="col-md-12 col-sm-6">
                               <asp:Button runat="server" ID="addStudent" Text="Next" CssClass="btn btn-success col-md-2 pull-right" OnClick="addStudent_Click"/>
                       </div>
                  </div>
         
        </asp:View>

            <asp:View ID="View2" runat="server">
                        <div class="card-body " id="bar-parent1">
                     <div class="table-scrollable">
                <asp:GridView ID="gvSubject" CssClass="table table-striped table-bordered table-hover table-checkable order-column valign-middle"
                AutoGenerateColumns="false" runat="server">

                <Columns> 
                   <asp:TemplateField>
                          <ItemTemplate>                  
                             <asp:Label ID="lblSubjectId" runat="server"  Text='<%# Bind("ID") %>' Visible="false"/>
                          </ItemTemplate>
                       <ItemStyle Width="2px" />
                    </asp:TemplateField>
                    <asp:TemplateField>
                          <ItemTemplate>                  
                             <asp:Label ID="lblSubjectCode" runat="server"  Text='<%# Bind("SubjectCode") %>' Visible="false"/>
                          </ItemTemplate>
                        <ItemStyle Width="2px" />
                    </asp:TemplateField>
                   <asp:BoundField  DataField="SN" HeaderText="SN">
                    </asp:BoundField>
                    <asp:BoundField  DataField="Subject" HeaderText="Subject">
                    </asp:BoundField>
                    <asp:BoundField  DataField="SubjectCode" HeaderText="Subject Code">
                    </asp:BoundField>  
                    <asp:TemplateField HeaderText="Select">
                          <ItemTemplate>  
                              <asp:CheckBox ID="chkSubject" runat="server" CssClass="checkbox-inline" />
                          </ItemTemplate>
                         <ItemStyle Width="20px" />
                      </asp:TemplateField>
                    </Columns>
            </asp:GridView>
                     </div>
                     <div class="col-md-12 col-sm-6">
                               <asp:Button runat="server" ID="btnSubMit" Text="Submit" CssClass="btn btn-success col-md-2 pull-right" OnClick="btnSubMit_Click" />
                       </div>
                  </div>
         
        </asp:View>
    
                <asp:View ID="View4" runat="server">
                     <div class="row">
	                    <div class="col-md-12">
                            <div style="width:800px">
                              <div class="white-box">
	                            <h3><b>INVOICE</b> <span class="pull-right"><asp:Label ID="lblInvoiceNo" runat="server" /></span></h3>
	                            <hr>
	                            <div class="row">
	                                <div class="col-md-12">
										<div class="pull-left">
											<address>
												<img src="../Content/img/edostateSubeb.jpg" alt="logo" class="logo-default" />
												<p class="text-muted m-l-5">
													Ministry of Education, <br> Edo State, <br>
													Nigeria - 2018
												</p>
											</address>
										</div>
										<div class="pull-right text-right">
											<address>
												<p class="addr-font-h3">To,</p>
												<p class="font-bold addr-font-h4"><asp:Label runat="server" ID="lblschoolName"></asp:label></p>
												<p class="text-muted m-l-30">
													<asp:Label runat="server" ID="lblSchoolEmail"></asp:label>, <br><asp:Label runat="server" ID="lblSchoolAddress"></asp:label> <br>
													<asp:Label runat="server" ID="lblSchoolLGA"></asp:label> <br> Edo State.
												</p>
												<p class="m-t-30">
													<b>Invoice Date :</b> <i class="fa fa-calendar"></i> <asp:Label runat="server" ID="lblDate"></asp:label>
												</p>
												<p>
													<b>Fee  :</b> Registration
												</p>
											</address>
										</div>
									</div>
	                                <div class="col-md-12">
	                                    <div class="table-responsive m-t-40">
	                                   <table class="table table-hover">
	                                            <thead>
	                                                <tr>
	                                                    <th class="text-center">#</th>
	                                                    <th class="text-right">Fees Type</th>
	                                                    <th class="text-right">No of Student</th>
	                                                    <th class="text-right">Date</th>
<%--	                                                    <th class="text-right">Invoice number</th>--%>
	                                                    <th class="text-right">Amount</th>
	                                                </tr>
	                                            </thead>
	                                            <tbody>
	                                                <tr>
	                                                    <td class="text-center">1</td>
	                                                    <td class="text-right"><asp:Label ID="lblFeesType" runat="server" ></asp:Label></td>
	                                                    <td class="text-right"><asp:Label ID="lblNoFStudent" runat="server" ></asp:Label></td>
	                                                    <td class="text-right"><asp:Label ID="lblDateFReg" runat="server" ></asp:Label></td>
<%--	                                                    <td class="text-right">#IN-345609865</td>--%>
	                                                    <td class="text-right"># <asp:Label ID="lblFeeAmount" runat="server" ></asp:Label></td>
	                                                </tr>	                                              
	                                            </tbody>
	                                        </table>
   
	                                    </div>
	                                </div>
	                                <div class="col-md-12">
	                                    <div class="pull-right m-t-30 text-right">
	                                        <p>Sub - Total amount: #<asp:Label runat="server" ID="lblSubTotal"></asp:label></p>
	                                        <hr>
	                                        <h3><b>Total :</b> #<asp:Label runat="server" ID="lblTotal"></asp:label></h3> </div>
	                                    <div class="clearfix"></div>
	                                    <hr>
	                                    <div class="text-right">
                                            <button class="btn btn-danger" type="submit"> Mail Invoice</button>
	                                        <button onclick="javascript:window.print();" class="btn btn-default btn-outline" type="button"> <span><i class="fa fa-print"></i> Print</span> </button>
	                                    </div>
                                        <div class="clearfix"></div>
                                        <div class="center center-block">
                                            <div runat="server" id="plBarCode"></div>
                                        </div>
	                                </div>
	                            </div>
	                        </div>

                            </div>
	                    </div>
	                </div>          
        </asp:View>
    </asp:MultiView>
   <asp:Label runat="server" ID="lblSchoolType" Visible="false"></asp:Label> <asp:Label runat="server" ID="lblSchoolCat" Visible="false"></asp:Label><asp:Label runat="server" ID="noOfStudent" Visible="false"></asp:Label><asp:Label runat="server" ID="lblExamCode1" Visible="false"></asp:Label><asp:Label runat="server" ID="lblID" Visible="false"></asp:Label>
        </div>
    </div>
</div>
    
            <!-- data tables -->
    <script src="../../Content/assets/plugins/datatables/jquery.dataTables.min.js" ></script>
 	<script src="../../Content/assets/plugins/datatables/plugins/bootstrap/dataTables.bootstrap4.min.js" ></script>
    <script src="../../Content/assets/js/pages/table/table_data.js" ></script>
<%-- Page Script --%>
<%--    <script src="../../Scripts/Pages/RegisterStudent.js"></script>--%>
</asp:Content>
