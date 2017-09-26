
var chatApp = angular.module("chatApp", ["ngRoute"]);
var baseApiUrl = "http://localhost:57627/";
var baseUrl = "http://localhost:57627/";
var chat;


chatApp.config(function ($routeProvider) {

        $routeProvider
            .when("/preChatWindow",
                {
                    templateUrl: "/app.client/chatWindow/preChatQuestion.html",
                    controller: "preChatController"
                })
        .when("/chatWindow",
            {
                templateUrl: "/app.client/chatWindow/chatWindow.html",
                controller: "chatController"
            })
        .otherwise("/preChatWindow");
});

chatApp.controller("chatController",['$scope',function($scope) {

    // Create a function that the hub can call back to display messages.
    chat.client.receiveMessage = function (name, message) {

        // Add the message to the page.
        appendMessageToChatList(name, message, false);
    };

    // Start the connection.
    $.connection.hub.start().done(function () {

        $('#btn-chat-send').click(function () {

            var name = $('#inputName').val();
            var message = $('#inputMessage').val();

            chat.server.send(name, message);

            // Clear text box and reset focus for next comment.
            appendMessageToChatList(name, message, true);

            $('#inputMessage').val('').focus();

        });
    });

}]);

chatApp.controller("preChatController", ['$scope', '$http', '$location', function ($scope, $http, $location) {


    // Reference the auto-generated proxy for the hub.
    chat = $.connection.letsChatHub;

    $scope.preChatQuestions = {
        name: "Irfan",
        emailAddress: "irfanakhtar345@hotmail.com",
        reason: "billing"
    };


    $scope.preChatSave = function (preChatQuestions) {



        // Start the connection.
        $.connection.hub.start().done(function () {

            debugger;
            chat.server.preChat(preChatQuestions);

                // Clear text box and reset focus for next comment.  
        });


        $location.path('/chatWindow');
    };




}]);



// This optional function html-encodes messages for display in the page.
function htmlEncode(value) {
    var encodedValue = $('<div />').text(value).html();
    return encodedValue;
}
function appendMessageToChatList(name, message, isFromMe) {
    var fromattedessage = '';
    if (isFromMe === true)
        fromattedessage = messageFormatSentFromYou(name, message);
    else 
        fromattedessage = messageFormatComeFromOther(name, message);

    if (fromattedessage !== '')
        $('#ulchatLit').append(fromattedessage);
}
function messageFormatComeFromOther(name, message) {

    var receiveMessageTag = "<li class=\"left clearfix\"><span class=\"chat-img pull-left\">" +
        "<img src=\"http://placehold.it/50/55C1E7/fff&text=U\" alt=\"User Avatar\" class=\"img-circle\" />" +
        "</span>" +
        "<div class=\"chat-body clearfix\">" +
        "<div class=\"header\">" +
        "<strong class=\"primary-font\">" + htmlEncode(name)+"</strong> <small class=\"pull-right text-muted\">" +
        "<span class=\"glyphicon glyphicon-time\"></span>Time</small>" +
        "</div>" +
        "<p>" + htmlEncode(message)+"</p>" +
        "</div>" +
        "</li>";
    return receiveMessageTag;
}

function messageFormatSentFromYou(name, message) {

    var formateMessage = "<li class=\"right clearfix\"><span class=\"chat-img pull-right\">" +
        "<img src=\"http://placehold.it/50/FA6F57/fff&text=ME\" alt=\"User Avatar\" class=\"img-circle\" />" +
        "</span>" +
        "<div class=\"chat-body clearfix\">" +
        "<div class=\"header\">" +
        "<small class=\"text-muted\"><span class=\"glyphicon glyphicon-time\"></span>Time</small>" +
        "<strong class=\"pull-right primary-font\">" + htmlEncode(name)+"</strong>" +
        "</div>" +
        "<p>" + htmlEncode(message)+"</p>" +
        "</div>" +
        "</li>";
    return formateMessage;
}



