var form = document.getElementById('form-val');
var inp = document.getElementsByClassName('text-box');
var btn = document.getElementById('btn-edit');

btn.onclick = function () {
    if (inp == "") {
        alert("Заповніть поля");
    }
    else {
        return null;
    }
       
}
