using eMSP.Data.DataServices.Company;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using eMSP.ViewModel.MSP;

namespace eMSP.WebAPI.Controllers.Company
{


    [RoutePrefix("api/company")]
    public class CompanyController : ApiController
    {

        #region Intialisation

        private CompanyManager CompanyService;

        public CompanyController()
        {
            CompanyService = new CompanyManager();
        }

        #endregion

        #region Get

        [Route("getCompany")]
        [HttpPost]
        [ResponseType(typeof(CompanyCreateModel))]
        public async Task<IHttpActionResult> GetCompany(CompanyModel data)
        {
            try
            {
                return Ok(await CompanyService.GetCompany(data));
            }
            catch (Exception)
            {

                throw;
            }
        }

        [Route("getAllCompanies")]
        [HttpPost]
        [ResponseType(typeof(CompanyCreateModel))]
        public async Task<IHttpActionResult> GetCompanies(CompanySearchModel data)
        {
            try
            {
                return Ok(await CompanyService.GetAllCompanies(data));
            }
            catch (Exception)
            {

                throw;
            }
        }


        #endregion

        #region Insert

        [Route("creatCompany")]
        [HttpPost]
        [ResponseType(typeof(CompanyCreateModel))]
        public async Task<IHttpActionResult> CreateCompany(CompanyCreateModel data)
        {
            try
            {
                return Ok(await CompanyService.CreateCompany(data));
            }
            catch (Exception)
            {

                throw;
            }
        }

        #endregion

        #region Update

        [Route("updateCompany")]
        [HttpPost]
        [ResponseType(typeof(CompanyCreateModel))]
        public async Task<IHttpActionResult> UpdateCompany(CompanyCreateModel data)
        {
            try
            {
                return Ok(await CompanyService.UpdateCompany(data));
            }
            catch (Exception)
            {

                throw;
            }
        }

        #endregion

        #region Delete

        [Route("deleteCompany")]
        [HttpPost]
        [ResponseType(typeof(string))]
        public async Task<IHttpActionResult> DeleteCompany(CompanyModel data)
        {
            try
            {
                await CompanyService.DeleteCompany(data);
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
