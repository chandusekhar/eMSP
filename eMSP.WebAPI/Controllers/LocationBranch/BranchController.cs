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

namespace eMSP.WebAPI.Controllers.LocationBranch
{
    [RoutePrefix("api/Branch")]
    public class BranchController : ApiController
    {
        #region Intialisation

        private LocationBranchManager BranchService;

        public BranchController()
        {
            BranchService = new LocationBranchManager();
        }

        #endregion

        #region Get

        [Route("getAllBranches")]
        [HttpPost]
        [Authorize]
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

        [Route("getBranch")]
        [HttpPost]
        [Authorize]
        [ResponseType(typeof(LocationBranchModel))]
        public async Task<IHttpActionResult> GetBranch(LocationBranchModel data)
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



        #endregion

        #region Insert

        [Route("creatBranch")]
        [HttpPost]
        [Authorize]
        [ResponseType(typeof(BranchCreateModel))]
        public async Task<IHttpActionResult> creatBranch(BranchCreateModel data)
        {
            try
            {
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
        [Authorize]
        [ResponseType(typeof(BranchCreateModel))]
        public async Task<IHttpActionResult> UpdateBranch(BranchCreateModel data)
        {
            try
            {
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
        [Authorize]
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
