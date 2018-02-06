using eMSP.Data.DataServices.Shared;
using eMSP.ViewModel.Shared;
using Microsoft.AspNet.Identity;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;

namespace eMSP.WebAPI.Controllers.Shared
{
    [RoutePrefix("api/Industry")]
    [Queryable]
    public class IndustrySkillController : ApiController
    {
        #region Intialisation

        private Industry_SkillsManager IndustryService;
        string userId;

        public IndustrySkillController()
        {
            IndustryService = new Industry_SkillsManager();            
        }

        #endregion

        #region Get

        [Route("getIndustry")]
        [HttpPost]
        [ResponseType(typeof(IndustryCreateModel))]
        public async Task<IHttpActionResult> GetIndustry(int id)
        {
            try
            {
             
                return Ok(await IndustryService.GetIndustry(id));
            }
            catch (Exception)
            {
                throw;
            }
        }

        [Route("getAllIndustries")]
        [HttpGet]
        [ResponseType(typeof(IndustryCreateModel))]
        public async Task<IHttpActionResult> GetAllIndustries()
        {
            try
            {
                return Ok((await IndustryService.GetAllIndustries()).AsQueryable());
            }
            catch (Exception)
            {
                throw;
            }
        }

        [Route("getSkill")]
        [HttpPost]
        [ResponseType(typeof(IndustrySkillsCreateModel))]
        public async Task<IHttpActionResult> GetSkill(int id)
        {
            try
            {
                long Id = Convert.ToInt64(id);
                return Ok(await IndustryService.GetIndustrySkill(Id));
            }
            catch (Exception)
            {
                throw;
            }
        }

        [Route("getAllSkills")]
        [HttpPost]
        [ResponseType(typeof(IndustrySkillsCreateModel))]
        public async Task<IHttpActionResult> GetAllSkills(int industryId)
        {
            try
            {
                long Id = Convert.ToInt64(industryId);
                return Ok((await IndustryService.GetAllIndustrySkills(Id)).AsQueryable());
            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion

        #region Insert

        [Route("insertIndustry")]
        [HttpPost]
        [ResponseType(typeof(IndustryCreateModel))]
        public async Task<IHttpActionResult> InsertIndustry(IndustryCreateModel model)
        {
            try
            {
                userId = User.Identity.GetUserId();
                Helpers.Helpers.AddBaseProperties(model, "create", userId);

                return Ok(await IndustryService.CreateIndustry(model));
            }
            catch (Exception)
            {
                throw;
            }
        }

        [Route("insertIndustrySkill")]
        [HttpPost]
        [ResponseType(typeof(IndustrySkillsCreateModel))]
        public async Task<IHttpActionResult> InsertIndustrySkill(IndustrySkillsCreateModel model)
        {
            try
            {
                userId = User.Identity.GetUserId();
                Helpers.Helpers.AddBaseProperties(model, "create", userId); 

                return Ok(await IndustryService.CreateIndustrySkill(model));
            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion

        #region update

        [Route("updateIndustry")]
        [HttpPost]
        [ResponseType(typeof(IndustryCreateModel))]
        public async Task<IHttpActionResult> UpdateIndustry(IndustryCreateModel model)
        {
            try
            {
                userId = User.Identity.GetUserId();
                Helpers.Helpers.AddBaseProperties(model, "update", userId);

                return Ok(await IndustryService.UpdateIndustry(model));
            }
            catch (Exception)
            {
                throw;
            }
        }

        [Route("updateIndustrySkill")]
        [HttpPost]
        [ResponseType(typeof(IndustrySkillsCreateModel))]
        public async Task<IHttpActionResult> UpdateIndustrySkill(IndustrySkillsCreateModel model)
        {
            try
            {
                userId = User.Identity.GetUserId();
                Helpers.Helpers.AddBaseProperties(model, "update", userId);

                return Ok(await IndustryService.UpdateIndustrySkill(model));
            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion
    }
}
