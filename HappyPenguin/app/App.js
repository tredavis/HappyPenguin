var happyApp = angular.module('happyApp', ['ngRoute','firebase']);

happyApp.config(['$routeProvider', '$httpProvider', function ($routeProvider, $httpProvider) {
    $routeProvider.when('/', {
        templateUrl: 'app/View/FrontPage.html',
        controller: 'FrontController'
    })
    .when('/login', {
        templateUrl: 'app/View/Login.html',
        controller: 'LoginController'
    })
    .when('/cart', {
        templateUrl: 'app/View/Cart.html',
        controller: 'SearchController'
    })
    .when('/register', {
        templateUrl: '/app/views/RegistrationView.html',
        controller: 'RegistrationController'
    })
    .when('/search', {
        templateUrl: 'app/View/Search.html',
        controller: 'SearchController'
    })
    .when('/about', {
        templateUrl: 'app/View/AboutUs.html'
    })
    .when('/register', {
        templateUrl: 'app/View/Registration.html',
        controller: 'RegistrationController'
    });

}]);