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
using Amazon.S3;
using Amazon.S3.Model;

public partial class agency_NewListing : Agency_Page_Control
{
    OdbcConnection cn = new OdbcConnection(System.Configuration.ConfigurationManager.ConnectionStrings["sq_housedreaming"].ConnectionString);

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
            Session["tempPhotoList"] = null;
            districtDDL.Items.Insert(0, new ListItem((string)GetLocalResourceObject("selectDistrict.Text"), ""));
        }

        if (IsPostBack && imagesUploader.PostedFile != null)
        {
            uploadTemp();
            ShowCurrentTemp();
        }
    }

    private void LoadArea()
    {
        try
        {
            cn.Open();
            OdbcCommand cmd = new OdbcCommand("select case @lang when 1 then areaEn when 2 then areaTc when 3 then areaSc end as area, areaID from area", cn);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add("@lang", OdbcType.Int).Value = Agency_Kernel.GetLanguageID();
            DataSet ds = new DataSet();
            OdbcDataAdapter ad = new OdbcDataAdapter(cmd);
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
            OdbcCommand cmd = new OdbcCommand(@"select case @lang when 1 then districtEn when 2 then districtTc when 3 then districtSc end as district, districtID 
                                            from district where areaID = @areaID", cn);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add("@areaID", OdbcType.Int).Value = Convert.ToInt32(ddl.SelectedValue);
            cmd.Parameters.Add("@lang", OdbcType.Int).Value = Agency_Kernel.GetLanguageID();
            DataSet ds = new DataSet();
            OdbcDataAdapter ad = new OdbcDataAdapter(cmd);
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
        bool success = true;
        string keyword = CommonFunc.GetAreaName(Convert.ToInt32(areaDDL.SelectedValue)) + " " + CommonFunc.GetDistictName(Convert.ToInt32(districtDDL.SelectedValue));
        try
        {
            cn.Open();
            OdbcCommand cmd = new OdbcCommand(@"insert into listing (districtID, areaID, buildingID, titleEn, titleTc, titleSc,
                                                subTitleEn, subTitleTc, subTitleSc,
                                                modifiedDate, publishedDate, createdDate, expiryDate, 
                                                room, bathroom, netSize, size, listingType,
                                                salePrice, rentPrice, descEn, descTc, descSc, agencyID, agencyCompanyID, youTubeID, keyword)
                                                values 
                                                (@districtID, @areaID, @buildingID, @titleEN, @titleTc, @titleSc,
                                                @subTitleEn, @subTitleTc, @subTitleSc,
                                                 NOW(), null, NOW(), null, @room, @bathroom, @netSize, @size, @listingType, @salePrice, @rentPrice,
                                                @descEn, @descTc, @descSc, @agencyID, @agencyCompanyID, @youTubeID, @keyword)", cn);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add("@districtID", OdbcType.Int).Value = Convert.ToInt32(districtDDL.SelectedValue);
            cmd.Parameters.Add("@areaID", OdbcType.Int).Value = Convert.ToInt32(areaDDL.SelectedValue);
            cmd.Parameters.Add("@buildingID", OdbcType.Int).Value = 0;
            cmd.Parameters.Add("@titleEn", OdbcType.VarChar).Value = titleEn.Text;
            cmd.Parameters.Add("@titleTc", OdbcType.VarChar).Value = titleTc.Text;
            cmd.Parameters.Add("@titleSc", OdbcType.VarChar).Value = Microsoft.VisualBasic.Strings.StrConv(titleTc.Text, VbStrConv.SimplifiedChinese, 2052);
            cmd.Parameters.Add("@subTitleEn", OdbcType.VarChar).Value = subTitleEn.Text;
            cmd.Parameters.Add("@subTitleTc", OdbcType.VarChar).Value = subTitleTc.Text;
            cmd.Parameters.Add("@subTitleSc", OdbcType.VarChar).Value = Microsoft.VisualBasic.Strings.StrConv(subTitleTc.Text, VbStrConv.SimplifiedChinese, 2052);
            cmd.Parameters.Add("@room", OdbcType.Int).Value = Convert.ToInt32(roomDDL.SelectedValue);
            cmd.Parameters.Add("@bathroom", OdbcType.Int).Value = Convert.ToInt32(bathroomDDL.SelectedValue);
            cmd.Parameters.Add("@netSize", OdbcType.Int).Value = Convert.ToInt32(netSize.Text);
            cmd.Parameters.Add("@size", OdbcType.Int).Value = Convert.ToInt32(size.Text);
            if (listingTypeCb.Items[0].Selected && listingTypeCb.Items[1].Selected)
            {
                cmd.Parameters.Add("@listingType", OdbcType.Int).Value = 1;
            }
            else if (listingTypeCb.Items[0].Selected && !listingTypeCb.Items[1].Selected)
            {
                cmd.Parameters.Add("@listingType", OdbcType.Int).Value = 1;
            }
            else if (!listingTypeCb.Items[0].Selected && listingTypeCb.Items[1].Selected)
            {
                cmd.Parameters.Add("@listingType", OdbcType.Int).Value = 2;
            }
            cmd.Parameters.Add("@salePrice", OdbcType.Int).Value = salePrice.Text != "" ? Convert.ToInt32(salePrice.Text) : 0;
            cmd.Parameters.Add("@rentPrice", OdbcType.Int).Value = rentPrice.Text != "" ? Convert.ToInt32(rentPrice.Text) : 0;
            cmd.Parameters.Add("@descEn", OdbcType.VarChar).Value = descEn.Text;
            cmd.Parameters.Add("@descTc", OdbcType.VarChar).Value = descTc.Text;
            cmd.Parameters.Add("@descSc", OdbcType.VarChar).Value = Microsoft.VisualBasic.Strings.StrConv(descTc.Text, VbStrConv.SimplifiedChinese, 2052);
            cmd.Parameters.Add("@agencyID", OdbcType.Int).Value = Convert.ToInt32(Session["agencyID"]);
            cmd.Parameters.Add("@agencyCompanyID", OdbcType.Int).Value = 0;
            cmd.Parameters.Add("@youTubeID", OdbcType.VarChar).Value = youtubeID.Text;
            cmd.Parameters.Add("@keyword", OdbcType.VarChar).Value = keyword + titleEn.Text + " " + titleTc.Text + " " + Microsoft.VisualBasic.Strings.StrConv(titleTc.Text, VbStrConv.SimplifiedChinese, 2052);
            cmd.ExecuteNonQuery();
            int listingID = Convert.ToInt32(cmd.LastInsertedId);

            if (Session["tempPhotoList"] != null)
            {
                List<string> tempPhotoList = (List<string>)Session["tempPhotoList"];
                for (int i = 0; i < tempPhotoList.Count; i++)
                {
                    int photoID = GetPhoto(listingID, (i + 1), cn);
                    string tempName = tempPhotoList[i].Replace("client_temp/" + Session["agencyID"] + "/", "");
                    string ext = tempName.Substring(tempName.LastIndexOf(".") + 1, tempName.Length - (tempName.LastIndexOf(".") + 1));
                    string newFileName = "listingPhoto/" + Session["agencyID"] + "/" + photoID + "." + ext;
                    CommonFunc.MoveImageS3(tempPhotoList[i], newFileName);
                    CommonFunc.DeleteImageS3(tempPhotoList[i]);
                    UpdatePhotoPath(photoID, newFileName, cn);
                }
            }

        }
        catch (Exception ex)
        {
            success = false;
        }
        finally
        {
            cn.Close();
        }

        if (success)
        {
            Response.Redirect("PendingListing.aspx");
        }
    }

    private int GetPhoto(int listingID, int displayOrder, OdbcConnection cn)
    {
        int photoID = 0;
        OdbcCommand cmd = new OdbcCommand(@"insert into listingPhoto (listingID, photoPath, displayOrder)
                                            values 
                                            (@listingID, '', @displayOrder)", cn);
        cmd.CommandType = CommandType.Text;
        cmd.Parameters.Add("@listingID", OdbcType.Int).Value = listingID;
        cmd.Parameters.Add("@displayOrder", OdbcType.Int).Value = displayOrder;
        cmd.ExecuteNonQuery();
        photoID = Convert.ToInt32(cmd.LastInsertedId);
        return photoID;
    }

    private void UpdatePhotoPath(int photoID, string path, OdbcConnection cn)
    {
        OdbcCommand cmd = new OdbcCommand("update listingPhoto set photoPath = @photoPath where photoID= @photoID", cn);
        cmd.CommandType = CommandType.Text;
        cmd.Parameters.Add("@photoPath", OdbcType.VarChar).Value = path;
        cmd.Parameters.Add("@photoID", OdbcType.Int).Value = photoID;
        cmd.ExecuteNonQuery();
    }

    public void uploadTemp()
    {
        if (imagesUploader.HasFile)
        {
            //client = new AmazonS3Client(Amazon.RegionEndpoint.APSoutheast1);

            HttpFileCollection uploadedFiles = Request.Files;
            
            for (int i = 0; i < uploadedFiles.Count; i++)
            {
                HttpPostedFile userPostedFile = uploadedFiles[i];
                try
                {
                    string fileName = userPostedFile.FileName;
                    string fileExt = fileName.Substring(fileName.LastIndexOf(".") + 1, fileName.Length - (fileName.LastIndexOf(".") + 1));
                    if (userPostedFile.ContentLength > 0 && userPostedFile.ContentLength < 4096000 && (fileExt.ToLower() == "png" || fileExt.ToLower() == "jpeg" || fileExt.ToLower() == "jpg"))
                    {
                        byte[] fileData = null;
                        Stream fileStream = null;
                        int length = 0;

                        length = userPostedFile.ContentLength;
                        fileData = new byte[length + 1];
                        fileStream = userPostedFile.InputStream;
                        fileStream.Read(fileData, 0, length);
                        MemoryStream stream = new MemoryStream(fileData);

                        CommonFunc.UploadImageS3("client_temp/" + Session["agencyID"] + "/" + fileName, stream);

                        List<string> tempPhotoList = new List<string>();
                        if (Session["tempPhotoList"] != null)
                        {
                            tempPhotoList = (List<string>)Session["tempPhotoList"];
                        }
                        tempPhotoList.Add("client_temp/" + Session["agencyID"] + "/" + fileName);
                        Session["tempPhotoList"] = tempPhotoList;
                    }
                }
                catch (Exception ex)
                {

                }
            }
        }
    }

    public void ShowCurrentTemp()
    { 
        if(Session["tempPhotoList"] != null)
        {
            tempPhotoRepeater.DataSource = (List<string>)Session["tempPhotoList"];
            tempPhotoRepeater.DataBind();
        }
       
    }
}