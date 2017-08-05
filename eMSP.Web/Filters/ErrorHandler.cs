using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Filters;
using System.Web.Mvc;
using NLog;

namespace eMSP.Web.Filters
{
    public class ErrorHandler : ExceptionFilterAttribute
    {        
        public override void OnException(HttpActionExecutedContext actionExecutedContext)
        {
            Controller controler = actionExecutedContext.ActionContext.ControllerContext.Controller as Controller;

            if (controler == null)
            {
                return;
            }
                      

            base.OnException(actionExecutedContext);
        }
    }
}