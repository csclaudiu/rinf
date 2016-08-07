/// <reference path="angular.js" />





app.controller("listController", function ($scope, $http, $window, $location, ProductService) {

    $scope.products = ProductService.query();

    $scope.delete = function (product) {
        ProductService.delete(product, function () {
            $scope.products = ProductService.query();
        });
    }
});
app.controller("editController", function ($scope, $http, $window, $location, ProductService, $routeParams) {

    $scope.selectedProduct = null;

    var selectedProduct = ProductService.get({ id: $routeParams.id }, function (raspuns) {
        $scope.selectedProduct = raspuns;
    });

    $scope.selectedProduct = selectedProduct;

    $scope.save = function (product) {
        ProductService.update({ id: $routeParams.id }, product, function () {
            $window.location.href = '#/list';
        });
        
    }
});

app.controller("addController", function ($scope, $http, $window, $location, ProductService) {
    var newProduct = {
        id: "",
        name: "",
        description: ""
    };
    $scope.newProduct = newProduct;

    $scope.add = function (product) {
        ProductService.save(product, function () {
            $window.location.href = '#/list';
        });
    }

});