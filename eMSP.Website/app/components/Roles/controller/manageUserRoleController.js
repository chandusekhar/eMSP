'use strict';
angular.module('eMSPApp')
    .controller("manageUserRoleController", manageUserRoleController)
function manageUserRoleController($scope, $state, localStorageService, configJSON, apiCall, APP_CONSTANTS, toaster, formAction) {
    $scope.configJSON = configJSON.data;
    $scope.dataJSON = {};
    $scope.refData = {};
    $scope.userList = [];
    $scope.roleGroupsList = [];
    $scope.refData.submitted = false;
    $scope.formAction = formAction;

    $scope.CUser = localStorageService.get('CurrentUser');

    var apires = apiCall.post(APP_CONSTANTS.URL.USER.GETALLUSERSURL, { companyType: $scope.CUser.companyType, id: $scope.CUser.companyId });
    apires.then(function (data) {
        $scope.userList = data;
    });

    var apiresroles = apiCall.post(APP_CONSTANTS.URL.ROLE.GETALLROLEGROUPURL);
    apiresroles.then(function (data) {
        $scope.roleGroupsList = data;
    });

    $scope.changeUser = function (model) {
        $scope.dataJSON.user = model.user;        
    }

    //Function to assign Role to user
    $scope.submit = function (form) {
        $scope.dataJSON.user.roleGroupId = $scope.dataJSON.roleGroup.id;
        $scope.refData.submitted = false;

        if (form.$valid) {
            var apires = apiCall.post(APP_CONSTANTS.URL.ROLE.ASSIGNUSERROLEURL, $scope.dataJSON);
            apires.then(function (data) {
                toaster.success({ body: "Role Assigned Successfully." });                
            });
        }
    }
}