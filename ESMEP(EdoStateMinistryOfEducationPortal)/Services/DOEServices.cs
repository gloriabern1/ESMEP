using ESMEP_EdoStateMinistryOfEducationPortal_.Infrastructure;
using ESMEP_EdoStateMinistryOfEducationPortal_.Infrastructure.Handler;
using ESMEP_EdoStateMinistryOfEducationPortal_.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ESMEP_EdoStateMinistryOfEducationPortal_.Services
{
    public class DOEServices
    {
       private  UnitOfWork unitOfWork = new UnitOfWork();
     
        public  string AddSchoolApproval(SchoolApproval model)
        {

            try
            {
                SchoolApproval schoolApproval = new SchoolApproval()
                {
                    YearId = model.YearId,
                    SchoolId= model.SchoolId,
                    BatchId=model.BatchId,
                    Activated= true,
                    DateApproved = DateTime.Now,

                };
                unitOfWork.SchoolApproval.Insert(schoolApproval);
                unitOfWork.Save();
              
                return schoolApproval.BatchId.ToString();
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public  int ReturnPreviousBatch(int SessionId, int SchoolId)
        {
            
            var schoolApproval = unitOfWork.SchoolApproval.GetQueryable(filter: x => x.YearId == SessionId && x.SchoolId == SchoolId && x.ReceiptID == null).FirstOrDefault();
            if (schoolApproval != null && schoolApproval.ReceiptID == null)
            {

                return int.Parse(schoolApproval.BatchId.ToString());
            }
            return 0;
        }

        public int GetMaxBatchInSchool(int SessionId, int SchoolId)
        {

            string Batchid = unitOfWork.SchoolApproval.GetQueryable(filter: x => x.YearId == SessionId && x.SchoolId == SchoolId).Max(p => p.BatchId).ToString();
            if (Batchid == null || Batchid== "")
            {

               return 1 ;
            }
            return int.Parse(Batchid) + 1;
        }

        public  string GetBatchApproval(int SessionId, int SchoolId)
        {
            int BatchId = ReturnPreviousBatch(SessionId, SchoolId);
            if (BatchId == 0)
            {
                BatchId = GetMaxBatchInSchool(SessionId, SchoolId);
                SchoolApproval schoolApproval = new SchoolApproval()
                {
                    YearId = SessionId,
                    SchoolId = SchoolId,
                    BatchId = BatchId,
                   
                };

                return AddSchoolApproval(schoolApproval);
            }
            else
            {
                return BatchId.ToString();
            }
           
            
        }

        public void UpdateStudentData(int studentID, bool approved, int schoolId, int SessionId, int Batchid)
        {
            var student = unitOfWork.studentData.GetByID(studentID);
            student.DOEApproval = approved;
            if (student.BatchID == null)
            {
                student.BatchID = Batchid;
            }
            student.DateModified = DateTime.Now.ToShortDateString();
            unitOfWork.studentData.Update(student);
            unitOfWork.Save();
        }
    }
}