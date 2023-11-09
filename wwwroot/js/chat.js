"use strict";

var connection = new signalR.HubConnectionBuilder().withUrl("/ReviewHub").build();

//Disable the send button until connection is established.
document.getElementById("sendButton").disabled = true;


var selectedRating = 0; // Stores the selected rating

// Add event listeners to the star elements
var stars = document.querySelectorAll(".star");
stars.forEach(function (star) {
    star.addEventListener("click", function () {
        var rating = parseInt(this.dataset.rating);
        selectRating(rating);
    });
});

// Function to select the rating
function selectRating(rating) {
    selectedRating = rating;
    highlightStars(rating);
}

// Function to highlight the selected stars
function highlightStars(rating) {
    stars.forEach(function (star) {
        var starRating = parseInt(star.dataset.rating);
        if (starRating <= rating) {
            star.classList.add("filled");
        } else {
            star.classList.remove("filled");
        }
    });
}

connection.on("ReceiveMessage", function (name, review,rating) {
    var li = document.createElement("li");
    li.className = "line";
    document.getElementById("messagesList").appendChild(li);

    var nameElement = document.createElement("span");
    nameElement.className = "review-name";
    nameElement.textContent = name;
    li.appendChild(nameElement);

    var ratingElement = document.createElement("span");
    ratingElement.className = "review-rating";
    ratingElement.innerHTML = generateStarRating(rating);
    li.appendChild(ratingElement);

    var messageElement = document.createElement("span");
    messageElement.className = "review-message";
    messageElement.textContent = review;
    li.appendChild(messageElement);



 

});

function generateStarRating(rating) {
    var starsHtml = "";
    for (var i = 1; i <= 5; i++) {
        var starClass = i <= rating ? "filled" : "";
        starsHtml += `<span class="star ${starClass}"></span>`;
    }
    return starsHtml;
}


connection.start().then(function () {
    document.getElementById("sendButton").disabled = false;
}).catch(function (err) {
    return console.error(err.toString());
});

document.getElementById("sendButton").addEventListener("click", function (event) {
    var message = document.getElementById("msg").value;
    var name = document.getElementById("name").value;
    var rating = selectedRating///getting the msg we got using form in index.cshtml
    connection.invoke("SendMessage",name, message,rating).catch(function (err) {////sending the message to server side(Myhub SendMessage method)
        return console.error(err.toString());
    });
    event.preventDefault();
});