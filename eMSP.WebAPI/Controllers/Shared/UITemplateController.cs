using eMSP.Data.DataServices.Roles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using eMSP.WebAPI.Controllers.Helpers;

namespace eMSP.WebAPI.Controllers.Shared
{
    [RoutePrefix("api/PageSettings")]
    [Authorize()]
    public class UITemplateController : ApiController
    {
        #region Intialisation

        private RoleManager rm;
       
        public UITemplateController()
        {
            rm = new RoleManager();
        }

        public async Task<UITemplate>  getTemplate(string UserID)
        {

            var OBJ = await  rm.GetUserRoles(UserID);
             
            return new UITemplate(OBJ.Select(x=>x.Name).ToList());
        }
        [Route("GetPageSettings")]
        [HttpPost]       
        public async Task<IHttpActionResult> GetUserRoles()
        {
            string UserID = User.Identity.GetUserId();          

            return Ok(await Task.Run(() => this.getTemplate(UserID)));
        }

        #endregion
    }
}
