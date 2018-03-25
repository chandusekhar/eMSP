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

        //internal static async Task<tblVacanciesRequiredDocument> UpdateVacanciesRequiredDocument(long a, tblVacancy vacancy)
        //{
        //    try
        //    {
        //        using (db = new eMSPEntities())
        //        {
        //            tblVacancieSkill model = await Task.Run(() => db.tblVacancieSkills.Where(b => b.VacancyID == vacancy.ID && b.SkillID == a).FirstOrDefaultAsync());

        //            if (model != null)
        //            {
        //                db.Entry(model).State = EntityState.Modified;

        //                int x = await Task.Run(() => db.SaveChangesAsync());
        //            }
        //            else
        //            {
        //                model = await Task.Run(() => AddVacancySkills(a, vacancy));
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

        //internal static async Task DeleteVacanciesRequiredDocument(long Id)
        //{
        //    try
        //    {
        //        using (db = new eMSPEntities())
        //        {
        //            tblVacancieSkill obj = await db.tblVacancieSkills.FindAsync(Id);
        //            db.tblVacancieSkills.Remove(obj);
        //            int x = await Task.Run(() => db.SaveChangesAsync());

        //        }
        //    }
        //    catch (Exception)
        //    {
        //        throw;

        //    }
        //}


        #endregion
    }
}
