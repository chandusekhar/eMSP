'use strict';
angular.module('eMSPApp')
.controller('createCompanyController', createCompanyController)
function createCompanyController($scope, configJSON, formAction, apiCall) {
    $scope.configJSON = configJSON.data;
    $scope.dataJSON = {};
    $scope.dataJSON.companyType = $scope.configJSON.companyType;

   $scope.formAction = formAction;
   $scope.edit = $scope.formAction == "Update" ? true : false;

    $scope.submit = function () {
        if ($scope.form.valid) {

            alert("Form submitted");

           // var res = apiCall.post("", dataJSON);
        }
        
    }
}