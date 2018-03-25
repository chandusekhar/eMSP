'use strict';
angular.module('eMSPApp')
    .controller('createCandidateController', createCandidateController)
   
function createCandidateController($scope, $state, localStorageService, ngAuthSettings, apiCall, formAction, AppIndustries, AppCoutries, APP_CONSTANTS, $http, configJSON) {
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
    $scope.IsMangePage = $scope.formAction == "Manage" ? true : false;
    $scope.compId = 1;
    $scope.refData.userViewType = "Card";
    $scope.baseUrl = ngAuthSettings.apiServiceBaseUri;

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


    if ($scope.edit) {
        $scope.SupplierState = true;
        $scope.dataJSON = localStorageService.get('editCandidateData');
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
    $scope.test = function (index) {
        console.log(index);

      
    }
    $scope.submit = function (form) {
        
        $scope.dataJSON.SupplierId = localStorageService.get('supplierId');            
            $scope.dataJSON.Candidate.Email = $scope.dataJSON.Contact.EmailAddress;
            $scope.dataJSON.Contact.FirstName = $scope.dataJSON.Candidate.FirstName;
            $scope.dataJSON.Contact.LastName = $scope.dataJSON.Candidate.LastName;            
            $scope.dataJSON.CandidateContact = [];
            $scope.dataJSON.CandidateContact.push($scope.dataJSON.Contact);
            $scope.CreateIndustriesData();
            $scope.CreateIndustrySkillsData();
            
        if (form.$valid) {
            var suc = false;
            if ($scope.edit) {
                var res = apiCall.post(APP_CONSTANTS.URL.CANDIDATEURL.UPDATEURL, $scope.dataJSON);
                res.then(function (data) {
                    $scope.dataJSON = data;
                    $scope.cancel();
                    //$state.go($scope.configJSON.successURL);
                });
            }
            else {
                var res = apiCall.post(APP_CONSTANTS.URL.CANDIDATEURL.CREATEURL, $scope.dataJSON);
                res.then(function (data) {
                    $scope.dataJSON = data;
                    $scope.cancel();
                    //$state.go($scope.configJSON.successURL);
                });
            }
           
        }
    }

    $scope.removeFile = function (index) {
        $scope.dataJSON.CandidateFile.splice(index, 1);
    }

    $scope.cancel = function () {

        if (!$scope.SupplierState){
            $scope.IsMangePage = true;
            $scope.edit = false;
        }
        else {
            $state.go("company.searchSuppliers");
        }
        
    }
    
    
}

angular.module('eMSPApp')
    .directive('dropZone', ['ngAuthSettings',
        function (ngAuthSettings) {

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
                objXhr.open("POST", ngAuthSettings.apiServiceBaseUri + "api/FileUpload/uploadFiles");
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


