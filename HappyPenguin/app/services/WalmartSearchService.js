app.factory("WalmartSearchService"), ["$http", "$q", function ($http, $q) {

    var searchWalmart = function (myQuery) {
        var deffered = $q.defer();
        $http('http://api.walmartlabs.com/v1/search')
    }
}

]