using ESMEP_EdoStateMinistryOfEducationPortal_.Infrastructure;
using ESMEP_EdoStateMinistryOfEducationPortal_.Infrastructure.Managers;
using ESMEP_EdoStateMinistryOfEducationPortal_.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ESMEP_EdoStateMinistryOfEducationPortal_.Modules.Registration
{
    public partial class AddSchool : System.Web.UI.Page
    {
        UnitOfWork unitOfWork = new UnitOfWork();
        DropDownManager dropDownManager = new DropDownManager();

        protected void Page_Load(object sender, EventArgs e)
        {
            Page.Title = "Add New School";            
            if (!Page.IsPostBack)
            {
                dropDownManager.GetLGA(ddlLGA, "ED");
                dropDownManager.GetCategory(ddlSchoolCat);
                dropDownManager.GetTitle(ddlTitle);
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (ValidateInputs())
            {
                var manager = Context.GetOwinContext().GetUserManager<ApplicationUserManager>();
                var signInManager = Context.GetOwinContext().Get<ApplicationSignInManager>();
                var user = new ApplicationUser() { UserName = txtEmail.Value, Email = txtEmail.Value, PhoneNumber = txtMobileNo.Value };
                IdentityResult result = manager.Create(user, "@Ab1234567");
                if (result.Succeeded)
                {
                    // For more information on how to enable account confirmation and password reset please visit https://go.microsoft.com/fwlink/?LinkID=320771
                    //string code = manager.GenerateEmailConfirmationToken(user.Id);
                    //string callbackUrl = IdentityHelper.GetUserConfirmationRedirectUrl(code, user.Id, Request);
                    manager.AddToRole(user.Id, "School");
                    //manager.SendEmail(user.Id, "Confirm your account", "Please confirm your account by clicking <a href=\"" + callbackUrl + "\">here</a>.");
                    int selectedRadio = 0;
                    if(radPublic.Checked == true)
                    {
                        selectedRadio = int.Parse(radPublic.Value);
                    }
                    else
                    {
                        selectedRadio = int.Parse(radPrivate.Value);
                    }
                    var school = new Models.School()
                    {
                        Name = txtname.Value,
                        Address = txtAddress.Value,
                        Email = txtEmail.Value,
                        MobileNo = Convert.ToDecimal(txtMobileNo.Value),
                        NameOfPrincipal = ddlTitle.SelectedItem.Text + " " + txtPrincipal.Value,
                        DateOfIncorporation = Convert.ToDateTime(txtdate.Value),
                        SchoolTypeId = selectedRadio,
                        CategoryId = int.Parse(ddlSchoolCat.SelectedValue),
                        LocalGovernmentID = int.Parse(ddlLGA.SelectedValue),
                        UserId = user.Id,
                        CreatedBy = "",                        
                        DateCreated = DateTime.Now                   
                    };
                    unitOfWork.School.Insert(school);
                    unitOfWork.Save();
                    //signInManager.SignIn(user, isPersistent: false, rememberBrowser: false);
                    dropDownManager.ShowPopUp("School Added Successfully !!!");
                    //IdentityHelper.RedirectToReturnUrl("Registration/School", Response);
                    ClearInput();
                }
                else
                {
                    ErrorMessage.Text = result.Errors.FirstOrDefault();
                }

            }

        }

        public bool ValidateInputs()
        {
            if (String.IsNullOrEmpty(txtname.Value))
            {
                ErrorMessage.Text = "School Name is Require";
                // dropDownManager.ShowPopUp("School Name is Require");     
                return false;          
            }
            if (String.IsNullOrEmpty(txtAddress.Value))
            {
                ErrorMessage.Text = "School Address is Require";
               // dropDownManager.ShowPopUp("School Address is Require");
            
            }
            if (String.IsNullOrEmpty(txtEmail.Value))
            {
                ErrorMessage.Text = "School Email Address is Require";
               // dropDownManager.ShowPopUp("School Email Address is Require");
                return false;
            }
            if (String.IsNullOrEmpty(txtPrincipal.Value))
            {
                ErrorMessage.Text = "Principal's Full Name is Require";
               // dropDownManager.ShowPopUp("Principal's Full Name is Require");
                return false;
            }
            if (String.IsNullOrEmpty(txtMobileNo.Value))
            {
                ErrorMessage.Text = "School Mobile Number is Require";
                //dropDownManager.ShowPopUp("School Mobile Number is Require");
                return false;
            }
            if (ddlLGA.SelectedIndex == 0)
            {
                ErrorMessage.Text = "Select Local Government";
               // dropDownManager.ShowPopUp("Select Local Government");                
                return false;
            }
            if (ddlSchoolCat.SelectedIndex == 0)
            {
                ErrorMessage.Text = "Select Category";
               // dropDownManager.ShowPopUp("Select Category");
                return false;
            }
            if (Convert.ToDateTime(txtdate.Value) > DateTime.Now)
            {
                ErrorMessage.Text = "Sorry, Date cannot be greater than today";
                //dropDownManager.ShowPopUp("Sorry, Date cannot be greater than today");
                return false;
            }
            return true;
        }

        void ClearInput()
        {
            txtAddress.Value = "";
            txtEmail.Value = "";
            txtname.Value = "";
            txtPrincipal.Value = "";
            txtdate.Value = "";
            txtMobileNo.Value = "";
            ddlLGA.SelectedIndex = 0;
            ddlSchoolCat.SelectedIndex = 0;
            ddlTitle.SelectedIndex = 0;
            radPublic.Checked = true;
        }
    }
}