addressBook.services.address = addressBook.services.address || {};

addressBook.services.address.insert = function (data, onSuccess, onError) {

    var url = "/address/" + data.userId;

    var settings = {
        cache: false
        , contentType: "application/x-www-form-urlencoded; charset=UTF-8"
        , data: data
        , dataType: "json"
        , success: onSuccess
        , error: onError
        , type: "POST"
    };

    $.ajax(url, settings);
}

addressBook.services.address.update = function (data, onSuccess, onError) {
    console.log("address update data", data);
    var url = "/address/" + data.userId + "/" + data.id;

    var settings = {
        cache: false
        , contentType: "application/x-www-form-urlencoded; charset=UTF-8"
        , data: data
        , dataType: "json"
        , success: onSuccess
        , error: onError
        , type: "PUT"
    };

    $.ajax(url, settings);
}

addressBook.services.address.getAll = function (userId, onSuccess, onError) {

    var url = "/address/" + userId;

    var settings = {
        dataType: "json"
        , success: onSuccess
        , error: onError
        , type: "GET"
    };

    $.ajax(url, settings);
}

addressBook.services.address.getById = function (data, onSuccess, onError) {

    var url = "/address/" + data.userId + "/" + data.addressId;

    var settings = {
        dataType: "json"
        , success: onSuccess
        , error: onError
        , type: "GET"
    };

    $.ajax(url, settings);
}

addressBook.services.address.delete = function (data, onSuccess, onError) {

    var url = "/address/" + data.userId + "/" + data.addressId;

    var settings = {
        success: onSuccess
        , error: onError
        , type: "DELETE"
    };

    $.ajax(url, settings);
}