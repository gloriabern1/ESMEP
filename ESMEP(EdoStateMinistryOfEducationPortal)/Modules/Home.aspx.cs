using ESMEP_EdoStateMinistryOfEducationPortal_.Infrastructure.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ESMEP_EdoStateMinistryOfEducationPortal_.Modules
{
    public partial class Home : System.Web.UI.Page
    {
        StaticsManager statManager = new StaticsManager();

        protected void Page_Load(object sender, EventArgs e)
        {
            lblSchool.Text = statManager.GetSchoolCount();
            lblStudent.Text = statManager.GetStudentCount();
            lblFees.Text = statManager.GetFeesSum().ToString();
            lblRegistered.Text = statManager.GetRegisteredStudentCount();
        }

    }
}