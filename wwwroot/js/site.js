// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

var nightModeToggleButton = document.querySelector(".nightModeButton");
var darkheader = document.querySelector(".darkheader");
var header = document.querySelector(".header");
var body = document.querySelector("body");

nightModeToggleButton.onclick = function () {
    nightModeToggleButton.classList.toggle("night-mode");
    darkheader.classList.toggle("night-mode");
    body.classList.toggle("night-mode");
};
