using ESMEP_EdoStateMinistryOfEducationPortal_.Infrastructure;
using System;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ESMEP_EdoStateMinistryOfEducationPortal_.Models;
using ESMEP_EdoStateMinistryOfEducationPortal_.ViewModels;

namespace ESMEP_EdoStateMinistryOfEducationPortal_
{
    public partial class Default : System.Web.UI.MasterPage
    {
        ApplicationDbContext db = new ApplicationDbContext();
        UnitOfWork unitOfWork = new UnitOfWork();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                try
                {
                    if (HttpContext.Current.User.Identity != null)
                    {
                        if (HttpContext.Current.User.Identity.IsAuthenticated)
                        {
                            var sessionUser = (SessionObject)Session["EdoSessionObject"];
                            if (!string.IsNullOrEmpty(sessionUser.Name))
                            {
                                lblUsername.Text = sessionUser.Name;
                            }
                            else
                            {
                                sessionUser.Name = HttpContext.Current.User.Identity.GetUserName();
                            }
                            LoadMenu(sessionUser.Name, sessionUser.UserId);
                        }
                    }
                    else
                    {
                        Response.Redirect("~/Account/Login");
                    }
                    
                }
                catch (Exception)
                {
                    Response.Redirect("~/Account/Login");
                }
            }


        }
        public void LoadMenu(string userName, string userId)
        {          
            StringBuilder str = new StringBuilder();
            string Dashboardurl = Page.ResolveClientUrl("~/Modules/Home");
            str.Append(Environment.NewLine);
            str.Append(String.Format(@"<li class=""sidebar-toggler-wrapper hide""><div class=""sidebar-toggler""><span></span></div></li>
	                                     <li class=""sidebar-user-panel""><div class=""user-panel""><div class=""pull-left image""><img src =""/Content/assets/img/images.png"" class=""img-circle user-img-circle"" alt=""User Image""/></div>
	                                      <div class=""pull-left info""><p>{0}</p>
	                                      <a href = ""#"" ><i class=""fa fa-circle user-online""></i><span class=""txtOnline""> Online</span></a>
	                                    </div></div></li>
                                <li class=""nav- item""><a runat=""server"" href=""{1}"" class=""nav-link""><i class=""material-icons"">dashboard</i><span class=""title"">Dashboard</span></a>
	                           </li>", userName.Substring(0,5), Dashboardurl));
            
            
            var usersWithRoles = (from user in db.Users
                                  select new
                                  {
                                      UserId = user.Id,
                                      Username = user.UserName,
                                      Email = user.Email,
                                      RoleId = (from userRole in user.Roles
                                                join role in db.Roles on userRole.RoleId
                                                equals role.Id
                                                select role.Id).ToList()
                                  }).Where(x => x.UserId == userId).ToList().Select(p => new Users_in_Role_ViewModel()

                                  {
                                      UserId = p.UserId,
                                      Username = p.Username,
                                      Email = p.Email,
                                      Role = string.Join(",", p.RoleId)
                                  });
            string url = "";

            IList<MenuViewModel> MenuList = new List<MenuViewModel>();
            IList<MenuMainViewModel> MainMenuList = new List<MenuMainViewModel>();           

            foreach (var item in usersWithRoles)
            {
                var menu = unitOfWork.MenuInRole.Get(x => x.RoleId.ToString() == item.Role, includeProperties: "MenuSub").OrderBy(x => x.MenuSub.MenuMain.PRIORITY);
                if (menu != null)
                {
                    //   var mainmenu = menu.Where(x => x.MenuSub.MenuMain)
                    foreach (var item1 in menu)
                    {
                        MenuMainViewModel AllMainMenus = new MenuMainViewModel();
                        MenuViewModel Meuns = new MenuViewModel();

                        if (MainMenuList.Count() == 0)
                        {
                            AllMainMenus.Id = item1.MenuSub.MenuMainId;
                            AllMainMenus.MenuName = item1.MenuSub.MenuMain.Name;
                            AllMainMenus.Icons = item1.MenuSub.MenuMain.ICONS;
                            MainMenuList.Add(AllMainMenus);
                        }
                        else if (MainMenuList.All(x => x.Id != item1.MenuSub.MenuMainId))
                        {
                            AllMainMenus.Id = item1.MenuSub.MenuMainId;
                            AllMainMenus.MenuName = item1.MenuSub.MenuMain.Name;
                            AllMainMenus.Icons = item1.MenuSub.MenuMain.ICONS;
                            MainMenuList.Add(AllMainMenus);
                        }                  
                            Meuns.RoleId = item1.RoleId.ToString();
                            Meuns.MenuId = item1.MenuSubId;
                            Meuns.MenuTitle = item1.MenuSub.MenuTitle;
                            url = Page.ResolveClientUrl("" + item1.MenuSub.URL + "");
                            Meuns.URL = url;
                            Meuns.MAIN_MENU = item1.MenuSub.MenuMain.Name;
                            Meuns.ICONS = item1.MenuSub.MenuMain.ICONS;
                            Meuns.MainMenuId = item1.MenuSub.MenuMainId;
                            MenuList.Add(Meuns);                                             
                    }
                }
                   
                if(MainMenuList != null)
                {
                     foreach (var m in MainMenuList)
                     {
                        str.Append(Environment.NewLine);
                        str.Append(String.Format(@"<li class=""nav-item""><a href=""#"" class=""nav-link nav-toggle""> <i class=""material-icons""> {0}</i><span class=""title"">{1}</span><span class=""arrow""></span></a>" + Environment.NewLine, m.Icons, m.MenuName));
                        str.Append(String.Format(@"<ul class=""sub-menu"">" + Environment.NewLine));
                        foreach (var l in MenuList.Where(x => x.MainMenuId == m.Id))
                        {
                            str.Append(String.Format(@"<li><a runat=""server"" href=""{0}"" class=""nav-link""><span class=""title"">{1}</span></a></li>" + Environment.NewLine, l.URL, l.MenuTitle));

                        }
                        str.Append("</ul>" + Environment.NewLine);
                        str.Append("</li>" + Environment.NewLine);             
                    }
                    MenuPanel.InnerHtml = str.ToString();
                }
            }
        }

        protected void btnlogin_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Session.Abandon();
            Session.RemoveAll();
            var signinManager = Context.GetOwinContext().GetUserManager<ApplicationSignInManager>();
            signinManager.AuthenticationManager.SignOut(DefaultAuthenticationTypes.ApplicationCookie);

            Response.Redirect("~/Account/Login");
        }
    }
}