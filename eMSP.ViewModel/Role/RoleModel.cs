using eMSP.DataModel;
using eMSP.ViewModel.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace eMSP.ViewModel.Role
{
    public class RoleModel
    {
        public RoleModel() { }
        public string id { get; set; }
        public string Name { get; set; }
    }

    public class RoleGroupModel
    {
        public RoleGroupModel() { }
        public string id { get; set; }
        public string roleGroupName { get; set; }
    }

    public class RoleGroupRolesModel
    {
        public RoleGroupRolesModel() { }
        public RoleGroupModel roleGroup { get; set; }
        public List<RoleModel> roles { get; set; }
    }

    public class UserRolesModel
    {
        public UserRolesModel() { }
        public UserModel user { get; set; }
        public List<RoleModel> roles { get; set; }
        
    }
    public class UserAuthorization
    {
        public UserAuthorization() { }
        public string Name { get; set; }
    }

    public class UserRoleGrupDetails
    {
        public UserRoleGrupDetails() { }
        public string UserId { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string ProfilePic { get; set; }
        public string RoleId { get; set; }
        public string RoleName { get; set; }
        public long MspId { get; set; }
        public long CustomerId { get; set; }
        public long SupplierId { get; set; }
    }
}
