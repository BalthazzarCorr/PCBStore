$(document).ready(function() {
    loadData();
});



//Load Data function

function loadData() {
    $.ajax({
        url: "/admin/users/listall",
        type: "GET",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function(result) {
            var html = '';
            $.each(result,
                function(key, item) {
                    html += '<tr>';
                    html += '<td>' + item.username + '</td>';
                    html += '<td>' + item.email + '</td>';
                    html += '</tr>';


                });
            $('#ajaxResponse').html(html);
        },
        error: function(errormessage) {
            alert(errormessage.responseText);
        }
    });
}


//Add Data Function
function Add() {
    var res = validate();
    if (res == false) {
        return false;
    }
    var empObj = {
        EmployeeID: $('#EmployeeID').val(),
        Username: $('#Username').val(),
        Name: $('#Name').val(),
        Email: $('#Email').val(),
        Password: $('#Password').val(),
        Birthdate: $('#Birthdate').val()
    };
    $.ajax({
        url: "/admin/users/Add",
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
    $('#EmployeeID').val("");
    $('#Username').val("");
    $('#Name').val("");
    $('#Email').val("");
    $('#Password').val("");
    $('#btnUpdate').hide();
    $('#btnAdd').show();
    $('#Username').css('border-color', 'lightgrey');
    $('#Name').css('border-color', 'lightgrey');
    $('#Email').css('border-color', 'lightgrey');
    $('#Password').css('border-color', 'lightgrey');
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
    if ($('#Name').val().trim() == "") {
        $('#Name').css('border-color', 'Red');
        isValid = false;
    } else {
        $('#Name').css('border-color', 'lightgrey');
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
    }
    return isValid;
}