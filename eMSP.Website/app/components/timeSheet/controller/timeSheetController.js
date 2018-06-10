'use strict';
angular.module('eMSPApp')
    .controller('timeSheetController', timeSheetController)
    .controller('addHoursController', addHoursController)

function timeSheetController($scope, $state, localStorageService, configJSON, dataJSON, ngAuthSettings, apiCall, APP_CONSTANTS, $http, toaster) {

    $scope.config = localStorageService.get('pageSettings');
    $scope.configJSON = configJSON.data;
    $scope.day = moment();
    $scope.dataJSON = dataJSON ? dataJSON : {};
    $scope.formAction;
    $scope.TimeSheetList = [];


    if ($scope.dataJSON) {
        $scope.editform = true;
        $scope.formAction = "Update";
    } else {
        $scope.formAction = "Create";
        $scope.editform = false;
        $scope.dataJSON.CandidateTimesheetHours = [];
    }



    $scope.submit = function (form) {

        if ($scope.editform) {
            var resn = apiCall.post(APP_CONSTANTS.URL.TIMESHEET.UPDATETIMESHEETURL, $scope.dataJSON);
            resn.then(function (data) {
                $scope.dataJSON = data;
                toaster.warning({ body: "Data updated Successfully." });
                $state.reload();
            });
        }
        else {
            $scope.dataJSON.PayPeriodID = 1;
            $scope.dataJSON.PlacementID = 6;
            $scope.dataJSON.StatusID = 1;
            $scope.dataJSON.VersionNumber = 1;
            var resn = apiCall.post(APP_CONSTANTS.URL.TIMESHEET.CREATETIMESHEETURL, $scope.dataJSON);
            resn.then(function (data) {
                $scope.dataJSON = data;
                toaster.warning({ body: "Data Created Successfully." });
                $state.reload();
            });
        }




    }

    $scope.close = function () {
        $uibModalInstance.close();
    }
}

function addHoursController($scope, $state, localStorageService, ngAuthSettings, apiCall, APP_CONSTANTS, $http, $uibModalInstance) {

    $scope.config = localStorageService.get('pageSettings');



    $scope.submit = function (form) {


        if (form.$valid) {
            if ($scope.dataJSON.ID) {
                $scope.filterFn();
                $uibModalInstance.close();
            }
            else {
                $scope.data.push($scope.dataJSON);
                $scope.filterFn();
                $uibModalInstance.close();
            }
            
        }


    }

    $scope.close = function () {
        $uibModalInstance.close();
    }
}
