using eMSP.Data.DataServices.Appointment;
using eMSP.ViewModel;
using eMSP.ViewModel.Appointment;
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

namespace eMSP.WebAPI.Controllers
{
    [RoutePrefix("api/Appointment")]
    //[Authorize(Roles = ApplicationRoles.SupplierCandidateFull)]
    [AllowAnonymous]
    public class AppointmentController : ApiController
    {

        #region Intialisation

        private AppointmentManager _service;

        public AppointmentController()
        {
            _service = new AppointmentManager();
        }

        #endregion


        #region Appointment Type

        [Route("type/getlist")]
        [HttpPost]
        [ResponseType(typeof(List<AppointmentTypeViewModel>))]
        public async Task<IHttpActionResult> GetTypeList()
        {
            try
            {
                return Ok((await _service.GetAppointmentTypeList()));
            }
            catch (Exception)
            {
                throw;
            }
        }

        [Route("type/get")]
        [HttpPost]
        [ResponseType(typeof(AppointmentTypeViewModel))]
        public async Task<IHttpActionResult> GetType(long id)
        {
            try
            {
                return Ok((await _service.GetAppointmentType(id)));
            }
            catch (Exception)
            {
                throw;
            }
        }

        [Route("type/save")]
        [HttpPost]
        [ResponseType(typeof(AppointmentTypeViewModel))]
        public async Task<IHttpActionResult> SaveType(AppointmentTypeViewModel data)
        {
            try
            {
                string userId = User.Identity.GetUserId();
                Helpers.Helpers.AddBaseProperties(data, "create", userId);
                return Ok((await _service.SaveType(data)));
            }
            catch (Exception)
            {
                throw;
            }
        }

        [Route("type/update")]
        [HttpPost]
        [ResponseType(typeof(AppointmentTypeViewModel))]
        public async Task<IHttpActionResult> UpdateType(AppointmentTypeViewModel data)
        {
            try
            {
                string userId = User.Identity.GetUserId();                
                Helpers.Helpers.AddBaseProperties(data, "update", userId);
                return Ok((await _service.UpdateType(data)));
            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion

        #region Appointment Status

        [Route("status/getlist")]
        [HttpPost]
        [ResponseType(typeof(List<AppointmentStatusViewModel>))]
        public async Task<IHttpActionResult> GetStatusList()
        {
            try
            {
                return Ok((await _service.GetAppointmentStatusList()));
            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion

    }
}
