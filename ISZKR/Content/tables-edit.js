/* 
Funkcje obsługujące dodawanie, zmienianie, usuwanie danych
tabeli historii edukacji, zawodowej, zamieszkania.
*/

/******************* HISTORIA EDUKACJI *******************/

function edu_add_row()
{
 var new_level=document.getElementById("new-edu-level").value;
 var new_name=document.getElementById("new-edu-name").value;
 var new_start=document.getElementById("new-edu-start").value;
 var new_end=document.getElementById("new-edu-end").value;
 var new_comment=document.getElementById("new-edu-comment").value;
 
 var table=document.getElementById("edu-table");
 var table_len=(table.rows.length)-1;
 var row = table.insertRow(table_len).outerHTML="<tr id='edu-row"+table_len+"'><td id='edu-level-row"+table_len+"'>"+new_level+"</td><td id='edu-name-row"+table_len+"'>"+new_name+"</td><td id='edu-start-row"+table_len+"'>"+new_start+"</td><td id='edu-end-row"+table_len+"'>"+new_end+"</td><td id='edu-comment-row"+table_len+"'>"+new_comment+"</td><td><button id='edu_edit_button"+table_len+"' value='Edit' class='btn-primary table-edit-btn' onclick='edu_edit_row("+table_len+")'><i class='glyphicon glyphicon-pencil'></i></button> <button id='edu_save_button"+table_len+"' value='Save' class='btn-success table-save-btn' onclick='edu_save_row("+table_len+")'><i class='glyphicon glyphicon-ok'></i></button> <button value='Delete' class='btn-danger table-delete-btn' onclick='edu_delete_row("+table_len+")'><i class='glyphicon glyphicon-trash'></i></button></td></tr>";

}

function edu_edit_row(no)
{
 document.getElementById("edu_edit_button"+no).style.display="none";
 document.getElementById("edu_save_button"+no).style.display="inherit";
 
 var level=document.getElementById("edu-level-row"+no);
 var name=document.getElementById("edu-name-row"+no);
 var start=document.getElementById("edu-start-row"+no);
 var end=document.getElementById("edu-end-row"+no);
 var comment=document.getElementById("edu-comment-row"+no);
	
 var level_data=level.value;
 var name_data=name.innerHTML;
 var start_data=start.innerHTML;
 var end_data=end.innerHTML;
 var comment_data=comment.innerHTML;
 
 level.innerHTML   = "<select id='new-edu-level"+no+"' value='"+level+"'><option value='Podstawowe'>Podstawowe</option><option value='Gimnazjalne'>Gimnazjalne</option><option value='Techniczne'>Techniczne</option><option value='Zawodowe'>Zawodowe</option><option value='Licealne'>Licealne</option><option value='Licencjackie'>Licencjackie</option><option value='Inżynierskie'>Inżynierskie</option><option value='Magisterskie'>Magisterskie</option><option value='Doktorskie'>Doktorskie</option><option value='Profesorskie'>Profesorskie</option></select>";
 name.innerHTML    = "<input type='text' id='new-edu-name"+no+"' value='"+name_data+"'>";
 start.innerHTML   = "<input type='date' id='new-edu-start"+no+"' value='"+moment(start_data).format('YYYY-MM-DD')+"'>";
 end.innerHTML     = "<input type='date' id='new-edu-end"+no+"' value='"+moment(end_data).format('YYYY-MM-DD')+"'>";
 comment.innerHTML = "<input type='text' id='new-edu-comment"+no+"' value='"+comment_data+"'>";
 
}

