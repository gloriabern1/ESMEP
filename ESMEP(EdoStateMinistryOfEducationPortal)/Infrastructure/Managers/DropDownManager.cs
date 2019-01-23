using ESMEP_EdoStateMinistryOfEducationPortal_.Models;
using ESMEP_EdoStateMinistryOfEducationPortal_.ViewModels;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ESMEP_EdoStateMinistryOfEducationPortal_.Infrastructure.Managers
{
    public class DropDownManager
    {
        UnitOfWork unitOfWork = new UnitOfWork();
        protected static Hashtable handlerPages = new Hashtable();

        public void GetLGA(DropDownList ddl, string stateId)
        {
            string lga = "";
            string lgaId = "";
            ddl.Items.Clear();
            ddl.Items.Add("Select Local Government");
            if (stateId == null || stateId == "")
            {
                var dtLga = unitOfWork.lga.Get();
                foreach (var item in dtLga)
                {
                    lgaId = item.ID.ToString();
                    lga = item.LocalGovernment1.ToString();

                    ddl.Items.Add(new ListItem(lga, lgaId));
                }
            }
            else
            {
                var dtLga = unitOfWork.lga.Get(x => x.StateId.TrimEnd() == stateId.Trim());
                foreach (var item in dtLga)
                {
                    lgaId = item.ID.ToString();
                    lga = item.LocalGovernment1.ToString();

                    ddl.Items.Add(new ListItem(lga, lgaId));
                }
            }

        }

        public void GetState(DropDownList ddl)
        {
            string state = "";
            string stateId = "";
            ddl.Items.Clear();
            ddl.Items.Add("Select State of  Origin");
            
            var dtLga = unitOfWork.state.Get();
            foreach (var item in dtLga)
            {
                stateId = item.Id.ToString();
                state = item.STATE_NAME.ToString();

                ddl.Items.Add(new ListItem(state, stateId));
            }           

        }

        public void GetRelationship(DropDownList ddl)
        {
            string state = "";
            string stateId = "";
            ddl.Items.Clear();
            ddl.Items.Add("Select Relationship");

            var dtRelation = unitOfWork.Relationship.Get();
            foreach (var item in dtRelation)
            {
                stateId = item.RELATIONSHIP_ID.ToString();
                state = item.RELATIONSHIP_NAME.ToString();

                ddl.Items.Add(new ListItem(state, stateId));
            }

        }

        public void GetGender(DropDownList ddl)
        {
            string state = "";
            string stateId = "";
            ddl.Items.Clear();
            ddl.Items.Add("Select Sex");

            var dtRelation = unitOfWork.sex.Get(x => x.ACTIVATED == true);
            foreach (var item in dtRelation)
            {
                stateId = item.GENDER_ID.ToString();
                state = item.GENDER_NAME.ToString();

                ddl.Items.Add(new ListItem(state, stateId));
            }

        }
        public void GetExam(DropDownList ddl)
        {
            string state = "";
            string stateId = "";
            ddl.Items.Clear();
            ddl.Items.Add("Select Examination");

            var dtRelation = unitOfWork.Exam.Get(x => x.Activated == true);
            foreach (var item in dtRelation)
            {
                stateId = item.ExamId.ToString();
                state = item.Name.ToString();

                ddl.Items.Add(new ListItem(state, stateId));
            }

        }

        public void GetCategory(DropDownList ddl)
        {
            string state = "";
            string stateId = "";
            ddl.Items.Clear();
            ddl.Items.Add("Select School Category");

            var dtLga = unitOfWork.Category.Get();
            foreach (var item in dtLga)
            {
                stateId = item.ID.ToString();
                state = item.Name.ToString().ToUpper();

                ddl.Items.Add(new ListItem(state, stateId));
            }

        }
        public void GetTitle(DropDownList ddl)
        {
            string state = "";
            string stateId = "";
            ddl.Items.Clear();
            ddl.Items.Add("Select Principal's Title");

            var dtLga = unitOfWork.Title.Get();
            foreach (var item in dtLga)
            {
                stateId = item.TitleId.ToString();
                state = item.Name.ToString().ToUpper();

                ddl.Items.Add(new ListItem(state, stateId));
            }

        }

        public int GetSchoolId(string UserId)
        {
            var school = unitOfWork.School.Get(x => x.UserId == UserId);
            if(school.Count() > 0)
            {
                var schoolId = school.FirstOrDefault().Id;
                return schoolId;
            }
            return 1;
        }

        public void ShowPopUp(string Message)
        {
            if (!(handlerPages.Contains(HttpContext.Current.Handler)))
            {
                Page currentPage = (Page)HttpContext.Current.Handler;
                if (!((currentPage == null)))
                {
                    Queue messageQueue = new Queue();
                    messageQueue.Enqueue(Message);
                    handlerPages.Add(HttpContext.Current.Handler, messageQueue);
                    currentPage.Unload += new EventHandler(CurrentPageUnload);
                }
            }
            else
            {
                Queue queue = ((Queue)(handlerPages[HttpContext.Current.Handler]));
                queue.Enqueue(Message);
            }

        }
        private static void CurrentPageUnload(object sender, EventArgs e)
        {

            Queue queue = ((Queue)(handlerPages[HttpContext.Current.Handler]));

            if (queue != null)
            {
                StringBuilder builder = new StringBuilder();
                int iMsgCount = queue.Count;
                builder.Append("<script language='javascript'>");
                string sMsg;
                while ((iMsgCount > 0))
                {
                    iMsgCount = iMsgCount - 1;
                    sMsg = System.Convert.ToString(queue.Dequeue());
                    sMsg = sMsg.Replace("\"", "'");
                    builder.Append("alert( \"" + sMsg + "\" );");
                }
                builder.Append("</script>");
                handlerPages.Remove(HttpContext.Current.Handler);
                HttpContext.Current.Response.Write(builder.ToString());
            }
        }

        public IEnumerable<School> GetAllSchools()
        {
            var allSchools = unitOfWork.School.Get();
            return allSchools;
        }

        public IEnumerable<Student> GetAllStudents(string id)
        {
            if(id != null)
            {
                var allSchools = unitOfWork.studentData.Get(x => x.SchoolId.ToString() == id, includeProperties: "School");
                return allSchools;
            }
            else
            {
                var allSchools = unitOfWork.studentData.Get(includeProperties: "School");
                return allSchools;
            }

        }

        public IEnumerable<Subject> GetAllSubject()
        {
            var allSubject = unitOfWork.Subject.Get(x => x.Activated == true);
            return allSubject;
        }

        public IEnumerable<StudentViewModel> GetStudentView()
        {
            IList<StudentViewModel> studentViewModel = null;
            var student = GetAllStudents(null);
            //IEnumerable<StudentViewModel> studentViewModel = null;
            StudentViewModel studentView = new StudentViewModel();
            foreach (var item in student)
            {
                studentView.FullName = item.FirstName + " " + item.LastName;
                studentView.schoolName = item.School.Name;
                studentView.DateOfBirth = item.DateOfBirth;
                studentView.Address = item.Address;
                studentView.Sex = item.Sex;
                studentView.StudentId = item.StudentId;
                studentView.SchoolId = item.SchoolId;
            }
            studentViewModel.Add(studentView);
            return studentViewModel;
        }

        public IEnumerable<Examination> GetExaminations(string catId)
        {
            if(catId == null)
            {
                var Exams = unitOfWork.Exam.Get();
                return Exams;
            }
            else
            {
                var Exams = unitOfWork.Exam.Get(e => e.CategoryId.ToString() == catId);
                return Exams;
            }
        }

        public IEnumerable<ExamDetailViewModel> GetRegisteredStudents()
        {
            IList<ExamDetailViewModel> examDetailModel = new List<ExamDetailViewModel>();
            var examDetail = unitOfWork.ExamRegistered.Get(includeProperties:"School, Examination, Student,Subject");
            if(examDetail != null)
            {
                var detail = new ExamDetailViewModel();
                foreach (var item in examDetail)
                {
                    if(examDetailModel.Count == 0)
                    {
                        detail.ExamId = item.ExamId;
                        detail.ExamCode = item.Examination.ExamCode;
                        detail.Fee = item.Examination.Fee;
                        detail.SchoolId = int.Parse(item.SchoolId.ToString());
                        detail.SchoolName = item.School.Name;
                        detail.StudentID = int.Parse(item.StudentId.ToString());
                        detail.StudentName = item.Student.FirstName + " " + item.Student.MiddleName + " " + item.Student.LastName;
                        examDetailModel.Add(detail);
                    }
                    else if (examDetailModel.Any(x => x.StudentID == item.StudentId && x.ExamId == item.ExamId))
                    {
                        detail.ExamId = item.ExamId;
                        detail.ExamCode = item.Examination.ExamCode;
                        detail.Fee = item.Examination.Fee;
                        detail.SchoolId = int.Parse(item.SchoolId.ToString());
                        detail.SchoolName = item.School.Name;
                        detail.StudentID = int.Parse(item.StudentId.ToString());
                        detail.StudentName = item.Student.FirstName + " " + item.Student.MiddleName + " " + item.Student.LastName;
                        examDetailModel.Add(detail);
                    }

                }
            }
            return examDetailModel;
        }
        public School GetSchool(string Id)
        {
            var school = unitOfWork.School.Get(x => x.Id.ToString() == Id).FirstOrDefault();
            return school;
        }  
        public string GetLGAIdByName(string Name)
        {
            string lga = unitOfWork.lga.Get(l => l.LocalGovernment1 == Name).FirstOrDefault().ID.ToString();
            return lga;
        }   
        public School GetSchoolByUserId(string userId)
        {
            var school = unitOfWork.School.GetQueryable(s => s.UserId == userId).FirstOrDefault();
            return school;
        }
        public IEnumerable<ExaminationRegistered> GetRegistrations(string Id)
        {
            var allregistration = unitOfWork.ExamRegistered.GetQueryable(e => e.SchoolId.ToString() == Id);
            return allregistration;
        }
        public IEnumerable<ExaminationRegistered> GetRegistrationsById(string Id)
        {
            var allregistration = unitOfWork.ExamRegistered.GetQueryable(e => e.RegistrationId.ToString() == Id);
            return allregistration;
        }
        public bool IsStudentRegistered(int studentID)
        {
            var data = unitOfWork.ExamRegistered.Get(x => x.StudentId == studentID).FirstOrDefault();
            if (data != null)
                return true;
            else
                return false;
        }

        public bool IsSchoolRegistered(int schoolId)
        {
            var data = unitOfWork.ExamRegistered.Get(x => x.SchoolId == schoolId).FirstOrDefault();
            if (data != null)
                return true;
            else
                return false;
        }
    } 

}