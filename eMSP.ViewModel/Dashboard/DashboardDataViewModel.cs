using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eMSP.ViewModel.Dashboard
{

    public partial class DashboardViewModel
    {
        public DashboardDataViewModel ChartData { get; set; }  
    }

    public partial class DashboardDataViewModel
    {
        public List<DashboardChartDataViewModel> JobActiveList { get; set; }//active/Inactive
        public List<DashboardChartDataViewModel> JobStatusList { get; set; }//different Status
        public List<DashboardChartDataViewModel> CustomerJobsList { get; set; }//jobs with different cusstomer
        public List<DashboardChartDataViewModel> JobsMonthList { get; set; }//monthly jobs list
        public List<DashboardStackedChartDataViewModel> CustomerMonthlyJobsList { get; set; } // monthly cutomer jobs
        public List<DashboardChartDataViewModel> SupplierJobsList { get; set; } // supplier jobs list
        public List<DashboardStackedChartDataViewModel> SupplierMonthlyJobsList { get; set; } // monthly supplier jobs
        public List<DashboardChartDataViewModel> SubmissionMonthlyList { get; set; } // supplier jobs list

    }

    public partial class DashboardChartDataViewModel
    {
        public string Name { get; set; }
        public int Count { get; set; }
    }


    public partial class DashboardStackedChartDataViewModel
    {
        public string Name { get; set; }
        public string Month { get; set; }
        public int Count { get; set; }
    }

}
