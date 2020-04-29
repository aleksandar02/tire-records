$(function () {
    $('#receiptTable').DataTable({
        processing: true,
        language: {
            search: '',
            zeroRecords: 'Nema rezultata!',
            paginate: {
                first: 'Prvi',
                last: 'Poslednji',
                next: 'Sledeci',
                previous: 'Prethodni'
            }
        },
        pageLength: 10,
        lengthChange: false,
        info: false,
        bFilter: false,
        bSort: false

    });

    var dateTo = new Date();
    dateTo.setDate(dateTo.getDate() + 1);

    $('.dateFrom').datepicker({
        format: 'dd.mm.yyyy.'
    });

    $('.dateFrom').datepicker("setDate", "-30d");

    $('.dateTo').datepicker({
        format: 'dd.mm.yyyy.'
    });

    $('.dateTo').datepicker("setDate", dateTo);

    $('#receiptCreatedPanel').click(function () {
        $('#msgPanel').fadeOut("fast");
    });

    $(".redirectToCreateReceiptBtn").click(function () {
        var firstName = $(this).attr("data-firstname");
        var lastName = $(this).attr("data-lastname");
        var vehicleId = $(this).attr("data-vehicleid");
        var vehicleType = $(this).attr("data-vehicletype");

        var firstAndLastName = firstName + " " + lastName;
        console.log(vehicleType);

        $("#clientFirstAndLastName").text(firstAndLastName);
        $("#hiddenVehicleId").text(vehicleId);
        $("#hiddenVehicleType").text(vehicleType);
    });

    $("#addReceiptBtn").click(function () {
        var vehicleId = $("#hiddenVehicleId").text();
        var vehicleType = $("#hiddenVehicleType").text();

        console.log(vehicleId, vehicleType);

        location.href = `/Receipt/Create?id=${vehicleId}&type=${vehicleType}`;
    });
});
