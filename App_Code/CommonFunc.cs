using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for CommonFunc
/// </summary>
public static class CommonFunc
{
    public static string GetLanguageCode()
    {
        return GetLanguage();
    }

    public static int GetLanguageID()
    {
        int langID = 2;
        switch (GetLanguage().ToLower())
        {
            case "en": langID = 1; break;
            case "tc": langID = 2; break;
            case "sc": langID = 3; break;
        }
        return langID;
    }

    public static string GetLanguage()
    {
        try
        {
            string _Lang = string.Empty;
            HttpCookie cookie1 = HttpContext.Current.Request.Cookies["House_Dreaming_Lang"];
            if (cookie1 != null)
            {
                if (HttpContext.Current.Request.Cookies["House_Dreaming_Lang"] != null)
                {
                    if (HttpContext.Current.Request.Cookies["House_Dreaming_Lang"] != null)
                        _Lang = HttpContext.Current.Request.Cookies["House_Dreaming_Lang"].Value.ToString();
                }
            }

            if (!string.IsNullOrEmpty(_Lang))
            {
                string LangCode = _Lang;
                if (LangCode == "en" || LangCode == "tc" || LangCode == "sc")
                    return LangCode;
                else
                {
                    return "tc";
                }
            }
            else
                return "tc";
        }
        catch
        {
            return "sc";
        }
    }

    public static string GeneratePassword()
    {
        string[] aList = new string[26] { "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p", "q", "r", "s", "t", "u", "v", "w", "x", "y", "z" };
        string[] sList = new string[12] { "!", "@", "#", "$", "%", "^", "&", "*", "(", ")", "_", "=" };
        Random rnd = new Random();
        string password = "";
        for (int i = 0; i < 12; i++)
        {
            int indicator = rnd.Next(1, 4);
            switch (indicator)
            {
                case 1: password += aList[rnd.Next(0, 25)]; break;
                case 2: password += aList[rnd.Next(0, 25)].ToUpper(); break;
                case 3: password += sList[rnd.Next(0, 11)]; break;
                case 4: password += rnd.Next(0, 9).ToString(); break;
            }
        }
        return password;
    }

    public static bool SendEmail(string subject, string msg, string toEmail)
    {
        bool successful = true;
        try
        {
            
        }
        catch (Exception ex)
        {
            successful = false;
        }
        return successful;
    }
}