using Amazon.S3;
using Amazon.S3.Model;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.IO;
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

    public static string GetAreaName(int areaID)
    {
        string area = "";
        MySqlConnection cn = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["sq_housedreaming"].ConnectionString);
        try
        {
            cn.Open();
            MySqlCommand cmd = new MySqlCommand("select areaEn, areaTc, areaSc from area where areaID = @areaID", cn);
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.Parameters.Add("@areaID", MySqlDbType.Int32).Value = areaID;
            MySqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                area = dr["areaEn"].ToString() + " " + dr["areaTc"].ToString() + " " + dr["areaSc"].ToString();
            }
            dr.Close();
        }
        catch (Exception ex)
        { }
        finally
        {
            cn.Close();
        }
        return area;
    }

    public static string GetDistictName(int districtID)
    {
        string district = "";
        MySqlConnection cn = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["sq_housedreaming"].ConnectionString);
        try
        {
            cn.Open();
            MySqlCommand cmd = new MySqlCommand("select districtEn, districtTc, districtSc from district where districtID = @districtID", cn);
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.Parameters.Add("@districtID", MySqlDbType.Int32).Value = districtID;
            MySqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                district = dr["districtEn"].ToString() + " " + dr["districtTc"].ToString() + " " + dr["districtSc"].ToString();
            }
            dr.Close();
        }
        catch (Exception ex)
        { }
        finally
        {
            cn.Close();
        }
        return district;
    }

    public static void UploadImageS3(string fileName, MemoryStream fileStream)
    {
        string accessKey = "";
        string secretKey = "";
        try
        {
            AmazonS3 client;
            AmazonS3Config config = new AmazonS3Config().WithCommunicationProtocol(Protocol.HTTP);
            using (client = Amazon.AWSClientFactory.CreateAmazonS3Client(accessKey, secretKey, config))
            {
                PutObjectRequest request = new PutObjectRequest();
                request.WithBucketName("traffiti");
                request.WithCannedACL(S3CannedACL.PublicRead);
                request.WithKey(fileName).InputStream = fileStream;
                request.AddHeaders(Amazon.S3.Util.AmazonS3Util.CreateHeaderEntry("Cache-Control", "max-age=31536000"));

                S3Response response = client.PutObject(request);
            }

        }
        catch (AmazonS3Exception amazonS3Exception)
        {
            if (amazonS3Exception.ErrorCode != null &&
                (amazonS3Exception.ErrorCode.Equals("InvalidAccessKeyId")
                ||
                amazonS3Exception.ErrorCode.Equals("InvalidSecurity")))
            {
                Console.WriteLine("Check the provided AWS Credentials.");
                Console.WriteLine("For service sign up go to http://aws.amazon.com/s3");
            }
            else
            {
                Console.WriteLine(
                    "Error occurred. Message:'{0}' when writing an object"
                    , amazonS3Exception.Message);
            }
        }
    }
}