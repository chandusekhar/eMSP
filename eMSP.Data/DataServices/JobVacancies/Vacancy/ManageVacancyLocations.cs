using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using eMSP.DataModel;
using System.Data.Entity;

namespace eMSP.Data.DataServices.JobVacancies
{
    class ManageVacancyLocations
    {
        #region Initialization

        internal static eMSPEntities db;

        static ManageVacancyLocations()
        {

        }

        #endregion

        #region Get
        internal static async Task<List<tblVacancyLocation>> GetVacancyLocations(long VacancyId)
        {
            try
            {
                using (db = new eMSPEntities())
                {
                    return await Task.Run(() => db.tblVacancyLocations
                                                  .Include(x => x.tblCustomerLocationBranch.tblLocation)
                                                  .Where(x => x.VacancyID == VacancyId && (x.IsDeleted ?? false) == false)
                                                  .OrderByDescending(x => x.ID).ToList());


                }
            }
            catch (Exception)
            {
                throw;

            }
        }

        #endregion

        #region Insert

        internal static async Task<tblVacancyLocation> AddVacancyLocation(long a, tblVacancy vacancy)
        {
            try
            {
                using (db = new eMSPEntities())
                {
                    tblVacancyLocation model = new tblVacancyLocation();
                    model = db.tblVacancyLocations.Add(new tblVacancyLocation
                    {
                        VacancyID = vacancy.ID,
                        LocationID = a,
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

        internal static async Task<tblVacancyLocation> UpdateVacancyLocation(long a, tblVacancy vacancy)
        {
            try
            {
                using (db = new eMSPEntities())
                {
                    tblVacancyLocation model = await Task.Run(() => db.tblVacancyLocations.Where(b => b.VacancyID == vacancy.ID && b.LocationID == a).FirstOrDefaultAsync());
                    if (model != null)
                    {
                        db.Entry(model).State = EntityState.Modified;

                        int x = await Task.Run(() => db.SaveChangesAsync());
                    }
                    else
                    {
                        model = await Task.Run(() => AddVacancyLocation(a, vacancy));
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

        internal static async Task DeleteVacancy(long Id)
        {
            try
            {
                using (db = new eMSPEntities())
                {
                    tblVacancy obj = await db.tblVacancies.FindAsync(Id);
                    db.tblVacancies.Remove(obj);
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
