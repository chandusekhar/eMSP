using eMSP.Data.DataServices.Shared;
using eMSP.ViewModel.Shared;
using eMSP.WebAPI.Controllers.Helpers;
using Microsoft.AspNet.Identity;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;

namespace eMSP.WebAPI.Controllers.Shared
{
    [RoutePrefix("api/Country")]
    [Queryable]    
    [Authorize(Roles = ApplicationRoles.CountryFull)]
    public class CountryController : ApiController
    {
        #region Intialisation

        private CountryManager CountryService;
        private StateManager StateService;
        string userId;

        public CountryController()
        {
            CountryService = new CountryManager();
            StateService = new StateManager();
        }

        #endregion

        #region Get

        [Route("getCountry")]
        [HttpPost]
        [Authorize(Roles = ApplicationRoles.CountryView)]
        [ResponseType(typeof(CountryCreateModel))]
        public async Task<IHttpActionResult> GetCountry(int id)
        {
            try
            {
                long Id = Convert.ToInt64(id);
                return Ok(await CountryService.GetCountry(Id));
            }
            catch (Exception)
            {
                throw;
            }
        }

        [Route("getAllCountries")]
        [HttpGet]
        [Authorize(Roles = ApplicationRoles.CountryView)]
        [ResponseType(typeof(CountryCreateModel))]
        public async Task<IHttpActionResult> GetAllCountries()
        {
            try
            {
                return Ok((await CountryService.GetAllCountries()).AsQueryable());
            }
            catch (Exception)
            {
                throw;
            }
        }

        [Route("getState")]
        [HttpPost]
        [Authorize(Roles = ApplicationRoles.CountryView)]
        [ResponseType(typeof(StateCreateModel))]
        public async Task<IHttpActionResult> GetState(int id)
        {
            try
            {
                long Id = Convert.ToInt64(id);
                return Ok(await StateService.GetState(Id));
            }
            catch (Exception)
            {
                throw;
            }
        }

        [Route("getAllStates")]
        [HttpPost]
        [Authorize(Roles = ApplicationRoles.CountryView)]
        [ResponseType(typeof(StateCreateModel))]
        public async Task<IHttpActionResult> GetAllStates(int countryId)
        {
            try
            {
                long Id = Convert.ToInt64(countryId);
                return Ok((await StateService.GetAllStates(Id)).AsQueryable());
            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion
        
        #region Insert

        [Route("insertCountry")]
        [HttpPost]
        [Authorize(Roles = ApplicationRoles.CountryCreate)]
        [ResponseType(typeof(CountryCreateModel))]
        public async Task<IHttpActionResult> InsertCountry(CountryCreateModel model)
        {
            try
            {
                userId = User.Identity.GetUserId();
                Helpers.Helpers.AddBaseProperties(model, "create", userId);

                return Ok(await CountryService.CreateCountry(model));
            }
            catch (Exception)
            {
                throw;
            }
        }

        [Route("insertState")]
        [HttpPost]
        [Authorize(Roles = ApplicationRoles.CountryCreate)]
        [ResponseType(typeof(StateCreateModel))]
        public async Task<IHttpActionResult> InsertState(StateCreateModel model)
        {
            try
            {
                userId = User.Identity.GetUserId();
                Helpers.Helpers.AddBaseProperties(model, "create", userId); 

                return Ok(await StateService.CreateState(model));
            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion

        #region update
        [Route("updateCountry")]
        [HttpPost]
        [Authorize(Roles = ApplicationRoles.CountryCreate)]
        [ResponseType(typeof(CountryCreateModel))]
        public async Task<IHttpActionResult> UpdateCountry(CountryCreateModel model)
        {
            try
            {
                userId = User.Identity.GetUserId();
                Helpers.Helpers.AddBaseProperties(model, "update", userId); 

                return Ok(await CountryService.UpdateCountry(model));
            }
            catch (Exception)
            {
                throw;
            }
        }

        [Route("updateState")]
        [HttpPost]
        [Authorize(Roles = ApplicationRoles.CountryCreate)]
        [ResponseType(typeof(StateCreateModel))]
        public async Task<IHttpActionResult> UpdateState(StateCreateModel model)
        {
            try
            {
                userId = User.Identity.GetUserId();
                Helpers.Helpers.AddBaseProperties(model, "update", userId);

                return Ok(await StateService.UpdateState(model));
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion

    }
}