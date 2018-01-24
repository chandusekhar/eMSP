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

        internal static async Task<tblVacancySupplier> InsertVacancySupplier(string a, tblVacancy vacancy)
        {
            try
            {
                using (db = new eMSPEntities())
                {
                    tblVacancySupplier model = new tblVacancySupplier();
                    model = db.tblVacancySuppliers.Add(new tblVacancySupplier
                    {
                        VacancyID = vacancy.ID,
                        SupplierID = Convert.ToInt16(a),
                        IsReleased = true,
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

        internal static async Task<tblVacancySupplier> UpdateVacancySupplier(string a, tblVacancy vacancy)
        {
            try
            {
                using (db = new eMSPEntities())
                {
                    long supplierId = Convert.ToInt64(a);
                    tblVacancySupplier model = await Task.Run(() => db.tblVacancySuppliers.Where(b => b.VacancyID == vacancy.ID && b.SupplierID == supplierId).FirstOrDefaultAsync());
                    if (model != null)
                    {
                        db.Entry(model).State = EntityState.Modified;

                        int x = await Task.Run(() => db.SaveChangesAsync());
                    }
                    else
                    {
                        model = await Task.Run(() => InsertVacancySupplier(a, vacancy));
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
