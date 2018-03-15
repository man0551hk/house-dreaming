using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HouseDreaming;
using MySql.Data.MySqlClient;
using System.Data;

public partial class agency_NewListing : Agency_Page_Control
{
    MySqlConnection cn = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["sq_housedreaming"].ConnectionString);

    protected void Page_Load(object sender, EventArgs e)
    {
        titleEn.Attributes.Add("placeholder", (string)GetLocalResourceObject("buildingNameEn.Text"));
        titleTc.Attributes.Add("placeholder", (string)GetLocalResourceObject("buildingNameTc.Text"));
        size.Attributes.Add("placeholder", (string)GetLocalResourceObject("size.Text"));
        netSize.Attributes.Add("placeholder", (string)GetLocalResourceObject("netSize.Text"));
        salePrice.Attributes.Add("placeholder", (string)GetLocalResourceObject("salePrice.Text"));
        rentPrice.Attributes.Add("placeholder", (string)GetLocalResourceObject("rentPrice.Text"));
        youtubeID.Attributes.Add("placeholder", "Youtube ID");
        descEn.Attributes.Add("placeholder", (string)GetLocalResourceObject("descEn.Text"));
        descTc.Attributes.Add("placeholder", (string)GetLocalResourceObject("descTc.Text"));

        if (!IsPostBack)
        {
            LoadArea();
            districtDDL.Items.Insert(0, new ListItem((string)GetLocalResourceObject("selectDistrict.Text"), "0"));
            //LoadDistrict();
        }
    }

    private void LoadArea()
    {
        try
        {
            cn.Open();
            MySqlCommand cmd = new MySqlCommand("select case @lang when 1 then areaEn when 2 then areaTc when 3 then areaSc end as area, areaID from area", cn);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add("@lang", MySqlDbType.Int32).Value = Agency_Kernel.GetLanguageID();
            DataSet ds = new DataSet();
            MySqlDataAdapter ad = new MySqlDataAdapter(cmd);
            ad.Fill(ds);
            areaDDL.DataSource = ds;
            areaDDL.DataBind();
            areaDDL.Items.Insert(0, new ListItem((string)GetLocalResourceObject("selectArea.Text"), "0"));
        }
        catch (Exception ex)
        { }
        finally
        {
            cn.Close();
        }
    }

    protected void areaDDL_SelectedIndexChanged(object sender, EventArgs e)
    {
        DropDownList ddl = sender as DropDownList;
        //testMsg.Text = ddl.SelectedValue;
        try
        {
            cn.Open();
            MySqlCommand cmd = new MySqlCommand(@"select case @lang when 1 then districtEn when 2 then districtTc when 3 then districtSc end as district, districtID 
                                            from district where areaID = @areaID", cn);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add("@areaID", MySqlDbType.Int32).Value = Convert.ToInt32(ddl.SelectedValue);
            cmd.Parameters.Add("@lang", MySqlDbType.Int32).Value = Agency_Kernel.GetLanguageID();
            DataSet ds = new DataSet();
            MySqlDataAdapter ad = new MySqlDataAdapter(cmd);
            ad.Fill(ds);
            districtDDL.DataSource = ds;
            districtDDL.DataBind();
            ListItem li = new ListItem();
            li.Attributes.Add("selected", "true");
            li.Attributes.Add("disabled", "true");
            li.Attributes.Add("hidden", "true");
            li.Text = (string)GetLocalResourceObject("selectDistrict.Text");
            li.Value = "0";
            districtDDL.Items.Insert(0, li);
        }
        catch (Exception ex)
        { }
        finally
        {
            cn.Close();
        }
    }

    protected void saveBtn_Click(object sender, EventArgs e)
    {

    }
}