using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using eMSP.Data.DataServices.Users;
using System.Web.Http.Description;
using eMSP.ViewModel.MSP;
using eMSP.ViewModel;
using System.Threading.Tasks;
using eMSP.WebAPI.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;

namespace eMSP.WebAPI.Controllers.User
{
    [RoutePrefix("api/user")]
    public class UserController : ApiController
    {
        #region Intialisation
        private ApplicationUserManager _userManager;
        private UserManger dao;

        public UserController()
        {
            dao = new UserManger();
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
                        ModelState.AddModelError("", error);
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

        #endregion

        #region Get

        [Route("getUser")]
        [HttpPost]
        [Authorize]
        [ResponseType(typeof(UserCreateModel))]
        public async Task<IHttpActionResult> GetUser(string UserID)
        {
            try
            {

                return Ok(await dao.GetUser(UserID));
            }
            catch (Exception)
            {

                throw;
            }
        }


        [Route("getUsers")]
        [HttpPost]
        [Authorize]
        [ResponseType(typeof(List<UserModel>))]
        public async Task<IHttpActionResult> GetUsers(CompanyModel data)
        {
            try
            {
                return Ok(await dao.GetAllCompanyUsers(data));
            }
            catch (Exception)
            {

                throw;
            }
        }


        #endregion

        #region Insert

        [Route("creatUser")]
        [HttpPost]
        [Authorize]
        [ResponseType(typeof(UserCreateModel))]
        public async Task<IHttpActionResult> CreateUser(UserCreateModel data)
        {
            try
            {
                var user = new ApplicationUser() { UserName = data.emailAddress, Email = data.emailAddress };

                IdentityResult result = await UserManager.CreateAsync(user, "Welcome@123");

                if (!result.Succeeded)
                {
                    return GetErrorResult(result);
                }

                data.userId = user.Id;
                return Ok(await dao.CreateUser(data));
            }
            catch (Exception)
            {

                throw;
            }
        }

        #endregion

        #region Update

        [Route("updateUser")]
        [HttpPost]
        [Authorize]
        [ResponseType(typeof(UserCreateModel))]
        public async Task<IHttpActionResult> UpdateUser(UserCreateModel data)
        {
            try
            {
                return Ok(await dao.UpdateUser(data));
            }
            catch (Exception)
            {

                throw;
            }
        }
        [Route("updateCompanyUser")]
        [HttpPost]
        [Authorize]
        [ResponseType(typeof(UserModel))]
        public async Task<IHttpActionResult> UpdateUser(UserModel data)
        {
            try
            {
                return Ok(await dao.UpdateUser(data));
            }
            catch (Exception)
            {

                throw;
            }
        }
        #endregion

        #region Delete

        [Route("deleteUser")]
        [HttpPost]
        [Authorize]
        [ResponseType(typeof(string))]
        public async Task<IHttpActionResult> DeleteCompany(UserCreateModel data)
        {
            try
            {
                await dao.DeleteCountry(data.userId);
                return Ok("Success");
            }
            catch (Exception)
            {

                throw;
            }
        }

        #endregion

    }
}
