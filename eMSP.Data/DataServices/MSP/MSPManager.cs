using eMSP.Data.DataServices.Candidate;
using eMSP.Data.Extensions;
using eMSP.DataModel;
using eMSP.ViewModel.Candidate;
using eMSP.ViewModel.MSP;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eMSP.Data.DataServices.MSP
{
    public class MSPManager : IDisposable
    {
        #region Initialization

        private bool IsDisposed = false;

        public MSPManager() { }

        #endregion

        #region Get

        public async Task<List<MSPPayPeriodViewModel>> GetMSPPayPeriods()
        {
            try
            {
                List<tblMSPPayPeriod> res = await Task.Run(() => ManageMSPPayPeriods.GetMSPPayPeriods());

                return res.Select(pp => pp.ConvertToMSPPayPeriodViewModel()).ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<List<MSPTimeGroupViewModel>> GetMSPTimeGroups()
        {
            try
            {
                List<tblMSPTimeGroup> res = await Task.Run(() => ManageMSPTimeGroup.GetMSPTimeGroups());

                return res.Select(pp => pp.ConvertToMSPTimeGroupViewModel()).ToList();
            }
            catch (Exception)   
            {
                throw;
            }
        }

        public async Task<MSPPayPeriodViewModel> GetMSPPayPeriod(long Id)
        {
            try
            {
                tblMSPPayPeriod res = await Task.Run(() => ManageMSPPayPeriods.GetMSPPayPeriod(Id));

                return res.ConvertToMSPPayPeriodViewModel();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<List<CandidateSubmissionSpendViewModel>> GetPayperiodExpenseSpends(long PayperiodId)
        {
            try
            {
                List<tblCandidateSubmissionSpend> res = await Task.Run(() => ManageCandidateSubmissionSpend.GetPayperiodExpenseSpends(PayperiodId));

                return res.Select(x => x.ConvertToCandidateSubmissionSpendViewModel()).ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<List<MSPSpendCategoryViewModel>> GetMSPSpendCategory()
        {
            try
            {
                List<tblMSPSpendCategory> res = await Task.Run(() => ManageMSPSpendCategory.GetMSPSpendCategory());

                return res.Select(x => x.ConvertToMSPSpendCategoryViewModel()).ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<List<TimesheetStatusViewModel>> GetTimesheetStatus()
        {
            try
            {
                List<tblTimesheetStatu> res = await Task.Run(() => ManageTimesheetStatus.GetTimesheetStatus());

                return res.Select(x => x.ConvertToTimesheetStatusViewModel()).ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }



        #endregion

        #region Insert

        public async Task<MSPPayPeriodViewModel> CreateMSPPayPeriod(MSPPayPeriodViewModel data)
        {
            try
            {
               tblMSPPayPeriod model= await Task.Run(() => ManageMSPPayPeriods.InsertMSPPayPeriod(data.ConvertTotblMSPPayPeriod()));

                return model.ConvertToMSPPayPeriodViewModel();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        #endregion

        #region Update

        public async Task<MSPPayPeriodViewModel> UpdateMSPPayPeriod(MSPPayPeriodViewModel data)
        {
            try
            {
                tblMSPPayPeriod model = await Task.Run(() => ManageMSPPayPeriods.UpdateMSPPayPeriod(data.ConvertTotblMSPPayPeriod()));

                return model.ConvertToMSPPayPeriodViewModel();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        #endregion

        #region Delete

        public async Task DeleteMSPPayPeriod(long Id)
        {
            try
            {
                await Task.Run(() => ManageMSPPayPeriods.DeleteMSPPayPeriod(Id));
            }
            catch (Exception ex)
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

        ~MSPManager()
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
