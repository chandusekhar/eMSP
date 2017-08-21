using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http.Results;
using System.Web.Http;
using System.Web.Http.Description;
using eMSP.ViewModel.Shared;
using eMSP.Data.DataServices.Shared;
using System.Threading.Tasks;

namespace eMSP.WebAPI.Controllers.Shared
{
    [RoutePrefix("api/settings")]
    public class CountryController
    {
        #region Intialisation

        private CountryManager CountryService;

        public CountryController()
        {
            CountryService = new CountryManager();
        }

        #endregion

        #region Get

        [Route("getCountry")]
        [HttpGet]
        [ResponseType(typeof(CountryCreateModel))]
        public async Task<IHttpActionResult> GetCountry(CountryModel data)
        {
            try
            {
                return Ok(await CountryService.GetCountry(data));
            }
            catch (Exception)
            {
                throw;
            }
        }

        [Route("GetAllCountrys")]
        [HttpGet]
        [ResponseType(typeof(CountryCreateModel))]
        public async Task<IHttpActionResult> GetAllCountrys(CountrySearchModel data)
        {
            try
            {
                return Ok(await CountryService.GetAllCountry(data));
            }
            catch (Exception)
            {
                throw;
            }
        }


        #endregion
    }
}