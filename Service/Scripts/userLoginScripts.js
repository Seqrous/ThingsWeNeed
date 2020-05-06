function loginClicked() {
    console.log("Logging in");

    var fElems = $("#loginForm")[0].elements;

    var username = fElems.Username.value,
        password = fElems.Password.value;

    login(username, password, loginSuccessCallback, loginErrorCallback);
}

function loginSuccessCallback(response) {
    console.log("Login successful");
    window.location = "/";
}

function loginErrorCallback(response) {     //TODO Handle login errors
    console.error("Login failed");
    console.log(response);
    alert("Login failed");
}