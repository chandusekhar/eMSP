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

                return Ok(await CandidateService.GetCandidate(candidateId));
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












