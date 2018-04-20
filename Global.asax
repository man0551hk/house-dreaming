<%@ Application Language="C#" %>

<script runat="server">

    void Application_Start(object sender, EventArgs e) 
    {
        // Code that runs on application startup

    }
    
    void Application_End(object sender, EventArgs e) 
    {
        //  Code that runs on application shutdown

    }
        
    void Application_Error(object sender, EventArgs e) 
    { 
        // Code that runs when an unhandled error occurs

    }

    void Session_Start(object sender, EventArgs e) 
    {
        // Code that runs when a new session is started
        #region check if agency logined
        HttpCookie agencyCookie = HttpContext.Current.Request.Cookies["House_Dreaming_Agency"];
        if (agencyCookie != null)
        {
            if (HttpContext.Current.Request.Cookies["House_Dreaming_Agency"] != null)
            {
                if (HttpContext.Current.Request.Cookies["House_Dreaming_Agency"]["agencyID"] != null &&
                   HttpContext.Current.Request.Cookies["House_Dreaming_Agency"]["accesskey"] != null  )
                {
                    string agencyID = HttpContext.Current.Request.Cookies["House_Dreaming_Agency"]["agencyID"].ToString();
                    string accesskey = HttpContext.Current.Request.Cookies["House_Dreaming_Agency"]["accesskey"].ToString();
                    int loginAgencyID = CommonFunc.AgencyLoginByAccessKey(Convert.ToInt32(agencyID), accesskey);
                    if (loginAgencyID > 0)
                    {
                        Session["agencyID"] = loginAgencyID;
                    }
                }
            }
        }
        #endregion
        //check if user logined
    }

    void Session_End(object sender, EventArgs e) 
    {
        // Code that runs when a session ends. 
        // Note: The Session_End event is raised only when the sessionstate mode
        // is set to InProc in the Web.config file. If session mode is set to StateServer 
        // or SQLServer, the event is not raised.

    }
       
</script>
