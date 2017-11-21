using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using eMSP.Data.DataServices.JobVacancies;
using eMSP.ViewModel.JobVacancies;
using System.Web.Http.Description;
using System.Threading.Tasks;

namespace eMSP.WebAPI.Controllers.JobVacancies
{
    [RoutePrefix("api/JobVacancie")]
    public class JobVacanciesController : ApiController
    {
        #region Intialisation

        private VacanciesManager VacanciesService;


        public JobVacanciesController()
        {
            VacanciesService = new VacanciesManager();

        }

        #endregion

        #region Get

        [Route("getVacancy")]
        [HttpPost]
        [ResponseType(typeof(VacancyCreateModel))]
        public async Task<IHttpActionResult> GetVacancy(int id)
        {
            try
            {

                return Ok(await VacanciesService.GetVacancy(id));
            }
            catch (Exception)
            {
                throw;
            }
        }

        

        #endregion

        #region Insert

        [Route("createVacancy")]
        [HttpPost]
        [ResponseType(typeof(VacancyCreateModel))]
        public async Task<IHttpActionResult> InsertIndustry(VacancyCreateModel model)
        {
            try
            {
                return Ok(await VacanciesService.CreateVacancy(model));
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion

        #region update

        [Route("updateVacancy")]
        [HttpPost]
        [ResponseType(typeof(VacancyCreateModel))]
        public async Task<IHttpActionResult> UpdateVacancy(VacancyCreateModel model)
        {
            try
            {
                return Ok(await VacanciesService.UpdateVacancy(model));
            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion

        #region Delete

        [Route("deleteVacancy")]
        [HttpPost]
        [ResponseType(typeof(VacancyCreateModel))]
        public async Task<IHttpActionResult> DeleteVacancy(long model)
        {
            try
            {
                await VacanciesService.DeleteVacancy(model);
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
