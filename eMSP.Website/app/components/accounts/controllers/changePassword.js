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
}]);