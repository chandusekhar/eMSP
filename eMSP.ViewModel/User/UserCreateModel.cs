using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using eMSP.DataModel;
using eMSP.ViewModel.MSP;
using eMSP.ViewModel.Role;
using eMSP.ViewModel.Shared;

namespace eMSP.ViewModel.User
{
    public class UserModel: BaseModel
    {
        public UserModel() { }
        public string userId { get; set; }
        public long companyId { get; set; }
        public long companyUserId { get; set; }
        public UserCreateModel user { get; set; }

        public string companyType { get; set; }
    }
    public class UserCreateModel : UserModel
    {
        public UserCreateModel() { }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string address { get; set; }
        public string emailAddress { get; set; }
        public string city { get; set; }
        public long? countryId { get; set; }
        public string country { get; set; }
        public long? stateId { get; set; }
        public string state { get; set; }
        public int? timeZoneId { get; set; }
        public string roleGroupId { get; set; }
        public string userProfilePhotoPath { get; set; }
        public string zipCode { get; set; }

    }

    public class UserRoleModel
    {
        public UserRoleModel() { }
        public UserCreateModel user { get; set; }
        public RoleGroupModel roleGroup { get; set; }
    }
}
