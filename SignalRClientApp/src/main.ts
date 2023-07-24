import './assets/main.css'

import { createApp } from 'vue'
import { createPinia } from 'pinia'
import axios from 'axios'
import * as signalR from '@microsoft/signalr'

import App from './App.vue'
import router from './router'
axios.defaults.baseURL = 'https://localhost:5001' // Replace with your ASP.NET Core API base URL

const connection = new signalR.HubConnectionBuilder()
    .withUrl('https://localhost:5001/hub') // Replace with your SignalR hub URL
    .build()

// Connect to the SignalR hub
connection.start().catch((err) => document.write(err))

const app = createApp(App)

app.provide("axios", axios)
app.provide("signalRConnection", connection)
app.use(createPinia())
app.use(router)

app.mount('#app')


