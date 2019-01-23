using ESMEP_EdoStateMinistryOfEducationPortal_.Infrastructure;
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
    public partial class AllSchool1 : System.Web.UI.Page
    {
        UnitOfWork unitOfWork = new UnitOfWork();
        DropDownManager dropDownManager = new DropDownManager();
        StaticsManager statManager = new StaticsManager();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                PopulateTable();
            }
        }

        public void PopulateTable()
        {
            var dt = new DataTable();
            dt.Columns.Add("ID");
            dt.Columns.Add("SN");
            dt.Columns.Add("Name");
            dt.Columns.Add("Email");
            dt.Columns.Add("Address");
            dt.Columns.Add("Principal");
            dt.Columns.Add("Student");

            var schools = dropDownManager.GetAllSchools();
            if(schools != null)
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
                    dt.Rows.Add(id, sn, Name, Email, Addreess, principal, nofstudent);
                }
                gvSchool.DataSource = dt;
                gvSchool.DataBind();
            }
        }

        protected void gvSchool_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            string id = e.CommandArgument.ToString();
            if(id != null)
            {
                Response.Redirect("~/Modules/School/AboutSchool/?id="+ id);
            }
        }
    }
}