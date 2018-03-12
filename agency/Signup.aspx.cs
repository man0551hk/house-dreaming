using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HouseDreaming;
using MySql.Data.MySqlClient;

public partial class agency_signup : Agency_Page_Control
{
    MySqlConnection cn = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["sq_housedreaming"].ConnectionString);
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            companyName.Attributes.Add("placeholder", (string)GetLocalResourceObject("companyName.Text"));
            companyLicense.Attributes.Add("placeholder", (string)GetLocalResourceObject("companyLicense.Text"));
            agentName.Attributes.Add("placeholder", (string)GetLocalResourceObject("agentName.Text"));
            agentLicense.Attributes.Add("placeholder", (string)GetLocalResourceObject("agentLicense.Text"));
            email.Attributes.Add("placeholder", (string)GetLocalResourceObject("email.Text"));
            mobile.Attributes.Add("placeholder", (string)GetLocalResourceObject("mobile.Text"));
            officePhone.Attributes.Add("placeholder", (string)GetLocalResourceObject("officePhone.Text"));
            fax.Attributes.Add("placeholder", (string)GetLocalResourceObject("fax.Text"));
        }
    }

    protected void signupBtn_Click(object sender, EventArgs e)
    {
        try
        {
            cn.Open();
            MySqlCommand cmd = new MySqlCommand("", cn);
        }
        catch (Exception ex)
        { }
        finally
        {
            cn.Close();
        }
    }
}