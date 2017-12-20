using eMSP.Data.DataServices.Company;
using eMSP.ViewModel.LocationBranch;
using eMSP.Data.Extensions;
using eMSP.DataModel;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eMSP.Data.DataServices.LocationBranch
{
    public class LocationBranchManager : IDisposable
    {
        #region Initialization

        private bool IsDisposed = false;

        public LocationBranchManager()
        {

        }

        #endregion

        #region Get

        public async Task<List<LocationCreateModel>> GetLocations(LocationCreateModel data)
        {
            try
            {
                List<LocationCreateModel> res = null;
                List<tblLocation> resData = null;
                long Id = data != null ? Convert.ToInt64(data.companyId) : 0;

                switch (data.companyType)
                {
                    case "MSP":
                        long id = Convert.ToInt64(ConfigurationManager.AppSettings["MSP_ID"]);
                        Id = id != null ? id : Id;
                        resData = await Task.Run(() => ManageMSP.GetMSPLocation(Id));
                        break;
                    case "Customer":
                        resData = await Task.Run(() => ManageCustomer.GetCustomerLocation(Id));
                        break;
                    case "Supplier":
                        resData = await Task.Run(() => ManageSupplier.GetSupplierLocation(Id));
                        break;
                }
                res = resData.Select(a => a.ConvertToLocation()).ToList();

                return res;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<List<LocationCreateModel>> GetCustomerLocationBranches(LocationCreateModel data)
        {
            try
            {
                List<LocationCreateModel> res = null;
                List<tblCustomerLocationBranch> resData = null;
                long Id = data != null ? Convert.ToInt64(data.companyId) : 0;

                switch (data.companyType)
                {                    
                    case "Customer":
                        resData = await Task.Run(() => ManageCustomer.GetCustomerLocationBranches(Id));
                        break;
                    
                }
                res = resData.Select(a => a.ConvertToCustomerLocationBranch()).ToList();

                return res;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<List<BranchCreateModel>> GetBranchs(LocationBranchModel data)
        {
            try
            {
                List<BranchCreateModel> model = null;
                List<tblBranch> resModel = null;
                long Id = data != null ? Convert.ToInt64(data.companyId) : 0;

                switch (data.companyType)
                {
                    case "MSP":
                        long id = Convert.ToInt64(ConfigurationManager.AppSettings["MSP_ID"]);
                        Id = id != null ? id : Id;
                        resModel = await Task.Run(() => ManageMSP.GetMSPBranches(Id, data.locationId));
                        break;
                    case "Customer":
                        resModel = await Task.Run(() => ManageCustomer.GetCustomerBranches(Id, data.locationId));
                        break;
                    case "Supplier":
                        resModel = await Task.Run(() => ManageSupplier.GetSupplierBranches(Id, data.locationId));
                        break;
                }
                model = resModel.Select(a => a.ConvertToBranch()).ToList();

                return model;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<List<BranchCreateModel>> GetAllBranchs(LocationBranchModel data)
        {
            try
            {
                List<BranchCreateModel> model = null;
                List<tblBranch> resModel = null;
                long Id = data != null ? Convert.ToInt64(data.companyId) : 0;

                switch (data.companyType)
                {
                    case "MSP":
                        long id = Convert.ToInt64(ConfigurationManager.AppSettings["MSP_ID"]);
                        Id = id != null ? id : Id;
                        resModel = await Task.Run(() => ManageMSP.GetMSPAllBranches(Id));
                        break;
                    case "Customer":
                        resModel = await Task.Run(() => ManageCustomer.GetCustomerAllBranches(Id));
                        break;
                    case "Supplier":
                        resModel = await Task.Run(() => ManageSupplier.GetSupplierAllBranches(Id));
                        break;
                }
                model = resModel.Select(a => a.ConvertToBranch()).ToList();

                return model;
            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion

        #region Insert

        public async Task<LocationCreateModel> CreateLocation(LocationCreateModel data)
        {
            try
            {
                LocationCreateModel model = null;
                tblLocation dataLocation = await Task.Run(() => ManageLocation.InsertLocation(data.ConvertTotblLocation()));
                model = dataLocation.ConvertToLocation();
                data.locationId = model.id;
                
                switch (data.companyType)
                {
                    case "MSP":                    
                        tblMSPLocationBranch dataMSP = await Task.Run(() => ManageMSP.InsertMSPLocationBranch(data.ConvertTotblMSPLocationBranch()));
                        break;
                    case "Customer":                        
                        tblCustomerLocationBranch dataCustomer = await Task.Run(() => ManageCustomer.InsertCustomerLocationBranch(data.ConvertTotblCustomerLocationBranch()));
                        break;
                    case "Supplier":                        
                        tblSupplierLocationBranch dataSupplier = await Task.Run(() => ManageSupplier.InsertSupplierLocationBranch(data.ConvertTotblSupplierLocationBranch()));
                        break;
                }

                return model;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<BranchCreateModel> CreateBranch(BranchCreateModel data)
        {
            try
            {
                BranchCreateModel model = null;
                tblBranch dataBranch = await Task.Run(() => ManageBranch.InsertBranch(data.ConvertTotblBranch()));
                model = dataBranch.ConvertToBranch();
                data.branchId = model.id;

                switch (data.companyType)
                {
                    case "MSP":
                        tblMSPLocationBranch dataMSP = await Task.Run(() => ManageMSP.InsertMSPLocationBranch(data.ConvertTotblMSPLocationBranch()));
                        break;
                    case "Customer":
                        tblCustomerLocationBranch dataCustomer = await Task.Run(() => ManageCustomer.InsertCustomerLocationBranch(data.ConvertTotblCustomerLocationBranch()));
                        break;
                    case "Supplier":
                        tblSupplierLocationBranch dataSupplier = await Task.Run(() => ManageSupplier.InsertSupplierLocationBranch(data.ConvertTotblSupplierLocationBranch()));
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

        public async Task<LocationCreateModel> UpdateLocation(LocationCreateModel model)
        {
            try
            {
                tblLocation data = await Task.Run(() => ManageLocation.UpdateLocation(model.ConvertTotblLocation()));
                return data.ConvertToLocation();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<BranchCreateModel> UpdateBranch(BranchCreateModel model)
        {
            try
            {
                tblBranch data = await Task.Run(() => ManageBranch.UpdateBranch(model.ConvertTotblBranch()));
                return data.ConvertToBranch();
            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion

        #region Delete

        public async Task DeleteLocation(LocationCreateModel data)
        {
            try
            {               

                switch (data.companyType)
                {
                    case "MSP":
                        await Task.Run(() => ManageMSP.DeleteMSPLocationBranch(data.id, "Location"));
                        break;
                    case "Customer":
                        await Task.Run(() => ManageCustomer.DeleteCustomerLocationBranch(data.id, "Location"));
                        break;
                    case "Supplier":
                        await Task.Run(() => ManageSupplier.DeleteSupplierBranchLocation(data.id, "Location"));
                        break;
                }

                await Task.Run(() => ManageLocation.DeleteLocation(data.id));

            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task DeleteBranch(BranchCreateModel data)
        {
            try
            {

                switch (data.companyType)
                {
                    case "MSP":
                        await Task.Run(() => ManageMSP.DeleteMSPLocationBranch(data.id, "Branch"));
                        break;
                    case "Customer":
                        await Task.Run(() => ManageCustomer.DeleteCustomerLocationBranch(data.id, "Branch"));
                        break;
                    case "Supplier":
                        await Task.Run(() => ManageSupplier.DeleteSupplierBranchLocation(data.id, "Branch"));
                        break;
                }

                await Task.Run(() => ManageBranch.DeleteBranch(data.id));

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

        ~LocationBranchManager()
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
