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

        internal static eMSPEntities mContext;

        static ManageCustomer()
        {
            mContext = new eMSPEntities();
        }

        #endregion

        #region Get
        internal static async Task<tblCustomer> GetCustomerDetails(long Id)
        {
            try
            {
                using (var db = mContext)
                {
                    return await Task.Run(() => db.tblCustomers.Where(x => x.ID == Id).SingleOrDefault());


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
                using (var db = mContext)
                {
                    return await Task.Run(() => db.tblCustomers.Where(x => x.Name == model.companyName).ToList());


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
                using (var db = mContext)
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
                using (var db = mContext)
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
                using (var db = mContext)
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
