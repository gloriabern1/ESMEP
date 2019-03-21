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
    public partial class RegisteredSchool : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public void LoadAllStudent()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("SN");
            dt.Columns.Add("Name");
            dt.Columns.Add("Sex");
            dt.Columns.Add("Date");
            dt.Columns.Add("School");
            dt.Columns.Add("Status");

            var student = DropDownManager.GetAllStudents(null);
            if (student != null)
            {
                int sn = 0;
                foreach (var item in student)
                {
                    string status = GetStatus(item.StudentId);
                    string Name = item.FirstName + "" + item.MiddleName + " " + item.LastName.ToString();
                    string sex = item.Sex.ToString();
                    string Date = item.DateOfBirth.ToString();
                    string school = item.School.Name;
                    sn++;

                    dt.Rows.Add(sn, Name, sex, Date, school, status);
                }

                gvStudents.DataSource = dt;
                gvStudents.DataBind();
            }

        }

        public string GetStatus(int studentId)
        {
            bool isRegistered = DropDownManager.IsStudentRegistered(studentId);
            if (isRegistered == true)
                return "Registered";
            else
                return "Not Registered";
        }

    }
}