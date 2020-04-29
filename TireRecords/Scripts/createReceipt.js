$(document).ready(function () {
    var vehicleBrands = [
        "Abarth",
        "Alfa Romeo",
        "Aston Martin",
        "Audi",
        "Bentley",
        "BMW",
        "Bugatti",
        "Cadillac",
        "Chevrolet",
        "Chrysler",
        "Citroën",
        "Dacia",
        "Daewoo",
        "Daihatsu",
        "Dodge",
        "Donkervoort",
        "DS",
        "Ferrari",
        "Fiat",
        "Fisker",
        "Ford",
        "Honda",
        "Hummer",
        "Hyundai",
        "Infiniti",
        "Iveco",
        "Jaguar",
        "Jeep",
        "Kia",
        "KTM",
        "Lada",
        "Lamborghini",
        "Lancia",
        "Land Rover",
        "Landwind",
        "Lexus",
        "Lotus",
        "Maserati",
        "Maybach",
        "Mazda",
        "McLaren",
        "Mercedes-Benz",
        "MG",
        "Mini",
        "Mitsubishi",
        "Morgan",
        "Nissan",
        "Opel",
        "Peugeot",
        "Porsche",
        "Renault",
        "Rolls-Royce",
        "Rover",
        "Saab",
        "Seat",
        "Skoda",
        "Smart",
        "SsangYong",
        "Subaru",
        "Suzuki",
        "Tesla",
        "Toyota",
        "Volkswagen",
        "Volvo"
    ];

    var container = $('#vehicleBrandPicker');

    $.each(vehicleBrands, function (index, item) {
        container.append(`<option value="${item.trim()}">
                                       ${item.trim()}
                                  </option>`);
    });

    $('.selectpicker').selectpicker({
        liveSearch: true,
        showSubtext: true,
        noneResultsText: "Nema rezultata!",
        noneSelectedText: "Marka"
    });

    $('.selectpicker').selectpicker('val', $("#vehicleBrandHidden").val())

    $('.copy-tire').click(function () {
        var id = $(this).closest('.row').attr('id');

        var source = $('#' + id + ' input');
        var rows = $('#tireSection .row');

        copyToNextRow(source, rows);
    });

    function copyToNextRow(source, rows) {
        for (var i = 0; i < 4; i++) {
            if (rows[i].children[1].children[0].value === '') {

                for (var j = 1; j < 7; j++) {
                    rows[i].children[j].children[0].value = source[j].value;
                }

                return;
            }
        }
    }
});