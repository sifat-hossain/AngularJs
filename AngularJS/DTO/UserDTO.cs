using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AngularJS.DTO
{
    public class UserDTO
    {
        public int UserId { get; set; }
        public string Phone { get; set; }
        public string DistrictName { get; set; }
        public int DistrictId { get; set; }
        public string UserName { get; set; }
        public int  DivisionId { get; set; }
        public string DivisionName { get; set; }
    }
}