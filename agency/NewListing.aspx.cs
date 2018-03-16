using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HouseDreaming;
using MySql.Data.MySqlClient;
using System.Data;
using Microsoft.VisualBasic;
using System.IO;

public partial class agency_NewListing : Agency_Page_Control
{
    MySqlConnection cn = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["sq_housedreaming"].ConnectionString);

    protected void Page_Load(object sender, EventArgs e)
    {
        titleEn.Attributes.Add("placeholder", (string)GetLocalResourceObject("buildingNameEn.Text"));
        titleTc.Attributes.Add("placeholder", (string)GetLocalResourceObject("buildingNameTc.Text"));
        subTitleEn.Attributes.Add("placeholder", (string)GetLocalResourceObject("subTitleEn.Text"));
        subTitleTc.Attributes.Add("placeholder", (string)GetLocalResourceObject("subTitleTc.Text"));
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
            districtDDL.Items.Insert(0, new ListItem((string)GetLocalResourceObject("selectDistrict.Text"), ""));
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
            areaDDL.Items.Insert(0, new ListItem((string)GetLocalResourceObject("selectArea.Text"), ""));
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
            li.Value = "";
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
        string keyword = CommonFunc.GetAreaName(Convert.ToInt32(areaDDL.SelectedValue)) + " " + CommonFunc.GetDistictName(Convert.ToInt32(districtDDL.SelectedValue));
        try
        {
            cn.Open();
//            MySqlCommand cmd = new MySqlCommand(@"insert into listing (districtID, areaID, buildingID, titleEn, titleTc, titleSc,
//                                                subTitleEn, subTitleTc, subTitleSc,
//                                                modifiedDate, publishedDate, createdDate, expiryDate, 
//                                                room, bathroom, netSize, size, listingType,
//                                                salePrice, rentPrice, descEn, descTc, descSc, agencyID, agencyCompanyID, youTubeID, keyword)
//                                                values 
//                                                (@districtID, @areaID, @buildingID, @titleEN, @titleTc, @titleSc,
//                                                @subTitleEn, @subTitleTc, @subTitleSc,
//                                                 NOW(), null, NOW(), null, @room, @bathroom, @netSize, @size, @listingType, @salePrice, @rentPrice,
//                                                @descEn, @descTc, @descSc, @agencyID, @agencyCompanyID, @youTubeID, @keyword)", cn);
//            cmd.CommandType = CommandType.Text;
//            cmd.Parameters.Add("@districtID", MySqlDbType.Int32).Value = Convert.ToInt32(districtDDL.SelectedValue);
//            cmd.Parameters.Add("@areaID", MySqlDbType.Int32).Value = Convert.ToInt32(areaDDL.SelectedValue);
//            cmd.Parameters.Add("@buildingID", MySqlDbType.Int32).Value = 0;
//            cmd.Parameters.Add("@titleEn", MySqlDbType.VarChar).Value = titleEn.Text;
//            cmd.Parameters.Add("@titleTc", MySqlDbType.VarChar).Value = titleTc.Text;
//            cmd.Parameters.Add("@titleSc", MySqlDbType.VarChar).Value = Microsoft.VisualBasic.Strings.StrConv(titleTc.Text, VbStrConv.SimplifiedChinese, 2052);
//            cmd.Parameters.Add("@subTitleEn", MySqlDbType.VarChar).Value = subTitleEn.Text;
//            cmd.Parameters.Add("@subTitleTc", MySqlDbType.VarChar).Value = subTitleTc.Text;
//            cmd.Parameters.Add("@subTitleSc", MySqlDbType.VarChar).Value = Microsoft.VisualBasic.Strings.StrConv(subTitleTc.Text, VbStrConv.SimplifiedChinese, 2052);
//            cmd.Parameters.Add("@room", MySqlDbType.Int32).Value = Convert.ToInt32(roomDDL.SelectedValue);
//            cmd.Parameters.Add("@bathroom", MySqlDbType.Int32).Value = Convert.ToInt32(bathroomDDL.SelectedValue);
//            cmd.Parameters.Add("@netSize", MySqlDbType.Int32).Value = Convert.ToInt32(netSize.Text);
//            cmd.Parameters.Add("@size", MySqlDbType.Int32).Value = Convert.ToInt32(size.Text);
//            if (listingTypeCb.Items[0].Selected && listingTypeCb.Items[1].Selected)
//            {
//                cmd.Parameters.Add("@listingType", MySqlDbType.Int32).Value = 1;
//            }
//            else if (listingTypeCb.Items[0].Selected && !listingTypeCb.Items[1].Selected)
//            {
//                cmd.Parameters.Add("@listingType", MySqlDbType.Int32).Value = 1;
//            }
//            else if (!listingTypeCb.Items[0].Selected && listingTypeCb.Items[1].Selected)
//            {
//                cmd.Parameters.Add("@listingType", MySqlDbType.Int32).Value = 2;
//            }
//            cmd.Parameters.Add("@salePrice", MySqlDbType.Int32).Value = salePrice.Text != "" ? Convert.ToInt32(salePrice.Text) : 0;
//            cmd.Parameters.Add("@rentPrice", MySqlDbType.Int32).Value = rentPrice.Text != "" ? Convert.ToInt32(rentPrice.Text) : 0;
//            cmd.Parameters.Add("@descEn", MySqlDbType.VarChar).Value = descEn.Text;
//            cmd.Parameters.Add("@descTc", MySqlDbType.VarChar).Value = descTc.Text;
//            cmd.Parameters.Add("@descSc", MySqlDbType.VarChar).Value = Microsoft.VisualBasic.Strings.StrConv(descTc.Text, VbStrConv.SimplifiedChinese, 2052);
//            cmd.Parameters.Add("@agencyID", MySqlDbType.Int32).Value = Convert.ToInt32(Session["agencyID"]);
//            cmd.Parameters.Add("@agencyCompanyID", MySqlDbType.Int32).Value = 0;
//            cmd.Parameters.Add("@youTubeID", MySqlDbType.VarChar).Value = youtubeID.Text;
//            cmd.Parameters.Add("@keyword", MySqlDbType.VarChar).Value = keyword + titleEn.Text + " " + titleTc.Text + " " + Microsoft.VisualBasic.Strings.StrConv(titleTc.Text, VbStrConv.SimplifiedChinese, 2052);
//            cmd.ExecuteNonQuery();
//            int listingID = Convert.ToInt32(cmd.LastInsertedId);

            int listingID = 1;
            if (imagesUploader.HasFile)
            { 
                HttpFileCollection uploadedFiles = Request.Files;
                for (int i = 0; i < uploadedFiles.Count; i++)
                {
                    HttpPostedFile userPostedFile = uploadedFiles[i];
                    try
                    {
                        string fileName = userPostedFile.FileName;
                        string fileExt = fileName.Substring(fileName.LastIndexOf(".") + 1, fileName.Length - (fileName.LastIndexOf(".") + 1));
                        int photoID = GetPhoto(listingID, (i + 1), cn);

                        if (userPostedFile.ContentLength > 0 && userPostedFile.ContentLength < 2048000 && (fileExt.ToLower() == "png" || fileExt.ToLower() == "jpeg" || fileExt.ToLower() == "jpg"))
                        {
                            byte[] fileData = null;
                            Stream fileStream = null;
                            int length = 0;

                            length = userPostedFile.ContentLength;
                            fileData = new byte[length + 1];
                            fileStream = userPostedFile.InputStream;
                            fileStream.Read(fileData, 0, length);
                            MemoryStream stream = new MemoryStream(fileData);
                            string newFileName = photoID + "." + fileExt;
                            CommonFunc.UploadImageS3("listingPhoto/" + Session["agencyID"] + "/" + newFileName, stream);
                            UpdatePhotoPath(photoID, "listingPhoto/" + Session["agencyID"] + "/" + newFileName, cn);
                        }
                    }
                    catch (Exception ex)
                    {

                    }
                }
            }
        }
        catch (Exception ex)
        { }
        finally
        { 
        
        }
    }

    private int GetPhoto(int listingID, int displayOrder, MySqlConnection cn)
    {
        int photoID = 0;
        MySqlCommand cmd = new MySqlCommand(@"insert into listingPhoto (listingID, photoPath, doisplayOrder)
                                            values 
                                            (@listingID, '', @displayOrder)", cn);
        cmd.CommandType = CommandType.Text;
        cmd.Parameters.Add("@listingID", MySqlDbType.Int32).Value = listingID;
        cmd.Parameters.Add("@displayOrder", MySqlDbType.Int32).Value = displayOrder;
        cmd.ExecuteNonQuery();
        photoID = Convert.ToInt32(cmd.LastInsertedId);
        return photoID;
    }

    private void UpdatePhotoPath(int photoID, string path, MySqlConnection cn)
    {
        MySqlCommand cmd = new MySqlCommand("update listingPhoto set photoPath = @photoPath where photoID= @photoID", cn);
        cmd.CommandType = CommandType.Text;
        cmd.Parameters.Add("@photoPath", MySqlDbType.VarChar).Value = path;
        cmd.Parameters.Add("@photoID", MySqlDbType.Int32).Value = photoID;
        cmd.ExecuteNonQuery();
    }
}