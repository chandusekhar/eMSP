using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using eMSP.DataModel;
using System.Data.Entity;

namespace eMSP.Data.DataServices.JobVacancies
{
    class ManageVacancy
    {
        #region Initialization

        internal static eMSPEntities db;

        static ManageVacancy()
        {

        }

        #endregion

        #region Get
        internal static async Task<tblVacancy> GetVacancyDetails(long Id)
        {
            try
            {
                using (db = new eMSPEntities())
                {
                    return await Task.Run(() => db.tblVacancies
                                                  .Include(a => a.tblCustomer)
                                                  .Include(a => a.tblMSPVacancieType)
                                                  .Where(x => x.ID == Id).SingleOrDefault());


                }
            }
            catch (Exception)
            {
                throw;

            }
        }


        internal static async Task<List<tblVacancy>> GetAllVacancies(long customerId)
        {
            try
            {
                using (db = new eMSPEntities())
                {
                    if (customerId != 0)
                    {
                        return await Task.Run(() => db.tblVacancies
                                                      .Include(a => a.tblCustomer)
                                                      .Include(a => a.tblMSPVacancieType)
                                                      .Where(x => x.CustomerID == customerId)
                                                      .ToList());
                    }
                    else
                    {
                        return await Task.Run(() => db.tblVacancies
                                                      .Include(a => a.tblCustomer)
                                                      .Include(a => a.tblMSPVacancieType)
                                                      .ToList());
                    }

                }
            }
            catch (Exception)
            {
                throw;

            }
        }

        #endregion

        #region Insert

        internal static async Task<tblVacancy> InsertVacancy(tblVacancy model)
        {
            try
            {
                using (db = new eMSPEntities())
                {
                    model = db.tblVacancies.Add(model);

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

        internal static async Task<tblVacancy> UpdateVacancy(tblVacancy model)
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
