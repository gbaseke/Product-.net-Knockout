// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
function formatCurrency(value) {
    return "$" + value.toFixed(2);
}

function toObservableList(list) {
    var newList = [];
    $.each(list, function (i, obj) {
        var newObj = toObservableObject(obj);
        newList.push(newObj);
    });
    return newList;
}

function toObservableObject(obj) {
    var newObj = {};
    Object.keys(obj).forEach(function (key) {
        newObj[key] = ko.observable(obj[key])
    });

    return newObj;
}