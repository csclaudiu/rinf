/// <reference path="../angular.js" />
/// <reference path="../angular-resource.js" />


'use strict'

angular.module("mainModule")
.factory("ProductService", function ($resource) {
    var data = $resource("http://localhost/wAPI/api/product/:id", { id: '@id' }, {
        update: { method: 'PUT' }
    });
    return data;
});

//services.factory('User', function ($resource) {
//    return $resource('/rest/usersettings/:username', {}, {
//        get: { method: 'GET' },
//        update: { method: 'POST' }
//    });
//});