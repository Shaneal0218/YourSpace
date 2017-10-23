app.controller("userController", function ($scope, $http, $state, $sce, userService, authService, notificationsService) {

    $scope.currentUser = userService.getCurrentUser();
    $scope.userSelected = null;
    $scope.updateUser = false;
    $scope.InvalidEmail = false;
    $scope.InvalidPassword = false;
    $scope.InvalidUsername = false;

    //Fills our front-end with all the users stored in our database
    userService.getUsers().then(function (response) {
        $scope.users = response.data;
        console.log($scope.users);
    })

    if ($scope.currentUser != null) {
        userService.getUserById($scope.currentUser.id).then(function (response) {
            $scope.currentUser = response.data;
            console.log($scope.currentUser);
            $scope.getSharedVideos($scope.currentUser);
            $scope.getFavoriteVideos($scope.currentUser);
        })
    }

    //Changes the ng-show in order for the User to update their name
    $scope.changeUsername = function () {
        $scope.updateUser = true;
    }

    //Changes the users Username
    $scope.updateUsername = function () {
        $scope.updateUser = false;
        userService.updateUser($scope.currentUser).then(function () {
            $http.get("http://localhost:5000/api/users/" + $scope.currentUser.id).then(function (response) {
                $scope.currentUser = response.data;
                userService.setCurrentUser($scope.currentUser);
                // console.log(this)
            }, function (error) {
                console.log(error);
            });
        })
        $state.go("user");
    }

    //Lets you open the side navbar and and stores the user you selected
    $scope.openNav = function (user) {
        $scope.userSelected = user;
        document.getElementById("myNav").style.width = "100%";
        console.log($scope.userSelected);
    }

    //Lets you close the side navbar
    $scope.closeNav = function () {
        document.getElementById("myNav").style.width = "0%";
    }

    //Lets a User login to our system by validating the User.
    $scope.login = function (user) {
        authService.login(user).then(function (response) {
            $scope.currentUser = response.data;
            userService.setCurrentUser($scope.currentUser);
            userService.getUsers().then(function (response) {
                $scope.users = response.data;
                console.log($scope.users);
            })
            userService.getUserById($scope.currentUser.id).then(function (response) {
                $scope.currentUser = response.data;
                console.log($scope.currentUser);
                $scope.getSharedVideos($scope.currentUser);
                $scope.getFavoriteVideos($scope.currentUser);
            });
        })
        $state.go("user");
    }
    //Lets a User logout of our System.
    $scope.logout = function () {
        authService.logout($scope.currentUser).then(function (response) {
            $scope.currentUser = null;
        })
    }

    //Lets a User register to our system.
    $scope.register = function (user) {
        var saveEmail;
        if (user == undefined) {
            $scope.InvalidEmail = true;
            $scope.InvalidPassword = true;
            $scope.InvalidUsername = true;
        }
        else {
            if (user.password == user.ConfirmPassword) {
                $scope.InvalidPassword = false;
            }
            else {
                $scope.InvalidPassword = true;
            }
            if (user.email.includes("@")) {
                $scope.InvalidEmail = false;
            }
            else {
                $scope.InvalidEmail = true;
            }
            for (var i = 0; i < $scope.users.length; i++) {
                if (user.Username == $scope.users[i].username) {
                    $scope.InvalidUsername = true;
                }
            }
            $scope.InvalidUsername = false;
            if ($scope.InvalidEmail == false && $scope.InvalidPassword == false && $scope.InvalidUsername == false) {
                console.log(user);
                authService.register(user).then(function (response) {
                    console.log(response);
                })
            }
        }
        $state.go("user");
    }

    //Lets a User delete one of their friends.
    $scope.deleteFriend = function () {
        var request = {};
        request.User = $scope.currentUser;
        request.fromUser = $scope.userSelected.username;
        document.getElementById("myNav").style.width = "0%";
        userService.deleteFriend(request).then(function () {
            $http.get("http://localhost:5000/api/users/" + $scope.currentUser.id).then(function (response) {
                $scope.currentUser = response.data;
                userService.setCurrentUser($scope.currentUser);
                // console.log(this)
            }, function (error) {
                console.log(error);
            });
        })
        $state.go("user");
    }

    //Lets a User send a friend request.
    $scope.sendFriendRequest = function () {
        var request = {};
        request.User = $scope.currentUser;
        request.fromUser = $scope.userSelected.username;
        document.getElementById("myNav").style.width = "0%";
        notificationsService.sendFriendRequest(request);
    }

    //Lets a User recieve a request.
    $scope.acceptFriendRequest = function (x) {
        var request = {};
        request.User = $scope.currentUser;
        request.fromUser = x.fromUser;
        request.Id = x.id;
        document.getElementById("myNav").style.width = "0%";
        notificationsService.acceptFriendRequest(request).then(function () {
            $http.get("http://localhost:5000/api/users/" + $scope.currentUser.id).then(function (response) {
                $scope.currentUser = response.data;
                userService.setCurrentUser($scope.currentUser);
                // console.log(this)
            }, function (error) {
                console.log(error);
            });
        })
        $state.go("user");
    }

    //Lets a User send a Direct Message.
    $scope.sendDirectMessage = function (message) {
        message.User = $scope.currentUser;
        message.fromUser = $scope.userSelected.username;
        document.getElementById("myNav").style.width = "0%";
        notificationsService.sendDirectMessage(message);
    }

    $scope.deleteDirectMessage = function (message) {
        message.User = $scope.currentUser;
        console.log(message)
        notificationsService.deleteDirectMessage(message).then(function () {
            $scope.currentUser = response.data;
        });
    }

    // Creates an array of trusted urls to embed video
    $scope.getSharedVideos = function (user) {
        userNotifications = user.notifications;
        console.log(userNotifications);
        $scope.sharedVideos = [];
        for (var i = 0; i < userNotifications.length; i++) {
            if (userNotifications[i].requestType == "SV") {
                url = $sce.trustAsResourceUrl("http://www.youtube.com/embed/" + userNotifications[i].videoId + "?rel=0&hd=1");
                $scope.sharedVideos.push(url);
            }
        }
    }

    // User's favorites are null, profile tab should update user
    $scope.getFavoriteVideos = function (user) {
        userFavorites = user.favorites
        $scope.favoriteVideos = [];
        console.log("Hey!");
        console.log($scope.favoriteVideos);
        for (var i = 0; i < userFavorites.length; i++) {
            url = $sce.trustAsResourceUrl("http://www.youtube.com/embed/" + userFavorites[i].video.id + "?rel=0&hd=1");
            $scope.favoriteVideos.push(url);
        }
    }
    $scope.deleteMessage = function (x) {
        $scope.currentUser.notifications.splice(x, 1);
    }

    $scope.openCity = function (evt, cityName) {
        // Declare all variables
        var i, tabcontent, tablinks;

        // Get all elements with class="tabcontent" and hide them
        tabcontent = document.getElementsByClassName("tabcontent");
        for (i = 0; i < tabcontent.length; i++) {
            tabcontent[i].style.display = "none";
        }

        // Get all elements with class="tablinks" and remove the class "active"
        tablinks = document.getElementsByClassName("tablinks");
        for (i = 0; i < tablinks.length; i++) {
            tablinks[i].className = tablinks[i].className.replace(" active", "");
        }

        // Show the current tab, and add an "active" class to the button that opened the tab
        document.getElementById(cityName).style.display = "block";
    }
})