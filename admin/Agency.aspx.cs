using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class admin_Agency : System.Web.UI.Page
{
    MySqlConnection cn = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["sq_housedreaming"].ConnectionString);
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
            MySqlCommand cmd = new MySqlCommand("select * from agency where verifyDate is null", cn);
            cmd.CommandType = System.Data.CommandType.Text;
            MySqlDataAdapter ad = new MySqlDataAdapter(cmd);
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

        //for (int i = 0; i < agencyRepeater.Items.Count; i++)
        //{
        //    Button approveBtn = agencyRepeater.Items[i].FindControl("approveBtn") as Button;
        //    AsyncPostBackTrigger trigger = new AsyncPostBackTrigger();
        //    trigger.ControlID = approveBtn.ClientID;
        //    agencyPanel.Triggers.Add(trigger);
        //}
    }
}