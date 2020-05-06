var logoffSuccessful = false;
function logOffClicked() {
    logoff(logoffSuccessCallback, logoffErrorCallback);
}

function logoffSuccessCallback() {
    logoffSuccessful = true;
    window.location = "/";
}

function logoffErrorCallback() {
    logoffSuccessful = false;
    window.location = "/";
    alert("Logoff failed. Not sure what happens now!");
}