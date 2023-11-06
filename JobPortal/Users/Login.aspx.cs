using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace JobPortal.Users
{
    public partial class Login : System.Web.UI.Page
    {
        SqlCommand cmd;
        SqlDataReader dr;
        string username, password = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLogIn_Click(object sender, EventArgs e)
        {
            try
            {
                
                if(ddlLoginType.SelectedValue=="Admin")
                {
                    username = ConfigurationManager.AppSettings["username"];
                    password = ConfigurationManager.AppSettings["password"];
                    if(username == txtUserName.Text.Trim() && password==txtPassword.Text.Trim())
                    {
                        Session["admin"] = username;
                        Response.Redirect("../Admin/Dashboard.aspx");
                    }
                    else
                    {
                        showErrorMsg("Admin");
                    }
                }
                else
                {
                    ConexiuneBd.conn.Open();
                    cmd = new SqlCommand("select * from Users where Username = @Username and Password = @Password",ConexiuneBd.conn);
                    cmd.Parameters.AddWithValue("@Username", txtUserName.Text.Trim());
                    cmd.Parameters.AddWithValue("@Password", txtPassword.Text.Trim());
                    dr = cmd.ExecuteReader();
                    if (dr.Read())
                    {
                        Session["user"] = dr["Username"].ToString();
                        Session["userId"] = dr["UserId"].ToString();
                        Response.Redirect("Default.aspx",false);
                    }
                    else
                    {
                        showErrorMsg("User");
                       
                    }
               
                
                }
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
            finally
            {
                ConexiuneBd.conn.Close();
            }
        }

        private void showErrorMsg(string userType)
        {
            lblMsg.Visible = true;
            lblMsg.Text = "<b>" + userType+ "</b> credential are incorrect..!";
            lblMsg.CssClass = "alert alert-danger";

        }
    }
}