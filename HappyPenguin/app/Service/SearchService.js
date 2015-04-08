
happyApp.service('SearchService', ['$http', '$q', function ($http, $q) {
    var loadItemDeferred = $q.defer();    
    var items = [];
    var search = function (input) {
        $http.jsonp('http://api.walmartlabs.com/v1/search?query=' + input + '&format=json&numItems=10&apiKey=uq3mpsyjuqmpbm8x5ggwwcb2&callback=JSON_CALLBACK')
            .success(function (data) {
            items.length = 0;
                for (var prop in data) {
                    if (data.hasOwnProperty('items')) {
                        items.push(data[prop]);
                    }
                }
                loadItemDeferred.resolve(items);
        
        }).error(function (data) {
                alert("The call didnt work...")
            });
      
        return loadItemDeferred.promise;
        }

    return {
        search: search,        
    }

}]);