function edu_save_row(no)
{
 var level_val=document.getElementById("new-edu-level"+no).value;
 var name_val=document.getElementById("new-edu-name"+no).value;
 var start_val=document.getElementById("new-edu-start"+no).value;
 var end_val=document.getElementById("new-edu-end"+no).value;
 var comment_val=document.getElementById("new-edu-comment"+no).value;

 document.getElementById("edu-level-row"+no).innerHTML=level_val;
 document.getElementById("edu-name-row"+no).innerHTML=name_val;
 document.getElementById("edu-start-row"+no).innerHTML=start_val;
 document.getElementById("edu-end-row"+no).innerHTML=end_val;
 document.getElementById("edu-comment-row"+no).innerHTML=comment_val;

 document.getElementById("edu_edit_button"+no).style.display="inherit";
 document.getElementById("edu_save_button"+no).style.display="none";
}

function edu_delete_row(no)
{
 document.getElementById("edu-row"+no).outerHTML="";
}

/******************* HISTORIA ZAWODOWA *******************/

function work_add_row()
{
 var new_name=document.getElementById("new-work-name").value;
 var new_employer=document.getElementById("new-work-employer").value;
 var new_start=document.getElementById("new-work-start").value;
 var new_end=document.getElementById("new-work-end").value;
 var new_address=document.getElementById("new-work-address").value;
 
 var table=document.getElementById("work-table");
 var table_len=(table.rows.length)-1;
 var row = table.insertRow(table_len).outerHTML="<tr id='work-row"+table_len+"'><td id='work-name-row"+table_len+"'>"+new_name+"</td><td id='work-employer-row"+table_len+"'>"+new_employer+"</td><td id='work-start-row"+table_len+"'>"+new_start+"</td><td id='work-end-row"+table_len+"'>"+new_end+"</td><td id='work-address-row"+table_len+"'>"+new_address+"</td><td><button id='work_edit_button"+table_len+"' value='Edit' class='btn-primary table-edit-btn' onclick='work_edit_row("+table_len+")'><i class='glyphicon glyphicon-pencil'></i></button> <button id='work_save_button"+table_len+"' value='Save' class='btn-success table-save-btn' onclick='work_save_row("+table_len+")'><i class='glyphicon glyphicon-ok'></i></button> <button value='Delete' class='btn-danger table-delete-btn' onclick='work_delete_row("+table_len+")'><i class='glyphicon glyphicon-trash'></i></button></td></tr>";

}

function work_edit_row(no)
{
 document.getElementById("work_edit_button"+no).style.display="none";
 document.getElementById("work_save_button"+no).style.display="inherit";
 
 var name=document.getElementById("work-name-row"+no);
 var employer=document.getElementById("work-employer-row"+no);
 var start=document.getElementById("work-start-row"+no);
 var end=document.getElementById("work-end-row"+no);
 var address=document.getElementById("work-address-row"+no);
	
 var name_data=name.innerHTML;
 var employer_data=employer.innerHTML;
 var start_data=start.innerHTML;
 var end_data=end.innerHTML;
 var address_data=address.innerHTML;
 
 name.innerHTML   = "<input type='text' id='new-work-name"+no+"' value='"+name_data+"'>";
 employer.innerHTML = "<input type='text' id='new-work-employer"+no+"' value='"+employer_data+"'>";
 start.innerHTML   = "<input type='date' id='new-work-start"+no+"' value='"+moment(start_data).format('YYYY-MM-DD')+"'>";
 end.innerHTML     = "<input type='date' id='new-work-end"+no+"' value='"+moment(end_data).format('YYYY-MM-DD')+"'>";
 address.innerHTML = "<input type='text' id='new-work-address"+no+"' value='"+address_data+"'>";
 
}

function work_save_row(no)
{
 var name_val=document.getElementById("new-work-name"+no).value;
 var employer_val=document.getElementById("new-work-employer"+no).value;
 var start_val=document.getElementById("new-work-start"+no).value;
 var end_val=document.getElementById("new-work-end"+no).value;
 var address_val=document.getElementById("new-work-address"+no).value;

 document.getElementById("work-name-row"+no).innerHTML=name_val;
 document.getElementById("work-employer-row"+no).innerHTML=employer_val;
 document.getElementById("work-start-row"+no).innerHTML=start_val;
 document.getElementById("work-end-row"+no).innerHTML=end_val;
 document.getElementById("work-address-row"+no).innerHTML=address_val;

 document.getElementById("work_edit_button"+no).style.display="inherit";
 document.getElementById("work_save_button"+no).style.display="none";
}

