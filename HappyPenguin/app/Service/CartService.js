happyApp.factory('CartService', ['$http', '$q', function ($http, $q) {

    var addItem = function (item) {
        
        var deferred = $q.defer();
        var model = {
            "ItemName": item["name"],
            "Price": item["salePrice"],
            "Image": item["thumbnailImage"]
            };
    
        $http({
            url: 'api/apiItem',
            method: 'POST',
            data: model
        }).success(function (model) {
            deferred.resolve(model);
           
        }).error(function () {
            deferred.reject();
        });
        return deferred.promise;
    }
    var addEbayItem = function (item) {
        var deferred = $q.defer();
        var ebayModel = {
            "ItemName": item["title"],
            "Price": item["price"],
            "Image": item["image"]
        };
        
        console.log(ebayModel);
        $http({
            url: 'api/apiItem',
            method: 'POST',
            data: ebayModel
        }).success(function (ebayModel) {
            deferred.resolve(ebayModel);
        
        }).error(function () {
            deferred.reject();
        });
        return deferred.promise;
    }
    var loadWalmartItem = function () {
        var cartView = [];
      
        var deferred = $q.defer();
        $http({
            url: 'api/apiItem',
            method: 'GET'
        }).success(function(data) {
            cartView = data;
        
            deferred.resolve(cartView);
        }).error(function() {
            deferred.reject();
        });
        return deferred.promise;
    }
    var deleteItem = function (item){
        var deferred = $q.defer();
        var model = {
            "ItemsId" : item.ItemsId
        }
        $http({
            url: 'api/apiItem' ,
            method: 'DELETE',
            headers : { "Content-Type" : "application/json"},
            data: model
        }).success(function (item) {
            console.log("We Deleted An Item")
        
            deferred.resolve(item)
        }).error(function () {
            console.log("YOU FAIL")
            deferred.reject();
        })
        return deferred.promsise;
    
    }
    return { addItem: addItem, addEbayItem: addEbayItem, loadWalmartItem: loadWalmartItem, deleteItem: deleteItem }
}]);