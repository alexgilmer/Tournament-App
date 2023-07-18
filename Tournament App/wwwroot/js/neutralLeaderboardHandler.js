// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

(function () {
    setInterval(updateLeaderBoard, 5000);

    function updateLeaderBoard() {
        $.ajax({
            type: "GET",
            url: "/Home/GetNeutralLeaderboardUpdate",
            contentType: false,
            processData: false,
            cache: false,
            success: leaderboardSuccess,
            error: leaderboardError
        });
    }

    function leaderboardSuccess(response) {
        $("#partial-container").html(response);
    }

    function leaderboardError(response) {
        console.log("Something broke: ", response);
    }
})();
