'use strict';
angular.module('eMSPApp')
    .controller('manageQuestionsController', manageQuestionsController)
function manageQuestionsController($scope, $state, localStorageService, configJSON, APP_CONSTANTS, apiCall, $filter, toaster) {
    $scope.configJSON = configJSON.data;
    $scope.dataJSON = {};
    $scope.refData = {};
    $scope.questionsList = [];
    $scope.formAction = "Create";
    $scope.refData.submitted = false;

    var resQuestions = apiCall.post(APP_CONSTANTS.URL.VACANCY.GETVACANCYQUESTIONS);
    resQuestions.then(function (data) {
        $scope.questionsList = data;
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
            if ($scope.formAction == "Update") {
                var res = apiCall.post(APP_CONSTANTS.URL.VACANCY.UPDATECANCYQUESTIONS, $scope.dataJSON);
                res.then(function (data) {
                    $scope.dataJSON = data;
                    toaster.warning({ body: "Question Updated Successfully." });
                    $scope.search = true;
                    $state.reload();
                });
            }
            else {
                var res = apiCall.post(APP_CONSTANTS.URL.VACANCY.CREATEVACANCYQUESTIONS, $scope.dataJSON);
                res.then(function (data) {
                    $scope.dataJSON = data;
                    toaster.success({ body: "Question Created Successfully." });
                    $scope.questionsList.unshift(data);
                    $scope.search = true;
                });
            }
        }
    }

    $scope.toggleActive = function (model) {
        var res = apiCall.post(APP_CONSTANTS.URL.VACANCY.UPDATECANCYQUESTIONS, model);
        res.then(function (data) {
            toaster.warning({ body: "Question Updated Successfully." });
        });
    }

    $scope.reset();
}