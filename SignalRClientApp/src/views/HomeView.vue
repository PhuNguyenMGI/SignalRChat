<script setup lang="ts">
import { inject, onMounted, ref } from 'vue';

const signalRConnection: any = inject('signalRConnection');
const connection = signalRConnection;
const inputMessage = ref('');

const sendMessage = () => {
  connection.invoke('SendMessage', 'Phu Nguyen', inputMessage.value);
  inputMessage.value = '';
}

onMounted(() => {
  const divMessages: HTMLDivElement = document.querySelector("#divMessages");
  connection.on('ReceiveMessage', (user: string, message: string) => {
    const m = document.createElement("div");

    m.innerHTML = `<div class="message-author">${user}</div><div>${message}</div>`;

    divMessages.appendChild(m);
    divMessages.scrollTop = divMessages.scrollHeight;
  })
})
</script>

<template>
  <main>
    <div class="main-chat w-full">
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
                <input id="tbMessage" class="input-zone-input" type="text" v-model="inputMessage" />
                <button @click="sendMessage" id="btnSend">Send</button>
            </div>
        </div>
      </div>
    </div>
  </main>
</template>
