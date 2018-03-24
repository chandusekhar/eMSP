using eMSP.DataModel;
using eMSP.ViewModel.MSP;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eMSP.Data.DataServices.MSP
{
   public class ManageMSPRequiredDocuments : IDisposable
    {
        private bool IsDisposed = false;
        internal eMSPEntities mContext;

        public ManageMSPRequiredDocuments()
        {
            mContext = new eMSPEntities();
        }

        public async Task<List<RequiredDocumentViewModel>> Get()
        {
            try
            {
                using (var db = mContext)
                {
                    var data = await db.tblMSPRequiredDocuments.ToListAsync();

                    return data.Select(x => new RequiredDocumentViewModel
                    {
                        ID = x.ID,
                        RequiredDocumentName = x.RequiredDocumentName,
                        RequiredDocumentDescription = x.RequiredDocumentDescription,
                        IsDefault = x.IsDefault,
                        IsMandatory = x.IsMandatory,
                        isActive = x.IsActive,
                        isDeleted = x.IsDeleted,
                        createdTimestamp = x.CreatedTimestamp
                    }).ToList();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<RequiredDocumentViewModel> Save(RequiredDocumentViewModel data)
        {
            try
            {
                using (var db = mContext)
                {
                    var obj = new tblMSPRequiredDocument()
                    {
                        RequiredDocumentName = data.RequiredDocumentName,
                        RequiredDocumentDescription = data.RequiredDocumentDescription,
                        IsDefault = data.IsDefault,
                        IsActive = data.isActive,
                        IsMandatory = data.IsMandatory,
                        IsDeleted = data.isDeleted,
                        CreatedTimestamp = DateTime.UtcNow,
                        CreatedUserID = data.createdUserID
                    };

                    db.tblMSPRequiredDocuments.Add(obj);
                    await db.SaveChangesAsync();

                    return new RequiredDocumentViewModel
                    {
                        ID = obj.ID,
                        RequiredDocumentName = obj.RequiredDocumentName,
                        RequiredDocumentDescription = obj.RequiredDocumentDescription,
                        IsDefault = obj.IsDefault,
                        IsMandatory = obj.IsMandatory,
                        isActive = obj.IsActive,
                        isDeleted = obj.IsDeleted,
                        createdTimestamp = obj.CreatedTimestamp
                    };
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<RequiredDocumentViewModel> Update(long id, RequiredDocumentViewModel data)
        {
            try
            {
                using (var db = mContext)
                {
                    var obj = await db.tblMSPRequiredDocuments.Where(x => x.ID == id).FirstOrDefaultAsync();

                    if (obj != null)
                    {
                        obj.RequiredDocumentName = data.RequiredDocumentName;
                        obj.RequiredDocumentDescription = data.RequiredDocumentDescription;
                        obj.IsDefault = data.IsDefault;
                        obj.IsMandatory = data.IsMandatory;
                        obj.IsActive = data.isActive;
                        obj.UpdatedTimestamp = DateTime.UtcNow;
                        obj.UpdatedUserID = data.updatedUserID;
                        obj.IsDeleted = data.isDeleted;
                    }
                    else
                    {
                        new Exception("Update Failed. Please verify data");
                    }
                    await db.SaveChangesAsync();

                    return new RequiredDocumentViewModel
                    {
                        ID = obj.ID,
                        RequiredDocumentName = obj.RequiredDocumentName,
                        RequiredDocumentDescription = obj.RequiredDocumentDescription,
                        IsDefault = obj.IsDefault,
                        IsMandatory = obj.IsMandatory,
                        isActive = obj.IsActive,
                        isDeleted = obj.IsDeleted,
                        createdTimestamp = obj.CreatedTimestamp
                    };
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<Boolean> ChangeStatus(long id, Boolean status, string loggedInUserID)
        {
            try
            {
                using (var db = mContext)
                {
                    var obj = await db.tblMSPRequiredDocuments.Where(x => x.ID == id).FirstOrDefaultAsync();

                    if (obj != null)
                    {
                        obj.IsActive = status;
                        obj.UpdatedTimestamp = DateTime.UtcNow;
                        obj.UpdatedUserID = loggedInUserID;
                    }
                    else
                    {
                        new Exception("Change Status Failed. Please verify data");
                    }
                    await db.SaveChangesAsync();
                    return true;
                }
            }
            catch (Exception)
            {
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

        ~ManageMSPRequiredDocuments()
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
