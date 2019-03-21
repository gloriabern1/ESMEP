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
using ESMEP_EdoStateMinistryOfEducationPortal_.Infrastructure.Managers;

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

        public bool ApproveOrRejectAttendance(bool status, int schoolId, string examId, string subjectId, string session)
        {
            int exam = 0;
            int sessionId = 0;
            int.TryParse(session, out sessionId);
            int.TryParse(examId, out exam);
            var registeredExam = DropDownManager.GetRegistrations(schoolId, sessionId, exam, subjectId);
            foreach (var item in registeredExam)
            {
                item.AttendanceApprovedByInspector = status;
                unitOfWork.ExamRegistered.Update(item);
                unitOfWork.Save();
            }
            return true;
        }
        public bool ApproveOrRejectSchedule(bool status, int schoolId, string examId, string session)
        {
            int exam = 0;
            int sessionId = 0;
            int.TryParse(session, out sessionId);
            int.TryParse(examId, out exam);
            var registeredExam = DropDownManager.GetRegistrations(schoolId, sessionId, exam).FirstOrDefault();
            registeredExam.EntyScheduleApprovedByInspector = status;
            unitOfWork.ExamRegistered.Update(registeredExam);
            unitOfWork.Save();
            return true;
        }


    }


}