using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.Odbc;
using System.Data.SqlClient;
using System.Data;
public partial class admin_ListingType : System.Web.UI.Page
{
    SqlConnection cn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["sq_housedreaming"].ConnectionString);
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            LoadData();
        }
    }


    private void LoadData()
    {
        try
        {
            cn.Open();
            SqlCommand cmd = new SqlCommand("GetAllListingType", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            DataSet ds = new DataSet();
            SqlDataAdapter ad = new SqlDataAdapter(cmd);
            ad.Fill(ds);
            listingTypeRepeater.DataSource = ds;
            listingTypeRepeater.DataBind();

        }
        catch (Exception ex)
        { }
        finally
        {
            cn.Close();
        }
    }

    protected void updBtn_Click(object sender, EventArgs e)
    {
        try
        {
            cn.Open();
            if (!string.IsNullOrEmpty(newNameEn.Text) && !string.IsNullOrEmpty(newNameTc.Text) && !string.IsNullOrEmpty(newNameSc.Text) && !string.IsNullOrEmpty(newPrice.Text))
            {
                SqlCommand cmd = new SqlCommand("InsertListingType", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@nameEn", SqlDbType.VarChar).Value = newNameEn.Text;
                cmd.Parameters.Add("@nameTc", SqlDbType.NVarChar).Value = newNameTc.Text;
                cmd.Parameters.Add("@nameSc", SqlDbType.NVarChar).Value = newNameSc.Text;
                cmd.Parameters.Add("@price", SqlDbType.Int).Value = Convert.ToInt32(newPrice.Text);
                cmd.ExecuteNonQuery();
            }

            foreach (RepeaterItem ri in listingTypeRepeater.Items)
            {
                HiddenField typeID = ri.FindControl("hiddenTypeID") as HiddenField;
                TextBox nameEn = ri.FindControl("nameEn") as TextBox;
                TextBox nameTc = ri.FindControl("nameTc") as TextBox;
                TextBox nameSc = ri.FindControl("nameSc") as TextBox;
                TextBox price = ri.FindControl("price") as TextBox;
                SqlCommand cmd = new SqlCommand("UpdateListingType", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@nameEn", SqlDbType.VarChar).Value = nameEn.Text;
                cmd.Parameters.Add("@nameTc", SqlDbType.NVarChar).Value = nameTc.Text;
                cmd.Parameters.Add("@nameSc", SqlDbType.NVarChar).Value = nameSc.Text;
                cmd.Parameters.Add("@price", SqlDbType.Int).Value = Convert.ToInt32(price.Text);
                cmd.Parameters.Add("@typeID", SqlDbType.Int).Value = Convert.ToInt32(typeID.Value);
                cmd.ExecuteNonQuery();
            }

        }
        catch (Exception ex)
        { }
        finally
        {
            cn.Close();
        }
        LoadData();
        listingTypePanel.Update();
    }
}