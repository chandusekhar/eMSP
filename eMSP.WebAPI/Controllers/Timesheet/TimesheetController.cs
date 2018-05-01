using eMSP.Data.DataServices.MSP;
using eMSP.Data.DataServices.Shared;
using eMSP.ViewModel.MSP;
using eMSP.ViewModel.Shared;
using eMSP.WebAPI.Controllers.Helpers;
using Microsoft.AspNet.Identity;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;

namespace eMSP.WebAPI.Controllers.Timesheet
{
    [RoutePrefix("api/timesheet")]
    [Queryable]
    [AllowAnonymous]
    [Authorize(Roles = ApplicationRoles.MSPPayPeriodFull)]
    public class TimesheetController : ApiController
    {
        #region Intialisation

        private MSPManager MSPManagerService;
        string userId;

        public TimesheetController()
        {
            MSPManagerService = new MSPManager();
        }

        #endregion

        #region Get

        [Route("getMSPPayPeriod")]
        [HttpPost]
        [Authorize(Roles = ApplicationRoles.MSPPayPeriodView)]
        [ResponseType(typeof(MSPPayPeriodViewModel))]
        public async Task<IHttpActionResult> GetMSPPayPeriod(long id)
        {
            try
            {
                return Ok(await MSPManagerService.GetMSPPayPeriod(id));
            }
            catch (Exception)
            {
                throw;
            }
        }

        [Route("getAllMSPPayPeriods")]
        [HttpGet]
        [Authorize(Roles = ApplicationRoles.MSPPayPeriodView)]
        [ResponseType(typeof(MSPPayPeriodViewModel))]
        public async Task<IHttpActionResult> GetMSPPayPeriods()
        {
            try
            {
                return Ok(await MSPManagerService.GetMSPPayPeriods());
            }
            catch (Exception)
            {
                throw;
            }
        }       

        #endregion

        #region Insert

        [Route("insertMSPPayPeriod")]
        [HttpPost]
        [Authorize(Roles = ApplicationRoles.MSPPayPeriodCreate)]
        [ResponseType(typeof(MSPPayPeriodViewModel))]
        public async Task<IHttpActionResult> InsertMSPPayPeriod(MSPPayPeriodViewModel model)
        {
            try
            {
                userId = User.Identity.GetUserId();
                Helpers.Helpers.AddBaseProperties(model, "create", userId);

                return Ok(await MSPManagerService.CreateMSPPayPeriod(model));
            }
            catch (Exception)
            {
                throw;
            }
        }        

        #endregion

        #region update
        [Route("updateMSPPayPeriod")]
        [HttpPost]
        [Authorize(Roles = ApplicationRoles.MSPPayPeriodCreate)]
        [ResponseType(typeof(MSPPayPeriodViewModel))]
        public async Task<IHttpActionResult> UpdateMSPPayPeriod(MSPPayPeriodViewModel model)
        {
            try
            {
                userId = User.Identity.GetUserId();
                Helpers.Helpers.AddBaseProperties(model, "update", userId);

                return Ok(await MSPManagerService.UpdateMSPPayPeriod(model));
            }
            catch (Exception)
            {
                throw;
            }
        }
        
        #endregion

    }
}