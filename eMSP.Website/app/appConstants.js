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
                GETUSERURL: "api/user/getUser",
                CREATEUSRURL: "api/user/creatUser",
                UPDATEUSERURL: "api/user/updateUser",
                UPDATECOMPANYUSER: "api/user/updateCompanyUser",
                DELETEUSERURL: "api/user/deleteUser",
            },
            VACANCY: {
                GETMSPVACANCYTYPEURL: "api/JobVacancie/getMSPVacancyType",
                GETACTIVEMSPVACANCYTYPEURL: "api/JobVacancie/getActiveMSPVacancyType",
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
                UPDATEVACANCYSUPPLIER: "api/JobVacancie/updateVacancySupplier"
            },
            APP: {
                GETCOUNTRYURL: "api/App/getCountries",
                GETSTATEURL: "api/App/getStates?Id="
            },
            CANDIDATEURL: {
                SEARCHURL: "api/candidate/getAllCandidates",
                GETURL: "api/candidate/getCandidate",
                CREATEURL: "api/candidate/creatCandidate",
                UPDATEURL: "api/candidate/updateCandidate",
                DELETEURL: "api/candidate/deleteCandidate"
            },
            CANDIDATESUBMISSIONURL: {
                
                GETURL: "api/candidate/getCandidateSubmission",
                CREATEURL: "api/candidate/creatCandidateSubmission",
                UPDATEURL: "api/candidate/updateCandidateSubmission"
            }
        }
    });
