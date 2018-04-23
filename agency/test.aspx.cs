using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class agency_test : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!Directory.Exists(Server.MapPath("../images/listing-images/1")))
            {
                Directory.CreateDirectory(Server.MapPath("../images/listing-images/1"));
            }
        }
        catch(Exception ex)
        {
            Response.Write(ex.Message);
        }
    }
}