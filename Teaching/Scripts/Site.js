/// <reference path="jquery-3.4.1.intellisense.js" />

$.ready(function () {
    var loginScreen = document.getElementById(programKeyWords.LoginForm);
    var bearerToken = sessionStorage.getItem(programKeyWords.BearerToken);
    if (bearerToken) {
        loginScreen.style.display = "none";
    }
});
var programKeyWords = {
    LoginForm: "LoginForm",
    BearerToken: "BearerToken",
    Results: "sqlQueryResults",
    SqlInput: "sqlString"
}
var uriManager = {
    baseUrl : "api/values/",
    access: "accesstoken",
    Execute: () => uriManager.baseUrl + "Execute"

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
        beforeSend: function (request) {
            request.setRequestHeader("Authorization", bearer);
        },
        data: bodyOfRequest,
        success : function (response) {
            sessionStorage.setItem(programKeyWords.BearerToken, response.access_token);
            var loginScreen = document.getElementById(programKeyWords.LoginForm);
            if (bearerToken) {
                loginScreen.style.display = "none";
            }
        }
        
    });
}

function SendTransactionRequest() {
    let bearer = "Bearer " + sessionStorage.getItem(programKeyWords.BearerToken);
    let sqlString = document.getElementById(programKeyWords.SqlInput).value
    let requestContent = {
        InputType: "SQL",
        InputRequest: sqlString
    };
    $.post({
        url: uriManager.Execute(),
        beforeSend: function (request) {
            request.setRequestHeader("Authorization", bearer);
        },
        data: requestContent,
        success: function (response) {
            document.getElementById(programKeyWords.Results) = response.Results;
        }
    })
}