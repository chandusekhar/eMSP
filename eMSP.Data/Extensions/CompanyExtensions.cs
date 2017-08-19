using eMSP.DataModel;
using eMSP.ViewModel.MSP;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eMSP.Data.Extensions
{
    public static class CompanyExtensions
    {
        public static tblMSPDetail ConvertTotblMSPDetail(this CompanyCreateModel data)
        {
            return new tblMSPDetail()
            {
                ID = Convert.ToInt64(data.id),
                CompanyName = data.companyName,
                EmailAddress = data.companyEmail,
                PhoneNumber = data.companyPhoneNumber,
                Address = data.companyAddress,
                City = data.companyCity,
                WebSite = data.companyWebsite,
                CountryID = data.CountryID,
                StateID = data.StateID,
                CreatedUserID = "",
                UpdatedUserID = "",
                CreatedTimestamp = DateTime.Now,
                UpdatedTimestamp = DateTime.Now,

            };


        }
        public static CompanyCreateModel ConvertTocompany(this tblMSPDetail data)
        {
            return new CompanyCreateModel()
            {
                id = Convert.ToString(data.ID),
                companyName = data.CompanyName ?? "",
                companyEmail = data.EmailAddress ?? "",
                companyPhoneNumber = data.PhoneNumber ?? "",
                companyAddress = data.Address ?? "",
                companyCity = data.City ?? "",
                companyWebsite = data.WebSite ?? "",
                CountryID = data.CountryID ?? 0,
                companyCountry ="", //data.tblCountry.Name ?? "",
                StateID = data.StateID ?? 0,
                companyState = "",//data.tblCountryState.Name ?? "",
                companyType = "MSP",
                createdUserID = data.CreatedUserID ?? "",
                updatedUserID = data.UpdatedUserID ?? "",
                createdTimestamp = data.CreatedTimestamp,
                updatedTimestamp = data.UpdatedTimestamp
            };

        }
        public static tblCustomer ConvertTotblCustomer(this CompanyCreateModel data)
        {
            return new tblCustomer()
            {
                ID = Convert.ToInt64(data.id),
                Name = data.companyName,
                EmailAddress = data.companyEmail,
                PhoneNumber = data.companyPhoneNumber,
                Address = data.companyAddress,
                City = data.companyCity,
                WebSite = data.companyWebsite,
                CountryID = data.CountryID,
                StateID = data.StateID,
                CreatedUserID = "",
                UpdatedUserID = "",
                CreatedTimestamp = DateTime.Now,
                UpdatedTimestamp = DateTime.Now,

            };


        }
        public static CompanyCreateModel ConvertTocompany(this tblCustomer data)
        {
            return new CompanyCreateModel()
            {
                id = Convert.ToString(data.ID),
                companyName = data.Name,
                companyEmail = data.EmailAddress,
                companyPhoneNumber = data.PhoneNumber,
                companyAddress = data.Address,
                companyCity = data.City,
                companyWebsite = data.WebSite,
                CountryID = data.CountryID,
                companyCountry = data.tblCountry.Name,
                StateID = data.StateID,
                companyState = data.tblCountryState.Name,
                companyType = "Customer",
                createdUserID = data.CreatedUserID,
                updatedUserID = data.UpdatedUserID,
                createdTimestamp = data.CreatedTimestamp,
                updatedTimestamp = data.UpdatedTimestamp
            };

        }
        public static tblSupplier ConvertTotblSupplier(this CompanyCreateModel data)
        {
            return new tblSupplier()
            {
                ID = Convert.ToInt64(data.id),
                Name = data.companyName,
                EmailAddress = data.companyEmail,
                PhoneNumber = data.companyPhoneNumber,
                Address = data.companyAddress,
                City = data.companyCity,
                WebSite = data.companyWebsite,
                CountryID = data.CountryID,
                StateID = data.StateID,
                CreatedUserID = "",
                UpdatedUserID = "",
                CreatedTimestamp = DateTime.Now,
                UpdatedTimestamp = DateTime.Now,

            };


        }
        public static CompanyCreateModel ConvertTocompany(this tblSupplier data)
        {
            return new CompanyCreateModel()
            {
                id = Convert.ToString(data.ID),
                companyName = data.Name,
                companyEmail = data.EmailAddress,
                companyPhoneNumber = data.PhoneNumber,
                companyAddress = data.Address,
                companyCity = data.City,
                companyWebsite = data.WebSite,
                CountryID = data.CountryID,
                companyCountry = data.tblCountry.Name,
                StateID = data.StateID,
                companyState = data.tblCountryState.Name,
                companyType = "Supplier",
                createdUserID = data.CreatedUserID,
                updatedUserID = data.UpdatedUserID,
                createdTimestamp = data.CreatedTimestamp,
                updatedTimestamp = data.UpdatedTimestamp
            };

        }


    }
}
