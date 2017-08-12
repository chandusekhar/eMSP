'use strict';
angular.module('eMSPApp')
.controller('createCompanyController', createCompanyController)
function createCompanyController($scope, configJSON) {
    $scope.configJSON = configJSON.data;
}