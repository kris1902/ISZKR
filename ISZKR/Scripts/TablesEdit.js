/* 
Funkcje obsługujące dodawanie, zmienianie, usuwanie danych
tabeli historii edukacji, zawodowej, zamieszkania.
*/

/******************* HISTORIA EDUKACJI *******************/

function edu_insert_row(new_level, new_name, new_start, new_end)
{
    var lastID = 0;
    $.ajax({
        type: "GET",
        url: "/Person/GetLastEduID",
        success: function (response) {
            if (response !== null) {
                lastID = response;
                var table_len = parseInt(lastID);
                var row = $("#edu-table tr:last").before("<tr id='edu-row-" + table_len + "'><td id='edu-level-row-" + table_len + "'>" + new_level + "</td><td id='edu-name-row-" + table_len + "'>" + new_name + "</td><td id='edu-start-row-" + table_len + "'>" + new_start + "</td><td id='edu-end-row-" + table_len + "'>" + new_end + "</td><td><button id='edu_edit_button-" + table_len + "' value='Edit' class='btn-primary table-edit-btn' onclick='edu_edit_row(" + table_len + ")'><i class='glyphicon glyphicon-pencil'></i></button> <button id='edu_save_button-" + table_len + "' value='Save' class='btn-success table-save-btn' onclick='edu_save_row(" + table_len + ")'><i class='glyphicon glyphicon-ok'></i></button> <button value='Delete' class='btn-danger table-delete-btn' onclick='edu_delete_row(" + table_len + ")'><i class='glyphicon glyphicon-trash'></i></button></td></tr>");
            } else {
                alert("Coś poszło nie tak...");
            }
        },
        failure: function (response) {
            alert("Coś poszło nie tak...");
        }
    });}

function edu_add_row(personID) {

    var new_level = $("#new-edu-level").val();
    var new_name = $("#new-edu-name").val();
    var new_start = $("#new-edu-start").val();
    var new_end = $("#new-edu-end").val();

    $.ajax({
        type: "POST",
        url: "/Person/AddOrEditEdu",
        data: {
            EducationLevel: $("#new-edu-level").val(),
            InstitutionName: $("#new-edu-name").val(),
            StartDateTime: $("#new-edu-start").val(),
            EndDateTime: $("#new-edu-end").val(),
            personID: personID
        },
        success: function () {
            edu_insert_row(new_level, new_name, new_start, new_end);
             },
        failure: function () {
            alert('Coś poszło nie tak...');
        }
    });
}

function edu_edit_row(no) {
    $("#edu_edit_button-" + no).hide();
    $("#edu_save_button-" + no).show();

    var level = $("#edu-level-row-" + no);
    var name = $("#edu-name-row-" + no);
    var start = $("#edu-start-row-" + no);
    var end = $("#edu-end-row-" + no);

    var level_data = level.text();
    var name_data = name.text();

    level.html("<select id='new-edu-level-" + no + "' value='" + level + "'><option value='Podstawowe'>Podstawowe</option><option value='Gimnazjalne'>Gimnazjalne</option><option value='Techniczne'>Techniczne</option><option value='Zawodowe'>Zawodowe</option><option value='Licealne'>Licealne</option><option value='Licencjackie'>Licencjackie</option><option value='Inżynierskie'>Inżynierskie</option><option value='Magisterskie'>Magisterskie</option><option value='Doktorskie'>Doktorskie</option><option value='Profesorskie'>Profesorskie</option></select>");
    name.html("<input type='text' id='new-edu-name-" + no + "' value='" + name_data + "'>");
    start.html("<input type='date' id='new-edu-start-" + no + "'>");
    end.html("<input type='date' id='new-edu-end-" + no + "'>");

}

function edu_save_row(personID, no) {

    $.ajax({
        type: "POST",
        url: "/Person/AddOrEditEdu",
        data: {
            EducationLevel: $("#new-edu-level-" + no).val(),
            InstitutionName: $("#new-edu-name-" + no).val(),
            StartDateTime: $("#new-edu-start-" + no).val(),
            EndDateTime: $("#new-edu-end-" + no).val(),
            personID: personID,
            eduID: no
        },
        success: function () {
            $("#edu-level-row-" + no).text($("#new-edu-level-" + no).val());
            $("#edu-name-row-" + no).text($("#new-edu-name-" + no).val());
            $("#edu-start-row-" + no).text($("#new-edu-start-" + no).val());
            $("#edu-end-row-" + no).text($("#new-edu-end-" + no).val());
            $("#edu_edit_button-" + no).show();
            $("#edu_save_button-" + no).hide();
        },
        failure: function () {
            alert('Coś poszło nie tak...');
        }
    });
}

