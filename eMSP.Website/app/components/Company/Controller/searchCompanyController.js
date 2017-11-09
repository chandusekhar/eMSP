'use strict';
angular.module('eMSPApp')
.controller('searchCompanyController', searchCompanyController)
function searchCompanyController($scope, $state, localStorageService, configJSON, APP_CONSTANTS, apiCall, $uibModal, AppCoutries) {// APP_CONSTANTS, apiCall
    $scope.configJSON = configJSON.data;
    $scope.dataJSON = {};
    $scope.searchResults = [];
    $scope.refData = {};
    $scope.dataJSON.companyType = $scope.configJSON.companyType;
    $scope.IsMSP = false;
    $scope.refData.countryList = AppCoutries;

    if ($scope.configJSON.companyType === "MSP") {
        $scope.dataJSON.companyName = "";
        $scope.dataJSON.id = 0;
        $scope.IsMSP = true;
        var apires = apiCall.post(APP_CONSTANTS.URL.COMPANYURL.GETURL, $scope.dataJSON);
        apires.then(function (data) {            
            $scope.res = data;
            localStorageService.set('editCompanyData', data);
            $scope.loadLocations($scope.res.id);
            $scope.loadAllBranches($scope.res.id);            
        });
    } else {
        $scope.dataJSON.companyName = "%";
        var res = apiCall.post(APP_CONSTANTS.URL.COMPANYURL.SEARCHURL, $scope.dataJSON);
        res.then(function (data) {
            $scope.searchResults = data;
        });
    }
    
    $scope.loadLocations = function (compId) {        
        var apires = apiCall.post(APP_CONSTANTS.URL.LOCATION.GETALLLOCATIONSURL, { companyType: $scope.dataJSON.companyType, companyId: compId });
        apires.then(function (data) {
            $scope.resLocations = data;
        });
    }

    $scope.loadAllBranches = function (compId) {
        debugger;
        var apires = apiCall.post(APP_CONSTANTS.URL.BRANCH.GETALLBRANCHESURL, { companyType: $scope.dataJSON.companyType, companyId: compId });
        apires.then(function (data) {
            console.log(data);
            $scope.resBranches = data;
        });
    }

    $scope.loadBranchesByLocation = function (compId, locId) {
        var apires = apiCall.post(APP_CONSTANTS.URL.BRANCH.GETALLBRANCHEBYLOCATIONSURL, { companyType: $scope.dataJSON.companyType, companyId: compId, locationId: locId });
        apires.then(function (data) {
            console.log(data);
            $scope.resBranches = data;
        });
    }

    $scope.edit = function (data) {
        if (data) {

            localStorageService.set('editCompanyData', data);

            $state.go($scope.configJSON.editUrl);
        }

    }
    $scope.view = function (data) {
        if (data) {
            $scope.IsMSP = true;
            $scope.res = data;
            localStorageService.set('editCompanyData', data);
            $scope.loadLocations($scope.res.id);
            $scope.loadAllBranches($scope.res.id);
        }

    }
    $scope.submit = function () {
        if ($scope.form.valid) {

            alert("Form submitted");

            var res = apiCall.post(APP_CONSTANTS.URL.COMPANYURL.SEARCHURL, dataJSON);
        }

    }

    $scope.modelL = function (model) {
        
        $scope.ldataJSON = {};
        if (model) {
            $scope.editform = true;            
            $scope.ldataJSON = model;            
        }
        else {
            $scope.editform = false;            
            $scope.ldataJSON.companyId = $scope.res.id;
            $scope.ldataJSON.companyType = $scope.res.companyType;
            $scope.ldataJSON.companyName = $scope.res.companyName;
        }        

        var modalInstance = $uibModal.open({
            templateUrl: 'app/components/location-branch/view/manageLocation.html',
            scope: $scope,
            controller: 'locationController',
            windowClass: 'animated slideInRight'
        });
    }

    $scope.modalB = function (model) {
        
        $scope.editform = false;

        $scope.bdataJSON = {};
        $scope.bdataJSON.companyId = $scope.res.id;
        $scope.bdataJSON.companyType = $scope.res.companyType;
        $scope.bdataJSON.companyName = $scope.res.companyName;
        $scope.bdataJSON.locationId = model.id;
        $scope.bdataJSON.locationName = model.locationName;

        var modalInstance = $uibModal.open({
            templateUrl: 'app/components/location-branch/view/manageBranch.html',
            scope: $scope,
            controller: 'branchController',
            windowClass: 'animated slideInRight'
        });
    }

    $scope.updateLocation = function (model) {
        model.companyId = $scope.res.id;
        model.companyType = $scope.res.companyType;
        model.companyName = $scope.res.companyName;
        $scope.modelL(model);
    }    

    

    $scope.deleteLocation = function (model) {
        model.companyId = $scope.res.id;
        model.companyType = $scope.res.companyType;
        model.companyName = $scope.res.companyName;
        var res = apiCall.post(APP_CONSTANTS.URL.LOCATION.DELETELOCATIONURL, model);
        res.then(function (data) {            
            alert("Location Removed Successfully");
            $state.reload();
        });
    }
}