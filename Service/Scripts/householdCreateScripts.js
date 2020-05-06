function householdCreateSubmit() {
    console.log("Creating household");
    var form = $("#householdForm")[0];

    var household = getHouseholdFormData(form);

    createHousehold(household, createSuccessCallback, createErrorCallback);
}

function createSuccessCallback(household) {
    console.log("Household created successfully");
    console.log(household);
    window.location.replace("/Households");
}

//  TODO Handle household creation errors
function createErrorCallback(response) {
    console.error("Error creating household");
    console.log(response);
    alert("Error creating household");
}