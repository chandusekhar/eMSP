using eMSP.DataModel;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eMSP.Data.DataServices.Candidate
{
    public class ManageCandidatePlacement
    {
        #region Initialization

        internal static eMSPEntities db;

        static ManageCandidatePlacement() { }

        #endregion

        #region Get

        internal static async Task<tblCandidatePlacement> GetPlacementDetails(long Id)
        {
            try
            {
                using (db = new eMSPEntities())
                {
                    return await Task.Run(() => db.tblCandidatePlacements
                                                  .Where(x => x.ID == Id).SingleOrDefault());

                }
            }
            catch (Exception)
            {
                throw;

            }
        }

        internal static async Task<tblCandidatePlacement> GetPlacementByCandidateId(long Id)
        {
            try
            {
                using (db = new eMSPEntities())
                {
                    return await Task.Run(() => db.tblCandidatePlacements                                                  
                                                  .Include(x => x.tblCandidateSubmission.tblCandidate)
                                                  .Where(x => x.tblCandidateSubmission.tblCandidate.ID == Id && (x.IsActive ?? true))
                                                  .SingleOrDefault());

                }
            }
            catch (Exception)
            {
                throw;

            }
        }

        internal static async Task<List<tblCandidatePlacement>> GetAllPlacements()
        {
            try
            {
                using (db = new eMSPEntities())
                {
                    return await Task.Run(() => db.tblCandidatePlacements.Where(x => x.IsActive ?? true)
                                                  .Include(x => x.tblCandidateSubmission.tblVacancy)
                                                  .Include(x => x.tblCandidateSubmission.tblCandidateStatu)
                                                  .Include(x => x.tblCandidateSubmission.tblCandidate)
                                                  .Include(x => x.tblCandidateSubmission.tblCandidate.tblSupplierCandidates.Select(y => y.tblSupplier))
                                                  .ToList());
                }
            }
            catch (Exception)
            {
                throw;

            }
        }
        #endregion

        #region Insert

        internal static async Task<tblCandidatePlacement> InsertCandidatePlacement(tblCandidatePlacement data)
        {
            try
            {
                using (db = new eMSPEntities())
                {
                    db.tblCandidatePlacements.Add(data);

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

        internal static async Task<tblCandidatePlacement> UpdateCandidatePlacement(tblCandidatePlacement model)
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

        internal static async Task DeleteCandidatePlacement(long Id)
        {
            try
            {
                using (db = new eMSPEntities())
                {
                    tblCandidatePlacement obj = await db.tblCandidatePlacements.FindAsync(Id);
                    db.tblCandidatePlacements.Remove(obj);

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
