using ESMEP_EdoStateMinistryOfEducationPortal_.Infrastructure;
using ESMEP_EdoStateMinistryOfEducationPortal_.Infrastructure.Managers;
using ESMEP_EdoStateMinistryOfEducationPortal_.Models;
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
    public partial class UploadStudent : System.Web.UI.Page
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

        }

        protected void btnUpload_Click(object sender, EventArgs e)
        {
            string fileName = GeneralUtility.GetExcelFile(xlsxSchol);


            if (!String.IsNullOrEmpty(fileName))
            {
                var ExcelResult = ExcelPlus.ReadExcel(fileName, 2);
                DataTable dt = new DataTable();
                dt.Columns.Add("ID");
                dt.Columns.Add("Firstname");
                dt.Columns.Add("Lastname");
                dt.Columns.Add("Othername");
                dt.Columns.Add("Address");
                dt.Columns.Add("Origin");
                dt.Columns.Add("LGA");
                dt.Columns.Add("DOB");
                dt.Columns.Add("Sex");
                dt.Columns.Add("GName");
                dt.Columns.Add("GAddress");
                dt.Columns.Add("GPhone");
                dt.Columns.Add("GEmail");
                dt.Columns.Add("Relation");

                for (int i = 0; i < ExcelResult.Tables[0].Rows.Count; i++)
                {
                    // string STUDENT_ID = Convert.ToString(ExcelResult.Tables[0].Rows[i][1]);
                    string ID = Convert.ToString(ExcelResult.Tables[0].Rows[i][0]);
                    string Name = Convert.ToString(ExcelResult.Tables[0].Rows[i][1]);
                    string Lastname = Convert.ToString(ExcelResult.Tables[0].Rows[i][2]);
                    string Othername = Convert.ToString(ExcelResult.Tables[0].Rows[i][4]);
                    string Address = Convert.ToString(ExcelResult.Tables[0].Rows[i][5]);
                    string Origin = Convert.ToString(ExcelResult.Tables[0].Rows[i][3]);
                    string LGA = Convert.ToString(ExcelResult.Tables[0].Rows[i][6]);
                    string DOB = Convert.ToString(ExcelResult.Tables[0].Rows[i][7]);
                    string Sex = Convert.ToString(ExcelResult.Tables[0].Rows[i][8]);
                    string GName = Convert.ToString(ExcelResult.Tables[0].Rows[i][9]);
                    string GAddress = Convert.ToString(ExcelResult.Tables[0].Rows[i][10]);
                    string GPhone = Convert.ToString(ExcelResult.Tables[0].Rows[i][11]);
                    string GEmail = Convert.ToString(ExcelResult.Tables[0].Rows[i][12]);
                    string Relation = Convert.ToString(ExcelResult.Tables[0].Rows[i][13]);

                    dt.Rows.Add(ID, Name, Lastname, Othername, Address, Origin, LGA, DOB, Sex, GName, GAddress, GPhone, Relation);
                }

                gvResult.DataSource = dt;
                gvResult.DataBind();
                excelDiv.Visible = true;
                gvResult.HeaderRow.TableSection = TableRowSection.TableHeader;

            }
            else
            {

            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            int count = 0;
            int ErrorLine = 0;
            Models.School school = new Models.School();
            for (int i = 0; i < gvResult.Rows.Count; i++)
            {
                string ID = gvResult.Rows[i].Cells[0].Text;
                string Name = gvResult.Rows[i].Cells[1].Text;
                string Lastname = gvResult.Rows[i].Cells[2].Text;
                string Othername = gvResult.Rows[i].Cells[4].Text;
                string Address = gvResult.Rows[i].Cells[5].Text;
                string Origin = gvResult.Rows[i].Cells[3].Text;
                string LGA = gvResult.Rows[i].Cells[6].Text;
                string DOB = gvResult.Rows[i].Cells[7].Text;
                string Sex = gvResult.Rows[i].Cells[8].Text;
                string GName = gvResult.Rows[i].Cells[9].Text;
                string GAddress = gvResult.Rows[i].Cells[10].Text;
                string GPhone = gvResult.Rows[i].Cells[11].Text;
                string GEmail = gvResult.Rows[i].Cells[12].Text;
                string Relation = gvResult.Rows[i].Cells[13].Text;

                var lgaid = DropDownManager.GetLGAIdByName(LGA);
                var relation = DropDownManager.GetRelationShipByName(Relation);
                var sex = DropDownManager.GetGenderByName(Sex);
                if (InsertStudent(Name, Lastname, Othername, DOB, sex, lgaid, Address, GName, GAddress, GPhone, GEmail, relation))
                {
                    ++count;
                }
                else
                {
                    ErrorLine = Convert.ToInt32(gvResult.Rows[i].Cells[0].Text);

                }
            }
            DropDownManager.ShowPopUp($"{count} students was successfully added !!");
            if (ErrorLine != 0)
            {
                DropDownManager.ShowPopUp("Record at Row " + ErrorLine + " was not Inserted#");
            }
        }

        public bool InsertStudent(string fName, string lName, string oName, string dob, string sex, int lgaId, string address, string gName, string gAddress, string gPhone, string gEmail, int relation )
        {
            try
            {
                var student = new Student()
                {
                    FirstName = fName,
                    LastName = lName,
                    MiddleName = oName,
                    DateOfBirth = dob,
                    Sex = sex,
                    LocalGovernmentID = lgaId,
                    Address = address,
                    DateCreated = DateTime.Now.ToShortDateString(),
                    SchoolId = SessionUser.SchoolId,
                    CreatedBy = SessionUser.UserId
                };
                unitOfWork.studentData.Insert(student);
                unitOfWork.Save();

                var guardianDetails = new StudentGuardianDetial()
                {
                    StudentId = student.StudentId,
                    FullName = gName,
                    Address = gAddress,
                    MobileNo = gPhone,
                    RelationShip = relation,
                    Email = gEmail
                };
                unitOfWork.GuardianDetails.Insert(guardianDetails);
                unitOfWork.Save();
                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }      
   }
}