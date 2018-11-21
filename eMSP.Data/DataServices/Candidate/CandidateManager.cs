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

        public async Task<CandidateSubmissionModel> GetCandidateDetails(int SubmissionId)
        {
            try
            {
                tblCandidateSubmission res = await Task.Run(() => ManageCandidate.GetCandidateDetails(Convert.ToInt64(SubmissionId)));

                return res.ConvertToCandidateSubmissionModel();
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

        public async Task<CandidateSubmissionSpendViewModel> GetExpenseDetails(long ExpenseId)
        {
            try
            {
                tblCandidateSubmissionSpend res = await Task.Run(() => ManageCandidateSubmissionSpend.GetExpenseDetails(ExpenseId));

                return res.ConvertToCandidateSubmissionSpendViewModel();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<List<CandidateSubmissionSpendViewModel>> GetCandidateExpenseSpend(long PlacementId)
        {
            try
            {
                List<tblCandidateSubmissionSpend> res = await Task.Run(() => ManageCandidateSubmissionSpend.GetCandidateExpenseSpends(PlacementId));

                return res.Select(x => x.ConvertToCandidateSubmissionSpendViewModel()).ToList();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<List<CandidatePlacementViewModel>> GetPlacedCandidates()
        {
            try
            {
                List<tblCandidatePlacement> res = await Task.Run(() => ManageCandidatePlacement.GetAllPlacements());

                return res.Select(x => x.ConvertToCandidatePlacementViewModel()).ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<CandidatePlacementViewModel> GetPlacementDetails(long PlacementId)
        {
            try
            {
                tblCandidatePlacement res = await Task.Run(() => ManageCandidatePlacement.GetPlacementDetails(PlacementId));

                return res.ConvertToCandidatePlacementViewModel();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<CandidatePlacementViewModel> GetPlacementByCandidateId(long CandidateId)
        {
            try
            {
                tblCandidatePlacement res = await Task.Run(() => ManageCandidatePlacement.GetPlacementByCandidateId(CandidateId));

                return res.ConvertToCandidatePlacementViewModel();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<List<AllTimesheetViewModel>> GetAllTimesheetEntries()
        {
            try
            {
                List<tblCandidateTimesheet> res = await Task.Run(() => ManageCandidateTimesheets.GetAllTimesheet());                               

                return res.Select(x => x.ConvertToTimesheetViewModel()).ToList();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<CandidateTimesheetViewModel> GetCandidateTimesheetDetails(long PlacementId)
        {
            try
            {
                tblCandidateTimesheet res = await Task.Run(() => ManageCandidateTimesheets.GetCandidateTimesheet(PlacementId));

                return res.ConvertToCandidateTimesheetViewModel();
            }
            catch (Exception ex)
            {
                throw;
            }
        }


        public async Task<CandidateTimesheetViewModel> GetCandidateTimesheetDetails(long placementId, long payPeriodId)
        {
            try
            {
                tblCandidateTimesheet res = await Task.Run(() => ManageCandidateTimesheets.GetCandidateTimesheet(placementId, payPeriodId));

                return res.ConvertToCandidateTimesheetViewModel();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<CandidateTimesheetViewModel> GetTimesheetDetailsById(long TimesheetId)
        {
            try
            {
                tblCandidateTimesheet res = await Task.Run(() => ManageCandidateTimesheets.GetTimesheetDetailsById(TimesheetId));

                return res.ConvertToCandidateTimesheetViewModel();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<CandidateTimesheetHoursViewModel> GetCandidateTimesheetHours(long Id)
        {
            try
            {
                tblCandidateTimesheetHour res = await Task.Run(() => ManageCandidateTimesheetHours.GetCandidateTimesheetHours(Id));

                return res.ConvertToCandidateTimesheetHoursViewModel();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<CandidateTimesheetCategoriesHoursViewModel> GetCandidateTimesheetCategoriesHours(long Id)
        {
            try
            {
                tblCandidateTimesheetCategoriesHour res = await Task.Run(() => ManageCandidateTimesheetCategoriesHours.GetCandidateTimesheetCategoriesHours(Id));

                return res.ConvertToCandidateTimesheetCategoriesHoursViewModel();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<List<SuplierCandidatePlacementModel>> GetSupplierCandidatePlacement(long SupplierId)
        {
            try
            {
                var supplierCandidatePlacement= await Task.Run(() => ManageCandidate.GetSupplierCandidatePlacement(SupplierId));
                return supplierCandidatePlacement;
            }
            catch (Exception ex)
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

        public async Task<CandidateSubmissionSpendViewModel> InsertCandidateExpenseSpent(CandidateSubmissionSpendViewModel data)
        {
            try
            {
                foreach (var a in data.Files)
                {
                    CandidateSubmissionSpendFilesViewModel submittedfiles = new CandidateSubmissionSpendFilesViewModel();
                    var file = await Task.Run(() => ManageCandidate.InsertFiles(a.ConvertTotblFile()));
                    submittedfiles.FileID = file.ID;
                    submittedfiles.createdUserID = a.createdUserID;
                    submittedfiles.createdTimestamp = a.createdTimestamp;
                    submittedfiles.updatedTimestamp = a.updatedTimestamp;
                    submittedfiles.updatedUserID = a.updatedUserID;
                    data.CandidateSubmissionSpendFiles.Add(submittedfiles);
                }

                tblCandidateSubmissionSpend res = await Task.Run(() => ManageCandidateSubmissionSpend.InsertCandidateSubmissionSpend(data.ConvertTotblCandidateSubmissionSpend()));
                
                return res.ConvertToCandidateSubmissionSpendViewModel();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<CandidatePlacementViewModel> CreateCandidatePlacement(CandidatePlacementViewModel data)
        {
            try
            {
                tblCandidatePlacement res = await Task.Run(() => ManageCandidatePlacement.InsertCandidatePlacement(data.ConvertTotblCandidatePlacement()));

                return res.ConvertToCandidatePlacementViewModel();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<CandidateTimesheetViewModel> CreateCandidateTimesheet(CandidateTimesheetViewModel data)
        {
            try
            {
                tblCandidateTimesheet res = await Task.Run(() => ManageCandidateTimesheets.InsertCandidateTimesheet(data.ConvertTotblCandidateTimesheet()));

                return res.ConvertToCandidateTimesheetViewModel();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<CandidateTimesheetHoursViewModel> CreateCandidateTimesheetHours(CandidateTimesheetHoursViewModel data)
        {
            try
            {
                tblCandidateTimesheetHour res = await Task.Run(() => ManageCandidateTimesheetHours.InsertCandidateTimesheetHours(data.ConvertTotblCandidateTimesheetHour()));

                return res.ConvertToCandidateTimesheetHoursViewModel();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<CandidateTimesheetCategoriesHoursViewModel> CreateCandidateTimesheetCategoriesHours(CandidateTimesheetCategoriesHoursViewModel data)
        {
            try
            {
                tblCandidateTimesheetCategoriesHour res = await Task.Run(() => ManageCandidateTimesheetCategoriesHours.InsertCandidateTimesheetCategoriesHours(data.ConvertTotblCandidateTimesheetCategoriesHour()));

                return res.ConvertToCandidateTimesheetCategoriesHoursViewModel();
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

        public async Task<CandidateSubmissionSpendViewModel> UpdateCandidateExpenseSpent(CandidateSubmissionSpendViewModel data)
        {
            try
            {
                foreach (var a in data.Files)
                {
                    CandidateSubmissionSpendFilesViewModel submittedfiles = new CandidateSubmissionSpendFilesViewModel();
                    var file = await Task.Run(() => ManageCandidate.InsertFiles(a.ConvertTotblFile()));
                    submittedfiles.FileID = file.ID;
                    submittedfiles.createdUserID = a.createdUserID;
                    submittedfiles.createdTimestamp = a.createdTimestamp;
                    submittedfiles.updatedTimestamp = a.updatedTimestamp;
                    submittedfiles.updatedUserID = a.updatedUserID;
                    data.CandidateSubmissionSpendFiles.Add(submittedfiles);
                }

                await Task.Run(() => ManageCandidateSubmissionSpendFiles.DeleteCandidateSubmissionSpendFiles(data.ID));

                data.CandidateSubmissionSpendFiles.All(x => { x.SpendID = data.ID; return true; });

                tblCandidateSubmissionSpend res = await Task.Run(() => ManageCandidateSubmissionSpend.UpdateCandidateSubmissionSpend(data.ConvertTotblCandidateSubmissionSpend()));                

                

                List<tblCandidateSubmissionSpendFile> submittedFiles = await Task.Run(() => ManageCandidateSubmissionSpendFiles.InsertCandidateSubmissionSpendFiles(data.CandidateSubmissionSpendFiles.Select(x => x.ConvertTotblCandidateSubmissionSpendFile()).ToList()));
                data.CandidateSubmissionSpendFiles = submittedFiles.Select(x => x.ConvertToCandidateSubmissionSpendFilesViewModel()).ToList();

                return data;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<CandidatePlacementViewModel> UpdateCandidatePlacement(CandidatePlacementViewModel data)
        {
            try
            {
                await Task.Run(() => ManageCandidatePlacement.UpdateCandidatePlacement(data.ConvertTotblCandidatePlacement()));

                return data;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<CandidateTimesheetViewModel> UpdateCandidateTimesheet(CandidateTimesheetViewModel data)
        {
            try
            {
                await Task.Run(() => ManageCandidateTimesheets.UpdateCandidateTimesheet(data.ConvertTotblCandidateTimesheet()));

                return data;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<CandidateTimesheetHoursViewModel> UpdateCandidateTimesheetHours(CandidateTimesheetHoursViewModel data)
        {
            try
            {
                await Task.Run(() => ManageCandidateTimesheetHours.UpdateCandidateTimesheetHours(data.ConvertTotblCandidateTimesheetHour()));

                return data;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<CandidateTimesheetCategoriesHoursViewModel> UpdateCandidateTimesheetCategoriesHours(CandidateTimesheetCategoriesHoursViewModel data)
        {
            try
            {
                await Task.Run(() => ManageCandidateTimesheetCategoriesHours.UpdateCandidateTimesheetCategoriesHours(data.ConvertTotblCandidateTimesheetCategoriesHour()));

                return data;
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
