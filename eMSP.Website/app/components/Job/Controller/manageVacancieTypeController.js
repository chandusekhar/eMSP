'use strict';
angular.module('eMSPApp')
    .controller('manageVacancieTypeController', manageVacancieTypeController)
    .controller('createVacancieTypeController', createVacancieTypeController);
function manageVacancieTypeController($scope, $state, $uibModal, localStorageService, configJSON, APP_CONSTANTS, apiCall, toaster) {// APP_CONSTANTS, apiCall    

    $scope.configJSON = configJSON.data;
    $scope.dataJSON = {};
    $scope.dataJSON.mspId = localStorageService.get('editCompanyData') ? localStorageService.get('editCompanyData').id : 0;
    $scope.edit = false;

    var apires = apiCall.post(APP_CONSTANTS.URL.VACANCY.GETMSPVACANCYTYPEURL + "?$filter=isDeleted eq false", $scope.dataJSON);
    apires.then(function (data) {
        $scope.resMSPVacancieType = data;
    });

    $scope.create = function (model) {

        $scope.ltdataJSON = {};
        if (model) {
            $scope.editform = true;
            $scope.ltdataJSON = model;
        }
        else {
            $scope.editform = false;
            $scope.ltdataJSON.mspId = $scope.dataJSON.mspId;
        }

        var modalInstance = $uibModal.open({
            templateUrl: 'app/components/Job/View/createVacancieType.html',
            scope: $scope,
            controller: 'createVacancieTypeController',
            windowClass: 'animated slideInRight'
        });
    }

    $scope.update = function (data) {
        $scope.create(data);
    }

    $scope.toggleActive = function (model) {
        var res = apiCall.post(APP_CONSTANTS.URL.VACANCY.UPDATEMSPVACANCYTYPEURL, model);
        res.then(function (data) {
            toaster.warning({ body: "Data Updated Successfully." });
        });
    }

    $scope.delete = function (data) {
        var res = apiCall.post(APP_CONSTANTS.URL.VACANCY.DELETEMSPVACANCYTYPEURL, data);
        res.then(function (data) {
            toaster.warning({ body: "Deleted Successfully." });
        });
    }
}

function createVacancieTypeController($scope, apiCall, APP_CONSTANTS, $http, toaster) {
    $scope.configJSON = {};
    $scope.edit = false;
    $scope.formAction = $scope.editform ? "Update" : "Create";
    $scope.submitted = false;

    $http.get("app/components/Job/Config/ManageVacancieType.json").success(function (data) {
        $scope.configJSON = data;
    });

    $scope.submit = function (form) {
        $scope.submitted = true;
        
        if (form.$valid) {
            if ($scope.editform) {
                var res = apiCall.post(APP_CONSTANTS.URL.VACANCY.UPDATEMSPVACANCYTYPEURL, $scope.ltdataJSON);
                res.then(function (data) {
                    $scope.ltdataJSON = data;
                    toaster.warning({ body: "Data Updated Successfully." });
                });
            }
            else {
                var res = apiCall.post(APP_CONSTANTS.URL.VACANCY.CREATWMSPVACANCYTYPEURL, $scope.ltdataJSON);
                res.then(function (data) {
                    $scope.ltdataJSON = data;
                    $scope.resMSPVacancieType.unshift(data);
                    toaster.warning({ body: "Data Created Successfully." });
                });
            }
            //$uibModalInstance.close();
        }
    }
    
    $scope.reset = function () {
        //$uibModalInstance.close();
    }    
}