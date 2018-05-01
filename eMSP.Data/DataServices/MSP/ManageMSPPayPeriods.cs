using eMSP.DataModel;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eMSP.Data.DataServices.MSP
{
    public class ManageMSPPayPeriods
    {
        #region Initialization

        internal static eMSPEntities db;

        static ManageMSPPayPeriods() { }

        #endregion

        #region Get
        internal static async Task<tblMSPPayPeriod> GetMSPPayPeriod(long Id)
        {
            try
            {
                using (db = new eMSPEntities())
                {
                    return await Task.Run(() => db.tblMSPPayPeriods
                                                  .Where(x => x.ID == Id).SingleOrDefault());

                }
            }
            catch (Exception)
            {
                throw;

            }
        }

        internal static async Task<List<tblMSPPayPeriod>> GetMSPPayPeriods()
        {
            try
            {
                using (db = new eMSPEntities())
                {
                    return await Task.Run(() => db.tblMSPPayPeriods.ToList());
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion

        #region Insert

        internal static async Task<tblMSPPayPeriod> InsertMSPPayPeriod(tblMSPPayPeriod data)
        {
            try
            {
                using (db = new eMSPEntities())
                {
                    db.tblMSPPayPeriods.Add(data);

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

        internal static async Task<tblMSPPayPeriod> UpdateMSPPayPeriod(tblMSPPayPeriod model)
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
        internal static async Task DeleteMSPPayPeriod(long Id)
        {
            try
            {
                using (db = new eMSPEntities())
                {
                    tblMSPPayPeriod obj = await db.tblMSPPayPeriods.FindAsync(Id);
                    db.tblMSPPayPeriods.Remove(obj);

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
