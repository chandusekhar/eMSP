using eMSP.ViewModel.MSP;
using eMSP.Data.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using eMSP.DataModel;
using System.Configuration;

namespace eMSP.Data.DataServices.Company
{
    public class CompanyManager : IDisposable
    {

        #region Initialization

        private bool IsDisposed = false;

        public CompanyManager()
        {

        }

        #endregion

        #region Get

        public async Task<CompanyCreateModel> GetCompany(CompanyModel data)
        {
            try
            {
                CompanyCreateModel model = null;
                long Id = data != null ?Convert.ToInt64(data.id):0;
                
                switch (data.companyType)
                {
                    case "MSP":
                        long id = Convert.ToInt64(ConfigurationManager.AppSettings["MSP_ID"]);
                        Id = id != null ? id : Id;
                        tblMSPDetail dataMSP = await Task.Run(() => ManageMSP.GetMSPDetails(Id));
                        model = dataMSP.ConvertTocompany();
                        break;
                    case "Customer":
                        tblCustomer dataCustomer = await Task.Run(() => ManageCustomer.GetCustomerDetails(Id));
                        model = dataCustomer.ConvertTocompany();
                        break;
                    case "Supplier":
                        tblSupplier dataSupplier = await Task.Run(() => ManageSupplier.GetSupplierDetails(Id));
                        model = dataSupplier.ConvertTocompany();
                        break;
                }

                return model;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<List<CompanyCreateModel>> GetAllCompanies(CompanySearchModel Model)
        {
            try
            {
                List<CompanyCreateModel> res = null;

                switch (Model.companyType)
                {
                    case "MSP":
                        List<tblMSPDetail> dataMSP = await Task.Run(() => ManageMSP.GetAllMSPDetails(Model));
                        res = dataMSP.Select(a => a.ConvertTocompany()).ToList();
                        break;
                    case "Customer":
                        List<tblCustomer> dataCustomer = await Task.Run(() => ManageCustomer.GetAllCustomerDetails(Model));
                        res = dataCustomer.Select(a => a.ConvertTocompany()).ToList();
                        break;
                    case "Supplier":
                        List<tblSupplier> dataSupplier = await Task.Run(() => ManageSupplier.GetAllSupplierDetails(Model));
                        res = dataSupplier.Select(a => a.ConvertTocompany()).ToList();
                        break;
                }

                return res;
            }
            catch (Exception)
            {
                throw;
            }
        }


        #endregion

        #region Insert

        public async Task<CompanyCreateModel> CreateCompany(CompanyCreateModel data)
        {
            try
            {
                CompanyCreateModel model = null;

                switch (data.companyType)
                {
                    case "MSP":
                        tblMSPDetail dataMSP = await Task.Run(() => ManageMSP.InsertMSP(data.ConvertTotblMSPDetail()));
                        model = dataMSP.ConvertTocompany();
                        break;
                    case "Customer":
                        tblCustomer dataCustomer = await Task.Run(() => ManageCustomer.InsertCustomer(data.ConvertTotblCustomer()));
                        model = dataCustomer.ConvertTocompany();
                        break;
                    case "Supplier":
                        tblSupplier dataSupplier = await Task.Run(() => ManageSupplier.InsertSupplier(data.ConvertTotblSupplier()));
                        model = dataSupplier.ConvertTocompany();
                        break;
                }

                return model;
            }
            catch (Exception)
            {
                throw;
            }
        }


        #endregion

        #region Update

        public async Task<CompanyCreateModel> UpdateCompany(CompanyCreateModel data)
        {
            try
            {
                CompanyCreateModel model = null;

                switch (data.companyType)
                {
                    case "MSP":
                        tblMSPDetail dataMSP = await Task.Run(() => ManageMSP.UpdateMSP(data.ConvertTotblMSPDetail()));
                        model = dataMSP.ConvertTocompany();
                        break;
                    case "Customer":
                        tblCustomer dataCustomer = await Task.Run(() => ManageCustomer.UpdateCustomer(data.ConvertTotblCustomer()));
                        model = dataCustomer.ConvertTocompany();
                        break;
                    case "Supplier":
                        tblSupplier dataSupplier = await Task.Run(() => ManageSupplier.UpdateSupplier(data.ConvertTotblSupplier()));
                        model = dataSupplier.ConvertTocompany();
                        break;
                }

                return model;
            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion

        #region Delete

        public async Task DeleteCompany(CompanyModel data)
        {
            try
            {
                long Id = Convert.ToInt64(data.id);
                switch (data.companyType)
                {
                    case "MSP":
                        await Task.Run(() => ManageMSP.DeleteMSP(Id));
                        break;
                    case "Customer":
                        await Task.Run(() => ManageCustomer.DeleteCustomer(Id));
                        break;
                    case "Supplier":
                        await Task.Run(() => ManageSupplier.DeleteSupplier(Id));
                        break;
                }

            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion

        #region Dispose

        protected virtual void Dispose(bool dispose)
        {
            if (!IsDisposed)
            {
                if (dispose)
                {
                    this.Dispose();
                }
                IsDisposed = true;
            }

           
        }

        ~CompanyManager()
        {
            Dispose(false);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        #endregion

    }



}



