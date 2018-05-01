using eMSP.Data.Extensions;
using eMSP.DataModel;
using eMSP.ViewModel.User;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eMSP.Data.DataServices.Users
{
    class UserOperations
    {
        #region Initialization

        internal static eMSPEntities db;

        static UserOperations()
        {

        }

        #endregion

        #region Get

        internal static async Task<tblUserProfile> GetUser(string Id)
        {
            try
            {
                using (db = new eMSPEntities())
                {
                    return await Task.Run(() => db.tblUserProfiles.Where(x => x.UserID == Id)
                                                  .Include(a => a.tblCountry)
                                                  .Include(a => a.tblCountryState)
                                                  .SingleOrDefault());
                }
            }
            catch (Exception)
            {
                throw;

            }
        }

        internal static async Task<tblUserProfile> GetUser(string Id, string companyType)
        {


            try
            {
                using (db = new eMSPEntities())
                {

                    switch (companyType)
                    {

                        case "MSP":
                        default:
                            return await Task.Run(() => db.tblUserProfiles
                                                          .Include(a => a.tblMSPUsers)
                                                          .Include(a => a.tblCountry)
                                                          .Include(a => a.tblCountryState)
                                                          .Join(db.tblMSPUsers, a => a.UserID, b => b.UserID, (a, b) => new { a, b })
                                                          .Where(x => x.a.UserID == Id && x.b.IsDeleted == false)
                                                          .Select(x => x.a)
                                                          .SingleOrDefault());

                        case "Customer":
                            return await Task.Run(() => db.tblUserProfiles
                                                          .Include(a => a.tblCustomerUsers)
                                                          .Include(a => a.tblCountry)
                                                          .Include(a => a.tblCountryState)
                                                          .Join(db.tblCustomerUsers, a => a.UserID, b => b.UserID, (a, b) => new { a, b })
                                                          .Where(x => x.a.UserID == Id && x.b.IsDeleted == false)
                                                          .Select(x => x.a)
                                                          .SingleOrDefault());

                        case "Supplier":
                            return await Task.Run(() => db.tblUserProfiles
                                                          .Include(a => a.tblSupplierUsers)
                                                          .Include(a => a.tblCountry)
                                                          .Include(a => a.tblCountryState)
                                                          .Join(db.tblSupplierUsers, a => a.UserID, b => b.UserID, (a, b) => new { a, b })
                                                          .Where(x => x.a.UserID == Id && x.b.IsDeleted == false)
                                                          .Select(x => x.a)
                                                          .SingleOrDefault());




                    }
                }
            }
            catch (Exception)
            {
                throw;

            }



        }

        internal static async Task<List<tblMSPUser>> GetAllMSPUsers(long Id)
        {
            List<tblMSPUser> data = null;

            try
            {
                using (db = new eMSPEntities())
                {


                    data = await Task.Run(() => db.tblMSPUsers
                                                  .Include(a => a.tblUserProfile)
                                                  .Include(a => a.tblUserProfile.tblCountry)
                                                  .Include(a => a.tblUserProfile.tblCountryState)
                                                  .Where(x => x.MSPID == Id && x.IsDeleted == false)
                                                  .Select(x => x)
                                                  .OrderByDescending(x => x.ID)
                                                  .ToList());

                }
            }
            catch (Exception)
            {
                throw;

            }
            return data;
        }

        internal static async Task<List<tblCustomerUser>> GetAllCustomerUsers(long Id)
        {
            List<tblCustomerUser> data = null;

            try
            {
                using (db = new eMSPEntities())
                {


                    data = await Task.Run(() => db.tblCustomerUsers
                                                  .Include(a => a.tblUserProfile)
                                                  .Include(a => a.tblUserProfile.tblCountry)
                                                  .Include(a => a.tblUserProfile.tblCountryState)
                                                  .Where(x => x.CustomerID == Id && x.IsDeleted == false)
                                                  .Select(x => x)
                                                  .OrderByDescending(x => x.ID)
                                                  .ToList());

                }
            }
            catch (Exception)
            {
                throw;

            }
            return data;
        }

        internal static async Task<List<tblSupplierUser>> GetAllSupplierUsers(long Id)
        {
            List<tblSupplierUser> data = null;

            try
            {
                using (db = new eMSPEntities())
                {


                    data = await Task.Run(() => db.tblSupplierUsers
                                                  .Include(a => a.tblUserProfile)
                                                  .Include(a => a.tblUserProfile.tblCountry)
                                                  .Include(a => a.tblUserProfile.tblCountryState)
                                                  .Where(x => x.SupplierID == Id && x.IsDeleted == false)
                                                  .Select(x => x)
                                                  .OrderByDescending(x => x.ID)
                                                  .ToList());

                }
            }
            catch (Exception)
            {
                throw;

            }
            return data;
        }

        internal static async Task<List<UserCreateModel>> GetAllUsers()
        {
            List<tblUserProfile> data = null;
            List<UserCreateModel> res = null;
            try
            {
                using (db = new eMSPEntities())
                {
                    res = new List<UserCreateModel>();
                    data = await db.tblUserProfiles
                                   .Include(a => a.tblMSPUsers)
                                   .Join(db.tblMSPUsers, a => a.UserID, b => b.UserID, (a, b) => new { a, b })
                                   .Where(x => x.b.IsDeleted == false)
                                   .Select(x => x.a)
                                   .OrderByDescending(x => x.UserID).ToListAsync();

                    res.AddRange(data.Select(a => a.ConvertToUser()).ToList());

                    data = await db.tblUserProfiles                                  
                                   .Include(a => a.tblCustomerUsers)
                                   .Join(db.tblCustomerUsers, a => a.UserID, b => b.UserID, (a, b) => new { a, b })
                                   .Where(x => x.b.IsDeleted == false)
                                   .Select(x => x.a)
                                   .OrderByDescending(x => x.UserID)
                                   .ToListAsync();

                    res.AddRange(data.Select(a => a.ConvertToUser()).ToList());



                }
            }
            catch (Exception)
            {
                throw;

            }
            return res;
        }

        internal static async Task<List<tblUserProfile>> GetAllUsers(long Id, string companyType)
        {
            List<tblUserProfile> data = null;

            try
            {
                using (db = new eMSPEntities())
                {
                    switch (companyType)
                    {
                        case "MSP":
                            data = await Task.Run(() => db.tblUserProfiles
                                                          .Include(a => a.tblMSPUsers)
                                                          .Join(db.tblMSPUsers, a => a.UserID, b => b.UserID, (a, b) => new { a, b })
                                                          .Where(x => x.b.MSPID == Id && x.b.IsDeleted == false)
                                                          .Select(x => x.a)
                                                          .OrderByDescending(x => x.UserID)
                                                          .ToList());
                            break;
                        case "Customer":
                            data = await Task.Run(() => db.tblUserProfiles
                                                          .Include(a => a.tblCustomerUsers)
                                                          .Join(db.tblCustomerUsers, a => a.UserID, b => b.UserID, (a, b) => new { a, b })
                                                          .Where(x => x.b.CustomerID == Id && x.b.IsDeleted == false)
                                                          .Select(x => x.a)
                                                          .OrderByDescending(x => x.UserID)
                                                          .ToList());
                            break;
                        case "Supplier":
                            data = await Task.Run(() => db.tblUserProfiles
                                                          .Include(a => a.tblSupplierUsers)
                                                          .Join(db.tblSupplierUsers, a => a.UserID, b => b.UserID, (a, b) => new { a, b })
                                                          .Where(x => x.b.SupplierID == Id && x.b.IsDeleted == false)
                                                          .Select(x => x.a)
                                                          .OrderByDescending(x => x.UserID)
                                                          .ToList());
                            break;
                    }
                }
            }
            catch (Exception)
            {
                throw;

            }
            return data;
        }

        #endregion

        #region Insert

        internal static async Task<tblUserProfile> InsertUser(tblUserProfile model, string companyType, long Id)
        {
            try
            {
                using (db = new eMSPEntities())
                {

                    model = db.tblUserProfiles.Add(model);

                    int x = await Task.Run(() => db.SaveChangesAsync());

                    switch (companyType)
                    {
                        case "MSP":
                            db.tblMSPUsers.Add(ToCompanyUsers(model, companyType, Id));
                            break;
                        case "Customer":
                            db.tblCustomerUsers.Add(ToCompanyUsers(model, companyType, Id));
                            break;
                        case "Supplier":
                            db.tblSupplierUsers.Add(ToCompanyUsers(model, companyType, Id));
                            break;
                    }
                    x = await Task.Run(() => db.SaveChangesAsync());

                    return GetUser(model.UserID).Result;

                }

            }
            catch (Exception e)
            {
                throw;

            }
        }

        #endregion

        #region Update

        internal static async Task<tblUserProfile> UpdateUser(tblUserProfile model)
        {
            try
            {
                using (db = new eMSPEntities())
                {
                    db.Entry(model).State = EntityState.Modified;

                    int x = await Task.Run(() => db.SaveChangesAsync());

                    return model;

                }
            }
            catch (Exception)
            {
                throw;

            }
        }

        internal static async Task<tblMSPUser> ToggleUser(tblMSPUser model)
        {
            try
            {
                using (db = new eMSPEntities())
                {
                    db.Entry(model).State = EntityState.Modified;

                    int x = await Task.Run(() => db.SaveChangesAsync());

                    return model;

                }
            }
            catch (Exception)
            {
                throw;

            }
        }

        internal static async Task<tblCustomerUser> ToggleUser(tblCustomerUser model)
        {
            try
            {
                using (db = new eMSPEntities())
                {
                    db.Entry(model).State = EntityState.Modified;

                    int x = await Task.Run(() => db.SaveChangesAsync());

                    return model;

                }
            }
            catch (Exception)
            {
                throw;

            }
        }

        internal static async Task<tblSupplierUser> ToggleUser(tblSupplierUser model)
        {
            try
            {
                using (db = new eMSPEntities())
                {
                    db.Entry(model).State = EntityState.Modified;

                    int x = await Task.Run(() => db.SaveChangesAsync());

                    return model;

                }
            }
            catch (Exception)
            {
                throw;

            }
        }
        #endregion

        #region Delete

        internal static async Task DeleteUser(string Id)
        {
            try
            {
                using (db = new eMSPEntities())
                {
                    tblUserProfile obj = await db.tblUserProfiles.FindAsync(Id);
                    db.tblUserProfiles.Remove(obj);
                    int x = await Task.Run(() => db.SaveChangesAsync());

                }
            }
            catch (Exception)
            {
                throw;

            }
        }


        #endregion

        public static dynamic ToCompanyUsers(tblUserProfile data, string companyType, long Id)
        {
            switch (companyType)
            {
                case "MSP":
                    return new tblMSPUser() { MSPID = Id, UserID = data.UserID, IsActive = true, IsDeleted = false, CreatedUserID = data.CreatedUserID, CreatedTimestamp = data.CreatedTimestamp, UpdatedUserID = data.UpdatedUserID, UpdatedTimestamp = data.UpdatedTimestamp };
                case "Customer":
                    return new tblCustomerUser() { CustomerID = Id, UserID = data.UserID, IsActive = true, IsDeleted = false, CreatedUserID = data.CreatedUserID, CreatedTimestamp = data.CreatedTimestamp, UpdatedUserID = data.UpdatedUserID, UpdatedTimestamp = data.UpdatedTimestamp };
                case "Supplier":
                    return new tblSupplierUser() { SupplierID = Id, UserID = data.UserID, IsActive = true, IsDeleted = false, CreatedUserID = data.CreatedUserID, CreatedTimestamp = data.CreatedTimestamp, UpdatedUserID = data.UpdatedUserID, UpdatedTimestamp = data.UpdatedTimestamp };

            }
            return null;
        }
    }

}
