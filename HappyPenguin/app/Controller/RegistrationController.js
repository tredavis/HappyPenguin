happyApp.controller("RegistrationController", ["$http", "RegistrationService", "$location", "$scope", function ($http, RegistrationService, $location, $scope) {

    $scope.isLoading = function () {
        $scope.buttonText = $scope.loading ? "Processing" : "Register";
        return $scope.loading;
    };
    $scope.processRegistration = function () {
        $scope.loading = !$scope.loading;
        console.log('hi');
        return RegistrationService.processRegistration($scope.email, $scope.password, $scope.passwordCheck)
            .then(function() {
                    
                    $scope.loading = !$scope.loading;
                    $location.path('/login');
                },
                function() {
                
                    $scope.loading = !$scope.loading;
               
                });
    }
}]);