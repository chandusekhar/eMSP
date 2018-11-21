'use strict';
angular.module('eMSPApp')
    .controller("changeUserPasswordController", changeUserPasswordController)
function changeUserPasswordController($scope, $state, localStorageService, configJSON, apiCall, APP_CONSTANTS, toaster, formAction) {
    $scope.config = localStorageService.get('pageSettings');
    $scope.configJSON = configJSON.data;
    $scope.dataJSON = $scope.dataJSON ? $scope.dataJSON : {};
    $scope.dataJSON.model = {};
    $scope.refData = {};
    $scope.userList = [];
    $scope.companyTypeList = ["Customer", "Supplier", "MSP"];
    $scope.companyList = [];
    $scope.roleGroupsList = [];
    $scope.refData.submitted = false;
    $scope.formAction = formAction;

    $scope.CUser = localStorageService.get('CurrentUser');    

    var apiresroles = apiCall.post(APP_CONSTANTS.URL.ROLE.GETALLROLEGROUPURL);
    apiresroles.then(function (data) {
        $scope.roleGroupsList = data;
    });

    $scope.changeUser = function (model) {
        $scope.dataJSON.user = model.user;        
    }

    $scope.changeCompanyType = function (model) {

        if (model != "MSP") {
            var res = apiCall.post(APP_CONSTANTS.URL.COMPANYURL.SEARCHURL, { companyType: model, companyName: "%" });
            res.then(function (data) {
                $scope.companyList = data;
            });
        }
        else {
            var res = apiCall.post(APP_CONSTANTS.URL.COMPANYURL.GETURL, { companyType: model, companyName: "" });
            res.then(function (data) {
                $scope.companyList.push(data);  
            });
        }

    }

    $scope.changeCompany = function (model) {

        var apires = apiCall.post(APP_CONSTANTS.URL.USER.GETALLUSERSURL, { companyType: model.companyType, id: model.id });
        apires.then(function (data) {
            $scope.userList = data;
        });

    }

    //Function to assign Role to user
    $scope.submit = function (form) {
        $scope.dataJSON.model.Email = $scope.dataJSON.user.emailAddress;
        $scope.refData.submitted = false;

        if (form.$valid) {
            var apires = apiCall.post(APP_CONSTANTS.URL.ACCOUNT.CHANGEUSERPASSWORD, $scope.dataJSON.model);
            apires.then(function (data) {
                toaster.success({ body: "User Name & Password changed Successfully." });
                $state.reload();
            });
        }
    }
}