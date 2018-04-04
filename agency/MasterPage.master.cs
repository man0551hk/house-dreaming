﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HouseDreaming;
using System.Threading;
using System.Globalization;
using MySql.Data.MySqlClient;
using System.Data;

public partial class agency_MasterPage : System.Web.UI.MasterPage
{
    OdbcConnection cn = new OdbcConnection(System.Configuration.ConfigurationManager.ConnectionStrings["sq_housedreaming"].ConnectionString);

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["agencyID"] != null)
        {
            LoadAgencyProfile();
        }
        else
        {
            Response.Redirect("Login.aspx");
        }
        
    }

    public void LoadAgencyProfile()
    {
        try
        {
            cn.Open();
            OdbcCommand cmd = new OdbcCommand(@"select agencyProfilePhoto, agentNameEn, agentNameTc 
                                                from agency where agencyID = @agencyID", cn);
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.Parameters.Add("@agencyID", OdbcType.Int).Value = Convert.ToInt32(Session["agencyID"]);
            OdbcDataReader dr = cmd.ExecuteReader();
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
