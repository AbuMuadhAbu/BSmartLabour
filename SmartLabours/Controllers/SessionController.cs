using SmartLabours.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SmartLabours.Controllers
{
    public class SessionController : Controller
    {
        CommonFunctions objCommon = new CommonFunctions();
        //
        // GET: /Session/

        public ActionResult Index()
        {
            return View();
        }
        public ActionResult AssignSessionHealth(string Id, string Hsid)
          {
              //CultureInfo culture = new CultureInfo("en-US");
              //culture.DateTimeFormat.ShortDatePattern = "dd-MMM-yyyy";
              //culture.DateTimeFormat.DateSeparator = "-";
              //Thread.CurrentThread.CurrentCulture = culture;

              //var DecryptedUserId = Id.Replace("$$$", "/");
              //var encryptedString = Hsid.Replace("$$$", "/");
              //DecryptedUserId = DecryptedUserId.Replace("(((", "=");
              //encryptedString = encryptedString.Replace("(((", "=");
              //DecryptedUserId = DecryptedUserId.Replace(")))", "+");
              //encryptedString = encryptedString.Replace(")))", "+");
            

              string UserId = Common.Encryption.Decrypt(objCommon.UrlDecode(Id), "SmartLabourAdmin");
              string hsid = Common.Encryption.Decrypt(objCommon.UrlDecode(Hsid), "SmartLabourAdmin");

              Session["EmpId"] = UserId;
                if (Session["EmpId"] != null)
                {
                    return RedirectToAction("HealthAndSafetyEdit", "HealthAndSafety", new { HSid = hsid });
                }
                else
                    return null;
        }

    }
}
