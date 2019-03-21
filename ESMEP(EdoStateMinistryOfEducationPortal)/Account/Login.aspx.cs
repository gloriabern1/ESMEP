using System;
using System.Web;
using System.Web.UI;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System.Linq;
using Owin;
using ESMEP_EdoStateMinistryOfEducationPortal_.Models;
using System.Collections.Generic;
using ESMEP_EdoStateMinistryOfEducationPortal_.ViewModels;
using ESMEP_EdoStateMinistryOfEducationPortal_.Infrastructure;

namespace ESMEP_EdoStateMinistryOfEducationPortal_.Account
{
    public partial class Login : Page
    {
        private UnitOfWork unitOfWork = new UnitOfWork();
        protected void Page_Load(object sender, EventArgs e)
        {
            RegisterHyperLink.NavigateUrl = "Register";
            // Enable this once you have account confirmation enabled for password reset functionality
            //ForgotPasswordHyperLink.NavigateUrl = "Forgot";
            var returnUrl = HttpUtility.UrlEncode(Request.QueryString["ReturnUrl"]);
            if (!String.IsNullOrEmpty(returnUrl))
            {
                RegisterHyperLink.NavigateUrl += "?ReturnUrl=" + returnUrl;
            }
            ErrorMessage.Text = "";
        }

        private void ValidateInput()
        {
            if (txtEmail.Value == "" || txtEmail.Value == null)
            {
                ErrorMessage.Text = "Enter Username";
                return;
            }
            if(txtPassword.Value == "" || txtPassword.Value == null)
            {
                ErrorMessage.Text = "Enter Password";
                return;
            }
        }

        protected void LogIn(object sender, EventArgs e)
        {
            ValidateInput();
            if (IsValid)
            {
                // Validate the user password
                var manager = Context.GetOwinContext().GetUserManager<ApplicationUserManager>();
                var signinManager = Context.GetOwinContext().GetUserManager<ApplicationSignInManager>();

                // This doen't count login failures towards account lockout
                // To enable password failures to trigger lockout, change to shouldLockout: true
                var result = signinManager.PasswordSignIn(txtEmail.Value, txtPassword.Value, chkRememberMe.Checked, shouldLockout: false);
     
                switch (result)
                {
                    case SignInStatus.Success:
                        IList<string> roles = null;
                        var user = signinManager.AuthenticationManager.AuthenticationResponseGrant.Identity;
                        string userId = user.GetUserId();
                        string Name = user.GetUserName();

                        roles = manager.GetRoles(userId);
                        SessionObject sessionObject = new SessionObject
                        {
                            UserId = userId,
                            Name = Name
                        };
                        //Session.Add("Name", user.GetUserName().ToString());
                        //    Session.Add("UserId", userId);

                        foreach (var item in roles)
                        {                              
                                if (item.Contains("Super Admin"))
                                {
                                Session["EdoSessionObject"] = sessionObject;
                                //IdentityHelper.RedirectToReturnUrl("~/Modules/Home", Response);
                                Response.Redirect("~/Modules/Home");
                                   
                                }
                            else if (item.Contains("Admin"))
                            {
                                Session["EdoSessionObject"] = sessionObject;
                                //IdentityHelper.RedirectToReturnUrl("~/Modules/Home", Response);
                                Response.Redirect("~/Modules/Home");

                            }
                            else if (item.Contains("School"))
                                {
                                //IdentityHelper.RedirectToReturnUrl("~/Modules/School/AllStudentBySchool", Response);

                                    var school = unitOfWork.School.Get(x => x.UserId == userId).FirstOrDefault();
                                    if(school != null)
                                    {
                                        sessionObject.CategoryId = school.CategoryId.Value;
                                        sessionObject.SchoolId = school.Id;
                                        sessionObject.SchoolType = school.SchoolTypeId;
                                        sessionObject.LgaId = school.LocalGovernmentID;
                                    }
                                    Session["EdoSessionObject"] = sessionObject;
                                    Response.Redirect("~/Modules/School/AllStudentBySchool");
                                }
                                else if (item.Contains("Inspector"))
                                {
                                var inspector = unitOfWork.inspector.Get(x => x.Email == Name).FirstOrDefault();
                                if (inspector != null)
                                {
                                    sessionObject.LgaId = inspector.LocalGovernmentId;
                                }
                                Session["EdoSessionObject"] = sessionObject;
                                    Response.Redirect("~/Modules/Inspectors/InspectorSchools");
                                }
                                else
                                {
                                    Session.Add("Name", "Admin@example.com");
                                    Session.Add("UserId", "1031be11-7a40-499f-9f60-69a0d0d37bc0");
                                    Response.Redirect("~/Modules/Home");

                                }
                            }

                        Session["EdoSessionObject"] = sessionObject;
                        break;
                    case SignInStatus.LockedOut:
                        Response.Redirect("/Account/Lockout");
                        break;
                    case SignInStatus.RequiresVerification:
                        Response.Redirect(String.Format("/Account/TwoFactorAuthenticationSignIn?ReturnUrl={0}&RememberMe={1}", 
                                                        Request.QueryString["ReturnUrl"],
                                                        chkRememberMe.Checked),
                                          true);
                        break;
                    case SignInStatus.Failure:
                    default:
                        ErrorMessage.Text = "Invalid login attempt";
                        ErrorMessage.Visible = true;
                        break;
                }
            }
        }
    }
}