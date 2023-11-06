using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection.Emit;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace JobPortal.Admin
{
    public partial class ListJob : System.Web.UI.Page
    {
        SqlCommand cmd;
        SqlDataReader dr;
        protected void Page_PreRender(object sender, EventArgs e)
        {
            if (Session["admin"]==null)
            {
                Response.Redirect("../User/Login.aspx");
            }
            if(!IsPostBack)
            {
                ShowJob();
            }    
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            ShowJob();
        }

        private void ShowJob()
        {
            try
            {

                SqlDataAdapter da = new SqlDataAdapter("SELECT Row_Number() over(Order By( JobId)) as [Sr.No],JobId,Title,NrOfPost,Qualification,Experience," +
                    "LastDayToAPply,CompanyName,Country,Locality,CreateDate FROM Jobs ",ConexiuneBd.conn);
                DataSet ds = new DataSet();
                da.Fill(ds);
                GridView1.DataSource = ds.Tables[0];
                GridView1.DataBind();
                
            }
            catch (Exception ex)
            {
                lblMsg.Text = "Nu se poate realiza conexiunea la baza de date: " + ex.Message;
            }
            finally
            {
                ConexiuneBd.conn.Close();
            }
        }

        protected void GridView1_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {
            
        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                GridViewRow row = GridView1.Rows[e.RowIndex];
                int JObid = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Values[0]);

                ScriptManager.RegisterStartupScript(this, GetType(), "ConfirmDelete", "return confirmDelete();", true);

             //   GridViewRow row = GridView1.Rows[e.RowIndex];
              //  int JObid = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Values[0]);
                cmd = new SqlCommand("Delete from Jobs Where JobId= @id", ConexiuneBd.conn);
                cmd.Parameters.AddWithValue("@id",JObid);
                ConexiuneBd.conn.Open();
                int r = cmd.ExecuteNonQuery();
                if(r>0)
                {
                    lblMsg.Text = "Job Deleted Succsfully";
                    lblMsg.CssClass = "alert alert-success";
                }
                else
                {

                    lblMsg.Text = "Cannot delete this job";
                    lblMsg.CssClass = "alert alert-danger";
                }
                GridView1.EditIndex = -1;
                ShowJob();
            }
            catch(Exception ex)
            {
                lblMsg.Text = "Error at date base"+ ex;
                lblMsg.CssClass = "alert alert-danger";
            }
            finally
            {
                ConexiuneBd.conn.Close();
            }
        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            ShowJob();
        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if(e.CommandName == "EditJob")
            {
                Response.Redirect("NewJob.aspx?id=" + e.CommandArgument.ToString());
            }
        }
    }
}