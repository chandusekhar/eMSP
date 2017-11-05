using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using eMSP.ViewModel.Shared;
using eMSP.Data.Extensions;
using eMSP.DataModel;

namespace eMSP.Data.DataServices.Shared
{
    public class CountryManager
    {
        #region Initialization

        private bool IsDisposed = false;

        public CountryManager()
        {

        }

        #endregion

        #region Get

        public async Task<CountryCreateModel> GetCountry(long Id)
        {
            try
            {
                
                tblCountry dataCountry = await Task.Run(() => ManageCountry.GetCountry(Id));
                return dataCountry.ConvertToCountry();

            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<List<CountryCreateModel>> GetAllCountries()
        {
            try
            {
               

                List<tblCountry> dataCountry = await Task.Run(() => ManageCountry.GetAllCountries());
                return dataCountry.Select(a => a.ConvertToCountry()).ToList();

            }
            catch (Exception)
            {
                throw;
            }
        }


        #endregion

        #region Insert

        public async Task<CountryCreateModel> CreateCountry(CountryCreateModel data)
        {
            try
            {

                tblCountry dataCountry = await Task.Run(() => ManageCountry.InsertCountry(data.ConvertTotblCountry()));
                return dataCountry.ConvertToCountry();

            }
            catch (Exception)
            {
                throw;
            }
        }


        #endregion

        #region Update

        public async Task<CountryCreateModel> UpdateCountry(CountryCreateModel data)
        {
            try
            {

                tblCountry dataCountry = await Task.Run(() => ManageCountry.UpdateCountry(data.ConvertTotblCountry()));
                return dataCountry.ConvertToCountry();

            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion

        #region Delete

        public async Task DeleteCountry(long Id)
        {
            try
            {
                await Task.Run(() => ManageCountry.DeleteCountry(Id));

            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion

        #region Dispose

        //protected virtual void Dispose(bool dispose)
        //{
        //    if (!IsDisposed)
        //    {
        //        this.Dispose();
        //    }

        //    IsDisposed = true;
        //}

        //~CountryManager()
        //{
        //    Dispose(false);
        //}

        //public void Dispose()
        //{
        //    Dispose(true);
        //    GC.SuppressFinalize(this);
        //}
        #endregion
    }
}
