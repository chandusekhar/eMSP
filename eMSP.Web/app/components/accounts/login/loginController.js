var eMSPAppControllers = angular.module("eMSPApp.Controllers", []);

eMSPAppControllers.controller("loginController", ['$scope', '$http', function ($scope, $http) {

    $scope.credentials = { username: "", password: ""};
    function login() {
        alert(credentials.username + " " + credentials.password);
        
    };
    
    $(".small-chat-box,.footer,.navbar-default,.border-bottom").hide();
    $("#page-wrapper").css({ margin: "0 0 0 0" });
    

}]);