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

        internal static eMSPEntities mContext;

        static ManageSupplier()
        {
            mContext = new eMSPEntities();
        }

        #endregion
    
        #region Get
        internal static async Task<tblSupplier> GetSupplierDetails(long Id)
        {
            try
            {
                using (var db = mContext)
                {
                    return await Task.Run(() => db.tblSuppliers.Where(x => x.ID == Id).SingleOrDefault());


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
                using (var db = mContext)
                {
                    return await Task.Run(() => db.tblSuppliers.Where(x => x.Name == model.companyName).ToList());


                }
            }
            catch (Exception)
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
                using (var db = mContext)
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

        #endregion

        #region Update

        internal static async Task<tblSupplier> UpdateSupplier(tblSupplier model)
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

        internal static async Task DeleteSupplier(long Id)
        {
            try
            {
                using (var db = mContext)
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


        #endregion

     

    }
}
