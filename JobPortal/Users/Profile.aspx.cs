using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.EnterpriseServices;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;

namespace JobPortal.Users
{
    public partial class Profile : System.Web.UI.Page
    {
        SqlCommand cmd;
        SqlDataAdapter sda;
        DataTable dt;
       // string str = ConfigurationManager.ConnectionStrings["JobPortal"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user"]==null)
            {
                Response.Redirect("Login.aspx");
            }
            if (!IsPostBack)
            {
                showUserProfile();
            }
        }

        private void showUserProfile()
        {
            cmd = new SqlCommand("Select UserId,Username,Name,Adress,Mobile,Email,Country,Resume from Users where Username=@username", ConexiuneBd.conn);
            cmd.Parameters.AddWithValue("@username", Session["user"]);
            sda = new SqlDataAdapter(cmd);
            dt = new DataTable();
            sda.Fill(dt);
            dlProfile.DataSource = dt;
            dlProfile.DataBind();
        }

        protected void dlProfile_ItemCommand(object source, DataListCommandEventArgs e)
        {
            
            if (e.CommandName == "EditUserProfile")
            {
                string username = e.CommandArgument.ToString();
                FileUpload fuXMLCv = (FileUpload)e.Item.FindControl("fuXMLCv");

                if (fuXMLCv.HasFile && Path.GetExtension(fuXMLCv.FileName).ToLower() == ".xml")
                {
                    try
                    {
                        XmlDocument doc = new XmlDocument();
                        doc.Load(fuXMLCv.FileContent);
                        XmlNamespaceManager nsmgr = new XmlNamespaceManager(doc.NameTable);
                        nsmgr.AddNamespace("europass", "http://europass.cedefop.europa.eu/Europass");

                        XmlNode personInfoNode = doc.SelectSingleNode("//europass:learnerinfo/europass:personinfo", nsmgr);

                        string firstName = personInfoNode.SelectSingleNode("europass:firstname", nsmgr)?.InnerText;
                        string lastName = personInfoNode.SelectSingleNode("europass:lastname", nsmgr)?.InnerText;
                        string birthdate = personInfoNode.SelectSingleNode("europass:birthdate", nsmgr)?.InnerText;
                        string gender = personInfoNode.SelectSingleNode("europass:gender", nsmgr)?.InnerText;
                        string email = personInfoNode.SelectSingleNode("europass:email", nsmgr)?.InnerText;

                        XmlNode workexperience = doc.SelectSingleNode("//europass:learnerinfo/europass:workexperience", nsmgr);
                        XmlNode workNode = workexperience.SelectSingleNode("europass:work", nsmgr);


                        string startDateWork = workNode.SelectSingleNode("europass:startdate", nsmgr)?.InnerText;
                        string endDateWork = workNode.SelectSingleNode("europass:enddate", nsmgr)?.InnerText;
                        string organization = workNode.SelectSingleNode("europass:organization", nsmgr)?.InnerText;
                        string position = workNode.SelectSingleNode("europass:position", nsmgr)?.InnerText;

                        XmlNodeList activityNodes = workNode.SelectNodes("europass:mainactivities/europass:activity", nsmgr);
                        string activity = null;
                        foreach (XmlNode activityNode in activityNodes)
                        {
                             activity = activityNode.InnerText;
                           
                        }
                        string type = workNode.SelectSingleNode("europass:type", nsmgr)?.InnerText;

                        XmlNode education = doc.SelectSingleNode("//europass:learnerinfo/europass:education", nsmgr);
                        XmlNode educationentry = education.SelectSingleNode("europass:educationentry", nsmgr);

                        string startDateEd = educationentry.SelectSingleNode("europass:startdate",nsmgr)?.InnerText;
                        string endDateEd = educationentry.SelectSingleNode("europass:enddate", nsmgr)?.InnerText;
                        string title = educationentry.SelectSingleNode("europass:title",nsmgr)?.InnerText;
                        string organisationED = educationentry.SelectSingleNode("europass:organisation", nsmgr)?.InnerText;
                        string titleEd = educationentry.SelectSingleNode("europass:title",nsmgr)?.InnerText;

                        XmlNodeList qualification = educationentry.SelectNodes("europass:qualification", nsmgr);
                        string qualificationtitle = null;
                        string qualificationlevel = null;
                        string qualificationsector = null;
                        foreach (XmlNode qualif in qualification)
                        {
                            qualificationtitle = qualif.SelectSingleNode("europass:qualificationtitle",nsmgr)?.InnerText;
                            qualificationlevel = qualif.SelectSingleNode("europass:qualificationlevel",nsmgr)?.InnerText;
                            qualificationsector = qualif.SelectSingleNode("europass:qualificationsector", nsmgr)?.InnerText;
                        }

                        XmlNode languages = doc.SelectSingleNode("//europass:learnerinfo/europass:languages", nsmgr);
                        XmlNodeList language = languages.SelectNodes("europass:language", nsmgr);
                         string name = null;
                        string proficiency = null;
                        List<string> languageNames = new List<string>();
                        List<string> languageProficiencies = new List<string>();
                        foreach (XmlNode lang in language)
                        {
                            name = lang.SelectSingleNode("europass:name", nsmgr)?.InnerText;
                            proficiency = lang.SelectSingleNode("europass:proficiency", nsmgr)?.InnerText;
                            languageNames.Add(name);
                            languageProficiencies.Add(proficiency);
                        }

                        // Label Label1 = (Label)e.Item.FindControl("Label1");
                        string totLg = String.Join(", ", languageNames) + " (" + String.Join(", ", languageProficiencies) + ")";

                        XmlNode skills= doc.SelectSingleNode("//europass:learnerinfo/europass:skills", nsmgr);
                        XmlNodeList skill= skills.SelectNodes("europass:skill", nsmgr);

                        string nameSk = null;
                        string descriptionSk = null;
                        foreach (XmlNode sk in skill)
                        {
                            nameSk = sk.SelectSingleNode("europass:name", nsmgr)?.InnerText;
                            descriptionSk = sk.SelectSingleNode("europass:description", nsmgr)?.InnerText;
                        }
                        //Label Label1 = (Label)e.Item.FindControl("Label1");
                        //Label1.Text=nameSk;
                        ConexiuneBd.conn.Open();
                        cmd = new SqlCommand("Insert into IncarcareXmlCV(FirstName,LastName,Birthdate,Gender,Email,startDateWork,endDateWork,Organization,Position,Activity,Typee,StartDateEd,EndDateEd,Title," +
                            "OrganisationED,TitleEd,Qualificationtitle,Qualificationlevel,Qualificationsector,NameLg,Proficiency,namesk,descriptionsk) " +
                            "values(@FirstName,@LastName,@Birthdate,@Gender,@Email,@startDateWork,@endDateWork,@Organization,@Position,@Activity,@Typee,@StartDateEd,@EndDateEd,@Title" +
                            ",@OrganisationED,@TitleEd,@Qualificationtitle,@Qualificationlevel,@Qualificationsector,@NameLg,@Proficiency,@namesk,@descriptionsk)", ConexiuneBd.conn);
                        //cmd.Parameters.AddWithValue("@Id", 1);
                        //cmd.Parameters.AddWithValue("@User_Id", 1);
                        cmd.Parameters.AddWithValue("@FirstName", firstName);
                        cmd.Parameters.AddWithValue("@LastName", lastName);
                        cmd.Parameters.AddWithValue("@Birthdate", birthdate);
                        cmd.Parameters.AddWithValue("@Gender", gender);
                        cmd.Parameters.AddWithValue("@Email", email);
                        cmd.Parameters.AddWithValue("@startDateWork", startDateWork);
                        cmd.Parameters.AddWithValue("@endDateWork", endDateWork);
                        cmd.Parameters.AddWithValue("@Organization", organization);
                        cmd.Parameters.AddWithValue("@Position", position);
                        cmd.Parameters.AddWithValue("@Activity", activity);
                       // cmd.Parameters.AddWithValue("@Email", email);
                        cmd.Parameters.AddWithValue("@Typee", type);
                        cmd.Parameters.AddWithValue("@StartDateEd", startDateEd);
                        cmd.Parameters.AddWithValue("@EndDateEd", endDateEd);
                        cmd.Parameters.AddWithValue("@Title", title);
                        cmd.Parameters.AddWithValue("@OrganisationED", organisationED);
                        cmd.Parameters.AddWithValue("@TitleEd", titleEd);
                        cmd.Parameters.AddWithValue("@Qualificationtitle", qualificationtitle);
                        cmd.Parameters.AddWithValue("@Qualificationlevel", qualificationlevel);
                        cmd.Parameters.AddWithValue("@Qualificationsector", qualificationsector);
                        cmd.Parameters.AddWithValue("@NameLg", string.Join(",", languageNames));
                        cmd.Parameters.AddWithValue("@Proficiency", string.Join(",", proficiency));
                       // cmd.Parameters.AddWithValue("@Proficiency", proficiency);
                       // cmd.Parameters.AddWithValue("@OrganisationED", organisationED);
                       // cmd.Parameters.Add("@totLg", SqlDbType.VarChar, 1000).Value = totLg;
                        cmd.Parameters.AddWithValue("@namesk", nameSk);
                        cmd.Parameters.AddWithValue("@descriptionsk", descriptionSk);

                        int rowsaffected = cmd.ExecuteNonQuery();
                        if (rowsaffected > 0)
                        {
                            lblMsg.Visible = true;
                            lblMsg.Text = "registered successful!";
                            lblMsg.CssClass = "alert alert-succes";

                        }
                        else
                        {
                            lblMsg.Text = "eroare inserare! in baza de datae";
                            lblMsg.CssClass = "danger danger-alert";
                        }

                        lblMsg.Text = "File uploaded and processed successfully!";
                        lblMsg.CssClass = "alert alert-success";
                    }
                    catch (Exception ex)
                    {
                        // Seteaza mesajul de eroare
                        lblMsg.Text = "An error occurred while processing the uploaded file: " + ex.Message;
                        lblMsg.CssClass = "alert alert-danger";
                    }
                    finally
                    {
                        ConexiuneBd.conn.Close();   
                    }
                }
                else
                {
                    lblMsg.Text = "The uploaded file does not have a .xml extension";
                    lblMsg.CssClass = "alert alert-danger";
                }

            }

            if (e.CommandName == "VizualizareCV")
            {
                Response.Redirect("ResumeBuild.aspx");
            }
        }

       

        
    }
}