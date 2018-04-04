using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HouseDreaming;
using MySql.Data.MySqlClient;
using System.Data;

public partial class agency_PendingListing : Agency_Page_Control
{
    OdbcConnection cn = new OdbcConnection(System.Configuration.ConfigurationManager.ConnectionStrings["sq_housedreaming"].ConnectionString);

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            LoadPendingListing();
        }
    }

    public class PendingListing
    { 
        
    }

    private void LoadPendingListing()
    {
        try
        {
            cn.Open();
            OdbcCommand cmd = new OdbcCommand(@"select listingID, titleEn, titleTc, subTitleEn, subTitleTc, room, 
                                                bathroom, size, netSize, 
                                                 listingType,
                                                salePrice, rentPrice,
                                                case when @lang = 1 then D.districtEn when @lang = 2 then D.districtTc when @lang = 3 then D.districtSc end as district
                                                from listing L
                                                inner join district D on L.districtID = D.districtID
                                                where agencyID = @agencyID", cn);
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.Parameters.Add("@lang", OdbcType.Int).Value = Agency_Kernel.GetLanguageID();
            cmd.Parameters.Add("@agencyID", OdbcType.Int).Value = Convert.ToInt32(Session["agencyID"]);
            DataSet ds = new DataSet();
            OdbcDataAdapter ad = new OdbcDataAdapter(cmd);
            ad.Fill(ds);
            pendingListRepeater.DataSource = ds;
            pendingListRepeater.DataBind();
        }
        catch (Exception ex)
        { }
        finally
        {
            cn.Close();
        }
    }
}