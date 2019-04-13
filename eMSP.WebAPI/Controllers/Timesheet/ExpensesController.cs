using eMSP.Data.DataServices.Candidate;
using eMSP.Data.DataServices.MSP;
using eMSP.Data.DataServices.Shared;
using eMSP.ViewModel.Candidate;
using eMSP.ViewModel.MSP;
using eMSP.ViewModel.Shared;
using eMSP.WebAPI.Controllers.Helpers;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;

namespace eMSP.WebAPI.Controllers.Timesheet
{
    [RoutePrefix("api/expenses")]
    [AllowAnonymous]
    [Authorize(Roles = ApplicationRoles.ExpenseSpentFull)]
    public class ExpensesController : ApiController
    {
        #region Intialisation

        private CandidateManager CandidateService;
        private MSPManager MSPService;
        string userId;

        public ExpensesController()
        {
            CandidateService = new CandidateManager();
            MSPService = new MSPManager();
        }

        #endregion

        #region Get

        [Route("getExpenseDetails")]
        [HttpPost]
        [Authorize(Roles = ApplicationRoles.ExpenseSpentView)]
        [ResponseType(typeof(CandidateSubmissionSpendViewModel))]
        public async Task<IHttpActionResult> GetExpense(long ExpenseId)
        {
            try
            {
                return Ok(await CandidateService.GetExpenseDetails(ExpenseId));
            }
            catch (Exception)
            {
                throw;
            }
        }

        [Route("getCandidateExpenseSpend")]
        [HttpPost]
        [Authorize(Roles = ApplicationRoles.ExpenseSpentView)]
        [ResponseType(typeof(List<CandidateSubmissionSpendViewModel>))]
        public async Task<IHttpActionResult> GetCandidateExpenseSpend(long PlacementId)
        {
            try
            {                
                return Ok(await CandidateService.GetCandidateExpenseSpend(PlacementId));
            }
            catch (Exception)
            {
                throw;
            }
        }

        [Route("getPayperiodExpenceSubmitted")]
        [HttpPost]
        [Authorize(Roles = ApplicationRoles.ExpenseSpentView)]
        [ResponseType(typeof(List<CandidateSubmissionSpendViewModel>))]
        public async Task<IHttpActionResult> GetPayperiodExpenseSubmitted(long PayperiodId)
        {
            try
            {
                return Ok(await MSPService.GetPayperiodExpenseSpends(PayperiodId));
            }
            catch (Exception)
            {
                throw;
            }
        }

        [Route("getMSPSpendCategory")]
        [HttpPost]
        [Authorize(Roles = ApplicationRoles.ExpenseSpentView)]
        [ResponseType(typeof(List<MSPSpendCategoryViewModel>))]
        public async Task<IHttpActionResult> GetMSPSpendCategory()
        {
            try
            {
                return Ok(await MSPService.GetMSPSpendCategory());
            }
            catch (Exception)
            {
                throw;
            }
        }
        

        #endregion

        #region Insert

        [Route("insertCandidateSpend")]
        [HttpPost]
        [Authorize(Roles = ApplicationRoles.ExpenseSpentCreate)]
        [ResponseType(typeof(CandidateSubmissionSpendViewModel))]
        public async Task<IHttpActionResult> InsertCandidateSpend(CandidateSubmissionSpendViewModel model)
        {
            try
            {
                userId = User.Identity.GetUserId();
                Helpers.Helpers.AddBaseProperties(model, "create", userId);

                model.Files.All(x => { Helpers.Helpers.AddBaseProperties(x, "create", userId); return true; });

                return Ok(await CandidateService.InsertCandidateExpenseSpent(model));
            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion

        #region update
        [Route("updateCandidateSpend")]
        [HttpPost]
        [Authorize(Roles = ApplicationRoles.ExpenseSpentCreate)]
        [ResponseType(typeof(CandidateSubmissionSpendViewModel))]
        public async Task<IHttpActionResult> UpdateCandidateSpend(CandidateSubmissionSpendViewModel model)
        {
            try
            {
                userId = User.Identity.GetUserId();
                Helpers.Helpers.AddBaseProperties(model, "update", userId);

                model.Files.All(x => { Helpers.Helpers.AddBaseProperties(x, "create", userId); return true; });

                return Ok(await CandidateService.UpdateCandidateExpenseSpent(model));
            }
            catch (Exception)
            {
                throw;
            }
        }

        [Route("approveExpense")]
        [HttpPost]
        [Authorize(Roles = ApplicationRoles.ExpenseSpentApprove)]
        public async Task<IHttpActionResult> ApproveExpense(ExpenseStateChangeViewModel model)
        {
            try
            {
                model.updatedUserID = User.Identity.GetUserId();
                model.updatedTimestamp = DateTime.Now;

                return Ok(await CandidateService.UpdateCandidateExpenseStatus(model));
            }
            catch (Exception)
            {
                throw;
            }
        }

        [Route("rejectExpense")]
        [HttpPost]
        [Authorize(Roles = ApplicationRoles.ExpenseSpentReject)]
        public async Task<IHttpActionResult> RejectExpense(ExpenseStateChangeViewModel model)
        {
            try
            {
                model.updatedUserID = User.Identity.GetUserId();
                model.updatedTimestamp = DateTime.Now;

                return Ok(await CandidateService.UpdateCandidateExpenseStatus(model));
            }
            catch (Exception)
            {
                throw;
            }
        }


        #endregion

    }
}