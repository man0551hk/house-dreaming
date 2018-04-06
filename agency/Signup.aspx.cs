using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HouseDreaming;
using MySql.Data.MySqlClient;
using Microsoft.VisualBasic;

public partial class agency_signup : Agency_Page_Control
{
    MySqlConnection cn = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["sq_housedreaming"].ConnectionString);
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            companyNameEn.Attributes.Add("placeholder", (string)GetLocalResourceObject("companyNameEn.Text"));
            companyNameTc.Attributes.Add("placeholder", (string)GetLocalResourceObject("companyNameTc.Text"));
            companyLicense.Attributes.Add("placeholder", (string)GetLocalResourceObject("companyLicense.Text"));
            agentNameEn.Attributes.Add("placeholder", (string)GetLocalResourceObject("agentNameEn.Text"));
            agentNameTc.Attributes.Add("placeholder", (string)GetLocalResourceObject("agentNameTc.Text"));
            agentLicense.Attributes.Add("placeholder", (string)GetLocalResourceObject("agentLicense.Text"));
            email.Attributes.Add("placeholder", (string)GetLocalResourceObject("email.Text"));
            mobile.Attributes.Add("placeholder", (string)GetLocalResourceObject("mobile.Text"));
            officePhone.Attributes.Add("placeholder", (string)GetLocalResourceObject("officePhone.Text"));
            fax.Attributes.Add("placeholder", (string)GetLocalResourceObject("fax.Text"));
            thanks.Visible = false;
            errorDiv.Visible = false;
        }
    }

    protected void signupBtn_Click(object sender, EventArgs e)
    {
        try
        {
            cn.Open();
            bool allow = true;
            MySqlCommand checkCmd = new MySqlCommand("select agencyID from agency where email = @email or mobile = @mobile or agentLicense = @agentLicense", cn);
            checkCmd.CommandType = System.Data.CommandType.Text;
            checkCmd.Parameters.Add("@email", MySqlDbType.VarChar).Value = email.Text;
            checkCmd.Parameters.Add("@mobile", MySqlDbType.VarChar).Value = mobile.Text;
            checkCmd.Parameters.Add("@agentLicense", MySqlDbType.VarChar).Value = agentLicense.Text;
            MySqlDataReader dr = checkCmd.ExecuteReader();
            if (dr.HasRows)
            {
                allow = false;
            }
            dr.Close();

            if (allow)
            {
                MySqlCommand cmd = new MySqlCommand(@"insert into agency (companyNameEn, companyNameTc, companyNameSc, companyLicense, agentNameEn, agentNameTc, agentNameSc, agentLicense, email, mobile, officePhone, fax, gender, createDate)
                                                    values 
                                                   (@companyNameEn, @companyNameTc, @companyNameSc, @companyLicense, @agentNameEn, @agentNameTc, @agentNameSc, @agentLicense, @email, @mobile, @officePhone, @fax, @gender, NOW())", cn);
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.Parameters.Add("@companyNameEn", MySqlDbType.VarChar).Value = companyNameEn.Text;
                cmd.Parameters.Add("@companyNameTc", MySqlDbType.VarChar).Value = companyNameTc.Text;
                cmd.Parameters.Add("@companyNameSc", MySqlDbType.VarChar).Value = Microsoft.VisualBasic.Strings.StrConv(agentNameTc.Text, VbStrConv.SimplifiedChinese, 2052);
                cmd.Parameters.Add("@companyLicense", MySqlDbType.VarChar).Value = companyLicense.Text;
                cmd.Parameters.Add("@agentNameEn", MySqlDbType.VarChar).Value = agentNameEn.Text;
                cmd.Parameters.Add("@agentNameTc", MySqlDbType.VarChar).Value = agentNameTc.Text;
                cmd.Parameters.Add("@agentNameSc", MySqlDbType.VarChar).Value = Microsoft.VisualBasic.Strings.StrConv(agentNameTc.Text, VbStrConv.SimplifiedChinese, 2052);
                cmd.Parameters.Add("@agentLicense", MySqlDbType.VarChar).Value = agentLicense.Text;
                cmd.Parameters.Add("@email", MySqlDbType.VarChar).Value = email.Text;
                cmd.Parameters.Add("@mobile", MySqlDbType.Int32).Value = Convert.ToInt32(mobile.Text);
                cmd.Parameters.Add("@officePhone", MySqlDbType.Int32).Value = officePhone.Text != "" ? Convert.ToInt32(officePhone.Text) : 0;
                cmd.Parameters.Add("@fax", MySqlDbType.Int32).Value = fax.Text != "" ? Convert.ToInt32(fax.Text) : 0;
                cmd.Parameters.Add("@gender", MySqlDbType.VarChar).Value = gender.SelectedValue.ToString();
                cmd.ExecuteNonQuery();
                form1.Visible = false;
                thanks.Visible = true;
                errorDiv.Visible = false;
            }
            else 
            {
                errorDiv.Visible = true;
            }
        }
        catch (Exception ex)
        { 
        
        }
        finally
        {
            cn.Close();
        }
    }

    public void checkCheckBox(object o, ServerValidateEventArgs e)
    {
        if (acceptCb.Checked)
        {
            e.IsValid = true;
        }
        else
        {
            e.IsValid = false;
        }
    } 
}