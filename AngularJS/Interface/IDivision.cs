using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AngularJS.DTO;
using AngularJS.ViewModel;

namespace AngularJS.Interface
{
   public interface IDivision
    {
        List<DivisionDTO> GetDivisionList();
        string InsertDivision(List<DivisionViewModel> divisionViewModel);
        string SaveEditedData(List<DivisionDTO> divisionDTO);
    }
}
