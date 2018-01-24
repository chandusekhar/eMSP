'use strict';
angular.module('eMSPApp')
    .controller('searchVacanciesController', searchVacanciesController)
function searchVacanciesController($scope, $state, localStorageService, configJSON, APP_CONSTANTS, apiCall, $uibModal) {// APP_CONSTANTS, apiCall
    $scope.configJSON = configJSON.data;
    $scope.dataJSON = {};
    $scope.searchResults = [];
    $scope.refData = {};
    $scope.dataJSON.mspId = localStorageService.get('editCompanyData') ? localStorageService.get('editCompanyData').id : 0;
    $scope.dataJSON.companyType = $scope.configJSON.companyType;
    $scope.dataJSON.companyName = $scope.configJSON.companyName;

    var apires = apiCall.post(APP_CONSTANTS.URL.VACANCY.GETVACANCIESURL, $scope.dataJSON);
    apires.then(function (data) {
        $scope.resVacancie = data;
    });

    var apiCL = apiCall.post(APP_CONSTANTS.URL.COMPANYURL.SEARCHURL, $scope.dataJSON);
    apiCL.then(function (data) {
        $scope.refData.customerList = data;
    });

    $scope.view = function (data) {
        localStorageService.set('vacancyData', data);
        $state.go($scope.configJSON.manageUrl);
    }

    $scope.edit = function (data) {
        localStorageService.set('vacancyData', data);
        $state.go($scope.configJSON.editUrl);
    }
}

