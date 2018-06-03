using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using eMSP.DataModel;
using System.Data.Entity;
using eMSP.ViewModel.JobVacancies;
using eMSP.Data.Extensions;
using eMSP.Data.DataServices.Comments;
using eMSP.ViewModel.Comments;
using eMSP.ViewModel.Shared;
using eMSP.ViewModel.MSP;
using eMSP.ViewModel.LocationBranch;

namespace eMSP.Data.DataServices.JobVacancies
{
    class ManageVacancy
    {
        #region Initialization

        internal static eMSPEntities db;

        static ManageVacancy()
        {

        }

        #endregion

        #region Get
        internal static async Task<tblVacancy> GetVacancyDetails(long Id)
        {
            try
            {
                using (db = new eMSPEntities())
                {
                    return await Task.Run(() => db.tblVacancies
                                                  .Include(a => a.tblCustomer)
                                                  .Include(a => a.tblMSPVacancieType)
                                                  .Where(x => x.ID == Id).SingleOrDefault());


                }
            }
            catch (Exception)
            {
                throw;

            }
        }


        internal static async Task<List<tblVacancy>> GetAllVacancies(CompanyModel model)
        {
            try
            {
                using (db = new eMSPEntities())
                {
                    long companyId = Convert.ToInt64(model.id);

                    if (companyId != 0 && model.companyType == "Customer")
                    {
                        return await Task.Run(() => db.tblVacancies
                                                      .Include(a => a.tblCustomer)
                                                      .Include(a => a.tblMSPVacancieType)
                                                      .Include(a => a.tblJobVacanciesStatu)
                                                      .Include(a => a.tblVacancyComments)
                                                      .Include(a => a.tblVacancyComments.Select(b => b.tblComment))
                                                      .Include(a => a.tblVacancyFiles)
                                                      .Include(a => a.tblVacanciesQuestions)
                                                      .Include(a => a.tblVacanciesRequiredDocuments)
                                                      .Include(a => a.tblVacanciesQuestions.Select(b => b.tblCandidateSubmissionsQuestionsResponses))
                                                      .Include(a => a.tblVacanciesRequiredDocuments.Select(b => b.tblCandidateSubmissionDocumentResponses))
                                                      .Include(a => a.tblVacancyLocations.Select(c => c.tblLocation).Select(e => e.tblCountry))
                                                      .Include(a => a.tblVacancyLocations.Select(c => c.tblLocation).Select(d => d.tblCountryState).Select(e => e.tblCountry))
                                                      .Include(a => a.tblVacancySuppliers.Select(b => b.tblSupplier).Select(e => e.tblCountry))
                                                      .Include(a => a.tblVacancySuppliers.Select(b => b.tblSupplier).Select(e => e.tblCountryState))
                                                      .Include(a => a.tblVacancieSkills.Select(b => b.tblIndustrySkill))
                                                      .Where(x => x.tblCustomer.ID == companyId)
                                                      .OrderByDescending(x => x.ID).ToList());
                    }
                    else if (companyId != 0 && model.companyType == "Supplier")
                    {
                        return await Task.Run(() => db.tblVacancies
                                                      .Include(a => a.tblCustomer)
                                                      .Include(a => a.tblMSPVacancieType)
                                                      .Include(a => a.tblJobVacanciesStatu)
                                                      .Include(a => a.tblVacancyComments)
                                                      .Include(a => a.tblVacancyComments.Select(b => b.tblComment))
                                                      .Include(a => a.tblVacancyFiles)
                                                      .Include(a => a.tblVacanciesQuestions)
                                                      .Include(a => a.tblVacanciesRequiredDocuments)
                                                      .Include(a => a.tblVacanciesQuestions.Select(b => b.tblCandidateSubmissionsQuestionsResponses))
                                                      .Include(a => a.tblVacanciesRequiredDocuments.Select(b => b.tblCandidateSubmissionDocumentResponses))
                                                      .Include(a => a.tblVacancyLocations.Select(c => c.tblLocation).Select(e => e.tblCountry))
                                                      .Include(a => a.tblVacancyLocations.Select(c => c.tblLocation).Select(d => d.tblCountryState).Select(e => e.tblCountry))
                                                      .Include(a => a.tblVacancySuppliers.Select(b => b.tblSupplier).Select(e => e.tblCountry))
                                                      .Include(a => a.tblVacancySuppliers.Select(b => b.tblSupplier).Select(e => e.tblCountryState))
                                                      .Include(a => a.tblVacancieSkills.Select(b => b.tblIndustrySkill))
                                                      .Where(x => x.tblVacancySuppliers.Any(r => r.SupplierID == companyId))
                                                      .OrderByDescending(x => x.ID).ToList());
                    }
                    else
                    {
                        return await Task.Run(() => db.tblVacancies
                                                      .Include(a => a.tblCustomer)
                                                      .Include(a => a.tblMSPVacancieType)
                                                      .Include(a => a.tblJobVacanciesStatu)
                                                      .Include(a => a.tblVacancyComments)
                                                      .Include(a => a.tblVacancyComments.Select(b => b.tblComment))
                                                      .Include(a => a.tblVacancyFiles)
                                                      .Include(a => a.tblVacanciesQuestions)
                                                      .Include(a => a.tblVacanciesRequiredDocuments)
                                                      .Include(a => a.tblVacanciesQuestions.Select(b=>b.tblCandidateSubmissionsQuestionsResponses))
                                                      .Include(a => a.tblVacanciesRequiredDocuments.Select(b=>b.tblCandidateSubmissionDocumentResponses))
                                                      .Include(a => a.tblVacancyLocations.Select(c => c.tblLocation).Select(e => e.tblCountry))
                                                      .Include(a => a.tblVacancyLocations.Select(c => c.tblLocation).Select(d => d.tblCountryState).Select(e => e.tblCountry))
                                                      .Include(a => a.tblVacancySuppliers.Select(b => b.tblSupplier).Select(e => e.tblCountry))
                                                      .Include(a => a.tblVacancySuppliers.Select(b => b.tblSupplier).Select(e => e.tblCountryState))
                                                      .Include(a => a.tblVacancieSkills.Select(b => b.tblIndustrySkill))
                                                      .OrderByDescending(x => x.ID).ToList());
                    }
                }
            }
            catch (Exception)
            {
                throw;

            }
        }

