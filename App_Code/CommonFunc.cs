using Amazon.S3;
using Amazon.S3.Model;
using System.Data.Odbc;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;


/// <summary>
/// Summary description for CommonFunc
/// </summary>
public static class CommonFunc
{
    public static string s3_buckey = ConfigurationManager.AppSettings["s3_bucket"];
    public static string s3_accesskey = ConfigurationManager.AppSettings["s3_accesskey"];
    public static string s3_secretkey = ConfigurationManager.AppSettings["s3_secrect_key"];

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

    public static string GeneratePassword(int size)
    {
        string[] aList = new string[26] { "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p", "q", "r", "s", "t", "u", "v", "w", "x", "y", "z" };
        string[] sList = new string[12] { "!", "@", "#", "$", "%", "^", "&", "*", "(", ")", "_", "=" };
        Random rnd = new Random();
        string password = "";
        for (int i = 0; i < size; i++)
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
        SqlConnection cn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["sq_housedreaming"].ConnectionString);
        try
        {
            cn.Open();
            SqlCommand cmd = new SqlCommand("GetArea", cn);
            cmd.CommandType =  CommandType.StoredProcedure;
            cmd.Parameters.Add("@areaID", SqlDbType.Int).Value = areaID;
            SqlDataReader dr = cmd.ExecuteReader();
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
        SqlConnection cn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["sq_housedreaming"].ConnectionString);
        try
        {
            cn.Open();
            SqlCommand cmd = new SqlCommand("GetDistrict", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@districtID", SqlDbType.Int).Value = districtID;
            SqlDataReader dr = cmd.ExecuteReader();
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
        try
        {
            AmazonS3 client;
            AmazonS3Config config = new AmazonS3Config().WithCommunicationProtocol(Protocol.HTTP);
            using (client = Amazon.AWSClientFactory.CreateAmazonS3Client(s3_accesskey, s3_secretkey, config))
            {
                PutObjectRequest request = new PutObjectRequest();
                request.WithBucketName(s3_buckey);
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

    public static void MoveImageS3(string originFile, string newFile)
    {
        try
        {
            AmazonS3 client;
            AmazonS3Config config = new AmazonS3Config().WithCommunicationProtocol(Protocol.HTTP);
            using (client = Amazon.AWSClientFactory.CreateAmazonS3Client(s3_accesskey, s3_secretkey, config))
            {
                CopyObjectRequest request = new CopyObjectRequest
                {
                    SourceBucket = s3_buckey,
                    SourceKey = originFile,
                    DestinationBucket = s3_buckey,
                    DestinationKey = newFile
                };
                CopyObjectResponse response = client.CopyObject(request);
            }
        }
        catch (AmazonS3Exception s3Exception)
        {
            Console.WriteLine(s3Exception.Message,
                              s3Exception.InnerException);
        }
    }

    public static void DeleteImageS3(string originFile)
    {
        try
        {
            AmazonS3 client;
            AmazonS3Config config = new AmazonS3Config().WithCommunicationProtocol(Protocol.HTTP);
            using (client = Amazon.AWSClientFactory.CreateAmazonS3Client(s3_accesskey, s3_secretkey, config))
            {
                DeleteObjectRequest deleteObjectRequest = new DeleteObjectRequest
                {
                    BucketName = s3_buckey,
                    Key = originFile
                };
                try
                {
                    client.DeleteObject(deleteObjectRequest);
                    Console.WriteLine("Deleting an object");
                }
                catch (AmazonS3Exception s3Exception)
                {
                    Console.WriteLine(s3Exception.Message,
                                      s3Exception.InnerException);
                }
            }
        }
        catch (AmazonS3Exception s3Exception)
        {
            Console.WriteLine(s3Exception.Message,
                              s3Exception.InnerException);
        }
    }

    public static bool UploadLocal(string path, string fileName, HttpPostedFile userPostedFile)
    {
        bool success = true;
        try
        {
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            userPostedFile.SaveAs(path + "/" + fileName);
        }
        catch {
            success = false;
        }
        return success;
    }

    public static bool MoveLocalImage(string origin, string destination, string newPath)
    {
        bool success = true;
        try
        {
            if (!Directory.Exists(newPath))
            {
                Directory.CreateDirectory(newPath);
            }
            File.Move(origin, destination);
        }
        catch
        {
            success = false;
        }
        return success;
    }

    public static string ImageUrl()
    {
        return ConfigurationManager.AppSettings["ImageDomain"];
    }

    public static string GetAgencyDomain()
    {
        return ConfigurationManager.AppSettings["AgencyDomain"].ToString();
    }

    public static int AgencyLoginByAccessKey(int agencyID, string accesskey)
    {
        SqlConnection cn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["sq_housedreaming"].ConnectionString);

        int loginAgencyID = 0;
        try
        {
            cn.Open();
            SqlCommand cmd = new SqlCommand("AgencyLoginByAccesskey", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@agencyID", SqlDbType.Int).Value = agencyID;
            cmd.Parameters.Add("@accesskey", SqlDbType.VarChar).Value = accesskey;
            loginAgencyID = Convert.ToInt32(cmd.ExecuteScalar());
        }
        catch (Exception eX)
        {
        
        }
        finally
        {
            cn.Close();
        }
        return loginAgencyID;
    }
}