using eMSP.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eMSP.Data.DataServices.MSP
{
    public class ManageMSPTimeGroup
    {
        #region Initialization

        internal static eMSPEntities db;

        static ManageMSPTimeGroup() { }

        #endregion

        #region Get
        internal static async Task<List<tblMSPTimeGroup>> GetMSPTimeGroups()
        {
            try
            {
                using (db = new eMSPEntities())
                {
                    return await Task.Run(() => db.tblMSPTimeGroups
                                                  .Where(x => (x.IsActive ?? true) && (!x.IsDeleted ?? false))
                                                  .ToList());


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
