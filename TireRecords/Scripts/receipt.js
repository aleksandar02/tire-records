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

    $('#dateFrom').datepicker("setDate", "-30d");
    $('#dateTo').datepicker('setDate', dateTo);

    $('#receiptCreatedPanel').click(function () {
        $('#msgPanel').fadeOut("fast");
    });

    $(".receiptDataTr").click(function () {
        var firstName = $(this)[0].children[0].innerHTML;
        var lastName = $(this)[0].children[1].innerHTML;

        var vehicleId = $(this)[0].children[5].children[0].attributes['data-vehicleid'].value;

        var firstAndLastName = firstName + " " + lastName;

        $("#clientFirstAndLastName").text(firstAndLastName);
        $("#hiddenVehicleId").text(vehicleId);
    });

    $("#addReceiptBtn").click(function () {
        var vehicleId = $("#hiddenVehicleId").text();

        location.href = `/Receipt/Create?id=${vehicleId}`;
    });
});