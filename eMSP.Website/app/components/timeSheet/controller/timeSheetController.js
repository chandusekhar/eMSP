'use strict';
angular.module('eMSPApp')
    .controller('manageTimeSheetController', manageTimeSheetController)
    .controller('timeSheetController', timeSheetController)
function manageTimeSheetController($scope, $state, $uibModal, localStorageService, configJSON, PayPeriodList, apiCall, APP_CONSTANTS, toaster, $filter) {
    $scope.config = localStorageService.get('pageSettings');
    $scope.configJSON = configJSON.data;
    $scope.dataJSON = {};
    $scope.PayPeriodList = PayPeriodList; 

    $scope.model = function (model, data) {

        $scope.dataJSON = {};

        if (model) {
            $scope.editform = true;
            $scope.dataJSON = data;
            $scope.formAction = "Update";
        }
        else {
            $scope.formAction = "Create";
            $scope.editform = false;
        }

        var modalInstance = $uibModal.open({
            templateUrl: 'app/components/payPeriod/view/payPeriod.html',
            scope: $scope,
            controller: 'payPeriodController',
            windowClass: 'animated slideInRight'
        });
    }
    
}

function timeSheetController($scope, $state, localStorageService, ngAuthSettings, apiCall, APP_CONSTANTS, $http, $uibModalInstance) {

    $scope.config = localStorageService.get('pageSettings');

    if ($scope.editform){
        $scope.dataJSON.dateRange = { startDate: $scope.dataJSON.StartDate, endDate: $scope.dataJSON.EndDate };
    }
  
    $scope.submit = function (form) {


        if (form.$valid) {

            $scope.dataJSON.StartDate = $scope.dataJSON.dateRange.startDate;
            $scope.dataJSON.EndDate = $scope.dataJSON.dateRange.endDate;

            if ($scope.editform) {
                var res = apiCall.post(APP_CONSTANTS.URL.TIMESHEET.UPDATETIMESHEETURL, $scope.dataJSON);
                res.then(function (data) {
                    $scope.dataJSON = data;                   
                    $state.reload();
                });
            }
            else {
                var resn = apiCall.post(APP_CONSTANTS.URL.TIMESHEET.CREATETIMESHEETURL, $scope.dataJSON);
                resn.then(function (data) {
                    $scope.dataJSON = data;
                    $state.reload();
                });
            }          

        }


    }
    
    $scope.close = function () {
        $uibModalInstance.close();
    }
}
