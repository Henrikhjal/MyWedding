(function () {
    "use strict";

    angular.module("app-guestbook").controller("guestbookController", guestbookController);

    function guestbookController($scope, $http) {

        $scope.addMessage = function () {
            $scope.newMessage.Date = new Date();
            $scope.newMessage.Public = 1;
            $http.post("/api/guestBookMessages", $scope.newMessage).then(onGuestBookMessagesCompletePost, onError).finally(onFinally);
        };

        var onGuestBookMessagesCompleteGet = function (response) {
            $scope.Messages = response.data;
        }

        var onGuestBookMessagesCompletePost = function (response) {
            $scope.Messages.push(response.data);
        }

        var onFinally = function () {
            $scope.newMessage.MessageText = "";
            $http.get("/api/guestBookMessages").then(onGuestBookMessagesCompleteGet, onError);
        }

        var onError = function (reason) {
            $scope.errorMessage = "An error occured in communication with the service for the guestbook";
        }

        $http.get("/api/guestBookMessages").then(onGuestBookMessagesCompleteGet, onError);
    }

})();

