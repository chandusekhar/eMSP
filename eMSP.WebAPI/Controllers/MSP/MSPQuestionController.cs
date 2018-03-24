using eMSP.Data.DataServices.MSP;
using eMSP.ViewModel;
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
    [RoutePrefix("api/MSPQuestions")]
    [Queryable]
    [AllowAnonymous]
    public class MSPQuestionController : ApiController
    {
        #region Intialisation

        private ManageMSPQuestions Service;
        string userId;

        public MSPQuestionController()
        {
            Service = new ManageMSPQuestions();
        }

        #endregion

        #region "CRUD"

        [Route("get")]
        [HttpPost]
        [ResponseType(typeof(QuestionViewModel))]
        public async Task<IHttpActionResult> GetVacancy()
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
        [ResponseType(typeof(QuestionViewModel))]
        public async Task<IHttpActionResult> Save(QuestionViewModel model)
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
        [ResponseType(typeof(QuestionViewModel))]
        public async Task<IHttpActionResult> Update(long ID,QuestionViewModel model)
        {
            try
            {
                userId = User.Identity.GetUserId();
                Helpers.Helpers.AddBaseProperties(model, "update", userId);
                return Ok(await Service.Update(ID,model));

            }
            catch (Exception)
            {
                throw;
            }
        }

        [Route("changestatus")]
        [HttpPost]
        [ResponseType(typeof(QuestionViewModel))]
        public async Task<IHttpActionResult> ChangeStatus(long ID, bool status)
        {
            try
            {
                userId = User.Identity.GetUserId();
                return Ok(await Service.ChangeStatus(ID, status,userId));
            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion
    }
}
