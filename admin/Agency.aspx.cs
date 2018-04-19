
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Odbc;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class admin_Agency : System.Web.UI.Page
{
    SqlConnection cn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["sq_housedreaming"].ConnectionString);
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {

            LoadAgency();
        }
    }

    private void LoadAgency()
    {
        try
        {
            cn.Open();
            SqlCommand cmd = new SqlCommand("GetPendingAgency", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter ad = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            ad.Fill(ds);

            agencyRepeater.DataSource = ds;
            agencyRepeater.DataBind();
        }
        catch (Exception ex)
        { }
        finally
        {
            cn.Close();
        }

        for (int i = 0; i < agencyRepeater.Items.Count; i++)
        {
            Button approveBtn = agencyRepeater.Items[i].FindControl("approveBtn") as Button;
            AsyncPostBackTrigger trigger = new AsyncPostBackTrigger();
            trigger.ControlID = approveBtn.UniqueID;
            trigger.EventName = "Click";
            agencyPanel.Triggers.Add(trigger);
        }
    }

    protected void approveBtn_Click(object sender, EventArgs e)
    {
        Button approveBtn = sender as Button;
        RepeaterItem ri = (RepeaterItem)approveBtn.NamingContainer;
        HiddenField hfAgencyID = ri.FindControl("hiddenAgencyID") as HiddenField;
        string agencyID = hfAgencyID.Value;

        try
        { 
            //generate password
            string password = CommonFunc.GeneratePassword();
            string encryptPassword = Crypto.EncryptMD5(password);
            
            cn.Open();
            SqlCommand cmd = new SqlCommand("ApproveAgency", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@password", SqlDbType.VarChar).Value = encryptPassword;
            cmd.Parameters.Add("@agencyID", SqlDbType.Int).Value = agencyID;
            cmd.ExecuteNonQuery();


            //send email
        }
        catch (Exception ex)
        {
        
        }
        finally
        {
            cn.Close();
        }
        LoadAgency();
    }
}

//EAAAAPHfH14eEdp54RLf2j2zyCjj3R8q8HB1+Rl2+Yzhd83l