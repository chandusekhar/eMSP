'use strict';
angular.module('eMSPApp')
    .controller('manageExpensesController', manageExpensesController)
    .controller('expensesController', expensesController)
function manageExpensesController($scope, $state, $uibModal, localStorageService, configJSON, PayPeriodList, apiCall, APP_CONSTANTS, toaster, $filter, SpendCategoryList, CurrentStatusList, ExpenseList) {
    $scope.config = localStorageService.get('pageSettings');
    $scope.configJSON = configJSON.data;
    $scope.dataJSON = {};
    $scope.dataJSON.Files = [];
    $scope.refData = {};
    $scope.refData.payPeriodList = PayPeriodList; 
    $scope.refData.spendCategoryList = SpendCategoryList;
    $scope.refData.currentStatusList = CurrentStatusList;
    $scope.ExpenseList = ExpenseList; 
    $scope.ExpenseDocument = [];


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
            templateUrl: 'app/components/expenses/view/expenses.html',
            scope: $scope,
            controller: 'expensesController',
            windowClass: 'animated slideInRight'
        });
    }
    
}

function expensesController($scope, $state, localStorageService, ngAuthSettings, apiCall, APP_CONSTANTS, $http, toaster, $uibModalInstance) {

    $scope.config = localStorageService.get('pageSettings');
    
    $scope.dataJSON.PlacementID = 6;//localStorageService.get('PlacementId');
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
                file.FileTypeId = 10007;
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
