function Household(HouseholdId, Name, Address) {
    this.HouseholdId = HouseholdId;
    this.Name = Name;
    this.Address = Address;
}

function Address(Address1, Address2, City, PostCode, Country) {
    this.Address1 = Address1;
    this.Address2 = Address2;
    this.City = City;
    this.PostCode = PostCode;
    this.Country = Country;
}

function getHouseholdFormData(form) {

    var fElems = form.elements;
    var household = new Household(
        0,
        fElems.Name.value,
        new Address(
            fElems.Address1.value,
            fElems.Address2.value,
            fElems.City.value,
            fElems.PostCode.value,
            fElems.Country.value
        )
    );

    return household;
}

function singleHouseholdResponseHandle(response) {
    var retAddress = new Address(
        response.Address.Address1, 
        response.Address.Address2,
        response.Address.City,
        response.Address.PostCode,
        response.Address.Country
    );

    var retHousehold = new Household(
        response.HouseholdId, 
        response.Name, 
        retAddress
    );

    return retHousehold;
}

function multipleHouseholdResponseHandle(response) {
    let householdArray = new Array(response.length);
    for (let index = 0; index < response.length; index++) {
        const element = response[index];
        householdArray[index] = singleHouseholdResponseHandle(element);
    }
    return householdArray();
}

function getHousehold(householdId, successCallback, errorCallback) {
        //  Test case
    // successCallback(new Household(
    //     999, 
    //     "TestHousehold", 
    //     new Address(
    //         "Test street 1",
    //         "Test street 2",
    //         "CandyTown",
    //         "9090",
    //         "DK"
    // )));

    $.ajax({
        type: 'GET',
        url: '/api/Households/' + householdId,
        contentType: "application/json",
        success: function(response) {
            successCallback(singleHouseholdResponseHandle(response));
        },
        error: function(response) {
            errorCallback(response);
        }
    });
}

function getHouseholdCollection(successCallback, errorCallback) {
    $.ajax({
        type: 'GET',
        url: '/api/Households',
        contentType: "application/json",
        success: function(response) {
            successCallback(multipleHouseholdResponseHandle(response));
        },
        error: function(response) {
            errorCallback(response);
        }
    });
}

function createHousehold(household, successCallback, errorCallback) {

    //  Test case
    // successCallback(new Household(
    //     999, 
    //     "TestHousehold", 
    //     new Address(
    //         "Test street 1",
    //         "Test street 2",
    //         "CandyTown",
    //         "9090",
    //         "DK"
    // )));

    $.ajax({
        type: 'POST',
        url: '/api/Households',
        data: JSON.stringify(household),
        contentType: "application/json",
        success: function(response) {
            successCallback(singleHouseholdResponseHandle(response));
        },
        error: function(response) {
            errorCallback(response);
        }
    });
}


function updateHousehold(household, successCallback, errorCallback) {
    //  Test case
    // successCallback(new Household(
    //     999, 
    //     "TestHousehold", 
    //     new Address(
    //         "Test street 1",
    //         "Test street 2",
    //         "CandyTown",
    //         "9090",
    //         "DK"
    // )));

    $.ajax({
        type: 'PUT',
        url: '/api/Households/' + household.HouseholdId,
        contentType: "application/json",
        data: JSON.stringify(household),
        success: function(response) {
            successCallback(singleHouseholdResponseHandle(response));
        },
        error: function(response) {
            errorCallback(response);
        }
    });
}


// function deleteHousehold(householdId, successCallback, errorCallback) {

//     $.ajax({
//         type: 'DELETE',
//         url: '/api/Households/' + householdId,
//         contentType: "application/json",
//         success: function(response) {
//             successCallback(singleHouseholdResponseHandle(response));
//         },
//         error: function(response) {
//             errorCallback(response);
//         }
//     });
// }


function leaveHousehold(householdId, successCallback, errorCallback) {
        //  Test case
    // successCallback(new Household(
    //     999, 
    //     "TestHousehold", 
    //     new Address(
    //         "Test street 1",
    //         "Test street 2",
    //         "CandyTown",
    //         "9090",
    //         "DK"
    // )));

    $.ajax({
        type: 'DELETE',
        url: '/api/Users/Households/' + householdId,
        contentType: 'application/json',
        success: function (response) {
            successCallback(singleHouseholdResponseHandle(response));
        },
        error: function (response) {
            errorCallback(response);
        }
    });
}



function joinHousehold(householdId, successCallback, errorCallback) {
        //  Test case
    // successCallback(new Household(
    //     999, 
    //     "TestHousehold", 
    //     new Address(
    //         "Test street 1",
    //         "Test street 2",
    //         "CandyTown",
    //         "9090",
    //         "DK"
    // )));

    $.ajax({
        type: 'PUT',
        url: '/api/Users/Households/' + householdId,
        contentType: 'application/json',
        success: function (response) {
            successCallback(singleHouseholdResponseHandle(response));
        },
        error: function (response) {
            errorCallback(response);
        }
    });
}