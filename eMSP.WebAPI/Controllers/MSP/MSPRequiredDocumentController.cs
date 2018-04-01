using eMSP.Data.DataServices.MSP;
using eMSP.ViewModel.MSP;
using eMSP.WebAPI.Controllers.Helpers;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;

namespace eMSP.WebAPI.Controllers.MSP
{
    [RoutePrefix("api/MSPRequiredDocument")]
    [Queryable]
    [AllowAnonymous]
    [Authorize(Roles = ApplicationRoles.DocumentFull)]
    public class MSPRequiredDocumentController : ApiController
    {
        #region Intialisation

        private ManageMSPRequiredDocuments Service;
        string userId;

        public MSPRequiredDocumentController()
        {
            Service = new ManageMSPRequiredDocuments();
        }

        #endregion

        #region "CRUD"

        [Route("get")]
        [HttpPost]
        [ResponseType(typeof(RequiredDocumentViewModel))]
        [Authorize(Roles = ApplicationRoles.DocumentCreate + "," + ApplicationRoles.DocumentView)]
        public async Task<IHttpActionResult> Get()
        {
            try
            {
                return Ok(await Service.Get());
            }
            catch (Exception)
            {
                throw;
            }
        }


        [Route("save")]
        [HttpPost]
        [ResponseType(typeof(RequiredDocumentViewModel))]
        [Authorize(Roles = ApplicationRoles.DocumentCreate)]
        public async Task<IHttpActionResult> Save(RequiredDocumentViewModel model)
        {
            try
            {
                userId = User.Identity.GetUserId();
                Helpers.Helpers.AddBaseProperties(model, "create", userId);
                return Ok(await Service.Save(model));

            }
            catch (Exception)
            {
                throw;
            }
        }

        [Route("update")]
        [HttpPost]
        [ResponseType(typeof(RequiredDocumentViewModel))]
        public async Task<IHttpActionResult> Update(RequiredDocumentViewModel model)
        {
            try
            {
                userId = User.Identity.GetUserId();
                Helpers.Helpers.AddBaseProperties(model, "update", userId);
                return Ok(await Service.Update(model.ID, model));

            }
            catch (Exception)
            {
                throw;
            }
        }

        [Route("changestatus")]
        [HttpPost]
        [ResponseType(typeof(RequiredDocumentViewModel))]
        public async Task<IHttpActionResult> ChangeStatus(long ID, bool status)
        {
            try
            {
                userId = User.Identity.GetUserId();
                return Ok(await Service.ChangeStatus(ID, status, userId));
            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion
    }
}
