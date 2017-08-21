var counter;

$(document).ready(function() {
    var time = location.hash.substring(1);

    $(".timer").text(time);

    $(".button.next").attr("href", $(".button.next").attr("href") + "#" + time);

    $(".button.prev").click(function() {
        history.back();
    })

    $(".button.stop").click(function() {
        clearTimeout(counter);
    })

    $(".button.start").click(function() {
        countdown();
    })

    $(".button.reset").click(function() {
        $(".timer").text(time);
    })

    countdown();
});

function countdown() {
    var timer = $(".timer");
    var time = timer.text();
    counter = setTimeout(countdown, 1000);
    time--;
    timer.text(time);

    if (time <= 0) {
        var url = window.location.pathname;
        var filename = url.substring(url.lastIndexOf('/') + 1);

        if (filename !== "4.html") {
            location.href = $(".button.next").attr("href");
        }

        if (confirm("Перейти к начальной странице?") == true) {
            location.href = $(".button.next").attr("href");
        } else {
            clearTimeout(counter);
        }
    }
}