using eMSP.DataModel;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eMSP.Data.DataServices.MSP
{
    public class ManageMSPSpendCategory
    {
        #region Initialization

        internal static eMSPEntities db;

        static ManageMSPSpendCategory() { }

        #endregion

        #region Get

        internal static async Task<tblMSPSpendCategory> GetMSPSpendCategory(long Id)
        {
            try
            {
                using (db = new eMSPEntities())
                {
                    return await Task.Run(() => db.tblMSPSpendCategories
                                                  .Where(x => x.ID == Id).SingleOrDefault());

                }
            }
            catch (Exception)
            {
                throw;

            }
        }

        internal static async Task<List<tblMSPSpendCategory>> GetMSPSpendCategory()
        {
            try
            {
                using (db = new eMSPEntities())
                {
                    return await Task.Run(() => db.tblMSPSpendCategories.ToList());
                }
            }
            catch (Exception)
            {
                throw;

            }
        }
        #endregion

        #region Insert

        internal static async Task<tblMSPSpendCategory> InsertMSPSpendCategory(tblMSPSpendCategory data)
        {
            try
            {
                using (db = new eMSPEntities())
                {
                    db.tblMSPSpendCategories.Add(data);

                    int x = await Task.Run(() => db.SaveChangesAsync());

                    return data;
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        #endregion

        #region Update

        internal static async Task<tblMSPSpendCategory> UpdateMSPSpendCategory(tblMSPSpendCategory model)
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

        internal static async Task DeleteMSPMSPSpendCategory(long Id)
        {
            try
            {
                using (db = new eMSPEntities())
                {
                    tblMSPSpendCategory obj = await db.tblMSPSpendCategories.FindAsync(Id);
                    db.tblMSPSpendCategories.Remove(obj);

                    await Task.Run(() => db.SaveChangesAsync());
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
