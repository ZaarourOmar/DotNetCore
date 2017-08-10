//site.js

// We use anonymous function here to esnure that everything becomes in the private scope of this file.

(function () {

    var sidebar = $("#sidebar");
    var wrapper = $("#wrapper");

    var hidden = false;
    $("#sidebarToggle").on("click", function () {
        sidebar.toggleClass("hide-sidebar");
        wrapper.toggleClass("hide-sidebar");
        hidden = !hidden;
        if(hidden)
        {
            $("#sidebarToggle").text("Show menu");
        }
        else
        {
            $("#sidebarToggle").text("Hide menu");

        }

        // we can do this by checking if $(this).hasclass(hide-sidebar) and set the text accordingly
    });
    
    
})();