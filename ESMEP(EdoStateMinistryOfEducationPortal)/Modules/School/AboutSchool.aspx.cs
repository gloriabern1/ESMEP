using ESMEP_EdoStateMinistryOfEducationPortal_.Infrastructure.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ESMEP_EdoStateMinistryOfEducationPortal_.Modules.School
{
    public partial class ViewDetails : System.Web.UI.Page
    {
        DropDownManager dropDownManager = new DropDownManager();
        StaticsManager statManager = new StaticsManager();
        protected void Page_Load(object sender, EventArgs e)
        {
            string schoolid = Request.QueryString.Get("Id").ToString();
            if (!Page.IsPostBack)
            {
                LoadSchool(schoolid);
            }
        }

        public void LoadSchool(string id)
        {

            if (id != null)
            {
              var school = dropDownManager.GetSchool(id);
              
                lblEmail.Text = school.Email;
                lblDate.Text = school.DateOfIncorporation.ToLongDateString();
                lblPrincipal.Text = school.NameOfPrincipal;
                lblStudent.Text = statManager.GetStudentCount(int.Parse(id));
                lblLga.Text = school.LocalGovernment.LocalGovernment1;
                lblDate1.Text = school.DateOfIncorporation.Year.ToString();
                lblDate2.Text = school.DateOfIncorporation.ToLongDateString();
            }
        }
    }

}