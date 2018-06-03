using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using eMSP.DataModel;
using System.Data.Entity;

namespace eMSP.Data.DataServices.JobVacancies
{
    class ManageVacancyComments
    {
        #region Initialization

        internal static eMSPEntities db;

        static ManageVacancyComments()
        {

        }

        #endregion

        #region Get
        internal static async Task<tblVacancyComment> GetVacancyComments(long VacancyId)
        {
            try
            {
                using (db = new eMSPEntities())
                {
                    return await Task.Run(() => db.tblVacancyComments
                                                  .Where(x => x.VacancyID == VacancyId).SingleOrDefault());


                }
            }
            catch (Exception)
            {
                throw;

            }
        }

        #endregion

        #region Insert

        internal static async Task<tblVacancyComment> CommentVacancy(tblVacancyComment model)
        {
            try
            {
                using (db = new eMSPEntities())
                {
                    model = db.tblVacancyComments.Add(model);

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

        internal static async Task<tblVacancyComment> UpdateComment(tblVacancyComment model)
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

        internal static async Task DeleteComment(long Id)
        {
            try
            {
                using (db = new eMSPEntities())
                {
                    tblVacancyComment obj = await db.tblVacancyComments.FindAsync(Id);
                    db.tblVacancyComments.Remove(obj);
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
