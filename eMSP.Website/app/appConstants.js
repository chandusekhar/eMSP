﻿//'use strict';
angular.module('eMSPApp')
    .value('APP_CONSTANTS',
        {
            URL: {
                COMPANYURL: {
                    SEARCHURL: "api/company/getAllCompanies",
                    GETURL: "api/company/getCompany",
                    CREATEURL: "api/company/creatCompany",
                    UPDATEURL: "api/company/updateCompany",
                    DELETEURL: "api/company/deleteCompany"
                },
                COUNTRY: {
                    GETALLCOUNTRIESURL: "api/Country/getAllCountries",
                    GETCOUNTRYURL: "api/Country/getCountry",
                    GETALLSTATESURL: "api/Country/getAllStates?countryId=",
                    GETSTATEURL: "api/Country/getState",
                    CREATECOUNTRYURL: "api/Country/insertCountry",
                    UPDATECOUNTRYURL: "api/Country/updateCountry",
                    DELETECOUNTRYURL: "api/Country/deleteCountry",
                    CREATESTATEURL: "api/Country/insertState",
                    UPDATESTATEURL: "api/Country/updateState",
                    DELETESTATEURL: "api/Country/deleteState"
                },
                INDUSTRY: {
                    GETALLINDUSTRIESURL: "api/Industry/getAllIndustries",
                    GETINDUSTRYURL: "api/Industry/getIndustry",
                    GETALLSKILLSURL: "api/Industry/getAllSkills?industryId=",
                    GETALLINDUSTRYSKILLSURL: "api/Industry/getAllSkills",
                    GETSKILLURL: "api/Industry/getSkill",
                    CREATEINDUSTRYURL: "api/Industry/insertIndustry",
                    UPDATEINDUSTRYURL: "api/Industry/updateIndustry",
                    DELETEINDUSTRYURL: "api/Industry/deleteIndustry",
                    CREATESKILLURL: "api/Industry/insertIndustrySkill",
                    UPDATESKILLURL: "api/Industry/updateIndustrySkill",
                    DELETESKILLURL: "api/Industry/deleteIndustrySkill"
                },
                LOCATION: {
                    GETALLLOCATIONSURL: "api/Location/getAllLocations",
                    GETLOCATIONURL: "api/Location/getLocation",
                    GETCUSTOMERLOCATIONBRANCHURL: "api/Location/getCustomerLocationBranch",
                    CREATELOCATIONURL: "api/Location/creatLocation",
                    UPDATELOCATIONURL: "api/Location/updateLocation",
                    DELETELOCATIONURL: "api/Location/deleteLocation",
                },
                BRANCH: {
                    GETALLBRANCHESURL: "api/Branch/getAllBranches",
                    GETALLBRANCHEBYLOCATIONSURL: "api/Branch/getBranchesByLocation",
                    GETBRANCHURL: "api/Branch/getBranch",
                    CREATEBRANCHURL: "api/Branch/creatBranch",
                    UPDATEBRANCHURL: "api/Branch/updateBranch",
                    DELETEBRANCHURL: "api/Branch/deleteBranch"
                },
                USER: {
                    GETALLUSERSURL: "api/user/getUsers",
                    GETALLCUSERSURL: "api/user/getAllUsers",
                    GETUSERURL: "api/user/getUser",
                    CREATEUSRURL: "api/user/creatUser",
                    UPDATEUSERURL: "api/user/updateUser",
                    UPDATECOMPANYUSER: "api/user/updateCompanyUser",
                    DELETEUSERURL: "api/user/deleteUser",
                    GETALLACCOUNTUSERSURL: "api/account/AllUsers"
                },
                VACANCY: {
                    GETMSPVACANCYTYPEURL: "api/JobVacancie/getMSPVacancyType",
                    CREATWMSPVACANCYTYPEURL: "api/JobVacancie/createMSPVacancieType",
                    UPDATEMSPVACANCYTYPEURL: "api/JobVacancie/updateMSPVacancieType",
                    DELETEMSPVACANCYTYPEURL: "api/JobVacancie/deleteMSPVacancieType",
                    GETVACANCYURL: "api/JobVacancie/getVacancy?id=",
                    GETVACANCIESURL: "api/JobVacancie/getAllVacancy",
                    CREATEVACANCY: "api/JobVacancie/createVacancy",
                    UPDATEBVACANCY: "api/JobVacancie/updateVacancy",
                    DELETEBVACANCY: "api/JobVacancie/deleteVacancy",
                    ADDVACANCYSKILLS: "api/JobVacancie/addVacancySkill",
                    GETVACANCYSKILLS: "api/JobVacancie/getVacancySkills?id=",
                    UPDATEVACANCYSKILLS: "api/JobVacancie/updateVacancySkill",
                    ADDVACANCYLOCATIONS: "api/JobVacancie/addVacancyLocation",
                    GETVACANCYLOCATIONS: "api/JobVacancie/getVacancyLocations?id=",
                    UPDATEVACANCYLOCATIONS: "api/JobVacancie/updateVacancyLocation",
                    ADDVACANCYSUPPLIER: "api/JobVacancie/addVacancySupplier",
                    GETVACANCYSUPPLIER: "api/JobVacancie/getVacancySupplier?id=",
                    UPDATEVACANCYSUPPLIER: "api/JobVacancie/updateVacancySupplier",
                    ADDVACANCYCOMMENT: "api/JobVacancie/commentVacancy",
                    GETVACANCYCOMMENT: "api/JobVacancie/getVacancyComments?id=",
                    GETVACANCYQUESTIONS: "api/MSPQuestions/get",
                    CREATEVACANCYQUESTIONS: "api/MSPQuestions/save",
                    UPDATECANCYQUESTIONS: "api/MSPQuestions/update",
                    GETVACANCYDOCUMENTS: "api/MSPRequiredDocument/get",
                    CREATEVACANCYDOCUMENTS: "api/MSPRequiredDocument/save",
                    UPDATECANCYDOCUMENTS: "api/MSPRequiredDocument/update",
                    GETJOBVACANCIESSTATUS: "api/JobVacancie/getVacancyStatus"
                },
                APPOINTMENT: {
                    GETALLAPPOINTMENTTYPEURL: "api/Appointment/type/getlist",
                    GETAPPOINTMENTTYPEURL: "api/Appointment/type/get?id=",
                    CREATEAPPOINTMENTTYPEURL: "api/Appointment/type/save",
                    UPDATEAPPOINTMENTTYPEURL: "api/Appointment/type/update",
                    GETALLAPPOINTMENTSTATUSURL: "api/Appointment/status/getlist",
                    GETAPPOINTMENTSTATUSURL: "api/Appointment/type/get?id=",
                    CREATEAPPOINTMENTSTATUSURL: "api/Appointment/type/save",
                    UPDATEAPPOINTMENTSTATUSURL: "api/Appointment/type/update",
                    GETALLAPPOINTMENTURL: "api/Appointment/getlist?id=",
                    GETAPPOINTMENTURL: "api/Appointment/get?id=",
                    CREATEAPPOINTMENTURL: "api/Appointment/save",
                    UPDATEAPPOINTMENTURL: "api/Appointment/update",
                    APPOINTMENTSLOTFINALIZEURL: "api/Appointment/slot/finalize",
                    SLOTUPDATEAPPOINTMENTURL: "api/Appointment/slot/update?id=",
                    SLOTADDAPPOINTMENTURL: "api/Appointment/slot/add",
                    APPOINTMENTUSERADDURL: "api/Appointment/user/add",
                    APPOINTMENTUSERREMOVEURL: "api/Appointment/user/remove",

                },
                APP: {
                    GETCOUNTRYURL: "api/App/getCountries",
                    GETSTATEURL: "api/App/getStates?Id="
                },
                ROLE: {
                    GETROLESURL: "api/role/GetAllRoles",
                    GETUSERROLESURL: "api/role/GetUserRoles",
                    GETROLEGROUPURL: "api/role/GetRoleGroup?id=",
                    GETALLROLEGROUPURL: "api/role/GetAllRoleGroup",
                    GETUSERROLEGROUPS: "api/role/GetUserRoleGroups",
                    GETROLEGROUPROLESURL: "api/role/GetRoleGroupRoles?id=",
                    GETALLROLEGROUPROLESURL: "api/role/GetAllRoleGroupRoles",
                    CREATEROLEURL: "api/role/create",
                    CREATEROLEGROUPURL: "api/role/createRoleGroup",
                    CREATEROLEGROUPROLESURL: "api/role/createRoleGroupRoles",
                    UPDATEROLEGROUPROLESURL: "api/role/updateRoleGroupRoles",
                    DELETEROLEGROUPROLESURL: "api/role/deleteRoleGroupRoles",
                    ASSIGNUSERROLEURL: "api/role/AssignUserRoles"
                },
                CANDIDATEURL: {
                    SEARCHURL: "api/candidate/getAllCandidates",
                    GETURL: "api/candidate/getCandidate?candidateId=",
                    GETSUPLIERCANDIDATEPLACEMENTURL: "api/candidate/getSupplierCandidatePlacementDetails?SuplierId=",
                    CREATEURL: "api/candidate/creatCandidate",
                    UPDATEURL: "api/candidate/updateCandidate",
                    DELETEURL: "api/candidate/deleteCandidate"
                },
                CANDIDATESUBMISSIONURL: {
                    GETCANDIDATESTATUS: "api/candidate/getAllCandidateStatus",
                    GETURL: "api/candidate/getCandidateSubmission?VacancyId=",
                    GETCANDIDATEDETAILSBYSUBBIDURL: "api/candidate/getCandidateDetails?SubmissionId=",
                    CREATEURL: "api/candidate/creatCandidateSubmission",
                    UPDATEURL: "api/candidate/updateCandidateSubmission",
                    GETALLSUBMISSIONURL: "api/candidate/getAllSubmissions"
                },
                ACCOUNT: {
                    CHANGEPASSWORD: "api/Account/ChangePassword",
                    CHANGEUSERNAME: "api/Account/ChangeUserName",
                    CHANGEUSERPASSWORD: "api/Account/ChangeUserPassword",
                    RESETPASSWORD: "api/Account/SetPassword",
                    FORGOTPASSWORD: "api/Account/ForgotPassword?Email="
                },
                DASHBOARD: {
                    GETDETAILS: "api/dashboard/msp"
                },
                TIMESHEET: {
                    GETTIMESHEETSTATUS: "api/timesheet/getTimesheetStatus",
                    GETPAYPERIOD: "api/timesheet/getMSPPayPeriod?id=",
                    GETALLPAYPERIODS: "api/timesheet/getAllMSPPayPeriods",
                    CREATEPAYPERIODURL: "api/timesheet/insertMSPPayPeriod",
                    UPDATEPAYPERIODURL: "api/timesheet/updateMSPPayPeriod",
                    GETCANDIDATETIMESHEETS: "api/timesheet/getCandidateTimesheetDetails?",
                    CREATETIMESHEETURL: "api/timesheet/insertTimeSheet",
                    UPDATETIMESHEETURL: "api/timesheet/updateTimeSheet",
                    GETALLTIMESHEETS: "api/timesheet/getAllTimesheetEntries",

                },
                EXPENSES: {
                    GETSPENDCATEGORY: "api/expenses/getMSPSpendCategory",
                    GETEXPENSE: "api/expenses/getExpenseDetails?ExpenseId=",
                    GETALLEXPENSES: "api/expenses/getCandidateExpenseSpend?PlacementId=",
                    CREATEEXPENSE: "api/expenses/insertCandidateSpend",
                    UPDATEEXPENSE: "api/expenses/updateCandidateSpend"
                },
                PLACEMENT: {
                    CREATEPLACEMENT: "api/candidate/creatCandidatePlacement",
                    GETPLACEMENTBYCANDIDATEID: "api/candidate/getPlacementByCandidateId?CandidateId=",
                    GETALLPLACEDCANDIDATES: "api/candidate/getAllPlacedCandidates",
                    UPDATECANDIDATEPLACEMENT:"api/candidate/updateCandidatePlacement"
                },
                MSPTIMEGROUP: {
                    GETMSPALLTIMEGROUP:"api/MSPTimeGroup/getAllMSPTimeGroup"
                }
            }
        });