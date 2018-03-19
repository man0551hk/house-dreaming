using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class agency_test : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        { 
        
        }
    }
    protected void btn_Click(object sender, EventArgs e)
    {
        string fileName = "";
        if (fileUploadImage.HasFile)
        {
            fileName = fileUploadImage.FileName;
            fileUploadImage.SaveAs("~/Images/" + fileName);
            img.ImageUrl = "~/Images/" + fileName;
        }
    }
    protected void btnProcessData_Click(object sender, EventArgs e)
    {
        System.Threading.Thread.Sleep(5000);
        lblMessage.Visible = true;
    }
}