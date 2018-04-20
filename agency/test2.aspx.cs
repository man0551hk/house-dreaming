﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class agency_test2 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        HttpCookie agencyCookie = HttpContext.Current.Request.Cookies["House_Dreaming_Agency"];
        if (agencyCookie != null)
        {
            if (HttpContext.Current.Request.Cookies["House_Dreaming_Agency"] != null)
            {
                Response.Write(HttpContext.Current.Request.Cookies["House_Dreaming_Agency"]["agencyID"].ToString());
                Response.Write(HttpContext.Current.Request.Cookies["House_Dreaming_Agency"]["accesskey"].ToString());



                if (HttpContext.Current.Request.Cookies["House_Dreaming_Agency"]["agencyID"] != null &&
                   HttpContext.Current.Request.Cookies["House_Dreaming_Agency"]["accesskey"] != null)
                {
                    string agencyID = HttpContext.Current.Request.Cookies["House_Dreaming_Agency"]["agencyID"].ToString();
                    string accesskey = HttpContext.Current.Request.Cookies["House_Dreaming_Agency"]["accesskey"].ToString();
                    int loginAgencyID = CommonFunc.AgencyLoginByAccessKey(Convert.ToInt32(agencyID), accesskey);
                    if (loginAgencyID > 0)
                    {
                        Session["agencyID"] = loginAgencyID;
                    }
                    Response.Write("<br/>" + loginAgencyID.ToString());
                }
            }
        }
    }
}