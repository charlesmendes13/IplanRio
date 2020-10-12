// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
// Parameters

var map;
var prefecture;
var shoppings = [];

$(function () {

    $("#HoraAbertura").keyup(function () {

        $("#HoraAbertura").mask("99:99");
    });

    $("#HoraFechamento").keyup(function () {

        $("#HoraFechamento").mask("99:99");
    });

    $("#adicionar").click(function () {

        addRoute();
    });

    $("#trajeto").click(function () {

        getShoppings((data) => {
                 
            var waypts = wayPoints(data);
            var end = endRoute(data);
            calcRoute(waypts, end);
        });
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

        var name = data.find(x => x.id == shoppings[i]).nome;
        var address = data.find(x => x.id == shoppings[i]).endereco;

        waypts.push({
            location: address,
            stopover: true,
        });

        infowindow(name, address);
    }

    return waypts;
}

function endRoute(data) {

    var name = data.find(x => x.id == shoppings.slice(-1)[0]).nome;
    var end = data.find(x => x.id == shoppings.slice(-1)[0]).endereco;

    infowindow(name, end);

    return end;
}

function infowindow(name, address) {

    geocoder = new google.maps.Geocoder();

    if (geocoder) {
        geocoder.geocode({ address, }, function (results, status) {
            if (status === 'OK') {

                var content =
                    "<div>" +
                    "<h5>" + name + "</h5>" +
                    "<div>" +
                    "<b>Endereço: </b>" + address +
                    "</div>" +
                    "</div>";                

                var infowindow = new google.maps.InfoWindow({
                    name: name,
                    content: content,
                });

                infowindow.setPosition(results[0].geometry.location);
                infowindow.open(map);
            }
        })
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
