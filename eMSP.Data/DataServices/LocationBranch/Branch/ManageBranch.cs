using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using eMSP.DataModel;
using System.Data.Entity;

namespace eMSP.Data.DataServices.LocationBranch
{
    internal static class ManageBranch
    {
        #region Initialization

        internal static eMSPEntities db;

        static ManageBranch()
        {

        }

        #endregion

        #region Get
        internal static async Task<tblBranch> GetBranchDetails(long Id)
        {
            try
            {
                using (db = new eMSPEntities())
                {
                    return await Task.Run(() => db.tblBranches
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

        internal static async Task<tblBranch> InsertBranch(tblBranch model)
        {
            try
            {
                using (db = new eMSPEntities())
                {
                    model = db.tblBranches.Add(model);

                    int x = await Task.Run(() => db.SaveChangesAsync());

                    return model;

                }
            }
            catch (Exception ex)
            {
                throw;

            }
        }

        #endregion

        #region Update

        internal static async Task<tblBranch> UpdateBranch(tblBranch model)
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

        internal static async Task DeleteBranch(long Id)
        {
            try
            {
                using (db = new eMSPEntities())
                {
                    tblBranch obj = await db.tblBranches.FindAsync(Id);
                    db.tblBranches.Remove(obj);
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
