using eMSP.DataModel;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eMSP.Data.DataServices.Candidate
{
    internal static class ManageCandidateTimesheets
    {
        #region Initialization

        internal static eMSPEntities db;

        static ManageCandidateTimesheets() { }

        #endregion

        #region Get

        internal static async Task<tblCandidateTimesheet> GetCandidateTimesheet(long PlacementId)
        {
            try
            {
                using (db = new eMSPEntities())
                {
                    return await Task.Run(() => db.tblCandidateTimesheets
                                               .Include(x => x.tblCandidatePlacement)
                                               .Include(x => x.tblTimesheetStatu)
                                               .Include(x => x.tblMSPPayPeriod)
                                               .Include(x => x.tblCandidateTimesheetHours)
                                               .Include(x => x.tblCandidateTimesheetCategoriesHours)
                                               .Where(x => x.PlacementID == PlacementId).FirstOrDefault());
                }
            }
            catch (Exception)
            {
                throw;

            }
        }

        internal static async Task<tblCandidateTimesheet> GetTimesheetDetailsById(long Id)
        {
            try
            {
                using (db = new eMSPEntities())
                {
                    return await Task.Run(() => db.tblCandidateTimesheets
                                               .Include(x => x.tblCandidatePlacement)
                                               .Include(x => x.tblTimesheetStatu)
                                               .Include(x => x.tblMSPPayPeriod)
                                               .Include(x => x.tblCandidateTimesheetHours)
                                               .Include(x => x.tblCandidateTimesheetCategoriesHours)
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
        internal static async Task<tblCandidateTimesheet> InsertCandidateTimesheet(tblCandidateTimesheet model)
        {
            try
            {
                using (db = new eMSPEntities())
                {
                    var candidateTimesheet = db.tblCandidateTimesheets.Add(model);
                    int x = await Task.Run(() => db.SaveChangesAsync());

                    return candidateTimesheet;

                }
            }
            catch (Exception)
            {
                throw;

            }
        }

        #endregion

        #region Update
        internal static async Task UpdateCandidateTimesheet(tblCandidateTimesheet model)
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
