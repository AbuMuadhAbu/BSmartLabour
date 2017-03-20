using Microsoft.Practices.EnterpriseLibrary.Data;
using SmartLabours.Common;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;

namespace SmartLabours
{
    /// <summary>
    /// Summary description for PostTestimonialUpload
    /// </summary>
    public class PostTestimonialUpload : IHttpHandler
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
                string ImagePath = HttpContext.Current.Server.MapPath("/Uplodify/TestimonialImages/") + ".jpg";
                string VideoPath = HttpContext.Current.Server.MapPath("/Uplodify/Testimonialvideo/") + ".mp4";

                if (HttpContext.Current.Request.Files.Count > 0)
                {
                    //dataSet = objTransDB.ExecuteDataSet("SP_LogFile", DateTime1, "InsideFile>0");
                    for (int i = 0; i < HttpContext.Current.Request.Files.Count; i++)
                    {
                        //dataSet = objTransDB.ExecuteDataSet("SP_LogFile", DateTime1, "InsideFileLoop_" + i.ToString());

                        HttpPostedFile file = HttpContext.Current.Request.Files[i];

                        if (!System.IO.Directory.Exists(HttpContext.Current.Server.MapPath("/Uplodify/TestimonialImages")))
                        {
                            System.IO.Directory.CreateDirectory(HttpContext.Current.Server.MapPath("/Uplodify/TestimonialImages"));
                        }
                        if (!System.IO.Directory.Exists(HttpContext.Current.Server.MapPath("/Uplodify/Testimonialvideo")))
                        {
                            System.IO.Directory.CreateDirectory(HttpContext.Current.Server.MapPath("/Uplodify/Testimonialvideo"));
                        }

                        string exttension = System.IO.Path.GetExtension(file.FileName);
                       // dataSet = objTransDB.ExecuteDataSet("SP_LogFile", DateTime1, "FileName_" + file.FileName);
                       // dataSet = objTransDB.ExecuteDataSet("SP_LogFile", DateTime1, "SplitFileType_" + "||" + exttension);

                        if (exttension.ToLower().Trim() == ".jpg" || exttension.ToLower().Trim() == ".jpeg" || exttension.ToLower().Trim() == ".png")
                        {
                            dataSet = objTransDB.ExecuteDataSet("SP_LogFile", DateTime1, "BeforeNewImageFileCreate_LengthOfFile" + file.ContentLength);
                            dataSet = objTransDB.ExecuteDataSet("SP_LogFile", DateTime1, "BeforeNewImageFileCreate_" + file.FileName);
                            string savedFileName = System.Web.HttpContext.Current.Server.MapPath("/Uplodify/" + file.FileName);
                            file.SaveAs(savedFileName);
                            //dataSet = objTransDB.ExecuteDataSet("SP_LogFile", DateTime1, "InsideImageFileType_" + exttension);
                            using (var fileStream = new System.IO.FileStream(HttpContext.Current.Server.MapPath("/Uplodify/TestimonialImages/") + file.FileName, System.IO.FileMode.Create, System.IO.FileAccess.Write))
                            {
                                dataSet = objTransDB.ExecuteDataSet("SP_LogFile", DateTime1, "BeforeTestImageFileCreate_" + file.FileName);

                       
                                dataSet = objTransDB.ExecuteDataSet("SP_LogFile", DateTime1, "OutSideImageByteFileCreate_" + file.FileName);
                                byte[] fileData = null;
                                using (var binaryReader = new BinaryReader(HttpContext.Current.Request.Files[0].InputStream))
                                {
                                    fileData = binaryReader.ReadBytes(HttpContext.Current.Request.Files[0].ContentLength);
                                }
                             
                                    dataSet = objTransDB.ExecuteDataSet("SP_LogFile", DateTime1, "InsideImageByteFileCreate_" + file.FileName);


                                    dataSet = objTransDB.ExecuteDataSet("SP_LogFile1", fileStream.Length, fileData);
                                    int numBytesToRead = fileData.Length;

                                // Write the byte array to the other FileStream.
                                using (FileStream fsNew = new FileStream(HttpContext.Current.Server.MapPath("/Uplodify/TestimonialImages/"),
                                    FileMode.Create, FileAccess.Write))
                                {
                                    fsNew.Write(fileData, 0, numBytesToRead);
                                }
                                file.InputStream.CopyTo(fileStream);
                                dataSet = objTransDB.ExecuteDataSet("SP_LogFile", DateTime1, "AfterImageFileCreate_" + file.FileName);
                            }
                        }

                        if (exttension.ToLower().Trim() == ".mp4")
                        {
                            //dataSet = objTransDB.ExecuteDataSet("SP_LogFile", DateTime1, "InsideAudioFileType_" + exttension);
                            using (var fileStream = new System.IO.FileStream(HttpContext.Current.Server.MapPath("/Uplodify/Testimonialvideo/") + file.FileName, System.IO.FileMode.Create, System.IO.FileAccess.Write))
                            {
                               // dataSet = objTransDB.ExecuteDataSet("SP_LogFile", DateTime1, "BeforeAudioFileCreate_" + file.FileName);
                                file.InputStream.CopyTo(fileStream);
                                dataSet = objTransDB.ExecuteDataSet("SP_LogFile", DateTime1, "AfterAudioFileCreate_" + file.FileName);
                            }
                        }
                    }
                }
            }
            catch(Exception Ex)
            {
                objTransDB.ExecuteDataSet("SP_LogFile", DateTime1, "Excepion:-->" + Ex.ToString());
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