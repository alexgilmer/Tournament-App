const formElem = document.querySelector("form#code-form");
const codeElem = document.querySelector("textarea#code");
let submissionInProgress = false;

formElem.addEventListener("submit", (e) => {
    e.preventDefault();

    if (!submissionInProgress) {
        submissionInProgress = true;

        startSpinner("yellow");

        const codeSubmission = codeElem.value; 

        $.ajax({
            type: "POST",
            url: formElem.action,
            cache: false,
            data: { code: codeSubmission },
            success: handleResponse,
            error: handleError
        });
    }
});

function handleResponse(response) {
    submissionInProgress = false;

    const responseContainerElem = document.querySelector("#response-container");
    if (responseContainerElem) {
        responseContainerElem.innerHTML = response;
    } else {
        throw "Container element not found";
    }
}

function handleError(response) {
    submissionInProgress = false;
    console.log(response);
}

function startSpinner() {
    const colorIndicatorElem = document.querySelector("#color-indicator");
    colorIndicatorElem.classList.remove("no-test", "pass");
    colorIndicatorElem.classList.add("in-progress");
}