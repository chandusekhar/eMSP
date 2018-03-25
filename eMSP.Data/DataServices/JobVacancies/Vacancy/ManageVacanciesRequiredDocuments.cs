using eMSP.DataModel;
using eMSP.ViewModel.JobVacancies;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eMSP.Data.DataServices.JobVacancies.Vacancy
{
   public class ManageVacanciesRequiredDocuments
    {
        private bool IsDisposed = false;
        internal eMSPEntities mContext;

        public ManageVacanciesRequiredDocuments()
        {
            mContext = new eMSPEntities();
        }

        public async Task<List<VacancyRequiredDocumentViewModel>> GetJobsQuestions(long VacancyId)
        {
            try
            {
                using (var db = mContext)
                {
                    var data = await db.tblVacanciesRequiredDocuments.Where(x => x.VacancyID == VacancyId).ToListAsync();

                    return data.Select(x => new VacancyRequiredDocumentViewModel
                    {
                        ID = x.ID,
                        VacancyID = x.VacancyID,
                        RequiredDocumentName = x.RequiredDocumentName,
                        RequiredDocumentDescription = x.RequiredDocumentDescription,
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

        public async Task<VacancyRequiredDocumentViewModel> Get(long Id)
        {
            try
            {
                using (var db = mContext)
                {
                    var obj = await db.tblVacanciesRequiredDocuments.Where(x => x.ID == Id).FirstOrDefaultAsync();

                    return new VacancyRequiredDocumentViewModel
                    {
                        ID = obj.ID,
                        RequiredDocumentName = obj.RequiredDocumentName,
                        RequiredDocumentDescription = obj.RequiredDocumentDescription,
                        VacancyID = obj.VacancyID,
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

        public async Task<VacancyRequiredDocumentViewModel> Save(VacancyRequiredDocumentViewModel data)
        {
            try
            {
                using (var db = mContext)
                {
                    var obj = new tblVacanciesRequiredDocument()
                    {
                        RequiredDocumentName = data.RequiredDocumentName,
                        RequiredDocumentDescription = data.RequiredDocumentDescription,
                        VacancyID = data.VacancyID,
                        IsActive = data.isActive,
                        IsMandatory = data.IsMandatory,
                        IsDeleted = data.isDeleted,
                        CreatedTimestamp = DateTime.UtcNow,
                        CreatedUserID = data.createdUserID
                    };

                    db.tblVacanciesRequiredDocuments.Add(obj);
                    await db.SaveChangesAsync();

                    return new VacancyRequiredDocumentViewModel
                    {
                        ID = obj.ID,
                        RequiredDocumentName = obj.RequiredDocumentName,
                        RequiredDocumentDescription = obj.RequiredDocumentDescription,
                        VacancyID = obj.VacancyID,
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

        public async Task<VacancyRequiredDocumentViewModel> Update(long id, VacancyRequiredDocumentViewModel data)
        {
            try
            {
                using (var db = mContext)
                {
                    var obj = await db.tblVacanciesRequiredDocuments.Where(x => x.ID == id).FirstOrDefaultAsync();

                    if (obj != null)
                    {
                        obj.RequiredDocumentName = data.RequiredDocumentName;
                        obj.RequiredDocumentDescription = data.RequiredDocumentDescription;
                        obj.VacancyID = data.VacancyID;
                        obj.IsMandatory = data.IsMandatory;
                        obj.IsActive = data.isActive;
                        obj.UpdatedTimestamp = DateTime.UtcNow;
                        obj.UpdatedUserID = data.updatedUserID;
                    }
                    else
                    {
                        new Exception("Update Failed. Please verify data");
                    }
                    await db.SaveChangesAsync();

                    return new VacancyRequiredDocumentViewModel
                    {
                        ID = obj.ID,
                        RequiredDocumentName = obj.RequiredDocumentName,
                        RequiredDocumentDescription = obj.RequiredDocumentDescription,
                        VacancyID = obj.VacancyID,
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
                    var obj = await db.tblVacanciesRequiredDocuments.Where(x => x.ID == id).FirstOrDefaultAsync();

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

        ~ManageVacanciesRequiredDocuments()
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
