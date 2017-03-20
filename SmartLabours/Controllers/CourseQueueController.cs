using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SmartLabours.Models;
using System.Configuration;
using Dapper;
using System.Data;
using System.Data.SqlClient;
using Newtonsoft.Json;
using Microsoft.Practices.EnterpriseLibrary.Data;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;

namespace SmartLabours.Controllers
{
    [AuthorizeUser]
    public class CourseQueueController : BaseController
    {
        //
        // GET: /CourseQueue/
        private static DatabaseProviderFactory _factory = new DatabaseProviderFactory();
        private Database _db = _factory.Create("SmartLabourEntities");
        private SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["SmartLabourEntities"].ToString());
        public ActionResult CourseQueue()
        {
            return View();
        }
        public string GetCourseQueues(string CourseTypeID, string OrgID, string Language,string CategoryId,string SubCategoryId)
        {
            int UId = Convert.ToInt32(Session["USERID"].ToString());
            DynamicParameters param = new DynamicParameters();
            param.Add("@OrgId", Convert.ToInt32(OrgID));
            param.Add("@CourseTypeID", Convert.ToInt32(CourseTypeID));
            param.Add("@Language", Language);
            param.Add("@CategoryId", Convert.ToInt32(CategoryId));
            param.Add("@SubCategoryId", Convert.ToInt32(SubCategoryId));
            var multi = con.Query<dynamic>("spSL_GetCourseQueues", param, commandType: CommandType.StoredProcedure);
            return JsonConvert.SerializeObject(multi.ToList());
        }
        public string GetOrganization()
        {
            int UId = Convert.ToInt32(Session["USERID"].ToString());
            DynamicParameters param = new DynamicParameters();
            var multi = con.Query<dynamic>("spSL_OrganisationMaster", param, commandType: CommandType.StoredProcedure);
            return JsonConvert.SerializeObject(multi.ToList());
        }
        public string GetCategoryMaster(string OrgID)
        {
            int UId = Convert.ToInt32(Session["USERID"].ToString());
            DynamicParameters param = new DynamicParameters();
            param.Add("@OrgId", Convert.ToInt32(OrgID));
            var multi = con.Query<dynamic>("spSL_CategoryMaster", param, commandType: CommandType.StoredProcedure);
            return JsonConvert.SerializeObject(multi.ToList());
        }
        public string GetSubCategoryMaster(string CategoryId)
        {
            int UId = Convert.ToInt32(Session["USERID"].ToString());
            DynamicParameters param = new DynamicParameters();
            param.Add("@CategoryId", Convert.ToInt32(CategoryId));
            var multi = con.Query<dynamic>("spSL_SubCategoryMaster", param, commandType: CommandType.StoredProcedure);
            return JsonConvert.SerializeObject(multi.ToList());
        }


        public JsonResult SaveCourseOrder(QueueModel QueuePriorityOrder)
        {
            DataTable dtblQueuePriority = new DataTable();
            dtblQueuePriority.Columns.Add("CourseID", Type.GetType("System.Int32"));
            dtblQueuePriority.Columns.Add("QueueOrder", Type.GetType("System.Int32"));
            foreach (var arr in QueuePriorityOrder.queuePriorityOrder)
            {
                DataRow dr = dtblQueuePriority.NewRow();
                dr["CourseID"] = Convert.ToInt32(arr.CourseID[0].ToString());
                dr["QueueOrder"] = Convert.ToInt32(arr.QueueOrder[0].ToString());
                dtblQueuePriority.Rows.Add(dr);
            }
            using (var sqlCmd = _db.GetStoredProcCommand("dbo.spSL_UpdateCourseOrder"))
            {
                var db = (SqlDatabase)_db;
                db.AddInParameter(sqlCmd, "@pCourseOrder", SqlDbType.Structured, dtblQueuePriority);
                _db.ExecuteNonQuery(sqlCmd);
            }
            return Json("");
        }

    }
}
