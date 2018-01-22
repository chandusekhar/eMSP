using eMSP.DataModel;
using eMSP.ViewModel.MSP;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace eMSP.Data.DataServices.Company
{
    internal static class ManageMSP
    {
        #region Initialization

        internal static eMSPEntities db;

        static ManageMSP()
        {
           
        }

        #endregion

        #region Get
        internal static async Task<tblMSPDetail> GetMSPDetails(long Id)
        {
            try
            {
                using (db = new eMSPEntities())
                {
                    
                    return await Task.Run(() => db.tblMSPDetails
                                                  .Include(a=>a.tblCountry)
                                                  .Include(b=>b.tblCountryState)
                                                  .Where(x => x.ID == Id).SingleOrDefault());


                }
            }
            catch (Exception)
            {
                throw;

            }
        }

        internal static async Task<List<tblMSPDetail>> GetAllMSPDetails(CompanySearchModel model)
        {
            try
            {
                using ( db = new eMSPEntities())
                {
                    return await Task.Run(() => db.tblMSPDetails.Where(x => x.CompanyName == model.companyName).OrderByDescending(x => x.ID).ToList());
                }
            }
            catch (Exception)
            {
                throw;

            }
        }

        internal static async Task<List<tblLocation>> GetMSPLocation(long mspId)
        {
            try
            {
                using (db = new eMSPEntities())
                {
                    return await Task.Run(() => db.tblMSPLocationBranches
                                                  .Include(a => a.tblLocation)
                                                  .Where(x => x.MSPID == mspId && x.BranchID == null)
                                                  .Select(x => x.tblLocation)
                                                  .Include(a => a.tblCountry)
                                                  .Include(a => a.tblCountryState)
                                                  .OrderByDescending(x => x.ID).ToList());                    

                }
            }
            catch (Exception ex)
            {
                throw;

            }
        }

        internal static async Task<List<tblBranch>> GetMSPBranches(long mspId, long locationId)
        {
            try
            {
                using (db = new eMSPEntities())
                {
                    return await Task.Run(() => db.tblMSPLocationBranches                                                  
                                                  .Include(a => a.tblBranch)
                                                  .Where(x => x.MSPID == mspId)
                                                  .Where(x => x.LocationID == locationId)
                                                  .Select(x => x.tblBranch)
                                                  .Include(a => a.tblLocation)
                                                  .Include(a => a.tblCountry)
                                                  .Include(a => a.tblCountryState)
                                                  .OrderByDescending(x => x.ID).ToList());


                }
            }
            catch (Exception)
            {
                throw;

            }
        }

        internal static async Task<List<tblBranch>> GetMSPAllBranches(long mspId)
        {
            try
            {
                using (db = new eMSPEntities())
                {
                    return await Task.Run(() => db.tblMSPLocationBranches                                                  
                                                  .Include(a => a.tblBranch)
                                                  .Where(x => x.MSPID == mspId && x.BranchID != null)
                                                  .Select(x => x.tblBranch)
                                                  .Include(a => a.tblLocation)
                                                  .Include(a => a.tblCountry)
                                                  .Include(a => a.tblCountryState)
                                                  .OrderByDescending(x => x.ID).ToList());


                }
            }
            catch (Exception)
            {
                throw;

            }
        }

        #endregion

        #region Insert

        internal static async Task<tblMSPDetail> InsertMSP(tblMSPDetail model)
        {
            try
            {
                using ( db = new eMSPEntities())
                {
                    model = db.tblMSPDetails.Add(model);

                    int x = await Task.Run(() => db.SaveChangesAsync());

                    return model;

                }
            }
            catch (Exception)
            {
                throw;

            }
        }

        internal static async Task<tblMSPLocationBranch> InsertMSPLocationBranch(tblMSPLocationBranch model)
        {
            try
            {
                using (db = new eMSPEntities())
                {
                    model = db.tblMSPLocationBranches.Add(model);

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

        internal static async Task<tblMSPDetail> UpdateMSP(tblMSPDetail model)
        {
            try
            {
                using ( db = new eMSPEntities())
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

        internal static async Task<tblMSPLocationBranch> UpdateMSPLocationBranch(tblMSPLocationBranch model)
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

        internal static async Task DeleteMSPLocationBranch(long Id, string type)
        {
            try
            {
                using (db = new eMSPEntities())
                {
                    tblMSPLocationBranch obj = new tblMSPLocationBranch();
                    switch (type)
                    {
                        case "Location":
                            obj = await db.tblMSPLocationBranches.Where(a => a.LocationID == Id).SingleAsync();
                            break;
                        case "Branch":
                            obj = await db.tblMSPLocationBranches.Where(a => a.BranchID == Id).SingleAsync();
                            break;
                    }

                    db.tblMSPLocationBranches.Remove(obj);
                    int x = await Task.Run(() => db.SaveChangesAsync());

                }
            }
            catch (Exception)
            {
                throw;

            }
        }

        internal static async Task DeleteMSP(long Id)
        {
            try
            {
                using (db = new eMSPEntities())
                {
                    tblMSPDetail obj = await db.tblMSPDetails.FindAsync(Id);
                    db.tblMSPDetails.Remove(obj);
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
