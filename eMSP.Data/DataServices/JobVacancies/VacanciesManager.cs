using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using eMSP.Data.DataServices.Company;
using eMSP.ViewModel.LocationBranch;
using eMSP.Data.Extensions;
using eMSP.DataModel;
using eMSP.ViewModel.JobVacancies;

namespace eMSP.Data.DataServices.JobVacancies
{
   public class VacanciesManager
    {
        #region Initialization

        private bool IsDisposed = false;

        public VacanciesManager()
        {

        }

        #endregion

        #region Get

        public async Task<VacancyCreateModel> GetVacancy(long Id)
        {
            try
            {
                VacancyCreateModel model = null;
                tblVacancy data = await Task.Run(() => ManageVacancy.GetVacancyDetails(Id));
                model = data.ConvertToVacancy();

                return model;
            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion

        #region Insert

        public async Task<VacancyCreateModel> CreateVacancy(VacancyCreateModel data)
        {
            try
            {
                tblVacancy dataIndustry = await Task.Run(() => ManageVacancy.InsertVacancy(data.ConvertTotblVacancy()));

                return dataIndustry.ConvertToVacancy();
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion

        #region Update

        public async Task<VacancyCreateModel> UpdateVacancy(VacancyCreateModel model)
        {
            try
            {
                tblVacancy data = await Task.Run(() => ManageVacancy.UpdateVacancy(model.ConvertTotblVacancy()));
                return data.ConvertToVacancy();

            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion

        #region Delete

        public async Task DeleteVacancy(long Id)
        {
            try
            {

                await Task.Run(() => ManageVacancy.DeleteVacancy(Id));

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
                if (dispose)
                {
                    this.Dispose();
                }
                IsDisposed = true;
            }
        }

        ~VacanciesManager()
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
