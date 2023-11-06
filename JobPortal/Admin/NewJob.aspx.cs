using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace JobPortal.Admin
{
    public partial class NewJob : System.Web.UI.Page
    {
        SqlCommand cmd;
      
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["admin"] == null)
            {
                Response.Redirect("../Users/Login.aspx");
            }
            Session["title"] = "Add Job";
            if (!IsPostBack)
            {
                fillData();
            }
        }

        private void fillData()
        {
            if (Request.QueryString["id"]!=null)
            {
                cmd=new SqlCommand("Select * from Jobs where JobId= '"+ Request.QueryString["id"] + "' ",ConexiuneBd.conn);
                ConexiuneBd.conn.Open();
                SqlDataReader sdr = cmd.ExecuteReader();
                if(sdr.HasRows)
                {
                    while(sdr.Read())
                    {
                        txtJobTitle.Text = sdr["Title"].ToString();
                        txtNumOfPOst.Text = sdr["NrOfPost"].ToString();
                        txtDescription.Text = sdr["Description"].ToString();
                        txtQualification.Text = sdr["Qualification"].ToString();
                        txtExperience.Text = sdr["Experience"].ToString();
                        txtSpecialization.Text = sdr["Specialization"].ToString();
                        txtLastDate.Text = Convert.ToDateTime(sdr["LastDayToAPply"]).ToString("yyyy-MM-dd");
                        txtSalary.Text = sdr["Salary"].ToString();
                        ddlJobType.SelectedValue = sdr["JobType"].ToString();
                        txtCompany.Text = sdr["CompanyName"].ToString();
                        txtWebsite.Text = sdr["Website"].ToString();
                        txtEmail.Text = sdr["Email"].ToString();
                        txtAdress.Text = sdr["Adress"].ToString();
                        ddlCountry.SelectedValue = sdr["Country"].ToString();
                        txtLocality.Text = sdr["Locality"].ToString();
                        btnAdd.Text = "Update";
                        linkBack.Visible = true;
                        Session["title"] = "Edit Job";
                    }
                }
                else
                {
                    lblMsg.Text = "Job not found! ";
                    lblMsg.CssClass = "alert alert-danger";
                }
                sdr.Close();
                ConexiuneBd.conn.Close();
            }
           
            
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
               
                string type, concatQuery,imgaePath=string.Empty;
                bool isValidExecute = false;
                if (Request.QueryString["id"]!= null )
                {
                    if(fuCompanyLogo.HasFile)
                    {
                        if(IsValidExtention(fuCompanyLogo.FileName))
                        {
                            concatQuery = "CompanyIamge =@CompanyIamge,";
                        }
                        else
                        {
                            concatQuery = string.Empty;
                        }
                    }
                    else
                    {
                        concatQuery = string.Empty;
                    }
                    cmd = new SqlCommand("Update Jobs set Title= @Title,NrOfPost=@NrOfPost,Description=@Description,Qualification=@Qualification,Experience=@Experience," +
                        "Specialization=@Specialization,LastDayToAPply=@LastDayToAPply,Salary=@Salary,JobType=@JobType,CompanyName=@CompanyName,"+concatQuery+"Website=@Website," +
                        "Email=@Email,Adress=@Adress,Country=@Country,Locality=@Locality where JobId=@id", ConexiuneBd.conn);
                    type = "upated";
                    cmd.Parameters.AddWithValue("@Title", txtJobTitle.Text.Trim());
                    cmd.Parameters.AddWithValue("@NrOfPost", txtNumOfPOst.Text.Trim());
                    cmd.Parameters.AddWithValue("@Description", txtDescription.Text.Trim());
                    cmd.Parameters.AddWithValue("@Qualification", txtQualification.Text.Trim());
                    cmd.Parameters.AddWithValue("@Experience", txtExperience.Text.Trim());
                    cmd.Parameters.AddWithValue("@Specialization", txtSpecialization.Text.Trim());
                    cmd.Parameters.AddWithValue("@LastDayToAPply", txtLastDate.Text.Trim());
                    cmd.Parameters.AddWithValue("@Salary", txtSalary.Text.Trim());
                    cmd.Parameters.AddWithValue("@JobType", ddlJobType.SelectedValue);
                    cmd.Parameters.AddWithValue("@CompanyName", txtCompany.Text.Trim());
                    // 
                    cmd.Parameters.AddWithValue("@Website", txtWebsite.Text.Trim());
                    cmd.Parameters.AddWithValue("@Email", txtEmail.Text.Trim());
                    cmd.Parameters.AddWithValue("@Adress", txtAdress.Text.Trim());
                    cmd.Parameters.AddWithValue("@Country", ddlCountry.SelectedValue);
                    cmd.Parameters.AddWithValue("@Locality", txtLocality.Text.Trim());
                    cmd.Parameters.AddWithValue("@id", Request.QueryString["id"].ToString());
                    if (fuCompanyLogo.HasFile)
                    {
                        if (IsValidExtention(fuCompanyLogo.FileName))
                        {
                            Guid obj = Guid.NewGuid();
                            imgaePath = "Images/" + obj.ToString() + fuCompanyLogo.FileName;
                            fuCompanyLogo.PostedFile.SaveAs(Server.MapPath("~/Images/") + obj.ToString() + fuCompanyLogo.FileName);
                            cmd.Parameters.AddWithValue("@CompanyIamge", imgaePath);
                            isValidExecute = true;
                        }
                        else
                        {
                            lblMsg.Text = "Plese select  .jpg, .jpeg, .png file for logo";
                            lblMsg.CssClass = "alert alert-danger";
                        }
                    }
                    else
                    {
                        
                        isValidExecute = true;
                    }
                }
                else
                {
                    cmd = new SqlCommand("Insert into Jobs(Title,NrOfPost,Description,Qualification,Experience,Specialization,LastDayToAPply,Salary,JobType," +
                   "CompanyName,CompanyIamge,Website,Email,Adress,Country,Locality,CreateDate) " +
                   "values(@Title,@NrOfPost,@Description,@Qualification,@Experience,@Specialization," +
                   "@LastDayToAPply,@Salary,@JobType,@CompanyName,@CompanyIamge,@Website,@Email,@Adress,@Country,@Locality,@CreateDate)", ConexiuneBd.conn);
                    type = "saved";
                    DateTime dateTime = DateTime.Now;
                    cmd.Parameters.AddWithValue("@Title", txtJobTitle.Text.Trim());
                    cmd.Parameters.AddWithValue("@NrOfPost", txtNumOfPOst.Text.Trim());
                    cmd.Parameters.AddWithValue("@Description", txtDescription.Text.Trim());
                    cmd.Parameters.AddWithValue("@Qualification", txtQualification.Text.Trim());
                    cmd.Parameters.AddWithValue("@Experience", txtExperience.Text.Trim());
                    cmd.Parameters.AddWithValue("@Specialization", txtSpecialization.Text.Trim());
                    cmd.Parameters.AddWithValue("@LastDayToAPply", txtLastDate.Text.Trim());
                    cmd.Parameters.AddWithValue("@Salary", txtSalary.Text.Trim());
                    cmd.Parameters.AddWithValue("@JobType", ddlJobType.SelectedValue);
                    cmd.Parameters.AddWithValue("@CompanyName", txtCompany.Text.Trim());
                    // 
                    cmd.Parameters.AddWithValue("@Website", txtWebsite.Text.Trim());
                    cmd.Parameters.AddWithValue("@Email", txtEmail.Text.Trim());
                    cmd.Parameters.AddWithValue("@Adress", txtAdress.Text.Trim());
                    cmd.Parameters.AddWithValue("@Country", ddlCountry.SelectedValue);
                    cmd.Parameters.AddWithValue("@Locality", txtLocality.Text.Trim());
                    cmd.Parameters.AddWithValue("@CreateDate", dateTime);
                    if (fuCompanyLogo.HasFile)
                    {
                        if (IsValidExtention(fuCompanyLogo.FileName))
                        {
                            Guid obj = Guid.NewGuid();
                            imgaePath = "Images/" + obj.ToString() + fuCompanyLogo.FileName;
                            fuCompanyLogo.PostedFile.SaveAs(Server.MapPath("~/Images/") + obj.ToString() + fuCompanyLogo.FileName);
                            cmd.Parameters.AddWithValue("@CompanyIamge", imgaePath);
                            isValidExecute = true;
                        }
                        else
                        {
                            lblMsg.Text = "Plese select  .jpg, .jpeg, .png file for logo";
                            lblMsg.CssClass = "alert alert-danger";
                        }
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@CompanyIamge", imgaePath);
                        isValidExecute = true;
                    }
                   

                }
                if (isValidExecute)
                {
                    ConexiuneBd.conn.Open();
                    int res = cmd.ExecuteNonQuery();
                    if (res > 0)
                    {
                        lblMsg.Text = "Job " + type + " Succesful";
                        lblMsg.CssClass = "alert alert-success";
                        clear();
                    }
                    else
                    {
                        lblMsg.Text = "Cannot acces the database! ";
                        lblMsg.CssClass = "alert alert-danger";
                    }
                }

            }

            catch (Exception ex)
            {
                
                lblMsg.Text = "Cannot acces the database! "+ex;
                lblMsg.CssClass = "alert alert-danger";
            }
            finally
            {
                ConexiuneBd.conn.Close();
            }
        }

        private void clear()
        {
            txtJobTitle.Text = string.Empty;
            txtNumOfPOst.Text = string.Empty;
            txtDescription.Text = string.Empty;
            txtQualification.Text = string.Empty;
            txtExperience.Text = string.Empty;
            txtSpecialization.Text = string.Empty;
            txtLastDate.Text = string.Empty;
            txtSalary.Text = string.Empty;
            ddlCountry.ClearSelection();
            ddlJobType.ClearSelection();
            txtCompany.Text = string.Empty;
            //fuCompanyLogo.F = string.Empty;
            txtWebsite.Text = string.Empty;
            txtEmail.Text = string.Empty;
            txtAdress.Text = string.Empty;
            txtLocality.Text = string.Empty;

        }

        private bool IsValidExtention(string fileName)
        {
            bool isValid = false;
            string[] fileExtentions = { ".jpg", ".png", ".jpeg" };
            for(int i = 0; i < fileExtentions.Length; i++)
            {
                if (fileName.Contains(fileExtentions[i]))
                {
                    isValid = true;
                    break;
                }
            }
            return isValid;
        }
    }
    
}