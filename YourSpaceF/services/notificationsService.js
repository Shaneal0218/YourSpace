app.service("notificationsService", function($http) {

    //Direct Messages
    this.sendDirectMessage = function(DM) {
        return $http.post("http://localhost:5000/api/notifications/directmessage", DM);
    }

    this.deleteDirectMessage = function(DM) {
        return $http.delete("http://localhost:5000/api/notifications/directmessage/delete", DM)
    }
    
    //Friend Requests
    this.sendFriendRequest = function(FR) {
        return $http.post("http://localhost:5000/api/notifications/friendrequest", FR);
    }

    this.acceptFriendRequest = function(request) {
        return $http.post("http://localhost:5000/api/friendrequest/accept", request);
    }
    this.deleteMessage = function(message) {
        return $http.post("http://localhost:5000/api/notifications/message/delete", message);
    }
})