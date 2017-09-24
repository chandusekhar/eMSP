'use strict';
angular.module('eMSPApp').controller("loginController", ['$scope', '$location', 'authService', function ($scope, $location, authService) {

    $scope.loginData = {
        userName: "",
        password: "",
        useRefreshTokens: false
    };

    $scope.message = "";

    $scope.login = function () {
        console.log($scope.loginData);

        authService.login($scope.loginData).then(function (response) {
            debugger;
            console.log(response);
            $location.path('/dashboard');
        },
         function (err) {
             debugger;
             $scope.message = err.error_description;
         });
    };

    $(".small-chat-box,.footer,.navbar-default,.border-bottom").hide();
    $("#page-wrapper").css({ margin: "0 0 0 0" });


}]);