$(document).ready(function() {
    $(".transfer-right").click(function() {
        $(this).parents(".transfer-select").find("select.left option:selected").remove()
            .appendTo($(this).parents(".transfer-select").children("select.right")).prop("selected", false);
    });
    $(".transfer-left").click(function() {
        $(this).parents(".transfer-select").find("select.right option:selected").remove()
            .appendTo($(this).parents(".transfer-select").children("select.left")).prop("selected", false);
    });
    $(".transfer-right-all").click(function() {
        $(this).parents(".transfer-select").find("select.left option").remove()
            .appendTo($(this).parents(".transfer-select").children("select.right")).prop("selected", false);
    });
    $(".transfer-left-all").click(function() {
        $(this).parents(".transfer-select").find("select.right option").remove()
            .appendTo($(this).parents(".transfer-select").children("select.left")).prop("selected", false);
    });
});