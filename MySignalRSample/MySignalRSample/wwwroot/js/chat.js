"use strict";
var connection = new signalR.HubConnectionBuilder().withUrl("/chathub").build();
document.getElementById("Sendmessage").disabled = true;
connection.on("ReceivedMessage",function (username, message) {
    var li = document.createElement("li");
    li.textContent = `${username}: ${message}`;
    document.getElementById("messages").appendChild(li);
    
});
connection.start().then(function () {
    document.getElementById("Sendmessage").disabled = false;
}).catch(function (err) {
    return console.error(err.toString());
});

document.getElementById("Sendmessage").addEventListener("click", function (event) {
    var username = document.getElementById("userName").value;
    var message = document.getElementById("message").value;
    connection.invoke("SendMessage", username, message).catch(function (err) {
        return console.error(err.toString());
    });
    event.preventDefault();
});