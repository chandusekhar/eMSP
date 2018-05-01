'use strict';
angular.module('eMSPApp')
    .controller('managePayPeriodController', managePayPeriodController)
    .controller('payPeriodController', payPeriodController)
function managePayPeriodController($scope, $state, $uibModal, localStorageService, configJSON, PayPeriodList, apiCall, APP_CONSTANTS, toaster, $filter) {
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

function payPeriodController($scope, $state, localStorageService, ngAuthSettings, apiCall, APP_CONSTANTS, $http, toaster, $uibModalInstance) {

    $scope.config = localStorageService.get('pageSettings');

    if ($scope.editform){
        $scope.dataJSON.dateRange = { startDate: $scope.dataJSON.StartDate, endDate: $scope.dataJSON.EndDate };
    }
  
    $scope.submit = function (form) {


        if (form.$valid) {

            $scope.dataJSON.StartDate = $scope.dataJSON.dateRange.startDate;
            $scope.dataJSON.EndDate = $scope.dataJSON.dateRange.endDate;

            if ($scope.editform) {
                var res = apiCall.post(APP_CONSTANTS.URL.TIMESHEET.UPDATEPAYPERIODURL, $scope.dataJSON);
                res.then(function (data) {
                    $scope.dataJSON = data;                   
                    toaster.warning({ body: "Data Updated Successfully." });
                    $state.reload();
                });
            }
            else {
                var resn = apiCall.post(APP_CONSTANTS.URL.TIMESHEET.CREATEPAYPERIODURL, $scope.dataJSON);
                resn.then(function (data) {
                    $scope.dataJSON = data;
                    toaster.warning({ body: "Data Created Successfully." });                    
                    $state.reload();
                });
            }          

        }


    }
    
    $scope.close = function () {
        $uibModalInstance.close();
    }
}
