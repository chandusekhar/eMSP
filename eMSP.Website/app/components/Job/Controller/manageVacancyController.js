'use strict';
angular.module('eMSPApp')
    .controller('manageVacancyController', manageVacancyController)
function manageVacancyController($scope, $state, localStorageService, configJSON, APP_CONSTANTS, apiCall, $uibModal, $filter, toaster) {// APP_CONSTANTS, apiCall
    $scope.configJSON = configJSON.data;
    $scope.dataJSON = {};
    $scope.refData = {};
    $scope.vacancyData = localStorageService.get('vacancyData') ? localStorageService.get('vacancyData') : undefined;
    $scope.dataJSON.companyType = $scope.configJSON.companyType;
    $scope.dataJSON.companyName = $scope.configJSON.companyName;

    console.log($scope.vacancyData);

   
    
}