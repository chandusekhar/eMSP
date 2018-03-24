'use strict';
angular.module('eMSPApp').controller("forgotPasswordController", ['$scope', '$http', 'apiCall', 'APP_CONSTANTS', 'toaster', '$state', function ($scope, $http, apiCall, APP_CONSTANTS, toaster, $state) {
    $(".small-chat-box,.footer,.navbar-default,.border-bottom").hide();
    $("#page-wrapper").css({ margin: "0 0 0 0" });
    $scope.dataJSON = {};
    $scope.submit = function (form) {

        if (form.$valid) {

            var res = apiCall.post(APP_CONSTANTS.URL.ACCOUNT.FORGOTPASSWORD + $scope.dataJSON.email, {});
            res.then(function (data) {
                $scope.dataJSON = data;
                toaster.success({ body: "Password reset link has been sent to your registered mail." });
                $state.go("login");
            });


        }
    }
}]);