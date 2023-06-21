var chatterName = 'Visitor';

// Initialize the SignalR client
const connection = new signalR.HubConnectionBuilder()
    .withUrl("https://localhost:7114/chatHub")
    .configureLogging(signalR.LogLevel.Information)
    .build();

//console.log("1. First of All Connection will Created!--> ", connection)

// Connection on with the Server and Recieve Messages for the all clients.
connection.on('ReceiveMessages', renderMessage);

// Connection start
connection.start();

// When the DOM Content Loaded call ready function
document.addEventListener('DOMContentLoaded', ready);

// Ready function Open the dialog box and send the message to the Server Hub.
function ready() {

    setTimeout(showChatDialog, 750);

    var chatFormEl = document.getElementById('chatForm');

    //console.log("2. Second Ready function call and get the form by id!--> ", chatFormEl)

    chatFormEl.addEventListener('submit', function (e) {
        e.preventDefault();

        var text = e.target[0].value;

        console.log("4. Again ready function call to display text in the Chat Box using render message!--> ", text)

        e.target[0].value = '';
        sendMessage(text);
    })
}

// Will open the Chat Dialog box.
function showChatDialog() {
    var dialogEl = document.getElementById('chatDialog');

    console.log("3. ShowChatDialog function call to display chat box!--> ", dialogEl)

    dialogEl.style.display = 'block';
}

// sendMessage function to send message to the server
function sendMessage(text) {
    if (text && text.length) {
        console.log("5. sendMessage function call to send message to the server!--> ", text)
        connection.invoke('SendMessage', chatterName, text);
    }
}

// renderMessage function call to display text in the box for all the clients in the hub.
function renderMessage(name, time, message) {

    console.log("6. renderMessage function call to display text in the box:--> ")

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
