/// <reference path="jquery-3.4.1.intellisense.js" />

var uriManager = {
    var baseUrl = "/api/values/";
    var access = "/accesstoken";

}

function Authorize() {
    let bearer = "bearer Q01JUzMwOERTMzA4OndlYkFQSQ=="
    var email = document.getElementById("email").value;
    var password = document.getElementById("password").value;
    var bodyOfRequest = {
        grant_type: "password",
        username: email,
        password: password
    };
    $.ajax({
        url: uriManager.access,
        beforeSend: function (request) {
            request.setRequestHeader("Authorization", bearer);
        },
        data = JSON.stringify(bodyOfRequest),
        success = function (response) {
            sessionStorage.setItem("access", response);
        }
    });
}