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
    MySqlConnection cn = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["sq_housedreaming"].ConnectionString);
    int totalPrice = 0;
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
            MySqlCommand cmd = new MySqlCommand(@"select listingID, titleEn, titleTc, subTitleEn, subTitleTc, room, 
                                                bathroom, size, netSize, 
                                                 listingType,
                                                salePrice, rentPrice,
                                                case when @lang = 1 then D.districtEn when @lang = 2 then D.districtTc when @lang = 3 then D.districtSc end as district
                                                from listing L
                                                inner join district D on L.districtID = D.districtID
                                                where agencyID = @agencyID", cn);
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.Parameters.Add("@lang", MySqlDbType.Int32).Value = Agency_Kernel.GetLanguageID();
            cmd.Parameters.Add("@agencyID", MySqlDbType.Int32).Value = Convert.ToInt32(Session["agencyID"]);
            DataSet ds = new DataSet();
            MySqlDataAdapter ad = new MySqlDataAdapter(cmd);
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


        foreach (RepeaterItem ri in pendingListRepeater.Items)
        {
            DropDownList durationDDL = ri.FindControl("durationDDL") as DropDownList;
            DropDownList classDDL = ri.FindControl("classDDL") as DropDownList;
            if (durationDDL != null)
            {
                AsyncPostBackTrigger trigger1 = new AsyncPostBackTrigger();
                trigger1.ControlID = durationDDL.UniqueID;
                trigger1.EventName = "SelectedIndexChanged";
                pendingPanel.Triggers.Add(trigger1);
            }
            if (classDDL != null)
            {
                AsyncPostBackTrigger trigger2 = new AsyncPostBackTrigger();
                trigger2.ControlID = durationDDL.UniqueID;
                trigger2.EventName = "SelectedIndexChanged";
                pendingPanel.Triggers.Add(trigger2);
            }
        }
    }


    protected void durationDDL_SelectedIndexChanged(object sender, EventArgs e)
    {
        CalculatePrice();
        pendingPanel.Update();
    }

    protected void classDDL_SelectedIndexChanged(object sender, EventArgs e)
    {
        CalculatePrice();
        pendingPanel.Update();
    }

    public void CalculatePrice()
    {
        foreach (RepeaterItem ri in pendingListRepeater.Items)
        {
            DropDownList durationDDL = ri.FindControl("durationDDL") as DropDownList;
            int days = Convert.ToInt32(durationDDL.SelectedValue);

            DropDownList classDDL = ri.FindControl("classDDL") as DropDownList;
            int classType = Convert.ToInt32(classDDL.SelectedValue);

            totalPrice += (days * classType);
        }
        //testMsg.Text = DateTime.Now.ToString();
        totalPriceLabel.Text = totalPrice.ToString();
    
    }
}