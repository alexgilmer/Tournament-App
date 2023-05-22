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
    const toastContainer = document.querySelector(".toast-container");
    toastContainer.insertAdjacentHTML("beforeend", getToastHtml(response));
    showLatestToast();
}

function errorFunction(response) {
    console.log("Error function engaged.", response);
}

function getToastHtml(data) {
    // success(green), warning(yellow), danger(red)
    let bgColor = "success";
    let textColor = "white";

    if (!data.validCode) {
        bgColor = "warning";
        textColor = "dark"
    }

    if (data.pointsAwarded < 0) {
        bgColor = "danger";
        textColor = "white";
    }

    //data.ValidCode;
    //data.AnswerName;
    //data.PointsAwarded;
    //data.Message;

    return `
    <div class="toast" role="alert" aria-live="assertive" aria-atomic="true">
        <div class="toast-header bg-${bgColor} text-${textColor}">
          <strong class="me-auto">${data.answerName}</strong>
          <small class="text-${textColor}">${data.pointsAwarded} points</small>
          <button type="button" class="btn-close" data-bs-dismiss="toast" aria-label="Close"></button>
        </div>
        <div class="toast-body">
          ${data.message}
        </div>
     </div>`;
}

function showLatestToast() {
    const toastElem = document.querySelector(".toast-container .toast:last-of-type");
    const toast = new bootstrap.Toast(toastElem);
    toast.show();
}