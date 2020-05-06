jQuery.validator.addMethod("lettersonly", function (value, element) {
    return this.optional(element) || /^[a-z ]+$/i.test(value);
}, "Dozvoljena su samo slova!");

$('#createReceiptForm').validate({
    rules: {
        firstName: {
            required: true,
            lettersonly: true,
            minlength: 2,
            maxlength: 50

        },
        lastName: {
            required: true,
            lettersonly: true,
            minlength: 2,
            maxlength: 50
        },
        mobilePhone: {
            required: true,
            digits: true,
            maxlength: 12
        },
        email: {
            required: true,
            maxlength: 128,
            email: true
        },
        vehicleBrandPicker: {
            required: true
        },
        registrationNumber: {
            required: true,
            maxlength: 128
        }
    },
    messages: {
        firstName: {
            required: 'Obavezno polje!',
            minlength: 'Ime mora imati vise od 2 slova!',
            maxlength: 'Dozvoljeno 50 slova!'
        },
        lastName: {
            required: 'Obavezno polje!',
            minlength: 'Prezime mora imati vise od 2 slova!',
            maxlength: 'Dozvoljeno 50 slova!'
        },
        mobilePhone: {
            required: 'Obavezno polje!',
            maxlength: 'Dozvoljeno 12 cifara!',
            digits: 'Dozvoljeni su samo brojevi!'
        },
        email: {
            required: 'Obavezno polje!',
            maxlength: 'Dozvoljeno 128 karaktera!',
            email: 'Unesite validnu email adresu!'
        },
        vehicleBrandPicker: {
            required: 'Obavezno polje!'
        },
        registrationNumber: {
            required: 'Obavezno polje!',
            maxlength: 'Dozvoljeno 128 karaktera!'
        }
    }
});