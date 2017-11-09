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
                         CREATELOCATIONURL: "api/Location/creatLocation",
                         UPDATELOCATIONURL: "api/Location/updateLocation",
                         DELETELOCATIONURL: "api/Location/deleteLocation",
                     },
                     BRANCH: {
                         GETALLBRANCHESURL: "api/Branch/getAllBranches",
                         GETALLBRANCHEBYLOCATIONSURL: "api/Branch/getBranches",
                         GETBRANCHURL: "api/Branch/getBranch",
                         CREATEBRANCHURL: "api/Branch/creatBranch",
                         UPDATEBRANCHURL: "api/Branch/updateBranch",
                         DELETEBRANCHURL: "api/Branch/deleteBranch"
                     },
                     APP: {
                         GETCOUNTRYURL: "api/App/getCountries",
                         GETSTATEURL: "api/App/getStates?Id="
                     }
                 }
             });
