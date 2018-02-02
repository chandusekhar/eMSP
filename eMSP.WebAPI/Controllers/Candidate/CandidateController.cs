using eMSP.Data.DataServices.Candidate;
using eMSP.ViewModel.Candidate;
using eMSP.ViewModel.LocationBranch;
using System;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using Microsoft.AspNet.Identity;
using eMSP.WebAPI.Controllers.Helpers;

namespace eMSP.WebAPI.Controllers.Candidate
{
    [RoutePrefix("api/candidate")]
    public class CandidateController : ApiController
    {


        #region Intialisation

        private CandidateManager CandidateService;

        public CandidateController()
        {
            CandidateService = new CandidateManager();
        }

        #endregion

        #region Get

        [Route("getAllCandidates")]
        [HttpPost]
        [Authorize]
        [ResponseType(typeof(CandidateCreateModel))]
        public async Task<IHttpActionResult> GetAllCandidates(int SupplierId)
        {
            try
            {

                return Ok(await CandidateService.GetAllCandidates(SupplierId));
            }
            catch (Exception)
            {

                throw;
            }
        }

        [Route("getCandidate")]
        [HttpPost]
        [Authorize]
        [ResponseType(typeof(CandidateCreateModel))]
        public async Task<IHttpActionResult> GetCandidate(int candidateId)
        {
            try
            {

                return Ok(await CandidateService.GetCandidateSubmission(candidateId));
            }
            catch (Exception)
            {

                throw;
            }
        }

        [Route("getCandidateSubmission")]
        [HttpPost]
        [Authorize]
        [ResponseType(typeof(CandidateSubmissionModel))]
        public async Task<IHttpActionResult> GetCandidateSubmission(int VacancyId)
        {
            try
            {

                return Ok(await CandidateService.GetCandidateSubmission(VacancyId));
            }
            catch (Exception)
            {

                throw;
            }
        }

        [Route("getAllCandidateStatus")]
        [HttpGet]
        [Authorize]
        [ResponseType(typeof(CandidateStatusModel))]
        public async Task<IHttpActionResult> GetCandidateStatus()
        {
            try
            {

                return Ok(await CandidateService.GetCandidateStatus());
            }
            catch (Exception)
            {

                throw;
            }
        }
        #endregion

        #region Insert

        [Route("creatCandidate")]
        [HttpPost]
        [Authorize]
        [ResponseType(typeof(CandidateCreateModel))]
        public async Task<IHttpActionResult> creatCandidate(CandidateCreateModel data)
        {
            try
            {
                string userId = User.Identity.GetUserId();
               
               Helpers.Helpers.AddBaseProperties(data.Candidate,"create", userId);
               Helpers.Helpers.AddBaseProperties(data.CandidateContact[0], "create", userId);

                return Ok(await CandidateService.CreateCandidate(data));
            }
            catch (Exception)
            {

                throw;
            }
        }

        [Route("creatCandidateSubmission")]
        [HttpPost]
        [Authorize]
        [ResponseType(typeof(CandidateSubmissionModel))]
        public async Task<IHttpActionResult> creatCandidateSubmission(CandidateSubmissionModel data)
        {
            try
            {
                string userId = User.Identity.GetUserId();

                Helpers.Helpers.AddBaseProperties(data, "create", userId);

                return Ok(await CandidateService.CreateCandidateSubmission(data));
            }
            catch (Exception)
            {

                throw;
            }
        }

        #endregion

        #region Update

        [Route("updateCandidate")]
        [HttpPost]
        [Authorize]
        [ResponseType(typeof(CandidateCreateModel))]
        public async Task<IHttpActionResult> UpdateCandidate(CandidateCreateModel data)
        {
            try
            {
                string userId = User.Identity.GetUserId();
                Helpers.Helpers.AddBaseProperties(data.Candidate, "update", userId);
                Helpers.Helpers.AddBaseProperties(data.CandidateContact[0], "update", userId);                
                return Ok(await CandidateService.UpdateCandidate(data));
            }
            catch (Exception)
            {

                throw;
            }
        }


        [Route("updateCandidateSubmission")]
        [HttpPost]
        [Authorize]
        [ResponseType(typeof(CandidateSubmissionModel))]
        public async Task<IHttpActionResult> UpdateCandidateSubmission(CandidateSubmissionModel data)
        {
            try
            {
                string userId = User.Identity.GetUserId();
                Helpers.Helpers.AddBaseProperties(data, "update", userId);
                Helpers.Helpers.AddBaseProperties(data.CandidateStatus, "update", userId);
                return Ok(await CandidateService.UpdateCandidateSubmission(data));
            }
            catch (Exception)
            {

                throw;
            }
        }
        #endregion

        #region Delete

        //[Route("deleteCandidate")]
        //[HttpPost]
        //[Authorize]
        //[ResponseType(typeof(string))]
        //public async Task<IHttpActionResult> DeleteBranch(BranchCreateModel data)
        //{
        //    try
        //    {
        //        await BranchService.DeleteBranch(data);
        //        return Ok("Success");
        //    }
        //    catch (Exception)
        //    {

        //        throw;
        //    }
        //}

        #endregion


    }
}












