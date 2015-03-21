happyApp.controller('FrontController', ['$scope', '$firebaseArray', 'firebaseService', 'LoginService', function ($scope, $firebaseArray, firebaseService, LoginService) {

    $scope.isLoggedIn = function () {
        $scope.username = LoginService.isLoggedIn();
        return $scope.username;
    };
    $scope.hotItems = "Hot Items!";
    var ref = new Firebase("https://happypenguin.firebaseio.com/happypenguin");
    $scope.frontgreeting = "Welcome to Happy Penguin!";

    $scope.happyPenguinObjects = $firebaseArray(ref);

    // add new items to the array
    // the message is automatically added to Firebase!
    $scope.seedObject = function () {
        $scope.happyPenguinObjects.$add({
            ItemName: $scope.newName,
            Image: $scope.newImage,
            Price: $scope.price
        });
    };

    $scope.addToDb = function (item) {
        console.log(item);
        return firebaseService.addFireItem(item).then(function () {
        });
    }

}]);