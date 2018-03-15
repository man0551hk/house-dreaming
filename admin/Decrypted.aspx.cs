using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class admin_Decrypted : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void convertBtn_Click(object sender, EventArgs e)
    {
        converted.Text = Crypto.DecryptStringAES(origin.Text);
    }
    protected void encryptBtn_Click(object sender, EventArgs e)
    {
        converted.Text = Crypto.EncryptStringAES(origin.Text);
    }
    protected void md5encryptBtn_Click(object sender, EventArgs e)
    {
        converted.Text = Crypto.EncryptMD5(origin.Text);
    }
    protected void md5decryptBtn_Click(object sender, EventArgs e)
    {
        converted.Text = Crypto.DecryptMD5(origin.Text);
    }
}