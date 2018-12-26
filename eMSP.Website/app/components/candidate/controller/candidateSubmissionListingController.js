'use strict';
angular.module('eMSPApp')
    .controller('candidateSubmissionListingController', candidateSubmissionListingController)    
function candidateSubmissionListingController($scope, configJSON, CandidateSubmissionList, DTOptionsBuilder, DTColumnDefBuilder) {
    $scope.configJSON = configJSON.data;
    $scope.dataJSON = {};
    $scope.candidateSubmissionList = CandidateSubmissionList;
    $scope.dtOptions = DTOptionsBuilder.newOptions().withPaginationType('full_numbers');
    console.log(CandidateSubmissionList);
}


