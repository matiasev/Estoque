(function(){
    'use strict';

    angular
        .module('produto')
        .controller('produtoController', ['produtoService', '$location', '$routeParams', produtoController])
        .controller('produtoDetalheController', ['produtoService', '$location', '$routeParams', produtoDetalheController])
        .controller('produtoEditController', ['produtoService', '$location', '$routeParams', produtoEditController]);

    function produtoController(produtoService, $location, $routeParams ){
        let vm = this;

        vm.routeParams = $routeParams;
        vm.produtos = [];

        init();

        function init(){
            produtoService.getData().then(function successCallback(response){
                vm.produtos = response.data;
                delete vm.addProduto;
            });
        }

        vm.adicionarProduto = function(item){
            debugger;
            if (item != null) {
                produtoService.postData(item).then(function successCallback(response){
                    init();
                });
            }else{
                alert('Campo vazio!');
            }
        }

        vm.detalhesProduto = function(item){
            produtoService.getItemData(item).then(function successCallback(response){   
                vm.produto = response.data;
                debugger;
            });
        }

        vm.removerProduto = function(item){
            if (confirm('Deseja realmente remover este produto')) {
                produtoService.removerData(item).then(function successCallback(response){
                    init();
                });
            }
        }
    }

    function produtoDetalheController(produtoService, $location, $routeParams ){
        let vm = this;

        vm.routeParams = $routeParams;
        vm.produto = [];
        
        init($routeParams.id);

        function init(item){
            produtoService.getItemData(item).then(function successCallback(response){
                vm.produto = response.data;
            });
        }
    }

    function produtoEditController(produtoService, $location, $routeParams ){
        let vm = this;

        vm.routeParams = $routeParams;
        
        init($routeParams.id);

        function init(item){
            produtoService.getItemData(item).then(function successCallback(response){
                vm.addProduto = response.data;
            });
        }

         vm.salvarProduto = function(item){
            debugger;
            if (item.nome != null) {
                produtoService.putData(item).then(function successCallback(response){
                    $location.path('#/');
                });
            }else{
                alert('Campo vazio!');
            }
        }
    }

}());