using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using eMSP.DataModel;
using System.Data.Entity;

namespace eMSP.Data.DataServices.JobVacancies
{
    class ManageMSPVacancieType
    {
        #region Initialization

        internal static eMSPEntities db;

        static ManageMSPVacancieType()
        {

        }

        #endregion

        #region Get
        internal static async Task<List<tblMSPVacancieType>> GetMSPVacancieTypes(long mspId, bool isOnlyActive)
        {
            try
            {
                using (db = new eMSPEntities())
                {
                    if (isOnlyActive)
                    {
                        return await Task.Run(() => db.tblMSPVacancieTypes
                                                   .Where(x => x.MSPID == mspId && x.IsActive == true).OrderByDescending(x => x.ID).ToList());
                    }
                    else
                    {
                        return await Task.Run(() => db.tblMSPVacancieTypes
                                                      .Where(x => x.MSPID == mspId).OrderByDescending(x => x.ID).ToList());
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

        internal static async Task<tblMSPVacancieType> InsertMSPVacancieType(tblMSPVacancieType model)
        {
            try
            {
                using (db = new eMSPEntities())
                {
                    model = db.tblMSPVacancieTypes.Add(model);

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

        internal static async Task<tblMSPVacancieType> UpdateMSPVacancieType(tblMSPVacancieType model)
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

        internal static async Task DeleteMSPVacancieType(long Id)
        {
            try
            {
                using (db = new eMSPEntities())
                {
                    tblMSPVacancieType obj = await db.tblMSPVacancieTypes.FindAsync(Id);
                    db.tblMSPVacancieTypes.Remove(obj);
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
