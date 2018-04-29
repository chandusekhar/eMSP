using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using eMSP.DataModel;
using System.Data.Entity;

namespace eMSP.Data.DataServices.JobVacancies
{
    class ManageVacancyFiles
    {
        #region Initialization

        internal static eMSPEntities db;

        static ManageVacancyFiles()
        {

        }

        #endregion

        #region Get
        internal static async Task<tblVacancyFile> GetVacancyFiles(long VacancyId)
        {
            try
            {
                using (db = new eMSPEntities())
                {
                    return await Task.Run(() => db.tblVacancyFiles
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

        internal static async Task<tblVacancyFile> InsertVacancyFiles(tblVacancyFile model, tblVacancy vacancy)
        {
            try
            {
                using (db = new eMSPEntities())
                {
                    model = db.tblVacancyFiles.Add(new tblVacancyFile
                    {
                        VacancyID = vacancy.ID,
                        FilePath = model.FilePath,
                        FileName = model.FileName,
                        IsActive = true,
                        IsDeleted = false,
                        CreatedTimestamp = vacancy.CreatedTimestamp,
                        CreatedUserID = vacancy.CreatedUserID,
                        UpdatedTimestamp = vacancy.UpdatedTimestamp,
                        UpdatedUserID = vacancy.UpdatedUserID
                    });

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

        internal static async Task<tblVacancyFile> UpdateVacancyFile(tblVacancyFile model, tblVacancy vacancy)
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

        internal static async Task DeleteVacancyFile(long VacancyId)
        {
            try
            {
                using (db = new eMSPEntities())
                {
                    List<tblVacancyFile> vacancyFilesList = db.tblVacancyFiles.Where(q => q.VacancyID == VacancyId)
                                                                            .ToList();
                    db.tblVacancyFiles.RemoveRange(vacancyFilesList);
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
