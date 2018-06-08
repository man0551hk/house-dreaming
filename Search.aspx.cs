using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HouseDreaming;

using System.Data;
using System.Data.Odbc;
using System.Data.SqlClient;
using System.Text;

public partial class Search : Page_Control
{
    SqlConnection cn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["sq_housedreaming"].ConnectionString);
    public int page = 1;
    protected void Page_Load(object sender, EventArgs e)
    {
        topPrevLink.Attributes.Add("aria-label", "Previous");
        topPrevLink.Text = "<span aria-hidden=\"true\">&laquo;</span><span class=\"sr-only\">Previous</span>";
        if (!IsPostBack)
        {
            LoadDistrict();
            SearchListing("", "", "", "", "", "", "", 1);
        }
    }

    private void LoadDistrict()
    {
        try
        {
            cn.Open();
            SqlCommand cmd = new SqlCommand("GetDistrictByLang", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@lang", SqlDbType.Int).Value = CommonFunc.GetLanguageID();
            DataSet ds = new DataSet();
            SqlDataAdapter ad = new SqlDataAdapter(cmd);
            ad.Fill(ds);
            districtDDL.DataSource = ds;
            districtDDL.DataBind();
            //districtDDL.DataTextField = "district";
            //districtDDL.DataValueField = "district";

            districtDDL.Items.Insert(0, new ListItem((string)GetLocalResourceObject("lbAny.Text"), "0"));
        }
        catch (Exception ex)
        {
            Response.Write(ex.Message);
        }
        finally
        {
            cn.Close();
        }
    }

    protected void searchBtn_Click(object sender, EventArgs e)
    {
        Search();
    }

    public void Search()
    {
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

    public string prevLink = "";
    public string nextLink = "";
    public string originLink = "";
    private void SearchListing(string keyword, string districtID, string room, string netsize, string listingType, string saleprice, string rentprice, int page)
    {
        //testMsg.Text = keyword + " " + districtID + " " + room + " " + netsize + " " + listingType + " " + saleprice + " " + rentprice;
        testMsg.Text = page.ToString();
        try
        {
            cn.Open();
            SqlCommand cmd = new SqlCommand("SearchListing", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@lang", SqlDbType.Int).Value = CommonFunc.GetLanguageID();
            cmd.Parameters.Add("@page", SqlDbType.Int).Value = page;
            cmd.Parameters.Add("@pageSize", SqlDbType.Int).Value = 20; // default size
            DataSet ds = new DataSet();
            SqlDataAdapter ad = new SqlDataAdapter(cmd);
            ad.Fill(ds);
            listingRepeater.DataSource = ds;
            listingRepeater.DataBind();

            if (ds.Tables[1] != null)
            {
                int totalListing = Convert.ToInt32(ds.Tables[1].Rows[0]["total"]);
                int totalPage = totalListing / 20;
                if (totalListing % 20 != 0)
                {
                    totalPage += 1;
                }

                List<int> pageList = new List<int>();
                for (int i = 1; i <= totalPage; i++)
                {
                    pageList.Add(i);
                }
                
                if (page > 1)
                { 

                }
            }
        }
        catch (Exception ex)
        {
            testMsg.Text = ex.Source;
        }
        finally
        {
            cn.Close();
        }
    }

    public string ConstructLayout(int classID, int listingID, string district, string title, string size, string netSize, string salePrice, string rentPrice, string companyName, string photoPath )
    {
        StringBuilder sb = new StringBuilder();
        sb.AppendLine("<div class = 'row'>");
            sb.AppendLine("<div class = 'col-md-12'>");
            if (classID == 3)
            { 
                sb.AppendLine("<div class = 'box' style ='width:100%'>");
                sb.AppendLine("<div style = 'width:100%; padding:5px 5px 5px 5px;'>");
                sb.AppendLine("<b>" +companyName + "</b>");
                sb.AppendLine("</div>");
                sb.AppendLine("<div style ='width:100%;'>");
                if (!string.IsNullOrEmpty(photoPath))
                {
                    sb.AppendLine("<img src= '" + CommonFunc.ImageUrl() + photoPath + "' style ='width:100%'>");
                }
                else
                {
                    sb.AppendLine("<img src= '" + CommonFunc.ImageUrl() + "NoImage.jpg" + "' style ='width:100%'>");
                }
                sb.AppendLine("</div>");
                sb.AppendLine("<div style =\"width:100%; padding:5px 5px 5px 5px;\">");
                sb.AppendLine(title);
                sb.AppendLine("<br />");
                sb.AppendLine("<div style = \"font-size:80%\">");
                if(!string.IsNullOrEmpty(salePrice))
                {
                    sb.AppendLine((string)GetLocalResourceObject("lbSalePrice.Text") + " $" + salePrice + " <br />");
                }
                if (!string.IsNullOrEmpty(salePrice))
                {
                    sb.AppendLine((string)GetLocalResourceObject("lbRentPrice.Text") + " $" + rentPrice + " <br />");
                }   
                if(!string.IsNullOrEmpty(size))
                {
                    sb.AppendLine((string)GetLocalResourceObject("lbSize.Text") + " " + size + " " + (string)GetLocalResourceObject("lbUnit.Text") + "<br />");
                }
                if (!string.IsNullOrEmpty(netSize))
                {
                    sb.AppendLine((string)GetLocalResourceObject("lbNetsize.Text") + " " + netSize + " " + (string)GetLocalResourceObject("lbUnit.Text") + "<br />");
                }
                sb.AppendLine("</div>");
                sb.AppendLine("</div>");
                sb.AppendLine("</div>");
            }
            else
            {
                sb.AppendLine("<div class =\"row onlyShadow\">");
                sb.AppendLine("<div class=\"col-md-5 noPadding\">");

                if (!string.IsNullOrEmpty(photoPath))
                {
                    sb.AppendLine("<img src= '" + CommonFunc.ImageUrl() + photoPath + "' style ='width:100%'>");
                }
                else
                {
                    sb.AppendLine("<img src= '" + CommonFunc.ImageUrl() + "NoImage.jpg" + "' style ='width:100%'>");
                }
                sb.AppendLine("</div>");
                sb.AppendLine("<div class=\"col-md-7\" style = 'padding-top:5px;'>");
                sb.AppendLine("<b>" +companyName + "</b>");
                sb.AppendLine("<br />");
                sb.AppendLine(title);
                sb.AppendLine("<br />");
                sb.AppendLine("<div style = \"font-size:80%\">");
                if(!string.IsNullOrEmpty(salePrice))
                {
                    sb.AppendLine((string)GetLocalResourceObject("lbSalePrice.Text") + " $" + salePrice + " <br />");
                }
                if (!string.IsNullOrEmpty(salePrice))
                {
                    sb.AppendLine((string)GetLocalResourceObject("lbRentPrice.Text") + " $" + rentPrice + " <br />");
                }   
                if(!string.IsNullOrEmpty(size))
                {
                    sb.AppendLine((string)GetLocalResourceObject("lbSize.Text") + " " + size + " " + (string)GetLocalResourceObject("lbUnit.Text") + "<br />");
                }
                if (!string.IsNullOrEmpty(netSize))
                {
                    sb.AppendLine((string)GetLocalResourceObject("lbNetsize.Text") + " " + netSize + " " + (string)GetLocalResourceObject("lbUnit.Text") + "<br />");
                }
                sb.AppendLine("</div>");
                sb.AppendLine("</div>");
                sb.AppendLine("</div>");
            }
            sb.AppendLine("<br/>");
            sb.AppendLine("</div>");
        sb.AppendLine("</div>");
        return sb.ToString();
    }

    protected void topPrevLink_Click(object sender, EventArgs e)
    {
        //testMsg.Text = "aaa";
        page = page - 1;
        Search();
    }
}