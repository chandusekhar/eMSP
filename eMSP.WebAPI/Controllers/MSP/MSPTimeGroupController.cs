using eMSP.Data.DataServices.MSP;
using eMSP.ViewModel;
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
    [RoutePrefix("api/MSPTimeGroup")]
    
    //[Authorize(Roles = ApplicationRoles.QuestionFull)]
    [AllowAnonymous]
    public class MSPTimeGroupController : ApiController
    {
        #region Intialisation

        private MSPManager Service;
        string userId;

        public MSPTimeGroupController()
        {
            Service = new MSPManager();
        }

        #endregion

        #region "CRUD"

        [Route("getAllMSPTimeGroup")]
        [HttpGet]
        //[Authorize(Roles =ApplicationRoles.MSPTimeGroupView)]
        [ResponseType(typeof(QuestionViewModel))]
        public async Task<IHttpActionResult> GetAllMSPTimeGroup()
        {
            try
            {
                return Ok(await Service.GetMSPTimeGroups());
            }
            catch (Exception)
            {
                throw;
            }
        }


        //[Route("save")]
        //[HttpPost]
        //[ResponseType(typeof(QuestionViewModel))]
        //[Authorize(Roles = ApplicationRoles.QuestionCreate)]
        //public async Task<IHttpActionResult> Save(QuestionViewModel model)
        //{
        //    try
        //    {
        //        userId = User.Identity.GetUserId();
        //        Helpers.Helpers.AddBaseProperties(model, "create", userId);
        //        return Ok(await Service.Save(model));

        //    }
        //    catch (Exception)
        //    {
        //        throw;
        //    }
        //}

        //[Route("update")]
        //[HttpPost]
        //[ResponseType(typeof(QuestionViewModel))]
        //public async Task<IHttpActionResult> Update(QuestionViewModel model)
        //{
        //    try
        //    {
        //        userId = User.Identity.GetUserId();
        //        Helpers.Helpers.AddBaseProperties(model, "update", userId);
        //        return Ok(await Service.Update(model.ID, model));

        //    }
        //    catch (Exception)
        //    {
        //        throw;
        //    }
        //}

        //[Route("changestatus")]
        //[HttpPost]
        //[ResponseType(typeof(QuestionViewModel))]
        //public async Task<IHttpActionResult> ChangeStatus(long ID, bool status)
        //{
        //    try
        //    {
        //        userId = User.Identity.GetUserId();
        //        return Ok(await Service.ChangeStatus(ID, status,userId));
        //    }
        //    catch (Exception)
        //    {
        //        throw;
        //    }
        //}

        #endregion
    }
}
