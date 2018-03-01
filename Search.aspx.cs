using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HouseDreaming;
using MySql.Data.MySqlClient;
using System.Data;

public partial class Search : Page_Control
{
    MySqlConnection cn = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["sq_housedreaming"].ConnectionString);
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            LoadDistrict();
        }
    }

    private void LoadDistrict()
    {
        try
        {
            cn.Open();
            MySqlCommand cmd = new MySqlCommand("select case @lang when 1 then districtEn when 2 then districtTc when 3 then districtSc end as district, districtID from district", cn);
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.Parameters.Add("@lang", MySqlDbType.Int32).Value = CommonFunc.GetLanguageID();
            DataSet ds = new DataSet();
            MySqlDataAdapter ad = new MySqlDataAdapter(cmd);
            ad.Fill(ds);
            districtDDL.DataSource = ds;
            districtDDL.DataBind();
            //districtDDL.DataTextField = "district";
            //districtDDL.DataValueField = "district";

            districtDDL.Items.Insert(0, new ListItem((string)GetLocalResourceObject("lbAny.Text"), "0"));
        }
        catch (Exception ex)
        { }
        finally
        {
            cn.Close();
        }
    }

    protected void searchBtn_Click(object sender, EventArgs e)
    {
        testMsg.Text = DateTime.Now.ToString();
    }
}