//site.js

// We use anonymous function here to esnure that everything becomes in the private scope of this file.

(function () {
    var ele = document.getElementById("userName");
    ele.innerHTML = "some other username";



    var main = document.getElementById("main");

    main.onmouseenter = function () {
        main.style.background = "#888";
    };


    main.onmouseleave = function () {
        main.style.background = "";
    };
})("some parameter"); // param is optional