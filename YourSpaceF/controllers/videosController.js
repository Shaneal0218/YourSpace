app.controller("videosController", function ($scope, $sce, $http, $state, videosService, userService) {
  // ng-model for search params
  $scope.mySearch = "";

  $scope.currentUser = userService.getCurrentUser();
  console.log($scope.currentUser);

  // ng-repeat on trending for video items
  videosService.getTrending().then(function (response) {
    $scope.trending = response.data.items
    for (var i = 0; i < $scope.trending.length; i++) {
      $scope.trending[i].url = $sce.trustAsResourceUrl("http://www.youtube.com/embed/" + $scope.trending[i].id + "?rel=0&hd=1");
    }
    console.log($scope.trending)
  })

  $scope.getSearch = function () {
    videosService.getSearch($scope.mySearch).then(function (response) {
      // searchReturn will be array of videos
      $scope.searchReturn = response.data.items;
      for (var i = 0; i < $scope.searchReturn.length; i++) {
        $scope.searchReturn[i].url = $sce.trustAsResourceUrl("http://www.youtube.com/embed/" + $scope.searchReturn[i].id.videoId + "?rel=0&hd=1");
      }
      console.log($scope.searchReturn)
    })
  }

  $scope.addFavorite = function (video) {
    var request = {};
    videosService.getVideo(video.id).then(function (response) {
      request.video = response.data.items[0];
      request.user = $scope.currentUser;
      videosService.addFavorite(request).then(function (response) {
        $http.get("http://localhost:5000/api/users/" + $scope.currentUser.id).then(function(response) {
          $scope.currentUser = response.data;
          userService.setCurrentUser($scope.currentUser);
        })
      })
      alert("Video has been saved to your favorites!");
    })
    $state.go("videos")
  }

  $scope.shareModal = function (video) {
    $scope.selectedVideo = video;
    $("#share").modal();
  };

  $scope.sendTo = [];
  $scope.checkedFriends = {};

  $scope.shareVideo = function() {
    console.log($scope.checkedFriends)
    for (var i = 0; i < $scope.currentUser.friends.length; i++) {
      var friend = $scope.currentUser.friends[i];
      if ($scope.checkedFriends[friend.username]) {
        $scope.sendTo.push(friend);
      }    
    }
    console.log($scope.sendTo)
    for (var i = $scope.sendTo.length - 1; i >= 0; i--) {
      var request = {};
      request.User = $scope.sendTo[i];
      request.fromUser = $scope.currentUser.username;
      request.videoId = $scope.selectedVideo.id;
      videosService.shareVideo(request);
      alert("Your message has been shared with " + $scope.sendTo[i].username + "!");
      $scope.sendTo.splice(i, 1);
    }
    console.log($scope.sendTo)
  }
})