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


        #endregion



    }
}
