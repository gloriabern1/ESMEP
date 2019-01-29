using ESMEP_EdoStateMinistryOfEducationPortal_.Infrastructure;
using ESMEP_EdoStateMinistryOfEducationPortal_.Infrastructure.Managers;
using ESMEP_EdoStateMinistryOfEducationPortal_.Services;
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
        DropDownManager dropDownManager = new DropDownManager();
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

            var schools = dropDownManager.GetAllSchools(inspector.LocalGovernmentId, primary);
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
                    dt.Rows.Add(id, sn, Name, Email, Addreess, principal, nofstudent, type );
                }
                gvPrimary.DataSource = dt;
                gvPrimary.DataBind();

                foreach (GridViewRow row in gvPrimary.Rows)
                {
                    Label type = (Label)row.FindControl("type");
                    if(type.Text == "Public")
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

            var schools = dropDownManager.GetAllSchools(inspector.LocalGovernmentId, secondary);
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
                Response.Redirect("~/Modules/School/AboutSchool/?id=" + id);
            }
        }

        protected void gvPrimary_RowCommand(object sender, GridViewCommandEventArgs e)
        {

        }
    }
}