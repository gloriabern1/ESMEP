using ESMEP_EdoStateMinistryOfEducationPortal_.Infrastructure.Managers;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ESMEP_EdoStateMinistryOfEducationPortal_.Modules.Report
{
    public partial class RegisteredStudent : System.Web.UI.Page
    {
        DropDownManager dropDownManager = new DropDownManager();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                mutilView1.ActiveViewIndex = 0;
                PopulateExamDetails();
            }
           
        }

        public void PopulateExamDetails()
        {
            var dt = new DataTable();
            dt.Columns.Add("SN");
            dt.Columns.Add("NAME");
            dt.Columns.Add("SCHOOL");
            dt.Columns.Add("EXAMINATION");
            dt.Columns.Add("FEES");
            dt.Columns.Add("EXAMID");


            var Exams = dropDownManager.GetRegisteredStudents();
            int sn = 0;
            foreach (var item in Exams)
            {
                string id = item.StudentID.ToString();
                string Name = item.StudentName;
                string schoolName = item.SchoolName;
                string Exam = item.ExamCode;
                string ExamId = item.ExamId.ToString() + "," +item.StudentID.ToString() + "," + item.SchoolId.ToString();
                string Fee = item.Fee;
                sn++;
                dt.Rows.Add(sn, Name, schoolName, Exam, Fee, ExamId);
            }
            gvSubject.DataSource = dt;
            gvSubject.DataBind();
        }

        protected void gvExam_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            string id = e.CommandArgument.ToString();
            string[] Ids = id.Split(',');
            string ExamId = Ids[0];
            string StudentId = Ids[1];
            string schoolId = Ids[2];

            dropDownManager.ShowPopUp(ExamId + " "+ StudentId + " "+ schoolId);

        }
    }
}