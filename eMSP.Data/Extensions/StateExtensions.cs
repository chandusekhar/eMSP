using eMSP.DataModel;
using eMSP.ViewModel.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eMSP.Data.Extensions
{
    public static class StateExtensions
    {        

        public static tblCountryState ConvertTotblCountryState(this StateCreateModel data)
        {
            return new tblCountryState()
            {
                ID = Convert.ToInt64(data.id),
                CountryID=data.countryId,
                Code = data.stateCode,
                Name = data.stateName,
                IsActive=data.isActive,
                IsDeleted=data.isDeleted,
                CreatedUserID = "",
                UpdatedUserID = "",
                CreatedTimestamp = DateTime.Now,
                UpdatedTimestamp = DateTime.Now
            };
        }

        public static StateCreateModel ConvertToCountryState(this tblCountryState data)
        {
            return new StateCreateModel()
            {
                id = data.ID,
                countryId = data.CountryID,
                stateCode=data.Code,
                stateName = data.Name,
                isActive = data.IsActive,
                isDeleted = data.IsDeleted,
                createdUserID = data.CreatedUserID,
                updatedUserID = data.UpdatedUserID,
                createdTimestamp = data.CreatedTimestamp,
                updatedTimestamp = data.UpdatedTimestamp
            };
        }
    }
}
