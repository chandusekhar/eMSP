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
    class ManageState
    {
        #region Initialization

        internal static eMSPEntities mContext;

        static ManageState()
        {
            mContext = new eMSPEntities();
        }

        #endregion

        #region Get
        internal static async Task<tblCountryState> GetStates(long Id)
        {
            try
            {
                using (var db = mContext)
                {
                    return await Task.Run(() => db.tblCountryStates.Where(x => x.ID == Id).SingleOrDefault());
                }
            }
            catch (Exception)
            {
                throw;

            }
        }

        internal static async Task<List<tblCountryState>> GetAllStates(StateSearchModel model)
        {
            try
            {
                using (var db = mContext)
                {
                    return await Task.Run(() => db.tblCountryStates.Where(x => x.IsActive == true
                    && x.IsDeleted == false && x.CountryID == model.countryId).ToList());
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
                using (var db = mContext)
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

        internal static async Task DeleteState(long Id)
        {
            try
            {
                using (var db = mContext)
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
