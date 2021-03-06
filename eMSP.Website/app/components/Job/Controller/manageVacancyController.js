﻿'use strict';
angular.module('eMSPApp')
    .controller('manageVacancyController', manageVacancyController)
function manageVacancyController($scope, $state, localStorageService, configJSON, APP_CONSTANTS, apiCall, $uibModal, $filter, toaster) {// APP_CONSTANTS, apiCall
    $scope.config = localStorageService.get('pageSettings');
    $scope.configJSON = configJSON.data;
    $scope.dataCommentJSON = {};
    $scope.vacancyData = localStorageService.get('vacancyData') ? localStorageService.get('vacancyData') : undefined;
    

    $scope.submitComments = function () {
        $scope.dataCommentJSON.comment.showToAll = true;
        $scope.dataCommentJSON.vacancyComment = { "vacancyId": $scope.vacancyData.Vacancy.id };
        $scope.dataCommentJSON.commentUser = {};
        var resUpdate = apiCall.post(APP_CONSTANTS.URL.VACANCY.ADDVACANCYCOMMENT, $scope.dataCommentJSON);
        resUpdate.then(function (data) {
            $scope.dataJSON = data;     
            $scope.loadComments();
            $scope.vacancyData.VacancyComment.push(data);
            toaster.success({ body: "Comment added Successfully." });
            $scope.dataCommentJSON = {};
        });
    };

    $scope.loadComments = function () {
        var resVacancyComments = apiCall.post(APP_CONSTANTS.URL.VACANCY.GETVACANCYCOMMENT + $scope.vacancyData.Vacancy.id, { "id": $scope.vacancyData.Vacancy.id });
        resVacancyComments.then(function (data) {
            $scope.vacancyData.VacancyComment = data;
        });
    };

    $scope.loadComments();

    $scope.manageCandidates = function () {
        $state.go($scope.configJSON.candidateAppointment);
    }
}