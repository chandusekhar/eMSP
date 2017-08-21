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

        public async Task<CountryCreateModel> GetCountry(CountryModel data)
        {
            try
            {
                CountryCreateModel model = null;
                long Id = Convert.ToInt64(data.id);
                tblCountry dataCountry = await Task.Run(() => ManageCountry.GetCountrys(Id));
                model = dataCountry.ConvertToCountry();

                return model;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<List<CountryCreateModel>> GetAllCountry(CountrySearchModel Model)
        {
            try
            {
                List<CountryCreateModel> res = null;

                List<tblCountry> dataCountry = await Task.Run(() => ManageCountry.GetAllCountrys(Model));
                res = dataCountry.Select(a => a.ConvertToCountry()).ToList();

                return res;
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
                CountryCreateModel model = null;

                tblCountry dataCountry = await Task.Run(() => ManageCountry.InsertCountry(data.ConvertTotblCountry()));
                model = dataCountry.ConvertToCountry();

                return model;
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
                CountryCreateModel model = null;

                tblCountry dataCountry = await Task.Run(() => ManageCountry.UpdateCountry(data.ConvertTotblCountry()));
                model = dataCountry.ConvertToCountry();

                return model;
            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion

        #region Delete

        public async Task DeleteCountry(CountryModel data)
        {
            try
            {
                long Id = Convert.ToInt64(data.id);
                await Task.Run(() => ManageCountry.DeleteCountry(Id));

            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion

        #region Dispose

        protected virtual void Dispose(bool dispose)
        {
            if (!IsDisposed)
            {
                this.Dispose();
            }

            IsDisposed = true;
        }

        ~CountryManager()
        {
            Dispose(false);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}
