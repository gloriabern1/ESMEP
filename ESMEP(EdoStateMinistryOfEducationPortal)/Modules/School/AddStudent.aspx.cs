using ESMEP_EdoStateMinistryOfEducationPortal_.Infrastructure;
using ESMEP_EdoStateMinistryOfEducationPortal_.Infrastructure.Managers;
using ESMEP_EdoStateMinistryOfEducationPortal_.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ESMEP_EdoStateMinistryOfEducationPortal_.Modules.School
{
    public partial class AddStudent : System.Web.UI.Page
    {
        UnitOfWork unitOfWork = new UnitOfWork();
        DropDownManager dropDownManager = new DropDownManager();

        protected void Page_Load(object sender, EventArgs e)
        {

            if (!Page.IsPostBack)
            {
                dropDownManager.GetRelationship(ddlRelation);
                dropDownManager.GetLGA(ddlLGA, null);
                dropDownManager.GetState(ddlState);
                dropDownManager.GetGender(ddlSex);
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (ValidateInputs())
            {
                if (Page.IsValid)
                {
                    string userId = HttpContext.Current.User.Identity.GetUserId();
                   var schoolId = dropDownManager.GetSchoolId(userId);
                    var student = new Student()
                    {
                        FirstName = txtFirstName.Value,
                        LastName = txtLastName.Value,
                        MiddleName = txtMidName.Value,
                        DateOfBirth = txtdate.Value,
                        Sex = ddlSex.SelectedValue,
                        LocalGovernmentID = int.Parse(ddlLGA.SelectedValue),
                        Address = txtAddress.Value,
                        DateCreated = DateTime.Now.ToShortDateString(),
                        SchoolId = schoolId,
                        CreatedBy = userId                    
                    };
                    unitOfWork.studentData.Insert(student);
                    unitOfWork.Save();

                    var guardianDetails = new StudentGuardianDetial()
                    {
                        StudentId = student.StudentId,
                        FullName = txtFullname.Value,
                        Address = txtGAddress.Value,
                        MobileNo = txtGMobile.Value,
                        RelationShip = int.Parse(ddlRelation.SelectedValue),
                        Email = txtGEmail.Value
                    };
                    unitOfWork.GuardianDetails.Insert(guardianDetails);
                    unitOfWork.Save();
                    dropDownManager.ShowPopUp("Student Added Successfull");
                }
            }

        }

        public bool ValidateInputs()
        {
            if (string.IsNullOrEmpty(txtFirstName.Value))
            {
                ErrorMessage.Text = "Please Enter Student First Name";
                return false;
            }
            if (string.IsNullOrEmpty(txtLastName.Value))
            {
                ErrorMessage.Text = "Please Enter Student Last Name";
                return false;
            }
            if (string.IsNullOrEmpty(txtAddress.Value))
            {
                ErrorMessage.Text = "Please Enter Student Address";
                return false;
            }
            if (string.IsNullOrEmpty(txtdate.Value))
            {
                ErrorMessage.Text = "Please Enter Student Date of Birth";
                return false;
            }
            if (ddlLGA.SelectedIndex == 0)
            {
                ErrorMessage.Text = "Please Select Student Local Government";
                return false;
            }
            if (ddlRelation.SelectedIndex == 0)
            {
                ErrorMessage.Text = "Please Select Guardian Relationship";
                return false;
            }
            if (ddlState.SelectedIndex == 0)
            {
                ErrorMessage.Text = "Please Select Student State Of Origin";
                return false;
            }
            if (ddlSex.SelectedIndex == 0)
            {
                ErrorMessage.Text = "Please Select Student Sex";
                return false;
            }
            if (string.IsNullOrEmpty(txtFullname.Value))
            {
                ErrorMessage.Text = "Please Enter Guardian Full Name";
                return false;
            }
            if (string.IsNullOrEmpty(txtGAddress.Value))
            {
                ErrorMessage.Text = "Please Enter Guardian Addrees";
                return false;
            }
            if (string.IsNullOrEmpty(txtGEmail.Value))
            {
                ErrorMessage.Text = "Please Enter Guardian Email";
                return false;
            }
            if (string.IsNullOrEmpty(txtGMobile.Value))
            {
                ErrorMessage.Text = "Please Enter Guardian Phone Number";
                return false;
            }
            //if (string.IsNullOrEmpty(iddropzone.PostedFile.FileName))
            //{
            //    ErrorMessage.Text = "Please Upload Student Passport";
            //    return false;
            //}
            return true;
        }

        protected void ddlState_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(ddlState.SelectedIndex > 0)
            {
                dropDownManager.GetLGA(ddlLGA, ddlState.SelectedValue.TrimEnd());
            }
        }
    }
}