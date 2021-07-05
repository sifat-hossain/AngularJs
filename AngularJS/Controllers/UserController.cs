using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AngularJS.Interface;
using AngularJS.Models;
using AngularJS.Service;
using AngularJS.AutoMapper;
using AngularJS.DTO;
using AngularJS.ViewModel;

namespace AngularJS.Controllers
{
    public class UserController : Controller
    {
        private AngularJSEntities db = new AngularJSEntities();
        readonly IUser iuser;
        public UserController(IUser userService)
        {
            iuser = userService;
        }
        // GET: User

        public ActionResult Index()
        {
            return View();
        }
        /*Get User List by Calling GetUser method in IUser
         * After getting tha Userlist store it in userDTO object
         * Map the userDTO to the userViewModel
         * Send the userViewModel to the view
         */
        [HttpGet]
        public JsonResult GetUserList()
        {

            List<UserDTO> userDTOs = iuser.GetUser();

            List<UserViewModel> userViewModels = new List<UserViewModel>();

            global::AutoMapper.Mapper.Map(userDTOs, userViewModels);

            return Json(userViewModels, JsonRequestBehavior.AllowGet);
        }
        //create view
        public ActionResult Create()
        {
            return View();
        }
        /* this method is called for getting the Division list
         * After getting the data store it in divisionDTOs
         * map the divisionDTOs with divisionViewModel
         * return the divisionViewModel
         */
        [HttpGet]
        public JsonResult GetDivision()
        {
            List<DivisionDTO> divisionDTOs = iuser.GetDivision();
            List<DivisionViewModel> divisionViewModels = new List<DivisionViewModel>();
            global::AutoMapper.Mapper.Map(divisionDTOs, divisionViewModels);
            return Json(divisionViewModels, JsonRequestBehavior.AllowGet);
        }
        /* this method is called for getting the District List by changing the Division
        * After getting the data store it in divisionDTOs
        * map the divisionDTOs with districtViewModels
        * return the districtViewModels
        */
        [HttpGet]
        public JsonResult GetDistrict(int divisionId)
        {
            List<DistrictDTO> districtDTOs = iuser.GetDistrict(divisionId);
            List<DistrictViewModel> districtViewModels = new List<DistrictViewModel>();
            global::AutoMapper.Mapper.Map(districtDTOs, districtViewModels);
            return Json(districtViewModels, JsonRequestBehavior.AllowGet);
        }
        /*Insert the data into user table by calling this method
         * data reicived by userViewModel
         * pass it to the service layer by calling SaveData function
         */
        [HttpPost]
        public JsonResult SaveData(List<UserViewModel> userViewModel)
        {
            string result;
            try
            {

                if (userViewModel.Count > 0)
                {
                    result = iuser.SaveData(userViewModel);
                }
                else
                {
                    // result = "Must Provide At least 1 User Record";
                    throw new Exception("Must Provide At least 1 User Record");
                }

            }
            catch (Exception e)
            {
                result = e.Message;
            }
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        /* this method is used for check whether the phone number is duplicate or not
         * it search the phone number is exist or not in database
         */
        [HttpGet]
        public JsonResult SearchData(string number)
        {
            UserDTO userDTOs = iuser.GetUserByPhone(number);
            UserViewModel userViewModels = new UserViewModel();
            global::AutoMapper.Mapper.Map(userDTOs, userViewModels);
            return Json(userViewModels, JsonRequestBehavior.AllowGet);
        }

        /* this method is used for edit the data
         * after geting the edited data send it to the service layer by calling EditedData function
         */
        [HttpPost]
        public JsonResult EditedData(List<UserViewModel> userViewModel)
        {
            string result = null;
            try
            {
                if (userViewModel != null)
                {
                    result = iuser.EditedData(userViewModel);
                }
            }
            catch (Exception e)
            {
                result = e.Message;
            }
            return Json(result, JsonRequestBehavior.AllowGet);
        }
    }
}