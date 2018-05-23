﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using HouseDreaming;
public partial class agency_EditListing : Agency_Page_Control
{
    SqlConnection cn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["sq_housedreaming"].ConnectionString);
    public int availableImageCount = 0;
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


        if (Request.QueryString["listingID"] != null)
        {
            LoadData(Convert.ToInt32(Request.QueryString["listingID"]));
        }
    }

    public void LoadData(int listingID)
    {
        try
        {
            cn.Open();
            SqlCommand cmd = new SqlCommand("GetListingInfoForEdit", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@listingID", SqlDbType.Int).Value = listingID;
            cmd.Parameters.Add("@lang", SqlDbType.Int).Value = Agency_Kernel.GetLanguageID();
            SqlDataAdapter ad = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            ad.Fill(ds);
            if (ds.Tables[0] != null && ds.Tables[0].Rows.Count == 1)
            {
                DataRow dr = ds.Tables[0].Rows[0];
                area.Text = dr["area"].ToString();
                district.Text = dr["district"].ToString();
                if (dr["titleEn"].ToString() != "")
                {
                    titleEn.Text = dr["titleEn"].ToString();
                }
                if (dr["titleTc"].ToString() != "")
                {
                    titleTc.Text = dr["titleTc"].ToString();
                }
                if (dr["subTitleEn"].ToString() != "")
                {
                    subTitleEn.Text = dr["subTitleEn"].ToString();
                }
                if (dr["subTitleTc"].ToString() != "")
                {
                    subTitleTc.Text = dr["subTitleTc"].ToString();
                }
                ListItem roomDDLSelected = roomDDL.Items.FindByValue(dr["room"].ToString());
                if (roomDDLSelected != null)
                {
                    roomDDLSelected.Selected = true;
                }

                ListItem bathroomDDLSelected = bathroomDDL.Items.FindByValue(dr["bathroom"].ToString());
                if (bathroomDDLSelected != null)
                {
                    bathroomDDLSelected.Selected = true;
                }

                if (dr["size"].ToString() != "0" && dr["size"].ToString() != "")
                {
                    size.Text = dr["size"].ToString();
                }
                if (dr["netSize"].ToString() != "0" && dr["netSize"].ToString() != "")
                {
                    netSize.Text = dr["netSize"].ToString();
                }

                ListItem listingTypeCbSelected = listingTypeCb.Items.FindByValue(dr["listingType"].ToString());
                if (listingTypeCbSelected != null)
                {
                    listingTypeCbSelected.Selected = true;
                }

                if (dr["salePrice"].ToString() != "0" && dr["salePrice"].ToString() != "")
                {
                    salePrice.Text = dr["salePrice"].ToString();
                }
                if (dr["rentPrice"].ToString() != "0" && dr["rentPrice"].ToString() != "")
                {
                    rentPrice.Text = dr["rentPrice"].ToString();
                }
                if (dr["youtubeID"].ToString() != "")
                {
                    youtubeID.Text = dr["youtubeID"].ToString();
                }
                if (dr["descEn"].ToString() != "")
                {
                    descEn.Text = dr["descEn"].ToString();
                }
                if (dr["descTc"].ToString() != "")
                {
                    descTc.Text = dr["descTc"].ToString();
                }
              
            }

            if (ds.Tables[1] != null)
            {
                photoRepeater.DataSource = ds.Tables[1];
                photoRepeater.DataBind();
                availableImageCount = 7 - ds.Tables[1].Rows.Count;
                if (availableImageCount < 0)
                {
                    availableImageCount = 0;
                }
                else
                {
                    List<availablePhoto> availablePhotoList = new List<availablePhoto>();
                    for (int i = 0; i < availableImageCount; i++)
                    {
                        availablePhoto ap = new availablePhoto();
                        ap.index = i + 1;
                        availablePhotoList.Add(ap);
                    }
                    availablePhotoRepeater.DataSource = availablePhotoList;
                    availablePhotoRepeater.DataBind();
                }
            }
        }
        catch (Exception ex)
        {
            testMsg.Text = ex.Message;
        }
        finally
        {
            cn.Close();
        }
    }

    public class availablePhoto
    {
        public int index { set; get; }
    }

    protected void saveBtn_Click(object sender, EventArgs e)
    {

    }

    //public void uploadTemp()
    //{
    //    if (imagesUploader.HasFile)
    //    {
    //        //client = new AmazonS3Client(Amazon.RegionEndpoint.APSoutheast1);

    //        HttpFileCollection uploadedFiles = Request.Files;

    //        for (int i = 0; i < uploadedFiles.Count; i++)
    //        {
    //            HttpPostedFile userPostedFile = uploadedFiles[i];
    //            try
    //            {
    //                string fileName = userPostedFile.FileName;
    //                string fileExt = fileName.Substring(fileName.LastIndexOf(".") + 1, fileName.Length - (fileName.LastIndexOf(".") + 1));
    //                if (userPostedFile.ContentLength > 0 && userPostedFile.ContentLength < 4096000 && (fileExt.ToLower() == "png" || fileExt.ToLower() == "jpeg" || fileExt.ToLower() == "jpg"))
    //                {
    //                    #region s3upload
    //                    //byte[] fileData = null;
    //                    //Stream fileStream = null;
    //                    //int length = 0;

    //                    //length = userPostedFile.ContentLength;
    //                    //fileData = new byte[length + 1];
    //                    //fileStream = userPostedFile.InputStream;
    //                    //fileStream.Read(fileData, 0, length);
    //                    //MemoryStream stream = new MemoryStream(fileData);

    //                    //CommonFunc.UploadImageS3("client_temp/" + Session["agencyID"] + "/" + fileName, stream);
    //                    bool uploadSuccess = CommonFunc.UploadLocal(Server.MapPath("../images/client-temp/" + Session["agencyID"]), fileName, userPostedFile);
    //                    #endregion


    //                    if (uploadSuccess)
    //                    {
    //                        List<string> tempPhotoList = new List<string>();
    //                        if (Session["tempPhotoList"] != null)
    //                        {
    //                            tempPhotoList = (List<string>)Session["tempPhotoList"];
    //                        }
    //                        tempPhotoList.Add("../images/client-temp/" + Session["agencyID"] + "/" + fileName);
    //                        Session["tempPhotoList"] = tempPhotoList;
    //                    }
    //                }
    //            }
    //            catch (Exception ex)
    //            {
    //                testMsg.Text = ex.Message;
    //            }
    //        }
    //    }
    //}

    //public void ShowCurrentTemp()
    //{
    //    if (Session["tempPhotoList"] != null)
    //    {
    //        tempPhotoRepeater.DataSource = (List<string>)Session["tempPhotoList"];
    //        tempPhotoRepeater.DataBind();
    //    }

    //}
    protected void delPhotoButton_Click(object sender, EventArgs e)
    {

    }
}