app.controller("moviesController", function ($scope, moviesService) {

    this.getShowing = moviesService.getShowing().then(function(response){
        $scope.movies = response.data.results;
        console.log(response.data.results);
        $scope.image = "https://image.tmdb.org/t/p/w185_and_h278_bestv2/";
        $scope.amc ="https://www.amctheatres.com/movies/"
      })
})