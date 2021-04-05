"use strict";
var admin = $("#admin").val();
var connection = new signalR.HubConnectionBuilder().withUrl("/NotificationUserHub?admin=" + admin).build();
connection.on("SendStoreRegistrationToastrNotificationToAdmin", (sendStoreRegistrationToastrNotificationHubDetails) => {
    StoreRegistrationToastrNotification(sendStoreRegistrationToastrNotificationHubDetails);
});

connection.on("SendAddedOfferToastrNotificationToAdmin", (sendAddedOfferToastrNotificationHubDetails) => {
    AddedOfferToastrNotificationHubDetails(sendAddedOfferToastrNotificationHubDetails);
});

connection.start().catch(function (err) {
    return console.error(err.toString());
}).then(function () {
    //document.getElementById("user").innerHTML = "UserId:1 ";
    //connection.invoke('GetConnectionId').then(function (connectionId) {
    //    document.getElementById('signalRConnectionId').innerHTML = connectionId;
    //})
});