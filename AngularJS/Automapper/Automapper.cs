using AngularJS.DTO;
using AngularJS.Interface;
using AngularJS.Models;
using AngularJS.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AngularJS.AutoMapper
{
    public class Automapper: global::AutoMapper.Profile
    {
        [Obsolete]
        public static void Run()
        {
            global::AutoMapper.Mapper.Initialize( a =>
            {
                a.AddProfile<Automapper>();
                });
        }
        public Automapper()
        {
            CreateMap<UserDTO, UserViewModel>();
            CreateMap<UserViewModel, UserDTO>();
            CreateMap<DivisionDTO, DivisionViewModel>();
            CreateMap<DivisionViewModel, DivisionDTO>();
            CreateMap<DistrictDTO, DistrictViewModel>();
            CreateMap<DistrictViewModel, DistrictDTO>();
            CreateMap<UserViewModel, UserInfo>();
            CreateMap<UserInfo,UserViewModel>();
        }
    }
}