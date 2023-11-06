using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace JobPortal.Users
{
    public partial class Register : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSend_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                SqlCommand cmd;

                try
                {
                    ConexiuneBd.conn.Open();
                    cmd = new SqlCommand("insert into Users (Username,Password,Name,Adress,Email,Country) values(@Username,@Password,@Name,@Adress,@Email,@Country) ",
                    ConexiuneBd.conn);
                    cmd.Parameters.AddWithValue("@Username", txtUserName.Text.Trim());
                    cmd.Parameters.AddWithValue("@Password", txtConfirmPasswprd.Text.Trim());
                    cmd.Parameters.AddWithValue("@Name", txtFullName.Text.Trim());
                    cmd.Parameters.AddWithValue("@Adress", txtAdress.Text.Trim());
                    cmd.Parameters.AddWithValue("@Email", txtEmail.Text.Trim());
                    cmd.Parameters.AddWithValue("@Country", ddlCountry.SelectedValue);

                    int rowsAffected = cmd.ExecuteNonQuery();
                    if (rowsAffected >0)
                    {
                        lblMsg.Visible = true;
                        lblMsg.Text = "Registered Successful!";
                        lblMsg.CssClass = "alert alert-succes";
                        clear();
                    }
                    else
                       lblMsg.Text = "Eroare inserare!";
                }
                catch(SqlException ex)
                {
                    if(ex.Message.Contains("Violation of UNIQUE KEY constraint"))
                    {
                        lblMsg.Visible = true;
                        lblMsg.Text = "<b>" + txtUserName + "</b> unsername already exist, try new one..!";
                        lblMsg.CssClass = "alert alert-danger";
                    }
                }
                catch (Exception ex)
                {

                    lblMsg.Text = "Eroare la deschidere baza date " + ex.Message;
                }
                finally
                {
                    ConexiuneBd.conn.Close();
                }
               // lblMsg.Text = "Datele sunt corecte!";
            }
            else
            {
                lblMsg.Text = "Completati toate campurile!";
            }
        }

        private void clear()
        {
            txtUserName.Text = string.Empty; txtPassword.Text=string.Empty;
           txtEmail.Text = string.Empty; txtFullName.Text = string.Empty;
            txtAdress.Text= string.Empty; txtPassword.Text = string.Empty; txtConfirmPasswprd.Text = string.Empty;
            txtMobileNum.Text = string.Empty;
            ddlCountry.ClearSelection();

        }
    }
}