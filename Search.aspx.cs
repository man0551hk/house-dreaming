using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HouseDreaming;
using MySql.Data.MySqlClient;
using System.Data;
using System.Data.Odbc;

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

        string keyword = keywordText.Text;
        string districtID = districtDDL.SelectedValue == "0" ? "" : districtDDL.SelectedValue;
        string room = roomDDL.SelectedValue == "0" ? "" : roomDDL.SelectedValue;
        string netsize = "";
        switch (netsizeDDL.SelectedValue)
        {
            case "1": netsize = "between 0 and 200";
                break;
            case "2": netsize = "between 200 and 400";
                break;
            case "3": netsize = "between 400 and 600";
                break;
            case "4": netsize = "between 600 and 800";
                break;
            case "5": netsize = "between 800 and 1000";
                break;
            case "6": netsize = ">= 1000";
                break;  
        }
        string listingType = listingTypeDDL.SelectedValue == "3" ? "" : listingTypeDDL.SelectedValue;
        string saleprice = "";
        switch (salepriceDDL.SelectedValue)
        {
            case "1": saleprice = "between 0 and 2000000";
                break;
            case "2": saleprice = "between 2000000 and 4000000";
                break;
            case "3": saleprice = "between 4000000 and 6000000";
                break;
            case "4": saleprice = "between 6000000 and 8000000";
                break;
            case "5": saleprice = "between 8000000 and 10000000";
                break;
            case "6": netsize = ">= 100000009";
                break;
        }
        string rentprice = "";
        switch (rentPriceDDL.SelectedValue)
        {
            case "1": rentprice = "between 0 and 10000";
                break;
            case "2": rentprice = "between 10000 and 20000";
                break;
            case "3": rentprice = "between 20000 and 30000";
                break;
            case "4": rentprice = ">= 30000";
                break;
        }
        SearchListing(keyword, districtID, room, netsize, listingType, saleprice, rentprice, 1);
    }

    private void SearchListing(string keyword, string districtID, string room, string netsize, string listingType, string saleprice, string rentprice, int page)
    {
        testMsg.Text = keyword + " " + districtID + " " + room + " " + netsize + " " + listingType + " " + saleprice + " " + rentprice;
        try
        {
            cn.Open();
            string sql = @"select case @lang when 1 then titleEn when 2 then titleTc when 3 then titleSc end as title, 
                     case @lang when 1 then districtEn when 2 then districtTc when 3 then districtSc end as district, 
                     case @lang when 1 then areaEn when 2 then areaTc when 3 then areaSc end as area, 
                            ";
        }
        catch (Exception ex)
        { }
        finally
        {
            cn.Close();
        }
    }
}