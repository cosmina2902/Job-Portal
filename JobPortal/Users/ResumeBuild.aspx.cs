using iText.IO.Image;
using iText.Kernel.Pdf;
using iText.Kernel.Pdf.Canvas.Draw;
using iText.Layout;
using iText.Layout.Element;
using iText.Layout.Properties;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using iText.IO.Image;
using iText.Kernel.Colors;
using iText.Kernel.Pdf;
using iText.Kernel.Pdf.Action;
using iText.Kernel.Pdf.Canvas.Draw;
using iText.Layout;
using iText.Layout.Element;
using iText.Layout.Properties;
using Image = iText.Layout.Element.Image;

namespace JobPortal.Users
{

    public partial class ResumeBuild : System.Web.UI.Page
    {
        SqlCommand cmd;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user"] == null)
            {
                Response.Redirect("../Users/Login.aspx");
            }
            else
            {
                fillData();
            }

           
            

        }
        private void fillData()
        {

            cmd = new SqlCommand("SELECT * FROM IncarcareXmlCV " +
                    "JOIN Users ON IncarcareXmlCV.id = Users.UserId " +
                    "WHERE IncarcareXmlCV.id = Users.UserId", ConexiuneBd.conn);
            ConexiuneBd.conn.Open();

            SqlDataReader sdr = cmd.ExecuteReader();
            if (sdr.HasRows)
            {
                while (sdr.Read())
                {
                    txtFirstName.Text = sdr["FirstName"].ToString();
                    txtLastName.Text = sdr["LastName"].ToString();
                    txtEmail.Text = sdr["Email"].ToString();
                    txtBirthday.Text= sdr["Birthdate"].ToString();
                    txtGender.Text= sdr["Gender"].ToString();
                    txtStartDayWork.Text = Convert.ToDateTime(sdr["startDateWork"]).ToString("yyyy-MM-dd");
                    txtEndDateWork.Text = Convert.ToDateTime(sdr["endDateWork"]).ToString("yyyy-MM-dd");
                    txtOrganization.Text = sdr["Organization"].ToString();
                    txtPosition.Text = sdr["Position"].ToString();
                    txtType.Text = sdr["Typee"].ToString();
                    txtType.Text = sdr["Activity"].ToString();
                    txtTitleED.Text = sdr["TitleEd"].ToString();
                    txtStartDateEd.Text = Convert.ToDateTime(sdr["StartDateEd"]).ToString("yyyy-MM-dd");
                    txtEndDateEd.Text = Convert.ToDateTime(sdr["EndDateEd"]).ToString("yyyy-MM-dd");
                    txtQualificationtitle.Text = sdr["Qualificationtitle"].ToString();
                    txtQualificationlevel.Text = sdr["Qualificationlevel"].ToString();
                    TextBox2.Text = sdr["Qualificationsector"].ToString();
                    txtLanguage.Text = sdr["NameLg"].ToString();
                    txtProficiency.Text = sdr["Proficiency"].ToString();
                    txtNameSkil.Text = sdr["namesk"].ToString();
                    txtDescription.Text = sdr["descriptionsk"].ToString();
                    txtActivity.Text = sdr["Activity"].ToString();



                }


            }
            sdr.Close();
            ConexiuneBd.conn.Close();




        }
        protected void btnGenButton_Click(object sender, EventArgs e)
        {
            try
            {
                PdfWriter writer = new PdfWriter("D:\\CV" + txtLastName.Text + txtFirstName.Text + ".pdf");
                PdfDocument pdf = new PdfDocument(writer);
                Document document = new Document(pdf);
                Paragraph header = new Paragraph("CV- " + txtFirstName.Text + " " + txtLastName.Text)
                .SetTextAlignment(TextAlignment.CENTER)
                .SetFontSize(20);
                document.Add(header);
                Paragraph subheader = new Paragraph("Made by JobPortal")
                .SetTextAlignment(TextAlignment.CENTER)
                .SetFontSize(15);
                document.Add(subheader);

                // Linie separatoare
                LineSeparator ls = new LineSeparator(new SolidLine());
                document.Add(ls);
                // Linie noua
                Paragraph newline = new Paragraph(new Text("\n"));
                document.Add(newline);
                Paragraph PersonalInformation = new Paragraph("Personal Information")
                .SetTextAlignment(TextAlignment.LEFT)
                .SetFontSize(15);
                document.Add(PersonalInformation);
                document.Add(newline);
                Paragraph Name = new Paragraph(" Numele: " +
                txtLastName.Text + ", " +
                "Prenumele: " + txtFirstName.Text );
                document.Add(Name);
                // Linie noua
                document.Add(newline);
                Paragraph email = new Paragraph("Email:  "+txtEmail.Text);
                document.Add(email);
                document.Add(newline);
                Paragraph birthday = new Paragraph("Birthday:  "+txtBirthday.Text+" , Gender:  "+txtGender.Text);
                document.Add(birthday);
                document.Add(newline);
                document.Add(newline);
                Paragraph LastJobInf = new Paragraph("Last / Curent Job Information")
               .SetTextAlignment(TextAlignment.LEFT)
               .SetFontSize(15);
                document.Add(LastJobInf);
                document.Add(newline);
                Paragraph date = new Paragraph("Start Date:  "+txtStartDayWork.Text
                    +"  ,  End Date:  "+txtEndDateWork.Text);
                document.Add(date);
                document.Add(newline);
                Paragraph Organization = new Paragraph("Organization: "+txtOrganization.Text);
                document.Add(Organization); document.Add(newline);
                Paragraph position = new Paragraph("Position:  "+txtPosition.Text);
                document.Add(position);
                document.Add(newline);
                Paragraph Type = new Paragraph("Type:  "+txtType.Text);
                document.Add(Type);
                document.Add(newline);
                Paragraph Activity = new Paragraph("Activity:  " + txtActivity.Text);
                document.Add(Activity);
                document.Add(newline);
                document.Add(newline);
                Paragraph Education = new Paragraph("Education")
                  .SetTextAlignment(TextAlignment.LEFT)
                  .SetFontSize(15);
                document.Add(Education);
                document.Add(newline);
                Paragraph Title = new Paragraph("Title:  " +txtTitleED.Text);
                document.Add(Title);
                document.Add(newline);
                Paragraph dateEd = new Paragraph("Start Date:  " + txtStartDateEd.Text
                     + "  ,  End Date:  " + txtEndDateEd.Text);
                document.Add(dateEd);
                document.Add(newline);
                Paragraph Qualification = new Paragraph("Qualification Title:  " + txtQualificationtitle.Text+
                    "Qualification Level:  "+txtQualificationlevel.Text+ " Qualification Sector:  "+TextBox2.Text);
                document.Add(Qualification);
                document.Add(newline);
                Paragraph Langueges = new Paragraph("Langueges:  " + txtLanguage.Text+"  Proficiency:  "+txtProficiency.Text);
                document.Add(Langueges);
                document.Add(newline);
                Paragraph Skil = new Paragraph("Skils")
                  .SetTextAlignment(TextAlignment.LEFT)
                  .SetFontSize(15);
                document.Add(Skil);
                Paragraph Skils = new Paragraph("Name Skils:  "+txtNameSkil.Text);
                document.Add(Skils);
                document.Add(newline);
                Paragraph Description = new Paragraph("Description:  " +txtDescription.Text);
                document.Add(Description);
                document.Add(newline);

                // Adaugare imagine
                ImageData imageData = ImageDataFactory.Create("C:\\Users\\COSMINA\\OneDrive\\Desktop\\c#\\Lab2MTP\\JobPortal\\JobPortal\\assets\\img\\logo\\logo.png");
                Image image = new Image(imageData);
                document.Add(image);
                // Linie noua
                document.Add(newline);
                int n = pdf.GetNumberOfPages();
                for (int i = 1; i <= n; i++)
                {
                    document.ShowTextAligned(new Paragraph(String
                    .Format("Pagina" + i + " din " + n)),
                    559, 806, i, TextAlignment.RIGHT,
                    VerticalAlignment.TOP, 0);
                }


                document.Close();
                lblMsg.Text = "CV Succsessful Genereted! Congrats! ";
                lblMsg.CssClass = " alert alert-success";
            }
            catch (Exception ex)
            {
                lblMsg.Text = "Something went wrong...Try Again"+ex;
                lblMsg.CssClass = " alert alert-danger";
            }

        }

    }
}