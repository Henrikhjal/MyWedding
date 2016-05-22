function updateClock() {
    //var deadline = new Date("May 14, 2016 15:00");
    var deadline = new Date('2016-05-14 15:00'.replace(/-/g, "/"));

    t = getTimeRemaining(deadline);

    var secs = document.getElementById("timer3");
    var mins= document.getElementById("timer2");
    var hrs = document.getElementById("timer1");
    var days = document.getElementById("timer0");

    secs.innerHTML = t.seconds;
    mins.innerHTML = t.minutes;
    hrs.innerHTML = t.hours;
    days.innerHTML = t.days;

    //if (t.total <= 0) {
        //clearInterval(timeinterval);
    //}
}  // , 1000);

function getTimeRemaining(endtime) {
    var t = Date.parse(new Date()) - Date.parse(endtime);

    var seconds = Math.floor((t / 1000) % 60);
    var minutes = Math.floor((t / 1000 / 60) % 60);
    var hours = Math.floor((t / (1000 * 60 * 60)) % 24);
    var days = Math.floor(t / (1000 * 60 * 60 * 24));
    return {
        'total': t,
        'days': days,
        'hours': hours,
        'minutes': minutes,
        'seconds': seconds
    };
}

function GetCurrentTime() {
    var currentTime = new Date();

    hour = currentTime.getHours();
    min = currentTime.getMinutes();
    sec = currentTime.getSeconds();
    var klockslag = hour + ":" + min + ":" + sec
    return klockslag;
}

function getLocationJS() {
    if (navigator.geolocation) {
        navigator.geolocation.getCurrentPosition(showPosition);

    } else {
        x.innerHTML = "Geolocation is not supported by this browser.";
    }
};





