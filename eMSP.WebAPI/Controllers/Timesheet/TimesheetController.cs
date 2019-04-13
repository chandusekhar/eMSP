using eMSP.Data.DataServices.Candidate;
using eMSP.Data.DataServices.MSP;
using eMSP.ViewModel.Candidate;
using eMSP.ViewModel.MSP;
using eMSP.WebAPI.Controllers.Helpers;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;

namespace eMSP.WebAPI.Controllers.Timesheet
{
    [RoutePrefix("api/timesheet")]
    [AllowAnonymous]
    [Authorize(Roles = ApplicationRoles.MSPPayPeriodFull)]
    public class TimesheetController : ApiController
    {
        #region Intialisation

        private MSPManager MSPManagerService;
        private CandidateManager CandidateManager;

        string userId;

        public TimesheetController()
        {
            MSPManagerService = new MSPManager();
            CandidateManager = new CandidateManager();
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

        [Route("getTimesheetStatus")]
        [HttpPost]
        [Authorize(Roles = ApplicationRoles.TimesheetStatusView)]
        [ResponseType(typeof(List<TimesheetStatusViewModel>))]
        public async Task<IHttpActionResult> GetTimesheetStatus()
        {
            try
            {
                return Ok(await MSPManagerService.GetTimesheetStatus());
            }
            catch (Exception)
            {
                throw;
            }
        }

        [Route("getAllTimesheetEntries")]
        [HttpGet]
        [Authorize(Roles = ApplicationRoles.TimesheetView)]
        [ResponseType(typeof(CandidateTimesheetViewModel))]
        public async Task<IHttpActionResult> GetCandidateTimesheet()
        {
            try
            {
                return Ok(await CandidateManager.GetAllTimesheetEntries());
            }
            catch (Exception)
            {
                throw;
            }
        }

        [Route("getCandidateTimesheet")]
        [HttpGet]
        [Authorize(Roles = ApplicationRoles.TimesheetView)]
        [ResponseType(typeof(CandidateTimesheetViewModel))]
        public async Task<IHttpActionResult> GetCandidateTimesheet(long PlacementId)
        {
            try
            {
                return Ok(await CandidateManager.GetCandidateTimesheetDetails(PlacementId));
            }
            catch (Exception)
            {
                throw;
            }
        }

        [Route("getCandidateTimesheetDetails")]
        [Authorize(Roles = ApplicationRoles.TimesheetView)]        
        [ResponseType(typeof(CandidateTimesheetViewModel))]
        public async Task<IHttpActionResult> GetCandidateTimesheet(long PlacementId , long PayPeriodId)
        {
            try
            {
                return Ok(await CandidateManager.GetCandidateTimesheetDetails(PlacementId, PayPeriodId));
            }
            catch (Exception)
            {
                throw;
            }
        }

        [Route("getTimesheetDetailsById")]
        [HttpPost]
        [Authorize(Roles = ApplicationRoles.TimesheetView)]
        [ResponseType(typeof(CandidateTimesheetViewModel))]
        public async Task<IHttpActionResult> GetTimesheetDetailsById(long Id)
        {
            try
            {
                return Ok(await CandidateManager.GetTimesheetDetailsById(Id));
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

        [Route("insertTimeSheet")]
        [HttpPost]
        [Authorize(Roles = ApplicationRoles.TimesheetCreate)]
        [ResponseType(typeof(CandidateTimesheetViewModel))]
        public async Task<IHttpActionResult> InsertTimeSheet(CandidateTimesheetViewModel model)
        {
            try
            {
                userId = User.Identity.GetUserId();
                Helpers.Helpers.AddBaseProperties(model, "create", userId);

                return Ok(await CandidateManager.CreateCandidateTimesheet(model));
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

        [Route("updateTimeSheet")]
        [HttpPost]
        [Authorize(Roles = ApplicationRoles.TimesheetCreate)]
        [ResponseType(typeof(CandidateTimesheetViewModel))]
        public async Task<IHttpActionResult> UpdateTimeSheet(CandidateTimesheetViewModel model)
        {
            try
            {
                userId = User.Identity.GetUserId();
                Helpers.Helpers.AddBaseProperties(model, "update", userId);

                return Ok(await CandidateManager.UpdateCandidateTimesheet(model));
            }
            catch (Exception)
            {
                throw;
            }
        }

        [Route("approveTimeSheet")]
        [HttpPost]
        [Authorize(Roles = ApplicationRoles.TimesheetApprove)]
        public async Task<IHttpActionResult> approveTimeSheet(TimesheetStateChangeViewModel model)
        {
            try
            {
                model.updatedUserID = User.Identity.GetUserId();
                model.updatedTimestamp = DateTime.Now;
                return Ok(await CandidateManager.UpdateCandidateTimesheetStatus(model));
            }
            catch (Exception)
            {
                throw;
            }
        }

        [Route("rejectTimeSheet")]
        [HttpPost]
        [Authorize(Roles = ApplicationRoles.TimesheetReject)]
        public async Task<IHttpActionResult> rejectTimeSheet(TimesheetStateChangeViewModel model)
        {
            try
            {
                model.updatedUserID = User.Identity.GetUserId();
                model.updatedTimestamp = DateTime.Now;
                return Ok(await CandidateManager.UpdateCandidateTimesheetStatus(model));
            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion

    }
}