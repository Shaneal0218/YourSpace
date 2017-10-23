app.service("authService", function ($http) {
    this.currentUser = null;

    this.login = function(user) {
        return $http.post("http://localhost:5000/api/account/signin", user);
    }

    this.logout = function(user) {
        return $http.post("http://localhost:5000/api/account/signout", user);
    }

    this.register = function(user) {
        return $http.post("http://localhost:5000/api/users", user);
    }
    
})