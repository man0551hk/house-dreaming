using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HouseDreaming;
using System.Configuration;


public partial class agency_Default : Agency_Page_Control
{
    protected void Page_Load(object sender, EventArgs e)
    {

        HttpCookie cookie1 = HttpContext.Current.Request.Cookies["House_Dreaming_Agency_ID"];
        try
        {
            if (cookie1 == null)
            {
                HttpCookie objCookie = new HttpCookie("House_Dreaming_Agency_ID");
                objCookie.Value = "1";
                objCookie.Expires = DateTime.Now.AddDays(30);
                objCookie.Domain = ConfigurationManager.AppSettings["AgencyDomain"].ToString();
                HttpContext.Current.Response.Cookies.Add(objCookie);
            }
            else
            {
                cookie1.Value = "1";
                cookie1.Domain = ConfigurationManager.AppSettings["AgencyDomain"].ToString();
                HttpContext.Current.Response.Cookies.Add(cookie1);
            }
        }
        catch (Exception ex)
        {
           Response.Write(ex.Message);
        }

    }
}