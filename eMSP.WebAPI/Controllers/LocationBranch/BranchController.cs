using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using eMSP.Data.DataServices.LocationBranch;
using eMSP.ViewModel.LocationBranch;
using System.Web.Http.Description;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using eMSP.WebAPI.Controllers.Helpers;

namespace eMSP.WebAPI.Controllers.LocationBranch
{
    [RoutePrefix("api/Branch")]
    [AllowAnonymous]
    public class BranchController : ApiController
    {
        #region Intialisation

        private LocationBranchManager BranchService;
        string userId;

        public BranchController()
        {
            BranchService = new LocationBranchManager();
        }

        #endregion

        #region Get

        [Route("getAllBranches")]
        [HttpPost]
        [Authorize(Roles = ApplicationRoles.SupplierLocationBranchFull + "," + ApplicationRoles.CustomerLocationBranchFull + "," + ApplicationRoles.SupplierLocationBranchView + "," + ApplicationRoles.CustomerLocationBranchView)]
        [ResponseType(typeof(LocationBranchModel))]
        public async Task<IHttpActionResult> GetAllBranches(LocationBranchModel data)
        {
            try
            {

                return Ok(await BranchService.GetAllBranchs(data));
            }
            catch (Exception)
            {

                throw;
            }
        }

        [Route("getBranchs")]
        [HttpPost]
        [Authorize(Roles = ApplicationRoles.SupplierLocationBranchFull + "," + ApplicationRoles.CustomerLocationBranchFull + "," + ApplicationRoles.SupplierLocationBranchView + "," + ApplicationRoles.CustomerLocationBranchView)]
        [ResponseType(typeof(LocationBranchModel))]
        public async Task<IHttpActionResult> GetBranchs(LocationBranchModel data)
        {
            try
            {

                return Ok(await BranchService.GetBranchs(data));
            }
            catch (Exception)
            {

                throw;
            }
        }

        [Route("getBranchesByLocation")]
        [HttpPost]
        [Authorize(Roles = ApplicationRoles.SupplierLocationBranchFull + "," + ApplicationRoles.CustomerLocationBranchFull + "," + ApplicationRoles.SupplierLocationBranchView + "," + ApplicationRoles.CustomerLocationBranchView)]
        [ResponseType(typeof(LocationBranchModel))]
        public async Task<IHttpActionResult> GetBranchesByLocation(LocationBranchModel data)
        {
            try
            {
                return Ok(await BranchService.GetBranchesByLocation(data));
            }
            catch (Exception)
            {

                throw;
            }
        }



        #endregion

        #region Insert

        [Route("creatBranch")]
        [HttpPost]
        [Authorize(Roles = ApplicationRoles.SupplierLocationBranchFull + "," + ApplicationRoles.CustomerLocationBranchFull + "," + ApplicationRoles.SupplierLocationBranchCreate + "," + ApplicationRoles.CustomerLocationBranchCreate)]
        [ResponseType(typeof(BranchCreateModel))]
        public async Task<IHttpActionResult> creatBranch(BranchCreateModel data)
        {
            try
            {
                userId = User.Identity.GetUserId();
                Helpers.Helpers.AddBaseProperties(data, "create", userId);
                return Ok(await BranchService.CreateBranch(data));
            }
            catch (Exception)
            {

                throw;
            }
        }

        #endregion

        #region Update

        [Route("updateBranch")]
        [HttpPost]
        [Authorize(Roles = ApplicationRoles.SupplierLocationBranchFull + "," + ApplicationRoles.CustomerLocationBranchFull + "," + ApplicationRoles.SupplierLocationBranchCreate + "," + ApplicationRoles.CustomerLocationBranchCreate)]
        [ResponseType(typeof(BranchCreateModel))]
        public async Task<IHttpActionResult> UpdateBranch(BranchCreateModel data)
        {
            try
            {
                userId = User.Identity.GetUserId();
                Helpers.Helpers.AddBaseProperties(data, "update", userId);
                return Ok(await BranchService.UpdateBranch(data));
            }
            catch (Exception)
            {

                throw;
            }
        }

        #endregion

        #region Delete

        [Route("deleteBranch")]
        [HttpPost]
        [Authorize(Roles = ApplicationRoles.SupplierLocationBranchFull + "," + ApplicationRoles.CustomerLocationBranchFull + "," + ApplicationRoles.SupplierLocationBranchCreate + "," + ApplicationRoles.CustomerLocationBranchCreate)]
        [ResponseType(typeof(string))]
        public async Task<IHttpActionResult> DeleteBranch(BranchCreateModel data)
        {
            try
            {
                await BranchService.DeleteBranch(data);
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
