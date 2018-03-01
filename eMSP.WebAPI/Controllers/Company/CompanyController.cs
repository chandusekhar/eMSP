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
using eMSP.WebAPI.Controllers.Helpers;
using Microsoft.AspNet.Identity;
using eMSP.WebAPI.Controllers.Helpers;

namespace eMSP.WebAPI.Controllers.Company
{


    [RoutePrefix("api/company")]
    [AllowAnonymous]
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
        [Authorize(Roles = ApplicationRoles.SupplierFull+","+ ApplicationRoles.CustomerFull + "," + ApplicationRoles.MSPFull + "," + ApplicationRoles.SupplierView + "," + ApplicationRoles.CustomerView + "," + ApplicationRoles.MSPView)]
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
        [Authorize(Roles = ApplicationRoles.SupplierFull + "," + ApplicationRoles.CustomerFull + "," + ApplicationRoles.MSPFull + "," + ApplicationRoles.SupplierView + "," + ApplicationRoles.CustomerView + "," + ApplicationRoles.MSPView)]
        [ResponseType(typeof(List<CompanyCreateModel>))]
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
        [Authorize(Roles = ApplicationRoles.SupplierFull + "," + ApplicationRoles.CustomerFull + "," + ApplicationRoles.MSPFull + "," + ApplicationRoles.SupplierCreate + "," + ApplicationRoles.CustomerCreate + "," + ApplicationRoles.MSPCreate)]
        [ResponseType(typeof(CompanyCreateModel))]
        public async Task<IHttpActionResult> CreateCompany(CompanyCreateModel data)
        {
            try
            {
                string userId = User.Identity.GetUserId();

                Helpers.Helpers.AddBaseProperties(data, "create", userId);

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
        [Authorize(Roles = ApplicationRoles.SupplierFull + "," + ApplicationRoles.CustomerFull + "," + ApplicationRoles.MSPFull + "," + ApplicationRoles.SupplierCreate + "," + ApplicationRoles.CustomerCreate + "," + ApplicationRoles.MSPCreate)]
        [ResponseType(typeof(CompanyCreateModel))]
        public async Task<IHttpActionResult> UpdateCompany(CompanyCreateModel data)
        {
            try
            {
                string userId = User.Identity.GetUserId();

                Helpers.Helpers.AddBaseProperties(data, "update", userId);

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
        [Authorize(Roles = ApplicationRoles.SupplierFull + "," + ApplicationRoles.CustomerFull + "," + ApplicationRoles.MSPFull + "," + ApplicationRoles.SupplierCreate + "," + ApplicationRoles.CustomerCreate + "," + ApplicationRoles.MSPCreate)]
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
