﻿'use strict';
angular.module('eMSPApp')
    .controller('candidateSubmissionController', candidateSubmissionController)
   
function candidateSubmissionController($scope, $state, $uibModal, localStorageService, configJSON, apiCall, APP_CONSTANTS, toaster, $filter, candidateStatusList, AppIndustries, AppCoutries) {
    $scope.config = localStorageService.get('pageSettings');
    $scope.submitted = false;
    $scope.refData = {};
    $scope.refData.candidateStatusList = candidateStatusList;
    
    $scope.refData.vacancyData = localStorageService.get('vacancyData');
    $scope.refData.submittedCandidate = localStorageService.get('submittedCandidate');
    $scope.edit = $scope.refData.submittedCandidate !== null ? true : false;
    $scope.formAction = $scope.edit ? "Update" : "Create";
    $scope.refData.countryList = AppCoutries;//$scope.$parent.refData.countryList;
    $scope.refData.industryList = AppIndustries;
    $scope.refData.industrySkillsList = [];
    $scope.dataJSON = {};
    $scope.dataJSON.CandidateFile = [];
    $scope.dataJSON.Candidate = {};
    $scope.dataJSON.Contact = {};
    $scope.refData.dataCandidateJSON = {};
    $scope.configJSON = configJSON.data;
    $scope.IsMangePage = $scope.formAction == "Manage" ? true : false;
    $scope.compId = 1;
    $scope.contact = false;
    $scope.resumeUpload = false;
    $scope.docUpload = false;
    $scope.contactEdit = false;
    $scope.CandidateResume = [];
    $scope.CandidateDocs = [];
    $scope.CandidateDocument = {};
    $scope.CandidateDocument.docExpiryDate = null;
    $scope.CandidateDocument.docFileName = "";
    $scope.dataJSON.CandidateContact = [];
    $scope.refData.isNewCustomer = false;
    $scope.refData.isCustomerEdited = false;
    $scope.SubmissionDetails = {}
    
    if ($scope.refData.submittedCandidate !== null) {
        $scope.SubmissionDetails = $scope.refData.submittedCandidate;
    }
    
    var apires = apiCall.post(APP_CONSTANTS.URL.CANDIDATEURL.SEARCHURL + '?SupplierId=' + 1, { 'SupplierId': 1 });
    apires.then(function (data) {
        $scope.refData.customerList = data;
    });

    //Function to load candidates
    if ($scope.IsMangePage) {
        var apires = apiCall.post(APP_CONSTANTS.URL.CANDIDATEURL.SEARCHURL + $scope.compId, { 'SupplierId': $scope.compId });
        apires.then(function (data) {
            $scope.resCandidates = data;
        });
    }

    if ($scope.edit) {        
        $scope.SupplierState = true;
        $scope.dataJSON = localStorageService.get('editCandidateData');
        if ($scope.dataJSON === null) {
            var apiCandidateData = apiCall.post(APP_CONSTANTS.URL.CANDIDATEURL.GETURL + $scope.refData.submittedCandidate.CandidateId, { 'candidateId': $scope.refData.submittedCandidate.CandidateId });
            apiCandidateData.then(function (data) {                
                $scope.loadCandidate(data);
            });
        } else {
            $scope.loadCandidate($scope.dataJSON);
        }
    }

    $scope.getCandidate = function (data) {        
        $scope.refData.isNewCustomer = false;
        var apiCandidateData = apiCall.post(APP_CONSTANTS.URL.CANDIDATEURL.GETURL + data.id, { 'candidateId': data.id });
        apiCandidateData.then(function (data) {
            $scope.loadCandidate(data);
        });
    }

    $scope.loadCandidate = function (data) {
        $scope.dataJSON = data;
        $scope.SubmissionDetails.CandidateId = $scope.dataJSON.Candidate.id;
        $scope.dataJSON.Contact = $scope.dataJSON.CandidateContact.length > 0 ? $scope.dataJSON.CandidateContact[0] : {};
        $scope.getStateList();
        $scope.LoadIndustriesData();
        angular.forEach($scope.dataJSON.CandidateIndustries, function (v, k) {

            var Id = 0;
            if (v.id) {
                Id = v.id;
            }
            else {
                Id = v;
            }
            $scope.loadIndustrySkills(Id);
        });
    }

    $scope.submit = function (form) {   
        
        $scope.submitted = true;
        $scope.CreateIndustriesData();
        $scope.CreateIndustrySkillsData();

        $scope.candidateSubmission = {
            Candidate: $scope.dataJSON,
            CandidateSubmission: $scope.SubmissionDetails,
            Questions: $scope.refData.vacancyData.Questions,
            RequiredDocument: $scope.refData.vacancyData.RequiredDocument,
            IsNewCustomer: false,
            IsCustomerEdited: false
        };
        
        if (form.$valid) {
            var suc = false;
            if ($scope.edit) {
                var resUpdate = apiCall.post(APP_CONSTANTS.URL.CANDIDATESUBMISSIONURL.UPDATEURL, $scope.candidateSubmission);
                resUpdate.then(function (data) { 
                    toaster.warning({ body: "Data Updated Successfully." });
                    $state.go($scope.configJSON.successCandidateSubmissionUrl);
                });
            }
            else {
                var res = apiCall.post(APP_CONSTANTS.URL.CANDIDATESUBMISSIONURL.CREATEURL, $scope.candidateSubmission);
                res.then(function (data) {
                    toaster.success({ body: "Data Created Successfully." });
                    $state.go($scope.configJSON.successCandidateSubmissionUrl);
                });
            }            
        }
    }

    $scope.fnAddContact = function (flag) {
        if (!flag) {
            $scope.dataJSON.Contact = {};
            $scope.contact = true;
        }
        else {

            if ($scope.dataJSON.Contact.IsPrimary == true) {
                $scope.dataJSON.Candidate.Email = $scope.dataJSON.Contact.EmailAddress;
                angular.forEach($scope.dataJSON.CandidateContact, function (con) {
                    con.IsPrimary = false;
                });
            }
            $scope.dataJSON.CandidateContact.push($scope.dataJSON.Contact);

            $scope.contact = false;
        }
    }

    $scope.fneditContact = function (flag, index) {
        if (!flag) {
            $scope.contact = true;
            $scope.contactEdit = true;
            $scope.dataJSON.Contact = angular.copy($scope.dataJSON.CandidateContact[index]);
            $scope.dataJSON.Contact.index = index;
        }
        else {

            if ($scope.dataJSON.Contact.IsPrimary == true) {
                $scope.dataJSON.Candidate.Email = $scope.dataJSON.Contact.EmailAddress;
                angular.forEach($scope.dataJSON.CandidateContact, function (con) {
                    con.IsPrimary = false;
                });
            }
            $scope.dataJSON.CandidateContact[$scope.dataJSON.Contact.index] = $scope.dataJSON.Contact;

            $scope.dataJSON.Contact = {};
            $scope.contactEdit = false;
            $scope.contact = false;
        }
    }

    $scope.fnDocUpload = function (flag) {
        if (!flag) {
            $scope.docUpload = true;
        }
        else {
            angular.forEach($scope.CandidateDocs, function (file) {
                file.FileName = $scope.CandidateDocument.docFileName;
                file.ExpiryDate = new Date($scope.CandidateDocument.docExpiryDate);
                file.FileTypeId = 6;
                $scope.dataJSON.CandidateFile.push(file);
            });
            $scope.CandidateDocs = [];
            $scope.CandidateDocument.docFileName = "";
            $scope.CandidateDocument.docExpiryDate = null;
            $scope.docUpload = false;
        }
    }

    $scope.fnResumeUpload = function (flag) {
        if (!flag) {
            $scope.resumeUpload = true;
        }
        else {
            angular.forEach($scope.CandidateResume, function (file) {

                file.FileTypeId = 2;
                $scope.dataJSON.CandidateFile.push(file);
            });
            $scope.CandidateResume = [];
            $scope.resumeUpload = false;
        }
    }

    $scope.removeFile = function (list, index) {
        list.splice(index, 1);
    }

    $scope.cancel = function () {
        if (!$scope.SupplierState) {
            $scope.IsMangePage = true;
            $scope.edit = false;
        }
        else {
            $state.go("company.searchSuppliers");
        }
    }

    $scope.close = function (flag) {
        if (flag) {
            $scope[flag] = false;
        }
    }


    $scope.getStateList = function () {
        if ($scope.dataJSON.Contact && $scope.dataJSON.Contact.CountyID) {
            var param = { "Id": $scope.dataJSON.Contact.CountyID }
            var apires = apiCall.post(APP_CONSTANTS.URL.APP.GETSTATEURL + $scope.dataJSON.Contact.CountyID, {});
            apires.then(function (data) {
                $scope.refData.stateList = data;
            });
        }
    }

    $scope.loadIndustrySkills = function (industryId) {
        if (industryId && !industryId.skillList) {
            var apires = apiCall.post(APP_CONSTANTS.URL.INDUSTRY.GETALLSKILLSURL + industryId, { "industryId": industryId });
            apires.then(function (data) {
                angular.extend($scope.refData.industrySkillsList, data);
                $scope.LoadIndustrySkillsData();
            });
        }
    }

    $scope.loadSkills = function () {
        var len = $scope.dataJSON.CandidateIndustries.length;
        var industryId = $scope.dataJSON.CandidateIndustries[len - 1];
        if (industryId && !industryId.skillList) {
            $scope.loadIndustrySkills(industryId);
        }
    }

    $scope.LoadIndustriesData = function () {

        angular.forEach($scope.dataJSON.CandidateIndustries, function (v, k) {
            angular.forEach($scope.refData.industryList, function (value, key) {
                if (value.id == v) {
                    $scope.dataJSON.CandidateIndustries[k] = value;
                }
            });
        });
    }

    $scope.CreateIndustriesData = function () {

        angular.forEach($scope.dataJSON.CandidateIndustries, function (v, k) {

            if (v.id) {
                $scope.dataJSON.CandidateIndustries[k] = v.id;
            }
        });
    }

    $scope.LoadIndustrySkillsData = function () {
        angular.forEach($scope.dataJSON.CandidateSkills, function (v, k) {
            angular.forEach($scope.refData.industrySkillsList, function (value, key) {
                if (value.id == v) {
                    $scope.dataJSON.CandidateSkills[k] = value;
                }
            });
        });
    }

    $scope.CreateIndustrySkillsData = function () {

        angular.forEach($scope.dataJSON.CandidateSkills, function (v, k) {

            if (v.id) {
                $scope.dataJSON.CandidateSkills[k] = v.id;
            }
        });
    }

    $scope.toggleView = function () {
        if ($scope.refData.userViewType === "Card") {
            $scope.refData.userViewType = "List";
        } else { $scope.refData.userViewType = "Card"; }
    };

    //Function to load candidates
    if ($scope.IsMangePage) {
        //if()
        var apires = apiCall.post(APP_CONSTANTS.URL.CANDIDATEURL.SEARCHURL + '?SupplierId=' + $scope.compId, { 'SupplierId': $scope.compId });
        apires.then(function (data) {
            $scope.resCandidates = data;
        });
    }

    $scope.editCanditate = function (candidate) {
        $scope.dataJSON = candidate;
        $scope.dataJSON.Contact = $scope.dataJSON.CandidateContact.length > 0 ? $scope.dataJSON.CandidateContact[0] : {};
        $scope.getStateList();
        $scope.LoadIndustriesData();
        angular.forEach($scope.dataJSON.CandidateIndustries, function (v, k) {

            var Id = 0;
            if (v.id) {
                Id = v.id;
            }
            else {
                Id = v;
            }

            $scope.loadIndustrySkills(Id);
        });
        $scope.IsMangePage = false;
        $scope.edit = true;
        $scope.formAction = "Update";
    }

    $scope.$watch('SubmissionDetails.PayRate', function (val) {        
        if (!angular.isUndefined(val)) {
            $scope.SubmissionDetails.BillRate = val + (val * ($scope.refData.vacancyData.Vacancy.payRateMarkUp / 100));
        }
    });    

    $scope.newCustomer = function () {
        $scope.refData.isNewCustomer = true;
        $scope.reset();
    }


    $scope.candidateSubmissionsQuestionsResponse = function (event) {  
        var response = [{
            SubmissionID: 0,
            VacancyQuestionID: event.qus.ID,
            Responses: event.response_qus
        }];
        event.qus.CandidateSubmissionsQuestionsResponse = response;        
    }

    $scope.candidateSubmissionDocumentResponse = function (data, doc) {        
        var docResponse = [];
        data.requiredDocumentResponse.forEach(function (res) {
            var response = {
                CandidateSubmissionID: 0,
                VacancyRequiredDocumentID: doc.ID,
                CandidateFileID: res.ID
            };
            docResponse.push(response);
        });
        doc.CandidateSubmissionDocumentResponse = docResponse;
    }

    $scope.reset = function () {
        $scope.refData.industrySkillsList = [];
        $scope.dataJSON = {};
        $scope.dataJSON.CandidateFile = [];
        $scope.dataJSON.Candidate = {};
        $scope.dataJSON.Contact = {};
        $scope.refData.dataCandidateJSON = {};
        $scope.configJSON = configJSON.data;
        $scope.compId = 1;
        $scope.contact = false;
        $scope.resumeUpload = false;
        $scope.docUpload = false;
        $scope.contactEdit = false;
        $scope.CandidateResume = [];
        $scope.CandidateDocs = [];
        $scope.CandidateDocument = {};
        $scope.CandidateDocument.docExpiryDate = null;
        $scope.CandidateDocument.docFileName = "";
        $scope.dataJSON.CandidateContact = [];
        $scope.submitted = false;
    }
}

