using eMSP.DataModel;
using eMSP.ViewModel.Candidate;
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

        internal static async Task<tblCandidateTimesheet> GetCandidateTimesheet(long placementId, long payPeriodId)
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
                                               .Where(x => x.PlacementID == placementId & x.PayPeriodID == payPeriodId).FirstOrDefault());
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


        internal static async Task<List<tblCandidateTimesheet>> GetTimesheetDetailsByDate(DateTime fromDate , DateTime toDate)
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
                                               .Where(x => x.tblMSPPayPeriod.StartDate >= fromDate || x.tblMSPPayPeriod.EndDate <= toDate).ToList());
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

                    var existingParent = db.tblCandidateTimesheets
                                           .Where(p => p.ID == model.ID)
                                           .Include(p => p.tblCandidateTimesheetHours)
                                           .SingleOrDefault();

                    if (existingParent != null)
                    {
                        db.Entry(existingParent).CurrentValues.SetValues(model);

                        foreach (var existingChild in existingParent.tblCandidateTimesheetHours.ToList())
                        {
                            if (!model.tblCandidateTimesheetHours.Any(c => c.ID == existingChild.ID))
                                db.tblCandidateTimesheetHours.Remove(existingChild);
                        }

                        foreach (var childModel in model.tblCandidateTimesheetHours)
                        {
                            var existingChild = existingParent.tblCandidateTimesheetHours
                                .Where(c => c.ID == childModel.ID)
                                .SingleOrDefault();

                            if (existingChild != null)
                                db.Entry(existingChild).CurrentValues.SetValues(childModel);
                            else
                            {
                                
                                existingParent.tblCandidateTimesheetHours.Add(childModel);
                            }
                        }

                        int x = await Task.Run(() => db.SaveChangesAsync());
                    }
                    else
                    {
                        await Task.Run(() => InsertCandidateTimesheet(model));
                    }
                   
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
