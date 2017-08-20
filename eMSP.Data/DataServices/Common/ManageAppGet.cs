using eMSP.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eMSP.Data.DataServices.Common
{
    internal static class ManageAppGet     
    {
        #region Intialization

        internal static eMSPEntities db;

        static ManageAppGet()
        {
            
        }

        #endregion

        #region Get

        internal static async Task<List<tblCountry>> GetAllCountries()
        {
            try
            {
                using (db = new eMSPEntities())
                {
                    return await Task.Run(() => db.tblCountries.Select(a=>a).ToList());
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        internal static async Task<List<tblCountryState>> GetAllStates(int Id)
        {
            try
            {


                using (db = new eMSPEntities())
                {
                    return await Task.Run(() => db.tblCountryStates.Where(a => a.CountryID == Id).ToList());
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
       
        #endregion

        #region Insert


        #endregion

        #region Update


        #endregion

        #region Delete

        #endregion



    }
}
