using eMSP.DataModel;
using eMSP.ViewModel.App;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eMSP.Data.DataServices.Common
{
    public class AppManager : IDisposable
    {

        #region Initialization

        private bool IsDisposed = false;

        public AppManager()
        {

        }

        #endregion

        #region Get

        public async Task<List<Option>> GetAllCountries()
        {
            try
            {
                List<tblCountry> res = await Task.Run(() => ManageAppGet.GetAllCountries());
                return res.Select(a=>new Option{ key=a.Name, value=a.ID.ToString()}).ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<List<Option>> GetAllStates(int Id)
        {
            try
            {
                List<tblCountryState> res = await Task.Run(() => ManageAppGet.GetAllStates(Id));
                return res.Select(a => new Option { key = a.Name, value = a.ID.ToString() }).ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }


        #endregion

        #region Insert
        #endregion

        #region Update              
        #endregion

        #region Delete
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

        ~AppManager()
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
