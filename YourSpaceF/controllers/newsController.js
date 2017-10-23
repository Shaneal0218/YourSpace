app.controller("newsController", function ($scope, newsService) {
    // Array of articles stored in $scope.entertainment
    // Array of articles stored in $scope.entertainment
  newsService.getEntertainment().then(function(response) {
    $scope.entertainment = response.data.articles;
    console.log($scope.entertainment)

    console.log($scope.entertainment[0].title);
  })

  $scope.articleCount = 1;

})