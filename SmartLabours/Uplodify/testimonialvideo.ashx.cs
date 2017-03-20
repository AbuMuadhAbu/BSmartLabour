using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Diagnostics;
using SmartLabours.Models;

namespace SmartLabours.Uplodify
{
    /// <summary>
    /// Summary description for testimonialvideo
    /// </summary>
    public class testimonialvideo : IHttpHandler
    {

        //public void ProcessRequest(HttpContext context)
        //{
        //    context.Response.ContentType = "text/plain";
        //    context.Response.Expires = -1;
        //    try
        //    {
        //        HttpPostedFile postedFile = context.Request.Files["Filedata"];
        //        string savepath = "";
        //        string tempPath = "";
        //        tempPath = "Testimonialvedio";
        //        savepath = context.Server.MapPath(tempPath);
        //        string filename = GetNewfileName(postedFile.FileName);
        //        postedFile.SaveAs(savepath + @"\" + filename);
        //        string mp4filename = filename;
        //        string webmfilename = filename;


        //        context.Response.Write(filename);
        //    }
        //    catch (Exception ex)
        //    {
        //        context.Response.Write("Error: " + ex.Message);
        //    }
        //}
     
        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            context.Response.Expires = -1;
            try
            {
                HttpPostedFile postedFile = context.Request.Files["Filedata"];
                string savepath = "";
                string tempPath = "";
                tempPath = "Testimonialvideo";
                savepath = context.Server.MapPath(tempPath);
                string filename = GetNewfileName(postedFile.FileName);
                postedFile.SaveAs(savepath + @"\" + filename);
                string mp4filename = filename;
                string webmfilename = filename;
                if (postedFile.FileName.Split('.').Last().ToLower() != "mp4") 
                {
                    mp4filename = filename.Replace("." + filename.Split('.').Last(), "") + ".mp4";
                    ConvertVideo(savepath + @"\" + filename, savepath + @"\" + mp4filename, "mp4");
                }
                if (postedFile.FileName.Split('.').Last().ToLower() != "webm")
                {
                    webmfilename = filename.Replace("." + filename.Split('.').Last(), "") + ".webm";
                    ConvertVideo(savepath + @"\" + filename, savepath + @"\" + webmfilename, "webm");
                }

                SmartLabourEntities db = new SmartLabourEntities();
                TBL_TESTIMONIAL_SMT objVideo = new TBL_TESTIMONIAL_SMT();
                // if the Video is for Home Page

                objVideo.videoFile = mp4filename + "|" + webmfilename;




                context.Response.Write(objVideo.videoFile);
            }
            catch (Exception ex)
            {
                context.Response.Write("Error: " + ex.Message);
            }
        }

        public bool ConvertVideo(string inputpath, string outputpath, string type)
        {
            string parameters = "";
            if (type == "mp4")
            {
                parameters = " -i " + inputpath + " -b:v 64k -vf scale=-1:240 -acodec copy " + outputpath;
            }
            else
            {
                parameters = " -i " + inputpath + " -b 1500k -vcodec libvpx -acodec libvorbis -ab 160000 -f webm -g 30 " + outputpath;
            }

            ProcessStartInfo oInfo = new ProcessStartInfo(System.Configuration.ConfigurationManager.AppSettings["path"].ToString(), parameters);
            oInfo.UseShellExecute = false;
            oInfo.CreateNoWindow = true;
            //try the process
            try
            {
                //run the process
                Process proc = System.Diagnostics.Process.Start(oInfo);

                proc.WaitForExit();

                //get the output
                //  srOutput = proc.StandardError;

                //now put it in a string
                // output = srOutput.ReadToEnd();

                // MessageBox.Show(output);

                proc.Close();
                return true;
            }
            catch (Exception)
            {
                return false;
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