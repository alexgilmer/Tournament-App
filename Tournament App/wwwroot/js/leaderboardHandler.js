// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

const teamListElem = document.getElementById("team-list");
setInterval(updateLeaderBoard, 5000);

function updateLeaderBoard() {
    $.ajax({
        type: "GET",
        url: "/Home/GetLeaderboardUpdate",
        contentType: false,
        processData: false,
        cache: false,
        success: leaderboardSuccess,
        error: leaderboardError
    });
}

function leaderboardSuccess(response) {
    const accordions = document.querySelectorAll(".accordion-item");
    for (let i = 0; i < response.teams.length; i++) {
        accordions[i].textContent = "";
        accordions[i].insertAdjacentHTML("afterbegin", getAccordionHtml(response.teams[i]));
    }
}

function leaderboardError(response) {
    console.log("Something broke: ", response);
}

function getAccordionHtml(team) {
    return `
    <h2 class="accordion-header" id="team-${team.id}">
        <button class="accordion-button" type="button" data-bs-toggle="collapse" data-bs-target="#team-collapsible-${team.id}" aria-expanded="true" aria-controls="panelsStayOpen-collapse${team.id}">
            ${team.name}:
            &nbsp;<strong>${team.pointsScored} Points</strong>
        </button>
    </h2>
    <div id="team-collapsible-${team.id}" class="accordion-collapse collapse show" aria-labelledby="team-${team.id}">
        <div class="accordion-body">
            ${
            team.members.map(m => `<span class="badge bg-info text-dark">${m.name}</span>`).join("")
            }
        </div>
    </div>`;
}