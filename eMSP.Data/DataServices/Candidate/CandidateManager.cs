using eMSP.ViewModel.MSP;
using eMSP.Data.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using eMSP.DataModel;
using System.Configuration;
using eMSP.ViewModel.Candidate;
using eMSP.ViewModel.JobVacancies;

namespace eMSP.Data.DataServices.Candidate
{
    public class CandidateManager : IDisposable
    {
        #region Initialization

        private bool IsDisposed = false;

        public CandidateManager()
        {

        }

        #endregion

        #region Get

        public async Task<List<CandidateSubmissionModel>> GetCandidateSubmission(int vacancyId)
        {
            try
            {
                List<CandidateSubmissionModel> model = null;
                

                
                       List< tblCandidateSubmission> res = await Task.Run(() => ManageCandidate.GetCandidateSubmission(Convert.ToInt64(vacancyId)));
                        model = res.Select(a=>a.ConvertToCandidateSubmissionModel()).ToList();
                       

                return model;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<List<CandidateStatusModel>> GetCandidateStatus()
        {
            try
            {
                List<CandidateStatusModel> model = null;



                List<tblCandidateStatu> res = await Task.Run(() => ManageCandidate.GetAllCandidateStatus());
                model = res.Select(a => a.ConvertToCandidateStatusModel()).ToList();


                return model;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<List<CandidateCreateModel>> GetAllCandidates(int SupplierId)
        {
            try
            {
                List<CandidateCreateModel> data = null;

                List<tblCandidate> res = await Task.Run(() => ManageCandidate.GetAll(SupplierId));
                data = res.Select(a=>a.ConvertToCandidateCreateModel()).ToList();

                return data;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<CandidateCreateModel> GetCandidate(int CandidateId)
        {
            try
            {
                tblCandidate res = await Task.Run(() => ManageCandidate.GetCandidate(CandidateId));

                return res.ConvertToCandidateCreateModel();
            }
            catch (Exception)
            {
                throw;
            }
        }


        #endregion

        #region Insert

        public async Task<CandidateCreateModel> CreateCandidate(CandidateCreateModel data)
        {
            try
            {
                CandidateCreateModel model = null;


                CandidateCreateModel res = await Task.Run(() => ManageCandidate.Insert(data));
                       // model = res.ConvertToCandidateCreateModel();
                      

                return model;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<CandidateSubmissionCreateModel> CreateCandidateSubmission(CandidateSubmissionCreateModel data)
        {
            try
            {
                CandidateSubmissionCreateModel model = null;

                if (data.IsNewCustomer)
                {
                    CandidateCreateModel candidate= await Task.Run(() => CreateCandidate(data.Candidate));
                    data.CandidateSubmission.CandidateId = candidate.Candidate.id;
                }

                if (data.IsCustomerEdited)
                {
                    await Task.Run(() => UpdateCandidate(data.Candidate));
                }

                CandidateSubmissionModel submissionResp = await Task.Run(() => ManageCandidate.InsertCandidateSubmissions(data.CandidateSubmission.ConverToTblCandidateSubmission()));


                foreach (VacancyQuestionViewModel vq in data.Questions)
                {
                    vq.CandidateSubmissionsQuestionsResponse.All(re =>
                    {
                        re.createdTimestamp = data.CandidateSubmission.createdTimestamp;
                        re.createdUserID = data.CandidateSubmission.createdUserID;
                        re.updatedUserID = data.CandidateSubmission.updatedUserID;
                        re.updatedTimestamp = data.CandidateSubmission.updatedTimestamp;
                        re.submissionId = submissionResp.ID;
                        return true;
                    });
                    await Task.Run(() => ManageCandidateSubmissionsQuestionsResponses.InsertCandidateSubmissionsQuestionsRespons(vq.CandidateSubmissionsQuestionsResponse.Select(re => re.ConvertTotblCandidateSubmissionsQuestionsRespons()).ToList()));
                }

                foreach (VacancyRequiredDocumentViewModel rd in data.RequiredDocument)
                {
                    rd.CandidateSubmissionDocumentResponse.All(re => {
                        re.createdTimestamp = data.CandidateSubmission.createdTimestamp;
                        re.createdUserID = data.CandidateSubmission.createdUserID;
                        re.updatedUserID = data.CandidateSubmission.updatedUserID;
                        re.updatedTimestamp = data.CandidateSubmission.updatedTimestamp;
                        re.candidateSubmissionId = submissionResp.ID;
                        return true;
                    });

                    await Task.Run(() => ManageCandidateSubmissionDocumentResponses.InsertCandidateSubmissionDocumentRespons(rd.CandidateSubmissionDocumentResponse.Select(res => res.ConvertTotblCandidateSubmissionsQuestionsResponses()).ToList()));
                }

                return model;
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion

        #region Update

        public async Task<CandidateCreateModel> UpdateCandidate(CandidateCreateModel data)
        {
            try
            {                           
               return await Task.Run(() => ManageCandidate.Update(data));                              
            }
            catch (Exception)
            {
                throw;
            }
        }
        public async Task<CandidateSubmissionCreateModel> UpdateCandidateSubmission(CandidateSubmissionCreateModel data)
        {
            try
            {
                CandidateSubmissionCreateModel model = null;

                if (data.IsNewCustomer)
                {
                    CandidateCreateModel candidate = await Task.Run(() => CreateCandidate(data.Candidate));
                    data.CandidateSubmission.CandidateId = candidate.Candidate.id;
                }

                if (data.IsCustomerEdited)
                {
                    await Task.Run(() => UpdateCandidate(data.Candidate));
                }

                await Task.Run(() => ManageCandidate.UpdateCandidateSubmissions(data.CandidateSubmission.ConverToTblCandidateSubmission()));

                await Task.Run(() => ManageCandidateSubmissionsQuestionsResponses.DeleteCandidateSubmissionsQuestionsRespons(data.CandidateSubmission.ID));
                foreach (VacancyQuestionViewModel vq in data.Questions)
                {
                    vq.CandidateSubmissionsQuestionsResponse.All(re =>
                    {
                        re.createdTimestamp = data.CandidateSubmission.createdTimestamp;
                        re.createdUserID = data.CandidateSubmission.createdUserID;
                        re.updatedUserID = data.CandidateSubmission.updatedUserID;
                        re.updatedTimestamp = data.CandidateSubmission.updatedTimestamp;
                        return true;
                    });
                    await Task.Run(() => ManageCandidateSubmissionsQuestionsResponses.InsertCandidateSubmissionsQuestionsRespons(vq.CandidateSubmissionsQuestionsResponse.Select(re => re.ConvertTotblCandidateSubmissionsQuestionsRespons()).ToList()));
                }

                await Task.Run(() => ManageCandidateSubmissionDocumentResponses.DeleteCandidateSubmissionDocumentRespons(data.CandidateSubmission.ID));
                foreach (VacancyRequiredDocumentViewModel rd in data.RequiredDocument)
                {
                    rd.CandidateSubmissionDocumentResponse.All(re => {
                        re.createdTimestamp = data.CandidateSubmission.createdTimestamp;
                        re.createdUserID = data.CandidateSubmission.createdUserID;
                        re.updatedUserID = data.CandidateSubmission.updatedUserID;
                        re.updatedTimestamp = data.CandidateSubmission.updatedTimestamp;
                        return true;
                    });

                    await Task.Run(() => ManageCandidateSubmissionDocumentResponses.InsertCandidateSubmissionDocumentRespons(rd.CandidateSubmissionDocumentResponse.Select(res => res.ConvertTotblCandidateSubmissionsQuestionsResponses()).ToList()));
                }

                return model;
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion

        #region Delete

        public async Task DeleteCandidate(CompanyModel data)
        {
            try
            {
                long Id = Convert.ToInt64(data.id);
                
                        //await Task.Run(() => ManageCandidate.Delete(Id));
                       

            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion

        #region Dispose

        protected virtual void Dispose(bool dispose)
        {
            if (!IsDisposed)
            {
                if (dispose)
                {
                    this.Dispose();
                }
                IsDisposed = true;
            }


        }

        ~CandidateManager()
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
