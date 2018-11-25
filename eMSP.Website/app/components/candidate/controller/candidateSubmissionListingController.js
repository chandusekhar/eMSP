'use strict';
angular.module('eMSPApp')
    .controller('candidateSubmissionListingController', candidateSubmissionListingController)    
function candidateSubmissionListingController($scope, configJSON,CandidateSubmissionList) {
    $scope.configJSON = configJSON.data;
    $scope.dataJSON = {};
    $scope.candidateSubmissionList = CandidateSubmissionList;
    console.log(CandidateSubmissionList);
}


