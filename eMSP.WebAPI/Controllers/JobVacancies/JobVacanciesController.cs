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
using eMSP.ViewModel.MSP;

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
        public async Task<IHttpActionResult> GetVacancy(long id)
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

        [Route("getAllVacancy")]
        [HttpPost]
        [ResponseType(typeof(VacancyCreateModel))]
        public async Task<IHttpActionResult> GetAllVacancy(CompanyModel model)
        {
            try
            {
                return Ok(await VacanciesService.GetAllVacancies(model));
            }
            catch (Exception)
            {
                throw;
            }
        }

        //[Route("getVacancySkills")]
        //[HttpPost]
        //[ResponseType(typeof(VacancySkillsCreateModel))]
        //public async Task<IHttpActionResult> GetVacancySkills(int id)
        //{
        //    try
        //    {
        //        long Id = Convert.ToInt64(id);
        //        return Ok(await VacanciesService.GetVacancySkills(Id));
        //    }
        //    catch (Exception)
        //    {
        //        throw;
        //    }
        //}

        //[Route("getVacancyLocations")]
        //[HttpPost]
        //[ResponseType(typeof(VacancyLocationsCreateModel))]
        //public async Task<IHttpActionResult> GetVacancyLocations(int id)
        //{
        //    try
        //    {
        //        long Id = Convert.ToInt64(id);
        //        return Ok(await VacanciesService.GetVacancyLocations(Id));
        //    }
        //    catch (Exception)
        //    {
        //        throw;
        //    }
        //}

        //[Route("getVacancySupplier")]
        //[HttpPost]
        //[ResponseType(typeof(VacancySuppliersCreateModel))]
        //public async Task<IHttpActionResult> GetVacancySupplier(int id)
        //{
        //    try
        //    {
        //        long Id = Convert.ToInt64(id);
        //        return Ok(await VacanciesService.GetVacancySupplier(Id));
        //    }
        //    catch (Exception)
        //    {
        //        throw;
        //    }
        //}

        [Route("getMSPVacancyType")]
        [HttpPost]
        public async Task<IHttpActionResult> GetMSPVacancyType(MSPVacancieType data)
        {
            try
            {
                return Ok(await VacanciesService.GetMSPVacancieType(data, false));
            }
            catch (Exception)
            {
                throw;
            }
        }

        [Route("getActiveMSPVacancyType")]
        [HttpPost]
        public async Task<IHttpActionResult> GetActiveMSPVacancyType(MSPVacancieType data)
        {
            try
            {
                return Ok(await VacanciesService.GetMSPVacancieType(data, true));
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
        public async Task<IHttpActionResult> InsertVacancy(VacancyCreateModel model)
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

        

        

        [Route("createMSPVacancieType")]
        [HttpPost]
        [ResponseType(typeof(MSPVacancieTypeCreateModel))]
        public async Task<IHttpActionResult> InsertMSPVacancieType(MSPVacancieTypeCreateModel model)
        {
            try
            {
                return Ok(await VacanciesService.CreateMSPVacancieType(model));
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

        //[Route("updateVacancySkill")]
        //[HttpPost]
        //[ResponseType(typeof(VacancySkillsCreateModel))]
        //public async Task<IHttpActionResult> UpdateVacancySkill(VacancySkillsCreateModel model)
        //{
        //    try
        //    {
        //        return Ok(await VacanciesService.UpdateVacancySkill(model));
        //    }
        //    catch (Exception)
        //    {
        //        throw;
        //    }
        //}

        //[Route("updateVacancyLocation")]
        //[HttpPost]
        //[ResponseType(typeof(VacancyLocationsCreateModel))]
        //public async Task<IHttpActionResult> UpdateVacancyLocation(VacancyLocationsCreateModel model)
        //{
        //    try
        //    {
        //        return Ok(await VacanciesService.UpdateVacancyLocation(model));
        //    }
        //    catch (Exception)
        //    {
        //        throw;
        //    }
        //}

        //[Route("updateVacancySupplier")]
        //[HttpPost]
        //[ResponseType(typeof(VacancySuppliersCreateModel))]
        //public async Task<IHttpActionResult> UpdateVacancySupplier(VacancySuppliersCreateModel model)
        //{
        //    try
        //    {
        //        return Ok(await VacanciesService.UpdateVacancySupplier(model));
        //    }
        //    catch (Exception)
        //    {
        //        throw;
        //    }
        //}

        [Route("updateMSPVacancieType")]
        [HttpPost]
        [ResponseType(typeof(MSPVacancieTypeCreateModel))]
        public async Task<IHttpActionResult> UpdateMSPVacancieType(MSPVacancieTypeCreateModel model)
        {
            try
            {
                return Ok(await VacanciesService.UpdateMSPVacancieType(model));
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

        [Route("deleteMSPVacancieType")]
        [HttpPost]
        [ResponseType(typeof(VacancyCreateModel))]
        public async Task<IHttpActionResult> DeleteMSPVacancieType(MSPVacancieTypeCreateModel data)
        {
            try
            {
                await VacanciesService.DeleteMSPVacancieType(data.id);
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
