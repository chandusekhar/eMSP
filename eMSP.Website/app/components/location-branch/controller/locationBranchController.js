'use strict';
angular.module('eMSPApp')
    .controller('locationController', locationController)
    .controller('branchController', branchController);
function locationController($scope, $state, $uibModal, localStorageService, apiCall, APP_CONSTANTS, $http, $uibModalInstance, toaster) {
    $scope.configJSON = {};
    $scope.refData = {};
    $scope.formAction = function () { return "Create"; };
    $scope.edit = $scope.formAction === "Update" ? true : false;
    $scope.refData.countryList = $scope.$parent.refData.countryList;
    $scope.refData.submitted = false;

    $http.get("app/components/location-branch/config/manageLocation.json").success(function (data) {
        $scope.configJSON = data;
    });

    $scope.getStateList = function () {
        if ($scope.ldataJSON.countryId) {
            var param = { "Id": $scope.ldataJSON.countryId }
            var apires = apiCall.post(APP_CONSTANTS.URL.APP.GETSTATEURL + $scope.ldataJSON.countryId , {});
            apires.then(function (data) {
                $scope.refData.stateList = data;
            });
        }
    }

    if ($scope.editform) {
        $scope.getStateList();
    }

    $scope.submit = function (form) {
        $scope.refData.submitted = true;

        if (form.$valid) {            
            var suc = false;
            if ($scope.editform) {
                var res = apiCall.post(APP_CONSTANTS.URL.LOCATION.UPDATELOCATIONURL, $scope.ldataJSON);
                res.then(function (data) {
                    $scope.ldataJSON = data;
                    toaster.warning({ body: "Data Updated Successfully." });
                });
            }
            else {
                var res = apiCall.post(APP_CONSTANTS.URL.LOCATION.CREATELOCATIONURL, $scope.ldataJSON);
                res.then(function (data) {
                    $scope.ldataJSON = data;
                    toaster.success({ body: "Data Created Successfully." });
                    $scope.resLocations.unshift(data);
                });
            }
            $uibModalInstance.close();
        }
    }

    $scope.reset = function () {
        $state.ldataJSON = {};
        $uibModalInstance.close();
    }
}

function branchController($scope, $state, $uibModal, localStorageService, apiCall, APP_CONSTANTS, $http, $uibModalInstance, toaster) {

    //var rawValue = angular.copy($scope.bdataJSON);
    $scope.configJSON = {};
    $scope.refData = {};
    $scope.formAction = function () { return "Create"; };
    $scope.edit = $scope.formAction === "Update" ? true : false;
    $scope.refData.countryList = $scope.$parent.refData.countryList;
    $scope.refData.submitted = false;

    $http.get("app/components/location-branch/config/manageBranch.json").success(function (data) {
        $scope.configJSON = data;
    });

    $scope.getStateList = function () {

        if ($scope.bdataJSON.countryId) {
            var param = { "Id": $scope.bdataJSON.countryId }
            var apires = apiCall.post(APP_CONSTANTS.URL.APP.GETSTATEURL + $scope.bdataJSON.countryId, {});
            apires.then(function (data) {
                $scope.refData.stateList = data;
            });
        }
    }

    if ($scope.editform) {
        $scope.getStateList();
    }

    $scope.submit = function (form) {
        $scope.refData.submitted = true;

        if (form.$valid) {
            var suc = false;
            if ($scope.editform) {
                var res = apiCall.post(APP_CONSTANTS.URL.BRANCH.UPDATEBRANCHURL, $scope.bdataJSON);
                res.then(function (data) {
                    $scope.bdataJSON = data;
                    toaster.warning({ body: "Data Updated Successfully." });
                });
            }
            else {
                var res = apiCall.post(APP_CONSTANTS.URL.BRANCH.CREATEBRANCHURL, $scope.bdataJSON);
                res.then(function (data) {
                    $scope.bdataJSON = data;
                    toaster.success({ body: "Data Created Successfully." });
                    $scope.resBranches.unshift(data);
                });
            }
            $uibModalInstance.close();
        }
    }



    $scope.reset = function () {
        $state.bdataJSON = {};
        $uibModalInstance.close();
    }
}