function edu_delete_row(no) {
    $.ajax({
        type: "POST",
        url: "/Person/DeleteEdu",
        data: {
            eduID: no
        },
        success: function () {
            $("#edu-row-" + no).text("");
        },
        failure: function () {
            alert('Coś poszło nie tak...');
        }
    });
}

/******************* HISTORIA ZAWODOWA *******************/

function work_insert_row(new_name, new_employer, new_address, new_start, new_end) {
    var lastID = 0;
    $.ajax({
        type: "GET",
        url: "/Person/GetLastProID",
        success: function (response) {
            if (response !== null) {
                lastID = response;
                var table_len = parseInt(lastID);
                var row = $("#work-table tr:last").before("<tr id='work-row-" + table_len + "'><td id='work-name-row-" + table_len + "'>" + new_name + "</td><td id='work-employer-row-" + table_len + "'>" + new_employer + "</td><td id='work-address-row-" + table_len + "'>" + new_address + "</td><td id='work-start-row-" + table_len + "'>" + new_start + "</td><td id='work-end-row-" + table_len + "'>" + new_end + "</td>" + "</td><td><button id='work_edit_button-" + table_len + "' value='Edit' class='btn-primary table-edit-btn' onclick='work_edit_row(" + table_len + ")'><i class='glyphicon glyphicon-pencil'></i></button> <button id='work_save_button-" + table_len + "' value='Save' class='btn-success table-save-btn' onclick='work_save_row(" + table_len + ")'><i class='glyphicon glyphicon-ok'></i></button> <button value='Delete' class='btn-danger table-delete-btn' onclick='work_delete_row(" + table_len + ")'><i class='glyphicon glyphicon-trash'></i></button></td></tr>");
            } else {
                alert("Coś poszło nie tak...");
            }
        },
        failure: function (response) {
            alert("Coś poszło nie tak...");
        }
    });
}

function work_add_row(personID) {

    var new_name = $("#new-work-name").val();
    var new_employer = $("#new-work-employer").val();
    var new_address = $("#new-work-address").val();
    var new_start = $("#new-work-start").val();
    var new_end = $("#new-work-end").val();

    $.ajax({
        type: "POST",
        url: "/Person/AddOrEditPro",
        data: {
            position: $("#new-work-name").val(),
            empName: $("#new-work-employer").val(),
            address: $("#new-work-address").val(),
            startDateTime: $("#new-work-start").val(),
            endDateTime: $("#new-work-end").val(),
            personID: personID
        },
        success: function () {
            work_insert_row(new_name, new_employer, new_address, new_start, new_end)
        },
        failure: function () {
            alert('Coś poszło nie tak...');
        }
    });
}

function work_edit_row(no) {

    $("#work_edit_button-" + no).hide();
    $("#work_save_button-" + no).show();

    var name = $("#work-name-row-" + no);
    var employer = $("#work-employer-row-" + no);
    var start = $("#work-start-row-" + no);
    var end = $("#work-end-row-" + no);
    var address = $("#work-address-row-" + no);

    var name_data = name.text();
    var employer_data = employer.text();
    var address_data = address.text();

    name.html("<input type='text' id='new-work-name-" + no + "' value='" + name_data + "'>");
    employer.html("<input type='text' id='new-work-employer-" + no + "' value='" + employer_data + "'>");
    address.html("<input type='text' id='new-work-address-" + no + "' value='" + address_data + "'>");
    start.html("<input type='date' id='new-work-start-" + no + "'>");
    end.html("<input type='date' id='new-work-end-" + no + "'>");

}

function work_save_row(personID, no) {

    $.ajax({
        type: "POST",
        url: "/Person/AddOrEditPro",
        data: {
            position: $("#new-work-name-" + no).val(),
            empName: $("#new-work-employer-" + no).val(),
            address: $("#new-work-address-" + no).val(),
            startDateTime: $("#new-work-start-" + no).val(),
            endDateTime: $("#new-work-end-" + no).val(),
            personID: personID,
            workID: no
        },
        success: function () {
            $("#work-name-row-" + no).text($("#new-work-name-" + no).val());
            $("#work-employer-row-" + no).text($("#new-work-employer-" + no).val());
            $("#work-address-row-" + no).text($("#new-work-address-" + no).val());
            $("#work-start-row-" + no).text($("#new-work-start-" + no).val());
            $("#work-end-row-" + no).text($("#new-work-end-" + no).val());
            $("#work_edit_button-" + no).show();
            $("#work_save_button-" + no).hide();
        },
        failure: function () {
            alert('Coś poszło nie tak...');
        }
    });
}

