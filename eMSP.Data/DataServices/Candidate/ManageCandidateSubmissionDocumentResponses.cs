using eMSP.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eMSP.Data.DataServices.Candidate
{
    internal static class ManageCandidateSubmissionDocumentResponses
    {
        #region Initialization

        internal static eMSPEntities db;

        static ManageCandidateSubmissionDocumentResponses() { }

        #endregion

        #region Get




        #endregion

        #region Insert

        internal static async Task InsertCandidateSubmissionDocumentRespons(List<tblCandidateSubmissionDocumentRespons> model)
        {
            try
            {
                using (db = new eMSPEntities())
                {
                    var response = db.tblCandidateSubmissionDocumentResponses.AddRange(model);
                    int x = await Task.Run(() => db.SaveChangesAsync());
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
        internal static async Task DeleteCandidateSubmissionDocumentRespons(long SubmissionId)
        {
            try
            {
                using (db = new eMSPEntities())
                {
                    List<tblCandidateSubmissionDocumentRespons> obj = db.tblCandidateSubmissionDocumentResponses
                                                                        .Where(cs => cs.CandidateSubmissionID == SubmissionId)
                                                                        .ToList();
                    db.tblCandidateSubmissionDocumentResponses.RemoveRange(obj);
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
