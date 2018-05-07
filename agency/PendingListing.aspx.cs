using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HouseDreaming;

using System.Data;
using System.Data.SqlClient;

public partial class agency_PendingListing : Agency_Page_Control
{
    SqlConnection cn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["sq_housedreaming"].ConnectionString);
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
            SqlCommand cmd = new SqlCommand(@"GetPendingListing", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@lang", SqlDbType.Int).Value = Agency_Kernel.GetLanguageID();
            cmd.Parameters.Add("@agencyID", SqlDbType.Int).Value = Convert.ToInt32(Session["agencyID"]);
            DataSet ds = new DataSet();
            SqlDataAdapter ad = new SqlDataAdapter(cmd);
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

            try
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand("GetAllListingTypeWithLang", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@lang", SqlDbType.Int).Value = Agency_Kernel.GetLanguageID();
                DataSet ds = new DataSet();
                SqlDataAdapter ad = new SqlDataAdapter(cmd);
                ad.Fill(ds);
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    ListItem li = new ListItem();
                    string itemClass =  (string)GetLocalResourceObject("itemClass.Text");
                    itemClass = itemClass.Replace("{type}", dr["typeName"].ToString()).Replace("{price}", dr["price"].ToString());


                    li.Text = itemClass;
                    li.Value = dr["price"].ToString() + "@" + dr["typeID"].ToString();
                    classDDL.Items.Add(li);
                }
            }
            catch (Exception ex)
            {

            }
            finally
            {
                cn.Close();
            }


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
        //testMsg.Text = "B";
        CalculatePrice();
        pendingPanel.Update();
    }

    public void CalculatePrice()
    {
        try
        {
            foreach (RepeaterItem ri in pendingListRepeater.Items)
            {
                DropDownList durationDDL = ri.FindControl("durationDDL") as DropDownList;
                int days = Convert.ToInt32(durationDDL.SelectedValue);

                DropDownList classDDL = ri.FindControl("classDDL") as DropDownList;
                string classType = classDDL.SelectedValue;
                int price = Convert.ToInt32(classType.Substring(0, classType.IndexOf("@")));
                totalPrice += (days * price);
            }
            //testMsg.Text = DateTime.Now.ToString();
            totalPriceLabel.Text = totalPrice.ToString();
        }
        catch (Exception ex)
        {
            testMsg.Text = ex.Message;
        }
    
    }
    protected void checkoutBtn_Click(object sender, EventArgs e)
    {
        int thisTotalPrice = 0;
        try
        {
            foreach (RepeaterItem ri in pendingListRepeater.Items)
            {
                HiddenField listingIDHF = ri.FindControl("listingID") as HiddenField;
                int listingID = Convert.ToInt32(listingIDHF.Value);

                DropDownList durationDDL = ri.FindControl("durationDDL") as DropDownList;
                int days = Convert.ToInt32(durationDDL.SelectedValue);

                DropDownList classDDL = ri.FindControl("classDDL") as DropDownList;
                string classType = classDDL.SelectedValue;
                int price = Convert.ToInt32(classType.Substring(0, classType.IndexOf("@")));
               
                int listingType =   Convert.ToInt32(classType.Substring(classType.IndexOf("@") + 1, classType.Length - (classType.IndexOf("@") + 1)));
                thisTotalPrice += (days * price);

                SqlCommand cmd = new SqlCommand("UpdateListingDuration", cn);
                cmd.Parameters.Add("@listingType", SqlDbType.Int).Value = listingType;
                cmd.Parameters.Add("@expiryDate",  SqlDbType.DateTime).Value = DateTime.Now.AddDays(days);
                cmd.Parameters.Add("@listingID", SqlDbType.Int).Value = listingID;
                cmd.ExecuteNonQuery();
            }
        }
        catch (Exception ex)
        {

        }
        finally
        {

        }
      
    }
}