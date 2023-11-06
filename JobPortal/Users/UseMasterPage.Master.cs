using MimeKit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


using MailKit.Net.Smtp;
using System.Net;
using MailKit.Security;

namespace JobPortal.Users
{
    public partial class UseMasterPage : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user"] !=null)
            {
                btnRegisterOrProfile.Text = "Profile";
                btnLoginOrLogout.Text = "Logout";
            }
            else
            {
                btnRegisterOrProfile.Text = "Register";
                btnLoginOrLogout.Text = "Login";
            }
        }

        protected void btnRegisterOrProfile_Click(object sender, EventArgs e)
        {
            if(btnRegisterOrProfile.Text=="Profile")
            {
                Response.Redirect("Profile.aspx");

            }
            else
            {
                Response.Redirect("Register.aspx");
            }
        }

        protected void LoginOrLogout_Click(object sender, EventArgs e)
        {
            if (btnLoginOrLogout.Text == "Login")
            {
                Response.Redirect("Login.aspx");

            }
            else
            {
                Session.Abandon();
                Response.Redirect("Login.aspx");
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                var email = new MimeMessage();
                //adresa de mail de la care trimitem
                email.From.Add(new MailboxAddress("Job Portal Email", "cosmina.recea@student.upt.ro"));
                //adresa de mail la care trimitem
                email.To.Add(new MailboxAddress("Cosmina", "recea.cosmina@gmail.com"));
                //Subiectul mailului
                email.Subject = "Send email from Job Portal";
                //costruim corpul mesajului - text + atasamente daca este nevoie
                var builder = new BodyBuilder();
                builder.TextBody = @"Hello This is a Feedback Email From Job Portal By Recea Cosmina";
                //builder.Attachments.Add("D:\\Exemplu.pdf");
                email.Body = builder.ToMessageBody();
                using (var smtp = new MailKit.Net.Smtp.SmtpClient())
                {
                    smtp.Connect("smtp.gmail.com", 465, true);

                    smtp.Authenticate("recea.cosmina@gmail.com", "kxhsvzjfbjeavpvs");
                    smtp.Send(email);
                    smtp.Disconnect(true);
                }
                Response.Write("<script>alert('Mail trimis cu succes!')</script>");
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('Eroare la trimiterea mesajului!'" + ex.Message + "')</script>");
            }
        }
    }
}