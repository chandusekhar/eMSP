//'use strict';
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
            },
            VACANCY: {
                GETMSPVACANCYTYPEURL: "api/JobVacancie/getMSPVacancyType",
                CREATWMSPVACANCYTYPEURL: "api/JobVacancie/createMSPVacancieType",
                UPDATEMSPVACANCYTYPEURL: "api/JobVacancie/updateMSPVacancieType",
                DELETEMSPVACANCYTYPEURL: "api/JobVacancie/deleteMSPVacancieType",
                GETVACANCYURL: "api/JobVacancie/getVacancy",
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
                UPDATEAPPOINTMENTURL: "api/Appointment/update"
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
                GETROLEGROUPROLESURL: "api/role/GetAllRoleGroupRoles?id=",
                CREATEROLEURL: "api/role/create",
                CREATEROLEGROUPURL: "api/role/createRoleGroup",
                CREATEROLEGROUPROLESURL: "api/role/createRoleGroupRoles",
                ASSIGNUSERROLEURL: "api/role/AssignUserRoles"
            },
            CANDIDATEURL: {
                SEARCHURL: "api/candidate/getAllCandidates",
                GETURL: "api/candidate/getCandidate?candidateId=",
                CREATEURL: "api/candidate/creatCandidate",
                UPDATEURL: "api/candidate/updateCandidate",
                DELETEURL: "api/candidate/deleteCandidate"
            },
            CANDIDATESUBMISSIONURL: {
                GETCANDIDATESTATUS: "api/candidate/getAllCandidateStatus",
                GETURL: "api/candidate/getCandidateSubmission?VacancyId=",
                CREATEURL: "api/candidate/creatCandidateSubmission",
                UPDATEURL: "api/candidate/updateCandidateSubmission"
            },
            ACCOUNT: {
                CHANGEPASSWORD: "api/Account/ChangePassword",
                RESETPASSWORD: "api/Account/SetPassword",
                FORGOTPASSWORD: "api/Account/ForgotPassword?Email="
            },
            DASHBOARD: {
                GETDETAILS: "api/dashboard/msp"
            }

        }
    });
