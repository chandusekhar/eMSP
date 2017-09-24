'use strict';
angular.module('eMSPApp')
.controller("manageMSPLocationController", ['$scope', '$http', 'configJSON', 'formAction', 'APP_CONSTANTS', 'apiCall', 'AppCoutries',
function ($scope, $http, configJSON, formAction, APP_CONSTANTS, apiCall, AppCoutries) {
    $scope.configJSON = configJSON.data;
    $scope.dataJSON = {};
    $scope.refData = {};
    $scope.refData.countryList = AppCoutries;
    $scope.formAction = formAction;
    $scope.edit = $scope.formAction == "Update" ? true : false;

    $scope.getStateList = function () {
        if ($scope.dataJSON.CountryID) {

            var param = { "Id": $scope.dataJSON.CountryID }
            var apires = apiCall.post(APP_CONSTANTS.URL.APP.GETSTATEURL + $scope.dataJSON.CountryID, {});
            apires.then(function (data) {
                $scope.refData.stateList = data;
            });
        }

    }

    $scope.submit = function () {        
        if ($scope.formLocation.$valid) {
            console.log($scope.formLocation.locationData);
            alert("Form submitted");
        }
    }

    $scope.locationData = {
        LocationName: "",
        StreetLine1: "",
        StreetLine2: "",
        City: "",
        State: "",
        Country: "",
        IsActive: ""
    };

}]);