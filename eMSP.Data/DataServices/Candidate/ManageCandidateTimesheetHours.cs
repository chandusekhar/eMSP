using eMSP.DataModel;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eMSP.Data.DataServices.Candidate
{
    internal static class ManageCandidateTimesheetHours
    {
        #region Initialization

        internal static eMSPEntities db;

        static ManageCandidateTimesheetHours() { }

        #endregion

        #region Get
        internal static async Task<tblCandidateTimesheetHour> GetCandidateTimesheetHours(long Id)
        {
            try
            {
                using (db = new eMSPEntities())
                {
                    return await Task.Run(() => db.tblCandidateTimesheetHours
                                                  .Include(x=>x.tblCandidateTimesheet)                                               
                                                  .Where(x => x.ID == Id).FirstOrDefault());
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion

        #region Insert
        internal static async Task<tblCandidateTimesheetHour> InsertCandidateTimesheetHours(tblCandidateTimesheetHour model)
        {
            try
            {
                using (db = new eMSPEntities())
                {
                    var candidateTimesheetHours = db.tblCandidateTimesheetHours.Add(model);
                    int x = await Task.Run(() => db.SaveChangesAsync());

                    return candidateTimesheetHours;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion

        #region Update

        internal static async Task UpdateCandidateTimesheetHours(tblCandidateTimesheetHour model)
        {
            try
            {
                using (db = new eMSPEntities())
                {
                    db.Entry(model).State = EntityState.Modified;

                    int x = await Task.Run(() => db.SaveChangesAsync());
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion

        #region Delete

        #endregion
    }
}
