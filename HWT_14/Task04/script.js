$(document).ready(function() {
    $(".button.begin").click(function() {
        var time = $(".time-input").val();
        $(this).attr("href", $(this).attr("href") + "#" + time);
    });
});