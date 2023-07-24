<script setup lang="ts">
import { inject, onMounted } from 'vue';

const signalRConnection: any = inject('signalRConnection');
  // export default {
  //   mounted() {
  //     const connection = this.$signalRConnection;
  //     connection.on('ReceiveMessage', (user, message) => {
  //       console.log(`Received message from ${user}: ${message}`);
  //     });
  //   },
  //   methods: {
  //     sendMessage() {
  //       const connection = this.$signalRConnection;
  //       connection.invoke('SendMessage', 'John', 'Hello from Vue.js');
  //     },
  //   },
  // };

const sendMessage = () => {
  const connection = signalRConnection;
  connection.invoke('SendMessage', 'Phu Nguyen', 'Hello from Vue.js');
}

onMounted(() => {
  const connection = signalRConnection;
  connection.on('ReceiveMessage', (user: string, message: string) => {
    console.log(`Received message from ${user}: ${message}`);
  })
})
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
                <button :click="sendMessage" id="btnSend">Send</button>
            </div>
        </div>
      </div>
    </div>
  </main>
</template>
