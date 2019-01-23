using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ESMEP_EdoStateMinistryOfEducationPortal_.ViewModels
{
    public class AllViewModels
    {
    }

    public class MenuViewModel
    {
        public string MAIN_MENU { get; set; }
        public string ICONS { get; set; }
        public bool? ACTIVATED { get; set; }
        public int Menu_In_RoleID { get; set; }
        public int MenuId { get; set; }
        public string RoleId { get; set; }
        public int MainMenuId { get; set; }
        public string MenuTitle { get; set; }
        public string URL { get; set; }


    }
    public class Users_in_Role_ViewModel
    {
        public string UserId { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Role { get; set; }
    }

    public class MenuMainViewModel
    {
        public int Id { get; set; }
        public string MenuName { get; set; }
        public string Icons { get; set; }

    }
}