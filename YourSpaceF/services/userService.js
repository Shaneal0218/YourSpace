angular.module("spaceApp").service("userService", function($http) {

    var _currentUser;

    var that = this
    //Get all users from database
    this.getUsers = function() {
        return $http.get("http://localhost:5000/api/users")
    }

    this.getUserById = function(id) {
        return $http.get("http://localhost:5000/api/users/" + id)
    }

    this.getCurrentUser = function() {
        return _currentUser;
    }

    this.setCurrentUser = function(u) {
        _currentUser = u;
    }

    this.deleteFriend = function(request) {
        return $http.post("http://localhost:5000/api/deletefriend", request);
    }
    
    this.updateUser = function(user) {
        return $http.put("http://localhost:5000/api/users", user);
    }
})