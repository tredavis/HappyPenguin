happyApp.factory('LoginService', ['$http', '$q', '$window', function ($http, $q, $window) {
    var callbacks = [];

    var processLogin = function (username, password) {
        var deferred = $q.defer();

        $http({
            url: '/Token', //Programmed In
            method: 'POST',
            data: 'username=' + username + '&password=' + password + '&grant_type=password',
            headers: { 'Content-Type': 'application/x-www-form-urlencoded' }
        }).success(function (data) {
            $window.sessionStorage.setItem('token', data.access_token);
            $window.sessionStorage.setItem('username', data.userName);
            console.log(data.username)
            deferred.resolve(data.username);
        }).error(function (data) {
            deferred.reject(data);
        });

        return deferred.promise;
    };

    var isLoggedIn = function () {
        return $window.sessionStorage.getItem('username');
    }

    var logout = function() {
        $window.sessionStorage.removeItem('token');
        $window.sessionStorage.removeItem('username');
        for (var c in callbacks) {
            var cb = callbacks[c];
            cb();
        }
    }


    return {
        processLogin: processLogin,
        isLoggedIn: isLoggedIn,
        logout: logout
        //registerLogOutCallback: registerLogOutCallback
    };
}]);