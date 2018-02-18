using eMSP.DataModel;
using eMSP.ViewModel.Role;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eMSP.Data.DataServices.Roles
{
    class ManageRole
    {
        #region Initialization

        internal static eMSPEntities db;

        static ManageRole()
        {

        }

        #endregion

        #region Get

        internal static async Task<List<UserAuthorization>> GetUserRoles(string UserID)
        {
            try
            {
                using (db = new eMSPEntities())
                {

                    return await Task.Run(() => db.tblUserProfiles.Where(x => x.AspNetUser.Id == UserID)
                                                                  .Join(db.AspNetRoleGroups,
                                                                  u => u.RoleGroupId,
                                                                  rg => rg.Id, (u, rg) => new
                                                                  {
                                                                      RoleGroupId = rg.Id
                                                                  }).Join(db.AspNetRoleGroupRoles,
                                                                  r => r.RoleGroupId,
                                                                  rgr => rgr.RoleGroupId, (r, rgr) => new
                                                                  {
                                                                      rolesId = rgr.RoleId
                                                                  }).Join(db.AspNetRoles,
                                                                  ro => ro.rolesId,
                                                                  b => b.Id, (ro, b) => new UserAuthorization
                                                                  {
                                                                      Name = b.Name
                                                                  }).ToList());
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        internal static async Task<AspNetRoleGroup> GetRoleGroup(string Id)
        {
            try
            {
                using (db = new eMSPEntities())
                {
                    return await Task.Run(() => db.AspNetRoleGroups.Where(x => x.Id == Id).SingleOrDefault());
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        internal static async Task<List<AspNetRoleGroup>> GetAllRoleGroup()
        {
            try
            {
                using (db = new eMSPEntities())
                {
                    return await Task.Run(() => db.AspNetRoleGroups
                                                  .ToList());
                }
            }
            catch (Exception)
            {
                throw;
            }
        }


        internal static async Task<List<AspNetRole>> GetRoleGroupRoles(string groupId)
        {
            try
            {
                using (db = new eMSPEntities())
                {                    
                    return await Task.Run(() => db.AspNetRoles.Where(y => db.AspNetRoleGroupRoles.Where(x => x.RoleGroupId == groupId)
                                                              .Any(x => x.RoleId == y.Id)).ToList());
                }
            }
            catch (Exception)
            {
                throw;
            }
        }


        #endregion

        #region Insert

        internal static async Task<AspNetRoleGroup> InsertRoleGroup(AspNetRoleGroup model)
        {
            try
            {
                using (db = new eMSPEntities())
                {
                    var roleGroup = db.AspNetRoleGroups.Add(model);
                    int x = await Task.Run(() => db.SaveChangesAsync());

                    return roleGroup;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        internal static async Task<AspNetRoleGroupRole> InsertRoleGroupRoles(AspNetRoleGroupRole model)
        {
            try
            {
                using (db = new eMSPEntities())
                {
                    var roleGroup = db.AspNetRoleGroupRoles.Add(model);
                    int x = await Task.Run(() => db.SaveChangesAsync());

                    return roleGroup;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        //internal static async Task<AspNetRoleGroupRole> InsertUserRole(AspNetUser model)
        //{
        //    try
        //    {
        //        using (db = new eMSPEntities())
        //        {
        //            var roleGroup = db.AspNetRoleGroupRoles.Add(model);
        //            int x = await Task.Run(() => db.SaveChangesAsync());

        //            return roleGroup;
        //        }
        //    }
        //    catch (Exception)
        //    {
        //        throw;
        //    }
        //}

        #endregion

        #region Update


        #endregion

        #region Delete



        #endregion
    }
}
