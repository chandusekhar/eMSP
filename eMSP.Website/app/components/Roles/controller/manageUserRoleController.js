'use strict';
angular.module('eMSPApp')
    .controller("manageUserRoleController", manageUserRoleController)
function manageUserRoleController($scope, localStorageService, configJSON, apiCall, APP_CONSTANTS, toaster, formAction, UserRoles) {
    $scope.config = localStorageService.get('pageSettings');
    $scope.configJSON = configJSON.data;
    $scope.dataJSON = {};
    $scope.refData = {};
    $scope.userList = [];
    $scope.companyTypeList = ["Customer", "Supplier", "MSP"];
    $scope.companyList = [];
    $scope.roleGroupsList = [];
    $scope.refData.submitted = false;
    $scope.formAction = formAction;
    $scope.userRoles = UserRoles;  
    $scope.editUserId = null;
    
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
            if ($scope.editUserId != null) {                
                $scope.userList.filter(function (v) {
                    if (v.userId === $scope.editUserId) {
                        $scope.dataJSON.roleUser = v;
                        $scope.editUserId = null;
                        return;
                    }
                });
                $scope.changeUser($scope.dataJSON.roleUser);
            }
        });
    }  

    $scope.updateRole = function (role) {
        var companyId = 0;
        if (role.MspId > 0) {
            $scope.dataJSON.companyType = "MSP";
            $scope.changeCompanyType("MSP");
            companyId = role.CustomerId;
        }
        else if (role.CustomerId > 0) {
            $scope.dataJSON.companyType = "Customer";
            $scope.changeCompanyType("Customer");
            companyId = role.CustomerId;
        }
        else if (role.SupplierId > 0) {
            $scope.dataJSON.companyType = "Supplier";
            $scope.changeCompanyType("Supplier");
            companyId = role.SupplierId;
        }

        $scope.editUserId = role.UserId;

        $scope.roleGroupsList.filter(function (r) {            
            if (r.id === role.RoleId) {
                $scope.dataJSON.roleGroup = r;
                return;
            }
        });

        var res = apiCall.post(APP_CONSTANTS.URL.COMPANYURL.GETURL, { companyType: $scope.dataJSON.companyType, id: companyId });
        res.then(function (data) {
            $scope.changeCompany(data);
            $scope.dataJSON.companyId = data;
        });
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