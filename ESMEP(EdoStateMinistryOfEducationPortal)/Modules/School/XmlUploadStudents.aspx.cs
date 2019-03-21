using ESMEP_EdoStateMinistryOfEducationPortal_.Infrastructure.Managers;
using ESMEP_EdoStateMinistryOfEducationPortal_.ViewModels;
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
    public partial class XmlUploadStudents : System.Web.UI.Page
    {
        public SessionObject sessionUser;
        public SessionObject SessionUser
        {
            get { return sessionUser ?? (SessionObject)Session["EdoSessionObject"]; }
            set { value = sessionUser; }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if(SessionUser.SchoolType == 1)
            {
              var result = GeneralUtility.HasSchoolBeenAssignedQuota(SessionUser.SchoolId);
                if (!result)
                {
                    DropDownManager.ShowPopUp("Quota Has not been Assigned For this Year");
                    return;
                }
            }
        }

        protected void btnUpload_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(xlsxSchol.PostedFile.FileName))
            {
                DataTable table = new DataTable();
                table.Columns.Add("ID");
                table.Columns.Add("SN");
                table.Columns.Add("REG_NUM");
                table.Columns.Add("FULLNAME");
                table.Columns.Add("DATE_OF_BIRTH");
                table.Columns.Add("GENDER");
                table.Columns.Add("EXAM_YEAR");
                table.Columns.Add("ADDRESS");
                table.Columns.Add("PICTURES");

                lblFileName.Text = GeneralUtility.GetExcelFile(xlsxSchol);
                string extenstion = Path.GetExtension(lblFileName.Text);
                if (extenstion != ".xml")
                {
                    DataSet ds = new DataSet();
                    ds.ReadXml(lblFileName.Text);
                    int counter = 0;
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {

                        string ID = ds.Tables[0].Rows[i]["ID"].ToString();
                        string RegNum = ds.Tables[0].Rows[i]["REG_NUMBER"].ToString();
                        string LastName = ds.Tables[0].Rows[i]["SURNAME"].ToString();
                        string FirstName = ds.Tables[0].Rows[i]["LASTNAME"].ToString();
                        string OtherName = ds.Tables[0].Rows[i]["OTHERNAME"].ToString();
                        string FullName = ds.Tables[0].Rows[i]["FULLNAME"].ToString();
                        string DateofBirth = ds.Tables[0].Rows[i]["DATE_OF_BIRTH"].ToString();
                        string Gender = ds.Tables[0].Rows[i]["GENDER"].ToString();
                        string ExamYear = ds.Tables[0].Rows[i]["EXAM_YEAR"].ToString();
                        string Address = ds.Tables[0].Rows[i]["ADDRESS"].ToString();
                        string Base64Picture = $"data:image/png;base64,{ ds.Tables[0].Rows[i]["PICTURE"].ToString()}";
                        //  SponosorId = int.Parse(ds.Tables[0].Rows[i]["SPONOSORID"].ToString())
                        Base64Picture =  $"<img src=\"{Base64Picture}\">";

                        ++counter;
                        table.Rows.Add(ID, counter, RegNum, FullName, DateofBirth, Gender, ExamYear, Address, Base64Picture);
                    }
                    gvResults.DataSource = table;
                    gvResults.DataBind();
                    excelDiv.Visible = true;
                    gvResults.HeaderRow.TableSection = TableRowSection.TableHeader;
                }
            }
            else
            {
                DropDownManager.ShowPopUp("Please Upload a file");
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            IList<XmlStudent> student = new List<XmlStudent>();
            IList<XmlStudentUpload> uploads = new List<XmlStudentUpload>();
            IList<XmlSponosorUpload> sponosorUploads = new List<XmlSponosorUpload>();
            XmlStudentUpload newUploads;
            XmlSponosorUpload sponosorUpload;

            DataSet ds = new DataSet();
            ds.ReadXml(lblFileName.Text);

            if (ds.Tables.Count > 0)
            {
                int counter = 0;
                for (int i = 0; i < ds.Tables["Student"].Rows.Count; i++)
                {
                    newUploads = new XmlStudentUpload()
                    {
                        ID = int.Parse(ds.Tables[0].Rows[i]["ID"].ToString()),
                        RegNum = ds.Tables[0].Rows[i]["REG_NUMBER"].ToString(),
                        LastName = ds.Tables[0].Rows[i]["SURNAME"].ToString(),
                        FirstName = ds.Tables[0].Rows[i]["LASTNAME"].ToString(),
                        OtherName = ds.Tables[0].Rows[i]["OTHERNAME"].ToString(),
                        FullName = ds.Tables[0].Rows[i]["FULLNAME"].ToString(),
                        DateofBirth = ds.Tables[0].Rows[i]["DATE_OF_BIRTH"].ToString(),
                        Gender = ds.Tables[0].Rows[i]["GENDER"].ToString(),
                        ExamYear = ds.Tables[0].Rows[i]["EXAM_YEAR"].ToString(),
                        Address = ds.Tables[0].Rows[i]["ADDRESS"].ToString(),
                        Base64Picture = ds.Tables[0].Rows[i]["PICTURE"].ToString(),
                        SponosorId = int.Parse(ds.Tables[0].Rows[i]["SPONOSORID"].ToString())
                     
                    };
                    if(newUploads.Gender == "Male")
                    {
                        newUploads.Gender = "M";
                    }
                    else
                    {
                        newUploads.Gender = "F";
                    }
                    uploads.Add(newUploads);
                    for (int j = 0; j < ds.Tables["SPONOSOR_DETAIL"].Rows.Count; j++)
                    {
                        sponosorUpload = new XmlSponosorUpload()
                        {
                            SponosorId = int.Parse(ds.Tables["SPONOSOR_DETAIL"].Rows[j]["ID"].ToString()),
                            SponosorName = ds.Tables["SPONOSOR_DETAIL"].Rows[j]["FULLNAME"].ToString(),
                            SponosorEmail = ds.Tables["SPONOSOR_DETAIL"].Rows[j]["EMAIL"].ToString(),
                            SponosorPhone = ds.Tables["SPONOSOR_DETAIL"].Rows[j]["PHONE_NUMBER"].ToString(),
                            SponosorAddress = ds.Tables["SPONOSOR_DETAIL"].Rows[j]["ADDRESS"].ToString(),
                            SponosorRelationship = ds.Tables["SPONOSOR_DETAIL"].Rows[j]["RELATIONSHIP"].ToString(),
                        };
                        sponosorUploads.Add(sponosorUpload);
                        if (sponosorUpload.SponosorId == newUploads.SponosorId)
                        {
                            var result = GeneralUtility.HasQuotaFinished(SessionUser.SchoolId);
                            if (result)
                            {
                                ++counter;
                                GeneralUtility.AddStudent(sponosorUpload, newUploads);
                            }
                        }
                    }
                }
                    DropDownManager.ShowPopUp($"{counter} students upload successfully");
                    Response.Redirect("~/Modules/School/AllStudents");
            }
        }
    }
}