using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HouseDreaming;
using MySql.Data.MySqlClient;

public partial class agency_ChangeLang : Agency_Page_Control
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString["lang"] != null)
        {
            Agency_Kernel.SaveLanguage(Request.QueryString["lang"].ToString());
            string referer = Request.Headers["Referer"].ToString();
            Response.Redirect(referer);
        }
    }
}