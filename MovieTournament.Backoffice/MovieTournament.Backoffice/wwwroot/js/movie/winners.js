function getFromUrl(param) {
    var url = new URL(location.href);
    var c = url.searchParams.get(param);
    return c;
}

var first = document.getElementById("first");
first.innerHTML = getFromUrl("first");

var second = document.getElementById("second");
second.innerHTML = getFromUrl("second");