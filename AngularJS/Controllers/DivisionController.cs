using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AngularJS.DTO;
using AngularJS.Interface;
using AngularJS.Models;
using AngularJS.ViewModel;

namespace AngularJS.Controllers
{
    public class DivisionController : Controller
    {
        IDivision idivision;
        public DivisionController(IDivision _division)
        {
            idivision = _division;
        }
       
        // GET: Division
        public ActionResult Index()
        {
            return View();
        }
        public JsonResult GetDivisionList()
        {
            try
            {
                List<DivisionDTO> divisionDTO = idivision.GetDivisionList();
                List<DivisionViewModel> divisionViewModel = new List<DivisionViewModel>();
                global::AutoMapper.Mapper.Map(divisionDTO, divisionViewModel);
                return Json(divisionViewModel, JsonRequestBehavior.AllowGet);
            }
            catch(Exception e)
            {
                string result = e.Message;
                return Json(result, JsonRequestBehavior.AllowGet);
            }
        }
        public ActionResult Create()
        {
            return View();
        }
        public JsonResult InsertData(List<DivisionViewModel> divisionViewModel)
        {
            string result = null;
            try
            {
                if(divisionViewModel.Count> 0)
                {
                    result = idivision.InsertDivision(divisionViewModel);
                }
            }
            catch(Exception e)
            {
                result = e.Message;
            }
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        public JsonResult SaveEditedData(List<DivisionDTO> divisionDTO)
        {
            string result=null;
            try
            {
                if(divisionDTO.Count>0)
                {
                    result = idivision.SaveEditedData(divisionDTO);
                }
            }
            catch(Exception e)
            {
                result = e.Message;
            }
            return Json(result, JsonRequestBehavior.AllowGet);
        }
    }
}
