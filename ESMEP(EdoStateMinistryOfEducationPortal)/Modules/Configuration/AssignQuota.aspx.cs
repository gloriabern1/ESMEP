using ESMEP_EdoStateMinistryOfEducationPortal_.Infrastructure.Managers;
using ESMEP_EdoStateMinistryOfEducationPortal_.ViewModels;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ESMEP_EdoStateMinistryOfEducationPortal_.Modules.Configuration
{
    public partial class AssignQuota : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DropDownManager.PopulateYear(ddlYear);
                DropDownManager.PopulateSchool(ddlSchool);
                DropDownManager.GetLGA(ddlLocalGovt, "ED");
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (ValidateInput())
            {
                QuotaViewModel quota = new QuotaViewModel()
                {
                    SchoolId = int.Parse(ddlSchool.SelectedValue),
                    SessionId = int.Parse(ddlYear.SelectedValue),
                    Year = ddlYear.SelectedItem.Text,
                    Quota = int.Parse(txtQuota.Value)
                };
                var result = GeneralUtility.AddQuota(quota);
                if (result)
                {
                    DropDownManager.ShowPopUp("Quota Successfully Assigned to School");
                }
                else
                {
                    DropDownManager.ShowPopUp("Quota Failed to Assign, Try Again");
                }
            }
        }

        bool ValidateInput()
        {
            if (ddlSchool.SelectedIndex == 0)
            {
                ErrorMessage.Text = "Select School";
                return false;
            }

            if (ddlYear.SelectedIndex == 0)
            {
                ErrorMessage.Text = "Select Year";
                return false;
            }
            if (string.IsNullOrEmpty(txtQuota.Value))
            {
                ErrorMessage.Text = "Enter Quota";
                return false;
            }
            if (txtQuota.Value == "0")
            {
                ErrorMessage.Text = "Quota cannot be zero";
                return false;
            }
            return true;
        }

        protected void ddlLocalGovt_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(ddlLocalGovt.SelectedIndex != 0)
            {
                int selectValue = int.Parse(ddlLocalGovt.SelectedValue);
                PopulateTable(selectValue);
            }
        }

        private void PopulateTable(int selectValue)
        {
            DataTable dataTable = new DataTable();
            dataTable.Columns.Add("ID");
            dataTable.Columns.Add("SN");
            dataTable.Columns.Add("Name");
            dataTable.Columns.Add("Inspector");
            int counter = 0;
            var schools = DropDownManager.GetAllSchools(selectValue, GeneralUtility.SessionUser.SchoolType, null);
            foreach (var item in schools)
            {
                ++counter;
                string id = item.Id.ToString();
                string name = item.Name.ToString();
                string inspector = item.LocalGovernment.Inspectors.FirstOrDefault()?.CIEName;
                dataTable.Rows.Add(id, counter, name, inspector);
            }
            gvAllQuota.DataSource = dataTable;
            gvAllQuota.DataBind();
            gvAllQuota.HeaderRow.TableSection = TableRowSection.TableHeader;
        }
    }
}