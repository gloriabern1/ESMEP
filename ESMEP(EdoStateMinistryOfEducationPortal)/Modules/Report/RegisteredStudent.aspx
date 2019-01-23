 <%@ Page Title="" Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true" CodeBehind="RegisteredStudent.aspx.cs" Inherits="ESMEP_EdoStateMinistryOfEducationPortal_.Modules.Report.RegisteredStudent" EnableEventValidation="false" %>
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
                    <li class="active">Registered Student</li>
                </ol>
            </div>
        </div>
        <div class="row">
        <div class="col-md-12 col-sm-12">
            <div class="card card-box">
                <div class="card-head">
                    <header>Student Registered For Exam</header>                   
                </div>
               <asp:ScriptManager runat="server" ID="manager"></asp:ScriptManager>

        <asp:MultiView runat="server" ID="mutilView1">
        
        <asp:View ID="View0" runat="server">
       <div class="card-body ">
          <div class="row">
        <%--    <div class="col-md-6 col-sm-6 col-6">
                <div class="btn-group">
                    <a href='<%=Page.ResolveUrl("~/Modules/School/RegisterStudent")%>' id="addRow" class="btn btn-info">
                        Add New <i class="fa fa-plus"></i>
                    </a>
                </div>
            </div>
            <div class="col-md-6 col-sm-6 col-6">
                <div class="btn-group pull-right">
                    <a class="btn deepPink-bgcolor  btn-outline dropdown-toggle" data-toggle="dropdown">Tools
                        <i class="fa fa-angle-down"></i>
                    </a>
                    <ul class="dropdown-menu pull-right">
                        <li>
                            <a href="javascript:;">
                                <i class="fa fa-print"></i> Print </a>
                        </li>
                        <li>
                            <a href="javascript:;">
                                <i class="fa fa-file-pdf-o"></i> Save as PDF </a>
                        </li>
                        <li>
                            <a href="javascript:;">
                                <i class="fa fa-file-excel-o"></i> Export to Excel </a>
                        </li>
                    </ul>
                </div>
            </div>
      --%>   </div>
            <asp:Label runat="server" ID="lblSchoolId" Visible="false"></asp:Label> <asp:Label runat="server" ID="lblStudent" Visible="false"></asp:Label>
              <div class="row" id="bar-parent2">              
              <div class="table-scrollable ">
                <asp:GridView ID="gvSubject" CssClass="table table-striped table-bordered table-hover table-checkable order-column valign-middle" OnRowCommand="gvExam_RowCommand"
                AutoGenerateColumns="false" runat="server">
                <Columns>
                    <asp:TemplateField>
                          <ItemTemplate>                  
                             <asp:Label ID="lblExamId" runat="server"  Text='<%# Bind("EXAMID") %>' Visible="false"/>
                          </ItemTemplate>
                        <ItemStyle Width="2px" />
                    </asp:TemplateField>
                   <asp:BoundField  DataField="SN" HeaderText="SN">
                    </asp:BoundField>
                    <asp:BoundField  DataField="NAME" HeaderText="Student">
                    </asp:BoundField>
                    <asp:BoundField  DataField="SCHOOL" HeaderText="School">
                    </asp:BoundField>
                    <asp:BoundField  DataField="EXAMINATION" HeaderText="Exam">
                    </asp:BoundField>                    
                    <asp:BoundField  DataField="FEE" HeaderText="Status">
                    </asp:BoundField>                
                    <asp:TemplateField HeaderText="PAYMENT">
                          <ItemTemplate>  
                                   <asp:Button ID="btnview" runat="server" CommandName="doView"  CommandArgument='<%# Bind("EXAMID") %>' Text="PAY" CssClass="btn btn-success btn-sm"/>                      
                          </ItemTemplate>
                         <ItemStyle Width="20px" />
                      </asp:TemplateField>
                    </Columns>
            </asp:GridView>
                     </div>
            <div class="col-md-12 col-sm-6">
