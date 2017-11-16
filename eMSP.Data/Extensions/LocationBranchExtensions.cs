using eMSP.DataModel;
using eMSP.ViewModel.LocationBranch;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eMSP.Data.Extensions
{
    public static class LocationBranchExtensions
    {
        public static tblLocation ConvertTotblLocation(this LocationCreateModel data)
        {
            return new tblLocation()
            {
                ID = Convert.ToInt64(data.id),
                LocationName = data.locationName,
                StreetLine1 = data.streetLine1,
                StreetLine2 = data.streetLine2,
                City = data.city,
                StateID = Convert.ToInt16(data.stateId),
                CountryID = Convert.ToInt16(data.countryId),
                IsActive = data.isActive,
                IsDeleted = data.isDeleted,
                CreatedUserID = data.createdUserID,
                UpdatedUserID = data.updatedUserID,
                CreatedTimestamp = DateTime.Now,
                UpdatedTimestamp = DateTime.Now
            };
        }


        public static LocationCreateModel ConvertToLocation(this tblLocation data)
        {
            return new LocationCreateModel()
            {
                id = data.ID,
                locationName = data.LocationName,
                streetLine1 = data.StreetLine1,
                streetLine2 = data.StreetLine2,
                city = data.City,
                stateId = data.StateID.ToString(),
                stateName = data.tblCountryState != null ? data.tblCountryState.Name : "",
                countryId = data.CountryID.ToString(),
                countryName = data.tblCountry != null ? data.tblCountry.Name : "",
                isActive = data.IsActive,
                isDeleted = data.IsDeleted,
                createdUserID = data.CreatedUserID,
                updatedUserID = data.UpdatedUserID,
                createdTimestamp = data.CreatedTimestamp,
                updatedTimestamp = data.UpdatedTimestamp
            };
        }

        public static tblBranch ConvertTotblBranch(this BranchCreateModel data)
        {
            return new tblBranch()
            {
                ID = Convert.ToInt64(data.id),
                BranchName = data.branchName,
                LocationID = data.locationId,
                EmailAddress = data.emailAddress,
                PhoneNumber = data.phoneNumber,
                StreetLine1 = data.streetLine1,
                StreetLine2 = data.streetLine2,
                City = data.city,
                StateID = Convert.ToInt16(data.stateId),
                CountryID = Convert.ToInt16(data.countryId),
                IsActive = data.isActive,
                IsDeleted = data.isDeleted,
                CreatedUserID = data.createdUserID,
                UpdatedUserID = data.updatedUserID,
                CreatedTimestamp = DateTime.Now,
                UpdatedTimestamp = DateTime.Now
            };
        }


        public static BranchCreateModel ConvertToBranch(this tblBranch data)
        {
            return new BranchCreateModel()
            {
                id = data.ID,
                branchName = data.BranchName,
                locationId = data.LocationID,
                locationName = data.tblLocation != null ? data.tblLocation.LocationName : "",
                emailAddress = data.EmailAddress,
                phoneNumber = data.PhoneNumber,
                streetLine1 = data.StreetLine1,
                streetLine2 = data.StreetLine2,
                city = data.City,
                stateId = data.StateID.ToString(),
                stateName = data.tblCountryState != null ? data.tblCountryState.Name : "",
                countryId = data.CountryID.ToString(),
                countryName = data.tblCountry != null ? data.tblCountry.Name : "",
                isActive = data.IsActive,
                isDeleted = data.IsDeleted,
                createdUserID = data.CreatedUserID,
                updatedUserID = data.UpdatedUserID,
                createdTimestamp = data.CreatedTimestamp,
                updatedTimestamp = data.UpdatedTimestamp
            };
        }

        public static tblMSPLocationBranch ConvertTotblMSPLocationBranch(this LocationCreateModel data)
        {
            return new tblMSPLocationBranch()
            {
                ID = Convert.ToInt64(data.id),
                MSPID = data.companyId,
                LocationID = data.locationId,
                BranchID = data.branchId,                
                IsActive = data.isActive,
                IsDeleted = data.isDeleted,
                CreatedUserID = data.createdUserID,
                UpdatedUserID = data.updatedUserID,
                CreatedTimestamp = DateTime.Now,
                UpdatedTimestamp = DateTime.Now
            };
        }

        public static tblMSPLocationBranch ConvertTotblMSPLocationBranch(this BranchCreateModel data)
        {
            return new tblMSPLocationBranch()
            {
                ID = Convert.ToInt64(data.id),
                MSPID = data.companyId,
                LocationID = data.locationId,
                BranchID = data.branchId,
                IsActive = data.isActive,
                IsDeleted = data.isDeleted,
                CreatedUserID = data.createdUserID,
                UpdatedUserID = data.updatedUserID,
                CreatedTimestamp = DateTime.Now,
                UpdatedTimestamp = DateTime.Now
            };
        }


        public static LocationCreateModel ConvertToMSPLocationBranch(this tblMSPLocationBranch data)
        {
            return new LocationCreateModel()
            {
                id=data.ID,
                companyId=data.MSPID,
                locationId=data.LocationID,
                branchId=data.BranchID,
                isActive = data.IsActive,
                isDeleted = data.IsDeleted,
                createdUserID = data.CreatedUserID,
                updatedUserID = data.UpdatedUserID,
                createdTimestamp = data.CreatedTimestamp,
                updatedTimestamp = data.UpdatedTimestamp
            };
        }

        public static tblCustomerLocationBranch ConvertTotblCustomerLocationBranch(this LocationCreateModel data)
        {
            return new tblCustomerLocationBranch()
            {
                ID = Convert.ToInt64(data.id),
                CustomerID  = data.companyId,
                LocationID = data.locationId,
                BranchID = data.branchId,
                IsActive = data.isActive,
                IsDeleted = data.isDeleted,
                CreatedUserID = data.createdUserID,
                UpdatedUserID = data.updatedUserID,
                CreatedTimestamp = DateTime.Now,
                UpdatedTimestamp = DateTime.Now
            };
        }

        public static tblCustomerLocationBranch ConvertTotblCustomerLocationBranch(this BranchCreateModel data)
        {
            return new tblCustomerLocationBranch()
            {
                ID = Convert.ToInt64(data.id),
                CustomerID = data.companyId,
                LocationID = data.locationId,
                BranchID = data.branchId,
                IsActive = data.isActive,
                IsDeleted = data.isDeleted,
                CreatedUserID = data.createdUserID,
                UpdatedUserID = data.updatedUserID,
                CreatedTimestamp = DateTime.Now,
                UpdatedTimestamp = DateTime.Now
            };
        }


        public static LocationCreateModel ConvertToCustomerLocationBranch(this tblCustomerLocationBranch data)
        {
            return new LocationCreateModel()
            {
                id = data.ID,
                companyId = data.CustomerID,
                locationId = data.LocationID,
                branchId = data.BranchID,
                isActive = data.IsActive,
                isDeleted = data.IsDeleted,
                createdUserID = data.CreatedUserID,
                updatedUserID = data.UpdatedUserID,
                createdTimestamp = data.CreatedTimestamp,
                updatedTimestamp = data.UpdatedTimestamp
            };
        }

        public static tblSupplierLocationBranch ConvertTotblSupplierLocationBranch(this LocationCreateModel data)
        {
            return new tblSupplierLocationBranch()
            {
                ID = Convert.ToInt64(data.id),
                SupplierID = data.companyId,
                LocationID = data.locationId,
                BranchID = data.branchId,
                IsActive = data.isActive,
                IsDeleted = data.isDeleted,
                CreatedUserID = data.createdUserID,
                UpdatedUserID = data.updatedUserID,
                CreatedTimestamp = DateTime.Now,
                UpdatedTimestamp = DateTime.Now
            };
        }

        public static tblSupplierLocationBranch ConvertTotblSupplierLocationBranch(this BranchCreateModel data)
        {
            return new tblSupplierLocationBranch()
            {
                ID = Convert.ToInt64(data.id),
                SupplierID = data.companyId,
                LocationID = data.locationId,
                BranchID = data.branchId,
                IsActive = data.isActive,
                IsDeleted = data.isDeleted,
                CreatedUserID = data.createdUserID,
                UpdatedUserID = data.updatedUserID,
                CreatedTimestamp = DateTime.Now,
                UpdatedTimestamp = DateTime.Now
            };
        }


        public static LocationCreateModel ConvertToSupplierLocationBranch(this tblSupplierLocationBranch data)
        {
            return new LocationCreateModel()
            {
                id = data.ID,
                companyId = data.SupplierID,
                locationId = data.LocationID,
                branchId = data.BranchID,
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

