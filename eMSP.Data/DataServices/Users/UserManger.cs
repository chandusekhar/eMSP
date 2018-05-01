using eMSP.Data.Extensions;
using eMSP.DataModel;
using eMSP.ViewModel.MSP;
using eMSP.ViewModel.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eMSP.Data.DataServices.Users
{
    public class UserManger
    {
        #region Initialization

        private bool IsDisposed = false;

        public UserManger()
        {

        }

        #endregion

        #region Get

        public async Task<UserCreateModel> GetUser(string Id)
        {
            try
            {

                tblUserProfile data = await Task.Run(() => UserOperations.GetUser(Id));
                return data.ConvertToUser();

            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public async Task<List<UserModel>> GetAllCompanyUsers(CompanyModel model)
        {
            try
            {
                switch (model.companyType)
                {
                    case "MSP":

                        List<tblMSPUser> mdata = await Task.Run(() => UserOperations.GetAllMSPUsers(Convert.ToInt64(model.id)));
                        return mdata.Select(a => a.ConvertToUserModel()).ToList();

                    case "Customer":

                        List<tblCustomerUser> cdata = await Task.Run(() => UserOperations.GetAllCustomerUsers(Convert.ToInt64(model.id)));
                        return cdata.Select(a => a.ConvertToUserModel()).ToList();

                    case "Supplier":

                        List<tblSupplierUser> sdata = await Task.Run(() => UserOperations.GetAllSupplierUsers(Convert.ToInt64(model.id)));
                        return sdata.Select(a => a.ConvertToUserModel()).ToList();
                }


            }
            catch (Exception)
            {
                throw;
            }
            return null;
        }
        public async Task<List<UserCreateModel>> GetAllUsers(CompanyModel model)
        {
            try
            {


                List<tblUserProfile> data = await Task.Run(() => UserOperations.GetAllUsers(Convert.ToInt64(model.id), model.companyType));
                return data.Select(a => a.ConvertToUser()).ToList();

            }
            catch (Exception)
            {
                throw;
            }
        }
        public async Task<List<UserCreateModel>> GetAllUsers()
        {
            try
            {


                return await Task.Run(() => UserOperations.GetAllUsers());
                

            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion

        #region Insert

        public async Task<UserModel> CreateUser(UserCreateModel model)
        {
            try
            {

                tblUserProfile data = await Task.Run(() => UserOperations.InsertUser(model.ConvertTotblUser(), model.companyType, model.companyId));
                switch (model.companyType)
                {
                    case "MSP":
                    default:
                        List<tblMSPUser> liMSP = await Task.Run(() => UserOperations.GetAllMSPUsers(model.companyId));
                        return liMSP.SingleOrDefault(a => a.UserID == data.UserID).ConvertToUserModel();

                        break;
                    case "Customer":
                        List<tblCustomerUser> licust = await Task.Run(() => UserOperations.GetAllCustomerUsers(model.companyId));
                        return licust.SingleOrDefault(a => a.UserID == data.UserID).ConvertToUserModel();
                        break;
                    case "Supplier":
                        List<tblSupplierUser> lisup = await Task.Run(() => UserOperations.GetAllSupplierUsers(model.companyId));
                        return lisup.SingleOrDefault(a => a.UserID == data.UserID).ConvertToUserModel();
                        break;


                }



            }
            catch (Exception)
            {
                throw;
            }
        }


        #endregion

        #region Update

        public async Task<UserCreateModel> UpdateUser(UserCreateModel model)
        {
            try
            {

                tblUserProfile data = await Task.Run(() => UserOperations.UpdateUser(model.ConvertTotblUser()));
                return data.ConvertToUser();

            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<UserModel> UpdateUser(UserModel data)
        {
            try
            {
                switch (data.companyType)
                {
                    case "MSP":

                        tblMSPUser mdata = await Task.Run(() => UserOperations.ToggleUser(data.ConvertTotblMSPUser()));
                        return mdata.ConvertToUserModel();

                    case "Customer":

                        tblCustomerUser cdata = await Task.Run(() => UserOperations.ToggleUser(data.ConvertTotblCustomerUser()));
                        return cdata.ConvertToUserModel();

                    case "Supplier":

                        tblSupplierUser sdata = await Task.Run(() => UserOperations.ToggleUser(data.ConvertTotblSuppierUser()));
                        return sdata.ConvertToUserModel();
                }


            }
            catch (Exception)
            {
                throw;
            }

            return null;
        }

        #endregion

        #region Delete

        public async Task DeleteCountry(string Id)
        {
            try
            {
                await Task.Run(() => UserOperations.DeleteUser(Id));

            }
            catch (Exception)
            {
                throw;
            }
        }



        #endregion

        #region Dispose

        //protected virtual void Dispose(bool dispose)
        //{
        //    if (!IsDisposed)
        //    {
        //        this.Dispose();
        //    }

        //    IsDisposed = true;
        //}

        //~CountryManager()
        //{
        //    Dispose(false);
        //}

        //public void Dispose()
        //{
        //    Dispose(true);
        //    GC.SuppressFinalize(this);
        //}
        #endregion
    }
}
