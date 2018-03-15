using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HouseDreaming;
using MySql.Data.MySqlClient;

public partial class agency_Login : Agency_Page_Control
{
    MySqlConnection cn = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["sq_housedreaming"].ConnectionString);
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["agencyID"] != null)
        {
            Response.Redirect("Default.aspx");
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
            MySqlCommand cmd = new MySqlCommand("select agencyID from agency where email = @email and password = @password", cn);
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.Parameters.Add("@email", MySqlDbType.VarChar).Value = email.Text;
            cmd.Parameters.Add("@password", MySqlDbType.VarChar).Value = enryptedPassword;
            MySqlDataReader dr = cmd.ExecuteReader();
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
        }
        finally
        { }
        if (loginSuccess)
        {
            Response.Redirect("Default.aspx");
        }
        else
        {
            errorDiv.Visible = true;
        }
    }
}