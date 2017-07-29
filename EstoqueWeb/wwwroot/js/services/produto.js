(function(){
    'use strict';

    angular
        .module('produto')
        .factory('produtoService', ['$http', produtoService]);

   
    function produtoService(http){

        const serviceBase = "http://localhost:59733/";

        return {
            getData: getData,
            postData: postData,
            getItemData: getItemData,
            removerData: removerData,
            putData: putData,
            getFornecedor: getFornecedor
        }

        function getData(){
            return http.get(serviceBase + "api/produto");
        }

        function postData(item){
            return http.post(serviceBase + "api/produto", item);
        }

        function getItemData(item){
            return http.get(serviceBase + "api/produto/" + item);
        }

        function removerData(item){
            return http.delete(serviceBase + "api/produto/" + item);
        }

        function putData(item){
            return http.put(serviceBase + "api/produto/" + item.produtoID, item);
        }

        function getFornecedor() {
            return http.get(serviceBase + "api/Fornecedor");
        }
    }

}());