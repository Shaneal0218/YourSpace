app.service("moviesService", function($http) {

    this.getShowing = function() {
        return $http.get("http://localhost:5000/api/movie")
      }
})