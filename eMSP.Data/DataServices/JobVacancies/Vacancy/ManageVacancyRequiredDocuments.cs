using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using eMSP.DataModel;
using System.Data.Entity;

namespace eMSP.Data.DataServices.JobVacancies
{
    class ManageVacancyRequiredDocuments
    {
        #region Initialization

        internal static eMSPEntities db;

        static ManageVacancyRequiredDocuments()
        {

        }

        #endregion

        #region Get
        internal static async Task<List<tblVacanciesRequiredDocument>> GetVacancySkills(long Id)
        {
            try
            {
                using (db = new eMSPEntities())
                {
                    return await Task.Run(() => db.tblVacanciesRequiredDocuments
                                                  .Include(x => x.tblVacancy)                                                  
                                                  .Where(x => x.VacancyID == Id && (x.IsDeleted ?? false) == false).OrderByDescending(x => x.ID).ToList());


                }
            }
            catch (Exception)
            {
                throw;

            }
        }

        #endregion

        #region Insert

        internal static async Task<tblVacanciesRequiredDocument> AddVacanciesRequiredDocument(tblVacanciesRequiredDocument data, tblVacancy vacancy)
        {
            try
            {
                using (db = new eMSPEntities())
                {
                    tblVacanciesRequiredDocument model = db.tblVacanciesRequiredDocuments.Add(new tblVacanciesRequiredDocument
                    {
                        VacancyID = vacancy.ID,
                        RequiredDocumentID=data.ID,
                        RequiredDocumentName=data.RequiredDocumentName,
                        RequiredDocumentDescription=data.RequiredDocumentDescription,
                        IsMandatory=data.IsMandatory,
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

        //internal static async Task<tblVacanciesRequiredDocument> UpdateVacanciesRequiredDocument(tblVacanciesRequiredDocument data, tblVacancy vacancy)
        //{
        //    try
        //    {
        //        using (db = new eMSPEntities())
        //        {
        //            tblVacanciesRequiredDocument model = await Task.Run(() => db.tblVacanciesRequiredDocuments
        //                                                                        .Where(b => b.VacancyID == vacancy.ID && b.ID == data.ID)
        //                                                                        .FirstOrDefaultAsync());

        //            if (model != null)
        //            {
        //                db.Entry(model).State = EntityState.Modified;

        //                int x = await Task.Run(() => db.SaveChangesAsync());
        //            }
        //            else {
        //                model = await Task.Run(() => AddVacanciesRequiredDocument(data, vacancy));
        //            }
        //            return model;
        //        }
        //    }
        //    catch (Exception)
        //    {
        //        throw;
        //    }
        //}

        #endregion

        #region Delete

        internal static async Task DeleteVacanciesRequiredDocument(long VacancyId)
        {
            try
            {
                using (db = new eMSPEntities())
                {
                    List<tblVacanciesRequiredDocument> requiredDocsList = db.tblVacanciesRequiredDocuments
                                                                            .Where(rd => rd.VacancyID == VacancyId)
                                                                            .ToList();
                    db.tblVacanciesRequiredDocuments.RemoveRange(requiredDocsList);
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
