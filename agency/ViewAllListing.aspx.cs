using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HouseDreaming;

using System.Data;
using System.Data.SqlClient;

public partial class agency_ViewAllListing : Agency_Page_Control
{
    SqlConnection cn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["sq_housedreaming"].ConnectionString);

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            LoadListing();
        }
    }

    private void LoadListing()
    {
        try
        {
            cn.Open();
            SqlCommand cmd = new SqlCommand(@"GetPaidListing", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@lang", SqlDbType.Int).Value = Agency_Kernel.GetLanguageID();
            cmd.Parameters.Add("@agencyID", SqlDbType.Int).Value = Convert.ToInt32(Session["agencyID"]);
            DataSet ds = new DataSet();
            SqlDataAdapter ad = new SqlDataAdapter(cmd);
            ad.Fill(ds);
            listRepeater.DataSource = ds;
            listRepeater.DataBind();
        }
        catch (Exception ex)
        { }
        finally
        {
            cn.Close();
        }
    }
}