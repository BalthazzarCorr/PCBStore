function Add() {
    var res = validate();
    if (res == false) {
        return false;
    }
    var empObj = {
        Name: $('#Name').val(),
        Description: $('#Description').val(),
        Type: $('#Type').val(),
        Manufacturer: $('#Manufacturer').val(),
        Price: $('#Price').val(),

    };
    $.ajax({
        url: "/components/add",
        data: JSON.stringify(empObj),
        type: "POST",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (result) {
            //loadData();
            clearTextBox();
            $('#addCompo').modal('hide');
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });

}

//Function for clearing the textboxes
function clearTextBox() {
    $('#Name').val("");
    $('#Description').val("");
    $('#Type').val("");
    $('#Manufacturer').val("");
    $('#Price').val("");
    $('#btnUpdate').hide();
    $('#btnAdd').show();
    $('#Name').css('border-color', 'lightgrey');
    $('#Description').css('border-color', 'lightgrey');
    $('#Type').css('border-color', 'lightgrey');
    $('#Manufacturer').css('border-color', 'lightgrey');
    $('#Price').css('border-color', 'lightgrey');
}

//Validation using jquery
function validate() {
    var html = '';
    var isValid = true;
    if ($('#Name').val().trim() == "") {
        $('#Name').css('border-color', 'Red');
        isValid = false;
    } else {
        $('#Name').css('border-color', 'lightgrey');
    }
    if ($('#Description').val().trim() == "") {
        $('#Description').css('border-color', 'Red');
        isValid = false;
    } else {
        $('#Description').css('border-color', 'lightgrey');
    }
    if ($('#Type').val().trim() == "") {
        $('#Type').css('border-color', 'Red');
        isValid = false;
    } else {
        $('#Type').css('border-color', 'lightgrey');
    }
    if ($('#Manufacturer').val().trim() == "") {
        $('#Manufacturer').css('border-color', 'Red');
        isValid = false;
    } else {
        $('#Manufacturer').css('border-color', 'lightgrey');
    }
    if ($('#Price').val().trim() == "") {
        $('#Price').css('border-color', 'Red');
        isValid = false;
    } else {
        $('#Price').css('border-color', 'lightgrey');
    }
   
    return isValid;
}