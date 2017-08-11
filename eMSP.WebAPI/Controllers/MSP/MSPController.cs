using eMSP.Data.DataServices.MSP;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using eMSP.ViewModel.MSP;

namespace eMSP.WebAPI.Controllers.MSP
{
    [RoutePrefix("api/mspdetails")]
    public class MSPController : ApiController
    {
        private ManageMSP mService;

        public MSPController()
        {
            mService = new ManageMSP();
        }

        [Route("~api/mspdetails")]
        [HttpPost]
        [ResponseType(typeof(MSPDetailsUIModel))]
        public async Task<IHttpActionResult> GetMspDetails(string id)
        {
            try
            {
                return Ok(await mService.GetMspDetails(Convert.ToInt64(id)));
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