<%--                  <asp:Button runat="server" ID="btnNext" Text="Next" CssClass="btn btn-warning col-md-2 pull-right" OnClick="btnNext_Click" />--%>
             </div>
          </div>
        </div>
           </asp:View>
            <asp:View ID="View1" runat="server">
                           <div class="page-bar">
                        <div class="page-title-breadcrumb">
                            <div class=" pull-left">
                                <div class="page-title">Student Invoice</div>
                            </div>
                            <ol class="breadcrumb page-breadcrumb pull-right">
                                <li><i class="fa fa-home"></i>&nbsp;<a class="parent-item" href="index.html">Home</a>&nbsp;<i class="fa fa-angle-right"></i>
                                <li><a class="parent-item" href="#">Fees</a>&nbsp;<i class="fa fa-angle-right"></i>
                                </li>
                                <li class="active">Invoice</li>
                            </ol>
                        </div>
                    </div>
	                   <div class="row">
	                    <div class="col-md-12">
	                        <div class="white-box">
	                            <h3><b>INVOICE</b> <span class="pull-right">#345766</span></h3>
	                            <hr>
	                            <div class="row">
	                                <div class="col-md-12">
										<div class="pull-left">
											<address>
												<img src="../assets/img/invoice_logo.png" alt="logo" class="logo-default" />
												<p class="text-muted m-l-5">
													Aditya University, <br> Opp. Town Hall, <br>
													Sardar Patel Road, <br> Ahmedabad - 380015
												</p>
											</address>
										</div>
										<div class="pull-right text-right">
											<address>
												<p class="addr-font-h3">To,</p>
												<p class="font-bold addr-font-h4">Jayesh Patel</p>
												<p class="text-muted m-l-30">
													207, Prem Sagar Appt., <br> Near Income Tax Office, <br>
													Ashram Road, <br> Ahmedabad - 380057
												</p>
												<p class="m-t-30">
													<b>Invoice Date :</b> <i class="fa fa-calendar"></i> 14th
													July 2017
												</p>
												<p>
													<b>Course  :</b> Engineering
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
	                                                    <th class="text-right">Frequency</th>
	                                                    <th class="text-right">Date</th>
	                                                    <th class="text-right">Invoice number</th>
	                                                    <th class="text-right">Amount</th>
	                                                </tr>
	                                            </thead>
	                                            <tbody>
	                                                <tr>
	                                                    <td class="text-center">1</td>
	                                                    <td class="text-right">Annual Fees</td>
	                                                    <td class="text-right">Yearly</td>
	                                                    <td class="text-right">2016-11-19</td>
	                                                    <td class="text-right">#IN-345609865</td>
	                                                    <td class="text-right">$100</td>
	                                                </tr>
	                                                <tr>
	                                                    <td class="text-center">2</td>
	                                                    <td class="text-right">Tuition Fees</td>
	                                                    <td class="text-right">Monthly</td>
	                                                    <td class="text-right">2016-11-19</td>
	                                                    <td class="text-right">#IN-345604565</td>
	                                                    <td class="text-right">$50</td>
	                                                </tr>
	                                            </tbody>
	                                        </table>
	                                    </div>
	                                </div>
	                                <div class="col-md-12">
	                                    <div class="pull-right m-t-30 text-right">
	                                        <p>Sub - Total amount: $150</p>
	                                        <p>Discount : $10 </p>
	                                        <p>Tax (10%) : $14 </p>
	                                        <hr>
	                                        <h3><b>Total :</b> $164</h3> </div>
	                                    <div class="clearfix"></div>
	                                    <hr>
	                                    <div class="text-right">
	                                        <button class="btn btn-danger" type="submit"> Proceed to payment </button>
	                                        <button onclick="javascript:window.print();" class="btn btn-default btn-outline" type="button"> <span><i class="fa fa-print"></i> Print</span> </button>
	                                    </div>
	                                </div>
	                            </div>
	                        </div>
	                    </div>
	                </div>
                    
                     <div class="col-md-12 col-sm-6">
<%--                               <asp:Button runat="server" ID="btnSubMit" Text="Submit" CssClass="btn btn-success col-md-2 pull-right" OnClick="btnSubMit_Click" />--%>
                       </div>
         
        </asp:View>
            <asp:View ID="View2" runat="server">
     
        </asp:View>
    </asp:MultiView>
        </div>
</div>
            </div>
</asp:Content>
