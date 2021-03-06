﻿using System;
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

        internal static async Task<tblVacancieSkill> AddVacancySkills(long a, tblVacancy vacancy)
        {
            try
            {
                using (db = new eMSPEntities())
                {
                    tblVacancieSkill model = new tblVacancieSkill();
                    model = db.tblVacancieSkills.Add(new tblVacancieSkill
                    {
                        VacancyID = vacancy.ID,
                        SkillID = a,
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

        internal static async Task<tblVacancieSkill> UpdateVacancySkills(long a, tblVacancy vacancy)
        {
            try
            {
                using (db = new eMSPEntities())
                {
                    tblVacancieSkill model = await Task.Run(() => db.tblVacancieSkills.Where(b => b.VacancyID == vacancy.ID && b.SkillID == a).FirstOrDefaultAsync());

                    if (model != null)
                    {
                        db.Entry(model).State = EntityState.Modified;

                        int x = await Task.Run(() => db.SaveChangesAsync());
                    }
                    else
                    {
                        model = await Task.Run(() => AddVacancySkills(a, vacancy));
                    }
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

        internal static async Task DeleteVacancySkills(long VacancyId)
        {
            try
            {
                using (db = new eMSPEntities())
                {
                    List<tblVacancieSkill> vacancySkills = db.tblVacancieSkills.Where(q => q.VacancyID == VacancyId)
                                                                         .ToList();
                    db.tblVacancieSkills.RemoveRange(vacancySkills);
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
