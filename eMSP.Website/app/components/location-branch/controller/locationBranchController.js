'use strict';
angular.module('eMSPApp')
    .controller('locationController', locationController)
    .controller('branchController', branchController);
function locationController($scope, $state, $uibModal, localStorageService, apiCall, APP_CONSTANTS, $http, $uibModalInstance) {
    $scope.configJSON = {};
    $scope.refData = {};
    $scope.formAction = function () { return "Create"; };
    $scope.edit = $scope.formAction == "Update" ? true : false;
    $scope.refData.countryList = $scope.$parent.refData.countryList;

    $http.get("app/components/location-branch/config/manageLocation.json").success(function (data) {
        $scope.configJSON = data;
    });

    $scope.getStateList = function () {
        debugger;
        if ($scope.ldataJSON.countryId) {
            var param = { "Id": $scope.ldataJSON.countryId }
            var apires = apiCall.post(APP_CONSTANTS.URL.APP.GETSTATEURL + $scope.ldataJSON.countryId, {});
            apires.then(function (data) {
                $scope.refData.stateList = data;
            });
        }
    }

    if ($scope.editform) {
        debugger;
        $scope.getStateList();
    }

    $scope.submit = function (form) {

        $scope.ldataJSON.createdUserID = "afcf8230-7878-4e1d-a550-532fd10769ae";
        $scope.ldataJSON.updatedUserID = "afcf8230-7878-4e1d-a550-532fd10769ae";

        if (form.$valid) {
            var suc = false;
            if ($scope.editform) {
                var res = apiCall.post(APP_CONSTANTS.URL.LOCATION.UPDATELOCATIONURL, $scope.ldataJSON);
                res.then(function (data) {
                    $scope.ldataJSON = data;
                    alert("Data Updated Successfully");
                });
            }
            else {
                var res = apiCall.post(APP_CONSTANTS.URL.LOCATION.CREATELOCATIONURL, $scope.ldataJSON);
                res.then(function (data) {
                    $scope.ldataJSON = data;
                    alert("Data Created Successfully");
                    $state.reload();
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

function branchController($scope, $state, $uibModal, localStorageService, apiCall, APP_CONSTANTS, $http, $uibModalInstance) {
    debugger;
    //var rawValue = angular.copy($scope.bdataJSON);
    $scope.configJSON = {};
    $scope.refData = {};
    $scope.formAction = function () { return "Create"; };
    $scope.edit = $scope.formAction == "Update" ? true : false;
    $scope.refData.countryList = $scope.$parent.refData.countryList;

    $http.get("app/components/location-branch/config/manageBranch.json").success(function (data) {
        $scope.configJSON = data;
    });

    $scope.getStateList = function () {
        debugger;
        console.log($scope.bdataJSON);
        if ($scope.bdataJSON.countryId) {
            var param = { "Id": $scope.bdataJSON.countryId }
            var apires = apiCall.post(APP_CONSTANTS.URL.APP.GETSTATEURL + $scope.bdataJSON.countryId, {});
            apires.then(function (data) {
                $scope.refData.stateList = data;
            });
        }
    }

    if ($scope.editform) {
        debugger;
        $scope.getStateList();
    }

    $scope.submit = function (form) {        
        $scope.bdataJSON.createdUserID = "afcf8230-7878-4e1d-a550-532fd10769ae";
        $scope.bdataJSON.updatedUserID = "afcf8230-7878-4e1d-a550-532fd10769ae";
        if (form.$valid) {
            var suc = false;
            if ($scope.editform) {
                var res = apiCall.post(APP_CONSTANTS.URL.BRANCH.UPDATEBRANCHURL, $scope.bdataJSON);
                res.then(function (data) {
                    $scope.bdataJSON = data;
                    alert("Branch Updated Successfully");
                });
            }
            else {
                var res = apiCall.post(APP_CONSTANTS.URL.BRANCH.CREATEBRANCHURL, $scope.bdataJSON);
                res.then(function (data) {
                    $scope.bdataJSON = data;
                    alert("Branch Created Successfully");
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