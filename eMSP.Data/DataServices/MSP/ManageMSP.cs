using eMSP.DataModel;
using eMSP.ViewModel.MSP;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eMSP.Data.DataServices.MSP
{
   public class ManageMSP:IDisposable
    {

        private bool IsDisposed = false;
        internal eMSPEntities mContext;

        public ManageMSP()
        {
            mContext = new eMSPEntities();
        }

        public async Task<MSPDetailsUIModel> GetMspDetails(long MspId)
        {
            try
            {
                using (var db=mContext)
                {
                    var data = await Task.Run(()=> db.tblMSPDetails.Where(x => x.ID == MspId).SingleOrDefault());

                    return new MSPDetailsUIModel()
                    {
                        ID = Convert.ToString(data.ID),
                        CompanyName = data.CompanyName,
                        EmailAddress = data.EmailAddress,
                        PhoneNumber = data.PhoneNumber,
                        Address = data.Address,
                        City = data.City,
                        WebSite = data.WebSite,
                        CountryID = data.CountryID,
                        CountryName = data.tblCountry.Name,
                        StateID = data.StateID,
                        StateName = data.tblCountryState.Name,
                        CreatedTimestamp = data.CreatedTimestamp
                    };
                }
            }
            catch (Exception)
            {
                throw;
                throw;
            }
        }

        #region Dispose

        protected virtual void Dispose(bool dispose)
        {
            if (!IsDisposed)
            {
                mContext.Dispose();
            }

            IsDisposed = true;
        }

        ~ManageMSP()
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
