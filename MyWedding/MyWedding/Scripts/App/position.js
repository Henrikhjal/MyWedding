(function getLocation() {

    $.getJSON("http://freegeoip.net/json/", function (data) {
        document.getElementById("country").value = data.country_name;
        document.getElementById("city").value = data.city;
        document.getElementById("latitude").value = data.latitude;
        document.getElementById("longitude").value = data.longitude;
    });
})();