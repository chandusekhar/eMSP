using eMSP.DataModel;
using eMSP.ViewModel.MSP;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eMSP.Data.DataServices.Company
{
    internal static class ManageSupplier
    {

        #region Initialization

        internal static eMSPEntities db;

        static ManageSupplier()
        {

        }

        #endregion

        #region Get
        internal static async Task<tblSupplier> GetSupplierDetails(long Id)
        {
            try
            {
                using (db = new eMSPEntities())
                {
                    return await Task.Run(() => db.tblSuppliers
                                                  .Include(a => a.tblCountry)
                                                  .Include(b => b.tblCountryState)
                                                  .Where(x => x.ID == Id).SingleOrDefault());


                }
            }
            catch (Exception)
            {
                throw;

            }
        }

        internal static async Task<List<tblSupplier>> GetAllSupplierDetails(CompanySearchModel model)
        {
            try
            {
                using (db = new eMSPEntities())
                {
                    if (model.companyName == "%")
                    {
                        return await Task.Run(() => db.tblSuppliers
                                                      .Include(a => a.tblCountry)
                                                      .Include(b => b.tblCountryState)
                                                      .Select(x => x).ToList());
                    }
                    else {
                        return await Task.Run(() => db.tblSuppliers
                                                      .Include(a => a.tblCountry)
                                                      .Include(b => b.tblCountryState)
                                                      .Where(x => x.Name == model.companyName).ToList());

                    }
                }
            }
            catch (Exception)
            {
                throw;

            }
        }

        internal static async Task<List<tblLocation>> GetSupplierLocation(long supplierId)
        {
            try
            {
                using (db = new eMSPEntities())
                {                   

                    return await Task.Run(() => db.tblSupplierLocationBranches
                                                  .Include(a => a.tblLocation)
                                                  .Where(x => x.SupplierID == supplierId && x.BranchID == null)
                                                  .Select(x => x.tblLocation)
                                                  .Include(a => a.tblCountry)
                                                  .Include(a => a.tblCountryState)
                                                  .ToList());


                }
            }
            catch (Exception)
            {
                throw;

            }
        }

        internal static async Task<List<tblBranch>> GetSupplierBranches(long supplierId, long locationId)
        {
            try
            {
                using (db = new eMSPEntities())
                {
                    return await Task.Run(() => db.tblSupplierLocationBranches                                                  
                                                  .Include(a => a.tblBranch)
                                                  .Where(x => x.SupplierID == supplierId)
                                                  .Where(x => x.LocationID == locationId)
                                                  .Select(x => x.tblBranch)
                                                  .Include(a => a.tblLocation)
                                                  .Include(a => a.tblCountry)
                                                  .Include(a => a.tblCountryState)
                                                  .ToList());


                }
            }
            catch (Exception)
            {
                throw;

            }
        }

        internal static async Task<List<tblBranch>> GetSupplierAllBranches(long supplierId)
        {
            try
            {
                using (db = new eMSPEntities())
                {
                    return await Task.Run(() => db.tblSupplierLocationBranches                                                  
                                                  .Include(a => a.tblBranch)
                                                  .Where(x => x.SupplierID == supplierId && x.BranchID != null)                                                  
                                                  .Select(x => x.tblBranch)
                                                  .Include(a => a.tblLocation)
                                                  .Include(a => a.tblCountry)
                                                  .Include(a => a.tblCountryState)
                                                  .ToList());


                }
            }
            catch (Exception ex)
            {
                throw;

            }
        }

        #endregion

        #region Insert

        internal static async Task<tblSupplier> InsertSupplier(tblSupplier model)
        {
            try
            {
                using (db = new eMSPEntities())
                {
                    model = db.tblSuppliers.Add(model);

                    int x = await Task.Run(() => db.SaveChangesAsync());

                    return model;

                }
            }
            catch (Exception)
            {
                throw;

            }
        }

        internal static async Task<tblSupplierLocationBranch> InsertSupplierLocationBranch(tblSupplierLocationBranch model)
        {
            try
            {
                using (db = new eMSPEntities())
                {
                    model = db.tblSupplierLocationBranches.Add(model);

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

        #region Update

        internal static async Task<tblSupplier> UpdateSupplier(tblSupplier model)
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

        internal static async Task<tblSupplierLocationBranch> UpdateSupplierBranchLocation(tblSupplierLocationBranch model)
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

        internal static async Task DeleteSupplier(long Id)
        {
            try
            {
                using (db = new eMSPEntities())
                {
                    tblSupplier obj = await db.tblSuppliers.FindAsync(Id);
                    db.tblSuppliers.Remove(obj);
                    int x = await Task.Run(() => db.SaveChangesAsync());

                }
            }
            catch (Exception)
            {
                throw;

            }
        }


        internal static async Task DeleteSupplierBranchLocation(long Id,string type)
        {
            try
            {
                using (db = new eMSPEntities())
                {
                    tblSupplierLocationBranch obj = new tblSupplierLocationBranch();
                    switch (type)
                    {
                        case "Location":
                            obj = await db.tblSupplierLocationBranches.Where(a => a.LocationID == Id).SingleAsync();
                            break;
                        case "Branch":
                            obj = await db.tblSupplierLocationBranches.Where(a => a.BranchID == Id).SingleAsync();
                            break;
                    }
                    
                    db.tblSupplierLocationBranches.Remove(obj);
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
