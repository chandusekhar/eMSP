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
            console.log(data);
            $scope.loadLocations($scope.res.id);
            $scope.loadAllBranches($scope.res.id);   
            $scope.loadUsers($scope.res.id);
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
    $scope.loadUsers = function (compId) {
    
        var apires = apiCall.post(APP_CONSTANTS.URL.USER.GETALLUSERSURL, { companyType: $scope.dataJSON.companyType, id: compId });
        apires.then(function (data) {
            $scope.resUsers = data;
        });
    }

    $scope.edit = function (data) {
        debugger;
        if (data) {

            localStorageService.set('editCompanyData', data);
            debugger;
            $state.go($scope.configJSON.editUrl);
        }

    }
    $scope.view = function (data) {
        debugger;
        if (data) {
            $scope.IsMSP = true;
            $scope.res = data;
            localStorageService.set('editCompanyData', data);
            $scope.loadLocations($scope.res.id);
            $scope.loadAllBranches($scope.res.id);
            $scope.loadUsers($scope.res.id);
        }

    }
    $scope.submit = function () {
        if ($scope.form.valid) {

            alert("Form submitted");

            var res = apiCall.post(APP_CONSTANTS.URL.COMPANYURL.SEARCHURL, dataJSON);
        }

    }

    $scope.modelU = function (model) {

        $scope.udataJSON = {};
        if (model) {
            $scope.editform = true;
            $scope.udataJSON = model.user;
            $scope.formAction = "Update"; 
        }
        else {
            $scope.formAction = "Create"; 
            $scope.editform = false;
            $scope.udataJSON.companyId = $scope.res.id;
            $scope.udataJSON.companyType = $scope.res.companyType;
            $scope.udataJSON.companyName = $scope.res.companyName;
        }

        var modalInstance = $uibModal.open({
            templateUrl: 'app/components/user/view/manageUser.html',
            scope: $scope,
            controller: 'userController',
            windowClass: 'animated slideInRight'
        });
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

    $scope.updateUser = function (model) {
        model.companyId = $scope.res.id;
        model.companyType = $scope.res.companyType;
        model.companyName = $scope.res.companyName;
        $scope.modelU(model);
    }   

    $scope.updateLocation = function (model) {
        model.companyId = $scope.res.id;
        model.companyType = $scope.res.companyType;
        model.companyName = $scope.res.companyName;
        $scope.modelL(model);
    }    

    $scope.ctoggleActive = function (model, isDelete) {

        if (isDelete) {
            model.isDeleted = isDelete;
        }
        model.companyType = $scope.res.companyType;
        var res = apiCall.post(APP_CONSTANTS.URL.USER.UPDATECOMPANYUSER, model);
        res.then(function (data) {
            alert("Completed Successfully");
            $state.reload();
        });
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