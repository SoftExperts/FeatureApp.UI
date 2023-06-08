﻿var chatterName = 'Visitor';

// Initialize the SignalR client
const connection = new signalR.HubConnectionBuilder()
    .withUrl("https://localhost:7114/chatHub")
    .configureLogging(signalR.LogLevel.Information)
    .build();

console.log("connection log: ", connection)

connection.on('ReceiveMessage', renderMessage);

connection.start();

function showChatDialog() {
    var dialogEl = document.getElementById('chatDialog');
    dialogEl.style.display = 'block';
}

function sendMessage(text) {
    if (text && text.length) {
        connection.invoke('SendMessage', chatterName, text);
    }
}

function ready() {
    setTimeout(showChatDialog, 750);

    var chatFormEl = document.getElementById('chatForm');
    chatFormEl.addEventListener('submit', function (e) {
        e.preventDefault();

        var text = e.target[0].value;
        e.target[0].value = '';
        sendMessage(text);
    })
}
document.addEventListener('DOMContentLoaded', ready);

function renderMessage(name, time, message) {
    var nameSpan = document.createElement('span');
    nameSpan.className = 'name';
    nameSpan.textContent = name;

    var timeSpan = document.createElement('span');
    timeSpan.className = 'time';
    var friendlyTime = moment(time).format('H:mm');
    timeSpan.textContent = friendlyTime;

    var headerDiv = document.createElement('div');
    headerDiv.appendChild(nameSpan);
    headerDiv.appendChild(timeSpan);

    var messageDiv = document.createElement('div');
    messageDiv.className = 'message';
    messageDiv.textContent = message;

    var newItem = document.createElement('li');
    newItem.appendChild(headerDiv);
    newItem.appendChild(messageDiv);

    var chatHistoryEl = document.getElementById('chatHistory');
    chatHistoryEl.appendChild(newItem);
    chatHistoryEl.scrollTop = chatHistoryEl.scrollHeight - chatHistoryEl.clientHeight;
}