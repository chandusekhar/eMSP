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
using eMSP.ViewModel.MSP;
using Microsoft.AspNet.Identity;
using eMSP.WebAPI.Controllers.Helpers;

namespace eMSP.WebAPI.Controllers.LocationBranch
{
    [RoutePrefix("api/Location")]
    [Queryable]
    [AllowAnonymous]
    public class LocationController : ApiController
    {
        #region Intialisation

        private LocationBranchManager LocationService;
        string userId;

        public LocationController()
        {
            LocationService = new LocationBranchManager();
        }

        #endregion

        #region Get

        [Route("getAllLocations")]
        [HttpPost]
        [Authorize(Roles = ApplicationRoles.SupplierLocationBranchFull + "," + ApplicationRoles.CustomerLocationBranchFull + "," + ApplicationRoles.SupplierLocationBranchView + "," + ApplicationRoles.CustomerLocationBranchView)]

        [ResponseType(typeof(LocationCreateModel))]
        public async Task<IHttpActionResult> GetAllLocations(LocationCreateModel data)
        {
            try
            {
                return Ok((await LocationService.GetLocations(data)).AsQueryable());
            }
            catch (Exception)
            {
                throw;
            }
        }

        [Route("getLocation")]
        [HttpPost]
        [Authorize(Roles = ApplicationRoles.SupplierLocationBranchFull + "," + ApplicationRoles.CustomerLocationBranchFull + "," + ApplicationRoles.SupplierLocationBranchView + "," + ApplicationRoles.CustomerLocationBranchView)]
        [ResponseType(typeof(LocationCreateModel))]
        public async Task<IHttpActionResult> GetLocation(LocationCreateModel data)
        {
            try
            {
                return Ok(await LocationService.GetLocations(data));
            }
            catch (Exception)
            {

                throw;
            }
        }

        [Route("getCustomerLocationBranch")]
        [HttpPost]
        [Authorize(Roles = ApplicationRoles.SupplierLocationBranchFull + "," + ApplicationRoles.CustomerLocationBranchFull + "," + ApplicationRoles.SupplierLocationBranchView + "," + ApplicationRoles.CustomerLocationBranchView)]
        [ResponseType(typeof(LocationCreateModel))]
        public async Task<IHttpActionResult> GetCustomerLocationBranch(LocationCreateModel data)
        {
            try
            {

                return Ok(await LocationService.GetCustomerLocationBranches(data));
            }
            catch (Exception)
            {

                throw;
            }
        }



        #endregion

        #region Insert

        [Route("creatLocation")]
        [HttpPost]
        [Authorize(Roles = ApplicationRoles.SupplierLocationBranchFull + "," + ApplicationRoles.CustomerLocationBranchFull + "," + ApplicationRoles.SupplierLocationBranchCreate + "," + ApplicationRoles.CustomerLocationBranchCreate)]
        [ResponseType(typeof(LocationCreateModel))]
        public async Task<IHttpActionResult> creatLocation(LocationCreateModel data)
        {
            try
            {
                userId = User.Identity.GetUserId();
                Helpers.Helpers.AddBaseProperties(data, "create", userId);

                return Ok(await LocationService.CreateLocation(data));
            }
            catch (Exception)
            {

                throw;
            }
        }

        #endregion

        #region Update

        [Route("updateLocation")]
        [HttpPost]
        [Authorize(Roles = ApplicationRoles.SupplierLocationBranchFull + "," + ApplicationRoles.CustomerLocationBranchFull + "," + ApplicationRoles.SupplierLocationBranchCreate + "," + ApplicationRoles.CustomerLocationBranchCreate)]
        [ResponseType(typeof(LocationCreateModel))]
        public async Task<IHttpActionResult> UpdateLocation(LocationCreateModel data)
        {
            try
            {
                userId = User.Identity.GetUserId();                
                Helpers.Helpers.AddBaseProperties(data, "update", userId);

                return Ok(await LocationService.UpdateLocation(data));
            }
            catch (Exception)
            {

                throw;
            }
        }

        #endregion

        #region Delete

        [Route("deleteLocation")]
        [HttpPost]
        [Authorize(Roles = ApplicationRoles.SupplierLocationBranchFull + "," + ApplicationRoles.CustomerLocationBranchFull + "," + ApplicationRoles.SupplierLocationBranchCreate + "," + ApplicationRoles.CustomerLocationBranchCreate)]
        [ResponseType(typeof(string))]
        public async Task<IHttpActionResult> DeleteLocation(LocationCreateModel data)
        {
            try
            {
                await LocationService.DeleteLocation(data);
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
