using eMSP.Data.DataServices.Candidate;
using eMSP.ViewModel.Candidate;
using eMSP.ViewModel.LocationBranch;
using System;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using Microsoft.AspNet.Identity;
using eMSP.WebAPI.Controllers.Helpers;
using System.Collections.Generic;

namespace eMSP.WebAPI.Controllers.Candidate
{
    [RoutePrefix("api/candidate")]
    [Authorize(Roles = ApplicationRoles.CandidateFull + "," + ApplicationRoles.CandidatePlacementFull)]
    [AllowAnonymous]
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
        [Authorize(Roles = ApplicationRoles.CandidateView)]
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
        [Authorize(Roles = ApplicationRoles.CandidateView)]
        [ResponseType(typeof(CandidateCreateModel))]
        public async Task<IHttpActionResult> GetCandidate(int candidateId)
        {
            try
            {
                return Ok(await CandidateService.GetCandidate(candidateId));
            }
            catch (Exception)
            {

                throw;
            }
        }

        [Route("getCandidateSubmission")]
        [HttpPost]
        [Authorize(Roles = ApplicationRoles.CandidateView)]
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
        [Authorize(Roles = ApplicationRoles.CandidateView)]
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

        [Route("getAllPlacedCandidates")]
        [HttpGet]
        [Authorize(Roles = ApplicationRoles.CandidatePlacementView)]
        [ResponseType(typeof(List<CandidatePlacementViewModel>))]
        public async Task<IHttpActionResult> GetAllPlacedCandidates()
        {
            try
            {
                return Ok(await CandidateService.GetPlacedCandidates());
            }
            catch (Exception)
            {

                throw;
            }
        }

        [Route("getPlacementDetails")]
        [HttpGet]
        [Authorize(Roles = ApplicationRoles.CandidatePlacementView)]
        [ResponseType(typeof(CandidatePlacementViewModel))]
        public async Task<IHttpActionResult> GetPlacementDetails(long PlacementId)
        {
            try
            {
                return Ok(await CandidateService.GetPlacementDetails(PlacementId));
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
        [Authorize(Roles = ApplicationRoles.CandidateCreate)]
        [ResponseType(typeof(CandidateCreateModel))]
        public async Task<IHttpActionResult> creatCandidate(CandidateCreateModel data)
        {
            try
            {
                string userId = User.Identity.GetUserId();

                Helpers.Helpers.AddBaseProperties(data.Candidate, "create", userId);
                foreach (var con in data.CandidateContact)
                {
                    Helpers.Helpers.AddBaseProperties(con, "create", userId);
                }

                foreach (var con in data.CandidateFile)
                {
                    Helpers.Helpers.AddBaseProperties(con, "create", userId);
                }


                return Ok(await CandidateService.CreateCandidate(data));
            }
            catch (Exception)
            {

                throw;
            }
        }

        [Route("creatCandidateSubmission")]
        [HttpPost]
        [Authorize(Roles = ApplicationRoles.CandidateCreate)]
        public async Task<IHttpActionResult> creatCandidateSubmission(CandidateSubmissionCreateModel data)
        {
            try
            {
                string userId = User.Identity.GetUserId();

                Helpers.Helpers.AddBaseProperties(data.CandidateSubmission, "create", userId);

                return Ok(await CandidateService.CreateCandidateSubmission(data));
            }
            catch (Exception)
            {

                throw;
            }
        }

        [Route("creatCandidatePlacement")]
        [HttpPost]
        [Authorize(Roles = ApplicationRoles.CandidatePlacementCreate)]
        [ResponseType(typeof(CandidatePlacementViewModel))]
        public async Task<IHttpActionResult> CreatCandidatePlacement(CandidatePlacementViewModel data)
        {
            try
            {
                string userId = User.Identity.GetUserId();

                Helpers.Helpers.AddBaseProperties(data, "create", userId);

                return Ok(await CandidateService.CreateCandidatePlacement(data));
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
        [Authorize(Roles = ApplicationRoles.CandidateCreate)]
        [ResponseType(typeof(CandidateCreateModel))]
        public async Task<IHttpActionResult> UpdateCandidate(CandidateCreateModel data)
        {
            try
            {
                string userId = User.Identity.GetUserId();
                Helpers.Helpers.AddBaseProperties(data.Candidate, "update", userId);
                foreach (var con in data.CandidateContact)
                {
                    Helpers.Helpers.AddBaseProperties(con, "create", userId);
                }

                foreach (var con in data.CandidateFile)
                {
                    Helpers.Helpers.AddBaseProperties(con, "create", userId);
                }

                return Ok(await CandidateService.UpdateCandidate(data));
            }
            catch (Exception)
            {

                throw;
            }
        }


        [Route("updateCandidateSubmission")]
        [HttpPost]
        [Authorize(Roles = ApplicationRoles.CandidateCreate)]
        //[ResponseType(typeof(CandidateSubmissionCreateModel))]
        public async Task<IHttpActionResult> UpdateCandidateSubmission(CandidateSubmissionCreateModel data)
        {
            try
            {
                string userId = User.Identity.GetUserId();
                Helpers.Helpers.AddBaseProperties(data.CandidateSubmission, "create", userId);
                return Ok(await CandidateService.UpdateCandidateSubmission(data));
            }
            catch (Exception)
            {
                throw;
            }
        }

        [Route("updateCandidatePlacement")]
        [HttpPost]
        [Authorize(Roles = ApplicationRoles.CandidatePlacementCreate)]
        [ResponseType(typeof(CandidatePlacementViewModel))]
        public async Task<IHttpActionResult> UpdateCandidatePlacement(CandidatePlacementViewModel data)
        {
            try
            {
                string userId = User.Identity.GetUserId();
                Helpers.Helpers.AddBaseProperties(data, "create", userId);
                return Ok(await CandidateService.UpdateCandidatePlacement(data));
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion

        #region Delete


        #endregion


    }
}












