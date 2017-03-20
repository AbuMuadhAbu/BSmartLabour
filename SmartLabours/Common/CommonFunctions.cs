using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.OleDb;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Web.Mvc;
using System.Web;
using System.Net.Security;
using System.Drawing;

namespace SmartLabours.Common
{
    public class CommonFunctions
    {
        /// <summary>
        /// Convert Excel Sheet data to Data Table
        /// </summary>
        /// <param name="FilePath"></param>
        /// <param name="Extension"></param>
        /// <returns></returns>
        private DataTable Import_To_Grid(string FilePath, string Extension)
        {
            string conStr = "";
            switch (Extension)
            {
                case ".xls": //Excel 97-03
                    conStr = ConfigurationManager.ConnectionStrings["Excel03ConString"]
                             .ConnectionString;
                    break;
                case ".xlsx": //Excel 07
                    conStr = ConfigurationManager.ConnectionStrings["Excel07ConString"]
                              .ConnectionString;
                    break;
            }
            conStr = String.Format(conStr, FilePath, "Yes");
            OleDbConnection connExcel = new OleDbConnection(conStr);
            OleDbCommand cmdExcel = new OleDbCommand();
            OleDbDataAdapter oda = new OleDbDataAdapter();
            DataTable dt = new DataTable();
            cmdExcel.Connection = connExcel;

            //Get the name of First Sheet
            connExcel.Open();
            DataTable dtExcelSchema;
            dtExcelSchema = connExcel.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
            string SheetName = dtExcelSchema.Rows[0]["TABLE_NAME"].ToString();
            connExcel.Close();

            //Read Data from First Sheet
            connExcel.Open();
            cmdExcel.CommandText = "SELECT * From [" + SheetName + "]";
            oda.SelectCommand = cmdExcel;
            oda.Fill(dt);
            connExcel.Close();
            return dt;
        }

        /// <summary>
        /// Common Method For Sending Mail.
        /// </summary>
        /// Create:16/09/2015
        /// <param name="Email"></param>
        /// <param name="content"></param>
        /// <param name="Title"></param>
        /// <param name="Description"></param>
        /// <returns></returns>
        public string SendingMail(string Email, string content, string Title, string Description, string url)
        {
            try
            {
                //string EmailId = Email;
                string body = string.Empty;
               // using (StreamReader reader = new StreamReader(Server.MapPath("~/Views/Shared/MailTemplates/RegEmailTemp.html")))
               // {
               // //    body = reader.ReadToEnd();
              //  }
                body = body.Replace("{Content}", content);
                body = body.Replace("{UserName}", "Password");
                body = body.Replace("{Title}", Title);
                body = body.Replace("{Description}", Description);
                using (MailMessage mailMessage = new MailMessage())
                {
                    mailMessage.From = new MailAddress("thiyagarajan.e@angleritech.com");
                    mailMessage.Subject = "Welcome Mail!";
                    mailMessage.IsBodyHtml = true;
                    SmtpClient smtp = new SmtpClient();
                    smtp.Host = ConfigurationManager.AppSettings["Host"];
                    smtp.EnableSsl = Convert.ToBoolean(ConfigurationManager.AppSettings["EnableSsl"]);
                    ServicePointManager.ServerCertificateValidationCallback = delegate(object s, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors)
                    { return true; };
                    System.Net.NetworkCredential NetworkCred = new System.Net.NetworkCredential();
                    NetworkCred.UserName = ConfigurationManager.AppSettings["UserName"];
                    NetworkCred.Password = "";
                    smtp.UseDefaultCredentials = true;
                    smtp.Credentials = NetworkCred;
                    smtp.Port = int.Parse(ConfigurationManager.AppSettings["Port"]);
                    byte[] encode = new byte[Email.Length];
                    encode = Encoding.UTF8.GetBytes(Email);
                    string str = Convert.ToBase64String(encode);
                    var UrlPath = System.Web.HttpContext.Current.Request.Url.Scheme + ":/" + System.Web.HttpContext.Current.Request.Url.Authority + url + str;
                    //body = body.Replace("{Url}", System.Web.Mvc.Url.Content(UrlPath));
                    mailMessage.Body = body;
                    mailMessage.To.Add(Email);
                    smtp.Send(mailMessage);
                    return "Success";
                }


            }
            catch (Exception)
            {
                return "Failure";
            }

        }

        public string GenerateRandomPassword()
        {
            try
            {
                //Every time Change the Length of the Secrete Numbers
                int textLength = 10, i = 0;
                textLength = 10 + i;
                i++;
                if (i == 9)
                {
                    i = 0;
                }
                const string Chars = "ABCDEFGHIJKLMNPOQRSTUVWXYZ0123456789";
                var random = new Random();
                var result = new string(
                    Enumerable.Repeat(Chars, textLength)
                        .Select(s => s[random.Next(s.Length)])
                        .ToArray());
                return result;
            }

            catch (Exception)
            {
                return "";
            }
        }


        public Image Base64ToImage(string base64String)
        {
            // Convert base 64 string to byte[]
            byte[] imageBytes = Convert.FromBase64String(base64String);
            // Convert byte[] to Image
            using (var ms = new MemoryStream(imageBytes, 0, imageBytes.Length))
            {
                Image image = Image.FromStream(ms, true);
                return image;
            }
        }


        public string UrlDecode(string base64String)
        {
            string UrlString = base64String.Replace(")$$$(", "/").Replace("$((($", "=").Replace("])))[", "+").Replace(")[[[(", "?").Replace(")[$](", "#");            
            return UrlString;
        }


        public string UrlEncode(string base64String)
        {
            string UrlString = base64String.Replace("/", ")$$$(").Replace("=", "$((($").Replace("+", "])))[").Replace("?", ")[[[(").Replace("#", ")[$](");           
            return UrlString;
        }
    }
}