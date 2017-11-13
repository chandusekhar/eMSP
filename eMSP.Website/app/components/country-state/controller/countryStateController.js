'use strict';
angular.module('eMSPApp')
    .controller('countryStateController', countryStateController)
    .controller('stateController', stateController)
function countryStateController($scope, $state, $uibModal, localStorageService, configJSON, AppCountries, apiCall, APP_CONSTANTS) {
    $scope.configJSON = configJSON.data;
    $scope.dataJSON = {};
    $scope.refData = {};
    $scope.countryList = AppCountries;
    $scope.submit = function (form) {
        if (form.$valid) {
            var suc = false;
            if ($scope.formAction == "Update") {
                var res = apiCall.post(APP_CONSTANTS.URL.COUNTRY.UPDATECOUNTRYURL, $scope.dataJSON);
                res.then(function (data) {
                    $scope.dataJSON = data;
                    alert("Data Updated Successfully");
                    $state.reload();
                });
            }
            else {
                var res = apiCall.post(APP_CONSTANTS.URL.COUNTRY.CREATECOUNTRYURL, $scope.dataJSON);
                res.then(function (data) {
                    $scope.dataJSON = data;
                    alert("Data Created Successfully");
                    $state.reload();
                });
            }





        }

    }
    $scope.create = function () {

        $scope.edit = false;
        $scope.formAction = "Create";
        $scope.search = false;
        $scope.dataJSON = {};
    }
    $scope.reset = function () {
        $scope.edit = false;
        $scope.formAction = "Create";
        $scope.search = true;

    }
    $scope.update = function (model) {
        $scope.edit = true;
        $scope.formAction = "Update";
        $scope.search = false;
        $scope.dataJSON = model;
    }
    $scope.toggleActive = function (model) {

        if (model.countryId) {
            var res = apiCall.post(APP_CONSTANTS.URL.COUNTRY.UPDATESTATEURL, model);
            res.then(function (data) {
                alert("Data Updated Successfully");
            });
        }
        else {
            var res = apiCall.post(APP_CONSTANTS.URL.COUNTRY.UPDATECOUNTRYURL, model);
            res.then(function (data) {
                alert("Data Updated Successfully");

            });
        }


    }
    $scope.loadStates = function (country, test) {
        this.test = true;
        if (!country.stateList) {
            var apires = apiCall.post(APP_CONSTANTS.URL.COUNTRY.GETALLSTATESURL + country.id, { "countryId": country.id });
            apires.then(function (data) {
                country.stateList = data;
            });
        }
    }
    $scope.modal = function (model) {
        if (model.countryId) {
            $scope.editform = true;
            $scope.sdataJSON = model;
        }
        else {
            $scope.editform = false;
            $scope.sdataJSON = {};
            $scope.sdataJSON.countryId = model.id;
        }
        
        var modalInstance = $uibModal.open({
            templateUrl: 'app/components/country-state/view/manageState.html',
            scope: $scope,
            controller: 'stateController'
        });
    }
    $scope.reset();


}
function stateController($scope, $state, $uibModalInstance, $filter,apiCall, APP_CONSTANTS) {

    var rawValue = angular.copy($scope.sdataJSON);

    $scope.submit = function (form) {
        if (form.$valid) {
            var suc = false;
            if ($scope.editform) {
                var res = apiCall.post(APP_CONSTANTS.URL.COUNTRY.UPDATESTATEURL, $scope.sdataJSON);
                res.then(function (data) {
                    $scope.sdataJSON = data;
                    alert("Data Updated Successfully");
                    //$state.reload();
                });
            }
            else {
                var res = apiCall.post(APP_CONSTANTS.URL.COUNTRY.CREATESTATEURL, $scope.sdataJSON);
                res.then(function (data) {
                    $scope.sdataJSON = data;
                    alert("Data Created Successfully");
                    angular.forEach($scope.countryList, function (obj) {
                        if (obj.id == data.countryId) {
                            obj.stateList.push(data);
                        }
                    });
                    //$scope.countryList[0].stateList.push(data);
                    //$state.reload();
                });
            }

            $uibModalInstance.close();



        }

    }    
    $scope.reset = function () {
        
        $state.reload();
    }
}