'use strict';
angular.module('eMSPApp')
.controller('searchCompanyController', searchCompanyController)
function searchCompanyController($scope,localStorageService,configJSON, APP_CONSTANTS, apiCall) {// APP_CONSTANTS, apiCall
    $scope.configJSON = configJSON.data;
    $scope.dataJSON = {};
    $scope.searchResults = [];
    $scope.dataJSON.companyType = $scope.configJSON.companyType;
    $scope.IsMSP = false;
    if ($scope.configJSON.companyType === "MSP") {
        $scope.dataJSON.companyName = "";
        $scope.dataJSON.id = 0;
        $scope.IsMSP = true;
        var apires = apiCall.post(APP_CONSTANTS.URL.COMPANYURL.GETURL, $scope.dataJSON);        
        apires.then(function (data) {
            $scope.res = data;
            localStorageService.set('editMSPData', data);
        });
        
    }
    $scope.submit = function () {
        if ($scope.form.valid) {

            alert("Form submitted");

            var res = apiCall.post(APP_CONSTANTS.URL.COMPANYURL.SEARCHURL, dataJSON);
        }

    }
}