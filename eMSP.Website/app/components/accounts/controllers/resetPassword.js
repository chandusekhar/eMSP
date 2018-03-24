'use strict';
angular.module('eMSPApp').controller("resetPasswordController", ['$scope', '$http', 'apiCall', 'APP_CONSTANTS', 'toaster', '$state', '$stateParams', function ($scope, $http, apiCall, APP_CONSTANTS, toaster, $state, $stateParams) {
    $(".small-chat-box,.footer,.navbar-default,.border-bottom").hide();
    $("#page-wrapper").css({ margin: "0 0 0 0" });
    $scope.dataJSON = {};
    $scope.dataJSON.UserId = $stateParams.UserId;
    $scope.dataJSON.code = $stateParams.code;

    $scope.submit = function (form) {

        if (form.$valid) {

            var res = apiCall.post(APP_CONSTANTS.URL.ACCOUNT.RESETPASSWORD, $scope.dataJSON);
            res.then(function (data) {
                $scope.dataJSON = data;
                toaster.success({ body: "Your Password has been reset." });
                $state.go("login");
            });


        }
    }
}]);