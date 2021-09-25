function SubmitMessage() {
    var hello = $("#aLuigMessage")[0].textContent;
    $.post(
        "Contact/Submit",
        hello
    );
    alert(hello);
}