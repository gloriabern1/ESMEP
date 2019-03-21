using ESMEP_EdoStateMinistryOfEducationPortal_.Infrastructure;
using ESMEP_EdoStateMinistryOfEducationPortal_.Infrastructure.Managers;
using ESMEP_EdoStateMinistryOfEducationPortal_.Services;
using ESMEP_EdoStateMinistryOfEducationPortal_.ViewModels;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ESMEP_EdoStateMinistryOfEducationPortal_.Modules.Inspectors
{
    public partial class InspectorSchools : System.Web.UI.Page
    {
        UnitOfWork unitOfWork = new UnitOfWork();
        public SessionObject sessionUser;
        public SessionObject SessionUser
        {
            get { return sessionUser ?? (SessionObject)Session["EdoSessionObject"]; }
            set { value = sessionUser; }
        }
        StaticsManager statManager = new StaticsManager();
        InspectorServices inspectorServices = new InspectorServices();
        int primary = 1;
        int secondary = 2;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                PopulatePrimaryTable();
                PopulateSecondaryTable();
                Multiview0.ActiveViewIndex = 0;
                DropDownManager.PopulateExam(ddlExam);
                DropDownManager.PopulateYear(ddlYear);
                DropDownManager.PopulateExam(ddlExam1);
                DropDownManager.PopulateSubject(ddlSubject);
                DropDownManager.PopulateSubject(ddlSubject1);
                DropDownManager.PopulateYear(ddlYear1);
                DropDownManager.PopulateExam(ddlExam2);
                DropDownManager.PopulateYear(ddlYear2);
                DropDownManager.PopulateExam(ddlExam3);
                DropDownManager.PopulateYear(ddlYear3);

            }
        }


        public void PopulatePrimaryTable()
        {
            var dt = new DataTable();
            dt.Columns.Add("ID");
            dt.Columns.Add("SN");
            dt.Columns.Add("Name");
            dt.Columns.Add("Email");
            dt.Columns.Add("Address");
            dt.Columns.Add("Principal");
            dt.Columns.Add("Student");
            dt.Columns.Add("Type");

            var inspector = inspectorServices.GetInspectorByName();

            var schools = DropDownManager.GetAllSchools(inspector.LocalGovernmentId, primary);
            if (schools != null && schools.Count() > 0)
            {
                int sn = 0;
                foreach (var item in schools)
                {
                    sn++;
                    string id = item.Id.ToString();
                    string Name = item.Name.ToString();
                    string Email = item.Email.ToString();
                    string Addreess = item.Address.ToString();
                    var nofstudent = statManager.GetStudentCount(item.Id);
                    string principal = item.NameOfPrincipal;
                    string type = item.SchoolType.SchoolType1;
                    dt.Rows.Add(id, sn, Name, Email, Addreess, principal, nofstudent, type);
                }
                gvPrimary.DataSource = dt;
                gvPrimary.DataBind();
                gvPrimary.HeaderRow.TableSection = TableRowSection.TableHeader;

                foreach (GridViewRow row in gvPrimary.Rows)
                {
                    Label type = (Label)row.FindControl("type");
                    if (type.Text == "Public")
                    {
                        type.CssClass = "btn btn-primary";
                    }
                    else
                    {
                        type.CssClass = "btn btn-warning";
                    }
                }
            }
            else
            {
                dt.Rows.Add("", "", "No School Registered under your Local Government", "", "", "", "", "");
                gvPrimary.DataSource = dt;
                gvPrimary.DataBind();
                gvPrimary.HeaderRow.TableSection = TableRowSection.TableHeader;

                foreach (GridViewRow row in gvPrimary.Rows)
                {
                    Button type = (Button)row.FindControl("btnview");
                    type.Visible = false;
                }
            }
        }


        public void PopulateSecondaryTable()
        {
            var dt = new DataTable();
            dt.Columns.Add("ID");
            dt.Columns.Add("SN");
            dt.Columns.Add("Name");
            dt.Columns.Add("Email");
            dt.Columns.Add("Address");
            dt.Columns.Add("Principal");
            dt.Columns.Add("Student");
            dt.Columns.Add("Type");

            var inspector = inspectorServices.GetInspectorByName();

            var schools = DropDownManager.GetAllSchools(inspector.LocalGovernmentId, secondary);
            if (schools != null && schools.Count() > 0)
            {
                int sn = 0;
                foreach (var item in schools)
                {
                    sn++;
                    string id = item.Id.ToString();
                    string Name = item.Name.ToString();
                    string Email = item.Email.ToString();
                    string Addreess = item.Address.ToString();
                    var nofstudent = statManager.GetStudentCount(item.Id);
                    string principal = item.NameOfPrincipal;
                    string type = item.SchoolType.SchoolType1;
                    dt.Rows.Add(id, sn, Name, Email, Addreess, principal, nofstudent, type);
                }
                gvSchool.DataSource = dt;
                gvSchool.DataBind();
                gvSchool.HeaderRow.TableSection = TableRowSection.TableHeader;

                foreach (GridViewRow row in gvSchool.Rows)
                {
                    Label type = (Label)row.FindControl("type");
                    if (type.Text == "Public")
                    {
                        type.CssClass = "btn btn-primary";
                    }
                    else
                    {
                        type.CssClass = "btn btn-warning";
                    }
                }
            }
            else
            {
                dt.Rows.Add("", "", "No School Registered under your Local Government", "", "", "", "", "");
                gvSchool.DataSource = dt;
                gvSchool.DataBind();
                gvSchool.HeaderRow.TableSection = TableRowSection.TableHeader;
                foreach (GridViewRow row in gvSchool.Rows)
                {
                    Button type = (Button)row.FindControl("btnview");
                    type.Visible = false;
                }
            }
        }

        protected void gvSchool_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            string id = e.CommandArgument.ToString();
            if (id != null)
            {
                SessionUser.SchoolId = int.Parse(id);
                Multiview1.ActiveViewIndex = 1;
            }
        }

        protected void gvPrimary_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            string id = e.CommandArgument.ToString();
            if (id != null)
            {
                SessionUser.SchoolId = int.Parse(id);
                Multiview0.ActiveViewIndex = 1;

                // Response.Redirect("~/Modules/School/AboutSchool/?id=" + id);
            }
        }

        protected void btnAttendReject_Click(object sender, EventArgs e)
        {
            if (inspectorServices.ApproveOrRejectAttendance(false, SessionUser.SchoolId, ddlExam.SelectedValue, ddlSubject.SelectedValue, ddlYear.SelectedValue))
            {
                DropDownManager.ShowPopUp("Rejected Successfully !!!");
                PopulateAttendancePri(SessionUser.SchoolId.ToString());
            }
        }

        protected void btnAttendApprove_Click(object sender, EventArgs e)
        {
            if (inspectorServices.ApproveOrRejectAttendance(true, SessionUser.SchoolId, ddlExam.SelectedValue, ddlSubject.SelectedValue, ddlYear.SelectedValue))
            {
                DropDownManager.ShowPopUp("Approved Successfully !!!");
                PopulateAttendancePri(SessionUser.SchoolId.ToString());
            }
        }

        protected void btnPriEntryAprove_Click(object sender, EventArgs e)
        {
            if (inspectorServices.ApproveOrRejectSchedule(true, SessionUser.SchoolId, ddlExam1.SelectedValue, ddlYear1.SelectedValue))
            {
                DropDownManager.ShowPopUp("Approved Successfully !!!");
                // PopulateAttendancePri(SessionUser.SchoolId.ToString());
            }
        }

        protected void btnSecEntryApprove_Click(object sender, EventArgs e)
        {
            if (inspectorServices.ApproveOrRejectSchedule(true, SessionUser.SchoolId, ddlExam1.SelectedValue, ddlYear1.SelectedValue))
            {
                DropDownManager.ShowPopUp("Approved Successfully !!!");
                // PopulateAttendancePri(SessionUser.SchoolId.ToString());
            }
        }

        protected void btnSecAttendApprove_Click(object sender, EventArgs e)
        {
            if (inspectorServices.ApproveOrRejectAttendance(true, SessionUser.SchoolId, ddlExam1.SelectedValue, ddlSubject1.SelectedValue, ddlYear1.SelectedValue))
            {
                DropDownManager.ShowPopUp("Approved Successfully !!!");
                PopulateAttendancePri(SessionUser.SchoolId.ToString());
            }
        }

        protected void btnSecAttendReject_Click(object sender, EventArgs e)
        {
            if (inspectorServices.ApproveOrRejectAttendance(false, SessionUser.SchoolId, ddlExam1.SelectedValue, ddlSubject1.SelectedValue, ddlYear1.SelectedValue))
            {
                DropDownManager.ShowPopUp("Approved Successfully !!!");
                PopulateAttendancePri(SessionUser.SchoolId.ToString());
            }
        }

        protected void btnSecEntryReject_Click(object sender, EventArgs e)
        {
            if (inspectorServices.ApproveOrRejectSchedule(false, SessionUser.SchoolId, ddlExam1.SelectedValue, ddlYear1.SelectedValue))
            {
                DropDownManager.ShowPopUp("Approved Successfully !!!");
                //PopulateAttendancePri(SessionUser.SchoolId.ToString());
            }
        }

        public void PopulateAttendancePri(string SchoolId)
        {
            int schoolId = 0;
            int.TryParse(SchoolId, out schoolId);
            DataTable table = new DataTable();
            table.Columns.Add("ID");
            table.Columns.Add("SN");
            table.Columns.Add("Name");
            table.Columns.Add("Exam_NO");
            table.Columns.Add("Present");
            table.Columns.Add("Mark");
            table.Columns.Add("Remarks");
            table.Columns.Add("Status");
            int exam = int.Parse(ddlExam.SelectedValue.ToString());
            int session = int.Parse(ddlYear.SelectedValue.ToString());
            string subject = ddlSubject.SelectedValue.ToString();
            // lblExamName.Text = ddlSubject.SelectedItem.Text;


            var registration = DropDownManager.GetRegistrations(schoolId, session, exam, subject);
            if (registration.Count() > 0 && registration != null)
            {
                int counter = 1;
                foreach (var item in registration)
                {
                    string id = item.SubjectId.ToString();
                    string name = $"{item.Student.LastName} {item.Student.FirstName} {item.Student.MiddleName ?? ""}";
                    string examNum = item.StudentRegNum ?? $"{item.Examination.ExamCode}00{counter} ";
                    string attendance = item.Attendance?.ToString();
                    string mark = item.TotalScore.ToString() ?? "";
                    string remark = item.AttendanceRemarks ?? "";
                    string status = item.AttendanceApprovedByInspector?.ToString() ?? "False";
                    table.Rows.Add(counter, name, examNum, attendance, mark, remark);
                    counter++;
                }
                gvAttendance.DataSource = table;
                gvAttendance.DataBind();
                gvAttendance1.DataSource = table;
                gvAttendance1.DataBind();
                gvAttendance1.HeaderRow.TableSection = TableRowSection.TableHeader;
                gvAttendance.HeaderRow.TableSection = TableRowSection.TableHeader;

                int RowCount = gvAttendance.Rows.Count - 1;
                btnAttendApprove.Enabled = false;
                btnAttendReject.Enabled = false;
                if (gvAttendance.Rows[RowCount - 1].Cells[7].Text.ToUpper() != "TRUE")
                {
                    btnAttendApprove.Enabled = true;
                }
                else
                {
                    btnAttendReject.Enabled = true;
                }

                int RowCount1 = gvAttendance1.Rows.Count - 1;
                btnSecAttendApprove.Enabled = false;
                btnSecAttendReject.Enabled = false;
                if (gvAttendance1.Rows[RowCount - 1].Cells[7].Text.ToUpper() != "TRUE")
                {
                    btnSecAttendApprove.Enabled = true;
                }
                else
                {
                    btnSecAttendReject.Enabled = true;
                }
                divBtn.Visible = true;
                divBtn1.Visible = true;
            }
            else
            {
                table.Rows.Add("", "", " No Record found ", "", "", "");
                gvAttendance1.DataSource = table;
                gvAttendance1.DataBind();
                gvAttendance.DataSource = table;
                gvAttendance.DataBind();
                gvAttendance1.Visible = true;
                gvAttendance.Visible = true;
                divBtn.Visible = false;
                divBtn1.Visible = false;
            }
        }

        protected void ddlExam_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ValiadateDate())
            {
                PopulateAttendancePri(SessionUser.SchoolId.ToString());
            }
        }

        protected void ddlYear_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ValiadateDate())
            {
                PopulateAttendancePri(SessionUser.SchoolId.ToString());
            }
        }

        protected void ddlSubject_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ValiadateDate())
            {
                PopulateAttendancePri(SessionUser.SchoolId.ToString());
            }
        }
        bool ValiadateDate()
        {
            if (ddlExam.SelectedIndex == 0 || ddlYear.SelectedIndex == 0 || ddlSubject.SelectedIndex == 0)
            {
                return false;
            }
            return true;
        }

        protected void ddlSubject1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ValiadateDate())
            {
                PopulateAttendancePri(SessionUser.SchoolId.ToString());
            }
        }

        protected void ddlYear1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ValiadateDate())
            {
                PopulateAttendancePri(SessionUser.SchoolId.ToString());
            }
        }

        protected void ddlExam1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ValiadateDate())
            {
                PopulateAttendancePri(SessionUser.SchoolId.ToString());
            }
        }
    }
}