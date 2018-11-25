'use strict';
angular.module('eMSPApp')
    .controller("manageRolesController", manageRolesController)
    .controller("createRolesController", createRolesController)
    .controller("createRoleGroupController", createRoleGroupController)
function manageRolesController($scope, $state, localStorageService, $uibModal, configJSON, apiCall, APP_CONSTANTS, toaster) {
    $scope.config = localStorageService.get('pageSettings');
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

    var apires = apiCall.get(APP_CONSTANTS.URL.ROLE.GETALLROLEGROUPROLESURL);
    apires.then(function (data) {
        $scope.roleGroupsList = data;
    });


    $scope.AddRole = function () {
        $scope.refData.submitted = false;
        $scope.rdataJSON.Name = "";
        var roleModalInstance = $uibModal.open({
            templateUrl: 'app/components/Roles/view/createRole.html',
            scope: $scope,
            controller: 'createRolesController',
            windowClass: 'animated slideInRight'
        });
    }

    $scope.deleteRoleGroup = function (model) {
        var apires = apiCall.post(APP_CONSTANTS.URL.ROLE.DELETEROLEGROUPROLESURL, model);
        apires.then(function (data) {
            toaster.success({ body: "Role Group deleted Successfully." });
        }).catch(function (err) { toaster.error({ body: "Role Group is in use, cannot delete it at the moment." }); });
    }

    $scope.AddRoleGroup = function (model) {
        $scope.refData.submitted = false;

        $scope.editform = false;
        if (model) {
            $scope.editform = true;
            $scope.rgdataJSON = model;
        }

        var rgModalInstance = $uibModal.open({
            templateUrl: 'app/components/Roles/view/createRoleGroup.html',
            scope: $scope,
            size: $scope.configJSON.modelSizeLarge,
            controller: 'createRoleGroupController',
            windowClass: 'animated slideInRight',
            resolve: {
                loadPlugin: function ($ocLazyLoad) {
                    return $ocLazyLoad.load([
                        {
                            files: ['css/plugins/iCheck/custom.css', 'js/plugins/iCheck/icheck.min.js']
                        }
                    ]);
                }
            }
        });
    }

}

//Controller to create Role
function createRolesController($scope, $state, localStorageService, $uibModal, apiCall, APP_CONSTANTS, toaster, $uibModalInstance) {
    $scope.config = localStorageService.get('pageSettings');
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
    $scope.config = localStorageService.get('pageSettings');
    $scope.formAction = $scope.editform ? "Update" : "Create";
    $scope.models = {};
    if (!($scope.rgdataJSON.roleGroup && $scope.rgdataJSON.roles)) {
        $scope.rgdataJSON.roleGroup = {};
        $scope.rgdataJSON.roles = [];
    }
    console.log($scope.rgdataJSON.roles);
    console.log($scope.rolesList);
    $scope.checkRoles = function (role) {

        if ($scope.rgdataJSON.roles && role) {
            var res = $scope.rgdataJSON.roles.findIndex(r => r.id == role.id) > -1 ? true : false;
            if (res) {
                $scope.models[role.id] = true;
            }
            return res;
        }
        else {
            return false;
        }
    }

    $scope.submit = function (form) {
        var isFormValid = false;
        $scope.refData.submitted = true;

        if ($scope.rgdataJSON.roles.length == 0) {
            $scope.isRolesEmpty = true;
            isFormValid = true;
        }
        if (form.$valid && !isFormValid) {

            if (!$scope.editform) {
                var apires = apiCall.post(APP_CONSTANTS.URL.ROLE.CREATEROLEGROUPROLESURL, $scope.rgdataJSON);
                apires.then(function (data) {
                    $scope.roleGroupsList.unshift(data);
                    toaster.success({ body: "Role Group Created Successfully." });
                    $scope.close();
                });
            }
            else {
                var apires = apiCall.post(APP_CONSTANTS.URL.ROLE.UPDATEROLEGROUPROLESURL, $scope.rgdataJSON);
                apires.then(function (data) {
                    $scope.roleGroupsList.unshift(data);
                    toaster.success({ body: "Role Group Updated Successfully." });
                    $scope.close();
                });
            }
        }
    }

    $scope.close = function () {
        $state.rgdataJSON = {};
        $uibModalInstance.close();
    }

    $scope.toggleSelection = function toggleSelection(Role) {

        if (Role != 'All') {

            var idx = $scope.rgdataJSON.roles.findIndex(r => r.id == Role.id); 
            // is currently selected
            if (idx > -1) {
                $scope.rgdataJSON.roles.splice(idx, 1);
            }

            // is newly selected
            else {
                $scope.rgdataJSON.roles.push(Role);
            }

        }
        else {

            if ($scope.rgdataJSON.roles.length == $scope.rolesList.length) {
                $scope.rgdataJSON.roles = [];
            }
            else {
                $scope.rgdataJSON.roles = $scope.rolesList;
            }

        }

    };
}

