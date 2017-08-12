'use strict';
angular.module('eMSPApp').controller("loginController", ['$scope', '$location', 'authService', function ($scope, $location, authService) {
    debugger;
    $scope.loginData = {
        userName: "",
        password: "",
        useRefreshTokens: false
    };

    $scope.message = "";

    $scope.login = function () {
        debugger;
        console.log($scope.loginData);
        alert("Hi");
        authService.login($scope.loginData).then(function (response) {

            $location.path('/dashboard');

        },
         function (err) {
             $scope.message = err.error_description;
         });
    };

    $(".small-chat-box,.footer,.navbar-default,.border-bottom").hide();
    $("#page-wrapper").css({ margin: "0 0 0 0" });


}]);