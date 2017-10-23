app.service("newsService", function($http) {

    this.getEntertainment = function() {
        return $http.get("http://localhost:5000/api/entertainment")
      }
})