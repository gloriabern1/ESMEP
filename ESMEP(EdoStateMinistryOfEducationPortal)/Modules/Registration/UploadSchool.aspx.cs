using ESMEP_EdoStateMinistryOfEducationPortal_.Infrastructure;
using ESMEP_EdoStateMinistryOfEducationPortal_.Infrastructure.Managers;
using ESMEP_EdoStateMinistryOfEducationPortal_.Models;
using Excel;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
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
    public partial class UploadSchool : System.Web.UI.Page
    {
        protected static string imagePath = AppDomain.CurrentDomain.SetupInformation.ApplicationBase;
        UnitOfWork unitOfWork = new UnitOfWork();
        DropDownManager dropDownManager = new DropDownManager();

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnUpload_Click(object sender, EventArgs e)
        {
            //HttpPostedFileBase file = xlsxSchol.PostedFile.
            var fileName = GetExcelFile();

            if (!String.IsNullOrEmpty(fileName))
            {
                var ExcelResult = ExcelPlus.ReadExcel(fileName, 2);
                DataTable dt = new DataTable();
                dt.Columns.Add("ID");
                dt.Columns.Add("Name");
                dt.Columns.Add("Address");
                dt.Columns.Add("Email");
                dt.Columns.Add("MobileNo");
                dt.Columns.Add("LGA");
                dt.Columns.Add("Type");
                dt.Columns.Add("Category");
                dt.Columns.Add("DateOfInCorporation");
                dt.Columns.Add("PrincipalName");

                for (int i = 0; i < ExcelResult.Tables[0].Rows.Count; i++)
                {
                    // string STUDENT_ID = Convert.ToString(ExcelResult.Tables[0].Rows[i][1]);
                    string ID = Convert.ToString(ExcelResult.Tables[0].Rows[i][0]);
                    string Name = Convert.ToString(ExcelResult.Tables[0].Rows[i][1]);
                    string Address = Convert.ToString(ExcelResult.Tables[0].Rows[i][2]);
                    string Email = Convert.ToString(ExcelResult.Tables[0].Rows[i][4]);
                    string MobileNo = Convert.ToString(ExcelResult.Tables[0].Rows[i][5]);
                    string LGA = Convert.ToString(ExcelResult.Tables[0].Rows[i][3]);
                    string Type = Convert.ToString(ExcelResult.Tables[0].Rows[i][6]);
                    string category = Convert.ToString(ExcelResult.Tables[0].Rows[i][7]);
                    string DateOfInCorporation = Convert.ToString(ExcelResult.Tables[0].Rows[i][8]);
                    string PrincipalName = Convert.ToString(ExcelResult.Tables[0].Rows[i][9]);

                   
                    dt.Rows.Add(ID, Name, Address, Email, MobileNo, LGA, Type, category, DateOfInCorporation, PrincipalName);
                }

                gvResult.DataSource = dt;
                gvResult.DataBind();
                excelDiv.Visible = true;
            }
            else
            {

            }
        }

        public string GetExcelFile()
        {
            var Foldername = HttpContext.Current.Server.MapPath("~/Static Content/Documents/");
            string fileName = Path.GetFileNameWithoutExtension(xlsxSchol.PostedFile.FileName);
            string extenstion = Path.GetExtension(xlsxSchol.PostedFile.FileName);
            fileName = Path.Combine(Foldername + fileName);
            xlsxSchol.PostedFile.SaveAs(fileName);            
            return fileName;
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                int count = 0;
                int ErrorLine = 0;
                Models.School school = new Models.School();
                for (int i = 0; i < gvResult.Rows.Count; i++)
                {
                    //string student_id = gvr.Cells[1].Text;
                    string id = gvResult.Rows[i].Cells[0].Text;
                    string name = gvResult.Rows[i].Cells[1].Text;
                    string Address = gvResult.Rows[i].Cells[2].Text;
                    string Email = gvResult.Rows[i].Cells[4].Text;
                    string MobileNo = gvResult.Rows[i].Cells[5].Text;
                    string LGA = gvResult.Rows[i].Cells[3].Text;
                    string Type = gvResult.Rows[i].Cells[6].Text;
                    string category = gvResult.Rows[i].Cells[7].Text;
                    string DateOfInCorporation = gvResult.Rows[i].Cells[8].Text;
                    string PrincipalName = gvResult.Rows[i].Cells[9].Text;
                    if(Type == "Public")
                    {
                        Type = "1";
                    }
                    else
                    {
                        Type = "2";
                    }
                    if(category == "Primary")
                    {
                        category = "1";
                    }
                    else
                    {
                        category = "2";
                    }
                    var lgaid = dropDownManager.GetLGAIdByName(LGA);
                    //Create User
                    var manager = Context.GetOwinContext().GetUserManager<ApplicationUserManager>();
                    var signInManager = Context.GetOwinContext().Get<ApplicationSignInManager>();
                    var user = new ApplicationUser() { UserName = Email, Email = Email, PhoneNumber = MobileNo };
                    IdentityResult result = manager.Create(user, "@Ab1234567");
                    if (result.Succeeded)
                    {
                        // For more information on how to enable account confirmation and password reset please visit https://go.microsoft.com/fwlink/?LinkID=320771
                        //string code = manager.GenerateEmailConfirmationToken(user.Id);
                        //string callbackUrl = IdentityHelper.GetUserConfirmationRedirectUrl(code, user.Id, Request);
                        manager.AddToRole(user.Id, "School");

                        school.Name = name;
                        school.Address = Address;
                        school.Email = Email;
                        school.MobileNo = Convert.ToDecimal(MobileNo);
                        school.SchoolTypeId = int.Parse(Type);
                        school.NameOfPrincipal = PrincipalName;
                        school.LocalGovernmentID = int.Parse(lgaid);
                        school.DateOfIncorporation = Convert.ToDateTime(DateOfInCorporation);
                        school.DateCreated = DateTime.Now;
                        school.CategoryId = int.Parse(category);
                        school.CreatedBy = User.Identity.GetUserId();
                        school.UserId = user.Id;
                        unitOfWork.School.Insert(school);
                        unitOfWork.Save();
                        count++;
                    }
                    else
                    {
                        ErrorLine = Convert.ToInt32(gvResult.Rows[i].Cells[0].Text);
                    }
                }
                dropDownManager.ShowPopUp(count.ToString() + " Records Successfully Inserted !!!");
                if (ErrorLine != 0)
                {
                    dropDownManager.ShowPopUp("Record at Row " + ErrorLine + " was not Inserted#");
                }
            }
            catch (Exception ex)
            {
               // lblError.Text = ErrorLog.InsertErrorLog(ex.Message) + " Please Contact Admin";
            }
        }

    }
}
