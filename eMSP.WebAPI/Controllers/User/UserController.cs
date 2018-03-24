using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using eMSP.Data.DataServices.Users;
using System.Web.Http.Description;
using eMSP.ViewModel.MSP;
using System.Threading.Tasks;
using eMSP.WebAPI.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using eMSP.ViewModel.User;
using eMSP.WebAPI.Controllers.Helpers;

namespace eMSP.WebAPI.Controllers.User
{
    [RoutePrefix("api/user")]
    [AllowAnonymous]
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
        [Authorize(Roles = ApplicationRoles.SupplierUserFull + "," + ApplicationRoles.CustomerUserFull + "," + ApplicationRoles.MSPUserFull + "," + ApplicationRoles.SupplierUserView + "," + ApplicationRoles.CustomerUserView + "," + ApplicationRoles.MSPUserView)]
        [ResponseType(typeof(UserCreateModel))]
        public async Task<IHttpActionResult> GetUser()
        {
            try
            {
                string UserID = User.Identity.GetUserId();

                return Ok(await dao.GetUser(UserID));
            }
            catch (Exception)
            {

                throw;
            }
        }


        [Route("getUsers")]
        [HttpPost]
        [Authorize(Roles = ApplicationRoles.SupplierUserFull + "," + ApplicationRoles.CustomerUserFull + "," + ApplicationRoles.MSPUserFull + "," + ApplicationRoles.SupplierUserView + "," + ApplicationRoles.CustomerUserView + "," + ApplicationRoles.MSPUserView)]
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
        [Authorize(Roles = ApplicationRoles.SupplierUserFull + "," + ApplicationRoles.CustomerUserFull + "," + ApplicationRoles.MSPUserFull + "," + ApplicationRoles.SupplierUserCreate + "," + ApplicationRoles.CustomerUserCreate + "," + ApplicationRoles.MSPUserCreate)]
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
                Helpers.Helpers.AddBaseProperties(data, "create", data.userId);
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
        [Authorize(Roles = ApplicationRoles.SupplierUserFull + "," + ApplicationRoles.CustomerUserFull + "," + ApplicationRoles.MSPUserFull + "," + ApplicationRoles.SupplierUserCreate + "," + ApplicationRoles.CustomerUserCreate + "," + ApplicationRoles.MSPUserCreate)]
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
        [Authorize(Roles = ApplicationRoles.SupplierUserFull + "," + ApplicationRoles.CustomerUserFull + "," + ApplicationRoles.MSPUserFull + "," + ApplicationRoles.SupplierUserCreate + "," + ApplicationRoles.CustomerUserCreate + "," + ApplicationRoles.MSPUserCreate)]
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
        [Authorize(Roles = ApplicationRoles.SupplierUserFull + "," + ApplicationRoles.CustomerUserFull + "," + ApplicationRoles.MSPUserFull + "," + ApplicationRoles.SupplierUserCreate + "," + ApplicationRoles.CustomerUserCreate + "," + ApplicationRoles.MSPUserCreate)]
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
