function thingCreateSubmit() {
    console.log("Creating thing");
    var form = $("#thingForm")[0];
    var thing = getThingFormData(form);

    createThing(thing, createSuccessCallback, createErrorCallback);
}

function createSuccessCallback(thing) {
    console.log("Thing created successfully");
    console.log(thing);
    window.location = "/Things";
}

function createErrorCallback(response) {
    console.error("Error creating thing");
    console.log(response);
    alert("Error creating thing");
}