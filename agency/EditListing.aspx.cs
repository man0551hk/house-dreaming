using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using HouseDreaming;
public partial class agency_EditListing : Agency_Page_Control
{
    SqlConnection cn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["sq_housedreaming"].ConnectionString);

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString["listingID"] != null)
        {
            LoadData(Convert.ToInt32(Request.QueryString["listingID"]));
        }
    }

    public void LoadData(int listingID)
    {
        try
        {
            cn.Open();
            SqlCommand cmd = new SqlCommand("GetListingInfoForEdit", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@listingID", SqlDbType.Int).Value = listingID;
            cmd.Parameters.Add("@lang", SqlDbType.Int).Value = Agency_Kernel.GetLanguageID();
            SqlDataAdapter ad = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            ad.Fill(ds);
            if (ds.Tables[0] != null && ds.Tables[0].Rows.Count == 1)
            {
                DataRow dr = ds.Tables[0].Rows[0];
                area.Text = dr["area"].ToString();
                district.Text = dr["district"].ToString();
            }
        }
        catch (Exception ex)
        { }
        finally
        {
            cn.Close();
        }
    }

    protected void saveBtn_Click(object sender, EventArgs e)
    {

    }

}