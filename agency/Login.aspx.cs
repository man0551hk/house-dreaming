using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HouseDreaming;

using System.Data.Odbc;
using System.Data.SqlClient;
using System.Data;

public partial class agency_Login : Agency_Page_Control
{
    SqlConnection cn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["sq_housedreaming"].ConnectionString);
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["agencyID"] != null)
        {
            Response.Redirect("home/");
        }
        if (!IsPostBack)
        {
            email.Attributes.Add("placeholder", (string)GetLocalResourceObject("email.Text"));
            password.Attributes.Add("placeholder", (string)GetLocalResourceObject("password.Text"));
            errorDiv.Visible = false;
        }
    }


    protected void loginBtn_Click(object sender, EventArgs e)
    {
        bool loginSuccess = false;
        try
        {
            int agencyID = 0;
            string enryptedPassword = Crypto.EncryptMD5(password.Text);
            cn.Open();
            SqlCommand cmd = new SqlCommand("AgencyLogin", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@email", SqlDbType.VarChar).Value = email.Text;
            cmd.Parameters.Add("@password", SqlDbType.VarChar).Value = enryptedPassword;
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                agencyID = Convert.ToInt32(dr["agencyID"]);
                Session["agencyID"] = agencyID;
                loginSuccess = true;
                errorDiv.Visible = false;
                if (rememberMe.Checked)
                {
                    Agency_Kernel.SaveAgencyIDCookie(agencyID);
                }
            }
            dr.Close();
        }
        catch (Exception ex)
        {
            Response.Write(ex.Message);
        }
        finally
        { }
        if (loginSuccess)
        {
            Response.Redirect(CommonFunc.GetAgencyDomain() + "home/");
        }
        else
        {
            errorDiv.Visible = true;
        }
    }
}