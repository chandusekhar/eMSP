'use strict';
angular.module('eMSPApp')
    .controller('createCompanyController', createCompanyController)
function createCompanyController($scope, $state, localStorageService, configJSON, formAction, AppCoutries, apiCall, APP_CONSTANTS, $uibModal, toaster) {
    $scope.configJSON = configJSON.data;
    $scope.dataJSON = {};
    $scope.refData = {};
    $scope.refData.countryList = AppCoutries;
    $scope.dataJSON.companyType = $scope.configJSON.companyType;
    $scope.dataJSON.LogoPath = "";
    $scope.edit = false;
    $scope.formAction = formAction;
    $scope.refData.submitted = false;
    $scope.cropped = {
        source: 'https://raw.githubusercontent.com/Foliotek/Croppie/master/demo/demo-1.jpg'
    };
    $scope.getStateList = function () {
        if ($scope.dataJSON.CountryID) {

            var param = { "Id": $scope.dataJSON.CountryID }
            var apires = apiCall.post(APP_CONSTANTS.URL.APP.GETSTATEURL + $scope.dataJSON.CountryID, {});
            apires.then(function (data) {
                $scope.refData.stateList = data;
            });
        }
    }

    if ($scope.formAction == "Update") {
        $scope.edit = true;
        $scope.dataJSON = localStorageService.get('editCompanyData');
        $scope.getStateList();
    }




    // Assign blob to component when selecting a image
    $scope.upload = function (input) {


        if (input.files && input.files[0]) {
            var reader = new FileReader();

            reader.onload = function (e) {
                // bind new Image to Component
                $scope.$apply(function () {
                    $scope.cropped.source = e.target.result;
                });
            }

            reader.readAsDataURL(input.files[0]);
            var fname = input.files[0].name;
            var ftype = 'img/' + fname.split('.')[1];
            $scope.modelLogo(fname,ftype);
        }
    };

    $scope.selectFile = function () {
        $("#upload").click();
    }

    $scope.modelLogo = function (filename,ftype) {
        var modalInstance = $uibModal.open({
            template: '<div class="modal-header">\
                       <h3 class="modal-title" > Upload Logo:</h3>\
                       </div >\
                       <div class="modal-body">\
                       <croppie ng-if="cropped.source" src="cropped.source" ng-model="dataJSON.companyLogo" options="{boundary:{width:300,height:350}}"></croppie></div>\
                       <div class="modal-footer">\
                       <button class="btn btn-primary" type="button" ng-click="ok()">OK</button>\
                       <button class="btn btn-warning" type="button" ng-click="cancel()">Cancel</button>\
                       </div>',
            scope: $scope,
            controller: function ($scope, $uibModalInstance, ngAuthSettings) {
                $scope.ok = function () {

                    var data = new FormData();

                    if ($scope.dataJSON.companyLogo) {

                        var image_data = atob($scope.dataJSON.companyLogo.split(',')[1]);
                        // Use typed arrays to convert the binary data to a Blob
                        var arraybuffer = new ArrayBuffer(image_data.length);
                        var view = new Uint8Array(arraybuffer);
                        for (var i = 0; i < image_data.length; i++) {
                            view[i] = image_data.charCodeAt(i) & 0xff;
                        }

                        var blob = new Blob([arraybuffer], { type: ftype });
                        var file = new File([blob], filename);

                        data.append("uploadedFile", file);
                        


                        // ADD LISTENERS.
                        var objXhr = new XMLHttpRequest();
                        //objXhr.addEventListener("progress", updateProgress, false);
                        objXhr.addEventListener("load", transferComplete, false);

                        // SEND FILE DETAILS TO THE API.
                        
                        objXhr.open("POST", ngAuthSettings.apiServiceBaseUri + "api/FileUpload/uploadFiles");
                        objXhr.send(data);

                        $uibModalInstance.close();
                    }


                };

                $scope.cancel = function () {
                    $uibModalInstance.dismiss('cancel');
                };

                function transferComplete(e) {
                    console.log(e);
                    var obj = angular.fromJson(e.srcElement.response);
                    $scope.dataJSON.LogoPath = obj[0].FilePath;
                    $uibModalInstance.close();
                };
            },
            windowClass: 'animated slideInRight'
        });
    }
    $scope.submit = function (form) {
        $scope.refData.submitted = true;
        if (form.$valid) {
            if ($scope.formAction == "Update") {
                var res = apiCall.post(APP_CONSTANTS.URL.COMPANYURL.UPDATEURL, $scope.dataJSON);
                res.then(function (data) {
                    $scope.dataJSON = data;
                    toaster.success({ body: "Data Updated Successfully." });
                });
            }
            else {
                var res = apiCall.post(APP_CONSTANTS.URL.COMPANYURL.CREATEURL, $scope.dataJSON);
                res.then(function (data) {
                    $scope.dataJSON = data;
                    toaster.success({ body: "Data Created Successfully." });
                });
            }

            $state.go($scope.configJSON.successURL);
        }
    }
}