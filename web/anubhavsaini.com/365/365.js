$(function () {
    AYOM = {};
    AYOM.GenerateGreetingSite001 = function () {
        var greeting = $("#Greeting").val();
        
        var fontFamily = $("#FontFamily").val();
        var fontSize = $("#FontSize").val();
        var fontSizeUnit = $("#FontSizeUnit").val();
        var backgroundColor = $('#BackgroundColor').val();
        var color = $('#Color').val();
        $("#GreetingOutput").text(greeting).css("font-family", fontFamily).css("font-size", fontSize + fontSizeUnit)
        .css("background-color", backgroundColor)
        .css("color", color);
    };
});
