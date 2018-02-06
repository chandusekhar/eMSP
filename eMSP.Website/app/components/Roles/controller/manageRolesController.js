'use strict';
angular.module('eMSPApp')
    .controller("manageRolesController", manageRolesController)
    .controller("createRolesController", createRolesController)
    .controller("createRoleGroupController", createRoleGroupController)
function manageRolesController($scope, $state, localStorageService, $uibModal, configJSON, apiCall, APP_CONSTANTS, toaster) {
    $scope.configJSON = configJSON.data;
    $scope.dataJSON = {};
    $scope.rdataJSON = {};
    $scope.rgdataJSON = {};
    $scope.refData = {};
    $scope.rolesList = [];
    $scope.roleGroupsList = [];
    $scope.refData.submitted = false;

    var apires = apiCall.post(APP_CONSTANTS.URL.ROLE.GETROLESURL);
    apires.then(function (data) {
        $scope.rolesList = data;
    });

    var apires = apiCall.post(APP_CONSTANTS.URL.ROLE.GETALLROLEGROUPURL);
    apires.then(function (data) {
        $scope.roleGroupsList = data;
    });


    $scope.AddRole = function () {
        $scope.refData.submitted = false;

        var roleModalInstance = $uibModal.open({
            templateUrl: 'app/components/Roles/view/createRole.html',
            scope: $scope,
            controller: 'createRolesController',
            windowClass: 'animated slideInRight'
        });
    }

    $scope.AddRoleGroup = function (model) {
        $scope.refData.submitted = false;
        $scope.rgdataJSON = {};
        $scope.editform = false;   
        if (model) {
            $scope.editform = true;   
            $scope.rgdataJSON = model;
        }

        var rgModalInstance = $uibModal.open({
            templateUrl: 'app/components/Roles/view/createRoleGroup.html',
            scope: $scope,
            controller: 'createRoleGroupController',
            windowClass: 'animated slideInRight'
        });
    }

}

//Controller to create Role
function createRolesController($scope, $state, localStorageService, $uibModal, apiCall, APP_CONSTANTS, toaster, $uibModalInstance) {
    
    $scope.submit = function (form) {
        $scope.refData.submitted = true;
        if (form.$valid) {
            var apires = apiCall.post(APP_CONSTANTS.URL.ROLE.CREATEROLEURL, $scope.rdataJSON);
            apires.then(function (data) {
                $scope.rolesList.unshift(data);
                toaster.success({ body: "Role Created Successfully." });
                $scope.close();
            });
        }
    }

    $scope.close = function () {
        $state.rdataJSON = {};
        $uibModalInstance.close();
    }
}

//Controller to create Role Group
function createRoleGroupController($scope, $state, localStorageService, $uibModal, apiCall, APP_CONSTANTS, toaster, $uibModalInstance) {
    console.log($scope.rolesList);
    $scope.rgdataJSON.roleGroup = {};
    $scope.rgdataJSON.roles = [];
    $scope.formAction = $scope.editform ? "Update" : "Create";
    
    $scope.submit = function (form) {
        var isFormValid = false;
        $scope.refData.submitted = true;

        if ($scope.rgdataJSON.roles.length == 0) {
            $scope.isRolesEmpty = true;
            isFormValid = true;
        }
        if (form.$valid && !isFormValid) {
            var apires = apiCall.post(APP_CONSTANTS.URL.ROLE.CREATEROLEGROUPROLESURL, $scope.rgdataJSON);
            apires.then(function (data) {
                $scope.roleGroupsList.unshift(data.roleGroup);
                toaster.success({ body: "Role Group Created Successfully." });
                $scope.close();
            });
        }
    }

    $scope.close = function () {
        $state.rgdataJSON = {};
        $uibModalInstance.close();
    }
}

