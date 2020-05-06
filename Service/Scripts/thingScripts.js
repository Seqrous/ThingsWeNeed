function Thing(ThingId, Name, Show, Needed, DefaultPrice, HouseholdId) {
    this.ThingId = ThingId;
    this.Name = Name;
    this.Show = Show;
    this.Needed = Needed;
    this.DefaultPrice = DefaultPrice;
    this.HouseholdId = HouseholdId;
}

function PurchaseRequestData(ThingId, Price) {
    this.ThingId = ThingId;
    this.Price = Price;
}   

/**
 * PurchaseDTO object
 * 
 * @param {Number} PurchaseId 
 * @param {SomeTimeDohicky} MadeOn 
 * @param {Number} Price 
 * @param {Number} MadeById 
 * @param {Number} ThingId 
 */
function Purchase (PurchaseId, MadeOn, Price, MadeById, ThingId) {
    this.PurchaseId = PurchaseId;
    this.MadeOn = MadeOn;
    this.Price = Price;
    this.MadeById = MadeById;
    this.ThingId = ThingId;
}

/**
 * Handle response that consists of a single Purchase object
 * @param {*} response
 * @returns {Purchase} 
 */
function singlePurchaseResponseHandle(response) {
    return new Purchase(
        response.PurchaseId,
        response.MadeOn,
        response.Price,
        response.MadeById,
        response.ThingId
    );
}

/**
 * Handle response that consists of multiple response objects
 * @param {*} response 
 * @returns {Purchase[]}
 */
function multiplePurchaseResponseHandle(response) {
    var purchases = [];
    for (i = 0; i < response.length; i++) {
        purchases[i] = singlePurchaseResponseHandle(response[i]);
    }
    return purchases;
}

function getThingFormData(form) {
    var elems = form.elements;
    var thing = new Thing(
        0,
        elems.Name.value,
        true,
        elems.Needed.checked,
        elems.DefaultPrice.value,
        elems.HouseholdId.value
    );

    return thing;
}

function singleThingResponseHandle(response) {
    return new Thing(
        response.ThingId, 
        response.Name, 
        response.Show, 
        response.Needed, 
        response.DefaultPrice, 
        response.HouseholdId
    );
}

function multipleThingResponseHandle(response) {
    var things = [];
    for (i = 0; i < response.length; i++) {
        things[i] = singleThingResponseHandle(response[i]);
    }
    return things;
}

function createThing(thing, successCallback, errorCallback) {
    $.ajax({
        type: 'POST',
        url: '/api/Things',
        data: JSON.stringify(thing),
        contentType: 'application/json',
        success: function (response) {
            successCallback(singleThingResponseHandle(response));
        },
        error: function (response) {
            errorCallback(response);
        }
    });
}

function deleteThing(id, successCallback, errorCallback) {
    $.ajax({
        type: 'DELETE',
        url: '/api/Things',
        contentType: 'application/json',
        success: function (response) {
            successCallback(singleThingResponseHandle(response));
        },
        error: function (response) {
            errorCallback(response);
        }
    });
}

function updateThing(thing, successCallback, errorCallback) {
    $.ajax({
        type: 'PUT',
        url: '/api/Things/' + thing.ThingId,
        data: JSON.stringify(thing),
        contentType: 'application/json',
        success: function (response) {
            successCallback(singleThingResponseHandle(response));
        },
        error: function (response) {
            errorCallback(response);
        }
    });
}

function getThing(id, successCallback, errorCallback) {
    $.ajax({
        type: 'GET',
        url: '/api/Things/' + id,
        data: JSON.stringify(),
        contentType: 'application/json',
        success: function (response) {
            successCallback(singleThingResponseHandle(response));
        },
        error: function (response) {
            errorCallback(response);
        }
    });
}

function getThingCollection(successCallback, errorCallback) {
    $.ajax({
        type: 'GET',
        url: '/api/Things',
        contentType: 'application/json',
        success: function (response) {
            successCallback(multipleThingResponseHandle(response))
        },
        error: function (response) {
            errorCallback(response);
        }
    });
}


/**
 * Callback for when a purchase collection was successfully created
 * 
 * @callback createPurchaseCollectionSuccessCallback
 * @param {Purchase[]} responseObjArray - array of created purchases
 */

/**
 * Callback for when a purchase collection was not successfully created
 * 
 * @callback createPurchaseCollectionErrorCallback
 * @param response - raw response from server
 */

/**
 * Creates a collection of purchases in a single request
 * 
 * @param {Purchase[]} purchaseObjArray - Array of thing Ids
 * @param {createPurchaseCollectionSuccessCallback} successCallback
 * @param {createPurchaseCollectionErrorCallback} errorCallback 
 */
function createPurchaseCollection(purchaseObjArray, successCallback, errorCallback) {
    $.ajax({
        type: 'POST',
        url: '/api/Purchases',
        data: JSON.stringify(purchaseObjArray),
        contentType: 'application/json',
        success: function (response) {
            successCallback(multiplePurchaseResponseHandle(response));
        },
        error: function (response) {
            errorCallback(response);
        }
    });
}