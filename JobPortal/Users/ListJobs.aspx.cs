using iText.Kernel.Pdf.Canvas.Parser.ClipperLib;
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
    public partial class ListJobs : System.Web.UI.Page
    {
        SqlCommand cmd;
        SqlDataAdapter sda;
        DataTable dt;
        public int jobCount = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                showJobList();
                RBSelectedColorChange();
            }

        }

        private void showJobList()
        {
            if (dt == null)
            {
                cmd = new SqlCommand("Select JobId, Title, Salary, JobType, CompanyName, CompanyIamge , Country, Locality , CreateDate from Jobs", ConexiuneBd.conn);
                sda = new SqlDataAdapter(cmd);
                dt = new DataTable();
                sda.Fill(dt);
            }

            DataList1.DataSource = dt;
            DataList1.DataBind();
            lbljobCount.Text = JobCount(DataList1.Items.Count);
        }

        private string JobCount(int count)
        {
            if(count > 1) 
            {
                return "Total <b> " + count + "</b> jobs found";

            }
            else if(count == 1) {
                return "Total <b> " + count + "</b> job found";
            }
            else
            {
                return "No job found";
            }
            
        }

        private void RBSelectedColorChange()
        {
            if (RadioButtonList1.SelectedItem != null && RadioButtonList1.SelectedItem.Selected)
            {
                RadioButtonList1.SelectedItem.Attributes.Add("class", "selectedradio");
            }
        }

        protected void ddlCountry_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlCountry.SelectedValue != "0")
            {
                cmd = new SqlCommand("SELECT JobId, Title, Salary, JobType, CompanyName, CompanyIamge, Country, Locality, CreateDate FROM Jobs " +
                    "WHERE Country = @Country", ConexiuneBd.conn);
                cmd.Parameters.AddWithValue("@Country", ddlCountry.SelectedValue);

                sda = new SqlDataAdapter(cmd);
                dt = new DataTable();
                sda.Fill(dt);

                showJobList();
                RBSelectedColorChange();
            }
            else
            {
                showJobList();
                RBSelectedColorChange();
            }

        }
        protected string GetImageUrl(object companyImage)
        {
            if (companyImage != null && companyImage != DBNull.Value)
            {
                string imageName = companyImage.ToString();
                string imageUrl = "~/"+imageName; 
                return ResolveUrl(imageUrl);
            }
            else
            {
                return string.Empty; 
            }
        }
     
        public static string RelativeDate(DateTime theDate)

        {

            Dictionary<long, string> thresholds = new Dictionary<long, string>();

            int minute = 60;

            int hour = 60 * minute;

            int day = 24 * hour;

            thresholds.Add(60, "{0} seconds ago");

            thresholds.Add(minute * 2, "a minute ago");

            thresholds.Add(45 * minute, "{0} minutes ago");

            thresholds.Add(120 * minute, "an hour ago");

            thresholds.Add(day, "{0} hours ago");

            thresholds.Add(day * 2, "yesterday");

            thresholds.Add(day * 30, "{0} days ago");

            thresholds.Add(day * 365, "{0} months ago");

            thresholds.Add(long.MaxValue, "{0} years ago");

            long since = (DateTime.Now.Ticks - theDate.Ticks) / 10000000;

            foreach (long threshold in thresholds.Keys)

            {

                if (since < threshold)

                {

                    TimeSpan t = new TimeSpan((DateTime.Now.Ticks - theDate.Ticks));

                    return string.Format(thresholds[threshold], (t.Days > 365 ? t.Days / 365 : (t.Days > 0 ? t.Days : (t.Hours > 0 ? t.Hours : (t.Minutes > 0 ? t.Minutes : (t.Seconds > 0 ? t.Seconds : 0))))).ToString());

                }

            }

            return "";

        }

        protected void CheckBoxList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string jobType = selectedCheckBox();
            if (!string.IsNullOrEmpty(jobType))
            {
                cmd = new SqlCommand("SELECT JobId, Title, Salary, JobType, CompanyName, CompanyIamge, Country, Locality, CreateDate FROM Jobs " +
                                    "WHERE JobType IN (" + jobType + ")", ConexiuneBd.conn);
                sda = new SqlDataAdapter(cmd);
                dt = new DataTable();
                sda.Fill(dt);
                showJobList();
                RBSelectedColorChange();
            }
            else
            {
                showJobList();
            }
        }

        private string selectedCheckBox()
        {
            string jobType = string.Empty;
            for (int i = 0; i < CheckBoxList1.Items.Count; i++)
            {
                if (CheckBoxList1.Items[i].Selected)
                {
                    jobType += "'" + CheckBoxList1.Items[i].Text + "',";
                }
            }
            return jobType.TrimEnd(',');
        }

        protected void RadioButtonList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(RadioButtonList1.SelectedValue!= "0")
            {
                string postDate = string.Empty;
                postDate = selectedRadioButton();
                cmd = new SqlCommand("SELECT JobId, Title, Salary, JobType, CompanyName, CompanyIamge, Country, Locality, CreateDate FROM Jobs " +
                                      "WHERE Convert(DATE, CreateDate) "+ postDate+ " ", ConexiuneBd.conn);
                sda= new SqlDataAdapter(cmd);   
                dt = new DataTable();
                sda.Fill(dt);
                showJobList();
                RBSelectedColorChange();
            }
            else
            {
                showJobList();
                RBSelectedColorChange();
            }
        }

        private string selectedRadioButton()
        {
           string postedDate = string.Empty;
            DateTime date = DateTime.Today;
            if(RadioButtonList1.SelectedValue == "1")
            {
                postedDate = "= CONVERT(DATE, '"+ date.ToString("yyyy/MM/dd") + "')";
            }
            else if(RadioButtonList1.SelectedValue == "2")
            {
                postedDate = " between Convert(DATE, '" + DateTime.Now.AddDays(-2).ToString("yyyy/MM/dd") + "') and CONVERT(DATE, '"+ date.ToString("yyyy/MM/dd")+ "')";
            }
            else if (RadioButtonList1.SelectedValue == "3")
            {
                postedDate = " between Convert(DATE, '" + DateTime.Now.AddDays(-3).ToString("yyyy/MM/dd") + "') and CONVERT(DATE, '" + date.ToString("yyyy/MM/dd") + "')";
            }
            else if (RadioButtonList1.SelectedValue == "4")
            {
                postedDate = " between Convert(DATE, '" + DateTime.Now.AddDays(-5).ToString("yyyy/MM/dd") + "') and CONVERT(DATE, '" + date.ToString("yyyy/MM/dd") + "')";
            }
            else
            {
                postedDate = " between Convert(DATE, '" + DateTime.Now.AddDays(-10).ToString("yyyy/MM/dd") + "') and CONVERT(DATE, '" + date.ToString("yyyy/MM/dd") + "')";

            }
            return postedDate;  

        }

        protected void lbFilter_Click(object sender, EventArgs e)
        {
            try
            {
                ConexiuneBd.conn.Open();
                bool isCOndition = false;
                string subquery = string.Empty;
                string JobType = string.Empty;
                string postedDate = string.Empty;
                string addAnd = string.Empty;
                string query = string.Empty;
                List<string> queryList = new List<string>();
                if(ddlCountry.SelectedValue!="0")
                {
                    queryList.Add(" Country = '" + ddlCountry.SelectedValue + "'");
                    isCOndition = true;
                }
                JobType = selectedCheckBox();
                if(JobType != "")
                {
                    queryList.Add(" JobType IN (" + JobType + ") ");
                    isCOndition = true;
                }
                if(RadioButtonList1.SelectedValue != "0")
                {
                    postedDate = selectedRadioButton();
                    queryList.Add(" Convert(DATE, CreateDate) " + postedDate);
                    isCOndition = true;
                }
                if(isCOndition)
                {
                    foreach (string a in queryList)
                    {
                        subquery += a + " and";
                    }
                    subquery = subquery.Remove(subquery.LastIndexOf("and"), 3);
                    query = @"Select JobId, Title, Salary, JobType, CompanyName, CompanyIamge, Country, Locality, CreateDate from Jobs where " + subquery + " ";
                }
                else
                {
                    query = @"Select JobId, Title, Salary, JobType, CompanyName, CompanyIamge, Country, Locality, CreateDate from Jobs ";

                }
                sda = new SqlDataAdapter(query, ConexiuneBd.conn);
                dt = new DataTable();
                sda.Fill(dt);
                showJobList();
                RBSelectedColorChange();

            }
            catch(Exception ex)
            {
                Response.Write(ex.ToString());
            }
            finally
            {
                ConexiuneBd.conn.Close();
            }
        }

        protected void lbReset_Click(object sender, EventArgs e)
        {
            ddlCountry.ClearSelection();
            CheckBoxList1.ClearSelection();
            RadioButtonList1.ClearSelection();
            RBSelectedColorChange();
            showJobList();
        }
    }
}