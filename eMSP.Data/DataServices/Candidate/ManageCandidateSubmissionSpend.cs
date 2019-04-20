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
    internal static class ManageCandidateSubmissionSpend
    {
        #region Initialization

        internal static eMSPEntities db;

        static ManageCandidateSubmissionSpend() { }

        #endregion

        #region Get

        internal static async Task<tblCandidateSubmissionSpend> GetExpenseDetails(long Id)
        {
            try
            {
                using (db = new eMSPEntities())
                {
                    return await Task.Run(() => db.tblCandidateSubmissionSpends
                                                  .Include(a => a.tblCandidateSubmissionSpendFiles)
                                                  .Include(a => a.tblMSPPayPeriod)
                                                  .Include(a => a.tblCandidateSubmissionSpendFiles.Select(b => b.tblFile))
                                                  .Include(a => a.tblMSPSpendCategory)
                                                  .Include(a => a.tblTimesheetStatu)
                                                  .Include(a => a.tblCandidatePlacement)
                                                  .Where(x => x.ID == Id).SingleOrDefault());

                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        internal static async Task<List<tblCandidateSubmissionSpend>> GetPayperiodExpenseSpends(long PayPeriodId)
        {
            try
            {
                using (db = new eMSPEntities())
                {
                    return await Task.Run(() => db.tblCandidateSubmissionSpends
                                                  .Include(a => a.tblCandidateSubmissionSpendFiles)
                                                  .Include(a => a.tblMSPPayPeriod)
                                                  .Include(a => a.tblCandidateSubmissionSpendFiles.Select(b => b.tblFile))
                                                  .Include(a => a.tblMSPSpendCategory)
                                                  .Include(a => a.tblTimesheetStatu)
                                                  .Include(a => a.tblCandidatePlacement)
                                                  .Where(x => x.PayPeriodID == PayPeriodId).ToList());

                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        internal static async Task<List<tblCandidateSubmissionSpend>> GetCandidateExpenseSpends(long PlacementId)
        {
            try
            {
                using (db = new eMSPEntities())
                {
                    return await Task.Run(() => db.tblCandidateSubmissionSpends
                                                  .Include(a=>a.tblCandidateSubmissionSpendFiles)
                                                  .Include(a=>a.tblMSPPayPeriod)
                                                  .Include(a=>a.tblCandidateSubmissionSpendFiles.Select(b=>b.tblFile))
                                                  .Include(a=>a.tblMSPSpendCategory)
                                                  .Include(a=>a.tblTimesheetStatu)
                                                  .Include(a=>a.tblCandidatePlacement.tblCandidateSubmission.tblCandidateStatu)
                                                  .Include(a => a.tblCandidatePlacement.tblMSPTimeGroup)
                                                  .Where(x => x.PlacementID == PlacementId).ToList());

                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        internal static async Task<List<tblCandidateSubmissionSpend>> GetCandidateExpenseSpends(long placementId, long payPeriodId)
        {
            try
            {
                using (db = new eMSPEntities())
                {
                    return await Task.Run(() => db.tblCandidateSubmissionSpends
                                                  .Include(a => a.tblCandidateSubmissionSpendFiles)
                                                  .Include(a => a.tblMSPPayPeriod)
                                                  .Include(a => a.tblCandidateSubmissionSpendFiles.Select(b => b.tblFile))
                                                  .Include(a => a.tblMSPSpendCategory)
                                                  .Include(a => a.tblTimesheetStatu)
                                                  .Include(a => a.tblCandidatePlacement)
                                                  .Where(x => x.PlacementID == placementId && x.PayPeriodID == payPeriodId).ToList());

                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion

        #region Insert

        internal static async Task<tblCandidateSubmissionSpend> InsertCandidateSubmissionSpend(tblCandidateSubmissionSpend model)
        {
            try
            {
                using (db = new eMSPEntities())
                {
                    var response = db.tblCandidateSubmissionSpends.Add(model);
                    int x = await Task.Run(() => db.SaveChangesAsync());
                    return model;
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        

        #endregion

        #region Update

        internal static async Task<tblCandidateSubmissionSpend> UpdateCandidateSubmissionSpend(tblCandidateSubmissionSpend model)
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

        internal static async Task UpdateCandidateExpenseStatus(ExpenseStateChangeViewModel model)
        {
            try
            {
                using (db = new eMSPEntities())
                {
                    var Expense = db.tblCandidateSubmissionSpends
                                           .Where(p => p.ID == model.ID)
                                           .SingleOrDefault();

                    if (Expense != null)
                    {
                        Expense.CurrentStatusID = model.StatusID;
                        Expense.UpdatedTimestamp = model.updatedTimestamp;
                        Expense.UpdatedUserID = model.updatedUserID;

                        await Task.Run(() => db.SaveChangesAsync());
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
        internal static async Task DeleteCandidateSubmissionSpend(long PlacementID)
        {
            try
            {
                using (db = new eMSPEntities())
                {
                    List<tblCandidateSubmissionSpend> obj = db.tblCandidateSubmissionSpends
                                                                        .Where(cs => cs.PlacementID == PlacementID)
                                                                        .ToList();
                    db.tblCandidateSubmissionSpends.RemoveRange(obj);
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
