using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using HouseDreaming;
using System.IO;
using Microsoft.VisualBasic;
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

        if (!IsPostBack)
        {
            if (Request.QueryString["listingID"] != null)
            {
                LoadData(Convert.ToInt32(Request.QueryString["listingID"]));
            }
            else
            {
                Response.Redirect(CommonFunc.GetAgencyDomain() + "viewlisting/");
            }
        }

        if (IsPostBack)
        {

            foreach (RepeaterItem ri in availablePhotoRepeater.Items)
            {
                FileUpload fu = ri.FindControl("fileUpload") as FileUpload;
                HiddenField index = ri.FindControl("index") as HiddenField;
                testMsg.Text = fu.HasFile.ToString() + "aaa";
                //if (fu.HasFile)
                //{
                //    UploadPhoto(fu, Convert.ToInt32(index.Value), Convert.ToInt32(listID.Value));
                //}
            }
        }
    }

    public void LoadData(int listingID)
    {
        try
        {
            listID.Value = listingID.ToString();
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
                areaID.Value = dr["areaID"].ToString();
                districtID.Value = dr["districtID"].ToString();
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

                for (int i = 0; i < photoRepeater.Items.Count; i++)
                {
                    Button approveBtn = photoRepeater.Items[i].FindControl("delPhotoButton") as Button;
                    AsyncPostBackTrigger trigger = new AsyncPostBackTrigger();
                    trigger.ControlID = approveBtn.UniqueID;
                    trigger.EventName = "Click";
                    wallPanel.Triggers.Add(trigger);
                }

                availableImageCount = 7 - ds.Tables[1].Rows.Count;
                if (availableImageCount < 0)
                {
                    availableImageCount = 0;
                }
                else
                {
                    List<availablePhoto> availablePhotoList = new List<availablePhoto>();
                    int displayOrder = ds.Tables[1].Rows.Count + 1;
                    for (int i = 0; i < availableImageCount; i++)
                    {
                        availablePhoto ap = new availablePhoto();
                        ap.index = displayOrder;
                        availablePhotoList.Add(ap);
                        displayOrder++;
                    }
                    availablePhotoRepeater.DataSource = availablePhotoList;
                    availablePhotoRepeater.DataBind();

                    foreach(RepeaterItem avaRepeaterItem in availablePhotoRepeater.Items)
                    {
                        FileUpload fu = avaRepeaterItem.FindControl("fileUpload") as FileUpload;
                       // ScriptManager.GetCurrent(this).RegisterPostBackControl(fu);
                    }
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
        try
        {
            string keyword = CommonFunc.GetAreaName(Convert.ToInt32(areaID.Value)) + " " + CommonFunc.GetDistictName(Convert.ToInt32(districtID.Value));
            cn.Open();
            SqlCommand cmd = new SqlCommand("UpdateListing", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@listingID", SqlDbType.Int).Value = listID.Value;
            cmd.Parameters.Add("@titleEn", SqlDbType.VarChar).Value = titleEn.Text;
            cmd.Parameters.Add("@titleTc", SqlDbType.NVarChar).Value = titleTc.Text;
            cmd.Parameters.Add("@titleSc", SqlDbType.NVarChar).Value = Microsoft.VisualBasic.Strings.StrConv(titleTc.Text, VbStrConv.SimplifiedChinese, 2052);
            cmd.Parameters.Add("@subTitleEn", SqlDbType.VarChar).Value = subTitleEn.Text;
            cmd.Parameters.Add("@subTitleTc", SqlDbType.NVarChar).Value = subTitleTc.Text;
            cmd.Parameters.Add("@subTitleSc", SqlDbType.NVarChar).Value = Microsoft.VisualBasic.Strings.StrConv(subTitleTc.Text, VbStrConv.SimplifiedChinese, 2052);
            cmd.Parameters.Add("@room", SqlDbType.Int).Value = Convert.ToInt32(roomDDL.SelectedValue);
            cmd.Parameters.Add("@bathroom", SqlDbType.Int).Value = Convert.ToInt32(bathroomDDL.SelectedValue);
            cmd.Parameters.Add("@netSize", SqlDbType.Int).Value = Convert.ToInt32(netSize.Text);
            cmd.Parameters.Add("@size", SqlDbType.Int).Value = Convert.ToInt32(size.Text);
            if (listingTypeCb.Items[0].Selected && listingTypeCb.Items[1].Selected)
            {
                cmd.Parameters.Add("@listingType", SqlDbType.Int).Value = 1;
            }
            else if (listingTypeCb.Items[0].Selected && !listingTypeCb.Items[1].Selected)
            {
                cmd.Parameters.Add("@listingType", SqlDbType.Int).Value = 1;
            }
            else if (!listingTypeCb.Items[0].Selected && listingTypeCb.Items[1].Selected)
            {
                cmd.Parameters.Add("@listingType", SqlDbType.Int).Value = 2;
            }
            cmd.Parameters.Add("@salePrice", SqlDbType.Int).Value = salePrice.Text != "" ? Convert.ToInt32(salePrice.Text) : 0;
            cmd.Parameters.Add("@rentPrice", SqlDbType.Int).Value = rentPrice.Text != "" ? Convert.ToInt32(rentPrice.Text) : 0;
            cmd.Parameters.Add("@descEn", SqlDbType.VarChar).Value = descEn.Text;
            cmd.Parameters.Add("@descTc", SqlDbType.NVarChar).Value = descTc.Text;
            cmd.Parameters.Add("@descSc", SqlDbType.NVarChar).Value = Microsoft.VisualBasic.Strings.StrConv(descTc.Text, VbStrConv.SimplifiedChinese, 2052);
            cmd.Parameters.Add("@youTubeID", SqlDbType.VarChar).Value = youtubeID.Text;
            cmd.Parameters.Add("@keyword", SqlDbType.NVarChar).Value = keyword + titleEn.Text + " " + titleTc.Text + " " + Microsoft.VisualBasic.Strings.StrConv(titleTc.Text, VbStrConv.SimplifiedChinese, 2052);
            cmd.ExecuteNonQuery();
        }
        catch (Exception ex)
        {
            testMsg.Text = ex.Message;
        }
        finally
        {
            cn.Close();
        }

        foreach (RepeaterItem ri in availablePhotoRepeater.Items)
        {
            //FileUpload fu = ri.FindControl("fileUpload") as FileUpload;
            //HiddenField index = ri.FindControl("index") as HiddenField;
            //testMsg.Text = fu.HasFile.ToString();
            //if (fu.HasFile)
            //{
            //    UploadPhoto(fu, Convert.ToInt32(index.Value), Convert.ToInt32(listID.Value));
            //}
        }

        //LoadData(Convert.ToInt32(listID.Value));
        //wallPanel.Update();
    }

    public void UploadPhoto(FileUpload imagesUploader, int displayOrder, int listingID)
    {
        if (imagesUploader.HasFile)
        {
            HttpPostedFile userPostedFile = imagesUploader.PostedFile;
            try
            {
                string fileName = userPostedFile.FileName;
                string fileExt = fileName.Substring(fileName.LastIndexOf(".") + 1, fileName.Length - (fileName.LastIndexOf(".") + 1));
                if (userPostedFile.ContentLength > 0 && userPostedFile.ContentLength < 4096000 && (fileExt.ToLower() == "png" || fileExt.ToLower() == "jpeg" || fileExt.ToLower() == "jpg"))
                {
                    bool uploadSuccess = CommonFunc.UploadLocal(Server.MapPath("../images/client-temp/" + Session["agencyID"]), fileName, userPostedFile);
                    if (uploadSuccess)
                    {
                        int photoID = GetPhoto(listingID, displayOrder, cn);
                        string newFileName = "../images/listing-images/" + Session["agencyID"] + "/" + listingID + "/" + photoID + "." + fileExt;
                        bool successMove = CommonFunc.MoveLocalImage(Server.MapPath("../images/client-temp/" + Session["agencyID"]) + "/" + fileName, Server.MapPath(newFileName), Server.MapPath("../images/listing-images/" + Session["agencyID"] + "/" + listingID));
                        if (successMove)
                        {
                            UpdatePhotoPath(photoID, "listing-images/" + Session["agencyID"] + "/" + listingID + "/" + photoID + "." + fileExt, cn);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                testMsg.Text = ex.Message;
            }
        }
    }

    private void UpdatePhotoPath(int photoID, string path, SqlConnection cn)
    {
        if (!string.IsNullOrEmpty(path))
        {
            SqlCommand cmd = new SqlCommand("UpdateListingPhotoPath", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@photoPath", SqlDbType.VarChar).Value = path;
            cmd.Parameters.Add("@photoID", SqlDbType.Int).Value = photoID;
            cmd.ExecuteNonQuery();
        }
    }


    private int GetPhoto(int listingID, int displayOrder, SqlConnection cn)
    {
        int photoID = 0;
        if (listingID > 0)
        {
            SqlCommand cmd = new SqlCommand(@"InsertListingPhoto", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@listingID", SqlDbType.Int).Value = listingID;
            cmd.Parameters.Add("@displayOrder", SqlDbType.Int).Value = displayOrder;
            photoID = Convert.ToInt32(cmd.ExecuteScalar());
        }
        return photoID;
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
        Button btn = sender as Button;
        RepeaterItem ri = btn.NamingContainer as RepeaterItem;
        HiddenField photoID = ri.FindControl("photoID") as HiddenField;
        HiddenField photoPath = ri.FindControl("photoPath") as HiddenField;
        if (File.Exists(Server.MapPath("/images/" + photoPath.Value)))
        {
            File.Delete(Server.MapPath("/images/" + photoPath.Value));
        }
        try
        {
                
            cn.Open();
            SqlCommand cmd = new SqlCommand("DeletePhoto", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@photoID", SqlDbType.Int).Value = Convert.ToInt32(photoID.Value);
            cmd.ExecuteNonQuery();
        }
        catch (Exception ex)
        {
            testMsg.Text = ex.Source;
        }
        finally
        {
            cn.Close();
        }
      
        LoadData(Convert.ToInt32(Request.QueryString["listingID"]));
        wallPanel.Update();
    }
}