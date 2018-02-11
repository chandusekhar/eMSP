using eMSP.ViewModel.Role;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using eMSP.Data.DataServices.Roles;
using eMSP.WebAPI.Controllers.Helpers;
using eMSP.ViewModel.User;
using eMSP.Data.DataServices.Users;

namespace eMSP.WebAPI.Controllers.Roles
{
    [RoutePrefix("api/role")]
    public class RolesController : ApiController
    {
        #region Intialisation

        private ApplicationRoleManager _AppRoleManager = null;
        private ApplicationUserManager _userManager;
        private RoleManager rm;
        private UserManger um;

        public RolesController()
        {
            rm = new RoleManager();
            um = new UserManger();
        }        

        protected ApplicationRoleManager AppRoleManager
        {
            get
            {
                return _AppRoleManager ?? Request.GetOwinContext().GetUserManager<ApplicationRoleManager>();
            }
            private set
            {
                _AppRoleManager = value;
            }
        }

        public ApplicationUserManager AppUserManager
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

        [Route("GetRole")]
        [HttpPost]
        [Authorize(Roles = ApplicationRoles.Administrator + "," + ApplicationRoles.User)]
        public async Task<IHttpActionResult> GetRole(string Id)
        {
            return Ok(await Task.Run(() => this.AppRoleManager.FindByIdAsync(Id)));
        }

        [Route("GetAllRoles")]
        [HttpPost]
        public async Task<IHttpActionResult> GetAllRoles()
        {
            return Ok(await Task.Run(() => this.AppRoleManager.Roles.ToList()));
        }

        [Route("GetRoleGroup")]
        [HttpPost]
        public async Task<IHttpActionResult> GetRoleGroup(string id)
        {
            return Ok(await Task.Run(() => rm.GetRoleGroup(id)));
        }

        [Route("GetAllRoleGroup")]
        [HttpPost]
        public async Task<IHttpActionResult> GetAllRoleGroup()
        {
            return Ok(await Task.Run(() => rm.GetAllRoleGroup()));
        }

        [Route("GetAllRoleGroupRoles")]
        [HttpPost]
        public async Task<IHttpActionResult> GetAllRoleGroupRoles(string id)
        {
            return Ok(await Task.Run(() => rm.GetRoleGroupRoles(id)));
        }

        #endregion

        #region Insert

        [Route("create")]
        public async Task<IHttpActionResult> CreateRole(RoleModel model)
        {
            var role = new IdentityRole { Name = model.Name };

            var result = await this.AppRoleManager.CreateAsync(role);

            if (!result.Succeeded)
            {
                return GetErrorResult(result);
            }

            return await Task.Run(() => this.GetRole(role.Id));
        }

        [Route("createRoleGroup")]
        public async Task<IHttpActionResult> CreateRoleGroup(RoleGroupModel model)
        {
            var Id = Guid.NewGuid().ToString();
            model.id = Id;

            return Ok(await Task.Run(() => rm.CreateRoleGroup(model)));
        }

        [Route("createRoleGroupRoles")]
        public async Task<IHttpActionResult> CreateRoleGroupRoles(RoleGroupRolesModel model)
        {
            if (string.IsNullOrEmpty(model.roleGroup.id))
            {
                var Id = Guid.NewGuid().ToString();
                model.roleGroup.id = Id;
                model.roleGroup = await Task.Run(() => rm.CreateRoleGroup(model.roleGroup));
            }
            return Ok(await Task.Run(() => rm.CreateRoleGroupRoles(model)));
        }

        //[Route("ManageUsersInRole")]
        //public async Task<IHttpActionResult> ManageUsersInRole(UsersInRoleModel model)
        //{
        //    var role = await this.AppRoleManager.FindByIdAsync(model.Id);

        //    if (role == null)
        //    {
        //        ModelState.AddModelError("", "Role does not exist");
        //        return BadRequest(ModelState);
        //    }

        //    foreach (string user in model.EnrolledUsers)
        //    {
        //        var appUser = await this.AppUserManager.FindByIdAsync(user);

        //        if (appUser == null)
        //        {
        //            ModelState.AddModelError("", String.Format("User: {0} does not exists", user));
        //            continue;
        //        }

        //        if (!this.AppUserManager.IsInRole(user, role.Name))
        //        {
        //            IdentityResult result = await this.AppUserManager.AddToRoleAsync(user, role.Name);

        //            if (!result.Succeeded)
        //            {
        //                ModelState.AddModelError("", String.Format("User: {0} could not be added to role", user));
        //            }

        //        }
        //    }

        //    foreach (string user in model.RemovedUsers)
        //    {
        //        var appUser = await this.AppUserManager.FindByIdAsync(user);

        //        if (appUser == null)
        //        {
        //            ModelState.AddModelError("", String.Format("User: {0} does not exists", user));
        //            continue;
        //        }

        //        IdentityResult result = await this.AppUserManager.RemoveFromRoleAsync(user, role.Name);

        //        if (!result.Succeeded)
        //        {
        //            ModelState.AddModelError("", String.Format("User: {0} could not be removed from role", user));
        //        }
        //    }

        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    return Ok();
        //}

        [Route("AssignUserRoles")]
        [HttpPost]
        public async Task<IHttpActionResult> UserRoles(UserRoleModel model)
        {
            UserCreateModel userModel = await Task.Run(() => um.UpdateUser(model.user));

            List<RoleModel> roles = await Task.Run(() => rm.GetRoleGroupRoles(model.roleGroup.id));
            string[] rolesList = roles.Select(x => x.Name).ToArray();

            dynamic res = await Task.Run(() => AssignRolesToUser(model.user.userId, rolesList));

            return Ok();
        }

        //[Authorize(Roles = "Admin")]
        [Route("AssignRolesToUser/{id:guid}")]
        [HttpPut]
        public async Task<IHttpActionResult> AssignRolesToUser([FromUri] string id, [FromBody] string[] rolesToAssign)
        {

            var appUser = await this.AppUserManager.FindByIdAsync(id);

            if (appUser == null)
            {
                return NotFound();
            }

            var currentRoles = await this.AppUserManager.GetRolesAsync(appUser.Id);

            var rolesNotExists = rolesToAssign.Except(this.AppRoleManager.Roles.Select(x => x.Name)).ToArray();

            if (rolesNotExists.Count() > 0)
            {

                ModelState.AddModelError("", string.Format("Roles '{0}' does not exixts in the system", string.Join(",", rolesNotExists)));
                return BadRequest(ModelState);
            }

            IdentityResult removeResult = await this.AppUserManager.RemoveFromRolesAsync(appUser.Id, currentRoles.ToArray());

            if (!removeResult.Succeeded)
            {
                ModelState.AddModelError("", "Failed to remove user roles");
                return BadRequest(ModelState);
            }

            IdentityResult addResult = await this.AppUserManager.AddToRolesAsync(appUser.Id, rolesToAssign);

            if (!addResult.Succeeded)
            {
                ModelState.AddModelError("", "Failed to add user roles");
                return BadRequest(ModelState);
            }

            return Ok();
        }


        #endregion

        #region Update


        #endregion

        #region Delete
        [Route("delete")]
        public async Task<IHttpActionResult> DeleteRole(string Id)
        {

            var role = await this.AppRoleManager.FindByIdAsync(Id);

            if (role != null)
            {
                IdentityResult result = await this.AppRoleManager.DeleteAsync(role);

                if (!result.Succeeded)
                {
                    return GetErrorResult(result);
                }

                return Ok();
            }

            return NotFound();

        }


        #endregion
    }
}