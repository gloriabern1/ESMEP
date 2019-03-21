using ESMEP_EdoStateMinistryOfEducationPortal_.Infrastructure.Managers;
using System;
using System.Data;
using Microsoft.AspNet.Identity;
using System.Linq;
using ESMEP_EdoStateMinistryOfEducationPortal_.ViewModels;

namespace ESMEP_EdoStateMinistryOfEducationPortal_.Modules.School
{
    public partial class DownloadAttachments : System.Web.UI.Page
    {
        public SessionObject sessionUser;
        public SessionObject SessionUser
        {
            get { return sessionUser ?? (SessionObject)Session["EdoSessionObject"]; }
            set { value = sessionUser; }
        }

       // DropDownManager dropManager = new DropDownManager();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DropDownManager.PopulateExam(ddlExam, SessionUser.CategoryId);
                DropDownManager.PopulateSubject(ddlSubject);
                DropDownManager.PopulateYear(ddlYear);
            }
        }
                
        protected void btnAttendenceList_Click(object sender, EventArgs e)
        {
            try
            {
                string filename = "Attendance For -" + lblExamName.Text;
                DropDownManager.GenerateExcel(GetTableForExecl(), filename, "Attendance", Response);
            }
            catch (Exception ex)
            {
                ErrorMessage.Text = ex.Message;
            }
        }

      
        protected void ddlExam_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ValiadateDate())
            {
                PopulateTable();
            }
        }

        protected void ddlYear_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ValiadateDate())
            {
                PopulateTable();
            }
        }

        protected void ddlSubject_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ValiadateDate())
            {
                PopulateTable();
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

        public void PopulateTable()
        {
            DataTable table = new DataTable();
            table.Columns.Add("SN");
            table.Columns.Add("Name");
            table.Columns.Add("Exam_NO");
            table.Columns.Add("Present");
            table.Columns.Add("Mark");
            table.Columns.Add("Remarks");

            int exam = int.Parse(ddlExam.SelectedValue.ToString());
            int session = int.Parse(ddlYear.SelectedValue.ToString());
            string subject = ddlSubject.SelectedValue.ToString();
            lblExamName.Text = ddlSubject.SelectedItem.Text;


            var registration = DropDownManager.GetRegistrations(SessionUser.SchoolId, session, exam, subject);
            if(registration.Count() > 0 && registration != null)
            {
                int counter = 1;
                foreach (var item in registration)
                {
                    string name = $"{item.Student.LastName} {item.Student.FirstName} {item.Student.MiddleName ?? ""}";
                    string examNum = item.StudentRegNum ?? $"{item.Examination.ExamCode}00{counter} " ;
                    string attendance = item.Attendance?.ToString();
                    string mark = item.TotalScore.ToString() ?? "";
                    string remark = item.AttendanceRemarks ?? "";

                    table.Rows.Add(counter, name, examNum, attendance, mark, remark);
                    counter++;
                }
                gvSchool.DataSource = table;
                gvSchool.DataBind();
                divBtn.Visible = true;
            }
            else
            {
                table.Rows.Add("", " No Record found ", "", "", "", "");
                gvSchool.DataSource = table;
                gvSchool.DataBind();
                divBtn.Visible = false;
            }
        }

        private DataTable GetTableForExecl()
        {
            DataTable table = new DataTable();
            table.Columns.Add("StudentID");
            table.Columns.Add("SN");
            table.Columns.Add("NAME OF CANDIDATE");
            table.Columns.Add("Exam NO");
            table.Columns.Add("Subject");
            table.Columns.Add("Present");
            table.Columns.Add("Mark");
            table.Columns.Add("Remarks");
            table.Columns.Add("ExaminationID");
            table.Columns.Add("Examination");
            table.Columns.Add("SessionID");
            table.Columns.Add("Session");
            table.Columns.Add("SchoolId");
            table.Columns.Add("SubjectId");

            int exam = int.Parse(ddlExam.SelectedValue.ToString());
            int session = int.Parse(ddlYear.SelectedValue.ToString());
            string subject = ddlSubject.SelectedValue.ToString();
            //string userId = string.Empty;
            //try
            //{
            //    userId = User.Identity.GetUserId();
            //}
            //catch (Exception ex)
            //{
            //    Response.Redirect("~/Account/Login");
            //}

            //Models.School school = dropManager.GetSchoolByUserId(userId);
            var registration = DropDownManager.GetRegistrations(SessionUser.SchoolId, session, exam, subject);
            if (registration.Count() > 0 && registration != null)
            {
                int counter = 1;
                foreach (var item in registration)
                {
                    int studentId = item.StudentId;
                    string name = $"{item.Student.LastName} {item.Student.FirstName} {item.Student.MiddleName ?? ""}";
                    string examNum = item.StudentRegNum ?? $"{item.Examination.ExamCode}00{counter} ";
                    string attendance = item.Attendance?.ToString();
                    string mark = item.TotalScore.ToString() ?? "";
                    string subjectName = item.Subject.Name;
                    string remark = item.AttendanceRemarks ?? "";
                    string examName = item.Examination.Name;
                    string examId = item.ExamId.ToString();
                    int sessionId = item.SessionId.Value;
                    string year = item.Session.Name;
                    table.Rows.Add(studentId, counter, name, examNum, subjectName, attendance, mark, remark, examId, examName,sessionId, session, SessionUser.SchoolId, item.SubjectId);
                    counter++;
                }
            }
            return table;
        }
    }
}