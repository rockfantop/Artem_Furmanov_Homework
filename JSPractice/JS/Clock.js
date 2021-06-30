function getDate() {
    let clock = document.getElementsByClassName("clock");
    let date = new Date();

    let currentDate = "";
    let currentTime = "";

    currentDate += date.getDay();
    currentDate += "/" + date.getMonth();
    currentDate += "/" + date.getFullYear();

    currentTime += date.getHours();
    currentTime += ":" + date.getMinutes();
    currentTime += ":" + date.getSeconds();

    clock.item(0).innerHTML = currentTime + "\t" + currentDate;
}

function startClock() {
    let timer = setInterval(getDate, 1000);
    getDate();
}

startClock();