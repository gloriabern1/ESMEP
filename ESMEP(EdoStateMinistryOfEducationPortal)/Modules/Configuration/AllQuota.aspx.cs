using ESMEP_EdoStateMinistryOfEducationPortal_.Infrastructure.Managers;
using ESMEP_EdoStateMinistryOfEducationPortal_.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ESMEP_EdoStateMinistryOfEducationPortal_.Modules.Configuration
{
    public partial class AllQuota : System.Web.UI.Page
    {
        public int Currentsession;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                Currentsession = GeneralUtility.GetCurrentSessionId();
                PopulateTable();
               
            }
        }

        public void PopulateTable()
        {
            var dt = new DataTable();
            dt.Columns.Add("ID");
            dt.Columns.Add("SN");
            dt.Columns.Add("Name");
            dt.Columns.Add("Assigned");
            dt.Columns.Add("Used");
            dt.Columns.Add("Remainning");
            dt.Columns.Add("Year");          

            IEnumerable<SchoolQuota> quota = GeneralUtility.GetQuotas(Currentsession);           

            if (quota != null)
            {
                int sn = 0;
                foreach (var item in quota)
                {
                    sn++;
                    string id = item.Id.ToString();
                    string Name = item.School.Name.ToString();
                    string quotaAssigned = item.QuotaAssigned.ToString();
                    var quotaUsed = item.QuotaUsed ?? 0;
                    var Remainnig = int.Parse(quotaAssigned) - quotaUsed;
                    string year = item.Year;
                    dt.Rows.Add(id, sn, Name, quotaAssigned, quotaUsed, Remainnig, year);
                }
                gvAllQuota.DataSource = dt;
                gvAllQuota.DataBind();
                gvAllQuota.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
        }

        protected void gvAllQuota_RowCommand(object sender, GridViewCommandEventArgs e)
        {

        }
    }
}