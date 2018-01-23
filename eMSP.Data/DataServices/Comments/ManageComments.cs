using eMSP.DataModel;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eMSP.Data.DataServices.Comments
{
    class ManageComments
    {
        #region Initialization

        internal static eMSPEntities db;

        static ManageComments()
        {

        }

        #endregion

        #region Get
        internal static async Task<tblComment> GetComment(long Id)
        {
            try
            {
                using (db = new eMSPEntities())
                {
                    return await Task.Run(() => db.tblComments                                                  
                                                  .Where(x => x.ID == Id).FirstOrDefault());

                }
            }
            catch (Exception)
            {
                throw;
            }
        }        

        #endregion

        #region Insert

        internal static async Task<tblComment> InsertComment(tblComment model)
        {
            try
            {
                using (db = new eMSPEntities())
                {                    
                    model = db.tblComments.Add(model);

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

        internal static async Task<tblComment> UpdateComment(tblComment model)
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

        internal static async Task DeleteComment(long Id)
        {
            try
            {
                using (db = new eMSPEntities())
                {
                    tblComment obj = await db.tblComments.FindAsync(Id);
                    db.tblComments.Remove(obj);
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
