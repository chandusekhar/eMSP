using eMSP.Data.DataServices.Candidate;
using eMSP.ViewModel.Candidate;
using eMSP.ViewModel.LocationBranch;
using System;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using eMSP.WebAPI.Controllers.Helpers;
using System.Collections.Generic;
using eMSP.WebAPI.Models;
using System.Net.Http;
using eMSP.WebAPI.Utility;
using eMSP.Data.DataServices.Users;
using eMSP.ViewModel.User;
using eMSP.Data.DataServices.Roles;

namespace eMSP.WebAPI.Controllers.Candidate
{
    [RoutePrefix("api/candidate")]
    [Authorize(Roles = ApplicationRoles.CandidateFull + "," + ApplicationRoles.PlacementFull)]
    [AllowAnonymous]
    public class CandidateController : ApiController
    {


        #region Intialisation

        private CandidateManager CandidateService;
        private ApplicationUserManager _userManager;
        private UserManger dao;
        private RoleManager roleManager;

        public CandidateController()
        {
            CandidateService = new CandidateManager();
            dao = new UserManger();
            roleManager= new RoleManager();
        }
        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? Request.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
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
        [HttpGet]
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

        [Route("getAllSubmissions")]
        [HttpGet]
        [Authorize(Roles = ApplicationRoles.CandidateView)]        
        public async Task<IHttpActionResult> GetAllSubmissions()
        {
            try
            {
                return Ok(await CandidateService.GetAllSubmissions());
            }
            catch (Exception)
            {
                throw;
            }
        }

        [Route("getCandidateDetails")]
        [HttpPost]
        [Authorize(Roles = ApplicationRoles.CandidateView)]
        [ResponseType(typeof(CandidateSubmissionModel))]
        public async Task<IHttpActionResult> GetCandidateDetails(int SubmissionId)
        {
            try
            {
                return Ok(await CandidateService.GetCandidateDetails(SubmissionId));
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
        [Authorize(Roles = ApplicationRoles.PlacementView)]        
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
        [Authorize(Roles = ApplicationRoles.PlacementView)]
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

        [Route("getPlacementByCandidateId")]
        [HttpGet]
        [Authorize(Roles = ApplicationRoles.PlacementView)]
        [ResponseType(typeof(CandidatePlacementViewModel))]
        public async Task<IHttpActionResult> GetPlacementByCandidateId(long CandidateId)
        {
            try
            {
                return Ok(await CandidateService.GetPlacementByCandidateId(CandidateId));
            }
            catch (Exception)
            {

                throw;
            }
        }

        [Route("getSupplierCandidatePlacementDetails")]
        [HttpGet]
        [AllowAnonymous]
        public async Task<IHttpActionResult> GetSupplierCandidatePlacementDetails(long SuplierId)
        {
            try
            {
                return Ok(await CandidateService.GetSupplierCandidatePlacement(SuplierId));
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
                var user = new ApplicationUser() { UserName = data.Candidate.Email, Email = data.Candidate.Email };

                IdentityResult result = await UserManager.CreateAsync(user, AppConstant.AppPassword);

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
        [Authorize(Roles = ApplicationRoles.PlacementCreate)]
        [ResponseType(typeof(CandidatePlacementViewModel))]
        public async Task<IHttpActionResult> CreatCandidatePlacement(CreateCandidatePlacementViewModel data)
        {
            try
            {   
                string userId = User.Identity.GetUserId();

                var candidateRole = await Task.Run(() => roleManager.GetRoleGroupByName("Candidate"));

                UserCreateModel dataUser = new UserCreateModel
                {
                    firstName = data.firstName,
                    lastName = data.lastName,                    
                    emailAddress = data.email,
                    roleGroupId = candidateRole?.id,
                    companyType="Candidate"
                };

                var user = new ApplicationUser() { UserName = dataUser.emailAddress, Email = dataUser.emailAddress };

                IdentityResult result = await UserManager.CreateAsync(user, AppConstant.AppPassword);

                if (!result.Succeeded)
                {
                    return GetErrorResult(result);
                }

                dataUser.userId = user.Id;
                Helpers.Helpers.AddBaseProperties(dataUser, "create", userId);
                var createdUser = await dao.CreateUser(dataUser);

                CandidatePlacementViewModel dataCP = new CandidatePlacementViewModel
                {
                    SubmissionID = data.SubmissionID,
                    TimeGroupID = data.timeGroup
                };
                Helpers.Helpers.AddBaseProperties(dataCP, "create", userId);

                return Ok(await CandidateService.CreateCandidatePlacement(dataCP));
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
        public async Task<IHttpActionResult> UpdateCandidateSubmission(CandidateSubmissionCreateModel data)
        {
            try
            {
                string userId = User.Identity.GetUserId();
                Helpers.Helpers.AddBaseProperties(data.CandidateSubmission, "update", userId);
                return Ok(await CandidateService.UpdateCandidateSubmission(data));
            }
            catch (Exception)
            {
                throw;
            }
        }

        [Route("updateCandidatePlacement")]
        [HttpPost]
        [Authorize(Roles = ApplicationRoles.PlacementCreate)]
        public async Task<IHttpActionResult> UpdateCandidatePlacement(CreateCandidatePlacementViewModel data)
        {
            try
            {
                string userId = User.Identity.GetUserId();

                var user = await UserManager.FindByEmailAsync(data.email);

                var token = await UserManager.GeneratePasswordResetTokenAsync(user.Id);

                IdentityResult result = await UserManager.ResetPasswordAsync(user.Id, token, data.password);

                if (result.Succeeded)
                {
                    user.UserName = data.email;

                    result = await UserManager.UpdateAsync(user);

                    if (!result.Succeeded)
                    {
                        return GetErrorResult(result);
                    }
                }
                else
                {
                    return GetErrorResult(result);
                }

                CandidatePlacementViewModel dataCP = new CandidatePlacementViewModel
                {
                    SubmissionID = data.SubmissionID,
                    TimeGroupID = data.timeGroup,
                    isActive = data.formIsActive
                };
                Helpers.Helpers.AddBaseProperties(dataCP, "update", userId);

                return Ok(await CandidateService.UpdateCandidatePlacement(dataCP));
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion

        #region Delete


        #endregion

        private IHttpActionResult GetErrorResult(IdentityResult result)
        {
            if (result == null)
            {
                return InternalServerError();
            }

            if (!result.Succeeded)
            {
                if (result.Errors != null)
                {
                    foreach (string error in result.Errors)
                    {
                        ModelState.AddModelError("errors", error);
                    }
                }

                if (ModelState.IsValid)
                {
                    // No ModelState errors are available to send, so just return an empty BadRequest.
                    return BadRequest();
                }

                return BadRequest(ModelState);
            }

            return null;
        }

    }
}












