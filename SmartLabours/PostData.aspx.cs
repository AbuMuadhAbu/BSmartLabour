using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Script.Serialization;
using System.Net;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Data.SqlClient;
using System.Configuration;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data;

namespace SmartLabours
{
    public partial class PostData : System.Web.UI.Page
    {
        private static string connString = ConfigurationManager.ConnectionStrings["SmartLabourEntities"].ToString();
        private Database objTransDB = new Microsoft.Practices.EnterpriseLibrary.Data.Sql.SqlDatabase(connString);
        string json = "";
        protected string jsonRequest = "";
        protected string signature = "";
        protected string client_id = System.Configuration.ConfigurationManager.AppSettings["client_id"];
        protected string PostURL = System.Configuration.ConfigurationManager.AppSettings["PostURL"];
        protected string Lang = "";

        protected string timestamp;
        protected string random = "";
        protected string localtimestamp;
        protected string localrandom = "";
        protected string nonce = "";
        DataSet ds = new DataSet();



        //protected void Page_Load(object sender, EventArgs e)
        //{
        //    string strUserType = Session["UserType"].ToString(); 
           
        //    if (strUserType == "Admin")
        //    {
        //        string strAdminId = Session["USERID"].ToString();
        //        ds = objTransDB.ExecuteDataSet("SMT_SP_GetUserDatailsForHappiness", 3, strAdminId); // (procedure,Mode,UserId)
        //    }
        //    else if (strUserType == "Sponsor")
        //    {
        //        string strSponsorId = Session["SPONSORID"].ToString();
        //        ds = objTransDB.ExecuteDataSet("SMT_SP_GetUserDatailsForHappiness", 2, strSponsorId); // (procedure,Mode,UserId)
        //    }
        //    else if (strUserType == "Labour")
        //    {
        //        string strLabourId = Session["LABOURID"].ToString();
        //        ds = objTransDB.ExecuteDataSet("SMT_SP_GetUserDatailsForHappiness", 1, strLabourId); // (procedure,Mode,UserId)
        //    }
           
        //    if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        //    {
        //        json = "{\"header\":{"
        //                + "\"serviceProvider\" : \"" + System.Configuration.ConfigurationManager.AppSettings["serviceProvider"] + "\","
        //                + "\"themeColor\" : \"" + Request["themeColor"] + "\"},"

        //                + "\"transaction\":{"
        //                + "\"transactionID\" : \"" + Session["transactionID"] + "\","
        //                + "\"gessEnabled\" : \"" + System.Configuration.ConfigurationManager.AppSettings["gessEnabled"] + "\","
        //                + "\"serviceCode\" : \"" + System.Configuration.ConfigurationManager.AppSettings["serviceCode"] + "\","
        //                + "\"serviceDescription\" : \"" + System.Configuration.ConfigurationManager.AppSettings["serviceDescription"] + "\","
        //                + "\"channel\" : \"" + System.Configuration.ConfigurationManager.AppSettings["channel"] + "\","
        //                + "\"result\" : \"\","
        //                + "\"notes\" : \"\"},"

        //                + "\"user\":{"
        //                + "\"source\" : \"" + System.Configuration.ConfigurationManager.AppSettings["source"] + "\","
        //                + "\"emiratesID\" : \"" + ds.Tables[0].Rows[0]["EmiratesId"] + "\","
        //                + "\"username\" :  \"" + ds.Tables[0].Rows[0]["UserName"] + "\","
        //                + "\"email\" :  \"" + ds.Tables[0].Rows[0]["Mobile"] + "\","
        //                + "\"mobile\" :  \"" + ds.Tables[0].Rows[0]["Email"] + "\"}}";
        //    }
          

        //    signature = GetCrypt(json + "|" + System.Configuration.ConfigurationManager.AppSettings["SecretKey"]);
        //    jsonRequest = Server.UrlEncode(json);

        //    localtimestamp = Convert.ToString(DateTime.UtcNow.ToString("dd/MM/yyyy HH:mm:ss"));

        //    localrandom = GenerateRnd();

