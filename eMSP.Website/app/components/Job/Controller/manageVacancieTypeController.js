'use strict';
angular.module('eMSPApp')
.controller('manageVacancieTypeController', manageVacancieTypeController)
.controller('createVacancieTypeController', createVacancieTypeController);
function manageVacancieTypeController($scope, $state, localStorageService, configJSON, APP_CONSTANTS, apiCall, $uibModal) {// APP_CONSTANTS, apiCall    

    $scope.configJSON = configJSON.data;
    $scope.dataJSON = {};
    $scope.dataJSON.mspId = localStorageService.get('editCompanyData') ? localStorageService.get('editCompanyData').id : 0;
    $scope.edit = false;

    var apires = apiCall.post(APP_CONSTANTS.URL.VACANCY.GETMSPVACANCYTYPEURL, $scope.dataJSON);
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

    $scope.delete = function (data) {
        var res = apiCall.post(APP_CONSTANTS.URL.VACANCY.DELETEMSPVACANCYTYPEURL, data);
        res.then(function (data) {
            alert("Vacancie Type deleted Successfully");
            $state.reload();
        });
    }
}

function createVacancieTypeController($scope, $state, localStorageService, apiCall, APP_CONSTANTS, $http) {
    $scope.configJSON = {};
    $scope.edit = false;
    $scope.formAction = $scope.editform ? "Update" : "Create";

    $http.get("app/components/Job/Config/ManageVacancieType.json").success(function (data) {
        $scope.configJSON = data;
    });

    $scope.submit = function (form) {
        $scope.ltdataJSON.createdUserID = "afcf8230-7878-4e1d-a550-532fd10769ae";
        $scope.ltdataJSON.updatedUserID = "afcf8230-7878-4e1d-a550-532fd10769ae";

        if (form.$valid) {
            if ($scope.editform) {
                var res = apiCall.post(APP_CONSTANTS.URL.VACANCY.UPDATEMSPVACANCYTYPEURL, $scope.ltdataJSON);
                res.then(function (data) {
                    $scope.ltdataJSON = data;
                    alert("Data Updated Successfully");
                });
            }
            else {
                var res = apiCall.post(APP_CONSTANTS.URL.VACANCY.CREATWMSPVACANCYTYPEURL, $scope.ltdataJSON);
                res.then(function (data) {
                    $scope.ltdataJSON = data;
                    alert("Data Created Successfully");
                    $state.reload();
                });
            }
        }
    }

    $scope.reset = function () {
        $state.reload();
    }
}