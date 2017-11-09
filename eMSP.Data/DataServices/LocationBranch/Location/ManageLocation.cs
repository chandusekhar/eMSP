using eMSP.DataModel;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eMSP.Data.DataServices.LocationBranch
{
    internal static class ManageLocation
    {
        #region Initialization

        internal static eMSPEntities db;

        static ManageLocation()
        {

        }

        #endregion

        #region Get
        internal static async Task<tblLocation> GetLocationDetails(long Id)
        {
            try
            {
                using (db = new eMSPEntities())
                {
                    return await Task.Run(() => db.tblLocations
                                                  .Where(x => x.ID == Id).SingleOrDefault());


                }
            }
            catch (Exception)
            {
                throw;

            }
        }

        #endregion

        #region Insert

        internal static async Task<tblLocation> InsertLocation(tblLocation model)
        {
            try
            {
                using (db = new eMSPEntities())
                {
                    model = db.tblLocations.Add(model);

                    int x = await Task.Run(() => db.SaveChangesAsync());

                    return model;

                }
            }
            catch (Exception)
            {
                throw;

            }
        }

        #endregion

        #region Update

        internal static async Task<tblLocation> UpdateLocation(tblLocation model)
        {
            try
            {
                using (db = new eMSPEntities())
                {
                    db.Entry(model).State = EntityState.Modified;

                    int x = await Task.Run(() => db.SaveChangesAsync());

                    return model;

                }
            }
            catch (Exception)
            {
                throw;

            }
        }

        #endregion

        #region Delete

        internal static async Task DeleteLocation(long Id)
        {
            try
            {
                using (db = new eMSPEntities())
                {
                    tblLocation obj = await db.tblLocations.FindAsync(Id);
                    db.tblLocations.Remove(obj);
                    int x = await Task.Run(() => db.SaveChangesAsync());

                }
            }
            catch (Exception)
            {
                throw;

            }
        }


        #endregion
    }
}
