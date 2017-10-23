var app = angular.module("spaceApp", ["ui.router"])

app.config(function ($stateProvider, $urlRouterProvider) {

    $urlRouterProvider.otherwise("/");

    $stateProvider
        .state("home", {
            url: '/',
            templateUrl: "./views/home.html",
        })
        .state("user", {
            url: '/user',
            templateUrl: "./views/user.html",
            controller: "userController"
        })
        .state("movies", {
            url: '/movies',
            templateUrl: "./views/movies.html",
            controller: "moviesController"
        })
        .state("videos", {
            url: '/videos',
            templateUrl: "./views/videos.html",
            controller: "videosController"
        })
        .state("news", {
            url: '/news',
            templateUrl: "./views/news.html",
            controller: "newsController"
        })
        .state("messages", {
            url: '/messages',
            templateUrl: "./views/messages.html",
            controller: "messagesController"
        })

})