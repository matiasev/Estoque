'use strict';

angular.module('produto', ['ngRoute'])

.config(['$routeProvider', function($routeProvider) {
    

    $routeProvider
        .when('/', {
            templateUrl: '/app/www/views/produto.html',
            controller: 'produtoController',
            controllerAs: 'vm'
        })
         .when('/produtos', {
            templateUrl: '/app/www/views/produto-list.html',
            controller: 'produtoController',
            controllerAs: 'vm'
        })
        .when('/produto/edit/:id',{
            templateUrl: '/app/www/views/produto-edit.html',
            controller: 'produtoEditController',
            controllerAs: 'vm'
        })
        .when('/produto/detalhes/:id', {
            templateUrl: '/app/www/views/produto-details.html',
            controller: 'produtoDetalheController',
            controllerAs: 'vm'
        })
        .otherwise({
            redirectTo: '/'     
        });

    
}]);

