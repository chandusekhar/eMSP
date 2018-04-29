'use strict';
angular.module('eMSPApp')
    .controller('userProfileController', userProfileController);

function userProfileController($scope, $state, localStorageService, $uibModal, apiCall, ngAuthSettings, APP_CONSTANTS, $http, toaster, dataJSON, AppCoutries) {

    $scope.res = dataJSON;
    $scope.res.userProfilePhotoPathT = ngAuthSettings.contentURL + $scope.res.userProfilePhotoPath;

    $scope.updateUser = function () {
        $scope.udataJSON = {};
        
            $scope.editform = true;
            $scope.udataJSON = $scope.res;
            $scope.formAction = "Update";
            $scope.refData = {};
            $scope.refData.countryList = AppCoutries;


        var modalInstance = $uibModal.open({
            templateUrl: 'app/components/user/view/manageUser.html',
            scope: $scope,
            controller: 'userController',
            windowClass: 'animated slideInRight'
        });
    }



}


