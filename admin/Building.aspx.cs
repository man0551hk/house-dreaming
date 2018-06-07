using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Text.RegularExpressions;

public partial class admin_Building : System.Web.UI.Page
{
    SqlConnection cn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["sq_housedreaming"].ConnectionString);
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    public string[] SplitCSV(string input)
    {
        Regex csvSplit = new Regex("(?:^|,)(\"(?:[^\"]+|\"\")*\"|[^,]*)", RegexOptions.Compiled);
        List<string> list = new List<string>();
        string curr = null;
        foreach (Match match in csvSplit.Matches(input))
        {
            curr = match.Value;
            if (0 == curr.Length)
            {
                list.Add("");
            }

            list.Add(curr.TrimStart(','));
        }

        return list.ToArray();
    }


    protected void uploadBtn_Click(object sender, EventArgs e)
    {
        if (fileUpload.HasFile)
        {
            HttpPostedFile userPostedFile = fileUpload.PostedFile;
            FileInfo fi = new FileInfo(userPostedFile.FileName);
            if (fi.Extension.Contains("csv"))
            {
                int counter = 0;
                string line;

                try
                {
                    cn.Open();
                    // Read the file and display it line by line.  
                    List<int> lineList = new List<int>();
                    StreamReader file = new StreamReader(fileUpload.PostedFile.InputStream);
                    while ((line = file.ReadLine()) != null)
                    {
                        System.Console.WriteLine(line);
                        if (counter > 0)
                        {
                            try
                            {
                                //string[] items = line.Split(',');
                                string[] items = SplitCSV(line);
                                string areaID = items[0];
                                string districtID = items[1];
                                string buildingNameEn = items[2];
                                string buildingNameTc = items[3];
                                string buildingNameSc = items[4];
                                string addressEn = items[5];
                                string addressTc = items[6];
                                string addressSc = items[7];
                                string latitude = items[8];
                                string longitude = items[9];

                                SqlCommand cmd = new SqlCommand(@"insert into building (areaID, districtID, buildingNameEn, buildingNameTc, buildingNameSc, addressEn, addressTc, addressSc, latitude, longitude)
                                                                values 
                                                            (@areaID, @districtID, @buildingNameEn, @buildingNameTc , @buildingNameSc, @addressEn, @addressTc, @addressSc, @latitude, @longitude)", cn);
                                cmd.CommandType = CommandType.Text;
                                cmd.Parameters.Add("@areaID", SqlDbType.Int).Value = Convert.ToInt32(areaID);
                                cmd.Parameters.Add("@districtID", SqlDbType.Int).Value = Convert.ToInt32(districtID);
                                cmd.Parameters.Add("@buildingNameEn", SqlDbType.VarChar).Value = buildingNameEn.Replace("\"", "");
                                cmd.Parameters.Add("@buildingNameTc", SqlDbType.NVarChar).Value = buildingNameTc.Replace("\"", "");
                                cmd.Parameters.Add("@buildingNameSc", SqlDbType.NVarChar).Value = buildingNameSc.Replace("\"", "");
                                cmd.Parameters.Add("@addressEn", SqlDbType.VarChar).Value = addressEn.Replace("\"", "");
                                cmd.Parameters.Add("@addressTc", SqlDbType.NVarChar).Value = addressTc.Replace("\"", "");
                                cmd.Parameters.Add("@addressSc", SqlDbType.NVarChar).Value = addressSc.Replace("\"", "");
                                cmd.Parameters.Add("@latitude", SqlDbType.Decimal).Value = Convert.ToDouble(latitude);
                                cmd.Parameters.Add("@longitude", SqlDbType.Decimal).Value = Convert.ToDouble(longitude);
                                cmd.ExecuteNonQuery();
                                
                            }
                            catch (Exception ex)
                            {
                                lineList.Add(counter);
                            }
                        }
                        counter++;
                    } 
                    file.Close();
                    Response.Write(lineList.ToArray().ToString());
                }
                catch (Exception ex)
                { }
                finally
                {
                    cn.Close();
                }

               
            }   
        }
    }
}