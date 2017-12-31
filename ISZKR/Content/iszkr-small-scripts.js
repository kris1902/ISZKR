var overlay = document.getElementById("overlay");

var person_name = document.getElementById("person-name");
var person_name_edit = document.getElementById("person-name-edit");
var person_name_edit_txt = document.getElementById("person-name-edit-textbox");
var person_name_edit_btn = document.getElementById("person-name-edit-btn");

person_name.onclick = function() {
	overlay.style.display = "inherit";
	person_name.style.display = "none";
	person_name_edit_txt.value = person_name.firstChild.textContent;
	person_name_edit.style.display = "inherit";
}

person_name_edit_btn.onclick = function() {
	person_name.firstChild.textContent = person_name_edit_txt.value;
	person_name.style.display = "inherit";
	person_name_edit.style.display = "none";
	overlay.style.display = "none";
}


var born_info = document.getElementById("born-info");
var born_info_edit = document.getElementById("born-info-edit");
var born_info_edit_city = document.getElementById("born-info-edit-city");
var born_info_edit_date = document.getElementById("born-info-edit-date");
var born_info_edit_btn = document.getElementById("born-info-edit-btn");
var born_city = document.getElementById("born-city");
var born_date = document.getElementById("born-date");

born_info.onclick = function() {
	overlay.style.display = "inherit";
	born_info.style.display = "none";
	born_info_edit_city.value = born_city.innerText;
	born_info_edit_date.value = born_date.innerText;
	born_info_edit.style.display = "inherit";
}

born_info_edit_btn.onclick = function() {
	born_city.innerText = born_info_edit_city.value;
	born_date.innerText = born_info_edit_date.value;
	born_info.style.display = "inherit";
	born_info_edit.style.display = "none";
	overlay.style.display = "none";
}



var death_info = document.getElementById("death-info");
var death_info_edit = document.getElementById("death-info-edit");
var death_info_edit_city = document.getElementById("death-info-edit-city");
var death_info_edit_date = document.getElementById("death-info-edit-date");
var death_info_edit_btn = document.getElementById("death-info-edit-btn");
var death_city = document.getElementById("death-city");
var death_date = document.getElementById("death-date");

death_info.onclick = function() {
	overlay.style.display = "inherit";
	death_info.style.display = "none";
	death_info_edit_city.value = death_city.innerText;
	death_info_edit_date.value = death_date.innerText;
	death_info_edit.style.display = "inherit";
}

death_info_edit_btn.onclick = function() {
	death_city.innerText = death_info_edit_city.value;
	death_date.innerText = death_info_edit_date.value;
	death_info.style.display = "inherit";
	death_info_edit.style.display = "none";
	overlay.style.display = "none";
}



var burial_info = document.getElementById("burial-info");
var burial_info_edit = document.getElementById("burial-info-edit");
var burial_info_edit_txt = document.getElementById("burial-info-edit-textbox");
var burial_place = document.getElementById("burial-place");
var burial_info_edit_btn = document.getElementById("burial-info-edit-btn");

burial_info.onclick = function() {
	overlay.style.display = "inherit";
	burial_info.style.display = "none";
	burial_info_edit_txt.value = burial_place.innerText;
	burial_info_edit.style.display = "inherit";
}

burial_info_edit_btn.onclick = function() {
	burial_place.innerText = burial_info_edit_txt.value;
	burial_info.style.display = "inherit";
	burial_info_edit.style.display = "none";
	overlay.style.display = "none";
}

var edytka = document.getElementsByClassName("ct-ignition__button--edit")
edytka.onclick = function() {
	alert('hihi');
}