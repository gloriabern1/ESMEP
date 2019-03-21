using ESMEP_EdoStateMinistryOfEducationPortal_.Infrastructure;
using ESMEP_EdoStateMinistryOfEducationPortal_.Infrastructure.Managers;
using ESMEP_EdoStateMinistryOfEducationPortal_.ViewModels;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ESMEP_EdoStateMinistryOfEducationPortal_.Modules.School
{
    public partial class UploadAttendance : System.Web.UI.Page
    {
        UnitOfWork unitOfWork = new UnitOfWork();
        public SessionObject sessionUser;

        public SessionObject SessionUser
        {
            get { return sessionUser ?? (SessionObject)Session["EdoSessionObject"]; }
            set { value = sessionUser; }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if(SessionUser == null)
                {
                    Response.Redirect("~/Account/Login");
                }
                DropDownManager.PopulateExam(ddlExam, SessionUser.CategoryId);
                DropDownManager.PopulateSubject(ddlSubject);
                DropDownManager.PopulateYear(ddlYear);
            }
        }

        protected void btnUpload_Click(object sender, EventArgs e)
        {
            var fileName = GeneralUtility.GetExcelFile(xlsxSchol);
            FileInfo existingFile = new FileInfo(fileName);

            using (ExcelPackage package = new ExcelPackage(existingFile))
            {
                // get the first worksheet in the workbook

                ExcelWorksheet worksheet = package.Workbook.Worksheets[1];
                var rowCnt = worksheet.Dimension.End.Row;
                if (rowCnt > 1)
                {
                    DataTable dtTable = new DataTable();
                    dtTable.Clear();
                    dtTable.Columns.Add("STUDENTID");
                    dtTable.Columns.Add("SN");
                    dtTable.Columns.Add("FULLNAME");
                    dtTable.Columns.Add("EXAM_NO");
                    dtTable.Columns.Add("PRESENT");
                    dtTable.Columns.Add("MARK");
                    dtTable.Columns.Add("REMARKS");

                    string exam_no = "";
                    string fullname = "";
                    string studentid = "";
                    string attendance = "";
                    string subjectToBeUploaded = ddlSubject.SelectedItem.Text;
                    string sessionToBeUploaded = ddlYear.SelectedValue;
                    string exam = ddlExam.SelectedItem.Text;
                    string SessionId = "";
                    string mark = "";
                    string remarks = "";
                    string schoolId = "";
                    string Exam = "";

                    //lblStatus.Text = "";
                    ErrorMessage.Text = "";
                    //  int A = 0, B = 0, C = 0, D = 0, E = 0, F = 0,
                    int counter = 0;
                    for (int i = 0; i < rowCnt; i++)
                    {
                        if (i == 0) continue;//skipping the header
                        studentid = worksheet.Cells[i + 1, 1].Value.ToString();
                        //2 is serial number

                        exam_no = worksheet.Cells[i + 1, 4].Value.ToString();
                        fullname = worksheet.Cells[i + 1, 3].Value.ToString();
                        try
                        {
                            attendance = worksheet.Cells[i + 1, 6].Value?.ToString() ?? "";
                            mark = worksheet.Cells[i + 1, 7].Value?.ToString() ?? "";
                            remarks = worksheet.Cells[i + 1, 8].Value?.ToString() ?? "";
                            lblSubject.Text = worksheet.Cells[i + 1, 5].Value?.ToString() ?? "";
                            SessionId = worksheet.Cells[i + 1, 11].Value?.ToString() ?? "";
                            schoolId = worksheet.Cells[i + 1, 13].Value?.ToString() ?? "";
                            Exam = worksheet.Cells[i + 1, 10].Value?.ToString() ?? "";

                        }
                        catch (Exception)
                        {
                            mark = null;
                            //do nothing
                        }



                        if (attendance == "")
                        {
                            attendance = null;
                        }
                        else if (attendance == "1")
                        {
                            attendance = "true";
                        }
                        else
                        {
                            attendance = "false";
                        }
                        if (mark != null)
                        {
                            if (mark.Trim() == "")
                            {
                                mark = null;
                            }
                        }

                        string LabScoreDecimal;
                        try
                        {
                            if(attendance == "true")
                            {
                                LabScoreDecimal = "Present";
                            }
                            else
                            {
                                LabScoreDecimal = "Absent";
                            }
                        }
                        catch (Exception)
                        {
                            LabScoreDecimal = null;
                            attendance = null;
                        }

                        if (string.IsNullOrEmpty(studentid) || string.IsNullOrEmpty(exam_no) || string.IsNullOrEmpty(fullname))
                        {
                            continue;
                        }

                        //check to see if the course being uploaded is actually the course in the excel sheet.
                        //we do this by comparing the course mapped in the Course registration id hidden in the 
                        //excel sheet with the one clicked in the gridview.
                        if (subjectToBeUploaded != lblSubject.Text)
                        {
                            ErrorMessage.Text = "You are trying to upload the result of " + subjectToBeUploaded + " instead of " + lblSubject.Text + " result.";
                            return;
                        }
                        if (sessionToBeUploaded != SessionId)
                        {
                            ErrorMessage.Text = "You are trying to upload the result of " + ddlYear.SelectedItem.Text + " instead of " + DropDownManager.GetSession(SessionId) + " result.";
                            return;
                        }
                        if (Exam != exam)
                        {
                            ErrorMessage.Text = "You are trying to upload the result of " + exam + " instead of " + exam + " result.";
                            return;
                        }
                        if (SessionUser.SchoolId != int.Parse(schoolId))
                        {
                            ErrorMessage.Text = "You are trying to upload the result of Different School";
                            return;
                        }

                        counter++;
                        dtTable.Rows.Add(studentid, (counter).ToString(), fullname, exam_no, LabScoreDecimal, mark, remarks);
                    }
                    gvResults.DataSource = dtTable;
                    gvResults.DataBind();
                    gvResults.Columns[0].Visible = false;
                    excelDiv.Visible = true;
                    gvResults.HeaderRow.TableSection = TableRowSection.TableHeader;

                }
            }

        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            int exam = 0;
            int studentId = 0;
            int subjectToBeUploaded = 0;
            int sessionToBeUploaded = 0;
            int counter = 0;
            string exam_no = "";
            string attendance = "";
            int.TryParse(ddlSubject.SelectedValue, out subjectToBeUploaded);
            int.TryParse(ddlExam.SelectedValue, out exam);
            int.TryParse(ddlYear.SelectedValue, out sessionToBeUploaded);
            string mark = "";
            string remarks = "";
            bool attend = false;

            for (int i = 0; i < gvResults.Rows.Count; i++)
            {
                 int.TryParse(gvResults.Rows[i].Cells[0].Text, out studentId);
                exam_no = Convert.ToString(gvResults.Rows[i].Cells[3].Text);
                attendance = Convert.ToString(gvResults.Rows[i].Cells[4].Text);
                mark = Convert.ToString(gvResults.Rows[i].Cells[5].Text);
                remarks = Convert.ToString(gvResults.Rows[i].Cells[6].Text);
                if(attendance == "Present")
                {
                    attend = true;
                }
                else
                {
                    attend = false;
                }

                var registeredExam = unitOfWork.ExamRegistered.Get(filter: x => x.ExamId == exam && x.SchoolId == SessionUser.SchoolId && x.StudentId == studentId && x.SubjectId == subjectToBeUploaded && x.SessionId == sessionToBeUploaded).SingleOrDefault();
                registeredExam.Attendance = attend;
                registeredExam.AttendanceRemarks = remarks;
                registeredExam.StudentRegNum = exam_no;
                registeredExam.TotalScore = decimal.Parse(mark);
                unitOfWork.ExamRegistered.Update(registeredExam);
                unitOfWork.Save();
                ++counter;
            }
            DropDownManager.ShowPopUp($"{counter} attendance was successfully uploaded");
            excelDiv.Visible = false;
        }
    }
}