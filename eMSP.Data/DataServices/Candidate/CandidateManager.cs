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

        public async Task<CandidateCreateModel> GetCandidate(int candidateId)
        {
            try
            {
                CandidateCreateModel model = null;
                

                
                        tblCandidate res = await Task.Run(() => ManageCandidate.Get(Convert.ToInt64(candidateId)));
                        model = res.ConvertToCandidateCreateModel();
                       

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
