using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AngularJS.Models;

namespace AngularJS.Controllers
{
    public class DivisionJsonController : Controller
    {
        private AngularJSEntities db = new AngularJSEntities();
        // GET: DivisionJson
       public JsonResult GetDivisionList()
        {
            var dividionList = db.Divisions.ToList();
            return Json(dividionList, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult InsertData(Division division)
        {
            string result ;
            try
            {
                db.Divisions.Add(division);
                db.SaveChanges();
                result="success";
            }
            catch(Exception) 
            {
                result = "failed";
            }
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult GetDivisionById(int id)
        {
            var getDivision = db.Divisions.Where(x => x.DivisionId == id).FirstOrDefault();
            return Json(getDivision, JsonRequestBehavior.AllowGet);
        }
    }
}