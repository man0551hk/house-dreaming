using HouseDreaming;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class agency_Logout : Agency_Page_Control
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Session.Clear();
        Agency_Kernel.Logout();
        Response.Redirect(CommonFunc.GetAgencyDomain() + "Login/");
    }
}