        //    random = Server.UrlEncode(localrandom);
        //    timestamp = Server.UrlEncode(localtimestamp);

        //    nonce = (GetCrypt(localrandom + "|" + localtimestamp + "|" + System.Configuration.ConfigurationManager.AppSettings["SecretKey"]));

        //    //Set the language parameter of your portal 

        //    if ((string)Session["Lang"] == "en")
        //    {
        //        Lang = "en";
        //    }
        //    else
        //    {
        //        Lang = "en";
        //    }



        //}

        protected void Page_Load(object sender, EventArgs e)
        {


                json = "{\"header\":{"
                        + "\"timestamp\" : \"" + DateTime.UtcNow.ToString("dd/MM/yyyy HH:mm:ss") + "\","
                        + "\"serviceProvider\" : \"" + System.Configuration.ConfigurationManager.AppSettings["serviceProvider"] + "\","
                        + "\"themeColor\" : \"" + Request["themeColor"] + "\"},"

                        + "\"application\":{"

                        + "\"applicationID\" : \"" + System.Configuration.ConfigurationManager.AppSettings["applicationID"] + "\","
                        + "\"type\" : \"" + System.Configuration.ConfigurationManager.AppSettings["Applicationtype"] + "\","
                        + "\"platform\" : \"" + System.Configuration.ConfigurationManager.AppSettings["platform"] + "\","
                        + "\"url\" : \"" + System.Configuration.ConfigurationManager.AppSettings["Applicationurl"] + "\","
                        + "\"version\" : \"" + System.Configuration.ConfigurationManager.AppSettings["version"] + "\","
                        + "\"result\" : \"\","
                        + "\"notes\" :  \"\"},"

                        + "\"user\":{"
                                      + "\"source\" : \"" + System.Configuration.ConfigurationManager.AppSettings["source"] + "\","
                                      + "\"emiratesID\" : \"" + Session["emiratesID"] + "\","
                                      + "\"username\" :  \"" + Session["username"] + "\","
                                      + "\"email\" :  \"" + Session["email"] + "\","
                                      + "\"mobile\" :  \"" + Session["mobile"] + "\"}}";




        
            signature = GetCrypt(json + "|" + System.Configuration.ConfigurationManager.AppSettings["SecretKey"]);
            jsonRequest = Server.UrlEncode(json);

            localtimestamp = Convert.ToString(DateTime.UtcNow.ToString("dd/MM/yyyy HH:mm:ss"));

            localrandom = GenerateRnd();

            random = Server.UrlEncode(localrandom);
            timestamp = Server.UrlEncode(localtimestamp);

            nonce = (GetCrypt(localrandom + "|" + localtimestamp + "|" + System.Configuration.ConfigurationManager.AppSettings["SecretKey"]));




            //Set the language parameter of your portal 

            //if ((string)Session["Lang"] == "en")
            //{
                Lang = "en";
            //}
            //else
            //{
            //    Lang = "ar";
            //}



        }

        public static string GetCrypt(string text)
        {
            SHA512 alg = SHA512.Create();
            byte[] result = alg.ComputeHash(Encoding.UTF8.GetBytes(text));
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < result.Length; i++)
            {
                sb.Append(Convert.ToString((result[i] & 0xff) + 0x100, 16).Substring(1));
            }
            return sb.ToString();
        }


        public static string GenerateRnd()
        {
            int maxSize = 15;
            int minSize = 15;
            char[] chars = new char[63];
            string a = null;
            a = "123456789ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            chars = a.ToCharArray(0, 16);
            int size = maxSize;
            byte[] data = new byte[2];
            RNGCryptoServiceProvider crypto = new RNGCryptoServiceProvider();
            crypto.GetNonZeroBytes(data);
            size = maxSize;
            data = new byte[size + 1];
            crypto.GetNonZeroBytes(data);
            StringBuilder result = new StringBuilder(size);
            foreach (byte b in data)
            {
                result.Append(chars[b % (chars.Length - 1)]);
            }
            return result.ToString();
        }

    }
}