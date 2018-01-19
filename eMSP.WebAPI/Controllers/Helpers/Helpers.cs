using eMSP.ViewModel.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace eMSP.WebAPI.Controllers.Helpers
{
    public static class Helpers
    {
        public static void AddBaseProperties<T>(T value, string action, string userId) where T : BaseModel
        {
            if (action == "create")
            {
                value.createdUserID = userId;
                value.updatedUserID = userId;
                value.isActive = true;
                value.isDeleted = false;
                value.createdTimestamp = DateTime.Now;
                value.updatedTimestamp = DateTime.Now;
            }
            else
            {
                value.updatedUserID = userId;
                value.updatedTimestamp = DateTime.Now;
            }


           // return value;
        }

    }
}