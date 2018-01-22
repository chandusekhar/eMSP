using eMSP.DataModel;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eMSP.Data.DataServices.Shared.Industry_Skills
{
    class ManageIndustry_Skills
    {
        #region Initialization

        internal static eMSPEntities db;

        static ManageIndustry_Skills()
        {
           
        }

        #endregion

        #region Get

        internal static async Task<tblIndustry> GetIndustry(long Id)
        {
            try
            {
                using (db = new eMSPEntities())
                {
                    return await Task.Run(() => db.tblIndustries.Where(x => x.ID == Id).SingleOrDefault());
                }
            }
            catch (Exception)
            {
                throw;

            }
        }

        internal static async Task<List<tblIndustry>> GetAllIndustries()
        {
            try
            {
                using (db = new eMSPEntities())
                {
                    return await Task.Run(() => db.tblIndustries.Where(x =>  x.IsDeleted == false).OrderByDescending(x => x.ID).ToList());
                }
            }
            catch (Exception)
            {
                throw;

            }
        }

        internal static async Task<tblIndustrySkill> GetIndustrySkill(long Id)
        {
            try
            {
                using (db = new eMSPEntities())
                {
                    return await Task.Run(() => db.tblIndustrySkills.Where(x => x.ID == Id).SingleOrDefault());
                }
            }
            catch (Exception)
            {
                throw;

            }
        }

        internal static async Task<List<tblIndustrySkill>> GetAllIndustrySkills(long Id)
        {
            try
            {
                using (db = new eMSPEntities())
                {
                    if (Id != 0)
                    {
                        return await Task.Run(() => db.tblIndustrySkills.Where(x => x.IsDeleted == false && x.IndustryID == Id).OrderByDescending(x => x.ID).ToList());
                    }
                    else
                    {
                        return await Task.Run(() => db.tblIndustrySkills.Where(x => x.IsDeleted == false).OrderByDescending(x => x.ID).ToList());
                    }

                }
            }
            catch (Exception)
            {
                throw;

            }
        }

        internal static async Task<List<tblIndustrySkill>> GetAllIndustrySkills()
        {
            try
            {
                using (db = new eMSPEntities())
                {
                    return await Task.Run(() => db.tblIndustrySkills.Where(x => x.IsDeleted == false).OrderByDescending(x => x.ID).ToList());
                }
            }
            catch (Exception)
            {
                throw;

            }
        }

        #endregion

        #region Insert

        internal static async Task<tblIndustry> InsertIndustry(tblIndustry model)
        {
            try
            {
                using (db = new eMSPEntities())
                {
                    model = db.tblIndustries.Add(model);

                    int x = await Task.Run(() => db.SaveChangesAsync());

                    return model;

                }
            }
            catch (Exception)
            {
                throw;

            }
        }
        internal static async Task<tblIndustrySkill> InsertIndustrySkill(tblIndustrySkill model)
        {
            try
            {
                using (db = new eMSPEntities())
                {
                    model = db.tblIndustrySkills.Add(model);

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

        #region Update

        internal static async Task<tblIndustry> UpdateIndustry(tblIndustry model)
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
        internal static async Task<tblIndustrySkill> UpdateIndustrySkill(tblIndustrySkill model)
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

        internal static async Task DeleteIndustry(long Id)
        {
            try
            {
                using (db = new eMSPEntities())
                {
                    tblIndustry obj = await db.tblIndustries.FindAsync(Id);
                    db.tblIndustries.Remove(obj);
                    int x = await Task.Run(() => db.SaveChangesAsync());

                }
            }
            catch (Exception)
            {
                throw;

            }
        }
        internal static async Task DeleteIndustrySkill(long Id)
        {
            try
            {
                using (db = new eMSPEntities())
                {
                    tblIndustrySkill obj = await db.tblIndustrySkills.FindAsync(Id);
                    db.tblIndustrySkills.Remove(obj);
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
