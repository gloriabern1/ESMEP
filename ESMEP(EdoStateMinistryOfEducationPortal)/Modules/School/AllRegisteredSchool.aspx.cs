using ESMEP_EdoStateMinistryOfEducationPortal_.Infrastructure.Managers;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ESMEP_EdoStateMinistryOfEducationPortal_.Modules.School
{
    public partial class AllRegisteredSchool : System.Web.UI.Page
    {
        DropDownManager dropDownManager = new DropDownManager();
        StaticsManager stat = new StaticsManager();

        protected void Page_Load(object sender, EventArgs e)
        {
            LoadAllStudent();
        }

        public void LoadAllStudent()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("SN");
            dt.Columns.Add("ID");
            dt.Columns.Add("Name");
            dt.Columns.Add("Email");
            dt.Columns.Add("Address");
            dt.Columns.Add("students");
            dt.Columns.Add("Status");

            var student = dropDownManager.GetAllSchools();
            if (student != null)
            {
                int sn = 0;
                foreach (var item in student)
                {
                    string id = item.Id.ToString();
                    string status = GetStatus(item.Id);
                    string Name = item.Name;
                    string Email = item.Email.ToString();
                    string students = stat.GetStudentCount (item.Id);
                    string Address = item.Address;
                    sn++;

                    dt.Rows.Add(sn, id, Name, Email, Address, students, status);
                }

                gvSchools.DataSource = dt;
                gvSchools.DataBind();
            }

        }

        public string GetStatus(int schoolId)
        {
            bool isRegistered = dropDownManager.IsSchoolRegistered(schoolId);
            if (isRegistered == true)
                return "Registered";
            else
                return "Not Registered";
        }

    }
}