function work_delete_row(no)
{
 document.getElementById("work-row"+no).outerHTML="";
}




/******************* HISTORIA ZAMIESZKANIA *******************/

function home_add_row()
{
 var new_city=document.getElementById("new-home-city").value;
 var new_address=document.getElementById("new-home-address").value;
 var new_country=document.getElementById("new-home-country").value;
 var new_start=document.getElementById("new-home-start").value;
 var new_end=document.getElementById("new-home-end").value;
 
 var table=document.getElementById("home-table");
 var table_len=(table.rows.length)-1;
 var row = table.insertRow(table_len).outerHTML="<tr id='home-row"+table_len+"'><td id='home-city-row"+table_len+"'>"+new_city+"</td><td id='home-address-row"+table_len+"'>"+new_address+"</td><td id='home-country-row"+table_len+"'>"+new_country+"</td><td id='home-start-row"+table_len+"'>"+new_start+"</td><td id='home-end-row"+table_len+"'>"+new_end+"</td><td><button id='home_edit_button"+table_len+"' value='Edit' class='btn-primary table-edit-btn' onclick='home_edit_row("+table_len+")'><i class='glyphicon glyphicon-pencil'></i></button> <button id='home_save_button"+table_len+"' value='Save' class='btn-success table-save-btn' onclick='home_save_row("+table_len+")'><i class='glyphicon glyphicon-ok'></i></button> <button value='Delete' class='btn-danger table-delete-btn' onclick='home_delete_row("+table_len+")'><i class='glyphicon glyphicon-trash'></i></button></td></tr>";

}

function home_edit_row(no)
{
 document.getElementById("home_edit_button"+no).style.display="none";
 document.getElementById("home_save_button"+no).style.display="inherit";
 
 var city=document.getElementById("home-city-row"+no);
 var address=document.getElementById("home-address-row"+no);
 var country=document.getElementById("home-country-row"+no);
 var start=document.getElementById("home-start-row"+no);
 var end=document.getElementById("home-end-row"+no);
	
 var city_data=city.innerHTML;
 var address_data=address.innerHTML;
 var country_data=country.innerHTML;
 var start_data=start.innerHTML;
 var end_data=end.innerHTML;
 
 city.innerHTML   = "<input type='text' id='new-home-city"+no+"' value='"+city_data+"'>";
 address.innerHTML = "<input type='text' id='new-home-address"+no+"' value='"+address_data+"'>";
 country.innerHTML = "<input type='text' id='new-home-country"+no+"' value='"+country_data+"'>";
 start.innerHTML   = "<input type='date' id='new-home-start"+no+"' value='"+moment(start_data).format('YYYY-MM-DD')+"'>";
 end.innerHTML     = "<input type='date' id='new-home-end"+no+"' value='"+moment(end_data).format('YYYY-MM-DD')+"'>";
 
}

function home_save_row(no)
{
 var city_val=document.getElementById("new-home-city"+no).value;
 var address_val=document.getElementById("new-home-address"+no).value;
 var country_val=document.getElementById("new-home-country"+no).value;
 var start_val=document.getElementById("new-home-start"+no).value;
 var end_val=document.getElementById("new-home-end"+no).value;

 document.getElementById("home-city-row"+no).innerHTML=city_val;
 document.getElementById("home-address-row"+no).innerHTML=address_val;
 document.getElementById("home-country-row"+no).innerHTML=country_val;
 document.getElementById("home-start-row"+no).innerHTML=start_val;
 document.getElementById("home-end-row"+no).innerHTML=end_val;

 document.getElementById("home_edit_button"+no).style.display="inherit";
 document.getElementById("home_save_button"+no).style.display="none";
}

function home_delete_row(no)
{
 document.getElementById("home-row"+no).outerHTML="";
}


