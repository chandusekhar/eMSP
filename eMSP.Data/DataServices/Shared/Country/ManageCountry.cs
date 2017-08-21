using eMSP.ViewModel.Shared;
using eMSP.Data.Extensions;
using eMSP.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace eMSP.Data.DataServices.Shared
{
    class ManageCountry
    {
        #region Initialization

        internal static eMSPEntities mContext;

        static ManageCountry()
        {
            mContext = new eMSPEntities();
        }

        #endregion

        #region Get
        internal static async Task<tblCountry> GetCountrys(long Id)
        {
            try
            {
                using (var db = mContext)
                {
                    return await Task.Run(() => db.tblCountries.Where(x => x.ID == Id).SingleOrDefault());
                }
            }
            catch (Exception)
            {
                throw;

            }
        }

        internal static async Task<List<tblCountry>> GetAllCountrys(CountrySearchModel model)
        {
            try
            {
                using (var db = mContext)
                {
                    return await Task.Run(() => db.tblCountries.Where(x => x.IsActive == true && x.IsDeleted == false).ToList());
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
                using (var db = mContext)
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
                using (var db = mContext)
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
                using (var db = mContext)
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
