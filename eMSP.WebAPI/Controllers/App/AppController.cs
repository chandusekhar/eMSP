using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using eMSP.ViewModel.MSP;
using System.Threading.Tasks;
using eMSP.Data.DataServices.Common;
using eMSP.ViewModel.App;

namespace eMSP.WebAPI.Controllers.App
{
    [RoutePrefix("api/App")]
    public class AppController : ApiController  
    {

        #region Intialisation

        private AppManager AppService;

        public AppController()
        {
            AppService = new AppManager();
        }

        #endregion

        #region Get

        [Route("getCountries")]
        [HttpGet]
        [ResponseType(typeof(List<Option>))]
        public async Task<IHttpActionResult> getCountries()
        {
            try
            {
                return Ok(await AppService.GetAllCountries());
            }
            catch (Exception)
            {

                throw;
            }
        }

        [Route("getStates")]
        [HttpPost]
        [ResponseType(typeof(List<Option>))]
        public async Task<IHttpActionResult> getStates(string Id)
        {
            try
            {
                return Ok(await AppService.GetAllStates(Convert.ToInt16(Id)));
            }
            catch (Exception)
            {

                throw;
            }
        }


        #endregion

        #region Insert

      

        #endregion

        #region Update

        

        #endregion

        #region Delete

      

        #endregion



    }
}
