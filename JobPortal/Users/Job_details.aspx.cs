using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace JobPortal.Users
{
    public partial class Job_details : System.Web.UI.Page
    {
        SqlCommand cmd;
        SqlDataAdapter sda;
        DataTable dt,dt1;
        public string Jobtitle = string.Empty;
        protected void Page_Init(object sender, EventArgs e)
        {
          if(  Request.QueryString["id"] != null)
          {
                showJobDetailas();
                DataBind();
          }
            else
            {
                Response.Redirect("ListJobs.aspx");
            }

        }
        protected void Page_Load(object sender, EventArgs e)
        {
            

        }
        private void showJobDetailas()
        {
           
          cmd = new SqlCommand("Select * from Jobs where JobId=@JobId", ConexiuneBd.conn);
            cmd.Parameters.AddWithValue("@JobId", Request.QueryString["id"]);
          sda = new SqlDataAdapter(cmd);
          dt = new DataTable();
          sda.Fill(dt);
          DataList1.DataSource = dt;
          DataList1.DataBind();
          Jobtitle = dt.Rows[0]["Title"].ToString();
          
        }
        protected void DataList1_ItemCommand(object source, DataListCommandEventArgs e)
        {
            if (e.CommandName == "ApplyJob")
            {
                if (Session["user"]!= null)
                {
                    try
                    {
                        cmd = new SqlCommand("Insert into AppliedJobs values(@JobId, @UserId)", ConexiuneBd.conn);
                        cmd.Parameters.AddWithValue("@JobId", Request.QueryString["id"]);
                        cmd.Parameters.AddWithValue("@UserId", Session["userId"]);
                        ConexiuneBd.conn.Open();
                        int r = cmd.ExecuteNonQuery();
                        if (r > 0)
                        {
                            LblMSg.Visible=true;
                            LblMSg.Text = "Job applied successful";
                            LblMSg.CssClass = "alert alert-success";
                        }
                        else
                        {
                            LblMSg.Visible = true;
                            LblMSg.Text = "Job not applied";
                            LblMSg.CssClass = "alert alert-danger";
                        }

                    }
                    catch(Exception ex)
                    {
                        LblMSg.Visible = true;
                        LblMSg.Text = ex.Message;
                        LblMSg.CssClass = "alert alert-danger";
                    }
                    finally
                    {
                        ConexiuneBd.conn.Close();   
                    }
                }
                else
                {
                    Response.Redirect("Login.aspx");
                }
            }
        }

        protected void DataList1_ItemDataBound(object sender, DataListItemEventArgs e)
        {
            if (Session["user"]!= null)
            {
                LinkButton btnApplyJob = e.Item.FindControl("lbApplayNow") as LinkButton;
                if(isApplied())
                {
                    btnApplyJob.Enabled = false;
                    btnApplyJob.Text = "Applied";
                }
                else
                {
                    btnApplyJob.Enabled = true;
                    btnApplyJob.Text = "Apply now";

                }
            }
        }
        bool isApplied()
        {
            cmd = new SqlCommand("Select * from AppliedJobs where UserId =@UserId and JodId=@JobId", ConexiuneBd.conn);
            cmd.Parameters.AddWithValue("@UserId", Session["userId"]);
            cmd.Parameters.AddWithValue("@JobId", Request.QueryString["id"]);
           
            sda = new SqlDataAdapter(cmd);
            dt1 = new DataTable();
            sda.Fill(dt1);
            if(dt1.Rows.Count == 1)
                return true; else return false;
        }
        protected string GetImageUrl(object companyImage)
        {
            if (companyImage != null && companyImage != DBNull.Value)
            {
                string imageName = companyImage.ToString();
                string imageUrl = "~/" + imageName;
                return ResolveUrl(imageUrl);
            }
            else
            {
                return string.Empty;
            }
        }

    }
}