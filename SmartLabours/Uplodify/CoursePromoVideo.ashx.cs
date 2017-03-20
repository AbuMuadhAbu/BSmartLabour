using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Wisemee.Uplodify
{
    /// <summary>
    /// Summary description for CoursePromoVideo
    /// </summary>
    public class CoursePromoVideo : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            context.Response.Expires = -1;
            try
            {
                HttpPostedFile postedFile = context.Request.Files["Filedata"];
                string savepath = "";
                string tempPath = "";
                tempPath = "Uploads";
                savepath = context.Server.MapPath(tempPath);
                string filename = GetNewfileName(postedFile.FileName);
                postedFile.SaveAs(savepath + @"\" + filename);
                string mp4filename = filename;
                string webmfilename = filename;
              

                context.Response.Write(filename);
            }
            catch (Exception ex)
            {
                context.Response.Write("Error: " + ex.Message);
            }
        }
        private string GetNewfileName(string filename)
        {
            string[] strFile = filename.Split('.');
            return filename.Replace("." + strFile.Last(), "") + DateTime.Now.Day.ToString() + DateTime.Now.Month.ToString()
                + DateTime.Now.Year.ToString() + DateTime.Now.Second.ToString() + "." + strFile.Last();
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