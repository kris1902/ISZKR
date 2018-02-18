$('#person-name').click(function () {
    $(this).css('display', 'none');
    $('form#name-edit-form').css('display', 'inline-block');
})

function successEditPersonName(data) {
    if (data.result === "success") {
        $('form#name-edit-form').css('display', 'none');
        $('#person-name').text($('#person-name-edit-textbox').val() + " " + $('#person-surname-edit-textbox').val());
        $('#person-familyname').text($('#person-familyname-edit-textbox').val());
        $('#person-name').css('display', 'inherit');
    }
}

$('#born-info').click(function () {
    $(this).css('display', 'none');
    $('form#born-info-edit').css('display', 'inline-block');
})

function successEditPersonBirth(data) {
    if (data.result === "success") {
        $('form#born-info-edit').css('display', 'none');
        $('#born-date').text($('#born-info-edit-date').val());
        $('#born-city').text($('#born-info-edit-city').val());
        $('#born-info-no-data').text($('#born-info-edit-date').val() + " " + $('#born-info-edit-city').val());
        $('#born-info').css('display', 'inherit');
    }
}

$('#death-info').click(function () {
    $(this).css('display', 'none');
    $('form#death-info-edit').css('display', 'inline-block');
})

function successEditPersonDeath(data) {
    if (data.result === "success") {
        $('form#death-info-edit').css('display', 'none');
        $('#death-date').text($('#death-info-edit-date').val());
        $('#death-city').text($('#death-info-edit-city').val());
        $('#death-info-no-data').text($('#death-info-edit-date').val() + " " + $('#death-info-edit-city').val());
        $('#death-info').css('display', 'inherit');
    }
}

$('#burial-info').click(function () {
    $(this).css('display', 'none');
    $('form#burial-info-edit').css('display', 'inline-block');
})

function successEditPersonBurial(data) {
    if (data.result === "success") {
        $('form#burial-info-edit').css('display', 'none');
        $('#burial-place').text($('#burial-info-edit-text').val());
        $('#burial-info-no-data').text($('#burial-info-edit-text').val());
        $('#burial-info').css('display', 'inherit');
    }
}

$(document).ready(function () {
    $('#father-edit').click(function () {
        var url = $('#setFatherModal').data('url');

        $.get(url, function (data) {
            $('#setFatherModal').html(data);
            $('#setFatherModal').modal('show');
        });
    });
});

$(document).ready(function () {
    $('#mother-edit').click(function () {
        var url = $('#setMotherModal').data('url');

        $.get(url, function (data) {
            $('#setMotherModal').html(data);
            $('#setMotherModal').modal('show');
        });
    });
});

$(document).ready(function () {
    $('#partner-edit').click(function () {
        var url = $('#setPartnerModal').data('url');

        $.get(url, function (data) {
            $('#setPartnerModal').html(data);
            $('#setPartnerModal').modal('show');
        });
    });
});

$(document).ready(function () {
    $('#kid-edit').click(function () {
        var url = $('#setKidModal').data('url');

        $.get(url, function (data) {
            $('#setKidModal').html(data);
            $('#setKidModal').modal('show');
        });
    });
});

function onKidDeleteClick(kid_id) {
    $('#deleteKidBtn').attr('href', $('#deleteKidBtn').attr('href') + '&kids_id=' + kid_id);
};

$(document).ready(function () {
    $('#person-photo-edit').click(function () {
        var url = $('#PersonsPhotoModal').data('url');

        $.get(url, function (data) {
            $('#PersonsPhotoModal').html(data);
            $('#PersonsPhotoModal').modal('show');
        });
    });
});

function edit_person_desc() {
    $('#description_content').summernote({ focus: true });
    $('#desc-edit-btn').css('display', 'none');
    $('#desc-save-btn').css('display', 'inline-block');
};

function save_person_desc(personID) {
    var desc = encodeURIComponent($("#description_content").summernote('code'));
    $.ajax({
        type: "POST",
        url: "/Person/EditDescription",
        data: {
            description: desc,
            personID: personID
        },
        success: function () {
            $('#description_content').summernote('destroy');
            $('#desc-edit-btn').css('display', 'inline-block');
            $('#desc-save-btn').css('display', 'none');
        },
        failure: function () {
            alert('Coś poszło nie tak...');
        }
    });
};

$(document).ready(function () {
    $('#add-person-btn').click(function () {
        var name = $('#add-person-name-edit-textbox').val();
        var surname = $('#add-person-surname-edit-textbox').val();
        var gender = $('#add-person-gender-select').val();
        var currentURL = $('#add-person-btn').attr('href');
        $('#add-person-btn').attr('href', currentURL + '&name=' + name + '&surname=' + surname + '&gender=' + gender);
    });
});