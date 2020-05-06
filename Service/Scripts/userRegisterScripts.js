function RegisterData(Email, Username, Password, ConfirmPassword, FName, LName, PhoneNumber) {
    this.Email = Email;
    this.Username = Username;
    this.Password = Password;
    this.ConfirmPassword = ConfirmPassword;
    this.FName = FName;
    this.LName = LName;
    this.PhoneNumber = PhoneNumber;
}

function registerClicked() {
    var formElems = $("#registerForm")[0].elements;
    var data = new RegisterData (
        formElems.Email.value,
        formElems.Username.value,
        formElems.Password.value,
        formElems.ConfirmPassword.value,
        formElems.FName.value,
        formElems.LName.value,
        formElems.PhoneNumber.value
    );

    console.log("Register data:");
    console.log(data);

    register(data, registerSuccessCallback, registerErrorCallback);
}

function registerSuccessCallback(response) {
    console.log("Register successful");
    console.log(response);
    window.location = "/Things";
}

function registerErrorCallback(response) {
    console.error("Register unsuccessful");
    console.log(response);
    alert("Register unsuccessful");
}







////    Unused code for displaying error data
////    Needs more work. Better to do in MVC error handling filter


// var responseTextObject = JSON.parse(response.responseText);
// console.log(responseTextObject);
// var errorText = "";

// for (var prop in responseTextObject.ModelState) {
//     if (Object.prototype.hasOwnProperty.call(responseTextObject.ModelState, prop)) {
//         errorText.concat(prop[0]);
//     }
// }



// $("#errorDisplay")[0].innerHTML = errorText;