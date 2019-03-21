using ESMEP_EdoStateMinistryOfEducationPortal_.Infrastructure.Managers;
using System;
using System.Collections.Generic;
using Microsoft.AspNet.Identity;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ESMEP_EdoStateMinistryOfEducationPortal_.Modules.School
{
    public partial class AllStudentBySchool : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string schoolId = GetSchoolId();
                LoadAllStudent(schoolId);
            }

        }

        protected void gvStudent_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            string id = e.CommandArgument.ToString();
        }

        public void LoadAllStudent(string schoolId)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("SN");
            dt.Columns.Add("ID");
            dt.Columns.Add("Name");
            dt.Columns.Add("Address");
            dt.Columns.Add("Sex");
            dt.Columns.Add("Date");
            dt.Columns.Add("State");

            var student = DropDownManager.GetAllStudents(schoolId);
            if (student != null)
            {
                int sn = 0;
                foreach (var item in student)
                {
                    string id = item.StudentId.ToString();
                    // string status = GetStatus(item.StudentId);
                    string Address = item.Address;
                    string Name = item.FirstName + "" + item.MiddleName + " " + item.LastName.ToString();
                    string sex = item.Sex.ToString();
                    string state = item.LocalGovernment.State.STATE_NAME;
                    string Date = item.DateOfBirth.ToString();
                    //string school = item.School.Name;
                    sn++;

                    dt.Rows.Add(sn, id, Name, Address ,sex, Date, state);
                }

                tblGeneral.DataSource = dt;
                tblGeneral.DataBind();
                tblGeneral.HeaderRow.TableSection = TableRowSection.TableHeader;

            }

        }

        public string GetSchoolId()
        {
            string userId = HttpContext.Current.User.Identity.GetUserId();
            if(userId != null)
            {
               var schoolId = DropDownManager.GetSchoolId(userId);
                return schoolId.ToString();
            }
            else
            {
                var schoolId = 1;   //dropDownManager.GetSchoolId(null);
                return schoolId.ToString();
            }
        }


    }
}