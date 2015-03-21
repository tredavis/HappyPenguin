happyApp.controller('LoginController', ['$scope', 'LoginService', '$location', function ($scope, LoginService, $location) {
    $scope.isLoading = function () {
        $scope.buttonText = $scope.loading ? 'Please Wait...' : 'Login';
        return $scope.loading;
    };

    $scope.processLogin = function () {
        $scope.loading = !$scope.loading;

        return LoginService.processLogin($scope.username, $scope.password)
            .then(function (username) {
                $scope.loading = !$scope.loading;
                $location.path('/');
            }, function (data) {
                $scope.errorMessage = data.error_description;
                $scope.loading = !$scope.loading;
            });
    };

    $scope.isLoggedIn = function () {
        $scope.username = LoginService.isLoggedIn();
        return $scope.username;
    };

    $scope.logout = function() {
        LoginService.logout();
        $location.path('/login');
    };
}]);