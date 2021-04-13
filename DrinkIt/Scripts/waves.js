var cnt = document.getElementById("count");
var water = document.getElementById("water");
var maxPercent = cnt.innerText;
var percent = 0;
var interval;
interval = setInterval(function () {
    if (maxPercent == 0){
        clearInterval(interval)
        percent--;
    }
    percent++;
    cnt.innerHTML = percent;
    water.style.transform = 'translate(0' + ',' + (100 - percent) + '%)';
    if (percent == maxPercent) {
        clearInterval(interval);
    }
}, 60);
