using eMSP.DataModel;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace eMSP.Data.DataServices.Shared
{
    class ManageCountry
    {
        #region Initialization

        internal static eMSPEntities db;

        static ManageCountry()
        {
             
        }

        #endregion

        #region Get
        internal static async Task<tblCountry> GetCountry(long Id)
        {
            try
            {
                using ( db = new eMSPEntities())
                {
                    return await Task.Run(() => db.tblCountries.Where(x => x.ID == Id).SingleOrDefault());
                }
            }
            catch (Exception)
            {
                throw;

            }
        }

        internal static async Task<List<tblCountry>> GetAllCountries()
        {
            try
            {
                using ( db = new eMSPEntities())
                {
                    return await Task.Run(() => db.tblCountries.Where(x => x.IsDeleted == false).ToList());
                }
            }
            catch (Exception)
            {
                throw;

            }
        }

        #endregion

        #region Insert

        internal static async Task<tblCountry> InsertCountry(tblCountry model)
        {
            try
            {
                using ( db = new eMSPEntities())
                {
                    model = db.tblCountries.Add(model);

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

        internal static async Task<tblCountry> UpdateCountry(tblCountry model)
        {
            try
            {
                using ( db = new eMSPEntities())
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

        internal static async Task DeleteCountry(long Id)
        {
            try
            {
                using ( db = new eMSPEntities())
                {
                    tblCountry obj = await db.tblCountries.FindAsync(Id);
                    db.tblCountries.Remove(obj);
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
