using AngularJS.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AngularJS.AutoMapper;
using AngularJS.DTO;
using AngularJS.Models;
using AngularJS.Service;
using AngularJS.ViewModel;
using System.Data.Entity;

namespace AngularJS.Service
{
    public class DivisionService : IDivision
    {
        private readonly AngularJSEntities db = new AngularJSEntities();
        public List<DivisionDTO> GetDivisionList()
        {
            List<DivisionDTO> divisionDTO = db.Divisions.Select(x => new DivisionDTO { DivisionId = x.DivisionId, DivisionName = x.DivisionName }).ToList();
            return divisionDTO;
        }
        public string InsertDivision(List<DivisionViewModel> divisionViewModel)
        {
            List<Division> division = new List<Division>();
            string result = null;
            try
            {
                if(divisionViewModel.Count>0)
                {
                    global::AutoMapper.Mapper.Map(divisionViewModel, division);
                    db.Divisions.AddRange(division);
                    db.SaveChanges();
                    result = "Successfully inserted";
                }
            }
            catch(Exception e)
            {
                result = e.Message;
            }
            return result;
        }

        public string SaveEditedData(List<DivisionDTO> divisionDTO)
        {
            string result = null;
            try
            {
                if (divisionDTO.Count > 0) {
                    List<Division> division = new List<Division>();
                    global::AutoMapper.Mapper.Map(divisionDTO, division);
                    if (division.Count > 0)
                    {
                        foreach (var item in division)
                        {
                            db.Entry(item).State = EntityState.Modified;
                            db.SaveChanges();
                        }
                        result = "Successfully Edited";
                    }
                }
            }
            catch(Exception e)
            {
                result = e.Message;
            }
            return result;
        }
    }
}