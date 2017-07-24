'use strict';

angular.module('produto', ['ngRoute'])

.config(['$routeProvider', function($routeProvider) {
    

    $routeProvider
        .when('/', {
            templateUrl: '/views/produto.html',
            controller: 'produtoController',
            controllerAs: 'vm'
        })
         .when('/produtos', {
            templateUrl: '/views/produto-list.html',
            controller: 'produtoController',
            controllerAs: 'vm'
        })
        .when('/produto/edit/:id',{
            templateUrl: '/views/produto-edit.html',
            controller: 'produtoEditController',
            controllerAs: 'vm'
        })
        .when('/produto/detalhes/:id', {
            templateUrl: '/views/produto-details.html',
            controller: 'produtoDetalheController',
            controllerAs: 'vm'
        })
        .otherwise({
            redirectTo: '/'     
        });

    
}]);

