using ESMEP_EdoStateMinistryOfEducationPortal_.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ESMEP_EdoStateMinistryOfEducationPortal_.Infrastructure.Managers
{
    public class StaticsManager
    {
        UnitOfWork unitOfWork = new UnitOfWork();
        int noFStudent = 0;
        public string GetSchoolCount()
        {
            var count = unitOfWork.School.Get().Count().ToString();
            return count != null ? count : "0";
        }

        public string GetStudentCount(int id = 0)
        {
            if(id == 0)
            {
                var count = unitOfWork.studentData.Get().Count().ToString();
                return count == null ? "0" : count;
            }
            else
            {
                var count = unitOfWork.studentData.Get(x => x.SchoolId == id).Count().ToString();
                return count == null ? "0" : count;
            }
        }

        public string GetRegisteredStudentCount()
        {
            string count = null;
            var registeredStudents = unitOfWork.ExamRegistered.Get().Select(x => x.StudentId).Distinct();     
            count = registeredStudents.Count().ToString();
            return count == null ? "0" : count;
        }
    
        public decimal GetFeesSum()
        {
            decimal sum = 0;
            List<ExaminationRegistered> ExamReg = new List<ExaminationRegistered>();
            var registeredStudents = unitOfWork.ExamRegistered.Get().Distinct();
            if (registeredStudents != null)
            {
                ExamReg = new List<ExaminationRegistered>();
                foreach (var item in registeredStudents)
                {
                    if (ExamReg.Count == 0)
                    {
                        ExamReg.Add(item);
                    }
                    else if (ExamReg.Any(x => x.StudentId != item.StudentId))
                    {
                        ExamReg.Add(item);
                    }
                }
               // sum = examFee * noFStudent;
                sum = ExamReg.Sum(x => Convert.ToInt64(x.Examination.Fee));
            }
            return sum == 0 ? 0 : sum;
        }

    }
}