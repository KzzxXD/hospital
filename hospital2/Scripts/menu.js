var openNav = document.getElementById("btn-open");
var nav = document.getElementById("mySidenav");
var closeNav = document.getElementById("closeBtn");
openNav.onclick = function () {

    nav.style.width = "350px";
}
closeNav.onclick = function () {
    nav.style.width = "0px";
}


