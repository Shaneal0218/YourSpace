app.service("videosService", function($http) {

    this.getVideo = function (videoId) {
        return $http.get("http://localhost:5000/api/video?videoId=" + videoId)
      }
    
      this.getSearch = function (search) {
        return $http.get("http://localhost:5000/api/youtube?search=" + search)
      }
    
      this.getTrending = function() {
        return $http.get("http://localhost:5000/api/trending")
      }

      this.addFavorite = function(request) {
        return $http.post("http://localhost:5000/api/video/favorite/add", request);
      }

      this.shareVideo = function(request) {
        return $http.post("http://localhost:5000/api/video/share", request)
      }
})