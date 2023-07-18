<script setup lang="ts">
import * as signalR from "@microsoft/signalr";

// const divMessages: HTMLDivElement = document.querySelector("#divMessages");
// const tbMessage: HTMLInputElement = document.querySelector("#tbMessage");
// const btnSend: HTMLButtonElement = document.querySelector("#btnSend");
const username = new Date().getTime();

const connection = new signalR.HubConnectionBuilder()
    .withUrl("/hub")
    .build();

connection.on("ReceiveMessage", (username: string, message: string) => {
    // const m = document.createElement("div");

    // m.innerHTML = `<div class="message-author">${username}</div><div>${message}</div>`;

    // divMessages.appendChild(m);
    // divMessages.scrollTop = divMessages.scrollHeight;
});

//connection.on("GetMessage", async () => {
//    let promise = new Promise((resolve, reject) => {
//        setTimeout(() => {
//            resolve("message");
//        }, 100);
//    });
//    return promise;
//});

connection.start().catch((err) => document.write(err));

// tbMessage.addEventListener("keyup", (e: KeyboardEvent) => {
//     if (e.key === "Enter") {
//         send();
//     }
// });

// btnSend.addEventListener("click", send);

function send() {
    connection.send("SendMessage", username.toString(), 'Sample message')
        // .then(() => (tbMessage.value = ""));
}
</script>

<template>
  <main>
    <div class="main-chat w-full bg-slate-700">
      <div class="main-container">
        <div class="sidebar">
            <h2>Groups Chat</h2>
            <ul class="group-list">
                <li class="group-item">Group 1</li>
                <li class="group-item">Group 2</li>
                <li class="group-item">Group 3</li>
                <li class="group-item">Group 4</li>
            </ul>
        </div>

        <div class="message-field">
            <div id="divMessages" class="messages"></div>
            <div class="input-zone">
                <label id="lblMessage" for="tbMessage">Message:</label>
                <input id="tbMessage" class="input-zone-input" type="text" />
                <button id="btnSend">Send</button>
            </div>
        </div>
      </div>
    </div>
  </main>
</template>
