(function () {
    'use strict';

    angular.module('eMSPApp')
       
        /*This function is to Get the total for the ng-repeat*/
        .filter('total', function () {
            return function (input, property) {
                var i = input instanceof Array ? input.length : 0;
                if (typeof property === 'undefined' || i === 0) {
                    return i;
                } else if (isNaN(input[0][property])) {
                    throw 'filter total can count only numeric values';
                } else {
                    var total = 0;
                    while (i--)
                        total += input[i][property];
                    return total;
                }
            };
        })
        .filter('roundup', function () {
            return function (value) {
                return Math.ceil(value);
            };
        })
        
        .factory('$eMSPFactory', ['$window', '$http', 'ngToast', function ($window, $http, ngToast) {
            return {
                set: function (key, value) {
                    $window.localStorage[key] = value;
                },
                get: function (key, defaultValue) {
                    return $window.localStorage[key] || defaultValue;
                },
                setObject: function (key, value) {
                    $window.localStorage[key] = angular.toJson(value);
                },
                getObject: function (key) {
                    return JSON.parse($window.localStorage[key] || '[]');
                },
                getArray: function (key) {
                    return JSON.parse($window.localStorage[key] || '[]');
                },
                destroy: function (key) {
                    $window.localStorage.removeItem(key);
                },
                log: function (key, defaultValue) {
                    console.log($window.localStorage[key] || defaultValue);
                },
                logObject: function (key) {
                    console.log(JSON.parse($window.localStorage[key] || '{}'));
                },
                sysDate: function (str) {
                    var date = new Date(str),
                    mnth = date.getMonth(),
                    day = ("0" + date.getDate()).slice(-2);
                    var months = ["Jan", "Feb", "Mar", "Apr", "May", "Jun", "Jul", "Aug", "Sep", "Oct", "Nov", "Dec"];
                    return [day, months[mnth], date.getFullYear()].join("-");
                },
                convertDate: function (str) {
                    var date = new Date(str),
                    mnth = date.getMonth(),
                    day = ("0" + date.getDate()).slice(-2);
                    var months = ["Jan", "Feb", "Mar", "Apr", "May", "Jun", "Jul", "Aug", "Sep", "Oct", "Nov", "Dec"];
                    return [day, months[mnth], date.getFullYear()].join("-");
                },
                httpGetHandler: function (url) {
                    var httpResult = {
                        async: function () {
                            $('#commonLoading').modal({
                                backdrop: 'static',
                                keyboard: false
                            });
                            // $http returns a promise, which has a then function, which also returns a promise
                            var promise = $http.get(url).then(function (response) {
                                $('#commonLoading').modal('hide');
                                // The return value gets picked up by the then in the controller.
                                return response.data;
                            });
                            // Return the promise to the controller
                            return promise;
                        }
                    };
                    return httpResult;
                },
                httpGetHeaderHandler: function (url) {
                    var httpResult = {
                        async: function () {
                            var config = {
                                headers: {
                                    'Token': $window.localStorage.getItem('authToken')
                                }
                            };
                            $('#commonLoading').modal({
                                backdrop: 'static',
                                keyboard: false
                            });
                            // $http returns a promise, which has a then function, which also returns a promise
                            var promise = $http.get(url, config).then(function (response) {
                                $('#commonLoading').modal('hide');
                                $window.localStorage.setItem('authToken', response.data.token);
                                // The return value gets picked up by the then in the controller.                             
                                return response.data;
                            }).catch(function (response) {
                                $('#commonLoading').modal('hide');
                                if (response.status == 401) {
                                    //Removing all user based values from Local storage
                                    for (var i = 0, len = localStorage.length; i < len; ++i) {
                                        if (!(localStorage.key(i) === "cartItem")) {
                                            $window.localStorage.removeItem(localStorage.key(i));
                                        }
                                    }
                                    $("div.log-in-up").addClass("open-log-in");
                                }
                                return response.data;
                            });
                            // Return the promise to the controller
                            return promise;
                        }
                    };
                    return httpResult;
                },
                httpPostHandler: function (url, data) {
                    $('#commonLoading').modal({
                        backdrop: 'static',
                        keyboard: false
                    });
                    var httpResult = {
                        async: function () {
                            // $http returns a promise, which has a then function, which also returns a promise
                            var promise = $http.post(url, data).then(function (response) {
                                $('#commonLoading').modal('hide');
                                // The return value gets picked up by the then in the controller.                            
                                return response.data;
                            });
                            // Return the promise to the controller
                            return promise;
                        }
                    };
                    return httpResult;
                },
                httpPostHeaderHandler: function (url, data, pageNo, pageCount) {
                    $('#commonLoading').modal({
                        backdrop: 'static',
                        keyboard: false
                    });

                    var httpResult = {
                        async: function () {
                            var config = {
                                headers: {
                                    'Token': $window.localStorage.getItem('authToken'),
                                    'PageNo': pageNo,
                                    'PageCount': pageCount
                                }
                            };
                            // $http returns a promise, which has a then function, which also returns a promise
                            var promise = $http.post(url, data, config).then(function (response) {
                                $('#commonLoading').modal('hide');
                                // The return value gets picked up by the then in the controller.                            
                                return response.data;
                            }).catch(function (response) {
                                $('#commonLoading').modal('hide');
                                if (response.status == 401) {
                                    //Removing all user based values from Local storage
                                    for (var i = 0, len = localStorage.length; i < len; ++i) {
                                        if (!(localStorage.key(i) === "cartItem")) {
                                            $window.localStorage.removeItem(localStorage.key(i));
                                        }
                                    }
                                    $("div.log-in-up").addClass("open-log-in");
                                }
                                return response.data;
                            });
                            // Return the promise to the controller
                            return promise;
                        }
                    };
                    return httpResult;
                },
                httpPost: function (url, data, pageNo, pageCount) {
                    $('#commonLoading').modal({
                        backdrop: 'static',
                        keyboard: false
                    });

                    var httpResult = {
                        async: function () {
                            var config = {
                                headers: {
                                    'Token': $window.localStorage.getItem('authToken'),
                                    'PageNo': pageNo,
                                    'PageCount': pageCount
                                }
                            };
                            // $http returns a promise, which has a then function, which also returns a promise
                            var promise = $http.post(url, data, config).then(function (response) {
                                $('#commonLoading').modal('hide');
                                if (response.headers('Token') != null) {
                                    $window.localStorage.setItem('authToken', response.headers('Token'));
                                }
                                // The return value gets picked up by the then in the controller.                            
                                return response;
                            }).catch(function (response) {
                                $('#commonLoading').modal('hide');
                                if (response.status == 401) {
                                    //Removing all user based values from Local storage
                                    for (var i = 0, len = localStorage.length; i < len; ++i) {
                                        if (!(localStorage.key(i) === "cartItem")) {
                                            $window.localStorage.removeItem(localStorage.key(i));
                                        }
                                    }
                                    $("div.log-in-up").addClass("open-log-in");
                                }
                                return response.data;
                            });
                            // Return the promise to the controller
                            return promise;
                        }
                    };
                    return httpResult;
                },
                httpPutHandler: function (url, data) {
                    $('#commonLoading').modal({
                        backdrop: 'static',
                        keyboard: false
                    });

                    var httpResult = {
                        async: function () {
                            var config = {
                                headers: {
                                    'Token': $window.localStorage.getItem('authToken')
                                }
                            };
                            // $http returns a promise, which has a then function, which also returns a promise
                            var promise = $http.put(url, data, config).then(function (response) {
                                $('#commonLoading').modal('hide');
                                // The return value gets picked up by the then in the controller.                            
                                return response.data;
                            }).catch(function (response) {
                                $('#commonLoading').modal('hide');
                                if (response.status == 401) {
                                    //Removing all user based values from Local storage
                                    for (var i = 0, len = localStorage.length; i < len; ++i) {
                                        if (!(localStorage.key(i) === "cartItem")) {
                                            $window.localStorage.removeItem(localStorage.key(i));
                                        }
                                    }
                                    $("div.log-in-up").addClass("open-log-in");
                                }
                                return response.data;
                            });
                            // Return the promise to the controller
                            return promise;
                        }
                    };
                    return httpResult;
                },
                myAlertHandler: function (type, content, position) {
                    ngToast.create({
                        className: type || 'warning',
                        content: content || "this is common alert",
                        animation: 'slide',
                        dismissButton: true,
                        timeout: 3000
                    });
                    //ngToast.settings.verticalPosition = 'bottom';
                    return "";
                }
            }
        }])        

});