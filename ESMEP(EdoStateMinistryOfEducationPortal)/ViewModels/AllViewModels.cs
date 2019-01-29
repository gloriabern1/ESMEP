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

    public class InspectorViewModel
    {
        public int Id { get; set; }
        public int LgaId  { get; set; }
        public string Name { get; set; }
        public string LocalGovtName { get; set; }
        public string Email { get; set; }        
    }

    public class UserViewModel
    {
        public string FullName { get; set; }
        public string Email { get; set; }
        public int LgaId { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }

    }
    public class SessionObject
    {
        public int SchoolId { get; set; }
        public int LgaId { get; set; }
        public int CategoryId { get; set; }
        public int SchoolType { get; set; }
        public string UserId { get; set; }
        public string Name { get; set; }
    }
}