$("#Title").on("input", (event) => {
    let inputText = event.target.value;
    if (!inputText)
        inputText = "Title Text";

    $(".notification-header").text(inputText);
});

$("#Text").on("input", (event) => {
    let inputText = event.target.value;
    if (!inputText)
        inputText = "Body text";

    $(".notification-content").text(inputText);
});

$("#HeaderColor").on("change", (event) => {
    $(".notification-header").css("background-color", event.target.value);
});

$(".color-sample").on("click", (event) => {
    const color = event.target.dataset.color;
    $("#HeaderColor").val(color);
    $("#HeaderColor").trigger("change");
})