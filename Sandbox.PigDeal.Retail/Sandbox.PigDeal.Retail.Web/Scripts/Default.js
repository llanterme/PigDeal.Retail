var prm = Sys.WebForms.PageRequestManager.getInstance();
prm.add_endRequest(EndRequest);
prm.add_initializeRequest(InitializeRequest);
var blockTimer;
var blockTimerFired;

function InitializeRequest(sender, args) {
    blockTimer = setTimeout(blockPage, 100);
    blockTimerFired = false;
}

function EndRequest(sender, args) {
    unblockPage();
}

function unblockPage() {
    // Check if the timer has run yet, and if it hasn't, cancel it
    if (blockTimerFired) {
       document.body.style.cursor = "default";
        $.unblockUI();
    }
    else {
        clearTimeout(blockTimer);
    }
}

function blockPage() {
    document.body.style.cursor = "wait";
    var loadingMessage = '<div>Please wait...</div>';
    
     $.blockUI({ message: loadingMessage, css: {
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


    blockTimerFired = true;
}

function HandleChange() {
    parent.frmListBox2.document.location.href = "Register.asp?StateValue=" + document.forms[0].selState.value;
}