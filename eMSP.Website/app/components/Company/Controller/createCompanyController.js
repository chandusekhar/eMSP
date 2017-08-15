'use strict';
angular.module('eMSPApp')
.controller('createCompanyController', createCompanyController)
function createCompanyController($scope, configJSON,formAction) {
    $scope.configJSON = configJSON.data;
    $scope.formAction = formAction;
    $scope.edit = $scope.formAction == "Update" ? true : false;

    $scope.submit = function () {
        if ($scope.form.valid) {

            alert("Form submitted");
        }
        
    }
}