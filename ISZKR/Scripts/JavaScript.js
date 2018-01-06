//person_name.onclick = function () {
//    overlay.style.display = "inherit";
//    person_name.style.display = "none";
//    person_name_edit_txt.value = person_name.firstChild.textContent;
//    person_name_edit.style.display = "inherit";
//}

$('#person-name').click(function () {
    $(this).css('display', 'none');
    $('form#name-edit-form').css('display', 'inline-block');
});


function successCreatePostFunction(data) {
    if (data.result === "success") {
        $('form#name-edit-form').css('display', 'none');
        $('#person-name').text($('#person-name-edit-textbox').val() + " " + $('#person-surname-edit-textbox').val());
        $('#person-familyname').text($('#person-familyname-edit-textbox').val());   //coś nie dziala
        $('#person-name').css('display', 'inherit');

        /*$('#AddCategoryModal').modal('hide');

        var row = $('<tr id="' + data.id + '"><th>@Html.CheckBox("chkSelect")</th><td>' + data.name + '</td><td><a href="javascript:void(0);"><span class="glyphicon glyphicon-edit Edit" data-id="' + data.id + '"></span> </a><a href="javascript:void(0);"><span class="glyphicon glyphicon-remove Remove" data-id="' + data.id + '"></span></a></td></tr>');
        row.on('click', '.Edit', Edit);
        row.on('click', '.Remove', Remove);

        var table = $('#dataTable').DataTable();
        row.hide('slow');
        row.fadeIn('slow');
        table.row.add(row).draw();
        DisplayRowsCounter();*/
    }
}