using eMSP.DataModel;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace eMSP.Data.DataServices.Shared
{
    class ManageState
    {
        #region Initialization

        internal static eMSPEntities db;

        static ManageState()
        {
          
        }

        #endregion

        #region Get
        internal static async Task<tblCountryState> GetState(long Id)
        {
            try
            {
                using ( db = new eMSPEntities())
                {
                    return await Task.Run(() => db.tblCountryStates.Where(x => x.ID == Id).SingleOrDefault());
                }
            }
            catch (Exception)
            {
                throw;

            }
        }

        internal static async Task<List<tblCountryState>> GetAllStates(long countryId)
        {
            try
            {
                using (db = new eMSPEntities())
                {
                    return await Task.Run(() => db.tblCountryStates.Where(x => x.IsDeleted == false && x.CountryID == countryId).OrderByDescending(x => x.ID).ToList());
                }
            }
            catch (Exception)
            {
                throw;

            }
        }

        #endregion

        #region Insert

        internal static async Task<tblCountryState> InsertState(tblCountryState model)
        {
            try
            {
                using (db = new eMSPEntities())
                {
                    model = db.tblCountryStates.Add(model);

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

        internal static async Task<tblCountryState> UpdateState(tblCountryState model)
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

        internal static async Task DeleteState(long Id)
        {
            try
            {
                using (db = new eMSPEntities())
                {
                    tblCountryState obj = await db.tblCountryStates.FindAsync(Id);
                    db.tblCountryStates.Remove(obj);
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
