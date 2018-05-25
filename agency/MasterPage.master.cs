using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HouseDreaming;
using System.Threading;
using System.Globalization;

using System.Data;
using System.Data.SqlClient;

public partial class agency_MasterPage : System.Web.UI.MasterPage
{
    SqlConnection cn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["sq_housedreaming"].ConnectionString);

    protected void Page_Load(object sender, EventArgs e)
    {
        //if (Session["agencyID"] != null)
        //{
        //    LoadAgencyProfile();
        //}
        //else
        //{
        //    Response.Redirect(CommonFunc.GetAgencyDomain() + "Login/");
        //}
        
    }

    public void LoadAgencyProfile()
    {
        try
        {
            cn.Open();
            SqlCommand cmd = new SqlCommand(@"GetAgencyProfile", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@agencyID", SqlDbType.Int).Value = Convert.ToInt32(Session["agencyID"]);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                string agencyProfilePhoto = dr["agencyProfilePhoto"] == DBNull.Value ? "images/unknown.png" : dr["agencyProfilePhoto"].ToString();
                string agentNameEn = dr["agentNameEn"].ToString();
                string agentNameTc = dr["agentNameTc"].ToString();
                string agentName = agentNameTc + "<br/>" + agentNameEn;
                profileUrl.ImageUrl = agencyProfilePhoto;
                username.Text = agentName;
            }
            dr.Close();

        }
        catch (Exception ex)
        { }
        finally
        { 
        
        }

    }
}
