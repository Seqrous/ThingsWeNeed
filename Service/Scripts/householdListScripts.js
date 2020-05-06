function leaveHouseholdClicked(id) {
    console.log("Asking user if they want to leave household");
    if (confirm("Are you sure you want to leave this household?")) {
        console.log("User leaving household");
        leaveHousehold(id, leaveSuccessCallback, leaveErrorCallback);
    } else {
        console.log("User chose not to leave household");
    }
}

function leaveSuccessCallback(household) {
    console.log("Household left successfully");
    console.log(household);

    location.reload();
}

function leaveErrorCallback(response) {
    console.error("Error leaving household");
    alert("Error leaving household");
} 



function joinHouseholdClicked() {
    var householdId = $("#householdIdTextBox")[0].value;
    joinHousehold(householdId, joinSuccessCallback, joinErrorCallback);
}

function joinSuccessCallback(household) {
    console.log("Joined household successfullt");
    console.log(household);
    alert("Success joining household");
    location.reload();
}

function joinErrorCallback(response) { 
    console.error("Error joining household");
    console.log(response);
    alert("Error joining household");
}