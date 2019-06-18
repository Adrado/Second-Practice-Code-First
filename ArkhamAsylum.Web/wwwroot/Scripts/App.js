var app = angular.module('CrazyBooksApp', ['ngRoute', 'ui.grid']);

app.config(function ($routeProvider, $locationProvider)
{
    $routeProvider.when('/areas',
    {
        template: '<areas></areas>'
        });

    $routeProvider.when('/employees',
        {
            template: '<employees></employees>'
        });

    $routeProvider.when('/buildings',
        {
            template: '<buildings></buildings>'
        });

    $routeProvider.when('/products',
        {
            template: '<products></products>'
        });

    $routeProvider.when('/purchases',
        {
            template: '<purchases></purchases>'
        });

    // use the HTML5 History API
    $locationProvider.html5Mode(true);
});




