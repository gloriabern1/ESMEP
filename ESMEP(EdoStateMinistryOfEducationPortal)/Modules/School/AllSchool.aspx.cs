using ESMEP_EdoStateMinistryOfEducationPortal_.Infrastructure;
using ESMEP_EdoStateMinistryOfEducationPortal_.Infrastructure.Managers;
using System;
using Microsoft.AspNet.Identity;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ESMEP_EdoStateMinistryOfEducationPortal_.ViewModels;

namespace ESMEP_EdoStateMinistryOfEducationPortal_.Modules.School
{
    public partial class AllSchool1 : System.Web.UI.Page
    {
        public SessionObject sessionUser;
        public SessionObject SessionUser
        {
            get { return sessionUser ?? (SessionObject)Session["EdoSessionObject"]; }
            set { value = sessionUser; }
        }
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
            dt.Columns.Add("LocalGovt");
            dt.Columns.Add("Inspector");

            IEnumerable<Models.School> schools;
            if(User.IsInRole("Inspector"))
            {
                 schools = DropDownManager.GetAllSchools(SessionUser.LgaId);
            }
            else
            {
                schools = DropDownManager.GetAllSchools();
            }

            if (schools != null)
            {
                int sn = 0;
                foreach (var item in schools)
                {
                    sn++;
                    string id = item.Id.ToString();
                    string Name = item.Name.ToString();
                    string Email = item.Email.ToString();
                    string Addreess = item.Address.ToString();
                    string principal = item.LocalGovernment.LocalGovernment1;
                    var nofstudent = item.LocalGovernment.Inspectors.FirstOrDefault()?.CIEName; // statManager.GetStudentCount(item.Id);
                    dt.Rows.Add(id, sn, Name, Email, Addreess, principal, nofstudent);
                }
                gvSchool.DataSource = dt;
                gvSchool.DataBind();
                gvSchool.HeaderRow.TableSection = TableRowSection.TableHeader;
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