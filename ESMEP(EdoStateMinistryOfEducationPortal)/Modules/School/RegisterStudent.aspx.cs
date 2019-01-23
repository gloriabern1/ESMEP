using ESMEP_EdoStateMinistryOfEducationPortal_.Infrastructure;
using ESMEP_EdoStateMinistryOfEducationPortal_.Infrastructure.Managers;
using ESMEP_EdoStateMinistryOfEducationPortal_.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ESMEP_EdoStateMinistryOfEducationPortal_.Modules.School
{
    public partial class RegisterStudent : System.Web.UI.Page
    {
        UnitOfWork unitOfWork = new UnitOfWork();
        DropDownManager dropDownManager = new DropDownManager();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (Request.QueryString["id"] != null && Request.QueryString["idx"] != null)
                {
                    string studentid = Request.QueryString["id"];
                    string schoolid = Request.QueryString["idx"];
                    lblSchoolId.Text = schoolid;
                    lblStudent.Text = studentid;
                }
                mutilView1.ActiveViewIndex = 0;
                PopulateExam();
            }
        }


        protected void btnNext_Click(object sender, EventArgs e)
        {
            bool selected = false;
            foreach (GridViewRow gvRow in gvExam.Rows)
            {
                CheckBox chkExam = (CheckBox)gvRow.FindControl("chkExam");
                Label lblExamId = (Label)gvRow.FindControl("lblExamId");
                if (chkExam.Checked == true)
                {
                    selected = true;
                }
            }
            if(selected == false)
            {
                dropDownManager.ShowPopUp("Please Select atleast one Exam to register ");
            }
            else
            {
                mutilView1.ActiveViewIndex = 1;
                PopulateStudent();
            }
         
        }

        public void PopulateExam()
        {
            var userId = HttpContext.Current.User.Identity.GetUserId();            
            var school = dropDownManager.GetSchoolByUserId(userId);
            if (school != null)
            {
                lblSchoolId.Text = school.Id.ToString();
                lblSchoolType.Text = school.SchoolTypeId.ToString();
                lblSchoolCat.Text = school.CategoryId.ToString();
                string catId = school.CategoryId.ToString();

                var dt = new DataTable();
                dt.Columns.Add("SN");
                dt.Columns.Add("ID");
                dt.Columns.Add("EXAM");
                dt.Columns.Add("EXAMCODE");
                dt.Columns.Add("FEE");

                var Exams = dropDownManager.GetExaminations(catId);
                int sn = 0;            
                foreach (var item in Exams)
                {                
                    string examId = item.ExamId.ToString();
                    string examName = item.Name.ToString();
                    string examCode = item.ExamCode.ToString();
                    string examFee = item.Fee.ToString();
                    string examStatus = item.Activated.ToString();
                    sn++;
                    dt.Rows.Add(sn, examId,examName, examCode, examFee);
                }
                gvExam.DataSource = dt;
                gvExam.DataBind();
            }
        }

        public void PopulateStudent()
        {
            var dt = new DataTable();
            dt.Columns.Add("SN");
            dt.Columns.Add("ID");
            dt.Columns.Add("Name");
            dt.Columns.Add("Sex");

            var Students = dropDownManager.GetAllStudents(lblSchoolId.Text);
            int sn = 0;
            foreach (var item in Students)
            {
                string Name = item.FirstName + " " + item.LastName + " " + item.MiddleName.ToString();
                string sex = item.Sex.ToString();
                string id = item.StudentId.ToString();
               // string subjectStatus = item..ToString();
                sn++;
                dt.Rows.Add(sn, id, Name, sex);
            }
            gvStudents.DataSource = dt;
            gvStudents.DataBind();
        }


        protected void btnSubMit_Click(object sender, EventArgs e)
        {
            string subjectCode = string.Empty;
            string selectedExam = string.Empty;
            string selectSubject;
            string schoolId = lblSchoolId.Text;
            int subjects = 0;
            int noStudent = 0;
           // string studentId = lblStudent.Text;
            IList<ExaminationRegistered> Exams = new List<ExaminationRegistered>();
            ExaminationRegistered Exam = null;
            foreach (GridViewRow gvRow in gvExam.Rows)
            {
                CheckBox chkExam = (CheckBox)gvRow.FindControl("chkExam");
                Label lblExamId = (Label)gvRow.FindControl("lblExamId");
                Label lblExamCode = (Label)gvRow.FindControl("lblExamCode");
                lblExamCode1.Text = lblExamCode.Text;
                if (chkExam.Checked == true)
                {
                    selectedExam = lblExamId.Text;
                    foreach (GridViewRow gvstudent in gvStudents.Rows)
                    {
                        CheckBox chkStudent = (CheckBox)gvstudent.FindControl("chkStudent");
                        Label _lblStudentId = (Label)gvstudent.FindControl("lblStudentId");
                        if(chkStudent.Checked == true)
                        {
                            noStudent++;
                            foreach (GridViewRow gvSub in gvSubject.Rows)
                            {
                                lblStudentR.Text = _lblStudentId.Text;
                                CheckBox chkSubject = (CheckBox)gvSub.FindControl("chkSubject");
                                Label lblSubjectId = (Label)gvSub.FindControl("lblSubjectId");
                                Label lblSubjectCode = (Label)gvSub.FindControl("lblSubjectCode");
                                if (chkSubject.Checked == true)
                                {
                                    subjects++;
                                    Exam = new ExaminationRegistered();
                                    selectSubject = lblSubjectId.Text;
                                    Exam.SchoolId = int.Parse(schoolId);
                                    Exam.StudentId = int.Parse(lblStudentR.Text);
                                    Exam.SubjectId = int.Parse(selectSubject);
                                    Exam.ExamId = int.Parse(selectedExam);
                                    Exam.SchoolTypeId = int.Parse(lblSchoolType.Text);
                                    Exam.CategoryId = int.Parse(lblSchoolCat.Text);
                                    Exam.DateRegistered = DateTime.Now;
                                    Exam.SubjectCode = lblSubjectCode.Text;
                                    Exams.Add(Exam);                              
                                       
                                }

                            }
                            if (subjects >= 8 || subjects == 9)
                            {

                                unitOfWork.ExamRegistered.InsertBulk(Exams);
                                unitOfWork.Save();
                                lblID.Text = Exams.FirstOrDefault().RegistrationId.ToString();
                            }
                            else
                            {
                                dropDownManager.ShowPopUp("Subject selected is below or above required no of subjects :: Minimum of 8 subject and Maximun is 9");
                                mutilView1.ActiveViewIndex = 2;
                            }
                        }
                        noOfStudent.Text = noStudent.ToString();
                    }                   
                }
            }
            dropDownManager.ShowPopUp(noStudent + " Student Registered Successfully");
            mutilView1.ActiveViewIndex = 3;
            LoadRecipt();
        }

        public void PopulateSubject()
        {
            var dt = new DataTable();
            dt.Columns.Add("SN");
            dt.Columns.Add("ID");
            dt.Columns.Add("Subject");
            dt.Columns.Add("SubjectCode");

            var Exams = dropDownManager.GetAllSubject();
            int sn = 0;
            foreach (var item in Exams)
            {
                string subjectId = item.ID.ToString();
                string subject = item.Name.ToString();
                string subjectCode = item.Code.ToString();
                string subjectStatus = item.Activated.ToString();
                sn++;
                dt.Rows.Add(sn, subjectId, subject, subjectCode);
            }
            gvSubject.DataSource = dt;
            gvSubject.DataBind();
        }


        protected void addStudent_Click(object sender, EventArgs e)
        {
            bool selected = false;
            foreach (GridViewRow gvRow in gvStudents.Rows)
            {
                CheckBox chkExam = (CheckBox)gvRow.FindControl("chkStudent");
                //Label lblExamId = (Label)gvRow.FindControl("lblExamId");
                if (chkExam.Checked == true)
                {
                    selected = true;
                }
            }
            if (selected == false)
            {
                dropDownManager.ShowPopUp("Please Select atleast one Student to register ");
            }
            else
            {
                mutilView1.ActiveViewIndex = 2;
                PopulateSubject();
            }
        }

        public  void LoadRecipt()
        {
            var ExamRegistered = dropDownManager.GetRegistrationsById(lblID.Text);
            //DataTable dt = new DataTable();
            //dt.Columns.Add("SN");
            //dt.Columns.Add("Type");
            //dt.Columns.Add("Student");
            //dt.Columns.Add("Date");
            //dt.Columns.Add("Amount");

            foreach (var item in ExamRegistered)
            {

                lblInvoiceNo.Text = "234245453";
                lblDate.Text = item.DateRegistered.ToLongDateString();
                lblSchoolAddress.Text = item.School.Address;
                lblSchoolEmail.Text = item.School.Email;
                lblSchoolLGA.Text = item.School.LocalGovernment.LocalGovernment1;
                lblschoolName.Text = item.School.Name;
                int nostudent = int.Parse(noOfStudent.Text);
                var fee = int.Parse(item.Examination.Fee) * nostudent;
                lblDateFReg.Text = item.DateRegistered.ToLongDateString();
                lblFeeAmount.Text = fee.ToString();
                lblSubTotal.Text = fee.ToString();
                lblFeesType.Text = lblExamCode1.Text;
                lblNoFStudent.Text = nostudent.ToString();
                lblTotal.Text = Convert.ToDecimal(fee).ToString();
                LoadBarcode(item.Examination.ExamCode + "" +item.StudentId + "" +item.SchoolId);
                return;
            }
        }

        protected void LoadBarcode(string datatoencode)
        {

            string barCode = datatoencode;
            System.Web.UI.WebControls.Image imgBarCode = new System.Web.UI.WebControls.Image();
            using (Bitmap bitMap = new Bitmap(barCode.Length * 25, 80))
            {
                using (Graphics graphics = Graphics.FromImage(bitMap))
                {
                    Font oFont = new Font("IDAutomationHC39M", 14);
                    PointF point = new PointF(2f, 2f);
                    SolidBrush blackBrush = new SolidBrush(Color.Black);
                    SolidBrush whiteBrush = new SolidBrush(Color.White);
                    graphics.FillRectangle(whiteBrush, 0, 0, bitMap.Width, bitMap.Height);
                    graphics.DrawString("*" + barCode + "*", oFont, blackBrush, point);
                }
                using (MemoryStream ms = new MemoryStream())
                {
                    bitMap.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                    byte[] byteImage = ms.ToArray();

                    Convert.ToBase64String(byteImage);
                    imgBarCode.ImageUrl = "data:image/png;base64," + Convert.ToBase64String(byteImage);
                }
                plBarCode.Controls.Add(imgBarCode);
            }
        }
    }
}