function thingUpdateSubmit() {
    console.log("Updating thing");
    var form = $("#thingForm")[0];

    var thing = getThingFormData(form);
    var url = window.location.pathname;
    var id = url.substring(url.lastIndexOf('/') + 1);
    thing.ThingId = id;

    updateThing(thing, updateSuccessCallback, updateErrorCallback);
}

function updateSuccessCallback(thing) {
    console.log("Thing updated successfully");
    console.log(thing);
    window.location.replace("/");  //TODO redirect to correct url
}

//  TODO Handle household updating errors
function updateErrorCallback(response) {
    console.error("Error updating thing");
    console.log(response);
    alert("Error updating thing");
}