using ESMEP_EdoStateMinistryOfEducationPortal_.Infrastructure.Managers;
using System;
using System.Collections.Generic;
using Microsoft.AspNet.Identity;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ESMEP_EdoStateMinistryOfEducationPortal_.ViewModels;

namespace ESMEP_EdoStateMinistryOfEducationPortal_.Modules.School
{
    public partial class DownloadEntrySchedule : System.Web.UI.Page
    {
        //DropDownManager dropManager = new DropDownManager();
        public SessionObject sessionUser;
        public SessionObject SessionUser
        {
            get { return sessionUser ?? (SessionObject)Session["EdoSessionObject"]; }
            set { value = sessionUser; }
        }
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DropDownManager.PopulateExam(ddlExam, SessionUser.CategoryId);
                DropDownManager.PopulateYear(ddlYear);
            }
         }

        void GetRegisteredSubject(int examId, int StudentId)
        {
            DropDownManager.GetRegisteredSubject(examId, StudentId);
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

        bool ValiadateDate()
        {
            if (ddlExam.SelectedIndex == 0 || ddlYear.SelectedIndex == 0)
            {
                return false;
            }
            return true;
        }

        void PopulateTable()
        {
            DataTable table = new DataTable();
            table.Columns.Add("SN");
            table.Columns.Add("Name");
            table.Columns.Add("Exam NO");
            table.Columns.Add("Sex");
            lblExamName.Text = ddlExam.SelectedItem.Text;
            if (SessionUser.CategoryId == 1)
            {                
                table.Columns.Add("Eng");
                table.Columns.Add("Maths");
                table.Columns.Add("Gen");
                table.Columns.Add("C.R.S");
                table.Columns.Add("I.R.S");
                table.Columns.Add("VOC");
                table.Columns.Add("Num");
                table.Columns.Add("Sign");
                table.Columns.Add("Remarks");

                int exam = int.Parse(ddlExam.SelectedValue.ToString());
                int session = int.Parse(ddlYear.SelectedValue.ToString());
                string userId = string.Empty;
                var registration = DropDownManager.GetRegistrations(SessionUser.SchoolId, session, exam);
                if (registration.Count() > 0 && registration != null)
                {
                    int counter = 1;
                    foreach (var item in registration)
                    {
                        //int studentId = item.StudentId;
                        string name = $"{item.Student.LastName} {item.Student.FirstName} {item.Student.MiddleName ?? ""}";
                        string examNum = item.StudentRegNum ?? $"{item.Examination.ExamCode}00{counter} ";
                        string sex = item.Student.Sex;

                        table.Rows.Add( counter, name, examNum, sex, "", "", "", "", "", "", "", "", "");
                        ++counter;
                    }
                    gvPrimary.DataSource = table;
                    gvPrimary.DataBind();
                    divSec.Visible = false;
                    divPri.Visible = true;
                }
            }
            else
            {
                table.Columns.Add("Eng");
                table.Columns.Add("Maths");
                table.Columns.Add("SciTech");
                table.Columns.Add("Rel");
                table.Columns.Add("Arts");
                table.Columns.Add("Nig");
                table.Columns.Add("Pre");
                table.Columns.Add("French");
                table.Columns.Add("Bus");
                table.Columns.Add("Arabic");
                table.Columns.Add("Pratical");
                table.Columns.Add("Num");
                table.Columns.Add("Sign");
                table.Columns.Add("Remarks");

                int exam = int.Parse(ddlExam.SelectedValue.ToString());
                int session = int.Parse(ddlYear.SelectedValue.ToString());
                string userId = string.Empty;
                var registration = DropDownManager.GetRegistrations(SessionUser.SchoolId, session, exam);
                if (registration.Count() > 0 && registration != null)
                {
                    int counter = 1;
                    foreach (var item in registration)
                    {
                        //int studentId = item.StudentId;
                        string name = $"{item.Student.LastName} {item.Student.FirstName} {item.Student.MiddleName ?? ""}";
                        string examNum = item.StudentRegNum ?? $"{item.Examination.ExamCode}00{counter} ";
                        string sex = item.Student.Sex;

                        table.Rows.Add( counter, name, examNum, sex, "", "", "", "", "", "", "", "", "", "", "", "", "", "");
                    }
                    gvSchool.DataSource = table;
                    gvSchool.DataBind();
                    divSec.Visible = true;
                    divPri.Visible = false;
                }
            }
        }

        public DataTable BuildTableForExcelPrimary()
        {
            DataTable table = new DataTable();
            table.Columns.Add("StudentID");
            table.Columns.Add("SN");
            table.Columns.Add("Name Of Student");
            table.Columns.Add("Exam NO");
            table.Columns.Add("Sex");
            table.Columns.Add("ENG. STUDIES");
            table.Columns.Add("MATHS");
            table.Columns.Add("GEN. PAPER");
            table.Columns.Add("C.R.S");
            table.Columns.Add("I.R.S");
            table.Columns.Add("VOC. STUDIES");
            //table.Columns.Add("PRE-VOCATIONAL");
            //table.Columns.Add("FRENCH LANGUAGE");
            //table.Columns.Add("BUSINESS STUDIES");
            //table.Columns.Add("ARABIC");
            //table.Columns.Add("PRATICAL 5MRKS");
            table.Columns.Add("NO OF SUBJECTS ENTERED FOR");
            table.Columns.Add("STUDENTS SIGNATURE");
            table.Columns.Add("REMARKS");
            table.Columns.Add("ExaminationID");
            table.Columns.Add("SessionID");
            table.Columns.Add("SchoolId");

            int exam = int.Parse(ddlExam.SelectedValue.ToString());
            int session = int.Parse(ddlYear.SelectedValue.ToString());
            string userId = string.Empty;
            var registration = DropDownManager.GetRegistrations(SessionUser.SchoolId, session, exam);
            if (registration.Count() > 0 && registration != null)
            {
                int counter = 1;
                foreach (var item in registration)
                {
                    int studentId = item.StudentId;
                    string name = $"{item.Student.LastName} {item.Student.FirstName} {item.Student.MiddleName ?? ""}";
                    string examNum = item.StudentRegNum ?? $"{item.Examination.ExamCode}00{counter} ";
                    string sex = item.Student.Sex;

                    table.Rows.Add(studentId, counter, name, examNum, sex, "", "", "", "", "", "", "", "", "",item.ExamId,item.SessionId,SessionUser.SchoolId);
                }
            }
            return table;
        }

        public DataTable BuildTableForExcelSecondary()
        {
            DataTable table = new DataTable();
            table.Columns.Add("StudentID");
            table.Columns.Add("SN");
            table.Columns.Add("Name Of Student");
            table.Columns.Add("Exam NO");
            table.Columns.Add("Sex");
            table.Columns.Add("ENG. STUDIES");
            table.Columns.Add("MATHS");
            table.Columns.Add("BASIC SCIENCE & TECHNOLOGY");
            table.Columns.Add("RELIGION & NATIONAL VALUES");
            table.Columns.Add("CULTURAL & CREATIVE ARTS");
            table.Columns.Add("NIGERIA LANGUAGE(EDO)");
            table.Columns.Add("PRE-VOCATIONAL");
            table.Columns.Add("FRENCH LANGUAGE");
            table.Columns.Add("BUSINESS STUDIES");
            table.Columns.Add("ARABIC");
            table.Columns.Add("PRATICAL 5MRKS");
            table.Columns.Add("NO OF SUBJECTS ENTERED FOR");
            table.Columns.Add("STUDENTS SIGNATURE");
            table.Columns.Add("REMARKS");
            table.Columns.Add("ExaminationID");
            table.Columns.Add("SessionID");
            table.Columns.Add("SchoolId");

            int exam = int.Parse(ddlExam.SelectedValue.ToString());
            int session = int.Parse(ddlYear.SelectedValue.ToString());
            string userId = string.Empty;
            var registration = DropDownManager.GetRegistrations(SessionUser.SchoolId, session, exam);
            if (registration.Count() > 0 && registration != null)
            {
                int counter = 1;
                foreach (var item in registration)
                {
                    int studentId = item.StudentId;
                    string name = $"{item.Student.LastName} {item.Student.FirstName} {item.Student.MiddleName ?? ""}";
                    string examNum = item.StudentRegNum ?? $"{item.Examination.ExamCode}00{counter} ";
                    string sex = item.Student.Sex;

                    table.Rows.Add(studentId, counter, name, examNum, sex, "", "", "", "", "", "", "", "", "", "", "", "", "", "",item.ExamId, item.SessionId, SessionUser.SchoolId);
                }
            }
            return table;
        }

        protected void btnSecEntry_Click(object sender, EventArgs e)
        {
            try
            {
                string filename = "Entry Schedule For-" + lblExamName.Text;
                DropDownManager.GenerateExcel(BuildTableForExcelSecondary(), filename, "Sec_Entry", Response);
            }
            catch (Exception ex)
            {
                ErrorMessage.Text = ex.Message;
            }
        }

        protected void btnPriEntry_Click(object sender, EventArgs e)
        {
            try
            {
                string filename = "Entry Schedule For-" + lblExamName.Text;
                DropDownManager.GenerateExcel(BuildTableForExcelPrimary(), filename, "Pri_Entry", Response);
            }
            catch (Exception ex)
            {
                ErrorMessage.Text = ex.Message;
            }
        }
    }
}