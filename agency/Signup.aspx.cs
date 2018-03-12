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
            thanks.Visible = false;
        }
    }

    protected void signupBtn_Click(object sender, EventArgs e)
    {
        try
        {
            cn.Open();
            MySqlCommand cmd = new MySqlCommand(@"insert into agency (companyName, companyLicense, agentName, agentLicense, email, mobile, officePhone, fax, gender, createDate)
                                                    values 
                                                   (@companyName, @companyLicense, @agentName, @agentLicense, @email, @mobile, @officePhone, @fax, @gender, NOW())", cn);
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.Parameters.Add("@companyName", MySqlDbType.VarChar).Value = companyName.Text;
            cmd.Parameters.Add("@companyLicense", MySqlDbType.VarChar).Value = companyLicense.Text;
            cmd.Parameters.Add("@agentName", MySqlDbType.VarChar).Value = agentName.Text;
            cmd.Parameters.Add("@agentLicense", MySqlDbType.VarChar).Value = agentLicense.Text;
            cmd.Parameters.Add("@email", MySqlDbType.VarChar).Value = email.Text;
            cmd.Parameters.Add("@mobile", MySqlDbType.Int32).Value = Convert.ToInt32(mobile.Text);
            cmd.Parameters.Add("@officePhone", MySqlDbType.Int32).Value = officePhone.Text != "" ? Convert.ToInt32(officePhone.Text) : 0;
            cmd.Parameters.Add("@fax", MySqlDbType.Int32).Value = fax.Text != "" ? Convert.ToInt32(fax.Text) : 0;
            cmd.Parameters.Add("@gender", MySqlDbType.VarChar).Value = gender.SelectedValue.ToString();
            cmd.ExecuteNonQuery();
            form1.Visible = false;
            thanks.Visible = true;
        }
        catch (Exception ex)
        { 
        
        }
        finally
        {
            cn.Close();
        }
    }
}