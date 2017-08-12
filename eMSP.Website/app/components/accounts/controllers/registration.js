'use strict';
angular.module('eMSPApp').controller("registrationController", ['$scope', '$http', function ($scope, $http) {
    
    $('.i-checks').iCheck({
        checkboxClass: 'icheckbox_square-green',
        radioClass: 'iradio_square-green',
    });
    
    $(".small-chat-box,.footer,.navbar-default,.border-bottom").hide();
    $("#page-wrapper").css({ margin: "0 0 0 0" });
    

}]);