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
    internal static class ManageCustomer
    {
        #region Intialization

        internal static eMSPEntities db;

        static ManageCustomer()
        {

        }

        #endregion

        #region Get
        internal static async Task<tblCustomer> GetCustomerDetails(long Id)
        {
            try
            {
                using (db = new eMSPEntities())
                {
                    return await Task.Run(() => db.tblCustomers
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

        internal static async Task<List<tblCustomer>> GetAllCustomerDetails(CompanySearchModel model)
        {
            try
            {
                using (db = new eMSPEntities())
                {
                    if (model.companyName == "%")
                    {
                        return await Task.Run(() => db.tblCustomers.Include(a => a.tblCountry)
                                                  .Include(b => b.tblCountryState).Select(x => x).ToList());
                    }
                    else
                    {
                        return await Task.Run(() => db.tblCustomers.Include(a => a.tblCountry)
                                                  .Include(b => b.tblCountryState).Where(x => x.Name == model.companyName).ToList());
                    }

                }
            }
            catch (Exception)
            {
                throw;

            }
        }

        internal static async Task<List<tblLocation>> GetCustomerLocation(long customerId)
        {
            try
            {
                using (db = new eMSPEntities())
                {   
                    return await Task.Run(() => db.tblCustomerLocationBranches
                                                  .Include(a => a.tblLocation)
                                                  .Where(x => x.CustomerID == customerId && x.BranchID == null)
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

        internal static async Task<List<tblCustomerLocationBranch>> GetCustomerLocationBranches(long customerId)
        {
            try
            {
                using (db = new eMSPEntities())
                {
                    return await Task.Run(() => db.tblCustomerLocationBranches
                                                  .Include(a => a.tblLocation)
                                                  .Where(x => x.CustomerID == customerId && x.BranchID == null)
                                                  .ToList());
                }
            }
            catch (Exception)
            {
                throw;

            }
        }



        internal static async Task<List<tblBranch>> GetCustomerBranches(long customerId,long locationId)
        {
            try
            {
                using (db = new eMSPEntities())
                {
                    return await Task.Run(() => db.tblCustomerLocationBranches                                                                                                    
                                                  .Include(a => a.tblBranch)
                                                  .Where(x => x.CustomerID == customerId)
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

        internal static async Task<List<tblBranch>> GetCustomerAllBranches(long customerId)
        {
            try
            {
                using (db = new eMSPEntities())
                {
                    return await Task.Run(() => db.tblCustomerLocationBranches                                                  
                                                  .Include(a => a.tblBranch)
                                                  .Where(x => x.CustomerID == customerId && x.BranchID != null)
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

        #endregion

        #region Insert

        internal static async Task<tblCustomer> InsertCustomer(tblCustomer model)
        {
            try
            {
                using (db = new eMSPEntities())
                {
                    model = db.tblCustomers.Add(model);

                    int x = await Task.Run(() => db.SaveChangesAsync());

                    return model;

                }
            }
            catch (Exception)
            {
                throw;

            }
        }

        internal static async Task<tblCustomerLocationBranch> InsertCustomerLocationBranch(tblCustomerLocationBranch model)
        {
            try
            {
                using (db = new eMSPEntities())
                {
                    model = db.tblCustomerLocationBranches.Add(model);

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

        internal static async Task<tblCustomer> UpdateCustomer(tblCustomer model)
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

        internal static async Task<tblCustomerLocationBranch> UpdateCustomerLocationBranch(tblCustomerLocationBranch model)
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

        internal static async Task DeleteCustomer(long Id)
        {
            try
            {
                using (db = new eMSPEntities())
                {
                    tblCustomer obj = await db.tblCustomers.FindAsync(Id);
                    db.tblCustomers.Remove(obj);
                    int x = await Task.Run(() => db.SaveChangesAsync());

                }
            }
            catch (Exception)
            {
                throw;

            }
        }

        internal static async Task DeleteCustomerLocationBranch(long Id,string type)
        {
            try
            {
                using (db = new eMSPEntities())
                {
                    tblCustomerLocationBranch obj = new tblCustomerLocationBranch();
                    switch (type)
                    {
                        case "Location":
                            obj = await db.tblCustomerLocationBranches.Where(a => a.LocationID == Id).SingleAsync();
                            break;
                        case "Branch":
                            obj = await db.tblCustomerLocationBranches.Where(a => a.BranchID == Id).SingleAsync();
                            break;
                    }
                    db.tblCustomerLocationBranches.Remove(obj);
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
