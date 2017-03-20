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

namespace SmartLabours.Controllers
{
    [AuthorizeUser]
    public class PhoneRequestHistoryKendoController : BaseController
    {
        private SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["SmartLabourEntities"].ToString());
        //
        // GET: /PhoneRequestHistoryKendo/

        public ActionResult PhoneRequestHistory()
        {
            base.TempData["currentgetidss"] = "PhoneDetails";
            return View();
        }
        public string RequestHistory()
        {
            int UId = Convert.ToInt32(Session["USERID"].ToString());
            DynamicParameters param = new DynamicParameters();
            param.Add("@UserId", UId);
            var multi = con.Query<dynamic>("pro_RequestPhone_List", param, commandType: CommandType.StoredProcedure);
            return JsonConvert.SerializeObject(multi.ToList());
        }


    }
}
