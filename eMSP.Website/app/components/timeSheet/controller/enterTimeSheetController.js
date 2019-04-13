'use strict';
angular.module('eMSPApp')
    .controller('enterTimeSheetController', enterTimeSheetController)
    .controller('addHoursController', addHoursController)

function enterTimeSheetController($scope, $state, localStorageService, configJSON, apiCall, APP_CONSTANTS, toaster) {

    $scope.config = localStorageService.get('pageSettings');
    $scope.configJSON = configJSON.data;
    $scope.day = moment();
    $scope.startDate = moment(new Date());
    $scope.endDate = moment(new Date());
    $scope.dataJSON = {};
    $scope.companyList = [];
    $scope.placementList = [];
    $scope.payPeriodList = [];
    $scope.compType = localStorageService.get('CurrentUser').companyType;
    $scope.compId = localStorageService.get('CurrentUser').companyId;
    $scope.formAction;
    $scope.TimeSheetList = [];
    $scope.showTimeSheet = false;

    if ($scope.compType == 'MSP') {
        var res = apiCall.post(APP_CONSTANTS.URL.COMPANYURL.SEARCHURL, { "companyType": "Supplier", "companyName": "%" });
        res.then(function (data) {
            $scope.companyList = data;
            $scope.compId = 0;
        });
    }

    $scope.loadPayPeriods = function () {

        var res = apiCall.get(APP_CONSTANTS.URL.TIMESHEET.GETALLPAYPERIODS);
        res.then(function (data) {
            $scope.payPeriodList = data;
        });
    }

    $scope.loadPlacements = function () {

        var res = apiCall.get(APP_CONSTANTS.URL.CANDIDATEURL.GETSUPLIERCANDIDATEPLACEMENTURL + $scope.compId);
        res.then(function (data) {
            $scope.placementList = data;
        });
    }

    $scope.changeCompany = function (model) {

        if (model) {
            $scope.compId = model.id;
        }

        $scope.loadPayPeriods();
        $scope.loadPlacements();
    }

    $scope.changePayperiod = function (model) {

        if (model) {
            $scope.startDate = moment(model.StartDate);
            $scope.endDate = moment(model.EndDate);
            apiCall.get(APP_CONSTANTS.URL.TIMESHEET.GETCANDIDATETIMESHEETS + "PlacementId=" + $scope.dataJSON.PlacementID + "&PayPeriodId=" + $scope.dataJSON.PayPeriodID, {})
                .then(function (data) {

                    if (data) {
                        $scope.dataJSON = data;
                        $scope.editform = true;
                        $scope.formAction = "Update";
                    } else {
                        $scope.formAction = "Create";
                        $scope.editform = false;
                        $scope.dataJSON.CandidateTimesheetHours = [];

                    }
                    $scope.showTimeSheet = true;
                });
        }


    }

    $scope.submit = function (form) {

        if ($scope.editform) {
            var resn = apiCall.post(APP_CONSTANTS.URL.TIMESHEET.UPDATETIMESHEETURL, $scope.dataJSON);
            resn.then(function (data) {
                $scope.dataJSON = data;
                toaster.success({ body: "Data updated Successfully." });
                $state.reload();
            });
        }
        else {
            // $scope.dataJSON.PayPeriodID = 1;
            //  $scope.dataJSON.PlacementID = 6;
            $scope.dataJSON.StatusID = 1;
            $scope.dataJSON.VersionNumber = 1;
            var res = apiCall.post(APP_CONSTANTS.URL.TIMESHEET.CREATETIMESHEETURL, $scope.dataJSON);
            res.then(function (data) {
                $scope.dataJSON = data;
                toaster.success({ body: "Data Created Successfully." });
                $state.reload();
            });
        }




    }

    $scope.close = function () {
        $uibModalInstance.close();
    }
}

function addHoursController($scope, $state, localStorageService, $uibModalInstance) {

    $scope.config = localStorageService.get('pageSettings');



    $scope.submit = function (form) {


        if (form.$valid) {
            if ($scope.dataJSON.ID) {
                $scope.$parent.filterFn();
                $uibModalInstance.close();
            }
            else {
                $scope.$parent.data.push($scope.dataJSON);
                $scope.$parent.filterFn();
                $uibModalInstance.close();
            }

        }


    }

    $scope.close = function () {
        $uibModalInstance.close();
    }
}
