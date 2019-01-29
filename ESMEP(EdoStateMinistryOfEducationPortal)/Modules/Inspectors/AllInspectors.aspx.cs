using ESMEP_EdoStateMinistryOfEducationPortal_.Infrastructure;
using ESMEP_EdoStateMinistryOfEducationPortal_.Infrastructure.Managers;
using ESMEP_EdoStateMinistryOfEducationPortal_.Services;
using ESMEP_EdoStateMinistryOfEducationPortal_.ViewModels;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ESMEP_EdoStateMinistryOfEducationPortal_.Modules.Inspectors
{
    public partial class LgaInspector : System.Web.UI.Page
    {
        InspectorServices inspectorServices = new InspectorServices();
        DropDownManager dropDownManager = new DropDownManager();

        //public LgaInspector(InspectorServices inspectorServicesParam)
        //{
        //    inspectorServices = inspectorServicesParam;
        //}

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                dropDownManager.GetTitle(ddlTitle);
                loadTable();
            }
        }

        public IEnumerable<InspectorViewModel> AllInspector()
        {
            return inspectorServices.GetLgaInspector();
        }

        public void loadTable()
        {
            var dt = AllInspector();
            gvInspector.DataSource = dt;
            gvInspector.DataBind();

            foreach (GridViewRow row in gvInspector.Rows)
            {
                Label Name = (Label)row.FindControl("name");
                Button view = (Button)row.FindControl("btnview");
                Button create = (Button)row.FindControl("btnAdd");

                if (Name.Text == "No Inspector Assigned")
                {
                    create.Visible = true;
                    view.Visible = false;
                }
                else
                {
                    create.Visible = false;
                    view.Visible = true;
                }
            }
            Multiview1.ActiveViewIndex = 0;
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Multiview1.ActiveViewIndex = 0;
        }

        protected void gvInspector_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            string command = e.CommandName.ToString();
            string lgaId = e.CommandArgument.ToString();
            lblLgaId.Text = lgaId;
            if (command == "doview")
            {
                Multiview1.ActiveViewIndex = 0;
            }
            else
            {
                Multiview1.ActiveViewIndex = 1;
            }

        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (ValidateData())
            {
                UserViewModel user = new UserViewModel()
                {
                    FullName = $"{txtFname.Value} {txtOname.Value} {txtLname.Value}",
                    Email = username.Value,
                    LgaId = int.Parse(lblLgaId.Text),
                    UserName = username.Value,
                    Password = password.Value
                };
                var result = inspectorServices.AddInspector(user);
                if (result)
                {
                    loadTable();
                    ClientScript.RegisterStartupScript(this.GetType(), "ramdomtext", "success()", true);
                }
            }
            else
            {
                ClientScript.RegisterStartupScript(this.GetType(), "ramdomtext", "error()", true);
            }
        }

        bool ValidateData()
        {
            if(username.Value == "")
            {
                ErrorMessage.Text = "Please Enter Email/Username";
                return false;
            }
                     

            if(password.Value == string.Empty)
            {
                ErrorMessage.Text = "Password Field is Required";
                return false;
            }

            if(confirmPassword.Value == string.Empty)
            {
                ErrorMessage.Text = "Confirm Password Field is Required";
                return false;
            }
            
            if(confirmPassword.Value != password.Value)
            {
                ErrorMessage.Text = "Confirm Password does not match Password";
                return false;
            }

            if(txtFname.Value == string.Empty)
            {
                ErrorMessage.Text = "First Name Field is Required";
                return false;
            }

            if(txtLname.Value == string.Empty)
            {
                ErrorMessage.Text = "Last Name Field is Required";
                return false;
            }
            return true;
        }
    }
}