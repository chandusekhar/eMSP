using eMSP.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eMSP.Data.DataServices.Candidate
{
    internal static class ManageCandidateSubmissionsQuestionsResponses
    {
        #region Initialization

        internal static eMSPEntities db;

        static ManageCandidateSubmissionsQuestionsResponses() { }

        #endregion

        #region Get




        #endregion

        #region Insert

        internal static async Task InsertCandidateSubmissionsQuestionsRespons(List<tblCandidateSubmissionsQuestionsRespons> model)
        {
            try
            {
                using (db = new eMSPEntities())
                {
                    db.tblCandidateSubmissionsQuestionsResponses.AddRange(model);
                    int x = await Task.Run(() => db.SaveChangesAsync());
                }
            }
            catch (Exception)
            {
                throw;

            }
        }

        #endregion

        #region Update


        #endregion

        #region Delete

        internal static async Task DeleteCandidateSubmissionsQuestionsRespons(long SubmissionId)
        {
            try
            {
                using (db = new eMSPEntities())
                {
                    List<tblCandidateSubmissionsQuestionsRespons> obj = db.tblCandidateSubmissionsQuestionsResponses
                                                                          .Where(cs => cs.SubmissionID == SubmissionId)
                                                                          .ToList();
                    db.tblCandidateSubmissionsQuestionsResponses.RemoveRange(obj);
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
