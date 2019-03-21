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
    public partial class UploadEntrySchedule : System.Web.UI.Page
    {
        private SessionObject sessionUser;
        
        public SessionObject SessionUser
        {
            get { return sessionUser ?? (SessionObject)Session["EdoSessionObject"]; }
            set { value = sessionUser; }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (SessionUser == null)
            {
                Response.Redirect("~/Account/Login");
            }
            DropDownManager.PopulateExam(ddlExam, SessionUser.CategoryId);
            DropDownManager.PopulateYear(ddlYear);
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {

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
                    dtTable.Columns.Add("STUDENTID");
                    dtTable.Columns.Add("SN");
                    dtTable.Columns.Add("Name");
                    dtTable.Columns.Add("Exam NO");
                    dtTable.Columns.Add("Sex");
                    string exam_no = "";
                    string fullname = "";
                    string studentid = "";
                    string sessionToBeUploaded = ddlYear.SelectedValue;
                    string exam = ddlExam.SelectedItem.Text;
                    string Exam = "";
                    string SessionId = "";
                    string eng = "";
                    string maths = "";
                    string sciTech = "";
                    string Rel = "";
                    string Arts = "";
                    string nig = "";
                    string french = "";
                    string bus = "";
                    string Arabic = "";
                    string Pratical = "";
                    string Num = "";
                    string gen = "";
                    string crs = "";
                    string irs = "";
                    string voc = "";
                    string Sign = "";
                    string Remarks = "";
                    string schoolId = "";
                    ErrorMessage.Text = "";
                    int counter = 0;
                    if (SessionUser.CategoryId == 1)
                    {
                        dtTable.Columns.Add("Eng");
                        dtTable.Columns.Add("Maths");
                        dtTable.Columns.Add("Gen");
                        dtTable.Columns.Add("C.R.S");
                        dtTable.Columns.Add("I.R.S");
                        dtTable.Columns.Add("VOC");
                        dtTable.Columns.Add("Num");
                        dtTable.Columns.Add("Sign");
                        dtTable.Columns.Add("Remarks");

                        for (int i = 0; i < rowCnt; i++)
                        {
                            if (i == 0) continue;//skipping the header
                            studentid = worksheet.Cells[i + 1, 1].Value.ToString();
                            //2 is serial number

                            exam_no = worksheet.Cells[i + 1, 4].Value.ToString();
                            fullname = worksheet.Cells[i + 1, 3].Value.ToString();
                            try
                            {
                                eng = worksheet.Cells[i + 1, 6].Value?.ToString() ?? "";
                                maths = worksheet.Cells[i + 1, 7].Value?.ToString() ?? "";
                                gen = worksheet.Cells[i + 1, 8].Value?.ToString() ?? "";
                                crs = worksheet.Cells[i + 1, 5].Value?.ToString() ?? "";
                                irs = worksheet.Cells[i + 1, 11].Value?.ToString() ?? "";
                                voc = worksheet.Cells[i + 1, 13].Value?.ToString() ?? "";
                                Num = worksheet.Cells[i + 1, 10].Value?.ToString() ?? "";
                                Sign = worksheet.Cells[i + 1, 13].Value?.ToString() ?? "";
                                Remarks = worksheet.Cells[i + 1, 10].Value?.ToString() ?? "";

                            }
                            catch (Exception)
                            {
                                //do nothing
                            }

                            if (string.IsNullOrEmpty(studentid) || string.IsNullOrEmpty(exam_no) || string.IsNullOrEmpty(fullname))
                            {
                                continue;
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
                            // dtTable.Rows.Add(studentid, (counter).ToString(), fullname, exam_no, LabScoreDecimal, mark, remarks);

                            gvPrimary.DataSource = dtTable;
                            gvPrimary.DataBind();
                            gvPrimary.Columns[0].Visible = false;
                            excelDiv.Visible = true;
                            divPri.Visible = true;
                            divSec.Visible = false;
                            gvPrimary.HeaderRow.TableSection = TableRowSection.TableHeader;

                        }
                    }
                    else
                    {
                        dtTable.Columns.Add("Eng");
                        dtTable.Columns.Add("Maths");
                        dtTable.Columns.Add("SciTech");
                        dtTable.Columns.Add("Rel");
                        dtTable.Columns.Add("Arts");
                        dtTable.Columns.Add("Nig");
                        dtTable.Columns.Add("Pre");
                        dtTable.Columns.Add("French");
                        dtTable.Columns.Add("Bus");
                        dtTable.Columns.Add("Arabic");
                        dtTable.Columns.Add("Pratical");
                        dtTable.Columns.Add("Num");
                        dtTable.Columns.Add("Sign");
                        dtTable.Columns.Add("Remarks");

                        for (int i = 0; i < rowCnt; i++)
                        {
                            if (i == 0) continue;//skipping the header
                            studentid = worksheet.Cells[i + 1, 1].Value.ToString();
                            //2 is serial number

                            exam_no = worksheet.Cells[i + 1, 4].Value.ToString();
                            fullname = worksheet.Cells[i + 1, 3].Value.ToString();
                            try
                            {
                                eng = worksheet.Cells[i + 1, 6].Value?.ToString() ?? "";
                                maths = worksheet.Cells[i + 1, 7].Value?.ToString() ?? "";
                                french = worksheet.Cells[i + 1, 8].Value?.ToString() ?? "";
                                lblSubject.Text = worksheet.Cells[i + 1, 5].Value?.ToString() ?? "";
                                sciTech = worksheet.Cells[i + 1, 11].Value?.ToString() ?? "";
                                Rel = worksheet.Cells[i + 1, 13].Value?.ToString() ?? "";
                                Arabic = worksheet.Cells[i + 1, 10].Value?.ToString() ?? "";
                                Arts = worksheet.Cells[i + 1, 5].Value?.ToString() ?? "";
                                bus = worksheet.Cells[i + 1, 11].Value?.ToString() ?? "";
                                nig = worksheet.Cells[i + 1, 13].Value?.ToString() ?? "";
                                Pratical = worksheet.Cells[i + 1, 10].Value?.ToString() ?? "";

                            }
                            catch (Exception)
                            {
                                //do nothing
                            }

                            if (string.IsNullOrEmpty(studentid) || string.IsNullOrEmpty(exam_no) || string.IsNullOrEmpty(fullname))
                            {
                                continue;
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
                            // dtTable.Rows.Add(studentid, (counter).ToString(), fullname, exam_no, LabScoreDecimal, mark, remarks);

                            gvSchool.DataSource = dtTable;
                            gvSchool.DataBind();
                            gvSchool.Columns[0].Visible = false;
                            excelDiv.Visible = true;
                            divSec.Visible = true;
                            divPri.Visible = false;
                            gvSchool.HeaderRow.TableSection = TableRowSection.TableHeader;

                        }

                    }               
                    
            }
        }

    }

        protected void btnPriEntry_Click(object sender, EventArgs e)
        {

        }

        protected void btnSecEntry_Click(object sender, EventArgs e)
        {

        }
    }
}