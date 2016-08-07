/// <reference path="../angular.js" />

'use strict'

var app = angular.module("mainModule", ['ngResource', 'ngRoute'])
            .config(function ($routeProvider, $locationProvider) {
                $routeProvider
                    .when("/list", {
                        templateUrl: "Scripts/Templates/list.html",
                        controller: "listController"
                        })
                    .when("/edit/:id", {
                        templateUrl: "Scripts/Templates/edit.html",
                        controller: "editController"
                    })
                    .when("/new", {
                        templateUrl: "Scripts/Templates/add.html",
                        controller: "addController"
                    })
                .otherwise({
                    redirectTo: "/list"
                })
                //$locationProvider.html5Mode(true);
            })
;