using JobPortal.Users;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace JobPortal.Admin
{
    public partial class Dashboard : System.Web.UI.Page
    {
        SqlDataAdapter sda;
        DataTable dt;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["admin"] == null)
            {
                Response.Redirect("../User/Login.aspx");
            }
            if (!IsPostBack)
            {
                Users();
                Jobs();
                AppliedJobs();

            }
        }

        private void AppliedJobs()
        {
          sda = new SqlDataAdapter("Select Count(*) from AppliedJobs ", ConexiuneBd.conn);
            dt = new DataTable();
            sda.Fill(dt);
            if(dt.Rows.Count>0)
            {
                Session["AppliedJobs"] = dt.Rows[0][0];
            }
            else
            {
                Session["AppliedJobs"] = 0;

            }
        }

        private void Jobs()
        {
            sda = new SqlDataAdapter("Select Count(*) from Jobs ", ConexiuneBd.conn);
            dt = new DataTable();
            sda.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                Session["Jobs"] = dt.Rows[0][0];
            }
            else
            {
                Session["Jobs"] = 0;

            }
        }

        private void Users()
        {
            sda = new SqlDataAdapter("Select Count(*) from Users ", ConexiuneBd.conn);
            dt = new DataTable();
            sda.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                Session["Users"] = dt.Rows[0][0];
            }
            else
            {
                Session["Users"] = 0;

            }
        }
    }
}