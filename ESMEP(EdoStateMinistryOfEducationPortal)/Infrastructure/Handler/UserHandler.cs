using ESMEP_EdoStateMinistryOfEducationPortal_.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Web;
using System.Web.UI;

namespace ESMEP_EdoStateMinistryOfEducationPortal_.Infrastructure.Handler
{
    public class UserHandler : Page
    {
        public bool CreateUser(string email, string Password)
        {
            try
            {
                var manager = Context.GetOwinContext().GetUserManager<ApplicationUserManager>();
                var signInManager = Context.GetOwinContext().Get<ApplicationSignInManager>();
                var user = new ApplicationUser() { UserName = email, Email = email };
                IdentityResult result = manager.Create(user, Password);
                if (result.Succeeded)
                {
                    // For more information on how to enable account confirmation and password reset please visit https://go.microsoft.com/fwlink/?LinkID=320771
                    //string code = manager.GenerateEmailConfirmationToken(user.Id);
                    //string callbackUrl = IdentityHelper.GetUserConfirmationRedirectUrl(code, user.Id, Request);
                    //manager.SendEmail(user.Id, "Confirm your account", "Please confirm your account by clicking <a href=\"" + callbackUrl + "\">here</a>.");
                    manager.AddToRole(user.Id, "Inspector");
                    //signInManager.SignIn(user, isPersistent: false, rememberBrowser: false);
                    return true;
                }
                return true;
            }
            catch (Exception ex)
            {
                return false;
                //throw ex;
            }
         
         
        }
    }
}