        internal static async Task<tblVacancy> GetVacancyComments(long Id)
        {
            try
            {
                using (db = new eMSPEntities())
                {
                    return await Task.Run(() => db.tblVacancies
                                                  .Include(a => a.tblCustomer)
                                                  .Include(a => a.tblVacancyComments)
                                                  .Include(a => a.tblVacancyComments.Select(b => b.tblComment))
                                                  .Include(a => a.tblVacancyComments.Select(b => b.tblComment).Select(c => c.tblCommentUsers))
                                                  .Include(a => a.tblVacancyComments.Select(b => b.tblComment).Select(c => c.tblCommentUsers.Select(x => x.tblUserProfile)))
                                                  .Include(a => a.tblVacancyComments.Select(b => b.tblComment).Select(c => c.tblCommentUsers.Select(x => x.tblUserProfile).Select(d => d.tblCountry)))
                                                  .Include(a => a.tblVacancyComments.Select(b => b.tblComment).Select(c => c.tblCommentUsers.Select(x => x.tblUserProfile).Select(d => d.tblCountryState)))
                                                  .Where(x => x.ID == Id)
                                                  .SingleOrDefault());


                }
            }
            catch (Exception)
            {
                throw;

            }
        }

        #endregion

        #region Insert

        internal static async Task<VacancyCreateModel> Insert(VacancyCreateModel model)
        {
            try
            {
                using (db = new eMSPEntities())
                {

                    tblVacancy vacancy = await Task.Run(() => InsertVacancy(model.Vacancy.ConvertTotblVacancy()));

                    foreach (IndustrySkillsCreateModel a in model.VacancySkills)
                    {
                        await Task.Run(() => ManageVacancySkills.AddVacancySkills(a.id, vacancy));
                    }

                    foreach (CompanyCreateModel a in model.VacancySuppliers)
                    {
                        await Task.Run(() => ManageVacancySuppliers.InsertVacancySupplier(a.id, vacancy));
                    }

                    foreach (LocationCreateModel a in model.VacancyLocations)
                    {
                        await Task.Run(() => ManageVacancyLocations.AddVacancyLocation(a.locationId, vacancy));
                    }

                    foreach (VacancyFileModel a in model.VacancyFiles)
                    {
                        await Task.Run(() => ManageVacancyFiles.InsertVacancyFiles(a.ConvertTotblVacancyFile(), vacancy));
                    }

                    foreach (VacancyRequiredDocumentViewModel a in model.RequiredDocument.Where(x => x.IsSelected ?? false))
                    {
                        await Task.Run(() => ManageVacancyRequiredDocuments.AddVacanciesRequiredDocument(a.ConvertTotblVacanciesRequiredDocument(), vacancy));
                    }

                    foreach (VacancyQuestionViewModel a in model.Questions.Where(x => x.IsSelected ?? false))
                    {
                        await Task.Run(() => ManageVacancyQuestions.AddVacanciesQuestions(a.ConvertTotblVacanciesQuestion(), vacancy));
                    }

                    //Comments
                    foreach (CommentModel c in model.VacancyComment)
                    {
                        if (!string.IsNullOrEmpty(c.comment))
                        {
                            c.createdUserID = vacancy.CreatedUserID;
                            c.createdTimestamp = vacancy.CreatedTimestamp;
                            c.updatedUserID = vacancy.UpdatedUserID;
                            c.updatedTimestamp = vacancy.UpdatedTimestamp;                            
                            tblComment comment = await Task.Run(() => ManageComments.InsertComment(c.ConvertTotblComment()));

                            tblVacancyComment vc = db.tblVacancyComments.Add(new tblVacancyComment
                            {
                                CommentID = comment.ID,
                                VacancyID = vacancy.ID,
                                IsActive = true,
                                IsDeleted = false,
                                CreatedTimestamp = vacancy.CreatedTimestamp,
                                CreatedUserID = vacancy.CreatedUserID,
                                UpdatedTimestamp = vacancy.UpdatedTimestamp,
                                UpdatedUserID = vacancy.UpdatedUserID
                            });

                            tblVacancyComment resVC = await Task.Run(() => ManageVacancyComments.CommentVacancy(vc));

                            CommentUsersModel commentUM = new CommentUsersModel
                            {
                                commentId = comment.ID,
                                userId = vacancy.CreatedUserID,
                                isActive = true,
                                isDeleted = false,
                                createdTimestamp = vacancy.CreatedTimestamp,
                                createdUserID = vacancy.CreatedUserID,
                                updatedTimestamp = vacancy.UpdatedTimestamp,
                                updatedUserID = vacancy.UpdatedUserID
                            };
                            
                            tblCommentUser resCommentUser = await Task.Run(() => ManageComments.InsertCommentUser(commentUM.ConvertTotblCommentUser()));

                        }
                    }
                    return model;
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        internal static async Task<VacancyCreateModel> Update(VacancyCreateModel model)
        {
            try
            {
                using (db = new eMSPEntities())
                {
                    tblVacancy vacancy = await Task.Run(() => UpdateVacancy(model.Vacancy.ConvertTotblVacancy()));

                    await Task.Run(() => ManageVacancySkills.DeleteVacancySkills(vacancy.ID));
                    foreach (IndustrySkillsCreateModel a in model.VacancySkills)
                    {
                        tblVacancieSkill vacancySkill = await Task.Run(() => ManageVacancySkills.AddVacancySkills(a.id, vacancy));
                    }

                    await Task.Run(() => ManageVacancySuppliers.UpdateVacancySupplier(vacancy.ID));
                    foreach (CompanyCreateModel a in model.VacancySuppliers)
                    {
                        tblVacancySupplier vacancySupplier = await Task.Run(() => ManageVacancySuppliers.InsertVacancySupplier(a.id, vacancy));
                    }

                    await Task.Run(() => ManageVacancyLocations.DeleteVacancyLocation(vacancy.ID));
                    foreach (LocationCreateModel a in model.VacancyLocations)
                    {
                        tblVacancyLocation vacancyLocation = await Task.Run(() => ManageVacancyLocations.AddVacancyLocation(a.locationId, vacancy));
                    }

                    await Task.Run(() => ManageVacancyFiles.DeleteVacancyFile(vacancy.ID));
                    foreach (VacancyFileModel a in model.VacancyFiles)
                    {
                        tblVacancyFile vacancyFile = await Task.Run(() => ManageVacancyFiles.InsertVacancyFiles(a.ConvertTotblVacancyFile(), vacancy));
                    }

                    await Task.Run(() => ManageVacancyRequiredDocuments.DeleteVacanciesRequiredDocument(vacancy.ID));
                    foreach (VacancyRequiredDocumentViewModel a in model.RequiredDocument.Where(x => x.IsSelected ?? false))
                    {
                        await Task.Run(() => ManageVacancyRequiredDocuments.AddVacanciesRequiredDocument(a.ConvertTotblVacanciesRequiredDocument(), vacancy));
                    }

                    await Task.Run(() => ManageVacancyQuestions.DeleteVacancySkills(vacancy.ID));
                    foreach (VacancyQuestionViewModel a in model.Questions.Where(x => x.IsSelected ?? false))
                    {
                        await Task.Run(() => ManageVacancyQuestions.AddVacanciesQuestions(a.ConvertTotblVacanciesQuestion(), vacancy));
                    }

                    //Comments
                    foreach (CommentModel c in model.VacancyComment)
                    {
                        if (!string.IsNullOrEmpty(c.comment))
                        {
                            c.updatedUserID = vacancy.UpdatedUserID;
                            c.updatedTimestamp = vacancy.UpdatedTimestamp;
                            tblComment comment = await Task.Run(() => ManageComments.UpdateComment(c.ConvertTotblComment()));
                        }
                    }
                    return model;
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        internal static async Task<tblVacancy> InsertVacancy(tblVacancy model)
        {
            try
            {
                using (db = new eMSPEntities())
                {
                    model = db.tblVacancies.Add(model);

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

        internal static async Task<tblVacancy> UpdateVacancy(tblVacancy model)
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

        internal static async Task DeleteVacancy(long Id)
        {
            try
            {
                using (db = new eMSPEntities())
                {
                    tblVacancy obj = await db.tblVacancies.FindAsync(Id);
                    db.tblVacancies.Remove(obj);
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
