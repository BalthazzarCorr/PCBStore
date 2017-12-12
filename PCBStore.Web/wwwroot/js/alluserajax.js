//$(document).ready(function() {
//    loadData();
//});

//Load Data function

//function loadData() {
//    $.ajax({
//        url: "/admin/customers/",
//        type: "GET",
//        contentType: "application/json;charset=utf-8",
//        dataType: "json",
//        success: function(result) {
//            var html = '';
//            $.each(result,
//                function(key, item) {
//                    html += '<tr>';
//                    html += '<td>' + item.username + '</td>';
//                    html += '<td>' + item.email + '</td>';
//                    html += '</tr>';


//                });
//            $('#ajaxResponse').html(html);
//        },
//        error: function(errormessage) {
//            alert(errormessage.responseText);
//        }
//    });
//}


//Add Data Function
function Add() {
    var res = validate();
    if (res == false) {
        return false;
    }
    var empObj = {
        Username: $('#Username').val(),
        FirstName: $('#FirstName').val(),
        LastName: $('#LastName').val(),
        Address: $('#Address').val(),
        Country: $('#Country').val(),
        Email: $('#Email').val(),
        Password: $('#Password').val(),
       
    };
    $.ajax({
        url: "/admin/customers/add",
        data: JSON.stringify(empObj),
        type: "POST",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function(result) {
            loadData();
            $('#myModal').modal('hide');
        },
        error: function(errormessage) {
            alert(errormessage.responseText);
        }
    });
    
}

//Function for clearing the textboxes
function clearTextBox() {
    $('#Username').val("");
    $('#FirstName').val("");
    $('#LastName').val("");
    $('#Address').val("");
    $('#Country').val("");
    $('#Email').val("");
    $('#Password').val("");
    $('#btnUpdate').hide();
    $('#btnAdd').show();
    $('#Username').css('border-color', 'lightgrey');
    $('#FirstName').css('border-color', 'lightgrey');
    $('#LastName').css('border-color', 'lightgrey');
    $('#Address').css('border-color', 'lightgrey');
    $('#Country').css('border-color', 'lightgrey');
    $('#Email').css('border-color', 'lightgrey');
    $('#Password').css('border-color', 'lightgrey');
    $('#ConfirmPassword').css('border-color', 'lightgrey');
}

//Valdidation using jquery
function validate() {
    var isValid = true;
    if ($('#Username').val().trim() == "") {
        $('#Username').css('border-color', 'Red');
        isValid = false;
    } else {
        $('#Username').css('border-color', 'lightgrey');
    }
    if ($('#FirstName').val().trim() == "") {
        $('#FirstName').css('border-color', 'Red');
        isValid = false;
    } else {
        $('#FirstName').css('border-color', 'lightgrey');
    }
    if ($('#LastName').val().trim() == "") {
        $('#LastName').css('border-color', 'Red');
        isValid = false;
    } else {
        $('#LastName').css('border-color', 'lightgrey');
    }
    if ($('#Address').val().trim() == "") {
        $('#Address').css('border-color', 'Red');
        isValid = false;
    } else {
        $('#Address').css('border-color', 'lightgrey');
    }
    if ($('#Country').val().trim() == "") {
        $('#Country').css('border-color', 'Red');
        isValid = false;
    } else {
        $('#Country').css('border-color', 'lightgrey');
    }
    if ($('#Email').val().trim() == "") {
        $('#Email').css('border-color', 'Red');
        isValid = false;
    } else {
        $('#Email').css('border-color', 'lightgrey');
    }
    if ($('#Password').val().trim() == "") {
        $('#Password').css('border-color', 'Red');
        isValid = false;
    } else {
        $('#Password').css('border-color', 'lightgrey');
    } if ($('#ConfirmPassword').val().trim() == "") {
        $('#ConfirmPassword').css('border-color', 'Red');
        isValid = false;
    } else {
        $('#ConfirmPassword').css('border-color', 'lightgrey');
    }
    return isValid;
}