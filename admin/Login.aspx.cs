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

public partial class agency_Login : Page
{
    SqlConnection cn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["sq_housedreaming"].ConnectionString);
    protected void Page_Load(object sender, EventArgs e)
    {
        email.Attributes.Add("placeholder", (string)GetLocalResourceObject("email.Text"));
        password.Attributes.Add("placeholder", (string)GetLocalResourceObject("password.Text"));
    }
    
    protected void loginBtn_Click(object sender, EventArgs e)
    {
        bool loginSuccess = false;
        try
        {
            int adminID = 0;
            string enryptedPassword = Crypto.EncryptMD5(password.Text);
            string accesskey = CommonFunc.GeneratePassword(20);
            cn.Open();
            SqlCommand cmd = new SqlCommand("AdminLogin", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@login", SqlDbType.VarChar).Value = email.Text;
            cmd.Parameters.Add("@password", SqlDbType.VarChar).Value = enryptedPassword;
            cmd.Parameters.Add("@accessKey", SqlDbType.VarChar).Value = accesskey;
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                adminID = Convert.ToInt32(dr["adminID"]);
                Session["adminID"] = adminID;
                loginSuccess = true;
                if (rememberMe.Checked)
                {
                    Admin_Kernal.SaveAdminIDCookie(adminID, accesskey);
                }
            }
            dr.Close();
        }
        catch (Exception ex)
        {
            Response.Write("Error" + ex.Message);
        }
        finally
        { }
        if (loginSuccess)
        {
            Response.Redirect(CommonFunc.GetMasterDomain() + "home/");
        }

    }
}