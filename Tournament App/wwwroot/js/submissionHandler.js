// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
const submissionForm = document.forms["team-submission"];
if (submissionForm) {
    submissionForm.addEventListener("submit", handleSubmission);
}

function handleSubmission(event) {
    event.preventDefault();
    const fd = new FormData(submissionForm);
    $.ajax({
        type: "POST",
        url: "/Puzzles/Submit",
        contentType: false,
        processData: false,
        cache: false,
        data: fd,
        success: successFunction,
        error: errorFunction
    });
}

function successFunction(response) {
    console.log(response);
}

function errorFunction(response) {
    console.log("Error function engaged.", response);
}