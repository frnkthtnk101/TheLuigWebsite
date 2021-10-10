/// <reference path="jquery-3.4.1.intellisense.js" />

var uriManager = {
    baseUrl : "api/values/",
    access: "accesstoken"

}

function Authorize() {
    let bearer = "Basic Q01JUzMwOERTMzA4OndlYkFQSQ=="
    var email = document.getElementById("email").value;
    var password = document.getElementById("password").value;
    var bodyOfRequest = {
        grant_type: "password",
        username: email,
        password: password
    };
    $.ajax({
        type: "POST",
        url: uriManager.access,
        //contentType: 'application/json',
       // dataType: 'json',
        beforeSend: function (request) {
            request.setRequestHeader("Authorization", bearer);
        },
        data: bodyOfRequest,//JSON.stringify(bodyOfRequest),
        success : function (response) {
            sessionStorage.setItem("access", response.access_token);
        }
    });
}