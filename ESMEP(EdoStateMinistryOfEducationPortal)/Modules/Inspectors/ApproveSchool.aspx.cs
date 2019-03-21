using ESMEP_EdoStateMinistryOfEducationPortal_.Infrastructure.Managers;
using ESMEP_EdoStateMinistryOfEducationPortal_.Services;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ESMEP_EdoStateMinistryOfEducationPortal_.Modules.Inspectors
{
    public partial class ApproveSchool : System.Web.UI.Page
    {
        DOEServices dOEServices = new DOEServices();
        public static int Currentsession;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Currentsession = GeneralUtility.GetCurrentSessionId();
                LoadAllSchools(null, null);
            }
        }

        public void LoadAllSchools(int? sessionid, int? Lgaid )
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("SN");
            dt.Columns.Add("ID");
            dt.Columns.Add("Name");
            dt.Columns.Add("L.G.A");
            dt.Columns.Add("Year");

            var schoolQuotas = GeneralUtility.GetQuotas(Currentsession);
            if (schoolQuotas != null)
            {
                int sn = 0;
                foreach (var item in schoolQuotas)
                {
                    string id = item.SchoolId.ToString();
                  
                    string Name = item.School.Name.ToString();
                    string Lga = item.School.LocalGovernment.LocalGovernment1.ToString();
                    string year = item.Session.Name.ToString();
                    //string school = item.School.Name;
                    sn++;

                    dt.Rows.Add(sn, id, Name, Lga, year);
                }

                tblGeneral.DataSource = dt;
                tblGeneral.DataBind();
                tblGeneral.HeaderRow.TableSection = TableRowSection.TableHeader;

            }

        }

        public void LoadAllStudents(int SessionId, int SchoolId)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("SN");
            dt.Columns.Add("ID");
            dt.Columns.Add("DOEAPPROVAL");
            dt.Columns.Add("Name");
            dt.Columns.Add("BATCH");
            dt.Columns.Add("Year");

            var StudentsInSession = GeneralUtility.GetStudentsInSession(SessionId, SchoolId);
            if (StudentsInSession != null)
            {
                int sn = 0;
                foreach (var item in StudentsInSession)
                {
                    string id = item.StudentId.ToString();
                    bool approval =  Convert.ToBoolean(item.DOEApproval);
                    string Name = item.LastName.ToString()+ " " + item.MiddleName.ToString() + " " + item.FirstName.ToString();
                    string Batch="";
                    if(item.BatchID == null)
                    {
                        Batch = "Not Yet Approved";
                    }
                    else
                    {
                        Batch = item.BatchID.ToString();
                    }
                    string Year = item.Session.Name.ToString();
                    //string school = item.School.Name;
                    sn++;

                    dt.Rows.Add(sn, id, approval, Name, Batch, Year);
                }

              
                GvStudent.DataSource = dt;
                GvStudent.DataBind();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    
                    if (Convert.ToString(dt.Rows[i]["DOEAPPROVAL"]).ToUpper() == "TRUE")
                    {
                        CheckBox chk = (CheckBox)GvStudent.Rows[i].FindControl("chkapprove");
                        chk.Checked = true;
                    }

                }
                GvStudent.HeaderRow.TableSection = TableRowSection.TableHeader;

                

            }

        }

        protected void tblGeneral_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int tempsessionId = GeneralUtility.GetCurrentSessionId();
            string SessionId = ddlyear.SelectedValue.ToString();
            string Lga = ddlLgda.SelectedValue.ToString();
            string id = e.CommandArgument.ToString();
            lblSchoolId.Text = id;
            if(e.CommandName.ToLower()== "doapprove")
            {
                string CountApproved= GeneralUtility.ApproveSchool(int.Parse(id), tempsessionId);
                int i=0;
                if (int.TryParse(CountApproved, out i) && int.Parse(CountApproved) > 0)
                {
                    DropDownManager.ShowPopUp("Operation Successful, " + CountApproved + " Records Approved");
                    return;
                }
                else
                {
                    DropDownManager.ShowPopUp("Operation Not Successful, No Records Approved");
                    return;
                }
            }
            else if(e.CommandName.ToLower()== "doview")
            {
                LoadAllStudents(tempsessionId, int.Parse(id));
                panelStudent.Visible = true;
                PnlSchool.Visible = false;
            }
        }

        protected void btnApproveselected_ServerClick(object sender, EventArgs e)
        {
            int schoolid = int.Parse(lblSchoolId.Text.ToString());
            string Batchid = dOEServices.GetBatchApproval(Currentsession, schoolid);

            for (int i = 0; i < GvStudent.Rows.Count; i++)
            {
                bool Approved = false;

                CheckBox chk = (CheckBox)GvStudent.Rows[i].FindControl("chkapprove");
               

                if (chk.Checked == true) Approved = true;
                Label lbl = (Label)GvStudent.Rows[i].FindControl("lblExamId");
                string id = lbl.Text;

                dOEServices.UpdateStudentData(int.Parse(id), Approved, schoolid, Currentsession, int.Parse(Batchid));
              

            }
            }
    }
}