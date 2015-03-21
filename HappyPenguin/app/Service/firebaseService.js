happyApp.service('firebaseService', ['$http', '$q', function ($http, $q) {

    var addFireItem = function (item) {
        var deferred = $q.defer();
        var firebaseModel = {
            "ItemName": item["ItemName"],
            "Price": item["Price"],
            "Image": item["Image"]
        };

        console.log(firebaseModel);
        $http({
            url: 'api/apiItem',
            method: 'POST',
            data: firebaseModel
        }).success(function (firebaseModel) {
            deferred.resolve(firebaseModel);

        }).error(function () {
            deferred.reject();
        });
        return deferred.promise;
    }
    return {
        addFireItem: addFireItem
    }
}])