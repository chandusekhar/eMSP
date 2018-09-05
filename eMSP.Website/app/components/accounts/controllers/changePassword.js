'use strict';
angular.module('eMSPApp')
    .controller("changePasswordController", ['$scope', '$http', 'apiCall', 'APP_CONSTANTS', 'toaster', '$state', function ($scope, $http, apiCall, APP_CONSTANTS, toaster, $state) {
        $scope.dataJSON = {};
        $scope.submit = function (form) {

            if (form.$valid) {

                var res = apiCall.post(APP_CONSTANTS.URL.ACCOUNT.CHANGEPASSWORD, $scope.dataJSON);
                res.then(function (data) {
                    $scope.dataJSON = data;
                    toaster.success({ body: "Password changed Successfully." });
                    $state.go("dashboard");
                });


            }
        }
    }]).controller("changeUserNameController", ['$scope', '$http', 'apiCall', 'APP_CONSTANTS', 'toaster', '$state', function ($scope, $http, apiCall, APP_CONSTANTS, toaster, $state) {
        $scope.dataJSON = {};
        $scope.submit = function (form) {

            if (form.$valid) {

                $scope.dataJSON.ConfirmPassword = $scope.dataJSON.Password; 
                var res = apiCall.post(APP_CONSTANTS.URL.ACCOUNT.CHANGEUSERNAME, $scope.dataJSON);
                res.then(function (data) {
                    $scope.dataJSON = data;
                    toaster.success({ body: "User Name changed Successfully." });
                    $state.go("dashboard");
                });


            }
        }
    }]);