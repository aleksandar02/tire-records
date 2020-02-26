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

    $('#dateFrom').datepicker('setDate', '-30d');
    $('#dateTo').datepicker('setDate', 'now');
});