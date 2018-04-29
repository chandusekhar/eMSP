using eMSP.Data.DataServices.Shared;
using eMSP.ViewModel.Shared;
using eMSP.WebAPI.Controllers.Helpers;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;

namespace eMSP.WebAPI.Controllers.Shared
{
    [RoutePrefix("api/Industry")]
    [Queryable]
    [AllowAnonymous]
    [Authorize(Roles = ApplicationRoles.IndustryFull)]
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
        [Authorize(Roles = ApplicationRoles.CountryView)]
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
        [Authorize(Roles = ApplicationRoles.CountryView)]
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
        [Authorize(Roles = ApplicationRoles.CountryView)]
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
        [Authorize(Roles = ApplicationRoles.CountryView)]
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

        [Route("getAllSkills")]
        [HttpPost]
        [Authorize(Roles = ApplicationRoles.CountryView)]
        [ResponseType(typeof(IndustrySkillsCreateModel))]
        public async Task<IHttpActionResult> GetAllSkills(Industries model)
        {
            try
            {
                long[] a = model.industryIds.Select(b => Convert.ToInt64(b)).ToArray();

                return Ok((await IndustryService.GetAllIndustrySkills(a)).AsQueryable());
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
        [Authorize(Roles = ApplicationRoles.CountryCreate)]
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
        [Authorize(Roles = ApplicationRoles.CountryCreate)]
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
        [Authorize(Roles = ApplicationRoles.CountryCreate)]
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
        [Authorize(Roles = ApplicationRoles.CountryCreate)]
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

    public class Industries
    {
        public List<string> industryIds;
    }
}
