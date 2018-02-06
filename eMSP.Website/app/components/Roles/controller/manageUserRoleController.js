'use strict';
angular.module('eMSPApp')
    .controller("manageUserRoleController", manageUserRoleController)
function manageUserRoleController($scope, $state, localStorageService, configJSON, apiCall, APP_CONSTANTS, toaster, formAction) {
    $scope.configJSON = configJSON.data;
    $scope.dataJSON = {};    
    $scope.refData = {};
    $scope.userList = [];
    $scope.rolesList = [];
    $scope.roleGroupsList = [];
    $scope.refData.submitted = false;

    var apires = apiCall.post(APP_CONSTANTS.URL.USER.GETALLUSERSURL, { companyType: $scope.configJSON.companyType, id: 1 });
    apires.then(function (data) {
        $scope.userList = data;
    });
    
    var apires = apiCall.post(APP_CONSTANTS.URL.ROLE.GETALLROLEGROUPURL);
    apires.then(function (data) {
        $scope.roleGroupsList = data;
    });

    $scope.getGroupRoles = function (model) {
        var apires = apiCall.post(APP_CONSTANTS.URL.ROLE.GETROLEGROUPROLESURL + model.id, { "id": model.id });
        apires.then(function (data) {
            $scope.rolesList = data;
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
    }
}