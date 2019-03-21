using ESMEP_EdoStateMinistryOfEducationPortal_.Models;
using ESMEP_EdoStateMinistryOfEducationPortal_.ViewModels;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;

namespace ESMEP_EdoStateMinistryOfEducationPortal_.Infrastructure.Managers
{
    public class GeneralUtility
    {
        protected static Hashtable handlerPages = new Hashtable();
        public static SessionObject sessionUser;

        public static SessionObject SessionUser
        {
            get { return sessionUser ?? (SessionObject)HttpContext.Current.Session["EdoSessionObject"]; }
            set { value = sessionUser; }
        }
        private static UnitOfWork unitofwork = new UnitOfWork();

        public GeneralUtility()
        {

        }

        public static string GetExcelFile(HtmlInputFile xlsxSchol)
        {
            var Foldername = HttpContext.Current.Server.MapPath("~/Static Content/Documents/");
            string fileName = Path.GetFileNameWithoutExtension(xlsxSchol.PostedFile.FileName);
            string extenstion = Path.GetExtension(xlsxSchol.PostedFile.FileName);
            fileName = Path.Combine(Foldername + fileName);
            xlsxSchol.PostedFile.SaveAs(fileName);
            return fileName;
        }

        public static bool AddStudent(XmlSponosorUpload xmlSponosor, XmlStudentUpload model)
        {
            try
            {
                var student = new Student()
                {
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    MiddleName = model.OtherName,
                    FullName = model.FullName,
                    DateOfBirth = model.DateofBirth,
                    Sex = model.Gender,
                    PassportUrl = model.Base64Picture,
                    Address = model.Address,
                    LocalGovernmentID = SessionUser.LgaId,
                    RegNumber = model.RegNum,
                    ExamYear = model.ExamYear,
                    SchoolId = SessionUser.SchoolId,
                    DateCreated = DateTime.Now.ToShortDateString(),
                    CreatedBy = SessionUser.UserId

                };
                unitofwork.studentData.Insert(student);
                unitofwork.Save();
                SaveSponosorDetail(xmlSponosor, student.StudentId);
                // InsertAudit("StudentBioData StudentPicture", student.Id, "Insert");
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }



        public static bool SaveSponosorDetail(XmlSponosorUpload model, int StudentId)
        {
            try
            {
                var relationship = DropDownManager.GetRelationShipByName(model.SponosorRelationship);
                var sponosor = new StudentGuardianDetial()
                {
                    FullName = model.SponosorName,
                    Email = model.SponosorEmail,
                    MobileNo = model.SponosorPhone,
                    Address = model.SponosorAddress,
                    RelationShip = relationship,
                    StudentId = StudentId
                };
                unitofwork.GuardianDetails.Insert(sponosor);
                unitofwork.Save();
                UpdateStudentData(sponosor.ID, StudentId);
                // InsertAudit("Student Sponosor Details", sponosor.Id, "Insert");
                // AddStudent(xmlStudent, sponosor.ID);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public static void UpdateStudentData(int sponosorId, int studentID)
        {
            var student = unitofwork.studentData.GetByID(studentID);
            student.StudentGuardianDetialID = sponosorId;
            unitofwork.studentData.Update(student);
            unitofwork.Save();
        }

        public static bool AddQuota(QuotaViewModel model)
        {
            if (model != null)
            {
                SchoolQuota quota = new SchoolQuota()
                {
                    QuotaAssigned = model.Quota,
                    SchoolId = model.SchoolId,
                    SessionId = model.SessionId,
                    Year = model.Year,
                    DateCreated = DateTime.Now,
                    CreatedBy = SessionUser.Name,
                    UserId = SessionUser.UserId
                };
                unitofwork.Quota.Insert(quota);
                unitofwork.Save();
                return true;
            }
            return false;
        }

        public static void UpdateUsedQuota(int schoolId, int usedQuota)
        {
            if (schoolId != 0)
            {
                var quota = unitofwork.Quota.GetQueryable(filter: x => x.SchoolId == schoolId).FirstOrDefault();
                quota.QuotaUsed = quota.QuotaUsed + usedQuota;
                unitofwork.Quota.Insert(quota);
                unitofwork.Save();
            }
        }

        public static bool HasSchoolBeenAssignedQuota(int schoolId)
        {
            if (schoolId != 0)
            {
                var quota = unitofwork.Quota.GetQueryable(filter: x => x.SchoolId == schoolId).FirstOrDefault();
                if (quota == null)
                    return false;
                else
                    return true;
            }
            return false;
        }

        public static int GetQuotaForSchool(int schoolId)
        {
            if (schoolId != 0)
            {
                var quota = unitofwork.Quota.GetQueryable(filter: x => x.SchoolId == schoolId).FirstOrDefault();
                if (quota == null)
                    return quota.QuotaAssigned;
                else
                    return 0;
            }
            return 0;
        }

        public static IEnumerable<SchoolQuota> GetQuotas(int SessionId)
        {
            return unitofwork.Quota.GetQueryable(x => x.SessionId == SessionId, includeProperties: "School , Session");
        }

        public static string  ApproveSchool (int SchoolId, int sessionid){
          
            SqlParameter[] xparams = {
            new SqlParameter("@ParamApproveCount", SqlDbType.Int) {Direction = ParameterDirection.Output},
            new SqlParameter("@ParamSessionId", sessionid),
            new SqlParameter("@ParamSchoolId", SchoolId )
            };
            string CountApproved = unitofwork.ExecuteNonQuery("STP_APPROVE_SCHOOL", System.Data.CommandType.StoredProcedure, xparams);
            return CountApproved;
            }
        public static int GetCurrentSessionId()
        {
            var Session = unitofwork.session.GetQueryable(filter: x => x.Is_Current == true).FirstOrDefault();
            if(Session!= null)
            {
                return Session.ID;
            }
            else
            {
                return -1;
            }
        }

        public static IEnumerable<Student> GetStudentsInSession(int SessionId, int SchoolId) 
        {
            return unitofwork.studentData.GetQueryable(x => x.SessionId == SessionId && x.SchoolId==SchoolId, includeProperties: "School , Session");
        }
        public static bool HasQuotaFinished(int schoolId)
        {
            var quota = unitofwork.Quota.GetQueryable(filter: x => x.SchoolId == schoolId).FirstOrDefault();
            if (quota != null)
            {
                var used = quota.QuotaUsed ?? 0;
                if(quota.QuotaAssigned == used )
                {
                    return true;
                }
                return false;
            }
            return false;
        }

        public static bool HasStudentBeenapproved(int SessionId, int StudentId)
        {

            var studentData = unitofwork.studentData.GetQueryable(filter: x =>  x.SessionId==SessionId && x.StudentId==StudentId).FirstOrDefault();
            if (studentData != null && studentData.DOEApproval !=false)
            {
               
                return true;
            }
            return false;
        }

      

    }
}