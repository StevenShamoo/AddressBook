var addressBook = {
    utilities: {}
    , layout: {}
    , page: {
        handlers: {
        }
        , startUp: null
    }

    , services: {
        apiPrefix: "",
        media: {}
    }
    , ui: {}

};

addressBook.layout.startUp = function () {

    console.debug("addressBook.layout.startUp");

    if (addressBook.page.startUp) {
        console.debug("addressBook.page.startUp");
        addressBook.page.startUp();
    }

};



$(document).ready(addressBook.layout.startUp);