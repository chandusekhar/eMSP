using eMSP.Data.DataServices.Dashboard;
using eMSP.ViewModel.JobVacancies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;

namespace eMSP.WebAPI.Controllers.Dashboard
{
    [RoutePrefix("api/dashboard")]
    [Queryable]
    [AllowAnonymous]
    public class DashboardController : ApiController
    {
        #region Intialisation

        private DashboardManager dashboardManager;
        string userId;

        public DashboardController()
        {
            dashboardManager = new DashboardManager();
        }

        #region GET

        [Route("msp")]
        [HttpPost]
        [ResponseType(typeof(bool))]
        public async Task<IHttpActionResult> GetMSPDashboard()
        {
            try
            {
                return Ok(await dashboardManager.MSPDashBoard());
            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion

        #endregion
    }
}
