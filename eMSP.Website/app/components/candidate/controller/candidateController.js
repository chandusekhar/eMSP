'use strict';
angular.module('eMSPApp')
    .controller('createCandidateController', createCandidateController)
   
function createCandidateController($scope, $state, localStorageService, apiCall, formAction, AppIndustries, AppCoutries, APP_CONSTANTS, $http, configJSON,) {
    $scope.configJSON = configJSON.data;
    $scope.refData = {};
    $scope.formAction = formAction;
    $scope.edit = $scope.formAction === "Update" ? true : false;
    $scope.refData.countryList = AppCoutries;//$scope.$parent.refData.countryList;
    $scope.refData.industryList = AppIndustries;
    $scope.refData.industrySkillsList = [];
    $scope.dataJSON = {};
    $scope.dataJSON.CandidateFile = [];
    $scope.dataJSON.Candidate = {};
    $scope.dataJSON.Contact = {};

    


    $scope.getStateList = function () {
        if ($scope.dataJSON.Contact && $scope.dataJSON.Contact.CountyID) {
            var param = { "Id": $scope.dataJSON.Contact.CountyID }
            var apires = apiCall.post(APP_CONSTANTS.URL.APP.GETSTATEURL + $scope.dataJSON.Contact.CountyID, {});
            apires.then(function (data) {
                $scope.refData.stateList = data;
            });
        }
    }
    $scope.loadSkills = function () {
        var len = $scope.dataJSON.CandidateIndustries.length;
        var industryId = $scope.dataJSON.CandidateIndustries[len - 1];
        if (industryId && !industryId.skillList) {
            var apires = apiCall.post(APP_CONSTANTS.URL.INDUSTRY.GETALLSKILLSURL + industryId, { "industryId": industryId });
            apires.then(function (data) {
                angular.extend($scope.refData.industrySkillsList, data);
            });
        }
    }

    if ($scope.edit) {
        $scope.dataJSON = localStorageService.get('editCandidateData');
        $scope.dataJSON.Contact = $scope.dataJSON.CandidateContact.length > 0 ? $scope.dataJSON.CandidateContact[0] : {}; 
        $scope.getStateList();
        $scope.loadSkills();
    }
    
    $scope.test = function (index) {
        console.log(index);

      
    }
    $scope.submit = function (form) {
        alert("submit");
        if (!$scope.editform) {
            $scope.dataJSON.SupplierId = 1;            
            $scope.dataJSON.Candidate.Email = $scope.dataJSON.Contact.EmailAddress;
            $scope.dataJSON.Contact.FirstName = $scope.dataJSON.Candidate.FirstName;
            $scope.dataJSON.Contact.LastName = $scope.dataJSON.Candidate.LastName;            
            $scope.dataJSON.CandidateContact = [];
            $scope.dataJSON.CandidateContact.push($scope.dataJSON.Contact);
        }
        if (form.$valid) {
            var suc = false;
            if ($scope.edit) {
                var res = apiCall.post(APP_CONSTANTS.URL.CANDIDATEURL.UPDATEURL, $scope.dataJSON);
                res.then(function (data) {
                    $scope.dataJSON = data;
                    alert("Data Updated Successfully");
                });
            }
            else {
                var res = apiCall.post(APP_CONSTANTS.URL.CANDIDATEURL.CREATEURL, $scope.dataJSON);
                res.then(function (data) {
                    $scope.dataJSON = data;
                    alert("Data Created Successfully");
                    $state.go($scope.configJSON.successURL);
                });
            }
            //$uibModalInstance.close();
        }
    }

    $scope.reset = function () {
        $state.ldataJSON = {};
        //$uibModalInstance.close();
    }

    
    
}

angular.module('eMSPApp')
    .directive('dropZone', [
        function () {


            var config = {
                template: '<label class="drop-zone">' +
                '<input type="file" multiple />' +
                ' <p style="position:relative">Drop files here <span>(or click to upload)</span></p>'+
                //'<div ng-transclude></div>' +       // <= transcluded stuff
                         '</label>'       
                ,
               // transclude: true,
                replace: true,                
                require: '?ngModel',
                link: function (scope, element, attributes, ngModel) {
                    var upload = element[0].querySelector('input');
                    upload.addEventListener('dragover', uploadDragOver, false);
                    upload.addEventListener('drop', uploadFileSelect, false);
                    upload.addEventListener('change', uploadFileSelect, false);
                    config.scope = scope;
                    config.model = ngModel;
                    config.scope.dzfiles = [];
                }
            }
            return config;

            
            // Helper functions
            function uploadDragOver(e) { e.stopPropagation(); e.preventDefault(); e.dataTransfer.dropEffect = 'copy'; }

            function uploadFileSelect(e) {
                console.log(this)
                e.stopPropagation();
                e.preventDefault();
                var files = e.dataTransfer ? e.dataTransfer.files : e.target.files;
                for (var i = 0, file; file = files[i]; ++i) {
                    console.log(file);
                    //config.scope.$apply(function () { config.model.$viewValue.push(file) });
                    uploadFiles(file);
                    var reader = new FileReader();
                    reader.onload = (function (file) {
                        return function (e) {

                            // Data handling (just a basic example):
                            // [object File] produces an empty object on the model
                            // why we copy the properties to an object containing
                            // the Filereader base64 data from e.target.result
                            var data = {
                                data: e.target.result,
                                dataSize: e.target.result.length
                            };
                            for (var p in file) { data[p] = file[p] }

                            
                            config.scope.$apply(function () { config.scope.dzfiles.push(data) })
                           
                        }
                    })(file);
                    
                    reader.readAsDataURL(file);
                }
            }

            // NOW UPLOAD THE FILES.
            function uploadFiles(files) {
                //alert("upload");
                //FILL FormData WITH FILE DETAILS.
                var data = new FormData();

                if (files.length > 0) {
                    for (var i in files) {
                        data.append("uploadedFile", files[i]);
                    }
                }
                else {
                    data.append("uploadedFile", files);
                }

                // ADD LISTENERS.
                var objXhr = new XMLHttpRequest();
                //objXhr.addEventListener("progress", updateProgress, false);
                objXhr.addEventListener("load", transferComplete, false);

                // SEND FILE DETAILS TO THE API.
                objXhr.open("POST", "http://localhost:50001/api/FileUpload/uploadFiles");
                objXhr.send(data);
            }
            

            // CONFIRMATION.
            function transferComplete(e) {
                //alert("Files uploaded successfully.");
                console.log(e);
                var obj = angular.fromJson(e.srcElement.response);
                config.scope.$apply(function () { config.model.$viewValue.push(obj[0]) });
            }
        }
    ])


