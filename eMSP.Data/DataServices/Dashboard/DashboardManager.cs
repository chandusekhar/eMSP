using eMSP.DataModel;
using eMSP.ViewModel.Dashboard;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eMSP.Data.DataServices.Dashboard
{
    public class DashboardManager
    {
        #region Initialization

        private bool IsDisposed = false;
        private static eMSPEntities dbContext = null;

        public DashboardManager()
        {
            dbContext = new eMSPEntities();
        }

        #endregion

        #region Get

        public async Task<DashboardViewModel> MSPDashBoard()
        {
            try
            {
                DashboardViewModel data = new DashboardViewModel();

                DashboardDataViewModel ddata = new DashboardDataViewModel();

                var listOfJobs = await dbContext.tblVacancies.ToListAsync();

                ddata.JobActiveList = listOfJobs.Select(x => new { Active = x.IsActive == true ? "Active" : "In-Active",ID=x.ID }).ToList().GroupBy(x => x.Active).Select(x => new DashboardChartDataViewModel { Name = x.Key, Count = x.Count() }).ToList();

                ddata.JobStatusList = listOfJobs.GroupBy(x => x.tblJobVacanciesStatu.Name).Select(x => new DashboardChartDataViewModel { Name = x.Key, Count = x.Count() }).ToList();

                ddata.CustomerJobsList = listOfJobs.GroupBy(x => x.tblCustomer.Name).Select(x => new DashboardChartDataViewModel { Name = x.Key, Count = x.Count() }).ToList();

                ddata.JobsMonthList = listOfJobs.GroupBy(x => x.CreatedTimestamp.ToString("MMM")).Select(x => new DashboardChartDataViewModel { Name = x.Key, Count = x.Count() }).ToList();

                ddata.CustomerMonthlyJobsList = (from list in listOfJobs
                                                          group list by new { Month = list.CreatedTimestamp.ToString("MMM"), Name = list.tblCustomer.Name } into grp
                                                          select new DashboardStackedChartDataViewModel { Month = grp.Key.Month, Name = grp.Key.Name, Count = grp.Count() }).ToList();

                var SupplierJobs = await dbContext.tblVacancySuppliers.ToListAsync();

                ddata.SupplierJobsList = SupplierJobs.GroupBy(x => x.tblSupplier.Name).Select(x => new DashboardChartDataViewModel { Name = x.Key, Count = x.Count() }).ToList();

                ddata.SupplierMonthlyJobsList = (from list in SupplierJobs
                                                          group list by new { Name = list.tblSupplier.Name, Month = list.CreatedTimestamp.ToString("MMM") } into grp
                                                          select new DashboardStackedChartDataViewModel { Name = grp.Key.Name, Month = grp.Key.Month, Count = grp.Count() }).ToList();

                var candidateSubmission = await dbContext.tblCandidateSubmissions.ToListAsync();

                ddata.SubmissionMonthlyList = candidateSubmission.GroupBy(x => x.CreatedTimestamp.ToString("MMM")).Select(x => new DashboardChartDataViewModel { Name = x.Key, Count = x.Count() }).ToList();


                var candidateProfiles = await dbContext.tblCandidates.ToListAsync();

                ddata.CandidateProfilesMonthlyList = candidateProfiles.GroupBy(x => x.CreatedTimestamp.ToString("MMM")).Select(x => new DashboardChartDataViewModel { Name = x.Key, Count = x.Count() }).ToList();


                data.ChartData = ddata;

                return data;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public async Task<DashboardViewModel> CustomerDashboard()
        {
            try
            {
                DashboardViewModel data = new DashboardViewModel();

                DashboardDataViewModel ddata = new DashboardDataViewModel();

                var listOfJobs = await dbContext.tblVacancies.ToListAsync();

                ddata.JobActiveList = listOfJobs.Select(x => new { Active = x.IsActive == true ? "Yes" : "No", ID = x.ID }).ToList().GroupBy(x => x.Active).Select(x => new DashboardChartDataViewModel { Name = x.Key, Count = x.Count() }).ToList();

                ddata.JobStatusList = listOfJobs.GroupBy(x => x.tblJobVacanciesStatu.Name).Select(x => new DashboardChartDataViewModel { Name = x.Key, Count = x.Count() }).ToList();

                ddata.CustomerJobsList = listOfJobs.GroupBy(x => x.tblCustomer.Name).Select(x => new DashboardChartDataViewModel { Name = x.Key, Count = x.Count() }).ToList();

                ddata.JobsMonthList = listOfJobs.GroupBy(x => x.CreatedTimestamp.ToString("MMM")).Select(x => new DashboardChartDataViewModel { Name = x.Key, Count = x.Count() }).ToList();

                ddata.CustomerMonthlyJobsList = (from list in listOfJobs
                                                 group list by new { Month = list.CreatedTimestamp.ToString("MMM"), Name = list.tblCustomer.Name } into grp
                                                 select new DashboardStackedChartDataViewModel { Month = grp.Key.Month, Name = grp.Key.Name, Count = grp.Count() }).ToList();

                var SupplierJobs = await dbContext.tblVacancySuppliers.ToListAsync();

                ddata.SupplierJobsList = SupplierJobs.GroupBy(x => x.tblSupplier.Name).Select(x => new DashboardChartDataViewModel { Name = x.Key, Count = x.Count() }).ToList();

                ddata.SupplierMonthlyJobsList = (from list in SupplierJobs
                                                 group list by new { Name = list.tblSupplier.Name, Month = list.CreatedTimestamp.ToString("MMM") } into grp
                                                 select new DashboardStackedChartDataViewModel { Name = grp.Key.Name, Month = grp.Key.Month, Count = grp.Count() }).ToList();

                var candidateSubmission = await dbContext.tblCandidateSubmissions.ToListAsync();

                ddata.SubmissionMonthlyList = candidateSubmission.GroupBy(x => x.CreatedTimestamp.ToString("MMM")).Select(x => new DashboardChartDataViewModel { Name = x.Key, Count = x.Count() }).ToList();

                var candidateProfiles = await dbContext.tblCandidates.ToListAsync();

                ddata.CandidateProfilesMonthlyList = candidateProfiles.GroupBy(x => x.CreatedTimestamp.ToString("MMM")).Select(x => new DashboardChartDataViewModel { Name = x.Key, Count = x.Count() }).ToList();


                data.ChartData = ddata;

                return data;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public async Task<DashboardViewModel> SupplierDashboard()
        {
            try
            {
                DashboardViewModel data = new DashboardViewModel();

                DashboardDataViewModel ddata = new DashboardDataViewModel();

                var listOfJobs = await dbContext.tblVacancies.ToListAsync();

                ddata.JobActiveList = listOfJobs.Select(x => new { Active = x.IsActive == true ? "Yes" : "No", ID = x.ID }).ToList().GroupBy(x => x.Active).Select(x => new DashboardChartDataViewModel { Name = x.Key, Count = x.Count() }).ToList();

                ddata.JobStatusList = listOfJobs.GroupBy(x => x.tblJobVacanciesStatu.Name).Select(x => new DashboardChartDataViewModel { Name = x.Key, Count = x.Count() }).ToList();

                ddata.CustomerJobsList = listOfJobs.GroupBy(x => x.tblCustomer.Name).Select(x => new DashboardChartDataViewModel { Name = x.Key, Count = x.Count() }).ToList();

                ddata.JobsMonthList = listOfJobs.GroupBy(x => x.CreatedTimestamp.ToString("MMM")).Select(x => new DashboardChartDataViewModel { Name = x.Key, Count = x.Count() }).ToList();

                ddata.CustomerMonthlyJobsList = (from list in listOfJobs
                                                 group list by new { Month = list.CreatedTimestamp.ToString("MMM"), Name = list.tblCustomer.Name } into grp
                                                 select new DashboardStackedChartDataViewModel { Month = grp.Key.Month, Name = grp.Key.Name, Count = grp.Count() }).ToList();

                var SupplierJobs = await dbContext.tblVacancySuppliers.ToListAsync();

                ddata.SupplierJobsList = SupplierJobs.GroupBy(x => x.tblSupplier.Name).Select(x => new DashboardChartDataViewModel { Name = x.Key, Count = x.Count() }).ToList();

                ddata.SupplierMonthlyJobsList = (from list in SupplierJobs
                                                 group list by new { Name = list.tblSupplier.Name, Month = list.CreatedTimestamp.ToString("MMM") } into grp
                                                 select new DashboardStackedChartDataViewModel { Name = grp.Key.Name, Month = grp.Key.Month, Count = grp.Count() }).ToList();

                var candidateSubmission = await dbContext.tblCandidateSubmissions.ToListAsync();

                ddata.SubmissionMonthlyList = candidateSubmission.GroupBy(x => x.CreatedTimestamp.ToString("MMM")).Select(x => new DashboardChartDataViewModel { Name = x.Key, Count = x.Count() }).ToList();

                var candidateProfiles = await dbContext.tblCandidates.ToListAsync();

                ddata.CandidateProfilesMonthlyList = candidateProfiles.GroupBy(x => x.CreatedTimestamp.ToString("MMM")).Select(x => new DashboardChartDataViewModel { Name = x.Key, Count = x.Count() }).ToList();


                data.ChartData = ddata;

                return data;
            }
            catch (Exception ex)
            {
                throw ex;
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
                    dbContext.Dispose();
                }
                IsDisposed = true;
            }
        }

        ~DashboardManager()
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
