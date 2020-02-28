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
});