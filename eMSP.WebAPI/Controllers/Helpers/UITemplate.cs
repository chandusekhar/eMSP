using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace eMSP.WebAPI.Controllers.Helpers
{
    public class UITemplate
    {
        //------------ Administration start------------- // 

        public bool navAdmistration = false;

        public bool navCompany = false;
        public bool navManageSuppliers = false;
        public bool navManageCustomers = false;
        public bool navManageMSP = false;

        public bool navAuthorization = false;
        public bool navManageRoleGroups = false;
        public bool navManageUserRoles = false;


        public bool navManageCountry = false;
        public bool navManageIndustry = false;
        public bool navManageDocuments = false;
        public bool navManageQuestions = false;
        public bool navManageVacancyTypes = false;
        public bool navMSPPayPeriod = false;
        public bool navAppointment = false;
        public bool navExpenseSpent = false;
        public bool navManageExpenseSpent = false;
        public bool navTimesheetStatus = false;
        public bool navTimeSheet = false;
        public bool navAddTimeSheet = false;
        public bool navManageTimeSheet = false;

        public bool navPlacement = false;
        public bool navCreatePlacement = false;
        public bool navManagePlacement = false;

        //------------ Administration end ------------- // 

        //------------ Job start ------------- // 

        public bool navJob = false;
        public bool navManageVacancies = false;
        public bool navCreateVacancy = false;

        //------------ Job end ------------- // 

        //------------ candidate start ------------- // 

        public bool navCandidate = false;
        public bool navManageCandidates = false;
        public bool navManageCandidateSubmission = false;
        public bool navCandidateSubmissionListing = false;
        public bool navCreateCandidate = false;

        //------------ candidate end ------------- // 

        //-------------Company start--------------//

        public bool MSPEdit = false;
        public bool MSPUserCreate = false;
        public bool MSPUserEdit = false;
        public bool MSPLBCreate = false;
        public bool MSPLBEdit = false;

        public bool SupplierCreate = false;
        public bool SupplierEdit = false;
        public bool SupplierUserCreate = false;
        public bool SupplierUserEdit = false;
        public bool SupplierLBCreate = false;
        public bool SupplierLBEdit = false;

        public bool CustomerCreate = false;
        public bool CustomerUserCreate = false;
        public bool CustomerLBCreate = false;
        public bool CustomerEdit = false;
        public bool CustomerUserEdit = false;
        public bool CustomerLBEdit = false;


        //-------------Company end------------//


        //-------------Authorization Start------------//

        public bool RoleAuthorizationCreate = false;

        //-------------Authorization end------------//


        //-------------Common Start------------//


        public bool CountryCreate = false;
        public bool CountryEdit = false;
        public bool IndustryCreate = false;
        public bool IndustryEdit = false;
        public bool DocumentCreate = false;
        public bool DocumentEdit = false;
        public bool QuestionCreate = false;
        public bool QuestionEdit = false;
        public bool VacancyTypeCreate = false;
        public bool VacancyTypeEdit = false;

        //-------------Common end------------//

        //-------------JOB Start------------//

        public bool VacancyCreate = false;
        public bool VacancyEdit = false;


        //-------------JOB end------------//

        //-------------Candidate Start------------//

        public bool CandidateCreate = false;
        public bool CandidateEdit = false;
        public bool CandidateSubmiddionCreate = false;
        public bool CandidateSubmiddionEdit = false;


        //-------------Candidate end------------//


        //-------------payperiod------------//

        public bool MSPPayPeriodCreate = false;
        public bool MSPPayPeriodEdit = false;
        public bool AppointmentCreate = false;
        public bool AppointmentEdit = false;
        public bool ExpenseSpentCreate = false;
        public bool ExpenseSpentEdit = false;
        public bool ExpenseSpentApprove = false;
        public bool ExpenseSpentReject = false;
        public bool TimesheetStatusCreate = false;
        public bool TimesheetStatusEdit = false;
        public bool TimesheetCreate = false;
        public bool TimesheetEdit = false;
        public bool TimesheetApprove = false;
        public bool TimesheetReject = false;

        //-------------payperiod end------------//

        //-------------Placement------------//

        public bool PlacementCreate = false;
        public bool PlacementEdit = false;
        public bool PlacementView = false;

        //-------------Placement end------------//




        public UITemplate(List<string> Roles)
        {



            #region Job

            this.navCreateVacancy = Roles.Contains(ApplicationRoles.VacancyFull) || Roles.Contains(ApplicationRoles.VacancyCreate);
            this.navManageVacancies = Roles.Where(a => a.StartsWith("Supplier")).ToList().Count > 0;

            this.navJob = this.navCreateVacancy || this.navManageVacancies;

            #endregion

            #region Candidate

            this.navCreateCandidate = Roles.Contains(ApplicationRoles.CandidateFull) || Roles.Contains(ApplicationRoles.CandidateCreate);
            this.navManageCandidateSubmission = Roles.Where(a => a.StartsWith("CandidateSubmission")).ToList().Count > 0;
            this.navCandidateSubmissionListing = Roles.Where(a => a.StartsWith("CandidateSubmission")).ToList().Count > 0;
            this.navManageCandidates = Roles.Where(a => a.StartsWith("Candidate ")).ToList().Count > 0;
            this.navCandidate = this.navCreateCandidate || this.navManageCandidates || this.navManageCandidateSubmission;

            #endregion

            #region Company

            this.MSPEdit = Roles.Contains(ApplicationRoles.MSPFull);
            this.MSPUserCreate = Roles.Contains(ApplicationRoles.MSPFull) || Roles.Contains(ApplicationRoles.MSPUserCreate) || Roles.Contains(ApplicationRoles.MSPUserFull);
            this.MSPLBCreate = Roles.Contains(ApplicationRoles.MSPFull) || Roles.Contains(ApplicationRoles.MSPLocationBranchCreate) || Roles.Contains(ApplicationRoles.MSPLocationBranchFull);
            this.MSPUserEdit = Roles.Contains(ApplicationRoles.MSPFull) || Roles.Contains(ApplicationRoles.MSPUserCreate) || Roles.Contains(ApplicationRoles.MSPUserFull);
            this.MSPLBEdit = Roles.Contains(ApplicationRoles.MSPFull) || Roles.Contains(ApplicationRoles.MSPLocationBranchCreate) || Roles.Contains(ApplicationRoles.MSPLocationBranchFull);

            this.SupplierCreate = Roles.Contains(ApplicationRoles.SupplierFull) || Roles.Contains(ApplicationRoles.SupplierCreate);
            this.SupplierUserCreate = Roles.Contains(ApplicationRoles.SupplierFull) || Roles.Contains(ApplicationRoles.SupplierUserCreate) || Roles.Contains(ApplicationRoles.SupplierUserFull);
            this.SupplierLBCreate = Roles.Contains(ApplicationRoles.SupplierFull) || Roles.Contains(ApplicationRoles.SupplierLocationBranchCreate) || Roles.Contains(ApplicationRoles.SupplierLocationBranchFull);
            this.SupplierEdit = Roles.Contains(ApplicationRoles.SupplierFull);
            this.SupplierUserEdit = Roles.Contains(ApplicationRoles.SupplierFull) || Roles.Contains(ApplicationRoles.SupplierUserFull);
            this.SupplierLBEdit = Roles.Contains(ApplicationRoles.SupplierFull) || Roles.Contains(ApplicationRoles.SupplierLocationBranchFull);

            this.CustomerCreate = Roles.Contains(ApplicationRoles.CustomerFull) || Roles.Contains(ApplicationRoles.CustomerCreate);
            this.CustomerUserCreate = Roles.Contains(ApplicationRoles.CustomerFull) || Roles.Contains(ApplicationRoles.CustomerUserCreate) || Roles.Contains(ApplicationRoles.CustomerUserFull);
            this.CustomerLBCreate = Roles.Contains(ApplicationRoles.CustomerFull) || Roles.Contains(ApplicationRoles.CustomerLocationBranchCreate) || Roles.Contains(ApplicationRoles.CustomerLocationBranchFull);
            this.CustomerEdit = Roles.Contains(ApplicationRoles.CustomerFull);
            this.CustomerUserEdit = Roles.Contains(ApplicationRoles.CustomerFull) || Roles.Contains(ApplicationRoles.CustomerUserFull);
            this.CustomerLBEdit = Roles.Contains(ApplicationRoles.CustomerFull) || Roles.Contains(ApplicationRoles.CustomerLocationBranchFull);

            #endregion

            #region Authorization

            this.RoleAuthorizationCreate = Roles.Contains(ApplicationRoles.RoleAuthorizationFull) || Roles.Contains(ApplicationRoles.RoleAuthorizationCreate);

            #endregion

            #region Common


            this.CountryEdit = Roles.Contains(ApplicationRoles.CountryFull);
            this.CountryCreate = Roles.Contains(ApplicationRoles.CountryFull) || Roles.Contains(ApplicationRoles.CountryCreate);
            this.IndustryEdit = Roles.Contains(ApplicationRoles.IndustryFull);
            this.IndustryCreate = Roles.Contains(ApplicationRoles.IndustryFull) || Roles.Contains(ApplicationRoles.IndustryCreate);
            this.DocumentCreate = Roles.Contains(ApplicationRoles.DocumentCreate) || Roles.Contains(ApplicationRoles.DocumentFull);
            this.DocumentEdit = Roles.Contains(ApplicationRoles.DocumentFull);
            this.QuestionCreate = Roles.Contains(ApplicationRoles.QuestionCreate) || Roles.Contains(ApplicationRoles.QuestionFull);
            this.QuestionEdit = Roles.Contains(ApplicationRoles.QuestionFull);
            this.VacancyTypeCreate = Roles.Contains(ApplicationRoles.VacancyTypeCreate) || Roles.Contains(ApplicationRoles.VacancyTypeFull);
            this.VacancyTypeEdit = Roles.Contains(ApplicationRoles.VacancyTypeFull);

            #endregion

            this.VacancyCreate = Roles.Contains(ApplicationRoles.VacancyFull) || Roles.Contains(ApplicationRoles.VacancyCreate);
            this.VacancyEdit = Roles.Contains(ApplicationRoles.VacancyFull);

            this.CandidateCreate = Roles.Contains(ApplicationRoles.CandidateFull) || Roles.Contains(ApplicationRoles.CandidateCreate);
            this.CandidateEdit = Roles.Contains(ApplicationRoles.CandidateFull);

            this.CandidateSubmiddionCreate = Roles.Contains(ApplicationRoles.CandidateSubmissionFull) || Roles.Contains(ApplicationRoles.CandidateSubmissionCreate);
            this.CandidateSubmiddionEdit = Roles.Contains(ApplicationRoles.CandidateSubmissionFull);

            this.MSPPayPeriodCreate = Roles.Contains(ApplicationRoles.MSPPayPeriodCreate) || Roles.Contains(ApplicationRoles.MSPPayPeriodFull);
            this.MSPPayPeriodEdit = Roles.Contains(ApplicationRoles.MSPPayPeriodFull);

            this.AppointmentCreate = Roles.Contains(ApplicationRoles.AppointmentCreate) || Roles.Contains(ApplicationRoles.AppointmentFull);
            this.AppointmentEdit = Roles.Contains(ApplicationRoles.AppointmentFull);

            this.ExpenseSpentCreate = Roles.Contains(ApplicationRoles.ExpenseSpentCreate) || Roles.Contains(ApplicationRoles.ExpenseSpentFull);
            this.ExpenseSpentEdit = Roles.Contains(ApplicationRoles.ExpenseSpentFull);
            this.ExpenseSpentApprove = Roles.Contains(ApplicationRoles.ExpenseSpentApprove);
            this.ExpenseSpentReject = Roles.Contains(ApplicationRoles.ExpenseSpentReject);

            this.TimesheetStatusCreate = Roles.Contains(ApplicationRoles.TimesheetStatusCreate) || Roles.Contains(ApplicationRoles.TimesheetStatusFull);
            this.TimesheetStatusEdit = Roles.Contains(ApplicationRoles.TimesheetStatusFull);

            this.TimesheetCreate = Roles.Contains(ApplicationRoles.TimesheetCreate) || Roles.Contains(ApplicationRoles.TimesheetFull);
            this.TimesheetEdit = Roles.Contains(ApplicationRoles.TimesheetFull);
            this.TimesheetApprove = Roles.Contains(ApplicationRoles.TimesheetApprove);
            this.TimesheetReject = Roles.Contains(ApplicationRoles.TimesheetReject);

            this.PlacementCreate = Roles.Contains(ApplicationRoles.PlacementCreate) || Roles.Contains(ApplicationRoles.PlacementFull);
            this.PlacementEdit = Roles.Contains(ApplicationRoles.PlacementFull);


            #region Administration 

            this.navManageVacancyTypes = Roles.Where(a => a.StartsWith("VacancyType")).ToList().Count > 0;
            this.navManageCountry = Roles.Where(a => a.StartsWith("Country")).ToList().Count > 0;
            this.navManageIndustry = Roles.Where(a => a.StartsWith("Industry")).ToList().Count > 0;
            this.navManageDocuments = Roles.Where(a => a.StartsWith("Document")).ToList().Count > 0;
            this.navManageQuestions = Roles.Where(a => a.StartsWith("Question")).ToList().Count > 0;
            this.navMSPPayPeriod = Roles.Where(a => a.StartsWith("MSPPayPeriod")).ToList().Count > 0;
            this.navExpenseSpent = this.ExpenseSpentCreate || this.ExpenseSpentEdit || this.ExpenseSpentApprove || this.ExpenseSpentReject;
            this.navManageExpenseSpent = this.ExpenseSpentEdit || this.ExpenseSpentApprove || this.ExpenseSpentReject;

            this.navTimeSheet = this.TimesheetCreate || this.TimesheetEdit || this.TimesheetApprove || this.TimesheetReject;
            this.navAddTimeSheet = this.TimesheetCreate;
            this.navManageTimeSheet = this.TimesheetEdit || this.TimesheetApprove || this.TimesheetReject;

            this.navPlacement = this.PlacementCreate || this.PlacementEdit;
            this.navCreatePlacement = this.PlacementCreate;
            this.navManagePlacement = this.PlacementEdit;

            this.navManageRoleGroups = Roles.Where(a => a.StartsWith("Role")).ToList().Count > 0;
            this.navManageUserRoles = Roles.Contains(ApplicationRoles.RoleAuthorizationFull) || Roles.Contains(ApplicationRoles.RoleAuthorizationCreate);
            this.navAuthorization = this.navManageRoleGroups || this.navManageUserRoles;


            this.navManageSuppliers = Roles.Where(a => a.StartsWith("Supplier")).ToList().Count > 0;
            this.navManageCustomers = Roles.Where(a => a.StartsWith("Customer")).ToList().Count > 0;
            this.navManageMSP = Roles.Where(a => a.StartsWith("MSP")).ToList().Count > 0;
            this.navCompany = this.navManageSuppliers || this.navManageCustomers || this.navManageMSP;

            this.navAdmistration = this.navManageVacancyTypes || this.navManageCountry || this.navManageIndustry || this.navManageDocuments || this.navManageQuestions || this.navAuthorization || this.navCompany || this.navMSPPayPeriod;
            
            #endregion
        }
    }
}