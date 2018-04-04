using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HouseDreaming;
using MySql.Data.MySqlClient;

public partial class agency_ChangePassword : Agency_Page_Control
{
    string key = "";
    string originPassword = "";
    string agencyID = "";
    OdbcConnection cn = new OdbcConnection(System.Configuration.ConfigurationManager.ConnectionStrings["sq_housedreaming"].ConnectionString);
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            oldPassword.Attributes.Add("placeholder", (string)GetLocalResourceObject("originPassword.Text"));
            newPassword.Attributes.Add("placeholder", (string)GetLocalResourceObject("newPassword.Text"));
            confirmPassword.Attributes.Add("placeholder", (string)GetLocalResourceObject("confirmPassword.Text"));
        }

        if (Request.QueryString["key"] == null)
        {
            successForm.Visible = true;
            form1.Visible = false;
        }
        else
        {
            successForm.Visible = false ;
            key =  Crypto.DecryptStringAES(Request.QueryString["key"].ToString());
            agencyID = key.Substring(0, key.IndexOf("~"));
            originPassword = Crypto.DecryptMD5(key.Substring(key.IndexOf("~") + 1, key.Length - (key.IndexOf("~") + 1)));
            oldPassword.Text = originPassword;
        }
    }

    protected void confirmBtn_Click(object sender, EventArgs e)
    {
        string encryptedPassword = Crypto.EncryptMD5(newPassword.Text);
        try
        {
            cn.Open();
            OdbcCommand cmd = new OdbcCommand("update agency set password = @password where agencyID = @agencyID", cn);
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.Parameters.Add("@password", OdbcType.VarChar).Value = encryptedPassword;
            cmd.Parameters.Add("@agencyID", OdbcType.Int).Value = Convert.ToInt32(agencyID);
            cmd.ExecuteNonQuery();
            Response.Redirect("ChangePassword.aspx");
        }
        catch (Exception ex)
        { }
        finally
        {
            cn.Close();
        }
    }
}