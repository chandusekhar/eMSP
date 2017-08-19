'use strict';
angular.module('eMSPApp')
.controller('createCompanyController', createCompanyController)
function createCompanyController($scope,localStorageService, configJSON, formAction, apiCall) {
    $scope.configJSON = configJSON.data;
    $scope.dataJSON = {};
    $scope.dataJSON.companyType = $scope.configJSON.companyType;
    $scope.edit = false;
   $scope.formAction = formAction;
   if ($scope.formAction == "Update") {
       $scope.edit = true;
       $scope.dataJSON = localStorageService.get('editMSPData');;
   } 


    $scope.submit = function (form) {
        if (form.$valid) {

            alert("Form submitted");

           // var res = apiCall.post("", dataJSON);
        }
        
    }
}