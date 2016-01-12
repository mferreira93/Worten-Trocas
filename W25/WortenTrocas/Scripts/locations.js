jQuery(function ($) {
    // Asynchronously Load the map API 
    var script = document.createElement('script');
    script.src = "http://maps.googleapis.com/maps/api/js?sensor=false&callback=initialize";
    document.body.appendChild(script);
});

function initialize() {
    var map;
    var bounds = new google.maps.LatLngBounds();
    var mapOptions = {
        mapTypeId: 'roadmap'
    };

    // Display a map on the page
    map = new google.maps.Map(document.getElementById("map_canvas"), mapOptions);
    map.setTilt(45);

    // Multiple Markers
    var markers = [
        [
        "Worten Oeiras",
        38.702324,
        -9.298618,
        1,

        ],
    [
        "Worten Amadora",
        38.7418500000,
        -9.2326700000,
        2,

    ],
    [
        "Worten Cascais",
        38.73929,
        -9.39595,
        3,

    ],
    [
        "Worten Colombo",
        38.7544850000,
        -9.1907230000,
        4,
    ],
    [
        "Worten Forum Sintra",
        38.775518,
        -9.340845,
        5

    ],
    [
        "Worten Seixal",
        38.6130650000,
        -9.1036640000,
        6

    ],

     [
        "Worten Telheiras",
        38.7646080000,
        -9.1753220000,
        7

     ],

     [
        "Worten Loures",
        38.8185300000,
        -9.1757500000,
        8

     ],
    ];

    // Info Window Content
    var infoWindowContent = [
        ['<div class="info_content">' +
        '<h3>Worten Oeiras</h3>' +
        '<p>Avenida Antonio Bernardo Cabral Macedo </p>' +  '<p>2780-560 Oeiras</p>' + '<p>808 100 007</p>'  +   '</div>'],
        ['<div class="info_content">' +
        '<h3>Worten Amadora</h3>' +
        '<p>Estrada Nacional 249-1, Venteira </p>' + '<p>2724-520 Amadora</p>' + '<p>808 100 007</p>' +
        '</div>'],
		['<div class="info_content">' +
        '<h3>Worten Cascais</h3>' +
        '<p>Estrada Nacional 9 </p>' + '<p>2645-543 Alcabideche</p>' + '<p>808 100 007</p>' +
        '</div>'],
		['<div class="info_content">' +
        '<h3>Worten Colombo</h3>' +
        '<p>Centro Comercial Colombo </p>' + '<p>Avenida Lusiada 1500-392 Lisboa </p>' + '<p>808 100 007</p>' +
        '</div>'],
		['<div class="info_content">' +
        '<h3>Worten Forum Sintra</h3>' +
        '<p>Campo Raso </p>' + '<p>Freguesia de Santa Maria 2710-140 Sintra</p>' + '<p>808 100 007</p>' + 
        '</div>'],
		['<div class="info_content">' +
        '<h3>Worten Seixal</h3>' +
        '<p>Rio Sul Shopping</p>' + '<p>Qta. Nova do Judeu - Estrada Nacional 10 Fogueteiro 2840-293 Seixal </p>' + '<p>808 100 007</p>' + 
        '</div>'],
		
			['<div class="info_content">' +
        '<h3>Worten Telheiras</h3>' +
        '<p>Avenida das Nações Unidas </p>' + '<p>Telheiras 1600-528 Lisboa </p>' + '<p>808 100 007</p>' + 
        '</div>'],
		
			['<div class="info_content">' +
        '<h3>Worten Loures</h3>' +
        '<p>Estrada Nacional 250  </p>' + '<p>Quinta Casal da Pipa 2670-339 Loures </p>' + '<p>808 100 007</p>' + 
        '</div>']
    ];

    // Display multiple markers on a map
    var infoWindow = new google.maps.InfoWindow(), marker, i;

    // Loop through our array of markers & place each one on the map  
    for (i = 0; i < markers.length; i++) {
        var position = new google.maps.LatLng(markers[i][1], markers[i][2]);
        bounds.extend(position);
        marker = new google.maps.Marker({
            position: position,
            map: map,
            title: markers[i][0]
        });

        // Allow each marker to have an info window    
        google.maps.event.addListener(marker, 'click', (function (marker, i) {
            return function () {
                infoWindow.setContent(infoWindowContent[i][0]);
                infoWindow.open(map, marker);
            }
        })(marker, i));

        // Automatically center the map fitting all markers on the screen
        map.fitBounds(bounds);
    }

    // Override our map zoom level once our fitBounds function runs (Make sure it only runs once)
    var boundsListener = google.maps.event.addListener((map), 'bounds_changed', function (event) {
        this.setZoom(9);
        google.maps.event.removeListener(boundsListener);
    });

}