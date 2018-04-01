'use strict';
angular.module('eMSPApp')
    .controller('manageDocumentsController', manageDocumentsController)
function manageDocumentsController($scope, $state, localStorageService, configJSON, APP_CONSTANTS, apiCall, $filter, toaster) {
    $scope.config = localStorageService.get('pageSettings');
    $scope.configJSON = configJSON.data;
    $scope.dataJSON = {};
    $scope.refData = {};
    $scope.documentsList = [];
    $scope.formAction = "Create";
    $scope.refData.submitted = false;

    var resDocuments = apiCall.post(APP_CONSTANTS.URL.VACANCY.GETVACANCYDOCUMENTS);
    resDocuments.then(function (data) {
        $scope.documentsList = data;
    });

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

    $scope.submit = function (form) {
        $scope.refData.submitted = true;
        if (form.$valid) {
            var suc = false;
            if ($scope.formAction == "Update") {
                var res = apiCall.post(APP_CONSTANTS.URL.VACANCY.UPDATECANCYDOCUMENTS, $scope.dataJSON);
                res.then(function (data) {
                    $scope.dataJSON = data;
                    toaster.warning({ body: "Documents Updated Successfully." });
                    $scope.search = true;
                    $state.reload();
                });
            }
            else {
                var res = apiCall.post(APP_CONSTANTS.URL.VACANCY.CREATEVACANCYDOCUMENTS, $scope.dataJSON);
                res.then(function (data) {
                    $scope.dataJSON = data;
                    toaster.success({ body: "Documents Created Successfully." });
                    $scope.documentsList.unshift(data);
                    $scope.search = true;
                });
            }
        }
    }

    $scope.toggleActive = function (model) {
        var res = apiCall.post(APP_CONSTANTS.URL.VACANCY.UPDATECANCYDOCUMENTS, model);
        res.then(function (data) {
            toaster.warning({ body: "Documents Updated Successfully." });
        });
    }

    $scope.reset();
}