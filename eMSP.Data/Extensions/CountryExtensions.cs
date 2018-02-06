using eMSP.DataModel;
using eMSP.ViewModel.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eMSP.Data.Extensions
{
    public static class CountryExtensions
    {
        public static tblCountry ConvertTotblCountry(this CountryCreateModel data)
        {
            return new tblCountry()
            {
                ID = Convert.ToInt64(data.id),
                Code = data.countryCode,
                Name = data.countryName,
                IsActive = data.isActive,
                IsDeleted = data.isDeleted ?? false,
                CreatedUserID = data.createdUserID,
                UpdatedUserID = data.updatedUserID,
                CreatedTimestamp = data.createdTimestamp ?? DateTime.Now,
                UpdatedTimestamp = data.updatedTimestamp ?? DateTime.Now
            };
        }

        public static CountryCreateModel ConvertToCountry(this tblCountry data)
        {
            return new CountryCreateModel()
            {
                id = data.ID,
                countryCode = data.Code,
                countryName = data.Name,
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
