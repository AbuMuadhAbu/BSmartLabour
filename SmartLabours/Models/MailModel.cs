using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading;
using System.Threading.Tasks;
using SmartLabours.Controllers;
using System.Data;
using System.Configuration;
using Microsoft.Practices.EnterpriseLibrary.Data;

namespace SmartLabours.Models
{
    public class MailModel
    {
        public static void Task_SendMailToSubAdmin(int OrgId, string EmiratesId, string LabourEmail)
        {
            string connString = ConfigurationManager.ConnectionStrings["SmartLabourEntities"].ToString();
            Database objTransDB = new Microsoft.Practices.EnterpriseLibrary.Data.Sql.SqlDatabase(connString);
            SmartLabourEntities Entities = new SmartLabourEntities();
            CommonClass objmail = new CommonClass();
            try
            {
                List<TBL_ADMINLOGIN_SMT> Oid = (from m in Entities.AdminLogin where m.OrgId == OrgId && m.STATUS == true select m).ToList<TBL_ADMINLOGIN_SMT>();
                foreach (TBL_ADMINLOGIN_SMT org in Oid)
                {
                    objmail.SendingMail(org.USEREMAIL, "Smart Labour  - New Labour", org.USEREMAIL, "", "", "New User with Emirates ID ( " + EmiratesId + " )   has been created successfully in your organisation !.");
                }
                objmail.SendingMail(LabourEmail, "Welcome To Smart Labour ", LabourEmail, "", "", "Your account has been created successfully !.");
                DataSet ds = objTransDB.ExecuteDataSet("SMT_SP_LogCreation", 1, "", "", "Success", EmiratesId, 0, 0, "", "");
            }
            catch (Exception Ex)
            {
                DataSet ds = objTransDB.ExecuteDataSet("SMT_SP_LogCreation", 1, Ex.InnerException.ToString(), Ex.StackTrace.ToString(), "Exception_Mail", EmiratesId, 0, 0, "", "");
            }

        }

        /// <summary>
        /// Run a Send Mail Task 
        /// </summary>
        /// <param name="OrgId"></param>
        /// <param name="EmiratesId"></param>
        /// <param name="LabourEmail"></param>
        public void SendMailToSubAdmin(int OrgId, string EmiratesId, string LabourEmail)
        {
            // Task_SendMailToSubAdmin();
            Task t2 = Task.Factory.StartNew(() => Task_SendMailToSubAdmin(OrgId, EmiratesId, LabourEmail));
        }

        public void mSendMailToSubAdmin(string LabourEmail)
        {
            // Task_SendMailToSubAdmin();
            Task t2 = Task.Factory.StartNew(() => mTask_SendMailToSubAdmin(LabourEmail));
        }

        public static void mTask_SendMailToSubAdmin(string LabourEmail)
        {
            string connString = ConfigurationManager.ConnectionStrings["SmartLabourEntities"].ToString();
            Database objTransDB = new Microsoft.Practices.EnterpriseLibrary.Data.Sql.SqlDatabase(connString);
            SmartLabourEntities Entities = new SmartLabourEntities();
            CommonClass objmail = new CommonClass();
            try
            {
                objmail.SendingMail(LabourEmail, "Welcome To Smart Labour ", LabourEmail, "", "", "Your account has been created successfully !.");
            }
            catch (Exception Ex)
            {
            }

        }

    }
}