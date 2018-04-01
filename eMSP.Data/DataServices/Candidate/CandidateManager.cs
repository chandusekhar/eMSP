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

        public async Task<CandidateSubmissionModel> CreateCandidateSubmission(CandidateSubmissionModel data)
        {
            try
            {
                CandidateSubmissionModel model = null;


                CandidateSubmissionModel res = await Task.Run(() => ManageCandidate.InsertCandidateSubmissions(data.ConverToTblCandidateSubmission()));
                // model = res.ConvertToCandidateCreateModel();


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
        public async Task<CandidateSubmissionModel> UpdateCandidateSubmission(CandidateSubmissionModel data)
        {
            try
            {
                return await Task.Run(() => ManageCandidate.UpdateCandidateSubmissions(data.ConverToTblCandidateSubmission()));
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
