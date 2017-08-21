﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using eMSP.ViewModel.Shared;
using eMSP.Data.Extensions;
using eMSP.DataModel;

namespace eMSP.Data.DataServices.Shared
{
    public class StateManager
    {
        #region Initialization

        private bool IsDisposed = false;

        public StateManager()
        {

        }

        #endregion

        #region Get

        public async Task<StateCreateModel> GetCompany(StateModel data)
        {
            try
            {
                StateCreateModel model = null;
                long Id = Convert.ToInt64(data.id);
                tblCountryState dataState = await Task.Run(() => ManageState.GetStates(Id));
                model = dataState.ConvertToCountryState();

                return model;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<List<StateCreateModel>> GetAllCompanies(StateSearchModel Model)
        {
            try
            {
                List<StateCreateModel> res = null;

                List<tblCountryState> dataState = await Task.Run(() => ManageState.GetAllStates(Model));
                res = dataState.Select(a => a.ConvertToCountryState()).ToList();

                return res;
            }
            catch (Exception)
            {
                throw;
            }
        }


        #endregion

        #region Insert

        public async Task<StateCreateModel> CreateCompany(StateCreateModel data)
        {
            try
            {
                StateCreateModel model = null;

                tblCountryState dataState = await Task.Run(() => ManageState.InsertState(data.ConvertTotblCountryState()));
                model = dataState.ConvertToCountryState();

                return model;
            }
            catch (Exception)
            {
                throw;
            }
        }


        #endregion

        #region Update

        public async Task<StateCreateModel> UpdateCompany(StateCreateModel data)
        {
            try
            {
                StateCreateModel model = null;

                tblCountryState dataState = await Task.Run(() => ManageState.UpdateState(data.ConvertTotblCountryState()));
                model = dataState.ConvertToCountryState();

                return model;
            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion

        #region Delete

        public async Task DeleteCompany(CountryModel data)
        {
            try
            {
                long Id = Convert.ToInt64(data.id);
                await Task.Run(() => ManageState.DeleteState(Id));

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

        ~StateManager()
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
