using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AngularJS.Models;
using AngularJS.DTO;
using AngularJS.Interface;
using AngularJS.ViewModel;
using System.Data.Entity;

namespace AngularJS.Service
{
    public class UserService:IUser
    {
        readonly AngularJSEntities db = new AngularJSEntities();

        public string EditedData(List<UserViewModel> userViewModel)
        {
            string result=null ;
            List<UserInfo> userInfo = new List<UserInfo>();
            global::AutoMapper.Mapper.Map(userViewModel, userInfo);
            try
            {
                if (userInfo != null)
                {
                    foreach (var item in userInfo)
                    {
                        db.Entry(item).State = EntityState.Modified;
                    }
                    db.SaveChanges();
                    result = "successfully Modified the data";
                }
            }
           catch(Exception e)
            {
                result = e.Message;
            }
            return result;
        }

        

        public List<DistrictDTO> GetDistrict(int divisionId)
        {
            List<DistrictDTO> districtDTOs = db.Districts.Where(x => x.DivisionId == divisionId).Select(x => new DistrictDTO { DistrictId = x.DistrictId, DistrictName = x.DistrictName }).ToList();
            return districtDTOs;
        }

        public List<DivisionDTO> GetDivision()
        {
            List<DivisionDTO> divisionDTOs = db.Divisions.Select(x => new DivisionDTO { DivisionId = x.DivisionId, DivisionName = x.DivisionName }).ToList();
            return divisionDTOs;
        }

        public List<UserDTO> GetUser()
        {          

            List<UserDTO> userDTOs = db.UserInfoes.Select(x => new UserDTO { DivisionId=x.District.DivisionId,DistrictId=x.DistrictId, DistrictName = x.District.DistrictName, Phone=x.Phone, UserId=x.UserId, UserName=x.UserName }).ToList();

            return userDTOs;
        }

        public UserDTO GetUserByPhone(string number)
        {
            UserDTO userDTOs = db.UserInfoes.Where(x => x.Phone == number).Select(x => new UserDTO { UserName = x.UserName, DistrictName = x.District.DistrictName, Phone = x.Phone, DivisionName = x.District.Division.DivisionName }).FirstOrDefault();
            return userDTOs;
        }

        public string SaveData(List<UserViewModel> userViewModel)
        {
           string result=null;
            List<UserInfo> userInfo = new List<UserInfo>();
            global::AutoMapper.Mapper.Map(userViewModel, userInfo);
            try
            {
                if (userInfo != null)
                {
                    db.UserInfoes.AddRange(userInfo);
                    db.SaveChanges();
                    result = "Successfully Inserted";
                }
            }
            catch (ArgumentNullException)
            {
                result = "Failed";
            }
            catch (NullReferenceException) {
                result = "Object Is null";
            }


            return result;
        }
    }
}