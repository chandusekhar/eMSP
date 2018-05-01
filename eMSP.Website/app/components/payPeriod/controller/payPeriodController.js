'use strict';
angular.module('eMSPApp')
    .controller('managePayPeriodController', managePayPeriodController)
    .controller('payPeriodController', payPeriodController)
    
function payPeriodController($scope, $state, $uibModal, localStorageService, configJSON, AppCountries, apiCall, APP_CONSTANTS, toaster, $filter) {
    $scope.config = localStorageService.get('pageSettings');
    $scope.configJSON = configJSON.data;
    $scope.dataJSON = {};
    $scope.refData = {};
    $scope.countryList = AppCountries;
    $scope.refData.submitted = false;

    $scope.submit = function (form) {
        $scope.refData.submitted = true;
        if (form.$valid) {
            var suc = false;
            if ($scope.formAction == "Update") {
                var res = apiCall.post(APP_CONSTANTS.URL.COUNTRY.UPDATECOUNTRYURL, $scope.dataJSON);
                res.then(function (data) {
                    $scope.dataJSON = data;
                    toaster.warning({ body: "Data Updated Successfully." });
                    $scope.search = true;
                });
            }
            else {
                var res = apiCall.post(APP_CONSTANTS.URL.COUNTRY.CREATECOUNTRYURL, $scope.dataJSON);
                res.then(function (data) {
                    $scope.dataJSON = data;
                    toaster.success({ body: "Data Created Successfully." });
                    $scope.countryList.unshift(data);
                    $scope.search = true;
                });
            }
        }
    }

    $scope.create = function () {
        $scope.refData.submitted = false;
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
                toaster.warning({ body: "Data Updated Successfully." });
            });
        }
        else {
            var res = apiCall.post(APP_CONSTANTS.URL.COUNTRY.UPDATECOUNTRYURL, model);
            res.then(function (data) {
                toaster.warning({ body: "Data Updated Successfully." });
            });
        }
    }

    $scope.loadStates = function (country, test) {
        this.test = true;
        if (!country.stateList) {
            var apires = apiCall.post(APP_CONSTANTS.URL.COUNTRY.GETALLSTATESURL + country.id + "& $filter=isDeleted eq false", { "countryId": country.id });
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
function managePayPeriodController($scope, $state, $uibModal, localStorageService, configJSON, AppCountries, apiCall, APP_CONSTANTS, toaster, $filter) {
    $scope.config = localStorageService.get('pageSettings');
    $scope.configJSON = configJSON.data;
    $scope.dataJSON = {};
    $scope.refData = {};
    $scope.countryList = AppCountries;
    $scope.refData.submitted = false;

    $scope.submit = function (form) {
        $scope.refData.submitted = true;
        if (form.$valid) {
            var suc = false;
            if ($scope.formAction == "Update") {
                var res = apiCall.post(APP_CONSTANTS.URL.COUNTRY.UPDATECOUNTRYURL, $scope.dataJSON);
                res.then(function (data) {
                    $scope.dataJSON = data;
                    toaster.warning({ body: "Data Updated Successfully." });
                    $scope.search = true;
                });
            }
            else {
                var res = apiCall.post(APP_CONSTANTS.URL.COUNTRY.CREATECOUNTRYURL, $scope.dataJSON);
                res.then(function (data) {
                    $scope.dataJSON = data;
                    toaster.success({ body: "Data Created Successfully." });
                    $scope.countryList.unshift(data);
                    $scope.search = true;
                });
            }
        }
    }

    $scope.create = function () {
        $scope.refData.submitted = false;
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
                toaster.warning({ body: "Data Updated Successfully." });
            });
        }
        else {
            var res = apiCall.post(APP_CONSTANTS.URL.COUNTRY.UPDATECOUNTRYURL, model);
            res.then(function (data) {
                toaster.warning({ body: "Data Updated Successfully." });
            });
        }
    }

    $scope.loadStates = function (country, test) {
        this.test = true;
        if (!country.stateList) {
            var apires = apiCall.post(APP_CONSTANTS.URL.COUNTRY.GETALLSTATESURL + country.id + "& $filter=isDeleted eq false", { "countryId": country.id });
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
