'use strict';
angular.module('eMSPApp')
    .controller('industrySkilsController', industrySkilsController)
    .controller('skillController', skillController)
function industrySkilsController($scope, $state, localStorageService, $uibModal, configJSON, AppIndustries, apiCall, APP_CONSTANTS) {
    $scope.configJSON = configJSON.data;
    $scope.dataJSON = {};
    $scope.refData = {};
    $scope.industryList = AppIndustries;   

    $scope.submit = function (form) {
        if (form.$valid) {
            var suc = false;
            if ($scope.formAction == "Update") {
                var res = apiCall.post(APP_CONSTANTS.URL.INDUSTRY.UPDATEINDUSTRYURL, $scope.dataJSON);
                res.then(function (data) {
                    alert("Data Updated Successfully");
                    $state.reload();
                });
            }
            else {
                var res = apiCall.post(APP_CONSTANTS.URL.INDUSTRY.CREATEINDUSTRYURL, $scope.dataJSON);
                res.then(function (data) {
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

        if (!model.industryId) {
            var res = apiCall.post(APP_CONSTANTS.URL.INDUSTRY.UPDATEINDUSTRYURL, model);
            res.then(function (data) {
                alert("Data Updated Successfully");
            });
        }
        else {
            var res = apiCall.post(APP_CONSTANTS.URL.INDUSTRY.UPDATESKILLURL, model);
            res.then(function (data) {
                alert("Data Updated Successfully");

            });
        }


    }
    $scope.loadSkills = function (industry, test) {
        this.test = true;
        if (!industry.skillList) {
            var apires = apiCall.post(APP_CONSTANTS.URL.INDUSTRY.GETALLSKILLSURL + industry.id, { "industryId": industry.id });
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
            controller: 'skillController'
        });
    }
    $scope.reset();
}

function skillController($scope, $state, $uibModalInstance, $filter, apiCall, APP_CONSTANTS) {


    $scope.submit = function (form) {
        if (form.$valid) {
            var suc = false;
            if ($scope.editform) {
                var res = apiCall.post(APP_CONSTANTS.URL.INDUSTRY.UPDATESKILLURL, $scope.sdataJSON);
                res.then(function (data) {
                    $scope.sdataJSON = data;
                    alert("Data Updated Successfully");
                });
            }
            else {
                var res = apiCall.post(APP_CONSTANTS.URL.INDUSTRY.CREATESKILLURL, $scope.sdataJSON);
                res.then(function (data) {
                    $scope.sdataJSON = data;
                    alert("Data Created Successfully");
                    angular.forEach($scope.industryList, function (obj) {
                        if (obj.id == data.industryId) {
                            obj.skillList.push(data);
                        }
                    });
                    
                });
            }
            $uibModalInstance.close();
        }

    }
    $scope.reset = function () {

        $state.reload();
    }
}