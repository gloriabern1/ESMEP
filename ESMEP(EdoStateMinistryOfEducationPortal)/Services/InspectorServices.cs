using ESMEP_EdoStateMinistryOfEducationPortal_.Infrastructure;
using ESMEP_EdoStateMinistryOfEducationPortal_.Infrastructure.Handler;
using ESMEP_EdoStateMinistryOfEducationPortal_.Models;
using ESMEP_EdoStateMinistryOfEducationPortal_.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;

namespace ESMEP_EdoStateMinistryOfEducationPortal_.Services
{

    public class InspectorServices
    {
        UnitOfWork unitOfWork = new UnitOfWork();
        UserHandler userHandler = new UserHandler();
        //public InspectorServices(UnitOfWork unitOfWorkParam)
        //{
        //    this.unitOfWork = unitOfWorkParam;
        //}
        string UserName = HttpContext.Current.User.Identity.Name;

        public string GetUser
        {
            get { return UserName ?? HttpContext.Current.User.Identity.Name; }
            set { UserName = value; }
        }

        public IEnumerable<InspectorViewModel> GetLgaInspector()
        {
            IList<InspectorViewModel> Cies = null;
            int counter = 0;
            Cies = unitOfWork.lga.Get(filter: x => x.StateId.TrimEnd() == "ED")
                .Select(x => new InspectorViewModel
                {
                    Id = ++counter,
                    LgaId = x.ID,
                    LocalGovtName = x.LocalGovernment1

                }).ToList();
            Cies.ToList().ForEach(x => x.Name = GetInspector(x.LgaId)?.CIEName ?? "No Inspector Assigned");

            return Cies;
        }

        public Inspector GetInspector(int LgaId)
        {
            return unitOfWork.inspector.Get(x => x.LocalGovernmentId == LgaId).FirstOrDefault();
        }

        private bool InsertInspector(Inspector model)
        {
            if (model != null)
            {
                unitOfWork.inspector.Insert(model);
                unitOfWork.Save();
                return true;
            }
            return false;
        }

        public Inspector GetInspectorByName()
        {
            var inspector = unitOfWork.inspector.Get(x => x.Email == UserName).FirstOrDefault();
            return inspector;
        }

        public bool AddInspector(UserViewModel model)
        {
            if(model != null)
            {
                Inspector inspector = new Inspector()
                {
                    CIEName = model.FullName,
                    Email = model.Email,
                    LocalGovernmentId = model.LgaId,
                    CreatedOn = DateTime.Now,
                    CreatedBy = HttpContext.Current.User.Identity.Name
                };
                var result = userHandler.CreateUser(model.Email, model.Password);
                if (result)
                {
                    return InsertInspector(inspector);
                }
            }
            return false;
        }

    }


}