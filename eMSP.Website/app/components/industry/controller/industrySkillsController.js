'use strict';
angular.module('eMSPApp')
    .controller('industrySkilsController', industrySkilsController)
    .controller('skillController', skillController)
function industrySkilsController($scope, $state, localStorageService, $uibModal, configJSON, AppIndustries, apiCall, APP_CONSTANTS, toaster) {
    $scope.configJSON = configJSON.data;
    $scope.dataJSON = {};
    $scope.refData = {};
    $scope.industryList = AppIndustries;
    $scope.refData.submitted = false;
    
    $scope.submit = function (form) {
        $scope.refData.submitted = true;
        if (form.$valid) {
            var suc = false;
            if ($scope.formAction === "Update") {
                var resUpdate = apiCall.post(APP_CONSTANTS.URL.INDUSTRY.UPDATEINDUSTRYURL, $scope.dataJSON);
                resUpdate.then(function (data) {
                    toaster.warning({ body: "Data Updated Successfully." });
                    $scope.search = true;
                });
            }
            else {
                var res = apiCall.post(APP_CONSTANTS.URL.INDUSTRY.CREATEINDUSTRYURL, $scope.dataJSON);
                res.then(function (data) {
                    toaster.success({ body: "Data Created Successfully." });
                    $scope.industryList.unshift(data);
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
        $scope.refData.submitted = false;
    }

    $scope.update = function (model) {
        $scope.edit = true;
        $scope.formAction = "Update";
        $scope.search = false;
        $scope.dataJSON = model;
    }

    $scope.toggleActive = function (model) {
        if (!model.industryId) {
            var resUpdate = apiCall.post(APP_CONSTANTS.URL.INDUSTRY.UPDATEINDUSTRYURL, model);
            resUpdate.then(function (data) {
                toaster.warning({ body: "Data Updated Successfully." });
            });
        }
        else {
            var res = apiCall.post(APP_CONSTANTS.URL.INDUSTRY.UPDATESKILLURL, model);
            res.then(function (data) {
                toaster.warning({ body: "Data Updated Successfully." });
            });
        }
    }

    $scope.loadSkills = function (industry, test) {
        this.test = true;
        if (!industry.skillList) {
            var apires = apiCall.post(APP_CONSTANTS.URL.INDUSTRY.GETALLSKILLSURL + industry.id + "&$filter=isDeleted eq false", { "industryId": industry.id });
            apires.then(function (data) {
                industry.skillList = data;
            });
        }
    }

    $scope.modal = function (model) {
        if (model.industryId) {
            $scope.editform = true;
            $scope.sdataJSON = model;
        }
        else {
            $scope.editform = false;
            $scope.sdataJSON = {};
            $scope.sdataJSON.industryId = model.id;
        }

        var modalInstance = $uibModal.open({
            templateUrl: 'app/components/industry/view/manageSkill.html',
            scope: $scope,
            controller: 'skillController',
            windowClass: 'animated slideInRight'
        });
    }
    $scope.reset();
}

function skillController($scope, $state, $uibModalInstance, $filter, apiCall, APP_CONSTANTS, toaster) {

    $scope.submitted = false;
    $scope.submit = function (form) {
        $scope.submitted = true;
        if (form.$valid) {
            var suc = false;
            if ($scope.editform) {
                var resUpdate = apiCall.post(APP_CONSTANTS.URL.INDUSTRY.UPDATESKILLURL, $scope.sdataJSON);
                resUpdate.then(function (data) {
                    $scope.sdataJSON = data;
                    toaster.warning({ body: "Data Updated Successfully." });
                });
            }
            else {
                var res = apiCall.post(APP_CONSTANTS.URL.INDUSTRY.CREATESKILLURL, $scope.sdataJSON);
                res.then(function (data) {
                    $scope.sdataJSON = data;
                    toaster.success({ body: "Data Created Successfully." });
                    angular.forEach($scope.industryList, function (obj) {
                        if (obj.id === data.industryId) {
                            obj.skillList.unshift(data);
                        }
                    });
                });
            }
            $uibModalInstance.close();
        }
    }

    $scope.reset = function () {
        $scope.submitted = false;
        //$state.reload();
        $uibModalInstance.close();
    }
}