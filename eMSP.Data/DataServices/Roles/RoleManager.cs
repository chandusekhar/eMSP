using eMSP.DataModel;
using eMSP.ViewModel.Role;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using eMSP.Data.Extensions;

namespace eMSP.Data.DataServices.Roles
{
    public class RoleManager
    {
        #region Initialization

        public RoleManager()
        {

        }

        #endregion

        #region Get

        //Get User roles List
        public async Task<List<UserAuthorization>> GetUserRoles(string UserID)
        {
            try
            {
                return await Task.Run(() => ManageRole.GetUserRoles(UserID));
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<UserRolesModel> GetUserRolesn(string UserID)
        {
            try
            {
                return await Task.Run(() => ManageRole.GetUserRolesn(UserID));
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<RoleGroupModel> GetRoleGroup(string id)
        {
            try
            {                
                AspNetRoleGroup data = await Task.Run(() => ManageRole.GetRoleGroup(id));
                return data.ConvertToRoleGroup();
            }
            catch (Exception)
            {
                throw;
            }
        }


        public async Task<List<RoleGroupModel>> GetAllRoleGroup()
        {
            try
            {
                List<AspNetRoleGroup> data = await Task.Run(() => ManageRole.GetAllRoleGroup());
                return data.Select(x => x.ConvertToRoleGroup()).ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<List<RoleModel>> GetRoleGroupRoles(string id)
        {
            try
            {
                List<AspNetRole> data = await Task.Run(() => ManageRole.GetRoleGroupRoles(id));
                return data.Select(x => x.ConvertToRole()).ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<List<RoleGroupRolesModel>> GetAllRoleGroupRoles()
        {
            List<RoleGroupRolesModel> rgr = new List<RoleGroupRolesModel>();
            try
            {
                List<AspNetRoleGroup> data = await Task.Run(() => ManageRole.GetAllRoleGroup());
                List<RoleGroupModel> datarg = data.Select(x => x.ConvertToRoleGroup()).ToList();

                foreach(RoleGroupModel rg in datarg)
                {
                    List<AspNetRole> roles = await Task.Run(() => ManageRole.GetRoleGroupRoles(rg.id));
                    rgr.Add(new RoleGroupRolesModel() { roleGroup = rg, roles = roles.Select(x => x.ConvertToRole()).ToList() });
                }

                
                return rgr;
            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion

        #region Insert

        public async Task<RoleGroupModel> CreateRoleGroup(RoleGroupModel model)
        {
            try
            {
                AspNetRoleGroup data = await Task.Run(() => ManageRole.InsertRoleGroup(model.ConvertToAspNetRoleGroup()));
                return data.ConvertToRoleGroup();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<RoleGroupRolesModel> CreateRoleGroupRoles(RoleGroupRolesModel model)
        {
            try
            {
                foreach (RoleModel  r in model.roles)
                {
                    AspNetRoleGroupRole data = new AspNetRoleGroupRole();
                    data.RoleGroupId = model.roleGroup.id;
                    data.RoleId = r.id;
                    AspNetRoleGroupRole res = await Task.Run(() => ManageRole.InsertRoleGroupRoles(data));
                }
                
                return model;
            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion

        #region Update

        public async Task<RoleGroupRolesModel> UpdateRoleGroupRoles(RoleGroupRolesModel model)
        {
            try
            {
                await Task.Run(() => ManageRole.UpdateRoleGroup(model.roleGroup.ConvertToAspNetRoleGroup()));
                await Task.Run(() => ManageRole.DeleteRoleGroupRoles(model.roleGroup.id));
                foreach (RoleModel r in model.roles)
                {
                    AspNetRoleGroupRole data = new AspNetRoleGroupRole();
                    data.RoleGroupId = model.roleGroup.id;
                    data.RoleId = r.id;
                    AspNetRoleGroupRole res = await Task.Run(() => ManageRole.InsertRoleGroupRoles(data));
                }

                return model;
            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion

        #region Delete

        public async Task DeleteRoleGroupRoles(string Id)
        {
            try
            {
                await Task.Run(() => ManageRole.DeleteRoleGroup(Id));
                await Task.Run(() => ManageRole.DeleteRoleGroupRoles(Id));
                
            }
            catch (Exception)
            {
                throw;
            }
        }



        #endregion

        #region Dispose


        #endregion
    }
}
