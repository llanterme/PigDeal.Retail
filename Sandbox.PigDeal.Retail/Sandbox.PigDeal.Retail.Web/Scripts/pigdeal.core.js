$(document).ready(function () {

//    $('#txbOutletName').change(function () {
//        CheckDuplicate($("#txbOutletName").val(), "#txbOutletName");

//    });

//    $('#txbLoginEmail').change(function () {
//        CheckDuplicate($("#txbLoginEmail").val(), "#txbLoginEmail");

//    });

//    $('#btnRegister').click(function () {
//        CreateOutlet();

//    });


});




/* Create Outlet */
function CreateOutlet() {

    // Disable save button
    ShowModal("Creating User..") 

    var outlet = new Object();
    outlet.OutletName = $("#txbOutletName").val();
    outlet.Description = $("#txbDescription").val();
    outlet.LoginEmail = $("#txbLoginEmail").val();
    outlet.Password = $("#txbPassword1").val();
    outlet.ContactNumber = $("#txbTelephone").val();
    outlet.ContactPerson = $("#txbContactPerson").val();

     var DTO = { 'outlet': outlet };

     $.ajax({
         type: "POST",
         url: "Ajax/AjaxService.svc/CreateOutlet",
         data: JSON.stringify(DTO),
         contentType: "application/json; charset=utf-8",
         dataType: "json",
         success: function (response) {
            
            $('#MainContent_PanelRegistration').css('display', 'none');
             $('#userCreateConfirmation').append('User created successfully. Please add at least 1 branch.');
             HideModal(); 
         },
         error: function (msg) {
             //alert(msg);
             HideModal();
         }
     });
        return false;

    

}

/* UTILS */
function ShowModal(blockmessage) {
    $.blockUI({ message: blockmessage, css: {
        border: 'none',
        padding: '15px',
        backgroundColor: '#000',
        height: '20px',
        '-webkit-border-radius': '10px',
        '-moz-border-radius': '10px',
        opacity: .5,
        color: '#fff'
    }
    });
}

function HideModal() {
    $.unblockUI();
}

function CheckDuplicate(param, field) {


    if ($("#txbOutletName").val() != "" || $("#txbLoginEmail").val() != "") {

        // Reset
        $(field).removeClass('validation');
        $('#validationMessage').text('');


        // Show modal
        ShowModal("checking " + field.replace("#txb", "").toLowerCase() + " availability....");


        // Call web service
        var DTO = { 'param': param };

        $.ajax({
            type: "POST",
            url: "Ajax/AjaxService.svc/DoesExists",
            data: JSON.stringify(DTO),
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (response) {

                if (response.d == true) {

                    //Do something if true
                }

                else {

                    $(field).addClass('validation');
                    $(field).attr('value', '');
                    $('#validationMessage').append(param + " is already registered!");
                }

                HideModal();

            },
            failure: function (msg) {
                alert(msg.d);
                HideModal();
            }
        });

    }
}

