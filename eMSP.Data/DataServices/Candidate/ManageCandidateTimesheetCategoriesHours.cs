using eMSP.DataModel;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eMSP.Data.DataServices.Candidate
{
    internal static class ManageCandidateTimesheetCategoriesHours
    {
        #region Initialization

        internal static eMSPEntities db;

        static ManageCandidateTimesheetCategoriesHours() { }

        #endregion

        #region Get
        internal static async Task<tblCandidateTimesheetCategoriesHour> GetCandidateTimesheetCategoriesHours(long Id)
        {
            try
            {
                using (db = new eMSPEntities())
                {
                    return await Task.Run(() => db.tblCandidateTimesheetCategoriesHours
                                                  .Include(x => x.tblCandidateTimesheet)
                                                  .Include(x => x.tblMSPTimeGroupCategory)
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
        internal static async Task<tblCandidateTimesheetCategoriesHour> InsertCandidateTimesheetCategoriesHours(tblCandidateTimesheetCategoriesHour model)
        {
            try
            {
                using (db = new eMSPEntities())
                {
                    var candidateTimesheetCategoriesHours = db.tblCandidateTimesheetCategoriesHours.Add(model);
                    int x = await Task.Run(() => db.SaveChangesAsync());

                    return candidateTimesheetCategoriesHours;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion

        #region Update

        internal static async Task UpdateCandidateTimesheetCategoriesHours(tblCandidateTimesheetCategoriesHour model)
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
