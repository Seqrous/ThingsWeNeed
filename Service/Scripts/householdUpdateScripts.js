function householdUpdateSubmit() {
    console.log("Updating household");
    var form = $("#householdForm")[0];

    var household = getHouseholdFormData(form);
    var url = window.location.pathname;
    var id = url.substring(url.lastIndexOf('/') + 1);
    household.HouseholdId = id;

    updateHousehold(household, updateSuccessCallback, updateErrorCallback);
}

function updateSuccessCallback(household) {
    console.log("Household updated successfully");
    console.log(household);
    window.location.replace("/");  //TODO redirect to correct url
}

//  TODO Handle household updating errors
function updateErrorCallback(response) {
    console.error("Error updating household");
    console.log(response);
    alert("Error updating household");
}