happyApp.controller('SearchController', ['SearchService', 'ebayService', 'CartService', '$scope','$location', function (SearchService, ebayService, CartService, $scope, $location) {
    
    $scope.search = function () {
        var walmart = SearchService.search($scope.input).then(function (data) {
            $scope.items = data[6];
            console.log($scope.items);
            $location.path('/search');
        });
        var ebay = ebayService.search($scope.input).then(function (data) {
            $scope.etems = data;
            $location.path('/search');

            return [walmart, ebay];
        });
    }
    //Walmart
    $scope.addItem = function (item) {
        console.log(item);
        return CartService.addItem(item).then(function () {
        });
    }
    //eBay 
    $scope.addEbayItem = function (item) {
        
        return CartService.addEbayItem(item).then(function () {
        });

    }
    //GET all items
    $scope.loadWalmartItem = function () {

        var loadCart = CartService.loadWalmartItem().then(function (data) {
            $scope.cart = data;
          
        });
        return loadCart;
    }

    $scope.deleteItem = function (item) {
        return CartService.deleteItem(item).then(function(data) {
         
        
        });
    }

}]);
