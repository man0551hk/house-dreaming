using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HouseDreaming;

public partial class agency_Login : Agency_Page_Control
{
    protected void Page_Load(object sender, EventArgs e)
    {
        email.Attributes.Add("placeholder", (string)GetLocalResourceObject("email.Text"));
        password.Attributes.Add("placeholder", (string)GetLocalResourceObject("password.Text"));
    }
}