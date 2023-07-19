(function () {
    setInterval(updateNotifications, 5000);

    function updateNotifications() {
        $.ajax({
            type: "GET",
            url: "/Home/GetNotifications",
            contentType: false,
            processData: false,
            cache: false,
            success: notificationSuccess,
            error: notificationError
        });
    }

    function notificationSuccess(response) {
        $("#notification-container").html(response);
    }

    function notificationError(response) {
        console.log("Something broke: ", response);
    }

})();