using eMSP.DataModel;
using eMSP.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eMSP.Data.Extensions
{
    public static class UserExtensions
    {
        public static tblUserProfile ConvertTotblUser(this UserCreateModel data)
        {
            return new tblUserProfile()
            {
                UserID = data.userId,
                FirstName = data.firstName,
                LastName = data.lastName,
                Address = data.address,
                EmailAddress = data.emailAddress,
                City = data.city,
                CountryID = data.countryId,
                StateID = data.stateId,
                TimezoneID = data.timeZoneId,
                RoleGroupId = data.roleGroupId == null ? "5D99B481-600F-4015-A169-4D5E8D64633F" : data.roleGroupId,
                UserProfilePhotoPath = data.userProfilePhotoPath == null ? "" : data.userProfilePhotoPath,
                ZipCode = data.zipCode,
                CreatedUserID = data.createdUserID,
                CreatedTimestamp = data.createdTimestamp ?? DateTime.Now,
                UpdatedUserID = data.updateUserId,
                UpdatedTimestamp = data.updatedTimestamp ?? DateTime.Now
            };
        }

        public static UserCreateModel ConvertToUser(this tblUserProfile data)
        {
            return new UserCreateModel()
            {
                userId = data.UserID,
                firstName = data.FirstName,
                lastName = data.LastName,
                address = data.Address,
                emailAddress = data.EmailAddress,
                roleGroupId = data.RoleGroupId,
                timeZoneId = data.TimezoneID,
                city = data.City,
                countryId = data.CountryID,
                country = data.tblCountry != null ? data.tblCountry.Name : "",
                state = data.tblCountryState != null ? data.tblCountryState.Name : "",
                stateId = data.StateID,
                userProfilePhotoPath = data.UserProfilePhotoPath,
                zipCode = data.ZipCode,
                createdUserID = data.CreatedUserID,
                updatedTimestamp = data.UpdatedTimestamp,
                createdTimestamp = data.CreatedTimestamp,
                updateUserId = data.UpdatedUserID
            };
        }

        public static tblMSPUser ConvertTotblMSPUser(this UserModel data)
        {
            return new tblMSPUser()
            {
                UserID = data.userId,
                MSPID = data.companyId,
                ID = data.companyUserId,
                CreatedUserID = data.createdUserID,
                CreatedTimestamp = data.createdTimestamp ?? DateTime.Now,
                UpdatedUserID = data.updateUserId,
                UpdatedTimestamp = data.updatedTimestamp ?? DateTime.Now,
                IsActive = data.isActive,
                IsDeleted = data.isDeleted ?? false
            };
        }

        public static tblCustomerUser ConvertTotblCustomerUser(this UserModel data)
        {
            return new tblCustomerUser()
            {
                UserID = data.userId,
                CustomerID = data.companyId,
                ID = data.companyUserId,
                CreatedUserID = data.createdUserID,
                CreatedTimestamp = data.createdTimestamp ?? DateTime.Now,
                UpdatedUserID = data.updateUserId,
                UpdatedTimestamp = data.updatedTimestamp ?? DateTime.Now,
                IsActive = data.isActive,
                IsDeleted = data.isDeleted ?? false
            };
        }

        public static tblSupplierUser ConvertTotblSuppierUser(this UserModel data)
        {
            return new tblSupplierUser()
            {
                UserID = data.userId,
                SupplierID = data.companyId,
                ID = data.companyUserId,
                CreatedUserID = data.createdUserID,
                CreatedTimestamp = data.createdTimestamp ?? DateTime.Now,
                UpdatedUserID = data.updateUserId,
                UpdatedTimestamp = data.updatedTimestamp ?? DateTime.Now,
                IsActive = data.isActive,
                IsDeleted = data.isDeleted ?? false
            };
        }

        public static UserModel ConvertToUserModel(this tblMSPUser data)
        {
            return new UserModel()
            {
                userId = data.UserID,
                companyId = data.MSPID,
                companyType = "MSP",
                companyUserId = data.ID,
                createdUserID = data.CreatedUserID,
                createdTimestamp = data.CreatedTimestamp,
                updateUserId = data.UpdatedUserID,
                updatedTimestamp = data.UpdatedTimestamp,
                isActive = data.IsActive,
                isDeleted = data.IsDeleted,
                user = data.tblUserProfile != null ? data.tblUserProfile.ConvertToUser() : null
            };
        }

        public static UserModel ConvertToUserModel(this tblCustomerUser data)
        {
            return new UserModel()
            {
                userId = data.UserID,
                companyId = data.CustomerID,
                companyType = "Customer",
                companyUserId = data.ID,
                createdUserID = data.CreatedUserID,
                createdTimestamp = data.CreatedTimestamp,
                updateUserId = data.UpdatedUserID,
                updatedTimestamp = data.UpdatedTimestamp,
                isActive = data.IsActive,
                isDeleted = data.IsDeleted,
                user = data.tblUserProfile != null ? data.tblUserProfile.ConvertToUser() : null
            };
        }

        public static UserModel ConvertToUserModel(this tblSupplierUser data)
        {
            return new UserModel()
            {
                userId = data.UserID,
                companyId = data.SupplierID,
                companyType = "Supplier",
                companyUserId = data.ID,
                createdUserID = data.CreatedUserID,
                createdTimestamp = data.CreatedTimestamp,
                updateUserId = data.UpdatedUserID,
                updatedTimestamp = data.UpdatedTimestamp,
                isActive = data.IsActive,
                isDeleted = data.IsDeleted,
                user = data.tblUserProfile != null ? data.tblUserProfile.ConvertToUser() : null
            };
        }
    }
}
