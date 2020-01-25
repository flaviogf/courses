$(document).ready(function () {
    var connection = $.hubConnection();

    var coffeeHub = connection.createHubProxy("coffeeHub");

    $("#order-form").on("submit", function (e) {
        e.preventDefault();

        var product = $(document.forms[0].product).val();
        var quantity = Number($(document.forms[0].quantity).val());

        coffeeHub.invoke("process", product, quantity);

        console.log("The form was submitted.");
    });

    coffeeHub.on("onOrderUpdated", function (data) {
        console.log("UpdatedOrder was executed.");
        console.log("The value received was " + data.State.Name + ".");

        var historyLine = $("<li>").text("Order Id: " + data.Id + ", Product: " + data.Product + ", Quantity: " + data.Quantity + ", State: " + data.State.Name);

        $("#history").append(historyLine);
    });

    connection.start();

    console.log("SignalR connections was established.");
});