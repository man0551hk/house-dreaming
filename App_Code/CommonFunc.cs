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
}