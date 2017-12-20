using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using eMSP.DataModel;
using System.Data.Entity;

namespace eMSP.Data.DataServices.JobVacancies
{
    class ManageVacancySuppliers
    {
        #region Initialization

        internal static eMSPEntities db;

        static ManageVacancySuppliers()
        { }

        #endregion

        #region Get
        internal static async Task<List<tblVacancySupplier>> GetVacancySuppliers(long Id)
        {
            try
            {
                using (db = new eMSPEntities())
                {
                    return await Task.Run(() => db.tblVacancySuppliers
                                                  .Include(x => x.tblSupplier)
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

        internal static async Task<tblVacancySupplier> InsertVacancySupplier(tblVacancySupplier model)
        {
            try
            {
                using (db = new eMSPEntities())
                {
                    model = db.tblVacancySuppliers.Add(model);

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

        internal static async Task<tblVacancySupplier> UpdateVacancySupplier(tblVacancySupplier model)
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

        internal static async Task DeleteVacancySupplier(long Id)
        {
            try
            {
                using (db = new eMSPEntities())
                {
                    tblVacancySupplier obj = await db.tblVacancySuppliers.FindAsync(Id);
                    db.tblVacancySuppliers.Remove(obj);
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
