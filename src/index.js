"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
var signalR = require("@microsoft/signalr");
require("./css/main.css");
var divMessages = document.querySelector("#divMessages");
var tbMessage = document.querySelector("#tbMessage");
var btnSend = document.querySelector("#btnSend");
var username = new Date().getTime();
var connection = new signalR.HubConnectionBuilder()
    .withUrl("/hub")
    .build();
connection.on("ReceiveMessage", function (username, message) {
    var m = document.createElement("div");
    m.innerHTML = "<div class=\"message-author\">".concat(username, "</div><div>").concat(message, "</div>");
    divMessages.appendChild(m);
    divMessages.scrollTop = divMessages.scrollHeight;
});
//connection.on("GetMessage", async () => {
//    let promise = new Promise((resolve, reject) => {
//        setTimeout(() => {
//            resolve("message");
//        }, 100);
//    });
//    return promise;
//});
connection.start().catch(function (err) { return document.write(err); });
tbMessage.addEventListener("keyup", function (e) {
    if (e.key === "Enter") {
        send();
    }
});
btnSend.addEventListener("click", send);
function send() {
    connection.send("SendMessage", username.toString(), tbMessage.value)
        .then(function () { return (tbMessage.value = ""); });
}
