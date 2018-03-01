using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class MasterPageControl_HeaderMenu : System.Web.UI.UserControl
{
    string currentLang = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            currentLang = CommonFunc.GetLanguage();
        }
    }

    public string GetUrl(string lang)
    {
        string url = Request.RawUrl.ToString();
        string host = Request.UserHostName;
        url = url.Replace("/en", "").Replace("/sc", "");

        if (lang == "sc")
        {
            url = "/sc" + url.Replace("/en", "").Replace("/sc", "");
        }
        else if (lang == "en")
        {
            url = "/en" + url.Replace("/sc", "").Replace("/sc", "");
        }
    
        return url;
    }

    public string GetLangPrefix()
    {
        string urlPrefix = "";
        if (currentLang == "tc")
        { }
        else if (currentLang == "sc")
        {
            urlPrefix = "/sc";
        }
        else if (currentLang == "en")
        {
            urlPrefix = "/en";
        }
        return urlPrefix;
    }
}