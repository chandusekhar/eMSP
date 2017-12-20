using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using eMSP.DataModel;
using System.Data.Entity;

namespace eMSP.Data.DataServices.JobVacancies
{
    class ManageVacancySkills
    {
        #region Initialization

        internal static eMSPEntities db;

        static ManageVacancySkills()
        {

        }

        #endregion

        #region Get
        internal static async Task<List<tblVacancieSkill>> GetVacancySkills(long Id)
        {
            try
            {
                using (db = new eMSPEntities())
                {
                    return await Task.Run(() => db.tblVacancieSkills
                                                  .Include(x => x.tblIndustrySkill)
                                                  .Include(x => x.tblIndustry)
                                                  .Where(x => x.VacancyID == Id && (x.IsDeleted ?? false) == false).ToList());


                }
            }
            catch (Exception)
            {
                throw;

            }
        }

        #endregion

        #region Insert

        internal static async Task<tblVacancieSkill> AddVacancySkills(tblVacancieSkill model)
        {
            try
            {
                using (db = new eMSPEntities())
                {
                    model = db.tblVacancieSkills.Add(model);

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

        internal static async Task<tblVacancieSkill> UpdateVacancySkills(tblVacancieSkill model)
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

        internal static async Task DeleteVacancySkills(long Id)
        {
            try
            {
                using (db = new eMSPEntities())
                {
                    tblVacancieSkill obj = await db.tblVacancieSkills.FindAsync(Id);
                    db.tblVacancieSkills.Remove(obj);
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
