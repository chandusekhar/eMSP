﻿using eMSP.Data.Extensions;
using eMSP.DataModel;
using eMSP.ViewModel;
using eMSP.ViewModel.MSP;
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
            catch (Exception)
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


        #endregion

        #region Insert

        public async Task<UserCreateModel> CreateUser(UserCreateModel model)
        {
            try
            {
                tblUserProfile data = await Task.Run(() => UserOperations.InsertUser(model.ConvertTotblUser(), model.companyType, model.companyId));
                return data.ConvertToUser();

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