(function(){
    'use strict';

    angular
        .module('produto')
        .controller('produtoController', ['produtoService', '$location', '$routeParams', produtoController])
        .controller('produtoDetalheController', ['produtoService', '$location', '$routeParams', produtoDetalheController])
        .controller('produtoEditController', ['produtoService', '$location', '$routeParams', produtoEditController]);

    function produtoController(produtoService, $location, $routeParams ){
        const vm = this;

        vm.routeParams = $routeParams;
        vm.produtos = [];
        vm.fornecedores = [];

        init();
        

        function init(){
            produtoService.getData().then(function successCallback(response) {
                vm.produtos = response.data;
            }, function errorCallback(response) {
                console.log('Erro: ', response);
            });

            produtoService.getFornecedor().then(function successCallback(response) {
                vm.fornecedores = response.data;
            }, function errorCallback(response) {
                console.log('Erro: ', response);
            });
        }

   
        vm.adicionarProduto = function (item) {
            debugger;
            produtoService.postData(item).then(function successCallback(response) {
                delete vm.addProduto;
                init();
                alert("Produto adicionado com sucesso!");
            }, function errorCallback(response) {
                console.log('Erro: ', response);
            });  
        }

        vm.detalhesProduto = function(item){
            produtoService.getItemData(item).then(function successCallback(response){   
                vm.produto = response.data;
            }, function errorCallback(response) {
                console.log('Erro: ', response);
            });
        }

        vm.removerProduto = function(item){
            if (confirm('Deseja realmente remover este produto')) {
                produtoService.removerData(item).then(function successCallback(response){
                    init();
                }, function errorCallback(response) {
                    console.log('Erro: ', response);
                });
            }
        }
    }

    function produtoDetalheController(produtoService, $location, $routeParams ){
        const vm = this;

        vm.routeParams = $routeParams;
        vm.produto = [];
        
        init($routeParams.id);

        function init(item) {
            produtoService.getItemData(item).then(function successCallback(response) {
                vm.produto = response.data;
            }, function errorCallback(response) {
                console.log('Erro: ', response);
            });
        }
    }

    function produtoEditController(produtoService, $location, $routeParams ){
        const vm = this;

        vm.routeParams = $routeParams;
        
        init($routeParams.id);

        function init(item){
            produtoService.getItemData(item).then(function successCallback(response) {
                debugger;
                vm.addProduto = response.data;
            }, function errorCallback(response) {
                console.log('Erro: ', response);
            });

            produtoService.getFornecedor().then(function successCallback(response) {
                vm.fornecedores = response.data;
            }, function errorCallback(response) {
                console.log('Erro: ', response);
            });
            
        }

        vm.salvarProduto = function(item){
            debugger;
            produtoService.putData(item).then(function successCallback(response) {
                $location.path('#!/');
            }, function errorCallback(response) {
                console.log('Erro: ', response);
            });
        }
    }
}());