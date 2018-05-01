using eMSP.DataModel;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eMSP.Data.DataServices.Candidate
{
    public class ManageTimesheetStatus
    {
        #region Initialization

        internal static eMSPEntities db;

        static ManageTimesheetStatus() { }

        #endregion

        #region Get

        internal static async Task<tblTimesheetStatu> GetTimesheetStatus(long Id)
        {
            try
            {
                using (db = new eMSPEntities())
                {
                    return await Task.Run(() => db.tblTimesheetStatus
                                                  .Where(x => x.ID == Id).SingleOrDefault());

                }
            }
            catch (Exception)
            {
                throw;

            }
        }

        internal static async Task<List<tblTimesheetStatu>> GetTimesheetStatus()
        {
            try
            {
                using (db = new eMSPEntities())
                {
                    return await Task.Run(() => db.tblTimesheetStatus.ToList());
                }
            }
            catch (Exception)
            {
                throw;

            }
        }
        #endregion

        #region Insert

        internal static async Task<tblTimesheetStatu> InsertTimesheetStatus(tblTimesheetStatu data)
        {
            try
            {
                using (db = new eMSPEntities())
                {
                    db.tblTimesheetStatus.Add(data);

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

        internal static async Task<tblTimesheetStatu> UpdateTimesheetStatus(tblTimesheetStatu model)
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

        internal static async Task DeleteTimesheetStatus(long Id)
        {
            try
            {
                using (db = new eMSPEntities())
                {
                    tblTimesheetStatu obj = await db.tblTimesheetStatus.FindAsync(Id);
                    db.tblTimesheetStatus.Remove(obj);

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
