// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
// Parameters

var map;
var infowindow;
var prefecture;
var shoppings = [];

$(function () {

    $("#adicionar").click(function () {

        addRoute();
    });

    $("#trajeto").click(function () {

        getShoppings((data) => {

            var waypts = wayPoints(data);
            var end = endRoute(data);
            clearInfowindow();
            calcRoute(waypts, end);
        });
    });

    $("#HoraAbertura").keyup(function () {

        $("#HoraAbertura").mask("99:99");
    });

    $("#HoraFechamento").keyup(function () {

        $("#HoraFechamento").mask("99:99");
    });   

});

function initMap() {

    prefecture = new google.maps.LatLng(-22.911081, -43.205794);

    map = new google.maps.Map(document.getElementById("map"), {
        center: prefecture,
        zoom: 15,
    });
}

function addRoute() {

    var value = $("#shopping").val();
    var text = $("#shopping option:selected").text();

    if (!(shoppings.indexOf(value) > -1)) {

        shoppings.push(value);

        var content = `<tr id="${value}"><td>"${text}"</td></tr>`;
        $('#tabelaShoppings tbody').append(content);
    }
}

function getShoppings(callback) {

    $.get("Home/GetShopping", function (data) {

        callback(data);
    });
}

function wayPoints(data) {

    var waypts = [];

    for (let i = 0; i < shoppings.length - 1; i++) {

        var shopping = data.find(x => x.id == shoppings[i]);

        waypts.push({
            location: shopping.endereco,
            stopover: true,
        });

        infowindows(shopping);
    }

    return waypts;
}

function endRoute(data) {

    var shopping = data.find(x => x.id == shoppings.slice(-1)[0]);

    infowindows(shopping);

    return shopping.endereco;
}

function infowindows(shopping) {

    geocoder = new google.maps.Geocoder();

    if (geocoder) {
        geocoder.geocode({ address: shopping.endereco }, function (results, status) {
            if (status === 'OK') {

                var content =
                    "<div>" +
                    "<h5>" + shopping.nome + "</h5>" +
                    "<div>" +
                    "<b>Endereço: </b>" + shopping.endereco +
                    "</div>" +
                    "<div>" +
                    "<b>Hora de Abertura: </b>" + shopping.horaAbertura +
                    "</div>" +
                    "<div>" +
                    "<b>Hora de Fechamento: </b>" + shopping.horaFechamento +
                    "</div>" +
                    "</div>";                

                infowindow = new google.maps.InfoWindow({
                    name: name,
                    content: content,
                    maxWidth: 200
                });

                infowindow.setPosition(results[0].geometry.location);
                infowindow.open(map);
            }
        })
    }
}

function clearInfowindow() {

    if (infowindow) {
        infowindow.close();
    }
}

function calcRoute(waypts, end) {

    var directionsService = new google.maps.DirectionsService();
    var directionsRenderer = new google.maps.DirectionsRenderer();

    directionsRenderer.setMap(map);

    var request = {
        origin: prefecture,
        waypoints: waypts,
        destination: end,
        optimizeWaypoints: true,
        travelMode: google.maps.DirectionsTravelMode.DRIVING
    };

    directionsService.route(request, function (result, status) {

        if (status == 'OK') {

            directionsRenderer.setDirections(result);
        }
    });
}
