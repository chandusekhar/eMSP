using eMSP.DataModel;
using eMSP.ViewModel.Role;
using eMSP.ViewModel.User;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using eMSP.Data.Extensions;

namespace eMSP.Data.DataServices.Roles
{
    class ManageRole
    {
        #region Initialization

        private static eMSPEntities db;

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

                    //return await Task.Run(() => db.tblUserProfiles.Where(x => x.AspNetUser.Id == UserID)
                    //                                              .Join(db.AspNetRoleGroups,
                    //                                              u => u.RoleGroupId,
                    //                                              rg => rg.Id, (u, rg) => new
                    //                                              {
                    //                                                  RoleGroupId = rg.Id
                    //                                              }).Join(db.AspNetRoleGroupRoles,
                    //                                              r => r.RoleGroupId,
                    //                                              rgr => rgr.RoleGroupId, (r, rgr) => new
                    //                                              {
                    //                                                  rolesId = rgr.RoleId
                    //                                              }).Join(db.AspNetRoles,
                    //                                              ro => ro.rolesId,
                    //                                              b => b.Id, (ro, b) => new UserAuthorization
                    //                                              {
                    //                                                  Name = b.Name
                    //                                              }).ToList());


                   var objlist = db.AspNetUsers.Where(x => x.Id == UserID).SingleOrDefault();

                   return objlist.AspNetRoles.Select(X => new UserAuthorization() { Name=X.Name }).ToList();

                    //return objlist.Select(x=> new UserAuthorization() { Name=})

                    //return await (from profile in db.tblUserProfiles
                    //              join rolegrp in db.AspNetRoleGroups on profile.RoleGroupId equals rolegrp.Id
                    //              join grpRoles in db.AspNetRoleGroupRoles on rolegrp.Id equals grpRoles.RoleGroupId
                    //              join role in db.AspNetRoles on grpRoles.RoleId equals role.Id
                    //              select new UserAuthorization { Name = role.Name }).ToListAsync();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        internal static async Task<UserRolesModel> GetUserRolesn(string UserID)
        {
            try
            {
                using (db = new eMSPEntities())
                {
                    UserRolesModel user = new UserRolesModel();

                    //user.roles = await Task.Run(() => db.tblUserProfiles.Where(x => x.AspNetUser.Id == UserID)
                    //                                              .Join(db.AspNetRoleGroups,
                    //                                              u => u.RoleGroupId,
                    //                                              rg => rg.Id, (u, rg) => new
                    //                                              {
                    //                                                  RoleGroupId = rg.Id
                    //                                              }).Join(db.AspNetRoleGroupRoles,
                    //                                              r => r.RoleGroupId,
                    //                                              rgr => rgr.RoleGroupId, (r, rgr) => new
                    //                                              {
                    //                                                  rolesId = rgr.RoleId
                    //                                              }).Join(db.AspNetRoles,
                    //                                              ro => ro.rolesId,
                    //                                              b => b.Id, (ro, b) => new RoleModel
                    //                                              {
                    //                                                  id = b.Id,

                    //                                                  Name = b.Name
                    //                                              }).ToList());

                    var objlist = db.AspNetUsers.Where(x => x.Id == UserID).SingleOrDefault();

                    user.roles= objlist.AspNetRoles.Select(X => new RoleModel() { Name = X.Name,id=X.Id }).ToList();


                    //user.roles = await (from profile in db.tblUserProfiles
                    //                    join rolegrp in db.AspNetRoleGroups on profile.RoleGroupId equals rolegrp.Id
                    //                    join grpRoles in db.AspNetRoleGroupRoles on rolegrp.Id equals grpRoles.RoleGroupId
                    //                    join role in db.AspNetRoles on grpRoles.RoleId equals role.Id
                    //                    select new RoleModel { id = role.Id, Name = role.Name }).ToListAsync();

                    //db.AspNetRoleGroupRoles.Where(x=>x.RoleGroupId==)

                    tblUserProfile up = db.tblUserProfiles.Where(a => a.UserID == UserID)
                                                  .Include(a => a.tblCountry)
                                                  .Include(a => a.tblCountryState)
                                                  .SingleOrDefault();
                    user.user = new UserModel();

                    user.user.user = up.ConvertToUser();
                    user.user.userId = UserID;

                    long mspId = db.tblUserProfiles.Where(x => x.AspNetUser.Id == UserID).Join(db.tblMSPUsers, u => u.UserID, rg => rg.UserID, (l, r) => new { l, r }).Select(b => b.r.MSPID).FirstOrDefault();
                    long supId = db.tblUserProfiles.Where(x => x.AspNetUser.Id == UserID).Join(db.tblSupplierUsers, u => u.UserID, rg => rg.UserID, (l, r) => new { l, r }).Select(b => b.r.SupplierID).FirstOrDefault();
                    long cutId = db.tblUserProfiles.Where(x => x.AspNetUser.Id == UserID).Join(db.tblCustomerUsers, u => u.UserID, rg => rg.UserID, (l, r) => new { l, r }).Select(b => b.r.CustomerID).FirstOrDefault();

                    if (mspId != 0)
                    {
                        user.user.companyId = mspId;
                        user.user.companyType = "MSP";
                    }
                    else if (supId != 0)
                    {
                        user.user.companyId = supId;
                        user.user.companyType = "Supplier";
                    }
                    else if (supId != 0)
                    {
                        user.user.companyId = cutId;
                        user.user.companyType = "Customer";
                    }

                    return user;
                }
            }
            catch (Exception ex)
            {
                throw ex;
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
        internal static async Task UpdateRoleGroup(AspNetRoleGroup model)
        {
            try
            {
                using (db = new eMSPEntities())
                {
                    db.Entry(model).State = EntityState.Modified;

                    int x = await Task.Run(() => db.SaveChangesAsync());
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion

        #region Delete

        internal static async Task DeleteRoleGroup(string Id)
        {
            try
            {
                using (db = new eMSPEntities())
                {
                    AspNetRoleGroup roleGroup = db.AspNetRoleGroups.FirstOrDefault(a => a.Id == Id);

                    db.AspNetRoleGroups.Remove(roleGroup);                    
                    int x = await Task.Run(() => db.SaveChangesAsync());

                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        internal static async Task DeleteRoleGroupRoles(string Id)
        {
            try
            {
                using (db = new eMSPEntities())
                {
                    List<AspNetRoleGroupRole> roleGroup = db.AspNetRoleGroupRoles.Where(a => a.RoleGroupId == Id).ToList();
                    roleGroup.ForEach(a => db.AspNetRoleGroupRoles.Remove(a));                    
                    int x = await Task.Run(() => db.SaveChangesAsync());

                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion
    }
}
