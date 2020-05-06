function login(username, password, successCallback, errorCallback) {
    $.ajax({
        type: 'POST',
        url: '/api/Users/Login',
        data: JSON.stringify({
            Username: username,
            Password: password
        }),
        contentType: 'application/json',
        success: function (response) {
            successCallback(response);
        },
        error: function (response) {
           errorCallback(response); 
        }
    });
}

function logoff(successCallback, errorCallback) {
    $.ajax({
        type: 'POST',
        url: '/api/Users/LogOff',
        contentType: 'application/json',
        success: function (response) {
            successCallback(response);
        },
        error: function (response) {
            errorCallback(response);
        }
    });
}


function register(data, successCallback, errorCallback) {
    console.log("Sending register data");
    $.ajax({
        type: "POST",
        url: "/api/Users/register",
        data: JSON.stringify(data),
        contentType: "application/json",
        
        success: function (response) {
            successCallback(response);
        },

        error: function (response) {
            errorCallback(response);
        }
    });
}