function work_delete_row(no) {
    $.ajax({
        type: "POST",
        url: "/Person/DeleteWork",
        data: {
            workID: no
        },
        success: function () {
            $("#work-row-" + no).text("");
        },
        failure: function () {
            alert('Coś poszło nie tak...');
        }
    });
}




/******************* HISTORIA ZAMIESZKANIA *******************/

function res_insert_row(new_city, new_address, new_country, new_start, new_end) {
    var lastID = 0;
    $.ajax({
        type: "GET",
        url: "/Person/GetLastResID",
        success: function (response) {
            if (response !== null) {
                lastID = response;
                var table_len = parseInt(lastID);
                var row = $("#home-table tr:last").before("<tr id='home-row-" + table_len + "'><td id='home-city-row-" + table_len + "'>" + new_city + "</td><td id='home-address-row-" + table_len + "'>" + new_address + "</td><td id='home-country-row-" + table_len + "'>" + new_country + "</td><td id='home-start-row-" + table_len + "'>" + new_start + "</td><td id='home-end-row-" + table_len + "'>" + new_end + "</td><td><button id='home_edit_button-" + table_len + "' value='Edit' class='btn-primary table-edit-btn' onclick='home_edit_row(" + table_len + ")'><i class='glyphicon glyphicon-pencil'></i></button> <button id='home_save_button-" + table_len + "' value='Save' class='btn-success table-save-btn' onclick='home_save_row(" + table_len + ")'><i class='glyphicon glyphicon-ok'></i></button> <button value='Delete' class='btn-danger table-delete-btn' onclick='home_delete_row(" + table_len + ")'><i class='glyphicon glyphicon-trash'></i></button></td></tr>");
            } else {
                alert("Coś poszło nie tak...");
            }
        },
        failure: function (response) {
            alert("Coś poszło nie tak...");
        }
    });
}

function home_add_row(personID) {
    var new_city = $("#new-home-city").val();
    var new_address = $("#new-home-address").val();
    var new_country = $("#new-home-country").val();
    var new_start = $("#new-home-start").val();
    var new_end = $("#new-home-end").val();

    $.ajax({
        type: "POST",
        url: "/Person/AddOrEditRes",
        data: {
            address: new_address,
            city: new_city,
            country: new_country,
            startDateTime: new_start,
            endDateTime: new_end,
            personID: personID
        },
        success: function () {
            res_insert_row(new_city, new_address, new_country, new_start, new_end)
        },
        failure: function () {
            alert('Coś poszło nie tak...');
        }
    });
}

function home_edit_row(no) {
    $("#home_edit_button-" + no).hide();
    $("#home_save_button-" + no).show();

    var city = $("#home-city-row-" + no);
    var address = $("#home-address-row-" + no);
    var country = $("#home-country-row-" + no);
    var start = $("#home-start-row-" + no);
    var end = $("#home-end-row-" + no);

    var city_data = city.text();
    var address_data = address.text();
    var country_data = country.text();

    city.html("<input type='text' id='new-home-city-" + no + "' value='" + city_data + "'>");
    address.html("<input type='text' id='new-home-address-" + no + "' value='" + address_data + "'>");
    country.html("<input type='text' id='new-home-country-" + no + "' value='" + country_data + "'>");
    start.html("<input type='date' id='new-home-start-" + no + "'>");
    end.html("<input type='date' id='new-home-end-" + no + "'>");
}

function home_save_row(personID, no) {

    $.ajax({
        type: "POST",
        url: "/Person/AddOrEditRes",
        data: {
            address: $("#new-home-address-" + no).val(),
            city: $("#new-home-city-" + no).val(),
            country: $("#new-home-country-" + no).val(),
            startDateTime: $("#new-home-start-" + no).val(),
            endDateTime: $("#new-home-end-" + no).val(),
            personID: personID,
            resID: no
        },
        success: function () {
            $("#home-address-row-" + no).text($("#new-home-address-" + no).val());
            $("#home-city-row-" + no).text($("#new-home-city-" + no).val());
            $("#home-country-row-" + no).text($("#new-home-country-" + no).val());
            $("#home-start-row-" + no).text($("#new-home-start-" + no).val());
            $("#home-end-row-" + no).text($("#new-home-end-" + no).val());
            $("#home_edit_button-" + no).show();
            $("#home_save_button-" + no).hide();
        },
        failure: function () {
            alert('Coś poszło nie tak...');
        }
    });
}

function home_delete_row(no) {
    $.ajax({
        type: "POST",
        url: "/Person/DeleteRes",
        data: {
            resID: no
        },
        success: function () {
            $("#home-row-" + no).text("");
        },
        failure: function () {
            alert('Coś poszło nie tak...');
        }
    });
}


