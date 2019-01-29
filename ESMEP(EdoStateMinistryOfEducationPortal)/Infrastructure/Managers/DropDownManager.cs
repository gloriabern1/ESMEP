using ESMEP_EdoStateMinistryOfEducationPortal_.Models;
using ESMEP_EdoStateMinistryOfEducationPortal_.ViewModels;
using OfficeOpenXml;
using OfficeOpenXml.DataValidation;
using OfficeOpenXml.Table;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.IO;
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

        public void PopulateSubject(DropDownList ddl)
        {
            string subject = "";
            string subjectCode = "";
            ddl.Items.Clear();
            ddl.Items.Add("Select Subject");

            var allSubject = unitOfWork.Subject.Get();
            foreach (var item in allSubject)
            {
                subjectCode = item.Code.ToString();
                subject = item.Name.ToString();

                ddl.Items.Add(new ListItem(subject, subjectCode));
            }
        }

        public void PopulateExam(DropDownList ddl)
        {
            string Exams = "";
            string examsCode = "";
            ddl.Items.Clear();
            ddl.Items.Add("Select Exam");

            var allExam = unitOfWork.Exam.Get();
            foreach (var item in allExam)
            {
                examsCode = item.ExamId.ToString();
                Exams = item.Name.ToString();

                ddl.Items.Add(new ListItem(Exams, examsCode));
            }
        }

        public void PopulateExam(DropDownList ddl, int category)
        {
            string exam = "";
            string examCode = "";
            ddl.Items.Clear();
            ddl.Items.Add("Select Exam");

            var allExam = unitOfWork.Exam.Get(x => x.CategoryId == category);
            foreach (var item in allExam)
            {
                exam = item.Name.ToString();
                examCode = item.ExamId.ToString();

                ddl.Items.Add(new ListItem(exam, examCode));
            }
        }

        public void PopulateYear(DropDownList ddl)
        {
            string session = "";
            string sessionId = "";
            ddl.Items.Clear();
            ddl.Items.Add("Select Year");

            var allSession = unitOfWork.session.Get();
            foreach (var item in allSession)
            {
                sessionId = item.ID.ToString();
                session = item.Name.ToString();

                ddl.Items.Add(new ListItem(session, sessionId));
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

        public IEnumerable<School> GetAllSchools(int lga)
        {
            var schools = unitOfWork.School.GetQueryable(x => x.LocalGovernmentID == lga);
            return schools;
        }

        public IEnumerable<School> GetAllSchools(int lga, int category)
        {
            var schools = unitOfWork.School.Get(x => x.LocalGovernmentID == lga && x.CategoryId == category).OrderBy(x => x.Name);
            return schools;
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

        public IEnumerable<ExaminationRegistered> GetRegistrations(int schoolId, int session, int exam)
        {
            List<ExaminationRegistered> DinstincStudent = new List<ExaminationRegistered>();
            var examReg = unitOfWork.ExamRegistered.GetQueryable(filter: x => x.SchoolId == schoolId && x.SessionId == session && x.ExamId == exam);
            foreach (var item in examReg)
            {
                if(DinstincStudent.Count() == 0)
                {
                    DinstincStudent.Add(item);
                }
                else if (DinstincStudent.All(x => x.StudentId != item.StudentId ))
                {
                    DinstincStudent.Add(item);
                }
            }
            return DinstincStudent;
        }

        public IEnumerable<ExaminationRegistered> GetRegistrations(int schoolId, int session, int exam, string subject)
        {
            var examReg = unitOfWork.ExamRegistered.GetQueryable(filter: x => x.SchoolId == schoolId && x.SessionId == session && x.ExamId == exam && x.SubjectCode == subject);
            return examReg;
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
        public void GenerateExcel(DataTable dt, string filename, string type , HttpResponse r)
        {

            if (dt != null && dt.Rows.Count > 0)
            {
                using (ExcelPackage pkg = new ExcelPackage())
                {
                    ExcelWorksheet ws = pkg.Workbook.Worksheets.Add("Students");
                    int rowCount = dt.Rows.Count;


                    //Load from DataTable
                    ws.Cells["A1"].LoadFromDataTable(dt, true, TableStyles.Light14);

                    //Format the validation cell ranges for CA and Exam

                    //string AssignValRng = String.Format("G2:G{0}", rowCount + 1);
                    //string caValRng = String.Format("H2:H{0}", rowCount + 1);
                    //string examValRng = String.Format("I2:I{0}", rowCount + 1);
                    //string remarkRng = String.Format("O2:O{0}", rowCount + 1);
                    //string allRng = String.Format("A1:O{0}", rowCount + 1);




                    //Autofit columns
                    ws.Cells["A:XFD"].AutoFitColumns(5);
                    ws.Cells["A:XFD"].Style.Font.Bold = true;



                    ws.Column(1).Hidden = true;
                   

                    if (type == "Attendance")
                    {
                        ws.Column(9).Hidden = true;
                        ws.Column(10).Hidden = true;
                        ws.Column(11).Hidden = true;
                        ws.Column(12).Hidden = true;
                        ws.Column(13).Hidden = true;
                        ws.Column(14).Hidden = true;

                        string attendance = String.Format("F2:F{0}", rowCount + 1);
                        //string caValRng = String.Format("H2:H{0}", rowCount + 1);
                        string examValRng = String.Format("G2:G{0}", rowCount + 1);
                        string remarkRng = String.Format("H2:H{0}", rowCount + 1);
                        //string allRng = String.Format("A1:O{0}", rowCount + 1);

                        //Set the Exam validation object
                        var examVal = ws.Cells[examValRng].DataValidation.AddIntegerDataValidation();
                        examVal.ErrorStyle = ExcelDataValidationWarningStyle.stop;
                        examVal.PromptTitle = "Enter a integer value here";
                        examVal.Prompt = "Value must be less 100";
                        examVal.ShowInputMessage = true;
                        examVal.ErrorTitle = "An invalid value was entered";
                        examVal.Error = "Value must be less than 100";
                        examVal.ShowErrorMessage = true;
                        examVal.Operator = ExcelDataValidationOperator.between;
                        examVal.Formula.Value = 0;
                        examVal.Formula2.Value = 100;

                        //set validation for attendance
                        var attendanceVal = ws.Cells[attendance].DataValidation.AddIntegerDataValidation();
                        attendanceVal.ErrorStyle = ExcelDataValidationWarningStyle.stop;
                        attendanceVal.PromptTitle = "Enter 1 for Present OR 0 for Absent";
                        attendanceVal.Prompt = "Enter 1 OR 0";
                        examVal.ShowInputMessage = true;
                        attendanceVal.ErrorTitle = "An invalid value was entered";
                        attendanceVal.Error = "Enter 1 OR 0";
                        attendanceVal.ShowErrorMessage = true;
                        attendanceVal.Operator = ExcelDataValidationOperator.between;
                        attendanceVal.Formula.Value = 0;
                        attendanceVal.Formula2.Value = 1;


                        ws.Cells[attendance].Style.Locked = false;
                       // ws.Cells[caValRng].Style.Locked = false;
                        ws.Cells[examValRng].Style.Locked = false;
                        ws.Cells[remarkRng].Style.Locked = false;
                    }


                    if(type == "Sec_Entry")
                    {
                        ws.Column(15).Hidden = true;
                        ws.Column(16).Hidden = true;
                        ws.Column(17).Hidden = true;

                        string subject1 = String.Format("F2:F{0}", rowCount + 1);
                        string subject2 = String.Format("G2:G{0}", rowCount + 1);
                        string subject3 = String.Format("H2:H{0}", rowCount + 1);
                        string subject4 = String.Format("I2:I{0}", rowCount + 1);
                        string subject5 = String.Format("J2:J{0}", rowCount + 1);
                        string subject6 = String.Format("K2:K{0}", rowCount + 1);
                        string subject7 = String.Format("L2:L{0}", rowCount + 1);
                        string subject8 = String.Format("M2:M{0}", rowCount + 1);
                        string subject9 = String.Format("N2:N{0}", rowCount + 1);
                        string subject10 = String.Format("O2:O{0}", rowCount + 1);


                        //string remarkRng = String.Format("H2:H{0}", rowCount + 1);
                        //string allRng = String.Format("A1:O{0}", rowCount + 1);

                        //Set the Exam validation object
                        var examVal = ws.Cells[subject1].DataValidation.AddIntegerDataValidation();
                        examVal.ErrorStyle = ExcelDataValidationWarningStyle.stop;
                        examVal.PromptTitle = "Enter a integer value here";
                        examVal.Prompt = "Value must be less 100";
                        examVal.ShowInputMessage = true;
                        examVal.ErrorTitle = "An invalid value was entered";
                        examVal.Error = "Value must be less than 100";
                        examVal.ShowErrorMessage = true;
                        examVal.Operator = ExcelDataValidationOperator.between;
                        examVal.Formula.Value = 0;
                        examVal.Formula2.Value = 100;

                        var subj2 = ws.Cells[subject2].DataValidation.AddIntegerDataValidation();
                        subj2.ErrorStyle = ExcelDataValidationWarningStyle.stop;
                        subj2.PromptTitle = "Enter a integer value here";
                        subj2.Prompt = "Value must be less 100";
                        subj2.ShowInputMessage = true;
                        subj2.ErrorTitle = "An invalid value was entered";
                        subj2.Error = "Value must be less than 100";
                        subj2.ShowErrorMessage = true;
                        subj2.Operator = ExcelDataValidationOperator.between;
                        subj2.Formula.Value = 0;
                        subj2.Formula2.Value = 100;

                        var subj3 = ws.Cells[subject3].DataValidation.AddIntegerDataValidation();
                        subj3.ErrorStyle = ExcelDataValidationWarningStyle.stop;
                        subj3.PromptTitle = "Enter a integer value here";
                        subj3.Prompt = "Value must be less 100";
                        subj3.ShowInputMessage = true;
                        subj3.ErrorTitle = "An invalid value was entered";
                        subj3.Error = "Value must be less than 100";
                        subj3.ShowErrorMessage = true;
                        subj3.Operator = ExcelDataValidationOperator.between;
                        subj3.Formula.Value = 0;
                        subj3.Formula2.Value = 100;

                        var subj4 = ws.Cells[subject4].DataValidation.AddIntegerDataValidation();
                        subj4.ErrorStyle = ExcelDataValidationWarningStyle.stop;
                        subj4.PromptTitle = "Enter a integer value here";
                        subj4.Prompt = "Value must be less 100";
                        subj4.ShowInputMessage = true;
                        subj4.ErrorTitle = "An invalid value was entered";
                        subj4.Error = "Value must be less than 100";
                        subj4.ShowErrorMessage = true;
                        subj4.Operator = ExcelDataValidationOperator.between;
                        subj4.Formula.Value = 0;
                        subj4.Formula2.Value = 100;

                        var subj5 = ws.Cells[subject5].DataValidation.AddIntegerDataValidation();
                        subj5.ErrorStyle = ExcelDataValidationWarningStyle.stop;
                        subj5.PromptTitle = "Enter a integer value here";
                        subj5.Prompt = "Value must be less 100";
                        subj5.ShowInputMessage = true;
                        subj5.ErrorTitle = "An invalid value was entered";
                        subj5.Error = "Value must be less than 100";
                        subj5.ShowErrorMessage = true;
                        subj5.Operator = ExcelDataValidationOperator.between;
                        subj5.Formula.Value = 0;
                        subj5.Formula2.Value = 100;

                        var subj6 = ws.Cells[subject6].DataValidation.AddIntegerDataValidation();
                        subj6.ErrorStyle = ExcelDataValidationWarningStyle.stop;
                        subj6.PromptTitle = "Enter a integer value here";
                        subj6.Prompt = "Value must be less 100";
                        subj6.ShowInputMessage = true;
                        subj6.ErrorTitle = "An invalid value was entered";
                        subj6.Error = "Value must be less than 100";
                        subj6.ShowErrorMessage = true;
                        subj6.Operator = ExcelDataValidationOperator.between;
                        subj6.Formula.Value = 0;
                        subj6.Formula2.Value = 100;

                        var subj7 = ws.Cells[subject7].DataValidation.AddIntegerDataValidation();
                        subj7.ErrorStyle = ExcelDataValidationWarningStyle.stop;
                        subj7.PromptTitle = "Enter a integer value here";
                        subj7.Prompt = "Value must be less 100";
                        subj7.ShowInputMessage = true;
                        subj7.ErrorTitle = "An invalid value was entered";
                        subj7.Error = "Value must be less than 100";
                        subj7.ShowErrorMessage = true;
                        subj7.Operator = ExcelDataValidationOperator.between;
                        subj7.Formula.Value = 0;
                        subj7.Formula2.Value = 100;

                        var subj8 = ws.Cells[subject8].DataValidation.AddIntegerDataValidation();
                        subj8.ErrorStyle = ExcelDataValidationWarningStyle.stop;
                        subj8.PromptTitle = "Enter a integer value here";
                        subj8.Prompt = "Value must be less 100";
                        subj8.ShowInputMessage = true;
                        subj8.ErrorTitle = "An invalid value was entered";
                        subj8.Error = "Value must be less than 100";
                        subj8.ShowErrorMessage = true;
                        subj8.Operator = ExcelDataValidationOperator.between;
                        subj8.Formula.Value = 0;
                        subj8.Formula2.Value = 100;

                        var subj9 = ws.Cells[subject9].DataValidation.AddIntegerDataValidation();
                        subj9.ErrorStyle = ExcelDataValidationWarningStyle.stop;
                        subj9.PromptTitle = "Enter a integer value here";
                        subj9.Prompt = "Value must be less 100";
                        subj9.ShowInputMessage = true;
                        subj9.ErrorTitle = "An invalid value was entered";
                        subj9.Error = "Value must be less than 100";
                        subj9.ShowErrorMessage = true;
                        subj9.Operator = ExcelDataValidationOperator.between;
                        subj9.Formula.Value = 0;
                        subj9.Formula2.Value = 100;

                        var subj10 = ws.Cells[subject10].DataValidation.AddIntegerDataValidation();
                        subj10.ErrorStyle = ExcelDataValidationWarningStyle.stop;
                        subj10.PromptTitle = "Enter a integer value here";
                        subj10.Prompt = "Value must be less 100";
                        subj10.ShowInputMessage = true;
                        subj10.ErrorTitle = "An invalid value was entered";
                        subj10.Error = "Value must be less than 100";
                        subj10.ShowErrorMessage = true;
                        subj10.Operator = ExcelDataValidationOperator.between;
                        subj10.Formula.Value = 0;
                        subj10.Formula2.Value = 100;


                        ws.Cells[subject1].Style.Locked = false;
                        ws.Cells[subject2].Style.Locked = false;
                        ws.Cells[subject3].Style.Locked = false;
                        ws.Cells[subject4].Style.Locked = false;
                        ws.Cells[subject5].Style.Locked = false;
                        ws.Cells[subject6].Style.Locked = false;
                    }

                    if(type == "Pri_Entry")
                    {
                        ws.Column(15).Hidden = true;
                        ws.Column(16).Hidden = true;
                        ws.Column(17).Hidden = true;

                        string subject1 = String.Format("F2:F{0}", rowCount + 1);
                        string subject2 = String.Format("G2:G{0}", rowCount + 1);
                        string subject3 = String.Format("H2:H{0}", rowCount + 1);
                        string subject4 = String.Format("I2:I{0}", rowCount + 1);
                        string subject5 = String.Format("J2:J{0}", rowCount + 1);
                        string subject6 = String.Format("K2:K{0}", rowCount + 1);

                       
                        //string remarkRng = String.Format("H2:H{0}", rowCount + 1);
                        //string allRng = String.Format("A1:O{0}", rowCount + 1);

                        //Set the Exam validation object
                        var examVal = ws.Cells[subject1].DataValidation.AddIntegerDataValidation();
                        examVal.ErrorStyle = ExcelDataValidationWarningStyle.stop;
                        examVal.PromptTitle = "Enter a integer value here";
                        examVal.Prompt = "Value must be less 100";
                        examVal.ShowInputMessage = true;
                        examVal.ErrorTitle = "An invalid value was entered";
                        examVal.Error = "Value must be less than 100";
                        examVal.ShowErrorMessage = true;
                        examVal.Operator = ExcelDataValidationOperator.between;
                        examVal.Formula.Value = 0;
                        examVal.Formula2.Value = 100;

                        var subj2 = ws.Cells[subject2].DataValidation.AddIntegerDataValidation();
                        subj2.ErrorStyle = ExcelDataValidationWarningStyle.stop;
                        subj2.PromptTitle = "Enter a integer value here";
                        subj2.Prompt = "Value must be less 100";
                        subj2.ShowInputMessage = true;
                        subj2.ErrorTitle = "An invalid value was entered";
                        subj2.Error = "Value must be less than 100";
                        subj2.ShowErrorMessage = true;
                        subj2.Operator = ExcelDataValidationOperator.between;
                        subj2.Formula.Value = 0;
                        subj2.Formula2.Value = 100;

                        var subj3 = ws.Cells[subject3].DataValidation.AddIntegerDataValidation();
                        subj3.ErrorStyle = ExcelDataValidationWarningStyle.stop;
                        subj3.PromptTitle = "Enter a integer value here";
                        subj3.Prompt = "Value must be less 100";
                        subj3.ShowInputMessage = true;
                        subj3.ErrorTitle = "An invalid value was entered";
                        subj3.Error = "Value must be less than 100";
                        subj3.ShowErrorMessage = true;
                        subj3.Operator = ExcelDataValidationOperator.between;
                        subj3.Formula.Value = 0;
                        subj3.Formula2.Value = 100;

                        var subj4 = ws.Cells[subject4].DataValidation.AddIntegerDataValidation();
                        subj4.ErrorStyle = ExcelDataValidationWarningStyle.stop;
                        subj4.PromptTitle = "Enter a integer value here";
                        subj4.Prompt = "Value must be less 100";
                        subj4.ShowInputMessage = true;
                        subj4.ErrorTitle = "An invalid value was entered";
                        subj4.Error = "Value must be less than 100";
                        subj4.ShowErrorMessage = true;
                        subj4.Operator = ExcelDataValidationOperator.between;
                        subj4.Formula.Value = 0;
                        subj4.Formula2.Value = 100;

                        var subj5 = ws.Cells[subject5].DataValidation.AddIntegerDataValidation();
                        subj5.ErrorStyle = ExcelDataValidationWarningStyle.stop;
                        subj5.PromptTitle = "Enter a integer value here";
                        subj5.Prompt = "Value must be less 100";
                        subj5.ShowInputMessage = true;
                        subj5.ErrorTitle = "An invalid value was entered";
                        subj5.Error = "Value must be less than 100";
                        subj5.ShowErrorMessage = true;
                        subj5.Operator = ExcelDataValidationOperator.between;
                        subj5.Formula.Value = 0;
                        subj5.Formula2.Value = 100;

                        var subj6 = ws.Cells[subject6].DataValidation.AddIntegerDataValidation();
                        subj6.ErrorStyle = ExcelDataValidationWarningStyle.stop;
                        subj6.PromptTitle = "Enter a integer value here";
                        subj6.Prompt = "Value must be less 100";
                        subj6.ShowInputMessage = true;
                        subj6.ErrorTitle = "An invalid value was entered";
                        subj6.Error = "Value must be less than 100";
                        subj6.ShowErrorMessage = true;
                        subj6.Operator = ExcelDataValidationOperator.between;
                        subj6.Formula.Value = 0;
                        subj6.Formula2.Value = 100;

                        ws.Cells[subject1].Style.Locked = false;
                        ws.Cells[subject2].Style.Locked = false;
                        ws.Cells[subject3].Style.Locked = false;
                        ws.Cells[subject4].Style.Locked = false;
                        ws.Cells[subject5].Style.Locked = false;
                        ws.Cells[subject6].Style.Locked = false;
                    }


                    //string hiddenRng = String.Format("J1:N{0}", rowCount + 1);
                    //if (type == "Attendance")
                    //{

                    //    //Add a formula for the value-column
                    //    string totalRng = String.Format("J2:J{0}", dt.Rows.Count + 1);
                    //    ws.Cells[totalRng].Formula = "G2+H2+I2";
                    //    ws.Cells[totalRng].Style.Hidden = true;
                    //    hiddenRng = String.Format("K1:N{0}", rowCount + 1);
                    //}




                    pkg.Workbook.Properties.Title = "Class List for Exam";
                    pkg.Workbook.Properties.Author = "Ministry of Education Edo State";
                    pkg.Workbook.Properties.Comments = "Donwloaded Class list";

                    // set some extended property values
                    pkg.Workbook.Properties.Company = "Tenece";


                    ws.Protection.SetPassword("sputnik3");
                    ws.Protection.AllowInsertRows = true;




                    //ws.Cells[AssignValRng].Style.Locked = false;
                    //ws.Cells[caValRng].Style.Locked = false;
                    //ws.Cells[examValRng].Style.Locked = false;
                    //ws.Cells[remarkRng].Style.Locked = false;

                    //Hide cell from being accessed
               // ws.Cells[hiddenRng].Style.Locked = true;
                    //ws.Column(11).Style.Locked = false;
                    //ws.Column(11).Style.Hidden = false;

                    //Send to Response object to be downloaded
                    r.Clear();
                    r.Buffer = true;
                    r.Charset = "";
                    r.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                    r.AddHeader("content-disposition", "attachment;filename=" + filename + ".xlsx");
                    using (MemoryStream MyMemoryStream = new MemoryStream())
                    {
                        pkg.SaveAs(MyMemoryStream);
                        MyMemoryStream.WriteTo(r.OutputStream);
                        r.Flush();
                        r.End();
                    }
                }
            }
        }

        public IEnumerable<Subject> GetRegisteredSubject(int examId, int studentId)
        {
            return unitOfWork.ExamRegistered.Get(filter: x => x.ExamId == examId && x.StudentId == studentId).Select(x => x.Subject);
        }
    } 

}