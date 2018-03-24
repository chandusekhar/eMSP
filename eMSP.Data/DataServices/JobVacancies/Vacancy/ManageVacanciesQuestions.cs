using eMSP.DataModel;
using eMSP.ViewModel;
using eMSP.ViewModel.JobVacancies;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eMSP.Data.DataServices.JobVacancies.Vacancy
{
   public class ManageVacanciesQuestions
    {
        private bool IsDisposed = false;
        internal eMSPEntities mContext;

        public ManageVacanciesQuestions()
        {
            mContext = new eMSPEntities();
        }

        public async Task<List<VacancyQuestionViewModel>> GetJobsQuestions(long VacancyId)
        {
            try
            {
                using (var db = mContext)
                {
                    var data = await db.tblVacanciesQuestions.Where(x=>x.VacancyID == VacancyId).ToListAsync();

                    return data.Select(x => new VacancyQuestionViewModel
                    {
                        ID = x.ID,
                        VacancyID=x.VacancyID,
                        QuestionName = x.QuestionName,
                        QuestionDescription = x.QuestionDescription,                        
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

        public async Task<VacancyQuestionViewModel> Get(long Id)
        {
            try
            {
                using (var db = mContext)
                {
                    var obj = await db.tblVacanciesQuestions.Where(x => x.ID == Id).FirstOrDefaultAsync();

                    return new VacancyQuestionViewModel
                    {
                        ID = obj.ID,
                        QuestionName = obj.QuestionName,
                        QuestionDescription = obj.QuestionDescription,
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

        public async Task<VacancyQuestionViewModel> Save(VacancyQuestionViewModel data)
        {
            try
            {
                using (var db = mContext)
                {
                    var obj = new tblVacanciesQuestion()
                    {
                        QuestionName = data.QuestionName,
                        QuestionDescription = data.QuestionDescription,
                        VacancyID=data.VacancyID,
                        IsActive = data.isActive,
                        IsMandatory = data.IsMandatory,
                        IsDeleted = data.isDeleted,
                        CreatedTimestamp = DateTime.UtcNow,
                        CreatedUserID = data.createdUserID
                    };

                    db.tblVacanciesQuestions.Add(obj);
                    await db.SaveChangesAsync();

                    return new VacancyQuestionViewModel
                    {
                        ID = obj.ID,
                        QuestionName = obj.QuestionName,
                        QuestionDescription = obj.QuestionDescription,
                        VacancyID =obj.VacancyID,
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

        public async Task<VacancyQuestionViewModel> Update(long id, VacancyQuestionViewModel data)
        {
            try
            {
                using (var db = mContext)
                {
                    var obj = await db.tblVacanciesQuestions.Where(x => x.ID == id).FirstOrDefaultAsync();

                    if (obj != null)
                    {
                        obj.QuestionName = data.QuestionName;
                        obj.QuestionDescription = data.QuestionDescription;
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

                    return new VacancyQuestionViewModel
                    {
                        ID = obj.ID,
                        QuestionName = obj.QuestionName,
                        QuestionDescription = obj.QuestionDescription,
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
                    var obj = await db.tblVacanciesQuestions.Where(x => x.ID == id).FirstOrDefaultAsync();

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

        ~ManageVacanciesQuestions()
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
