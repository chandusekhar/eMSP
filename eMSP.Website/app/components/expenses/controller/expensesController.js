'use strict';
angular.module('eMSPApp')
    .controller('manageExpensesController', manageExpensesController)
    .controller('expensesController', expensesController)
function manageExpensesController($scope, $uibModal, localStorageService, configJSON, PayPeriodList, apiCall, APP_CONSTANTS, SpendCategoryList, CurrentStatusList, DTOptionsBuilder) {
    $scope.config = localStorageService.get('pageSettings');
    $scope.configJSON = configJSON.data;
    $scope.dataJSON = {};
    $scope.dataJSON.Files = [];
    $scope.refData = {};
    $scope.companyList = [];
    $scope.placementList = [];
    $scope.payPeriodList = [];
    $scope.compType = localStorageService.get('CurrentUser').companyType;
    $scope.compId = localStorageService.get('CurrentUser').companyId;
    $scope.refData.payPeriodList = PayPeriodList;
    $scope.refData.spendCategoryList = SpendCategoryList;
    $scope.refData.currentStatusList = CurrentStatusList;
    $scope.ExpenseList = [];
    $scope.ExpenseDocument = [];
    $scope.dtOptions = DTOptionsBuilder.newOptions().withPaginationType('full_numbers');

    $scope.loadPlacements = function () {

        var res = apiCall.get(APP_CONSTANTS.URL.CANDIDATEURL.GETSUPLIERCANDIDATEPLACEMENTURL + $scope.compId);
        res.then(function (data) {
            $scope.placementList = data;
        });
    }

    if ($scope.compType === 'MSP') {
        var res = apiCall.post(APP_CONSTANTS.URL.COMPANYURL.SEARCHURL, { "companyType": "Supplier", "companyName": "%" });
        res.then(function (data) {
            $scope.companyList = data;
            $scope.compId = 0;
        });
    }
    else if ($scope.compType === 'Supplier') {
        $scope.loadPlacements();

    }
    else {
        $scope.dataJSON.PlacementID = 1;
        $scope.loadPlacements();
    }

    $scope.changeCompany = function (model) {

        if (model) {
            $scope.compId = model.id;
        }
        $scope.loadPlacements();
    }

    

    $scope.changePlacement = function () {

        if ($scope.dataJSON.PlacementID) {
            var res = apiCall.post(APP_CONSTANTS.URL.EXPENSES.GETALLEXPENSES + $scope.dataJSON.PlacementID, {})
            res.then(function (data) {
                $scope.ExpenseList = data;
            });

        }
    }

    $scope.model = function (model, data) {        

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
            templateUrl: 'app/components/expenses/view/expenses.html',
            scope: $scope,
            controller: 'expensesController',
            windowClass: 'animated slideInRight'
        });
    }

}

function expensesController($scope, $state, localStorageService, ngAuthSettings, apiCall, APP_CONSTANTS, $http, toaster, $uibModalInstance) {

    $scope.config = localStorageService.get('pageSettings');

    //$scope.dataJSON.PlacementID = 1;//localStorageService.get('PlacementId');
    if ($scope.editform) {

        $scope.dataJSON.PayPeriodID = $scope.dataJSON.PayPeriodID.toString();

        $scope.dataJSON.SpendCategoryID = $scope.dataJSON.SpendCategoryID.toString();

        $scope.dataJSON.CurrentStatusID = $scope.dataJSON.CurrentStatusID.toString();
    }
    $scope.removeFile = function (list, index) {

        list.splice(index, 1);
    }
    $scope.fnExpenseDocumentUpload = function (flag) {


        if (!flag) {

            $scope.expenseDocumentUpload = true;
        }
        else {
            angular.forEach($scope.ExpenseDocument, function (file) {
                file.FileTypeId = 6;
                $scope.dataJSON.Files.push(file);
            });
            $scope.ExpenseDocument = [];
            console.log($scope.dataJSON.Files);
            $scope.expenseDocumentUpload = false;
        }
    }

    $scope.submit = function (form) {


        if (form.$valid) {

            if ($scope.editform) {
                var res = apiCall.post(APP_CONSTANTS.URL.EXPENSES.UPDATEEXPENSE, $scope.dataJSON);
                res.then(function (data) {
                    $scope.dataJSON = data;
                    toaster.warning({ body: "Data Updated Successfully." });
                    $state.reload();
                });
            }
            else {
                var resn = apiCall.post(APP_CONSTANTS.URL.EXPENSES.CREATEEXPENSE, $scope.dataJSON);
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
