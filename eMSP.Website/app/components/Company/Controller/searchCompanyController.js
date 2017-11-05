'use strict';
angular.module('eMSPApp')
.controller('searchCompanyController', searchCompanyController)
function searchCompanyController($scope, $state, localStorageService, configJSON, APP_CONSTANTS, apiCall) {// APP_CONSTANTS, apiCall
    $scope.configJSON = configJSON.data;
    $scope.dataJSON = {};
    $scope.searchResults = [];
    $scope.dataJSON.companyType = $scope.configJSON.companyType;
    $scope.IsMSP = false;
    if ($scope.configJSON.companyType === "MSP") {
        //debugger;
        $scope.dataJSON.companyName = "";
        $scope.dataJSON.id = 0;
        $scope.IsMSP = true;
       // debugger;
        var apires = apiCall.post(APP_CONSTANTS.URL.COMPANYURL.GETURL, $scope.dataJSON);
        apires.then(function (data) {
            $scope.res = data;
            localStorageService.set('editCompanyData', data);
        });

    } else {
        $scope.dataJSON.companyName = "%";
        var res = apiCall.post(APP_CONSTANTS.URL.COMPANYURL.SEARCHURL, $scope.dataJSON);
        res.then(function (data) {
            $scope.searchResults = data;
        });
    }
    $scope.edit = function (data) {
        if (data) {

            localStorageService.set('editCompanyData', data);

            $state.go($scope.configJSON.editUrl);
        }

    }
    $scope.view = function (data) {
        if (data) {
            $scope.IsMSP = true;
            $scope.res = data;
            localStorageService.set('editCompanyData', data);
        }

    }
    $scope.submit = function () {
        if ($scope.form.valid) {

            alert("Form submitted");

            var res = apiCall.post(APP_CONSTANTS.URL.COMPANYURL.SEARCHURL, dataJSON);
        }

    }
}