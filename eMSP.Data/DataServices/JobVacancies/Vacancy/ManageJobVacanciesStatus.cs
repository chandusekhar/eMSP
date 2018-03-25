using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using eMSP.DataModel;
using System.Data.Entity;

namespace eMSP.Data.DataServices.JobVacancies
{
    class ManageJobVacanciesStatus
    {
        #region Initialization

        internal static eMSPEntities db;

        static ManageJobVacanciesStatus()
        {

        }

        #endregion

        #region Get
        internal static async Task<List<tblJobVacanciesStatu>> GetJobVacanciesStatuses()
        {
            try
            {
                using (db = new eMSPEntities())
                {
                    return await Task.Run(() => db.tblJobVacanciesStatus
                                                  .Where(x => (x.IsDeleted ?? false) == false).OrderByDescending(x => x.ID).ToList());


                }
            }
            catch (Exception)
            {
                throw;

            }
        }

        #endregion

        #region Insert

        internal static async Task<tblJobVacanciesStatu> AddJobVacanciesStatus(tblJobVacanciesStatu data)
        {
            try
            {
                using (db = new eMSPEntities())
                {
                    db.tblJobVacanciesStatus.Add(data);

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

        //internal static async Task<tblVacancieSkill> UpdateVacancySkills(long a, tblVacancy vacancy)
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

        //internal static async Task DeleteVacancySkills(long Id)
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
