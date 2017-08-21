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
                     APP: {
                         GETCOUNTRYURL: "api/App/getCountries",
                         GETSTATEURL: "api/App/getStates?Id="
                     }
                 }
             });
