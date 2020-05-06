/**
 * Array that holds the Ids of thing that the user is buying
 */
var buyList = [];

/**
 * Adds the Thing Id to buyList, changes the input cell in Thing table to price input/cancel button
 * @param {Number} id 
 */
function buyButtonClicked(id) {
    buyList.push(id);
    var $row = $("tr#" + id);
    $row.find("span.price").show();
    $row.find("span.buy").hide();

    console.log(buyList);
}

/**
 * Removes the id from buyList, changes the input cell in thing table to buy/edit/need buttons
 * @param {Number} id 
 */
function cancelButtonClicked(id) {
    for( var i = 0; i < buyList.length; i++){ 
        if ( buyList[i] === id) {
            buyList.splice(i, 1); 
        }
    }
    var $row = $("tr#" + id);
    $row.find("span.price").hide();
    $row.find("span.buy").show();

    console.log("Cancel clicked");
    console.log(buyList);
}

/**
 * Creates an array of PurchaseRequestData objects (contains the thing Id and given price) and passes to the request
 */
function finishClicked() {
    
    var purchaseObjArray = [];

    for ( var i = 0; i < buyList.length; i++ ) {
        var price = $("tr#" + buyList[i]).find("input.price-input")[0].value;
        purchaseObjArray[i] = new PurchaseRequestData(buyList[i], price);
    }

    console.log("finished");
    console.log(purchaseObjArray);

    createPurchaseCollection(purchaseObjArray, createPurchaseCollectionSuccessCallback, createPurchaseCollectionErrorCallback);
}


function createPurchaseCollectionSuccessCallback(purchases) {
    console.log("Created purchases successfully");
    console.log(purchases);
    location.reload();
}

function createPurchaseCollectionErrorCallback(response) {
    console.error("Error creating purchases");
    console.log(response);
}