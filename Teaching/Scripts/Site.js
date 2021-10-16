/// <reference path="jquery-3.4.1.intellisense.js" />

$(window).ready(function () {
    var loginScreen = document.getElementById(programKeyWords.LoginForm);
    var bearerToken = sessionStorage.getItem(programKeyWords.BearerToken);
    if (!bearerToken) {
        ShowModal();
    }

});
var programKeyWords = {
    LoginForm: "LoginForm",
    BearerToken: "BearerToken",
    Results: "sqlQueryResults",
    SqlInput: "sqlString"
}
var uriManager = {
    baseUrl: "api/values/",
    access: "accesstoken",
    Execute: () => uriManager.baseUrl + "Execute"

}
function ShowModal() {
    var modalOptions = {
        backdrop: 'static',
        keyboard: false,
        focus: true,
        show: true
    };
    $('#LogonModal').modal(modalOptions);
}
function Authorize() {
    let bearer = "Basic Q01JUzMwOERTMzA4OndlYkFQSQ=="
    var email = document.getElementById("email").value;
    var password = document.getElementById("password").value;
    var userNameAndPasswordFilled = (email != "" && password != "");
    if (!userNameAndPasswordFilled) {
        $("#formError").show('fast');
    }
    else {
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
            success: function (response) {
                sessionStorage.setItem(programKeyWords.BearerToken, response.access_token);
                $('#LogonModal').modal('hide');
            },
            error: function (response) {
                $("#formError").show('fast');
            }
        });
    }
}

function SendTransactionRequest() {
    let bearer = "Bearer " + sessionStorage.getItem(programKeyWords.BearerToken);
    let sqlString = document.getElementById(programKeyWords.SqlInput).value
    let requestContent = {
        InputType: "SQL",
        InputRequest: sqlString
    };
    $.ajax({
        type: "POST",
        url: uriManager.Execute(),
        beforeSend: function (request) {
            request.setRequestHeader("Authorization", bearer);
        },
        data: requestContent,
        success: function (response) {

            var keys = Object.keys(response[0]);
            var tableBody = $("#sqlQueryResults tbody");
            var tableHeader = $("#sqlQueryResults thead");
            tableBody.remove();
            tableHeader.remove();
            var table = $("#sqlQueryResults");
            table.append('<thead></thead>');
            table.append('<tbody></tbody>');
            tableHeader = $("#sqlQueryResults thead");
            tableBody = $("#sqlQueryResults tbody");
            let tableRow = "<tr>"
            keys.forEach((key) => {
                tableRow += "<td scope='col'>" + key + "</td>"
            });
            tableRow += "</tr>"
            tableHeader.append(tableRow);
            response.forEach((element) => {
                let tableRow = "<tr>"
                keys.forEach((key) => {
                    tableRow += "<td>" + element[key] + "</td>"
                })
                tableRow += "</tr>"
                tableBody.append(tableRow);
            });

        },
        error: function (response) {
            ShowModal();
            localStorage.setItem("sqlPlayground", JSON.stringify(response));
        }
    })
}