'use strict';
angular.module('eMSPApp')
.controller('searchCompanyController', searchCompanyController)
function searchCompanyController($scope, configJSON) {
    $scope.configJSON = configJSON.data;
}