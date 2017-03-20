using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace SmartLabours.Common
{
    public class DataAccess
    {
        string connectionString = ConfigurationManager.ConnectionStrings["SmartLabourEntities"].ToString();

        public void dbSample()
        {
            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand command = new SqlCommand("Pro_AcceptPhone", connection)
            {
                CommandType = CommandType.StoredProcedure
            };
            command.Parameters.Add(new SqlParameter("@LabourId", 12));
            command.Parameters.Add(new SqlParameter("@IsPhoneAccepted", Convert.ToBoolean(1)));
            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();
            command.Dispose();
            connection.Dispose();

        }

        /// <summary>
        /// GetQuestionList
        /// </summary>
        /// <returns></returns>
        public DataTable GetQuestionList(int UserId)
        {
            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(connectionString);
            string cmdText = "PROC_MULTIPLEQUESTION";
            SqlCommand command = new SqlCommand(cmdText, connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@UserId", UserId);
            command.Connection = connection;
            using (SqlDataAdapter sda = new SqlDataAdapter(command))
            {
                sda.Fill(dt);
            }
            return dt;
        }

        /// <summary>
        /// GetAllCourseList
        /// </summary>
        /// <param name="CourseTypeId"></param>
        /// <param name="Labourid"></param>
        /// <returns></returns>
        public DataSet GetAllCourseList(string CourseTypeId, string Labourid)
        {
            DataSet ds = new DataSet();
            SqlConnection connection = new SqlConnection(connectionString);
            string cmdText = "SMT_SP_GetAllCourseStatus";
            SqlCommand command = new SqlCommand(cmdText, connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@CourseTypeId", CourseTypeId);
            command.Parameters.AddWithValue("@LabourId", Labourid);
            command.Connection = connection;
            using (SqlDataAdapter sda = new SqlDataAdapter(command))
            {
                sda.Fill(ds);
            }
            return ds;
        }

        public DataTable UpdateNotificationIsRead(string LabourID, string Type,string TransactionID)
        {
            DataSet ds = new DataSet();
            SqlConnection connection = new SqlConnection(connectionString);
            string cmdText = "spSM_UpdateNotificationIsRead";
            SqlCommand command = new SqlCommand(cmdText, connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@pLabourID", LabourID);
            command.Parameters.AddWithValue("@pType", Type);
            command.Parameters.AddWithValue("@pTransactionID", TransactionID);
            command.Connection = connection;
            using (SqlDataAdapter sda = new SqlDataAdapter(command))
            {
                sda.Fill(ds);
            }
            return ds.Tables[0];
        }

        public DataSet GetLangPreference(string CourseTypeId, string Labourid, string LangPreference)
        {
            DataSet ds = new DataSet();
            SqlConnection connection = new SqlConnection(connectionString);
            string cmdText = "spSL_GetLangPreference";
            SqlCommand command = new SqlCommand(cmdText, connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@CourseTypeId", CourseTypeId);
            command.Parameters.AddWithValue("@LabourId", Labourid);
            command.Parameters.AddWithValue("@LangPreference", LangPreference);
            command.Connection = connection;
            using (SqlDataAdapter sda = new SqlDataAdapter(command))
            {
                sda.Fill(ds);
            }
            return ds;
        }

        /// <summary>
        /// InsertHealthAndSafety
        /// </summary>
        /// <param name="LabourId"></param>
        /// <param name="ImagePath"></param>
        /// <param name="AudioPath"></param>
        /// <param name="comments"></param>
        /// <returns></returns>
        public DataTable InsertHealthAndSafety(string LabourId, string ImagePath, string AudioPath, string comments)
        {
            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(connectionString);
            string cmdText = "SMT_SP_HealthAndSafety";
            SqlCommand command = new SqlCommand(cmdText, connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@LabourId", LabourId);
            command.Parameters.AddWithValue("@ImagePath", ImagePath);
            command.Parameters.AddWithValue("@AudioPath", AudioPath);
            command.Parameters.AddWithValue("@Comments", comments);
            command.Parameters.AddWithValue("@Mode", 1);
            command.Connection = connection;
            using (SqlDataAdapter sda = new SqlDataAdapter(command))
            {
                sda.Fill(dt);
            }
            return dt;
        }

        public DataTable InsertHealthAndSafetyReport(string LabourId, string ImagePath, string AudioPath, string comments, string ReportParamterType)
        {
            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(connectionString);
            string cmdText = "SMT_SP_HealthAndSafety";
            SqlCommand command = new SqlCommand(cmdText, connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@LabourId", LabourId);
            command.Parameters.AddWithValue("@ImagePath", ImagePath);
            command.Parameters.AddWithValue("@AudioPath", AudioPath);
            command.Parameters.AddWithValue("@Comments", comments);
            command.Parameters.AddWithValue("@Mode", 1);
            command.Parameters.AddWithValue("@ReportParamterType", ReportParamterType);
            command.Connection = connection;
            using (SqlDataAdapter sda = new SqlDataAdapter(command))
            {
                sda.Fill(dt);
            }
            return dt;
        }


        /// <summary>
        /// GetHealthAndSafetyList
        /// </summary>
        /// <param name="UserId"></param>
        /// <returns></returns>
        public DataTable GetHealthAndSafetyList(int UserId)
        {
            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(connectionString);
            string cmdText = "SMT_SP_HealthAndSafety";
            SqlCommand command = new SqlCommand(cmdText, connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@userId", UserId);
            command.Parameters.AddWithValue("@Mode", 2);
            command.Connection = connection;
            using (SqlDataAdapter sda = new SqlDataAdapter(command))
            {
                sda.Fill(dt);
            }
            return dt;
        }

        /// <summary>
        /// GetOrgDetails
        /// </summary>
        /// <returns></returns>
        public DataTable GetOrgDetails()
        {
            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(connectionString);
            string cmdText = "SL_SP_GetOrgDetails";
            SqlCommand command = new SqlCommand(cmdText, connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Connection = connection;
            using (SqlDataAdapter sda = new SqlDataAdapter(command))
            {
                sda.Fill(dt);
            }
            return dt;
        }


        /// <summary>
        /// GetExportLabours
        /// </summary>
        /// <returns></returns>
        public DataTable GetExportLabours(DateTime? FromDate, DateTime? Todate, int OrgId, int Mode)
        {
            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(connectionString);
            string cmdText = "SMT_SP_GetExportLabours";
            SqlCommand command = new SqlCommand(cmdText, connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@FromDate", FromDate);
            command.Parameters.AddWithValue("@ToDate", Todate);
            command.Parameters.AddWithValue("@OrgId", OrgId);
            command.Parameters.AddWithValue("@Mode", Mode);
            command.CommandType = CommandType.StoredProcedure;
            command.Connection = connection;
            using (SqlDataAdapter sda = new SqlDataAdapter(command))
            {
                sda.Fill(dt);
            }
            return dt;
        }

    }
}