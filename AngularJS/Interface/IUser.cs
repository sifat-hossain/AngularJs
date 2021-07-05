using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AngularJS.DTO;
using AngularJS.Service;
using AngularJS.ViewModel;

namespace AngularJS.Interface
{
    public interface IUser
    {
        List<UserDTO> GetUser();
        List<DivisionDTO> GetDivision();
        List<DistrictDTO> GetDistrict(int divisionId);
        string SaveData(List<UserViewModel> userViewModel);
        UserDTO GetUserByPhone(string number);
        string EditedData(List<UserViewModel> userViewModel);
    }
}
