'use strict';
angular.module('eMSPApp')
    .controller('userController', userController);

function userController($scope, $state, $uibModal, localStorageService, apiCall, APP_CONSTANTS, $http, $uibModalInstance) {
    $scope.configJSON = {};
    $scope.refData = {};
    
    $scope.edit = $scope.formAction == "Update" ? true : false;
    $scope.refData.countryList = $scope.$parent.refData.countryList;

    $http.get("app/components/user/config/manageUser.json").success(function (data) {
        $scope.configJSON = data;
    });

    $scope.getStateList = function () {

        if ($scope.udataJSON.countryId) {
            var param = { "Id": $scope.udataJSON.countryId }
            var apires = apiCall.post(APP_CONSTANTS.URL.APP.GETSTATEURL + $scope.udataJSON.countryId, {});
            apires.then(function (data) {
                $scope.refData.stateList = data;
            });
        }
    }

    if ($scope.editform) {
        $scope.getStateList();
    }

    $scope.submit = function (form) {

        $scope.udataJSON.createdUserID = "afcf8230-7878-4e1d-a550-532fd10769ae";
        $scope.udataJSON.updatedUserID = "afcf8230-7878-4e1d-a550-532fd10769ae";

        var obj = localStorageService.get('authorizationData');
        if (form.$valid) {
            var suc = false;
            if ($scope.editform) {
                var res = apiCall.post(APP_CONSTANTS.URL.USER.UPDATEUSERURL, $scope.udataJSON);
                res.then(function (data) {
                    $scope.udataJSON = data;
                    alert("Data Updated Successfully");
                });
            }
            else {
                var res = apiCall.post(APP_CONSTANTS.URL.USER.CREATEUSRURL, $scope.udataJSON);
                res.then(function (data) {
                    $scope.udataJSON = data;
                    alert("Data Created Successfully");
                    $state.reload();
                });
            }
            $uibModalInstance.close();
        }
    }

    $scope.close = function () {
        $uibModalInstance.close();
    }

}

angular.module('eMSPApp').directive('toNumber', function () {
    return {
        require: 'ngModel',
        link: function (scope, element, attrs, ngModel) {
            ngModel.$parsers.push(function (val) {
                return parseInt(val, 10);
            });
            ngModel.$formatters.push(function (val) {
                return '' + val;
            });
        }
    }
})

