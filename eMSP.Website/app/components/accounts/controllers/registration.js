'use strict';
angular.module('eMSPApp').controller("registrationController", ['$scope', '$http', 'mspRegistrationService', function ($scope, $http, mspRegistrationService) {
    

    $scope.regData = {
        companyName: "",
        companyWebsite: "",
        email: "",
        phoneNumber: "",
        address: "",
        city: "",
        state: "",
        country: "",
        password: "",
        agree: false
    };

    $scope.login = function () {

        mspRegistrationService.saveRegistration($scope.regData).then(function (response) {
            $location.path('/dashboard');
        },
         function (err) {
             $scope.message = err.error_description;
         });
    };

    $('.i-checks').iCheck({
        checkboxClass: 'icheckbox_square-green',
        radioClass: 'iradio_square-green',
    });
    
    $(".small-chat-box,.footer,.navbar-default,.border-bottom").hide();
    $("#page-wrapper").css({ margin: "0 0 0 0" });
    

}]);