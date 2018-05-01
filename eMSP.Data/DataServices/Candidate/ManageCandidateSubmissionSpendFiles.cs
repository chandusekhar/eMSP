using eMSP.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eMSP.Data.DataServices.Candidate
{
    internal static class ManageCandidateSubmissionSpendFiles
    {
        #region Initialization

        internal static eMSPEntities db;

        static ManageCandidateSubmissionSpendFiles() { }

        #endregion

        #region Get

        #endregion

        #region Insert

        internal static async Task<List<tblCandidateSubmissionSpendFile>> InsertCandidateSubmissionSpendFiles(List< tblCandidateSubmissionSpendFile> model)
        {
            try
            {
                using (db = new eMSPEntities())
                {
                    var response = db.tblCandidateSubmissionSpendFiles.AddRange(model);
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


        #endregion

        #region Delete

        internal static async Task DeleteCandidateSubmissionSpendFiles(long SpendID)
        {
            try
            {
                using (db = new eMSPEntities())
                {
                    var response = db.tblCandidateSubmissionSpendFiles.Where(cs=>cs.SpendID== SpendID).ToList();
                    db.tblCandidateSubmissionSpendFiles.RemoveRange(response);
                    await Task.Run(() => db.SaveChangesAsync());
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        #endregion
    }
}
