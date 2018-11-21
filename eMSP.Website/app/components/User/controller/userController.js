'use strict';
angular.module('eMSPApp')
    .controller('userController', userController)
    .controller('userManagerController', userManagerController);

function userController($scope, $state, $uibModal, localStorageService, apiCall, ngAuthSettings, APP_CONSTANTS, $http, $uibModalInstance, toaster) {
    $scope.configJSON = {};
    $scope.refData = {};
    $scope.refData.submitted = false;
    $scope.edit = $scope.formAction == "Update" ? true : false;
    $scope.refData.countryList = $scope.$parent.refData.countryList;
    $scope.dataJSON.userProfilePhotoPath = "";
    $scope.error = "";
    $scope.cropped = {
        source: 'https://raw.githubusercontent.com/Foliotek/Croppie/master/demo/demo-1.jpg'
    };

    $http.get("app/components/user/config/manageUser.json").success(function (data) {
        $scope.configJSON = data;
    });

    $scope.getStateList = function () {

        if ($scope.udataJSON.countryId) {
            var param = { "Id": $scope.udataJSON.countryId }
            var apires = apiCall.post(APP_CONSTANTS.URL.APP.GETSTATEURL + $scope.udataJSON.countryId, {});
            apires.then(function (data) {
                $scope.refData.stateList = data;
            });
        }
    }

    if ($scope.editform) {
        $scope.udataJSON.countryId = $scope.udataJSON.countryId.toString();
        $scope.udataJSON.stateId = $scope.udataJSON.stateId.toString()
        $scope.udataJSON.userProfilePhotoPathT = ngAuthSettings.contentURL + $scope.udataJSON.userProfilePhotoPath;
        $scope.getStateList();
    }

    $scope.submit = function (form) {
        $scope.refData.submitted = true;

        var obj = localStorageService.get('authorizationData');
        if (form.$valid) {
            var suc = false;
            if ($scope.editform) {
                var res = apiCall.post(APP_CONSTANTS.URL.USER.UPDATEUSERURL, $scope.udataJSON);
                res.then(function (data) {
                    $scope.udataJSON = data;
                    toaster.warning({ body: "Data Updated Successfully." });
                    $uibModalInstance.close();

                }).catch(function (err) {
                    $scope.error = err;
                    toaster.error({ body: err });
                });
            }
            else {
                var res = apiCall.post(APP_CONSTANTS.URL.USER.CREATEUSRURL, $scope.udataJSON);
                res.then(function (data) {
                    $scope.udataJSON = data;
                    toaster.warning({ body: "Data Created Successfully." });
                    //$state.reload();                    
                    $scope.$parent.resUsers.unshift(data);
                    $uibModalInstance.close();
                }).catch(function (err) {
                    $scope.error = err.data;
                    toaster.error({ body: "Some Error occured." });
                });
            }
        }
    }

    $scope.close = function () {
        $uibModalInstance.close();
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
            $scope.fname = input.files[0].name;
            $scope.ftype = 'img/' + $scope.fname.split('.')[1];
            //$scope.modelLogo(fname, ftype);
            $scope.crop = true;
        }
    };

    $scope.selectFile = function () {
        $("#upload").click();
    }
    $scope.ok = function () {

        var data = new FormData();

        if ($scope.udataJSON.userProfilePhotoPath) {

            var image_data = atob($scope.udataJSON.userProfilePhotoPath.split(',')[1]);
            // Use typed arrays to convert the binary data to a Blob
            var arraybuffer = new ArrayBuffer(image_data.length);
            var view = new Uint8Array(arraybuffer);
            for (var i = 0; i < image_data.length; i++) {
                view[i] = image_data.charCodeAt(i) & 0xff;
            }

            var blob = new Blob([arraybuffer], { type: $scope.ftype });
            var file = new File([blob], $scope.fname);

            data.append("uploadedFile", file);



            // ADD LISTENERS.
            var objXhr = new XMLHttpRequest();
            //objXhr.addEventListener("progress", updateProgress, false);
            objXhr.addEventListener("load", transferComplete, false);

            // SEND FILE DETAILS TO THE API.

            objXhr.open("POST", ngAuthSettings.apiServiceBaseUri + "api/FileUpload/uploadFiles");
            objXhr.send(data);

            $scope.crop = false;
            $scope.udataJSON.userProfilePhotoPathT = $scope.udataJSON.userProfilePhotoPath;
        }


    };

    $scope.cancel = function () {
        $scope.crop = false;
    };

    function transferComplete(e) {
        console.log(e);
        var obj = angular.fromJson(e.srcElement.response);
        $scope.udataJSON.userProfilePhotoPath = obj[0].FilePath;
        $scope.crop = false;
    };
    $scope.modelLogo = function (filename, ftype) {
        var modalInstance = $uibModal.open({
            template: '<div style="Z-index:10000000 !important" class="modal-header">\
                       <h3 class="modal-title" > Upload Logo:</h3>\
                       </div >\
                       <div class="modal-body">\
                       <croppie ng-if="cropped.source" src="cropped.source" ng-model="udataJSON.userProfilePhotoPath" options="{boundary:{width:300,height:350}}"></croppie></div>\
                       <div class="modal-footer">\
                       <button class="btn btn-primary" type="button" ng-click="ok()">OK</button>\
                       <button class="btn btn-warning" type="button" ng-click="cancel()">Cancel</button>\
                       </div>',
            scope: $scope,
            controller: function ($scope, $uibModalInstance, ngAuthSettings) {
                $scope.ok = function () {

                    var data = new FormData();

                    if ($scope.udataJSON.userProfilePhotoPath) {

                        var image_data = atob($scope.udataJSON.userProfilePhotoPath.split(',')[1]);
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
                    $scope.udataJSON.userProfilePhotoPath = obj[0].FilePath;
                    $uibModalInstance.close();
                };
            },
            windowClass: 'animated slideInRight'
        });
    }

}


function userManagerController($scope, localStorageService, apiCall, APP_CONSTANTS, toaster, configJSON, usersList) {
    $scope.configJSON = configJSON.data;
    $scope.resUsers = usersList;


    $scope.toggleLockUser = function (model) {

        if (model.IsLockedOut == true) {
            var res = apiCall.post($scope.configJSON.urlLock, model);
            res.then(function (data) {
                toaster.warning({ body: "User Locked Successfully." });
            });
        } else {
            var res = apiCall.post($scope.configJSON.urlUnlock, model);
            res.then(function (data) {
                toaster.warning({ body: "User Unlocked Successfully." });
            });
        }

    }




}
angular.module('eMSPApp').directive('toNumber', function () {
    return {
        require: 'ngModel',
        link: function (scope, element, attrs, ngModel) {
            ngModel.$parsers.push(function (val) {
                return parseInt(val, 10);
            });
            ngModel.$formatters.push(function (val) {
                return '' + val;
            });
        }
    }
})

