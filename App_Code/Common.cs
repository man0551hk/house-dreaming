using System;
using System.Collections.Generic;
using System.Configuration;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.UI;

namespace HouseDreaming
{
    public class Kernel
    {
        public static int GetLanguageID()
        {
            string LangCode = GetLanguage();
            int LangID = 1;
            switch (LangCode.ToLower())
            {
                case "en":
                    LangID = 1;
                    break;
                case "tc":
                    LangID = 2;
                    break;
                case "sc":
                    LangID = 3;
                    break;
            }
            return LangID;
        }

        public static string GetLanguageCode()
        {
            return GetLanguage();
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
                return "tc";
            }
        }

        public static void ChangeLanguage(string langcode)
        {
            HttpCookie cookie1 = HttpContext.Current.Request.Cookies["House_Dreaming_Lang"];
            cookie1 = null;
            if (cookie1 == null)
            {
                HttpCookie objCookie = new HttpCookie("House_Dreaming_Lang");
                HttpContext.Current.Response.Cookies.Add(objCookie);
                objCookie.Values.Add("LangCode", langcode.ToUpper());
                HttpContext.Current.Response.SetCookie(objCookie);
            }
            else
            {
                cookie1["LangCode"] = langcode.ToUpper().ToString();
                HttpContext.Current.Response.SetCookie(cookie1);
            }
        }

        public static void SaveLanguage(string langcode)
        {
            HttpCookie cookie1 = HttpContext.Current.Request.Cookies["House_Dreaming_Lang"];
            if (cookie1 == null)
            {
                HttpCookie objCookie = new HttpCookie("House_Dreaming_Lang");
                objCookie.Value = langcode;
                objCookie.Expires = DateTime.Now.AddDays(30);
                objCookie.Domain = ConfigurationSettings.AppSettings["HomeDomain"].ToString();
                HttpContext.Current.Response.Cookies.Add(objCookie);
            }
            else
            {
                try
                {
                    cookie1.Value = langcode;
                    cookie1.Domain = ConfigurationSettings.AppSettings["HomeDomain"].ToString();
                    HttpContext.Current.Response.Cookies.Add(cookie1);
                }
                catch (Exception ex) { }
            }
        }
    }

    public class Page_Control : Page
    {
        public Page_Control()
        {
            string langcode = string.Empty;
            if (!string.IsNullOrEmpty(HttpContext.Current.Request.QueryString["lang"]))
            {
                langcode = HttpContext.Current.Request.QueryString["lang"].ToString();
                Kernel.SaveLanguage(langcode);
                //HttpContext.Current.Response.Redirect(HttpContext.Current.Request.RawUrl.ToString().Replace("?lang=" + langcode, string.Empty));
            }
        }

        protected override void OnInit(EventArgs e)
        {
        }

        protected override void InitializeCulture()
        {
            string language = "zh-hk";

            switch (Kernel.GetLanguageCode().ToLower())
            {
                case "en":
                    language = "en-us";
                    break;
                case "tc":
                    language = "zh-hk";
                    break;
                case "sc":
                    language = "zh-cn";
                    break;
            }
            Thread.CurrentThread.CurrentCulture = new CultureInfo(language);
            Thread.CurrentThread.CurrentUICulture = Thread.CurrentThread.CurrentCulture;
            base.InitializeCulture();
        }

        protected override void OnPreInit(EventArgs e)
        {
        }


    }

    public class Agency_Kernel
    {
        public static int GetLanguageID()
        {
            string LangCode = GetLanguage();
            int LangID = 1;
            switch (LangCode.ToLower())
            {
                case "en":
                    LangID = 1;
                    break;
                case "tc":
                    LangID = 2;
                    break;
                case "sc":
                    LangID = 3;
                    break;
            }
            return LangID;
        }

        public static string GetLanguageCode()
        {
            return GetLanguage();
        }

        public static string GetLanguage()
        {
            try
            {
                string _Lang = string.Empty;
                HttpCookie cookie1 = HttpContext.Current.Request.Cookies["House_Dreaming_Agency_Lang"];
                if (cookie1 != null)
                {
                    if (HttpContext.Current.Request.Cookies["House_Dreaming_Agency_Lang"] != null)
                    {
                        if (HttpContext.Current.Request.Cookies["House_Dreaming_Agency_Lang"] != null)
                            _Lang = HttpContext.Current.Request.Cookies["House_Dreaming_Agency_Lang"].Value.ToString();
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
                return "tc";
            }
        }

        public static void ChangeLanguage(string langcode)
        {
            HttpCookie cookie1 = HttpContext.Current.Request.Cookies["House_Dreaming_Agency_Lang"];
            cookie1 = null;
            if (cookie1 == null)
            {
                HttpCookie objCookie = new HttpCookie("House_Dreaming_Agency_Lang");
                HttpContext.Current.Response.Cookies.Add(objCookie);
                objCookie.Values.Add("LangCode", langcode.ToUpper());
                HttpContext.Current.Response.SetCookie(objCookie);
            }
            else
            {
                cookie1["LangCode"] = langcode.ToUpper().ToString();
                HttpContext.Current.Response.SetCookie(cookie1);
            }
        }

        public static void SaveLanguage(string langcode)
        {
            HttpCookie cookie1 = HttpContext.Current.Request.Cookies["House_Dreaming_Agency_Lang"];
            if (cookie1 == null)
            {
                HttpCookie objCookie = new HttpCookie("House_Dreaming_Agency_Lang");
                objCookie.Value = langcode;
                objCookie.Expires = DateTime.Now.AddDays(30);
                objCookie.Domain = ConfigurationSettings.AppSettings["HomeDomain"].ToString();
                HttpContext.Current.Response.Cookies.Add(objCookie);
            }
            else
            {
                try
                {
                    cookie1.Value = langcode;
                    cookie1.Domain = ConfigurationSettings.AppSettings["HomeDomain"].ToString();
                    HttpContext.Current.Response.Cookies.Add(cookie1);
                }
                catch (Exception ex) { }
            }
        }
    }

    public class Agency_Page_Control : Page
    {
        public Agency_Page_Control()
        {
            string langcode = string.Empty;
            if (!string.IsNullOrEmpty(HttpContext.Current.Request.QueryString["lang"]))
            {
                langcode = HttpContext.Current.Request.QueryString["lang"].ToString();
                Agency_Kernel.SaveLanguage(langcode);
                //HttpContext.Current.Response.Redirect(HttpContext.Current.Request.RawUrl.ToString().Replace("?lang=" + langcode, string.Empty));
            }
        }

        protected override void OnInit(EventArgs e)
        {
        }

        protected override void InitializeCulture()
        {
            string language = "zh-hk";

            switch (Kernel.GetLanguageCode().ToLower())
            {
                case "en":
                    language = "en-us";
                    break;
                case "tc":
                    language = "zh-hk";
                    break;
                case "sc":
                    language = "zh-cn";
                    break;
            }
            Thread.CurrentThread.CurrentCulture = new CultureInfo(language);
            Thread.CurrentThread.CurrentUICulture = Thread.CurrentThread.CurrentCulture;
            base.InitializeCulture();
        }

        protected override void OnPreInit(EventArgs e)
        {
        }


    }

}
