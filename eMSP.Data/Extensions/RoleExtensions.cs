using eMSP.DataModel;
using eMSP.ViewModel.Role;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eMSP.Data.Extensions
{
    public static class RoleExtensions
    {
        public static AspNetRole ConvertToAspNetRole(this RoleModel data)
        {
            return new AspNetRole()
            {
                Id =data.id,
                Name = data.Name                
            };
        }

        public static RoleModel ConvertToRole(this AspNetRole data)
        {
            return new RoleModel()
            {
                id = data.Id,
                Name = data.Name
            };
        }

        public static AspNetRoleGroup ConvertToAspNetRoleGroup(this RoleGroupModel data)
        {
            return new AspNetRoleGroup()
            {
                Id = data.id,
                Name = data.roleGroupName
            };
        }

        public static RoleGroupModel ConvertToRoleGroup(this AspNetRoleGroup data)
        {
            return new RoleGroupModel()
            {
                id = data.Id,
                roleGroupName = data.Name
            };
        }
    }
}
