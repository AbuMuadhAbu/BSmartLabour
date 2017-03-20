using Microsoft.Practices.EnterpriseLibrary.Data;
using SmartLabours.Common;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;

namespace SmartLabours
{
    /// <summary>
    /// Summary description for FileUpload1
    /// </summary>
    public class FileUpload1 : IHttpHandler
    {
        private static string connString = ConfigurationManager.ConnectionStrings["SmartLabourEntities"].ToString();
        private Database objTransDB = new Microsoft.Practices.EnterpriseLibrary.Data.Sql.SqlDatabase(connString);

        public void ProcessRequest(HttpContext context)
        {
            string DateTime1 = string.Empty;
            DateTime1 = DateTime.Now.ToString("yyyyMMddHHmmssfff");
            try
            {
                DataAccess ObjDa = new DataAccess();
                DataTable ds = new DataTable();
                DataSet dataSet = new DataSet();
                //  string FileName1 = "Not Success";
               // dataSet = objTransDB.ExecuteDataSet("SP_LogFile", DateTime1, "Before");
                if (HttpContext.Current.Request.Files.Count > 0)
                {
                  //  dataSet = objTransDB.ExecuteDataSet("SP_LogFile", DateTime1, "InsideFile>0");
                    for (int i = 0; i < HttpContext.Current.Request.Files.Count; i++)
                    {
                       // dataSet = objTransDB.ExecuteDataSet("SP_LogFile", DateTime1, "InsideFileLoop_" + i.ToString());

                        HttpPostedFile file = HttpContext.Current.Request.Files[i];

                        if (!System.IO.Directory.Exists(HttpContext.Current.Server.MapPath("/HealthAndSafety/Image")))
                        {
                            System.IO.Directory.CreateDirectory(HttpContext.Current.Server.MapPath("/HealthAndSafety/Image"));
                        }
                        if (!System.IO.Directory.Exists(HttpContext.Current.Server.MapPath("/HealthAndSafety/Audio")))
                        {
                            System.IO.Directory.CreateDirectory(HttpContext.Current.Server.MapPath("/HealthAndSafety/Audio"));
                        }                       
                        string exttension = System.IO.Path.GetExtension(file.FileName);
                      //  dataSet = objTransDB.ExecuteDataSet("SP_LogFile", DateTime1, "FileName_" + file.FileName);
                      //  dataSet = objTransDB.ExecuteDataSet("SP_LogFile", DateTime1, "SplitFileType_" + "||" + exttension);

                        if (exttension.ToLower().Trim() == ".jpg" || exttension.ToLower().Trim() == ".jpeg")
                        {
                           // dataSet = objTransDB.ExecuteDataSet("SP_LogFile", DateTime1, "InsideImageFileType_" + exttension);
                            using (var fileStream = new System.IO.FileStream(HttpContext.Current.Server.MapPath("/HealthAndSafety/Image/") + file.FileName, System.IO.FileMode.Create, System.IO.FileAccess.Write))
                            {
                               // dataSet = objTransDB.ExecuteDataSet("SP_LogFile", DateTime1, "BeforeImageFileCreate_" + file.FileName);
                                file.InputStream.CopyTo(fileStream);
                                dataSet = objTransDB.ExecuteDataSet("SP_LogFile", DateTime1, "AfterImageFileCreate_" + file.FileName);
                            }
                        }

                        if (exttension.ToLower().Trim() == ".wav" || exttension.ToLower().Trim() == ".mp3")
                        {
                            //dataSet = objTransDB.ExecuteDataSet("SP_LogFile", DateTime1, "InsideAudioFileType_" + exttension);
                            using (var fileStream = new System.IO.FileStream(HttpContext.Current.Server.MapPath("/HealthAndSafety/Audio/") + file.FileName, System.IO.FileMode.Create, System.IO.FileAccess.Write))
                            {
                               // dataSet = objTransDB.ExecuteDataSet("SP_LogFile", DateTime1, "BeforeAudioFileCreate_" + file.FileName);
                                file.InputStream.CopyTo(fileStream);
                                dataSet = objTransDB.ExecuteDataSet("SP_LogFile", DateTime1, "AfterAudioFileCreate_" + file.FileName);
                            }
                        }
                    }
                }
                //  return FileName1;
            }
            catch (Exception Ex)
            {
                DataSet dataSet = new DataSet();
                dataSet = objTransDB.ExecuteDataSet("SP_LogFile", DateTime1, "Exception_" + Ex.ToString());
            }
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }

    }
}